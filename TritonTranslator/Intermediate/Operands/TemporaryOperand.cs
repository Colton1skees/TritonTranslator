using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Intermediate.Operands
{
    public class TemporaryOperand : IOperand, IEquatable<TemporaryOperand>
    {
        public uint Bitsize { get; }

        public bool IsWritable => true;

        public uint Uid { get; }

        public string Name => String.Format("t{0}", Uid);

        public TemporaryOperand(uint uid, uint bitSize)
        {
            if (uid == 0)
                Debugger.Break();
            Uid = uid;
            Bitsize = bitSize;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj) => Equals(obj as TemporaryOperand);

        public bool Equals(TemporaryOperand op)
        {
            if (op is null)
                return false;

            if (Object.ReferenceEquals(this, op))
                return true;

            if (GetType() != op.GetType())
                return false;

            if (op.Bitsize != Bitsize)
                throw new InvalidOperationException("Temporary bit sizes do not match.");

            return op.Uid == Uid;
        }

        public override int GetHashCode()
        {
            return (int)Uid;
        }
    }
}
