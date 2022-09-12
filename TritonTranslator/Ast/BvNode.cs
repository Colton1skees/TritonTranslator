using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BV;

        public BvNode(ulong value, uint bitSize) : this(new IntegerNode(value, bitSize), new IntegerNode(bitSize, bitSize))
        {
        }

        public BvNode(IntegerNode value, IntegerNode size) : base(value, size)
        {

        }

        public override uint ComputeBitvecSize()
        {
            var imm = (IntegerNode)Children[1];
            return imm.BitvectorSize;
        }
    }
}
