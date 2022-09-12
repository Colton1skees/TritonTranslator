using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public abstract class AbstractBinaryNode : AbstractNode
    {
        /// <inheritdoc cref="AbstractNode.Type"/>
        public override abstract AstType Type { get; }

        public AbstractNode Expr1
        {
            get => Children[0];
            set => Children[0] = value;
        }

        public AbstractBinaryNode(AbstractNode expr1) 
        {
            Children = new List<AbstractNode>(1);
            Children.Add(expr1);

            Initialize();
        }

        protected override void ValidateChildren()
        {
            if (Children.Count != 1)
                throw new InvalidOperationException("Binary nodes must take one child.");
            if (Children[0] == null)
                throw new InvalidOperationException("Binary nodes child at index 0 cannot be null.");
        }

        public override uint ComputeBitvecSize()
        {
            return Children[0].BitvectorSize;
        }
    }
}
