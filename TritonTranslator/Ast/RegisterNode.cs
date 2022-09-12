using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;

namespace TritonTranslator.Ast
{
    public class RegisterNode : VariableNode
    {
        public override AstType Type => AstType.REGISTER;

        public RegisterNode(Register register) : base(register.Id.ToString())
        {
            Register = register;
            BitvectorSize = register.BitSize;
            Initialize();
        }

        public Register Register { get; }

        public override string GetOperator()
        {
            return string.Format("Reg({0}", Register.Name);
        }
    }
}
