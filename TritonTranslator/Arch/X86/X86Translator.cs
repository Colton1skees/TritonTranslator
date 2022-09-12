using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Expression;

namespace TritonTranslator.Arch.X86
{
    /// <inheritdoc cref="IArchitectureTranslator"/>
    public class X86Translator : IArchitectureTranslator
    {
        private readonly X86Semantics semantics;

        public X86Translator(ICpuArchitecture architecture)
        {
            this.semantics = new X86Semantics(architecture);
        }

        /// <inheritdoc cref="IArchitectureTranslator.TranslateInstruction(Instruction)"/>
        public IEnumerable<SymbolicExpression> TranslateInstruction(Instruction instruction)
        {
            // Clear the symbolic expression list beforehand.
            semantics.ExpressionDatabase.SymbolicExpressions.Clear();

            // Translate the instruction.
            bool success = semantics.BuildSemantics(instruction);

            // If we succeed, return a clone of the lifted expression list.
            // Otherwise, return null.
            return success ? semantics.ExpressionDatabase.SymbolicExpressions.ToList() : null;
        }
    }
}
