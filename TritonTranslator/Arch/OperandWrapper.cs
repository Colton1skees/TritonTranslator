using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    public enum OperandType : byte
    {
        Invalid = 0,
        Imm = 1,
        Mem = 2,
        Reg = 3,
    }

    public class OperandWrapper
    {
        /// <summary>
        /// Gets or sets the operand type.
        /// </summary>
        public OperandType Type { get; set; }

        /// <summary>
        /// Gets or sets the immediate operand.
        /// </summary>
        public Immediate Immediate
        {
            get => (Immediate)Operand;
            set => Operand = value;
        }

        /// <summary>
        /// Gets or sets the memory access operand.
        /// </summary>
        public MemoryAccess MemoryAccess
        {
            get => (MemoryAccess)Operand;
            set => Operand = value;
        }

        /// <summary>
        /// Gets or sets the register operand.
        /// </summary>
        public Register Register
        {
            get => (Register)Operand;
            set => Operand = value;
        }

        public BitsVector Operand { get; set; }

        public uint Size
        {
            get
            {
                switch (Type)
                {
                    case OperandType.Imm:
                        return Immediate.Size;
                    case OperandType.Mem:
                        return MemoryAccess.Size;
                    case OperandType.Reg:
                        return Register.Size;
                    default:
                        throw new InvalidOperationException("Invalid operand type.");
                }
            }
        }

        public uint BitSize
        {
            get
            {
                switch (Type)
                {
                    case OperandType.Imm:
                        return Immediate.BitSize;
                    case OperandType.Mem:
                        return MemoryAccess.BitSize;
                    case OperandType.Reg:
                        return Register.BitSize;
                    default:
                        throw new InvalidOperationException("Invalid operand type.");
                }
            }
        }

        public uint High
        {
            get
            {
                switch (Type)
                {
                    case OperandType.Imm:
                        return Immediate.High;
                    case OperandType.Mem:
                        return MemoryAccess.High;
                    case OperandType.Reg:
                        return Register.High;
                    default:
                        throw new InvalidOperationException("Invalid operand type.");
                }
            }
        }

        public uint Low
        {
            get
            {
                switch (Type)
                {
                    case OperandType.Imm:
                        return Immediate.Low;
                    case OperandType.Mem:
                        return MemoryAccess.Low;
                    case OperandType.Reg:
                        return Register.Low;
                    default:
                        throw new InvalidOperationException("Invalid operand type.");
                }
            }
        }

        public OperandWrapper(Immediate imm)
        {
            Immediate = imm;
            Type = OperandType.Imm;
        }

        public OperandWrapper(MemoryAccess mem)
        {
            MemoryAccess = mem;
            Type = OperandType.Mem;
        }

        public OperandWrapper(Register reg)
        {
            Register = reg;
            Type = OperandType.Reg;
        }

        public void SetRegister(Register reg)
        {
            Register = reg;
            Type = OperandType.Reg;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case OperandType.Mem:
                    return MemoryAccess.ToString();
                case OperandType.Reg:
                    return Register.ToString();
                case OperandType.Imm:
                    return Immediate.ToString();
                default:
                    throw new InvalidOperationException();
            }
        }

        public static implicit operator OperandWrapper(Immediate imm)
        {
            return new OperandWrapper(imm);
        }

        public static implicit operator OperandWrapper(MemoryAccess mem)
        {
            return new OperandWrapper(mem);
        }

        public static implicit operator OperandWrapper(Register reg)
        {
            return new OperandWrapper(reg);
        }
    }
}
