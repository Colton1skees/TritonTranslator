using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstExtract : AbstractInstTernary
    {
        public override InstructionId Id => InstructionId.Extract;

        public InstExtract(IOperand destination, IOperand op1, IOperand op2, IOperand op3) : base(destination, op1, op2, op3)
        {
            if (op1 is ImmediateOperand && op2 is ImmediateOperand)
                return;

            throw new Exception("Extract operands must be integers.");
        }

        public override uint ComputeBitvecSize()
        {
            var high = (ImmediateOperand)Op1;
            var low = (ImmediateOperand)Op2;
            return (uint)(high.Immediate.Value - low.Immediate.Value) + 1;
        }
    }
}
