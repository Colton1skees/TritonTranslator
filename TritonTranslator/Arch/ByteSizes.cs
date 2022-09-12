using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    public static class ByteSizes
    {
        public const uint Byte = 1;

        public const uint Word = 2;

        public const uint Dword = 4;

        public const uint Qword = 8;

        public const uint Fword = 10;

        public const uint Dqword = 16;

        public const uint Qqword = 32;

        public const uint Dqqword = 64;

        public const uint MaxSupported = Dqqword;
    }
}
