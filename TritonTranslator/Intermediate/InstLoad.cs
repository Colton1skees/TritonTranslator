using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstLoad : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Load;

        public InstLoad(IOperand destination, IOperand op1, uint size) : base(destination, op1)
        {
            Bitsize = size;
            Initialize();
        }
    }
}
