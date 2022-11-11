using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstSign : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Sign;

        public InstSign(IOperand destination, IOperand op1) : base(destination, op1)
        {
            if (destination.Bitsize != 1)
                throw new InvalidOperationException("Sign size must be 1.");
        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
