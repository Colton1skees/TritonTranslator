using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstLoad : AbstractInstUnary
    {
        public override InstructionId Id => InstructionId.Load;

        public InstLoad(IOperand destination, IOperand op1, ImmediateOperand sizeOp) : base(destination, op1, sizeOp)
        {
            Bitsize = (uint)sizeOp.Value;
            Initialize();
        }
    }
}
