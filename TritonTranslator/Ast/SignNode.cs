using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class SignNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.SIGN;

        public SignNode(AbstractNode expr1) : base(expr1)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
