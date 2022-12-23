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

        public IntegerNode High
        {
            get => (IntegerNode)Children[0];
            set => Children[0] = value;
        }

        public IntegerNode Low
        {
            get => (IntegerNode)Children[1];
            set => Children[1] = value;
        }

        public AbstractNode Source
        {
            get => Children[2];
            set => Children[2] = value;
        }

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
            return (uint)(High.Value - Low.Value) + 1;
        }
    }
}
