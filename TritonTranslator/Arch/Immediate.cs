using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    /// <summary>
    /// TODO: Finish this class.
    /// </summary>
    public class Immediate : BitsVector
    {
        /// <summary>
        /// Gets the immediate value.
        /// </summary>
        public ulong Value { get; set; }

        /// <summary>
        /// Gets the register size in bits.
        /// </summary>
        public uint BitSize => VectorSize;

        /// <summary>
        /// Gets the register size in bytes.
        /// </summary>
        public uint Size => VectorSize / 8;

        public Immediate(ulong value, uint size)
        {
            Value = value;
            if (size == 0)
                throw new Exception("Immediate size must be greater than zero..");
            else if (size > ByteSizes.MaxSupported)
                throw new Exception(String.Format("Immediate size {0} is greater than max size of {1}", size, ByteSizes.MaxSupported));
            else if (size % 8 != 0)
                throw new Exception(String.Format("Immediate size {0} is not divisble by 8.", size));

            // Update the bit vector high / low.
            SetBits((size * BitSizes.Byte) - 1, 0);
        }

        public override string ToString()
        {
            return "0x" + Value.ToString("X");
        }
    }
}
