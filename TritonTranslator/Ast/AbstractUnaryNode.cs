using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public abstract class AbstractUnaryNode : AbstractNode
    {
        protected override int DefaultChildrenCount => 2;

        /// <inheritdoc cref="AbstractNode.Type"/>
        public override abstract AstType Type { get; }

        public AbstractNode Expr1
        {
            get => Children[0];
            set => Children[0] = value;
        }

        public AbstractNode Expr2
        {
            get => Children[1];
            set => Children[1] = value;
        }

        public AbstractUnaryNode(AbstractNode expr1, AbstractNode expr2)
        {
            Children.Add(expr1);
            Children.Add(expr2);
            Initialize();
        }

        protected override void ValidateChildren()
        {
            if (Children.Count != 2)
                throw new InvalidOperationException(String.Format("Unary node {0} does not have exactly two children.", Type));
            if (Children.Any(x => x == null))
                throw new InvalidOperationException(String.Format("Unary node {0} cannot have any null children.", Type));
        }

        protected override void ValidateChildSizes()
        {
            if (Children[0].BitvectorSize != Children[1].BitvectorSize)
                throw new InvalidOperationException(String.Format("Unary node {0} children has unequal sizes.", Type));
        }

        public override uint ComputeBitvecSize()
        {
            return Children[0].BitvectorSize;
        }
    }
}
