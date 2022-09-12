using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class SxNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.SX;

        public SxNode(uint sizeExt, AbstractNode expr) : base(new IntegerNode(sizeExt, expr.BitvectorSize), expr)
        {

        }

        public SxNode(AbstractNode sizeExt, AbstractNode expr) : base(sizeExt, expr)
        {

        }

        public override uint ComputeBitvecSize()
        {
            var childSize = Children[1].BitvectorSize;
            var sizeExt = (Children[0] as IntegerNode).Value;
            return (uint)sizeExt + childSize;
        }
    }
}
