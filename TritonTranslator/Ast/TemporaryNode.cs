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

        public TemporaryNode(uint id, uint bitSize) : this(id, bitSize, id.ToString())
        {

        }

        public TemporaryNode(uint id, uint bitSize, string name) : base(name)
        {
            if (id == 160)
                Debugger.Break();
            Uid = id;
            BitvectorSize = bitSize;
            Initialize();
        }


        public override string GetOperator()
        {
            return Name;
        }
    }
}
