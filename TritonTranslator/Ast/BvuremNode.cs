using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvuremNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVUREM;

        public BvuremNode(AstContext ctx, AbstractNode expr1, AbstractNode expr2) : base(ctx, expr1, expr2)
        {

        }
    }
}
