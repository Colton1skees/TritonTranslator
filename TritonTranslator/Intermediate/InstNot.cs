using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstNot : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Not;

        public InstNot(IOperand destination, IOperand op1) : base(destination, op1)
        {

        }
    }
}
