using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstZero : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Zero;

        public InstZero(IOperand destination, IOperand op1) : base(destination, op1)
        {
            if (destination.Bitsize != 1)
                throw new InvalidOperationException("Zero size must be 1.");
        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
