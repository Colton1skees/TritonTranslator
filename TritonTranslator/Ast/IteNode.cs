using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class IteNode : AbstractTernaryNode
    {
        public override AstType Type => AstType.ITE;

        public IteNode(AstContext ctx, AbstractNode ifExpr, AbstractNode thenExpr, AbstractNode elseExpr) : base(ctx, ifExpr, thenExpr, elseExpr)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return Children[1].BitvectorSize;
        }

        protected override void ValidateChildSizes()
        {
            if (Children[1].BitvectorSize != Children[2].BitvectorSize)
                throw new InvalidOperationException("IteNode thenExpr and elseExpr have unequal sizes.");
        }
    }
}
