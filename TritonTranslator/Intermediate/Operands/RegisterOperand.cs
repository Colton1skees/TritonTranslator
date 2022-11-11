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
    public class RegisterOperand : IOperand, IEquatable<RegisterOperand>
    {
        public uint Bitsize => Register.BitSize;

        public bool IsWritable => true;

        public Register Register { get; }

        public string Name => String.Format("Reg({0})", Register.Name);

        public RegisterOperand(Register register)
        {
            Register = register;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj) => Equals(obj as RegisterOperand);

        public bool Equals(RegisterOperand op)
        {
            if (op is null)
                return false;

            if (Object.ReferenceEquals(this, op))
                return true;

            if (GetType() != op.GetType())
                return false;

            if (op.Bitsize != Bitsize)
                throw new InvalidOperationException("Temporary bit sizes do not match.");

            return op.Register.Id == Register.Id;
        }

        public override int GetHashCode()
        {
            return (int)Register.Id;
        }
    }
}
