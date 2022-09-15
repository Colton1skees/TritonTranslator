using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public abstract class AbstractInstBinary : AbstractInst
    {
        public AbstractInstBinary(IOperand destination, IOperand op1)
        {
            Dest = destination;
            Op1 = op1;
        }
    }
}
