using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvnegNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.BVNEG;

        public BvnegNode(AstContext ctx, AbstractNode expr1) : base(ctx, expr1)
        {
        }
    }
}
