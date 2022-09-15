using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public abstract class AbstractInstUnary : AbstractInst
    {
        public AbstractInstUnary(IOperand destination, IOperand op1, IOperand op2)
        {
            Dest = destination;
            Op1 = op1;
            Op2 = op2;
        }
    }
}
