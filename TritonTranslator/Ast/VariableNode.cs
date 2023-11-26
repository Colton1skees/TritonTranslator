using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public abstract class VariableNode : AbstractNode
    {
        public override AstType Type => throw new NotImplementedException();

        public string Name { get; }

        public VariableNode(AstContext ctx, string name) : base(ctx)
        {
            Name = name;
        }
    }
}
