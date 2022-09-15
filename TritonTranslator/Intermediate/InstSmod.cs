using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstSmod : AbstractInstUnary
    {
        public override InstructionId Id => InstructionId.Smod;

        public InstSmod(IOperand destination, IOperand op1, IOperand op2) : base(destination, op1, op2)
        {
            
        }
    }
}
