using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    public static class BitSizes
    {
        public const uint Flag = 1;

        public const uint Byte = 8;

        public const uint Word = 16;

        public const uint Dword = 32;

        public const uint Qword = 64;

        public const uint Fword = 80;

        public const uint Dqword = 128;

        public const uint Qqword = 256;

        public const uint Dqqword = 512;

        public const uint MaxSupported = Dqqword;
    }
}
