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

        public IntegerNode SizeExt
        {
            get => (IntegerNode)Children[0];
            set => Children[0] = value;
        }

        public AbstractNode Source
        {
            get => (IntegerNode)Children[1];
            set => Children[1] = value;
        }

        public ZxNode(uint sizeExt, AbstractNode expr2) : base(new IntegerNode(sizeExt, expr2.BitvectorSize), expr2)
        {

        }

        public ZxNode(AbstractNode sizeExt, AbstractNode expr2) : base(sizeExt, expr2)
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
