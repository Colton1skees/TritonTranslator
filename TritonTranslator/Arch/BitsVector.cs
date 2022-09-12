using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    public class BitsVector
    {
        private uint high;

        private uint low;

        /// <summary>
        /// Gets or sets the highest bit of the bitvector.
        /// </summary>
        public uint High
        {
            get => high;
            set
            {
                high = value;
                if (high > BitSizes.MaxSupported)
                {
                    throw new Exception(string.Format("The highest bit {0} cannot be greater than the max supported size {1}",
                        high, BitSizes.MaxSupported));
                }

                if (VectorSize % BitSizes.Byte != 0 && VectorSize != BitSizes.Flag)
                    throw new Exception(string.Format("The vector size {0} is not a multiple of 8.", VectorSize));
            }
        }

        /// <summary>
        /// Gets or sets the lower bit of the vector,
        /// </summary>
        public uint Low
        {
            get => low;
            set
            {
                low = value;
                if (low > high)
                {
                    throw new Exception(string.Format("The lowest bit {0} cannot be greater than the highest bit {1}",
                        low, high));
                }

                if (low % ByteSizes.Byte != 0)
                    throw new Exception(string.Format("The lower bit {0} is not a multiple of 8.", Low));
            }
        }

        /// <summary>
        /// Gets the vector size.
        /// </summary>
        public uint VectorSize => (High - Low) + 1;

        /// <summary>
        /// Gets the max value.
        /// </summary>
        public ulong MaxValue
        {
            get
            {
                ulong max = unchecked((ulong)-1);
                max = max >> ((int)(64 - VectorSize));
                return max;
            }
        }

        public BitsVector()
        {
            High = 0;
            Low = 0;
        }

        public BitsVector(BitsVector other)
        {
            High = other.High;
            Low = other.Low;
        }

        public BitsVector(uint high, uint low)
        {
            High = high;
            Low = low;
        }

        public void SetBits(uint high, uint low)
        {
            // Set both fields.
            this.high = high;
            this.low = low;

            // Run setters to validate that the input is valid.
            High = high;
            Low = low;
        }
    }
}
