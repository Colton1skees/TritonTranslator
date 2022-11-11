using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstJmp : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Jmp;

        public ImmediateOperand JumpDestination
        {
            get => (ImmediateOperand)Op1;
            set => Op1 = value;
        }

        public override bool HasDestination => false;

        public InstJmp(IOperand op1) : base(null, op1)
        {
            if (op1 is not ImmediateOperand)
                throw new InvalidOperationException(String.Format("Instruction {0} expects an immediate branch destination.", Id));
        }
    }
}
