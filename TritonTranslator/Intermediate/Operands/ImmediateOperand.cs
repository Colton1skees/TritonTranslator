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
        public uint Bitsize => Immediate.BitSize;

        public bool IsWritable => false;

        public Immediate Immediate { get; }

        public ImmediateOperand(Immediate immediate)
        {
            Immediate = immediate;
        }
    }
}
