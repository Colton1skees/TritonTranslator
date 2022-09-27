using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public abstract class AbstractInstTernary : AbstractInst
    {
        public AbstractInstTernary(IOperand destination, IOperand op1, IOperand op2, IOperand op3)
        {
            Dest = destination;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
            Initialize();
        }

        protected override void ValidateOperands()
        {
            if (Operands.Count != 3)
                throw new InvalidOperationException(String.Format("Ternary node {0} does not have exactly three children.", Id));
            if (Operands.Any(x => x == null))
                throw new InvalidOperationException(String.Format("Ternary node {0} cannot have any null children.", Id));
        }

        public override uint ComputeBitvecSize()
        {
            // Handles the case of ITE, but not extract.
            return Op2.Bitsize;
        }
    }
}
