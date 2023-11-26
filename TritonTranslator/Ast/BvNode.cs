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

        public ulong Value => (Children[0] as IntegerNode).Value;

        public BvNode(AstContext ctx, ulong value, uint bitSize) : this(ctx, new IntegerNode(ctx, value, bitSize), new IntegerNode(ctx, bitSize, bitSize))
        {
        }

        public BvNode(AstContext ctx, IntegerNode value, IntegerNode size) : base(ctx, value, size)
        {

        }

        public override uint ComputeBitvecSize()
        {
            var imm = (IntegerNode)Children[1];
            return imm.BitvectorSize;
        }
    }
}
