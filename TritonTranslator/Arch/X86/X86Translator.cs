using System;
using System.Collections.Generic;
using System.Linq;
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

            if (destReg.BitSize == 32)
            {
                // Zero extend the expression to 64 bits.
                var rootDestination = X86Registers.RegisterNodeMapping[architecture.GetRootParentRegister(destReg.Register).Id];
                var extSize = rootDestination.BitSize - destReg.BitSize;
                var zx = new ZxNode(extSize, expression.Destination);

                // Store a new expression, which writes to the higher portion of the register.
                // Transforms:
                //      eax = add t0:32, t1:32
                // to:
                //      eax = add t0:32, t1:32
                //      rax = Zx(eax) to i64
                output.Add(new SymbolicExpression(zx, rootDestination));
            }

            else if (destReg.BitSize == 64)
            {
                // Truncate the expression to 32 bits.
                var childDest = X86Registers.RegisterMapping.Single(x => x.Value.ParentId == destReg.Register.Id && x.Value.BitSize == 32);
                var trunc = new ExtractNode(childDest.Value.BitSize - 1, 0, expression.Destination);

                // Store a new expression, which writes to the lower portion of the register.
                // Transforms:
                //      rax = add t0:64, t1:64
                // to:
                //      rax = add t0:64, t1:64
                //      eax = extract 0 to 31, rax
                output.Add(new SymbolicExpression(trunc, X86Registers.RegisterNodeMapping[childDest.Key]));
            }

            else
            {
                throw new InvalidOperationException(String.Format("Cannot alias register {0}", destReg));
            }

            return output;
        }


        /// <summary>
        /// For each reference to the lower portion of a register(e.g. EAX),
        /// replace it with a truncation operation(e.g. Trunc RAX to i32).
        /// 
        /// There are some downsides to this approach(i.e. conflated dataflow),
        /// but I prefer this over trying to preserve alias information in the
        /// intermediate representation.
        /// </summary>
        private void TruncateRegisterAliases(AbstractNode node)
        {
            for (int i = 0; i < node.Children.Count; i++)
            {
                var childNode = node.Children[i];
                if (childNode is RegisterNode registerNode)
                {
                    node.Children[i] = GetTruncatedParentRegisterExpression(registerNode);
                }

                else
                {
                    TruncateRegisterAliases(childNode);
                }
            }
        }

        private AbstractNode GetTruncatedParentRegisterExpression(RegisterNode registerNode)
        {
            // Get the root parent of the input register(i.e. ax becomes RAX).
            var rootParent = X86Registers.RegisterNodeMapping[architecture.GetRootParentRegister(registerNode.Register).Id];

            // If the input register node is already the root parent, then return an unmodified expression.
            if (rootParent.Register.Id == registerNode.Register.Id)
                return registerNode;

            // Return an expression that extracts the lower register portion from the input.
            return new ExtractNode(registerNode.BitSize - 1, 0, rootParent);
        }
    }
}
