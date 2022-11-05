using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstBranchIndirect : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.BranchIndirect;

        public override bool HasDestination => false;

        public InstBranchIndirect(IOperand destination, IOperand op1) : base(destination, op1)
        {

        }
    }
}
