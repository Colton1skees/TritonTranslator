using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class SsaVariableNode : VariableNode
    {
        private readonly int version;

        public override AstType Type => AstType.SSAVAR;

        public VariableNode Variable { get; }

        public SsaVariableNode(VariableNode variable, int version) : base(String.Format("{0}.{1}", variable, version))
        {
            this.version = version;
            Variable = variable;
            BitvectorSize = variable.BitSize;
            Initialize();
        }

        public override string GetOperator()
        {
            return Variable.ToString() + String.Format(".{0}", version);
        }
    }
}
