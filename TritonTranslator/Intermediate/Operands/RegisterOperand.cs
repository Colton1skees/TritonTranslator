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
    public class RegisterOperand : IOperand
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
    }
}
