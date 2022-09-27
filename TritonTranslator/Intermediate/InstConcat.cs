using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstConcat : AbstractInst
    {
        public override InstructionId Id => InstructionId.Concat;

        public InstConcat(IOperand dest, IOperand op1, IOperand op2) : 
            this(dest, new List<IOperand>(2) { op1, op2 })
        {

        }

        public InstConcat(IOperand dest, IEnumerable<IOperand> operands)
        {
            Dest = dest;
            Operands.AddRange(operands);
            Initialize();
        }

        public override uint ComputeBitvecSize()
        {
            return (uint)Operands.Sum(x => x.Bitsize);
        }
    }
}
