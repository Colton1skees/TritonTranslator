using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Intermediate.Operands
{
    /// <summary>
    /// Class for IR instruction operands.
    /// </summary>
    public interface IOperand
    {
        /// <summary>
        /// Gets the bit size of the operand.
        /// </summary>
        public uint Bitsize { get; }

        /// <summary>
        /// Gets whether the operand can be used as a destination.
        /// (e.g. registers and temporaries are writable, whereas immediates are not).
        /// </summary>
        public bool IsWritable { get; }

        /// <summary>
        /// Gets the operand name.
        /// </summary>
        public string Name { get; }
    }
}
