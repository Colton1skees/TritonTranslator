using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvshlNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVSHL;

        public BvshlNode(AbstractNode expr1, AbstractNode expr2) : base(expr1, expr2)
        {
        }

    }
}
