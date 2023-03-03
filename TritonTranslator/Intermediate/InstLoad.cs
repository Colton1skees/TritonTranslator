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

        public IOperand AddressOp
        {
            get => Op1;
            set => Op1 = value;
        }

        public ImmediateOperand SizeOp
        {
            get => (ImmediateOperand)Op2;
            set => Op2 = value;
        }

        public InstLoad(IOperand destination, IOperand addressOp, ImmediateOperand sizeOp) : base(destination, addressOp, sizeOp)
        {
            Bitsize = (uint)sizeOp.Value;
            Initialize();
        }

        public override uint ComputeBitvecSize()
        {
            return Dest.Bitsize;
        }

        protected override void ValidateOperandSizes()
        {
            if (Operands[0].Bitsize != Operands[1].Bitsize)
                throw new InvalidOperationException(String.Format("Unary node {0} children has unequal sizes.", Id));
        }
    }
}
