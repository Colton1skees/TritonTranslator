using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;

namespace TritonTranslator.Intermediate.Operands
{
    /// <summary>
    /// Constant immediate operand.
    /// </summary>
    public class ImmediateOperand : IOperand
    {
        public ulong Value { get; set; }

        public uint Bitsize { get; }

        public bool IsWritable => false;

        public string Name => String.Format("i{0} 0x{1}", Bitsize, Value.ToString("X"));

        public ImmediateOperand(ulong value, uint bitSize)
        {
            Value = value;
            Bitsize = bitSize;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
