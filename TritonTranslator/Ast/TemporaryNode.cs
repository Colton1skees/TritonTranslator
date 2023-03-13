using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class TemporaryNode : VariableNode
    {
        public override AstType Type => AstType.TEMPVAR;

        public uint Uid { get; }

        public TemporaryNode(uint id, uint bitSize) : base(String.Format("t{0}:{1}", id, bitSize.ToString()))
        {
            if (id == 160)
                Debugger.Break();
            Uid = id;
            BitvectorSize = bitSize;
            Initialize();
        }

        public override string GetOperator()
        {
            return String.Format("t{0}:{1}", Uid, BitSize.ToString());
        }
    }
}
