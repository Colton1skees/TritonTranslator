using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class ZxNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.ZX;

        public ZxNode(uint sizeExt, AbstractNode expr2) : base(new IntegerNode(sizeExt, expr2.BitvectorSize), expr2)
        {

        }

        public ZxNode(AbstractNode sizeExt, AbstractNode expr2) : base(sizeExt, expr2)
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
