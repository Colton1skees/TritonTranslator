using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstJcc : AbstractInstTernary
    {
        public override InstructionId Id => InstructionId.Jcc;

        public override bool HasDestination => false;

        public InstJcc(IOperand op1, IOperand op2, IOperand op3) : base(null, op1, op2, op3)
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
