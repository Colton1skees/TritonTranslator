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

        public IntegerNode SizeExt
        {
            get => (IntegerNode)Children[0];
            set => Children[0] = value;
        }

        public AbstractNode Source
        {
            get => Children[1];
            set => Children[1] = value;
        }

        public SxNode(AstContext ctx, uint sizeExt, AbstractNode expr) : base(ctx, new IntegerNode(ctx, sizeExt, expr.BitvectorSize), expr)
        {

        }

        public SxNode(AstContext ctx, AbstractNode sizeExt, AbstractNode expr) : base(ctx, sizeExt, expr)
        {

        }

        protected override void ValidateChildSizes()
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
