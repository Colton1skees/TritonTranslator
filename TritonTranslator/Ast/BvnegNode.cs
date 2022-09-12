using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    internal class BvnegNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.BVNEG;

        public BvnegNode(AbstractNode expr1) : base(expr1)
        {
        }
    }
}
