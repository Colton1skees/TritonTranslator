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
            var expressions = semantics.ExpressionDatabase.SymbolicExpressions.ToList();

            // Properly handle register aliasing.
            foreach(var expression in expressions)
            {
                UpdateRegisterAliasing(expression);
            }

            return expressions;
        }

        private void UpdateRegisterAliasing(SymbolicExpression expression)
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
            if(rootDestination.BitSize != 64)
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
    }
}
