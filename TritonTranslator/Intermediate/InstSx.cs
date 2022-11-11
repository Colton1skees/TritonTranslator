using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstSx : AbstractInstUnary
    {
        public override InstructionId Id => InstructionId.Zx;

        public ImmediateOperand Size
        {
            get => (ImmediateOperand)Op1;
            set => Op1 = value;
        }

        public IOperand InputOperand
        {
            get => Op2;
            set => Op2 = value;
        }

        public InstSx(IOperand destination, IOperand size, IOperand operand) : base(destination, size, operand)
        {

        }

        public override uint ComputeBitvecSize()
        {
            var childSize = InputOperand.Bitsize;
            var sizeExt = Size.Value;
            return (uint)sizeExt + childSize;
        }
    }
}
