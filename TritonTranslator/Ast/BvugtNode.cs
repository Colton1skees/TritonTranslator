using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvugtNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVUGT;

        public BvugtNode(AbstractNode expr1, AbstractNode expr2) : base(expr1, expr2)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
