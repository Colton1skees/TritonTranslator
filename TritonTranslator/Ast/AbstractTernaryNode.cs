using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public abstract class AbstractTernaryNode : AbstractNode
    {
        protected override int DefaultChildrenCount => 3;

        public AbstractTernaryNode(AbstractNode expr1, AbstractNode expr2, AbstractNode expr3)
        {
            Children.Add(expr1);
            Children.Add(expr2);
            Children.Add(expr3);
            Initialize();
        }

        protected override void ValidateChildren()
        {
            if (Children.Count != 3)
                throw new InvalidOperationException(String.Format("Ternary node {0} does not have exactly three children.", Type));
            if (Children.Any(x => x == null))
                throw new InvalidOperationException(String.Format("Ternary node {0} cannot have any null children.", Type));
        }

        public override uint ComputeBitvecSize()
        {
            // Handles the case of ITE, but not extract.
            return Children[1].BitvectorSize;
        }
    }
}
