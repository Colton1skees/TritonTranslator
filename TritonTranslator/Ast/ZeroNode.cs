using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class ZeroNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.ZERO;

        public ZeroNode(AbstractNode expr1) : base(expr1)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
