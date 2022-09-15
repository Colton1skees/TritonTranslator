using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    public class MemoryAccess : BitsVector
    {
        public MemoryAccess()
        {

        }

        public ArchitectureId Architecture { get; set; }

        /// <summary>
        /// Gets the segment register.
        /// </summary>
        public Register SegmentReg { get; set; }

        /// <summary>
        /// Gets the base register.
        /// </summary>
        public Register BaseRegister { get; set; }

        /// <summary>
        /// Gets the immediate displacement.
        /// </summary>
        public Immediate Displacement { get; set; }

        /// <summary>
        /// Gets the memory access scale.
        /// </summary>
        public Immediate Scale { get; set; }

        /// <summary>
        /// Gets the index register.
        /// </summary>
        public Register IndexRegister { get; set; }

        /// <summary>
        /// Gets the pc relative address. 
        /// This is typically only used with LEAs.
        /// </summary>
        public ulong PcRelative { get; set; }

        /// <summary>
        /// Gets the bite size of the memory access.
        /// </summary>
        public uint BitSize => VectorSize;

        /// <summary>
        /// Gets the byte size of the memory access.
        /// </summary>
        public uint Size
        {
            get => VectorSize / 8;
            set
            {
                SetBits((value * BitSizes.Byte) - 1, 0);
            }
        }
    }
}
