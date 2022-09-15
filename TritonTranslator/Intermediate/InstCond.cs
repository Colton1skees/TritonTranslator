using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public enum CondType
    {
        Eq,
        Sge,
        Sgt,
        Sle,
        Slt,
        Uge,
        Ugt,
        Ule,
        Ult,
    }

    public class InstCond : AbstractInstUnary
    {
        public override InstructionId Id => InstructionId.Concat;

        public CondType CondType { get; set; }

        public InstCond(CondType type, IOperand destination, IOperand op1, IOperand op2) : base(destination, op1, op2)
        {
            CondType = type;
        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
