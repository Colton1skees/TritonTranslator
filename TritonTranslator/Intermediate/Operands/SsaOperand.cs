using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;

namespace TritonTranslator.Intermediate.Operands
{
    /// <summary>
    /// Architecture register operand.
    /// </summary>
    public class SsaOperand : IOperand, IEquatable<SsaOperand>
    {
        public uint Bitsize => BaseOperand.Bitsize;

        public bool IsWritable => true;

        public IOperand BaseOperand { get; }

        public int Version { get; }

        public string Name => String.Format("{0}.{1}", BaseOperand, Version);

        public HashSet<AbstractInst> Users { get; } = new HashSet<AbstractInst>();

        public AbstractInst Definition { get; }

        public SsaOperand(IOperand operand, AbstractInst definition, int version)
        {
            if (operand is SsaOperand)
                throw new InvalidOperationException("SSA variables cannot be nested.");

            BaseOperand = operand;
            Definition = definition;
            Version = version;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj) => Equals(obj as SsaOperand);

        public bool Equals(SsaOperand op)
        {
            if (op is null)
                return false;

            if (Object.ReferenceEquals(this, op))
                return true;

            if (GetType() != op.GetType())
                return false;

            if (op.Bitsize != Bitsize)
                throw new InvalidOperationException("Temporary bit sizes do not match.");

            return op.BaseOperand == BaseOperand && op.Version == Version;
        }

        /*
        public override int GetHashCode()
        {
            // TODO: Fix.
            return (int.MaxValue / 2) + BaseOperand.GetHashCode() + Version;
        }*/
    }
}
