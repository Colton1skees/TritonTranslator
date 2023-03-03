using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstStore : AbstractInstBinary
    {
        public override InstructionId Id => InstructionId.Store;

        public override bool HasDestination => true;

        public InstStore(IOperand dest, IOperand value) : base(dest, value)
        {

        }

        protected override void ValidateDestination()
        {
            if(Dest.Bitsize != 64)
            {
                throw new InvalidOperationException();
            }

        }
    }
}
