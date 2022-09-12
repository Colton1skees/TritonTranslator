using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;

namespace TritonTranslator.Arch.X86
{
    public static class X86Registers
    {
        public static Dictionary<register_e, Register> RegisterMapping;

        public static Dictionary<register_e, RegisterNode> RegisterNodeMapping;

        public static Dictionary<string, Register> RegisterNameMapping;

        public static Dictionary<Iced.Intel.Register, Register> IcedRegisterMapping;

        public static Register Invalid;

        public static Register Rsp;

        public static Register Rip;

        public static Register Esp;

        public static Register Eip;

        public static RegisterNode RipNode;

        public static RegisterNode CxNode;

        public static RegisterNode ZfNode;

        static X86Registers()
        {
            BuildRegisterMapping();
            BuildRegisterNodeMapping();
            BuildConstRegisters();
            BuildConstRegisterNodes();
            BuildNameMapping();
            BuildIcedMapping();
        }

        private static void BuildRegisterMapping()
        {
            // Build a mapping of register id -> Register objects.
            RegisterMapping = new Dictionary<register_e, Register>()
            {
                { register_e.ID_REG_INVALID, new Register(register_e.ID_REG_INVALID, "invalid", register_e.ID_REG_INVALID, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RAX, new Register(register_e.ID_REG_X86_RAX, "rax", register_e.ID_REG_X86_RAX, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RBX, new Register(register_e.ID_REG_X86_RBX, "rbx", register_e.ID_REG_X86_RBX, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RCX, new Register(register_e.ID_REG_X86_RCX, "rcx", register_e.ID_REG_X86_RCX, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RDX, new Register(register_e.ID_REG_X86_RDX, "rdx", register_e.ID_REG_X86_RDX, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RDI, new Register(register_e.ID_REG_X86_RDI, "rdi", register_e.ID_REG_X86_RDI, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RSI, new Register(register_e.ID_REG_X86_RSI, "rsi", register_e.ID_REG_X86_RSI, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RBP, new Register(register_e.ID_REG_X86_RBP, "rbp", register_e.ID_REG_X86_RBP, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RSP, new Register(register_e.ID_REG_X86_RSP, "rsp", register_e.ID_REG_X86_RSP, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_RIP, new Register(register_e.ID_REG_X86_RIP, "rip", register_e.ID_REG_X86_RIP, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R8, new Register(register_e.ID_REG_X86_R8, "r8", register_e.ID_REG_X86_R8, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R8D, new Register(register_e.ID_REG_X86_R8D, "r8d", register_e.ID_REG_X86_R8, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R8W, new Register(register_e.ID_REG_X86_R8W, "r8w", register_e.ID_REG_X86_R8, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R8B, new Register(register_e.ID_REG_X86_R8B, "r8b", register_e.ID_REG_X86_R8, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R9, new Register(register_e.ID_REG_X86_R9, "r9", register_e.ID_REG_X86_R9, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R9D, new Register(register_e.ID_REG_X86_R9D, "r9d", register_e.ID_REG_X86_R9, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R9W, new Register(register_e.ID_REG_X86_R9W, "r9w", register_e.ID_REG_X86_R9, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R9B, new Register(register_e.ID_REG_X86_R9B, "r9b", register_e.ID_REG_X86_R9, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R10, new Register(register_e.ID_REG_X86_R10, "r10", register_e.ID_REG_X86_R10, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R10D, new Register(register_e.ID_REG_X86_R10D, "r10d", register_e.ID_REG_X86_R10, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R10W, new Register(register_e.ID_REG_X86_R10W, "r10w", register_e.ID_REG_X86_R10, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R10B, new Register(register_e.ID_REG_X86_R10B, "r10b", register_e.ID_REG_X86_R10, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R11, new Register(register_e.ID_REG_X86_R11, "r11", register_e.ID_REG_X86_R11, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R11D, new Register(register_e.ID_REG_X86_R11D, "r11d", register_e.ID_REG_X86_R11, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R11W, new Register(register_e.ID_REG_X86_R11W, "r11w", register_e.ID_REG_X86_R11, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R11B, new Register(register_e.ID_REG_X86_R11B, "r11b", register_e.ID_REG_X86_R11, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R12, new Register(register_e.ID_REG_X86_R12, "r12", register_e.ID_REG_X86_R12, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R12D, new Register(register_e.ID_REG_X86_R12D, "r12d", register_e.ID_REG_X86_R12, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R12W, new Register(register_e.ID_REG_X86_R12W, "r12w", register_e.ID_REG_X86_R12, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R12B, new Register(register_e.ID_REG_X86_R12B, "r12b", register_e.ID_REG_X86_R12, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R13, new Register(register_e.ID_REG_X86_R13, "r13", register_e.ID_REG_X86_R13, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R13D, new Register(register_e.ID_REG_X86_R13D, "r13d", register_e.ID_REG_X86_R13, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R13W, new Register(register_e.ID_REG_X86_R13W, "r13w", register_e.ID_REG_X86_R13, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R13B, new Register(register_e.ID_REG_X86_R13B, "r13b", register_e.ID_REG_X86_R13, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R14, new Register(register_e.ID_REG_X86_R14, "r14", register_e.ID_REG_X86_R14, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R14D, new Register(register_e.ID_REG_X86_R14D, "r14d", register_e.ID_REG_X86_R14, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R14W, new Register(register_e.ID_REG_X86_R14W, "r14w", register_e.ID_REG_X86_R14, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R14B, new Register(register_e.ID_REG_X86_R14B, "r14b", register_e.ID_REG_X86_R14, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_R15, new Register(register_e.ID_REG_X86_R15, "r15", register_e.ID_REG_X86_R15, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_R15D, new Register(register_e.ID_REG_X86_R15D, "r15d", register_e.ID_REG_X86_R15, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_R15W, new Register(register_e.ID_REG_X86_R15W, "r15w", register_e.ID_REG_X86_R15, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_R15B, new Register(register_e.ID_REG_X86_R15B, "r15b", register_e.ID_REG_X86_R15, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_EAX, new Register(register_e.ID_REG_X86_EAX, "eax", register_e.ID_REG_X86_RAX, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_AX, new Register(register_e.ID_REG_X86_AX, "ax", register_e.ID_REG_X86_RAX, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_AH, new Register(register_e.ID_REG_X86_AH, "ah", register_e.ID_REG_X86_RAX, BitSizes.Word - 1, BitSizes.Byte, true) },
                { register_e.ID_REG_X86_AL, new Register(register_e.ID_REG_X86_AL, "al", register_e.ID_REG_X86_RAX, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_EBX, new Register(register_e.ID_REG_X86_EBX, "ebx", register_e.ID_REG_X86_RBX, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_BX, new Register(register_e.ID_REG_X86_BX, "bx", register_e.ID_REG_X86_RBX, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_BH, new Register(register_e.ID_REG_X86_BH, "bh", register_e.ID_REG_X86_RBX, BitSizes.Word - 1, BitSizes.Byte, true) },
                { register_e.ID_REG_X86_BL, new Register(register_e.ID_REG_X86_BL, "bl", register_e.ID_REG_X86_RBX, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_ECX, new Register(register_e.ID_REG_X86_ECX, "ecx", register_e.ID_REG_X86_RCX, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_CX, new Register(register_e.ID_REG_X86_CX, "cx", register_e.ID_REG_X86_RCX, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_CH, new Register(register_e.ID_REG_X86_CH, "ch", register_e.ID_REG_X86_RCX, BitSizes.Word - 1, BitSizes.Byte, true) },
                { register_e.ID_REG_X86_CL, new Register(register_e.ID_REG_X86_CL, "cl", register_e.ID_REG_X86_RCX, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_EDX, new Register(register_e.ID_REG_X86_EDX, "edx", register_e.ID_REG_X86_RDX, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_DX, new Register(register_e.ID_REG_X86_DX, "dx", register_e.ID_REG_X86_RDX, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_DH, new Register(register_e.ID_REG_X86_DH, "dh", register_e.ID_REG_X86_RDX, BitSizes.Word - 1, BitSizes.Byte, true) },
                { register_e.ID_REG_X86_DL, new Register(register_e.ID_REG_X86_DL, "dl", register_e.ID_REG_X86_RDX, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_EDI, new Register(register_e.ID_REG_X86_EDI, "edi", register_e.ID_REG_X86_RDI, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_DI, new Register(register_e.ID_REG_X86_DI, "di", register_e.ID_REG_X86_RDI, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_DIL, new Register(register_e.ID_REG_X86_DIL, "dil", register_e.ID_REG_X86_RDI, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_ESI, new Register(register_e.ID_REG_X86_ESI, "esi", register_e.ID_REG_X86_RSI, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_SI, new Register(register_e.ID_REG_X86_SI, "si", register_e.ID_REG_X86_RSI, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_SIL, new Register(register_e.ID_REG_X86_SIL, "sil", register_e.ID_REG_X86_RSI, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_EBP, new Register(register_e.ID_REG_X86_EBP, "ebp", register_e.ID_REG_X86_RBP, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_BP, new Register(register_e.ID_REG_X86_BP, "bp", register_e.ID_REG_X86_RBP, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_BPL, new Register(register_e.ID_REG_X86_BPL, "bpl", register_e.ID_REG_X86_RBP, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_ESP, new Register(register_e.ID_REG_X86_ESP, "esp", register_e.ID_REG_X86_RSP, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_SP, new Register(register_e.ID_REG_X86_SP, "sp", register_e.ID_REG_X86_RSP, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_SPL, new Register(register_e.ID_REG_X86_SPL, "spl", register_e.ID_REG_X86_RSP, BitSizes.Byte - 1, 0, true) },
                { register_e.ID_REG_X86_EIP, new Register(register_e.ID_REG_X86_EIP, "eip", register_e.ID_REG_X86_RIP, BitSizes.Dword - 1, 0, true) },
                { register_e.ID_REG_X86_IP, new Register(register_e.ID_REG_X86_IP, "ip", register_e.ID_REG_X86_RIP, BitSizes.Word - 1, 0, true) },
                { register_e.ID_REG_X86_EFLAGS, new Register(register_e.ID_REG_X86_EFLAGS, "eflags", register_e.ID_REG_X86_EFLAGS, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM0, new Register(register_e.ID_REG_X86_MM0, "mm0", register_e.ID_REG_X86_MM0, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM1, new Register(register_e.ID_REG_X86_MM1, "mm1", register_e.ID_REG_X86_MM1, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM2, new Register(register_e.ID_REG_X86_MM2, "mm2", register_e.ID_REG_X86_MM2, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM3, new Register(register_e.ID_REG_X86_MM3, "mm3", register_e.ID_REG_X86_MM3, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM4, new Register(register_e.ID_REG_X86_MM4, "mm4", register_e.ID_REG_X86_MM4, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM5, new Register(register_e.ID_REG_X86_MM5, "mm5", register_e.ID_REG_X86_MM5, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM6, new Register(register_e.ID_REG_X86_MM6, "mm6", register_e.ID_REG_X86_MM6, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MM7, new Register(register_e.ID_REG_X86_MM7, "mm7", register_e.ID_REG_X86_MM7, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_MXCSR, new Register(register_e.ID_REG_X86_MXCSR, "mxcsr", register_e.ID_REG_X86_MXCSR, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM0, new Register(register_e.ID_REG_X86_XMM0, "xmm0", register_e.ID_REG_X86_ZMM0, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM1, new Register(register_e.ID_REG_X86_XMM1, "xmm1", register_e.ID_REG_X86_ZMM1, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM2, new Register(register_e.ID_REG_X86_XMM2, "xmm2", register_e.ID_REG_X86_ZMM2, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM3, new Register(register_e.ID_REG_X86_XMM3, "xmm3", register_e.ID_REG_X86_ZMM3, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM4, new Register(register_e.ID_REG_X86_XMM4, "xmm4", register_e.ID_REG_X86_ZMM4, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM5, new Register(register_e.ID_REG_X86_XMM5, "xmm5", register_e.ID_REG_X86_ZMM5, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM6, new Register(register_e.ID_REG_X86_XMM6, "xmm6", register_e.ID_REG_X86_ZMM6, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM7, new Register(register_e.ID_REG_X86_XMM7, "xmm7", register_e.ID_REG_X86_ZMM7, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM8, new Register(register_e.ID_REG_X86_XMM8, "xmm8", register_e.ID_REG_X86_ZMM8, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM9, new Register(register_e.ID_REG_X86_XMM9, "xmm9", register_e.ID_REG_X86_ZMM9, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM10, new Register(register_e.ID_REG_X86_XMM10, "xmm10", register_e.ID_REG_X86_ZMM10, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM11, new Register(register_e.ID_REG_X86_XMM11, "xmm11", register_e.ID_REG_X86_ZMM11, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM12, new Register(register_e.ID_REG_X86_XMM12, "xmm12", register_e.ID_REG_X86_ZMM12, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM13, new Register(register_e.ID_REG_X86_XMM13, "xmm13", register_e.ID_REG_X86_ZMM13, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM14, new Register(register_e.ID_REG_X86_XMM14, "xmm14", register_e.ID_REG_X86_ZMM14, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_XMM15, new Register(register_e.ID_REG_X86_XMM15, "xmm15", register_e.ID_REG_X86_ZMM15, BitSizes.Dqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM0, new Register(register_e.ID_REG_X86_YMM0, "ymm0", register_e.ID_REG_X86_ZMM0, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM1, new Register(register_e.ID_REG_X86_YMM1, "ymm1", register_e.ID_REG_X86_ZMM1, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM2, new Register(register_e.ID_REG_X86_YMM2, "ymm2", register_e.ID_REG_X86_ZMM2, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM3, new Register(register_e.ID_REG_X86_YMM3, "ymm3", register_e.ID_REG_X86_ZMM3, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM4, new Register(register_e.ID_REG_X86_YMM4, "ymm4", register_e.ID_REG_X86_ZMM4, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM5, new Register(register_e.ID_REG_X86_YMM5, "ymm5", register_e.ID_REG_X86_ZMM5, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM6, new Register(register_e.ID_REG_X86_YMM6, "ymm6", register_e.ID_REG_X86_ZMM6, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM7, new Register(register_e.ID_REG_X86_YMM7, "ymm7", register_e.ID_REG_X86_ZMM7, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM8, new Register(register_e.ID_REG_X86_YMM8, "ymm8", register_e.ID_REG_X86_ZMM8, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM9, new Register(register_e.ID_REG_X86_YMM9, "ymm9", register_e.ID_REG_X86_ZMM9, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM10, new Register(register_e.ID_REG_X86_YMM10, "ymm10", register_e.ID_REG_X86_ZMM10, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM11, new Register(register_e.ID_REG_X86_YMM11, "ymm11", register_e.ID_REG_X86_ZMM11, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM12, new Register(register_e.ID_REG_X86_YMM12, "ymm12", register_e.ID_REG_X86_ZMM12, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM13, new Register(register_e.ID_REG_X86_YMM13, "ymm13", register_e.ID_REG_X86_ZMM13, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM14, new Register(register_e.ID_REG_X86_YMM14, "ymm14", register_e.ID_REG_X86_ZMM14, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_YMM15, new Register(register_e.ID_REG_X86_YMM15, "ymm15", register_e.ID_REG_X86_ZMM15, BitSizes.Qqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM0, new Register(register_e.ID_REG_X86_ZMM0, "zmm0", register_e.ID_REG_X86_ZMM0, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM1, new Register(register_e.ID_REG_X86_ZMM1, "zmm1", register_e.ID_REG_X86_ZMM1, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM2, new Register(register_e.ID_REG_X86_ZMM2, "zmm2", register_e.ID_REG_X86_ZMM2, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM3, new Register(register_e.ID_REG_X86_ZMM3, "zmm3", register_e.ID_REG_X86_ZMM3, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM4, new Register(register_e.ID_REG_X86_ZMM4, "zmm4", register_e.ID_REG_X86_ZMM4, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM5, new Register(register_e.ID_REG_X86_ZMM5, "zmm5", register_e.ID_REG_X86_ZMM5, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM6, new Register(register_e.ID_REG_X86_ZMM6, "zmm6", register_e.ID_REG_X86_ZMM6, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM7, new Register(register_e.ID_REG_X86_ZMM7, "zmm7", register_e.ID_REG_X86_ZMM7, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM8, new Register(register_e.ID_REG_X86_ZMM8, "zmm8", register_e.ID_REG_X86_ZMM8, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM9, new Register(register_e.ID_REG_X86_ZMM9, "zmm9", register_e.ID_REG_X86_ZMM9, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM10, new Register(register_e.ID_REG_X86_ZMM10, "zmm10", register_e.ID_REG_X86_ZMM10, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM11, new Register(register_e.ID_REG_X86_ZMM11, "zmm11", register_e.ID_REG_X86_ZMM11, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM12, new Register(register_e.ID_REG_X86_ZMM12, "zmm12", register_e.ID_REG_X86_ZMM12, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM13, new Register(register_e.ID_REG_X86_ZMM13, "zmm13", register_e.ID_REG_X86_ZMM13, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM14, new Register(register_e.ID_REG_X86_ZMM14, "zmm14", register_e.ID_REG_X86_ZMM14, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM15, new Register(register_e.ID_REG_X86_ZMM15, "zmm15", register_e.ID_REG_X86_ZMM15, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM16, new Register(register_e.ID_REG_X86_ZMM16, "zmm16", register_e.ID_REG_X86_ZMM16, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM17, new Register(register_e.ID_REG_X86_ZMM17, "zmm17", register_e.ID_REG_X86_ZMM17, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM18, new Register(register_e.ID_REG_X86_ZMM18, "zmm18", register_e.ID_REG_X86_ZMM18, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM19, new Register(register_e.ID_REG_X86_ZMM19, "zmm19", register_e.ID_REG_X86_ZMM19, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM20, new Register(register_e.ID_REG_X86_ZMM20, "zmm20", register_e.ID_REG_X86_ZMM20, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM21, new Register(register_e.ID_REG_X86_ZMM21, "zmm21", register_e.ID_REG_X86_ZMM21, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM22, new Register(register_e.ID_REG_X86_ZMM22, "zmm22", register_e.ID_REG_X86_ZMM22, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM23, new Register(register_e.ID_REG_X86_ZMM23, "zmm23", register_e.ID_REG_X86_ZMM23, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM24, new Register(register_e.ID_REG_X86_ZMM24, "zmm24", register_e.ID_REG_X86_ZMM24, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM25, new Register(register_e.ID_REG_X86_ZMM25, "zmm25", register_e.ID_REG_X86_ZMM25, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM26, new Register(register_e.ID_REG_X86_ZMM26, "zmm26", register_e.ID_REG_X86_ZMM26, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM27, new Register(register_e.ID_REG_X86_ZMM27, "zmm27", register_e.ID_REG_X86_ZMM27, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM28, new Register(register_e.ID_REG_X86_ZMM28, "zmm28", register_e.ID_REG_X86_ZMM28, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM29, new Register(register_e.ID_REG_X86_ZMM29, "zmm29", register_e.ID_REG_X86_ZMM29, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM30, new Register(register_e.ID_REG_X86_ZMM30, "zmm30", register_e.ID_REG_X86_ZMM30, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_ZMM31, new Register(register_e.ID_REG_X86_ZMM31, "zmm31", register_e.ID_REG_X86_ZMM31, BitSizes.Dqqword - 1, 0, true) },
                { register_e.ID_REG_X86_CR0, new Register(register_e.ID_REG_X86_CR0, "cr0", register_e.ID_REG_X86_CR0, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR1, new Register(register_e.ID_REG_X86_CR1, "cr1", register_e.ID_REG_X86_CR1, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR2, new Register(register_e.ID_REG_X86_CR2, "cr2", register_e.ID_REG_X86_CR2, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR3, new Register(register_e.ID_REG_X86_CR3, "cr3", register_e.ID_REG_X86_CR3, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR4, new Register(register_e.ID_REG_X86_CR4, "cr4", register_e.ID_REG_X86_CR4, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR5, new Register(register_e.ID_REG_X86_CR5, "cr5", register_e.ID_REG_X86_CR5, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR6, new Register(register_e.ID_REG_X86_CR6, "cr6", register_e.ID_REG_X86_CR6, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR7, new Register(register_e.ID_REG_X86_CR7, "cr7", register_e.ID_REG_X86_CR7, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR8, new Register(register_e.ID_REG_X86_CR8, "cr8", register_e.ID_REG_X86_CR8, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR9, new Register(register_e.ID_REG_X86_CR9, "cr9", register_e.ID_REG_X86_CR9, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR10, new Register(register_e.ID_REG_X86_CR10, "cr10", register_e.ID_REG_X86_CR10, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR11, new Register(register_e.ID_REG_X86_CR11, "cr11", register_e.ID_REG_X86_CR11, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR12, new Register(register_e.ID_REG_X86_CR12, "cr12", register_e.ID_REG_X86_CR12, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR13, new Register(register_e.ID_REG_X86_CR13, "cr13", register_e.ID_REG_X86_CR13, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR14, new Register(register_e.ID_REG_X86_CR14, "cr14", register_e.ID_REG_X86_CR14, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_CR15, new Register(register_e.ID_REG_X86_CR15, "cr15", register_e.ID_REG_X86_CR15, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DR0, new Register(register_e.ID_REG_X86_DR0, "dr0", register_e.ID_REG_X86_DR0, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DR1, new Register(register_e.ID_REG_X86_DR1, "dr1", register_e.ID_REG_X86_DR1, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DR2, new Register(register_e.ID_REG_X86_DR2, "dr2", register_e.ID_REG_X86_DR2, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DR3, new Register(register_e.ID_REG_X86_DR3, "dr3", register_e.ID_REG_X86_DR3, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DR6, new Register(register_e.ID_REG_X86_DR6, "dr6", register_e.ID_REG_X86_DR6, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DR7, new Register(register_e.ID_REG_X86_DR7, "dr7", register_e.ID_REG_X86_DR7, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_AC, new Register(register_e.ID_REG_X86_AC, "ac", register_e.ID_REG_X86_AC, 0, 0, true) },
                { register_e.ID_REG_X86_AF, new Register(register_e.ID_REG_X86_AF, "af", register_e.ID_REG_X86_AF, 0, 0, true) },
                { register_e.ID_REG_X86_CF, new Register(register_e.ID_REG_X86_CF, "cf", register_e.ID_REG_X86_CF, 0, 0, true) },
                { register_e.ID_REG_X86_DF, new Register(register_e.ID_REG_X86_DF, "df", register_e.ID_REG_X86_DF, 0, 0, true) },
                { register_e.ID_REG_X86_ID, new Register(register_e.ID_REG_X86_ID, "id", register_e.ID_REG_X86_ID, 0, 0, true) },
                { register_e.ID_REG_X86_IF, new Register(register_e.ID_REG_X86_IF, "if", register_e.ID_REG_X86_IF, 0, 0, true) },
                { register_e.ID_REG_X86_NT, new Register(register_e.ID_REG_X86_NT, "nt", register_e.ID_REG_X86_NT, 0, 0, true) },
                { register_e.ID_REG_X86_OF, new Register(register_e.ID_REG_X86_OF, "of", register_e.ID_REG_X86_OF, 0, 0, true) },
                { register_e.ID_REG_X86_PF, new Register(register_e.ID_REG_X86_PF, "pf", register_e.ID_REG_X86_PF, 0, 0, true) },
                { register_e.ID_REG_X86_RF, new Register(register_e.ID_REG_X86_RF, "rf", register_e.ID_REG_X86_RF, 0, 0, true) },
                { register_e.ID_REG_X86_SF, new Register(register_e.ID_REG_X86_SF, "sf", register_e.ID_REG_X86_SF, 0, 0, true) },
                { register_e.ID_REG_X86_TF, new Register(register_e.ID_REG_X86_TF, "tf", register_e.ID_REG_X86_TF, 0, 0, true) },
                { register_e.ID_REG_X86_VIF, new Register(register_e.ID_REG_X86_VIF, "vif", register_e.ID_REG_X86_VIF, 0, 0, true) },
                { register_e.ID_REG_X86_VIP, new Register(register_e.ID_REG_X86_VIP, "vip", register_e.ID_REG_X86_VIP, 0, 0, true) },
                { register_e.ID_REG_X86_VM, new Register(register_e.ID_REG_X86_VM, "vm", register_e.ID_REG_X86_VM, 0, 0, true) },
                { register_e.ID_REG_X86_ZF, new Register(register_e.ID_REG_X86_ZF, "zf", register_e.ID_REG_X86_ZF, 0, 0, true) },
                { register_e.ID_REG_X86_IE, new Register(register_e.ID_REG_X86_IE, "ie", register_e.ID_REG_X86_IE, 0, 0, true) },
                { register_e.ID_REG_X86_DE, new Register(register_e.ID_REG_X86_DE, "de", register_e.ID_REG_X86_DE, 0, 0, true) },
                { register_e.ID_REG_X86_ZE, new Register(register_e.ID_REG_X86_ZE, "ze", register_e.ID_REG_X86_ZE, 0, 0, true) },
                { register_e.ID_REG_X86_OE, new Register(register_e.ID_REG_X86_OE, "oe", register_e.ID_REG_X86_OE, 0, 0, true) },
                { register_e.ID_REG_X86_UE, new Register(register_e.ID_REG_X86_UE, "ue", register_e.ID_REG_X86_UE, 0, 0, true) },
                { register_e.ID_REG_X86_PE, new Register(register_e.ID_REG_X86_PE, "pe", register_e.ID_REG_X86_PE, 0, 0, true) },
                { register_e.ID_REG_X86_DAZ, new Register(register_e.ID_REG_X86_DAZ, "daz", register_e.ID_REG_X86_DAZ, 0, 0, true) },
                { register_e.ID_REG_X86_IM, new Register(register_e.ID_REG_X86_IM, "im", register_e.ID_REG_X86_IM, 0, 0, true) },
                { register_e.ID_REG_X86_DM, new Register(register_e.ID_REG_X86_DM, "dm", register_e.ID_REG_X86_DM, 0, 0, true) },
                { register_e.ID_REG_X86_ZM, new Register(register_e.ID_REG_X86_ZM, "zm", register_e.ID_REG_X86_ZM, 0, 0, true) },
                { register_e.ID_REG_X86_OM, new Register(register_e.ID_REG_X86_OM, "om", register_e.ID_REG_X86_OM, 0, 0, true) },
                { register_e.ID_REG_X86_UM, new Register(register_e.ID_REG_X86_UM, "um", register_e.ID_REG_X86_UM, 0, 0, true) },
                { register_e.ID_REG_X86_PM, new Register(register_e.ID_REG_X86_PM, "pm", register_e.ID_REG_X86_PM, 0, 0, true) },
                { register_e.ID_REG_X86_RL, new Register(register_e.ID_REG_X86_RL, "rl", register_e.ID_REG_X86_RL, 0, 0, true) },
                { register_e.ID_REG_X86_RH, new Register(register_e.ID_REG_X86_RH, "rh", register_e.ID_REG_X86_RH, 0, 0, true) },
                { register_e.ID_REG_X86_FZ, new Register(register_e.ID_REG_X86_FZ, "fz", register_e.ID_REG_X86_FZ, 0, 0, true) },
                { register_e.ID_REG_X86_CS, new Register(register_e.ID_REG_X86_CS, "cs", register_e.ID_REG_X86_CS, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_DS, new Register(register_e.ID_REG_X86_DS, "ds", register_e.ID_REG_X86_DS, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_ES, new Register(register_e.ID_REG_X86_ES, "es", register_e.ID_REG_X86_ES, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_FS, new Register(register_e.ID_REG_X86_FS, "fs", register_e.ID_REG_X86_FS, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_GS, new Register(register_e.ID_REG_X86_GS, "gs", register_e.ID_REG_X86_GS, BitSizes.Qword - 1, 0, true) },
                { register_e.ID_REG_X86_SS, new Register(register_e.ID_REG_X86_SS, "ss", register_e.ID_REG_X86_SS, BitSizes.Qword - 1, 0, true) },
            };
        }

        private static void BuildRegisterNodeMapping()
        {
            RegisterNodeMapping = new Dictionary<register_e, RegisterNode>();
            foreach(var pair in RegisterMapping)
            {
                RegisterNodeMapping.Add(pair.Key, new RegisterNode(pair.Value));
            }
        }

        private static void BuildConstRegisters()
        {
            Invalid = RegisterMapping[register_e.ID_REG_INVALID];
            Rsp = RegisterMapping[register_e.ID_REG_X86_RSP];
            Rip = RegisterMapping[register_e.ID_REG_X86_RIP];
            Esp = RegisterMapping[register_e.ID_REG_X86_ESP];
            Eip = RegisterMapping[register_e.ID_REG_X86_EIP];
        }

        private static void BuildConstRegisterNodes()
        {
            RipNode = RegisterNodeMapping[register_e.ID_REG_X86_RIP];
            CxNode = RegisterNodeMapping[register_e.ID_REG_X86_CX];
            ZfNode = RegisterNodeMapping[register_e.ID_REG_X86_ZF];
        }

        private static void BuildNameMapping()
        {
            RegisterNameMapping = RegisterMapping.Values.ToDictionary(x => x.Name, x => x);
        }

        private static void BuildIcedMapping()
        {
            // Build a mapping of iced register id -> register object.
            var icedRegisters = Enum.GetValues(typeof(Iced.Intel.Register)).Cast<Iced.Intel.Register>();
            IcedRegisterMapping = new Dictionary<Iced.Intel.Register, Register>();
            foreach (var icedRegister in icedRegisters)
            {
                var regName = icedRegister.ToString().ToLower();
                if (RegisterNameMapping.ContainsKey(regName))
                    IcedRegisterMapping.Add(icedRegister, RegisterNameMapping[regName]);
            }

            // Fix non matching names.
            IcedRegisterMapping[Iced.Intel.Register.None] = RegisterMapping[register_e.ID_REG_INVALID];
            IcedRegisterMapping[Iced.Intel.Register.R8L] = RegisterMapping[register_e.ID_REG_X86_R8B];
            IcedRegisterMapping[Iced.Intel.Register.R9L] = RegisterMapping[register_e.ID_REG_X86_R9B];
            IcedRegisterMapping[Iced.Intel.Register.R10L] = RegisterMapping[register_e.ID_REG_X86_R10B];
            IcedRegisterMapping[Iced.Intel.Register.R11L] = RegisterMapping[register_e.ID_REG_X86_R11B];
            IcedRegisterMapping[Iced.Intel.Register.R12L] = RegisterMapping[register_e.ID_REG_X86_R12B];
            IcedRegisterMapping[Iced.Intel.Register.R13L] = RegisterMapping[register_e.ID_REG_X86_R13B];
            IcedRegisterMapping[Iced.Intel.Register.R14L] = RegisterMapping[register_e.ID_REG_X86_R14B];
            IcedRegisterMapping[Iced.Intel.Register.R15L] = RegisterMapping[register_e.ID_REG_X86_R15B];

            // The following registers cannot be mapped from triton to iced:
            // invalid, r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b, ip, eflags, mxcsr, ac,
            // af, cf, df, id, if, nt, of, pf, rf, sf, tf, vif, vip, vm, zf, ie, de, ze,
            // oe, ue, pe, daz, im, dm, zm, om, um, pm, rl, rh, fz,
        }

    }
}
