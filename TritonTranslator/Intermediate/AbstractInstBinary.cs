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
            Operands.Add(op1);
            Initialize();
        }

        protected override void ValidateOperands()
        {
            if (Operands.Count != 1)
                throw new InvalidOperationException("Binary nodes must take one child.");
            if (Operands[0] == null)
                throw new InvalidOperationException("Binary nodes child at index 0 cannot be null.");
        }

        public override uint ComputeBitvecSize()
        {
            return Op1.Bitsize;
        }
    }
}
