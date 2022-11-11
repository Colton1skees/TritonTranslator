using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstJmpInd : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.JmpInd;

        public override bool HasDestination => false;

        public InstJmpInd(IOperand destination, IOperand op1) : base(destination, op1)
        {

        }
    }
}
