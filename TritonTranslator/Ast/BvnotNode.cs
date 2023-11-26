using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvnotNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.BVNOT;

        public BvnotNode(AstContext ctx, AbstractNode expr1) : base(ctx, expr1)
        {
        }
    }
}
