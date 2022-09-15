using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public enum InstructionId
    {
        None = 0,

        Add,
        And,
        Xor,
        Ashr,
        Lshr,
        Shl,
        Mul,
        Neg,
        Not,
        Or,
        Rol,
        Ror,
        Sdiv,

        Smod,
        Srem,
        Sub,
        Udiv,
        Urem,

        Cond,
        Concat,
        Extract,
        Select,

        Load,
        Store,
    }

    public abstract class AbstractInst
    {
        public abstract InstructionId Id { get; }

        public uint Bitsize { get; protected set; }

        public IOperand Op1
        {
            get => Operands[0];
            set => Operands[0] = value;
        }

        public IOperand Op2
        {
            get => Operands[1];
            set => Operands[1] = value;
        }

        public IOperand Op3
        {
            get => Operands[2];
            set => Operands[2] = value;
        }

        public List<IOperand> Operands { get; protected set; }

        public IOperand Dest { get; set; }

        public virtual bool HasDestination => true;

        public void Initialize()
        {

        }

        public virtual uint ComputeBitvecSize()
        {
            throw new Exception("TODO: Implement.");
        }

        protected virtual void ValidateOperands()
        {

        }

        protected virtual void ValidateOperandSizes()
        {

        }

        public string GetOperator()
        {
            return Id.ToString().ToLower();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetOperator());
            for(int i = 0; i < Operands.Count; i++)
            {
                var op = Operands[i];
                sb.Append(" " + op);
                if (i + 1 != Operands.Count)
                    sb.Append(",");
            }

            return sb.ToString();
        }
    }
}
