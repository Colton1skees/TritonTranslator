using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class IntegerNode : AbstractNode
    {
        public override AstType Type => AstType.INTEGER;

        public ulong Value { get; }

        public IntegerNode(AstContext ctx, ulong value, uint size) : base(ctx)
        {
            Value = value;
            BitvectorSize = size;
            Initialize();
        }

        public override string GetOperator()
        {
            return string.Format("0x{0}:I{1}", Value.ToString("X"), BitSize.ToString());
        }
    }
}
