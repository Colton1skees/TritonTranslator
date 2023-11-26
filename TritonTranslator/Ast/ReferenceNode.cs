using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class ReferenceNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.REFERENCE;

        public ReferenceNode(AstContext ctx, AbstractNode expr1) : base(ctx, expr1)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return Children[0].BitvectorSize;
        }
    }
}
