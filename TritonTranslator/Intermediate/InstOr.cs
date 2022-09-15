using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class OrInst : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Or;

        public OrInst(IOperand destination, IOperand op1) : base(destination, op1)
        {

        }
    }
}
