using Dna.ControlFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstPhi : AbstractInst
    {
        public override InstructionId Id => InstructionId.Phi;

        public BasicBlock<AbstractInst> Block { get; set; }

        public InstPhi(IOperand dest, BasicBlock<AbstractInst> block, IEnumerable<IOperand> operands)
        {
            Dest = dest;
            Block = block;
            Operands.AddRange(operands);
            Initialize();
        }

        public InstPhi(IOperand dest, BasicBlock<AbstractInst> block)
        {
            Dest = dest;
            Block = block;
            Initialize();
        }

        public override uint ComputeBitvecSize()
        {
            if (Operands.Any(x => x.Bitsize != Dest.Bitsize))
                throw new Exception("Phi node operand size does not match destination sizes.");
            return Dest.Bitsize;
        }
    }
}
