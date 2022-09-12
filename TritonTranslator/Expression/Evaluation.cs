using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Expression
{
    // Artifact that is required as a result of transpiling the triton semantics directly.
    // TODO: Remove all instances of concrete evaluation in the semantics.
    internal class Evaluation
    {
        public static Evaluation Instance { get; } = new Evaluation();

        public bool IsZero()
        {
            return false;
        }

        public static implicit operator bool(Evaluation valuation)
        {
            return false;
        }

        public static implicit operator ulong(Evaluation valuation)
        {
            return 0;
        }

        public static implicit operator uint(Evaluation valuation)
        {
            return 0;
        }

        public static implicit operator long(Evaluation valuation)
        {
            return 0;
        }

        public static implicit operator Evaluation(uint value)
        {
            return Instance;
        }
    }
}
