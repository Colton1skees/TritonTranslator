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

        public UndefNode(uint size)
        {
            BitvectorSize = size;
            Initialize();
        }
    }
}
