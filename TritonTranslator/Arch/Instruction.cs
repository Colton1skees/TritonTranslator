using Iced.Intel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    public enum Prefix : byte
    {
        ID_PREFIX_INVALID = 0,  //!< invalid
        ID_PREFIX_LOCK,         //!< LOCK
        ID_PREFIX_REP,          //!< REP
        ID_PREFIX_REPE,         //!< REPE
        ID_PREFIX_REPNE,        //!< REPNE

        /* Must be the last item */
        ID_PREFIX_LAST_ITEM     //!< must be the last item
    }

    public class Instruction
    {
        public ulong Address { get; set; }

        public ulong NextAddress => Address + Size;

        public uint Size { get; set; }

        public Prefix Prefix { get; set; }

        public Mnemonic Type { get; set; }

        public List<OperandWrapper> Operands { get; } 

        public Instruction(int defaultCapacity = 0)
        {
            Operands = new List<OperandWrapper>(defaultCapacity);
        }

    }
}
