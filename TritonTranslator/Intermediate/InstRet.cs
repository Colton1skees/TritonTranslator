using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Intermediate
{
    public class InstRet : AbstractInst
    {
        public override InstructionId Id => InstructionId.Ret;

        public override bool HasDestination => false;
    }
}
