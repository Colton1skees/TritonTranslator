using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvaddNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVADD;

        public BvaddNode(AbstractNode expr1, AbstractNode expr2) : base(expr1, expr2)
        {

        }
    }
}
