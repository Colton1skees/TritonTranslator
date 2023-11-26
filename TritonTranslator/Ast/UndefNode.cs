using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class UndefNode : AbstractNode
    {
        public override AstType Type => AstType.UNDEF;

        public UndefNode(AstContext ctx, uint size) : base(ctx)
        {
            BitvectorSize = size;
            Initialize();
        }
    }
}
