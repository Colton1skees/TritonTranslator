using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class ExtractNode : AbstractTernaryNode
    {
        public override AstType Type => AstType.EXTRACT;

        public ExtractNode(uint high, uint low, AbstractNode expr) :
            base(new IntegerNode(high, expr.BitvectorSize), new IntegerNode(low, expr.BitvectorSize), expr)
        {

        }

        public ExtractNode(IntegerNode high, IntegerNode low, AbstractNode expr) :
            base(high, low, expr)
        {

        }

        public override uint ComputeBitvecSize()
        {
            var high = (IntegerNode)Children[0];
            var low = (IntegerNode)Children[1];
            return (uint)(high.Value - low.Value) + 1;
        }
    }
}
