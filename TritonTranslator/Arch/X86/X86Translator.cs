using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;
using TritonTranslator.Expression;

namespace TritonTranslator.Arch.X86
{
    /// <inheritdoc cref="IArchitectureTranslator"/>
    public class X86Translator : IArchitectureTranslator
    {
        private readonly ICpuArchitecture architecture;

        private readonly X86Semantics semantics;

        public X86Translator(ICpuArchitecture architecture)
        {
            this.semantics = new X86Semantics(architecture);
            this.architecture = architecture;
        }

        /// <inheritdoc cref="IArchitectureTranslator.TranslateInstruction(Instruction)"/>
        public IEnumerable<SymbolicExpression> TranslateInstruction(Instruction instruction)
        {
            // Note: This is a goto place to start debugging when translation is incorrect : )
            bool debugging = false;
            if (debugging && instruction.Address == 0x1400F2948)
                Debugger.Break();
            

            // Clear the symbolic expression list beforehand.
            semantics.ExpressionDatabase.SymbolicExpressions.Clear();

            // Translate the instruction.
            bool success = semantics.BuildSemantics(instruction);

            // If the instruction fails to translate, return null.
            if (!success)
                return null;

            // Create a clone of the lifted expression list.
            List<SymbolicExpression> newExpressions = new();

            // Properly handle register aliasing.
            foreach (var expression in semantics.ExpressionDatabase.SymbolicExpressions)
            {
                newExpressions.AddRange(PropagateRegisterAliases(expression));
            }

            return newExpressions;
        }

        /// <summary>
        /// If the expression destination is the lower 32 bits of a GPR,
        /// then zero extend the source and destination to 64 bits.
        /// See: https://stackoverflow.com/q/11177137
        /// </summary>
        private void ZeroExtendLowGprBits(SymbolicExpression expression)
        {
            // Exit if the destination node is not a register.
            var destReg = expression.Destination as RegisterNode;
            if (destReg == null)
                return;

            // Exit if a 64 bit expression is being written to a 64 bit GPR.
            var rootDestination = X86Registers.RegisterNodeMapping[architecture.GetRootParentRegister(destReg.Register).Id];
            if (destReg.BitSize == 64 && rootDestination.BitSize == 64)
                return;

            // Exit if the destination is a flag register.
            if (rootDestination.BitSize == 1)
                return;

            // Exit if the destination is not a 64 bit GPR.
            if (rootDestination.BitSize != 64)
                throw new InvalidOperationException(String.Format("Cannot alias register {0} with {1}", rootDestination, destReg));

            // Handle zero extension when writing to the lower 32 bits of a register.
            if (expression.Source.BitSize == 32)
            {
                var extSize = rootDestination.BitSize - destReg.BitSize;
                expression.Destination = rootDestination;
                expression.Source = new ZxNode(extSize, expression.Source);
            }

            // TODO: Handle aliasing when writing to 8-bit or 16-bit registers.
            else
            {
                throw new InvalidOperationException(String.Format("Cannot alias register {0} with {1}", rootDestination, destReg));
            }
        }

        /// <summary>
        /// If the expression destination is the lower 32 bits of a GPR,
        /// then zero extend the source and destination to 64 bits.
        /// See: https://stackoverflow.com/q/11177137
        /// </summary>
        private List<SymbolicExpression> PropagateRegisterAliases(SymbolicExpression expression)
        {
            var output = new List<SymbolicExpression>();
            output.Add(expression);

            // Exit if the destination node is not a register.
            var destReg = expression.Destination as RegisterNode;
            if (destReg == null)
                return output;

            // This is a temporary solution to allow branch recovery code
            // work. 
            // TODO: Remove this.
            if (destReg.Register.Id == register_e.ID_REG_X86_RIP)
                return output;

            // Skip if we're writing to a flag register.
            if (destReg.BitSize == 1)
                return output;

            output.AddRange(UpdateAliasingRegisters(destReg.Register, expression));

            return output;
        }

