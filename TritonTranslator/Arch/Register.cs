﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{

    public enum register_e
    {
        ID_REG_INVALID,
        ID_REG_X86_RAX,
        ID_REG_X86_RBX,
        ID_REG_X86_RCX,
        ID_REG_X86_RDX,
        ID_REG_X86_RDI,
        ID_REG_X86_RSI,
        ID_REG_X86_RBP,
        ID_REG_X86_RSP,
        ID_REG_X86_RIP,
        ID_REG_X86_R8,
        ID_REG_X86_R8D,
        ID_REG_X86_R8W,
        ID_REG_X86_R8B,
        ID_REG_X86_R9,
        ID_REG_X86_R9D,
        ID_REG_X86_R9W,
        ID_REG_X86_R9B,
        ID_REG_X86_R10,
        ID_REG_X86_R10D,
        ID_REG_X86_R10W,
        ID_REG_X86_R10B,
        ID_REG_X86_R11,
        ID_REG_X86_R11D,
        ID_REG_X86_R11W,
        ID_REG_X86_R11B,
        ID_REG_X86_R12,
        ID_REG_X86_R12D,
        ID_REG_X86_R12W,
        ID_REG_X86_R12B,
        ID_REG_X86_R13,
        ID_REG_X86_R13D,
        ID_REG_X86_R13W,
        ID_REG_X86_R13B,
        ID_REG_X86_R14,
        ID_REG_X86_R14D,
        ID_REG_X86_R14W,
        ID_REG_X86_R14B,
        ID_REG_X86_R15,
        ID_REG_X86_R15D,
        ID_REG_X86_R15W,
        ID_REG_X86_R15B,
        ID_REG_X86_EAX,
        ID_REG_X86_AX,
        ID_REG_X86_AH,
        ID_REG_X86_AL,
        ID_REG_X86_EBX,
        ID_REG_X86_BX,
        ID_REG_X86_BH,
        ID_REG_X86_BL,
        ID_REG_X86_ECX,
        ID_REG_X86_CX,
        ID_REG_X86_CH,
        ID_REG_X86_CL,
        ID_REG_X86_EDX,
        ID_REG_X86_DX,
        ID_REG_X86_DH,
        ID_REG_X86_DL,
        ID_REG_X86_EDI,
        ID_REG_X86_DI,
        ID_REG_X86_DIL,
        ID_REG_X86_ESI,
        ID_REG_X86_SI,
        ID_REG_X86_SIL,
        ID_REG_X86_EBP,
        ID_REG_X86_BP,
        ID_REG_X86_BPL,
        ID_REG_X86_ESP,
        ID_REG_X86_SP,
        ID_REG_X86_SPL,
        ID_REG_X86_EIP,
        ID_REG_X86_IP,
        ID_REG_X86_EFLAGS,
        ID_REG_X86_MM0,
        ID_REG_X86_MM1,
        ID_REG_X86_MM2,
        ID_REG_X86_MM3,
        ID_REG_X86_MM4,
        ID_REG_X86_MM5,
        ID_REG_X86_MM6,
        ID_REG_X86_MM7,
        ID_REG_X86_MXCSR,
        ID_REG_X86_XMM0,
        ID_REG_X86_XMM1,
        ID_REG_X86_XMM2,
        ID_REG_X86_XMM3,
        ID_REG_X86_XMM4,
        ID_REG_X86_XMM5,
        ID_REG_X86_XMM6,
        ID_REG_X86_XMM7,
        ID_REG_X86_XMM8,
        ID_REG_X86_XMM9,
        ID_REG_X86_XMM10,
        ID_REG_X86_XMM11,
        ID_REG_X86_XMM12,
        ID_REG_X86_XMM13,
        ID_REG_X86_XMM14,
        ID_REG_X86_XMM15,
        ID_REG_X86_YMM0,
        ID_REG_X86_YMM1,
        ID_REG_X86_YMM2,
        ID_REG_X86_YMM3,
        ID_REG_X86_YMM4,
        ID_REG_X86_YMM5,
        ID_REG_X86_YMM6,
        ID_REG_X86_YMM7,
        ID_REG_X86_YMM8,
        ID_REG_X86_YMM9,
        ID_REG_X86_YMM10,
        ID_REG_X86_YMM11,
        ID_REG_X86_YMM12,
        ID_REG_X86_YMM13,
        ID_REG_X86_YMM14,
        ID_REG_X86_YMM15,
        ID_REG_X86_ZMM0,
        ID_REG_X86_ZMM1,
        ID_REG_X86_ZMM2,
        ID_REG_X86_ZMM3,
        ID_REG_X86_ZMM4,
        ID_REG_X86_ZMM5,
        ID_REG_X86_ZMM6,
        ID_REG_X86_ZMM7,
        ID_REG_X86_ZMM8,
        ID_REG_X86_ZMM9,
        ID_REG_X86_ZMM10,
        ID_REG_X86_ZMM11,
        ID_REG_X86_ZMM12,
        ID_REG_X86_ZMM13,
        ID_REG_X86_ZMM14,
        ID_REG_X86_ZMM15,
        ID_REG_X86_ZMM16,
        ID_REG_X86_ZMM17,
        ID_REG_X86_ZMM18,
        ID_REG_X86_ZMM19,
        ID_REG_X86_ZMM20,
        ID_REG_X86_ZMM21,
        ID_REG_X86_ZMM22,
        ID_REG_X86_ZMM23,
        ID_REG_X86_ZMM24,
        ID_REG_X86_ZMM25,
        ID_REG_X86_ZMM26,
        ID_REG_X86_ZMM27,
        ID_REG_X86_ZMM28,
        ID_REG_X86_ZMM29,
        ID_REG_X86_ZMM30,
        ID_REG_X86_ZMM31,
        ID_REG_X86_CR0,
        ID_REG_X86_CR1,
        ID_REG_X86_CR2,
        ID_REG_X86_CR3,
        ID_REG_X86_CR4,
        ID_REG_X86_CR5,
        ID_REG_X86_CR6,
        ID_REG_X86_CR7,
        ID_REG_X86_CR8,
        ID_REG_X86_CR9,
        ID_REG_X86_CR10,
        ID_REG_X86_CR11,
        ID_REG_X86_CR12,
        ID_REG_X86_CR13,
        ID_REG_X86_CR14,
        ID_REG_X86_CR15,
        ID_REG_X86_DR0,
        ID_REG_X86_DR1,
        ID_REG_X86_DR2,
        ID_REG_X86_DR3,
        ID_REG_X86_DR6,
        ID_REG_X86_DR7,
        ID_REG_X86_AC,
        ID_REG_X86_AF,
        ID_REG_X86_CF,
        ID_REG_X86_DF,
        ID_REG_X86_ID,
        ID_REG_X86_IF,
        ID_REG_X86_NT,
        ID_REG_X86_OF,
        ID_REG_X86_PF,
        ID_REG_X86_RF,
        ID_REG_X86_SF,
        ID_REG_X86_TF,
        ID_REG_X86_VIF,
        ID_REG_X86_VIP,
        ID_REG_X86_VM,
        ID_REG_X86_ZF,
        ID_REG_X86_IE,
        ID_REG_X86_DE,
        ID_REG_X86_ZE,
        ID_REG_X86_OE,
        ID_REG_X86_UE,
        ID_REG_X86_PE,
        ID_REG_X86_DAZ,
        ID_REG_X86_IM,
        ID_REG_X86_DM,
        ID_REG_X86_ZM,
        ID_REG_X86_OM,
        ID_REG_X86_UM,
        ID_REG_X86_PM,
        ID_REG_X86_RL,
        ID_REG_X86_RH,
        ID_REG_X86_FZ,
        ID_REG_X86_CS,
        ID_REG_X86_DS,
        ID_REG_X86_ES,
        ID_REG_X86_FS,
        ID_REG_X86_GS,
        ID_REG_X86_SS,
    }

    public class Register : BitsVector
    {
        public Register(register_e regId, string name, register_e parent,
            uint high, uint low, bool vmutable) : base(high, low)
        {
            Name = name;
            Id = regId;
            ParentId = parent;
            IsVMutable = false;
        }

        public Register(Register register) : base(register.High, register.Low)
        {
            this.Name = register.Name;
            this.Id = register.Id;
            this.ParentId = register.ParentId;
            this.IsVMutable = register.IsVMutable;
        }

        public string Name { get; set; }

        /// <summary>
        /// Gets the ID of the register.
        /// </summary>
        public register_e Id { get; }

        /// <summary>
        /// Gets the ID of the parent register.
        /// </summary>
        public register_e ParentId { get; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsVMutable { get; }

        /// <summary>
        /// Gets the register size in bits.
        /// </summary>
        public uint BitSize => VectorSize;

        /// <summary>
        /// Gets the register size in bytes.
        /// </summary>
        public uint Size => VectorSize / BitSizes.Byte;

        /// <summary>
        /// Gets the type of operand.
        /// </summary>
        public OperandType OperandType { get; set; }

        /// <summary>
        /// Gets whether one register overlaps with another.
        /// </summary>
        public bool OverlapsWith(Register other)
        {
            if (ParentId != other.ParentId)
                return false;
            if (Low <= other.Low && other.Low <= High)
                return true;
            if (other.Low <= Low && Low <= other.High)
                return true;
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
