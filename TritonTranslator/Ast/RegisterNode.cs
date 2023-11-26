using TritonTranslator.Arch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class RegisterNode : VariableNode
    {
        public override AstType Type => AstType.REGISTER;

        public RegisterNode(AstContext ctx, Register register) : base(ctx, register.Id.ToString())
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
