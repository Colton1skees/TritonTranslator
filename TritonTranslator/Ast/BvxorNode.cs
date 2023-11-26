using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvxorNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVXOR;

        public BvxorNode(AstContext ctx, AbstractNode expr1, AbstractNode expr2) : base(ctx, expr1, expr2)
        {

        }
    }
}