        /// <summary>
        /// Gets a set of expressions which update aliasing registers.
        /// </summary>
        private List<SymbolicExpression> UpdateAliasingRegisters(Register source, SymbolicExpression expression)
        {
            var output = new List<SymbolicExpression>();
            var sourceRoot = X86Registers.RegisterNodeMapping[architecture.GetRootParentRegister(source).Id];
            foreach (var regId in X86Registers.RegisterNodeMapping.Keys)
            {
                // Skip if this is the destination register, since we've already written to it.
                if (regId == source.Id)
                    continue;

                // Skip if this register does not alias with the destination register. 
                if (architecture.GetRootParentRegister(regId).Id != sourceRoot.Register.Id)
                    continue;

                // Throw if two aliasing registes have the same size. This is impossible.
                var aliasingRegister = architecture.GetRegister(regId);
                var write = WriteToRegister(source, aliasingRegister);
                if (write != null)
                    output.Add(write);

            }

            return output;
        }



        // Construct an expression for the value of {originalWrittenRegister} which may be legally stored in {newlyUpdatedRegister}.
        private SymbolicExpression WriteToRegister(Register originalWrittenRegister, Register newlyUpdatedRegister)
        {
            // If the registers don't overlap(e.g. AL and AX), then do nothing. 
            if (!originalWrittenRegister.OverlapsWith(newlyUpdatedRegister))
                return null;
            
            // If the registers do overlap, then we need to compute an expression
            // to update the register, while taking alias information into account.
            AbstractNode expr = null;

            if(newlyUpdatedRegister.High > originalWrittenRegister.High)
            {
                if (newlyUpdatedRegister.BitSize == 64 && originalWrittenRegister.BitSize == 32)
                {
                    expr = new ZxNode(32, new RegisterNode(originalWrittenRegister));
                }

                else
                {

                    // If the new register being updated(e.g. eax) starts at a higher point
                    // than the original register(e.g. ax), then first we need to extract
                    // out the bits which aren't updated. This would give us the higher 16 bits of eax for example.
                    expr = new ExtractNode(newlyUpdatedRegister.High, originalWrittenRegister.High + 1, new RegisterNode(newlyUpdatedRegister));

                    // Then we need to concatenate the contents together, such that you have something along the lines of
                    // Concat(eax[31..15], ax).
                    expr = new ConcatNode(expr, new RegisterNode(originalWrittenRegister));

                    if (originalWrittenRegister.Low != 0)
                        expr = new ConcatNode(expr, new ExtractNode(originalWrittenRegister.Low - 1, 0, new RegisterNode(newlyUpdatedRegister)));
                }
            }

            // If the new register being updated(e.g. ax) starts at a lower point than
            // the original register, then we need to truncate.
            else if(newlyUpdatedRegister.High < originalWrittenRegister.High)
            {
                // If the new register being updated(e.g. ax) has a high bit index than the original
                // register being updated(e.g.) eax, then transform this such that we have extract(ax.Start, ax.End, eax).
                expr = new ExtractNode(newlyUpdatedRegister.High, newlyUpdatedRegister.Low, new RegisterNode(originalWrittenRegister));
            }

            else 
            {
                if (IsHigh8Bits(newlyUpdatedRegister.Id))
                {
                    expr = new ExtractNode(newlyUpdatedRegister.High, newlyUpdatedRegister.Low, new RegisterNode(originalWrittenRegister));
                }

                else if (IsHigh8Bits(originalWrittenRegister.Id))
                {
                    expr = new ExtractNode(originalWrittenRegister.High, originalWrittenRegister.Low, new RegisterNode(originalWrittenRegister));

                    expr = new ConcatNode(expr, new ExtractNode(originalWrittenRegister.Low - 1, 0, new RegisterNode(newlyUpdatedRegister)));
                }

                else
                {
                    throw new InvalidOperationException();
                }
            }

            return new SymbolicExpression(expr, new RegisterNode(newlyUpdatedRegister)); 
        }


        private bool IsHigh8Bits(register_e regId)
            => regId == register_e.ID_REG_X86_AH || regId == register_e.ID_REG_X86_BH || regId == register_e.ID_REG_X86_CH || regId == register_e.ID_REG_X86_DH;
    }
}
