using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class ConcatNode : AbstractNode
    {
        public override AstType Type => AstType.CONCAT;

        public ConcatNode(AstContext ctx, AbstractNode expr1, AbstractNode expr2) : base(ctx)
        {
            Children = new List<AbstractNode>();
            Children.Add(expr1);
            Children.Add(expr2);
            Initialize();
        }

        public ConcatNode(AstContext ctx, IEnumerable<AbstractNode> expressions) : base(ctx)
        {
            Children = new List<AbstractNode>();
            Children.AddRange(expressions);
            Initialize();
        }

        public override uint ComputeBitvecSize()
        {
            return (uint)Children.Sum(x => x.BitvectorSize);
        }
    }
}
