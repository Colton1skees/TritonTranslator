using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvrorNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVROR;

        public BvrorNode(AstContext ctx, AbstractNode expr1, AbstractNode expr2) : base(ctx, expr1, expr2)
        {
        }
    }
}
