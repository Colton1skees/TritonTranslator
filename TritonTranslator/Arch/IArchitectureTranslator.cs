using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Expression;

namespace TritonTranslator.Arch
{
    /// <summary>
    /// Class for translating architecture instructions to an intermediate representation.
    /// </summary>
    public interface IArchitectureTranslator
    {
        /// <summary>
        /// Translates the provided instruction to an intermediate representation.
        /// </summary>
        /// <returns>If the instruction is supported, then a collection of translated expressions is returned.
        /// Otherwise, we return null.</returns>
        public IEnumerable<SymbolicExpression> TranslateInstruction(Instruction instruction);
    }
}
