using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvuleNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVULE;

        public BvuleNode(AbstractNode expr1, AbstractNode expr2) : base(expr1, expr2)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }

    }
}
