using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstSelect : AbstractInstTernary
    {
        public override InstructionId Id => InstructionId.Select;

        public InstSelect(IOperand destination, IOperand op1, IOperand op2, IOperand op3) : base(destination, op1, op2, op3)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return Op2.Bitsize;
        }

        protected override void ValidateOperandSizes()
        {
            if (Op1.Bitsize != 1)
                throw new InvalidOperationException("Select node op1 bit size must be 1.");
            if (Op2.Bitsize != Op3.Bitsize)
                throw new InvalidOperationException("Select node operands must have matching sizes.");  
        }
    }
}
