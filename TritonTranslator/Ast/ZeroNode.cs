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

        public ZeroNode(AstContext ctx, AbstractNode expr1) : base(ctx, expr1)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
