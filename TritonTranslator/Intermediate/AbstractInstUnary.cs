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
            Initialize();
        }

        protected override void ValidateOperands()
        {
            if (Operands.Count != 2)
                throw new InvalidOperationException(String.Format("Unary node {0} does not have exactly two children.", Id));
            if (Operands.Any(x => x == null))
                throw new InvalidOperationException(String.Format("Unary node {0} cannot have any null children.", Id));
        }

        protected override void ValidateOperandSizes()
        {
            if (Operands[0].Bitsize != Operands[1].Bitsize)
                throw new InvalidOperationException(String.Format("Unary node {0} children has unequal sizes.", Id));
        }

        public override uint ComputeBitvecSize()
        {
            return Operands[0].Bitsize;
        }
    }
}
