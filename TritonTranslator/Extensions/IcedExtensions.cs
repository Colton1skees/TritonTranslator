using Iced.Intel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Extensions
{
    public static class IcedExtensions
    {
        private static HashSet<OpKind> immediateKinds = new HashSet<OpKind>()
        {
            OpKind.Immediate16,
            OpKind.Immediate32,
            OpKind.Immediate32to64,
            OpKind.Immediate64,
            OpKind.Immediate8,
            OpKind.Immediate8to16,
            OpKind.Immediate8to32,
            OpKind.Immediate8to64,
            OpKind.Immediate8_2nd,
        };

        private static HashSet<OpKind> explicitImmediateKinds = new HashSet<OpKind>()
        {
            OpKind.Immediate16,
            OpKind.Immediate32,
            OpKind.Immediate32to64,
            OpKind.Immediate64,
            OpKind.Immediate8,
            OpKind.Immediate8to16,
            OpKind.Immediate8to32,
            OpKind.Immediate8to64,
            OpKind.Immediate8_2nd,
        };

        private static HashSet<OpKind> memoryKinds = new HashSet<OpKind>()
        {
            OpKind.MemorySegSI,
            OpKind.MemorySegESI,
            OpKind.MemorySegRSI,
            OpKind.MemorySegDI,
            OpKind.MemorySegEDI,
            OpKind.MemorySegRDI,
            OpKind.MemoryESDI,
            OpKind.MemoryESEDI,
            OpKind.MemoryESRDI,
            OpKind.Memory,
        };

        public static HashSet<HashSet<Register>> regList = new HashSet<HashSet<Iced.Intel.Register>>()
        {
            new HashSet<Register>() {Register.RAX, Register.EAX, Register.AX, Register.AH, Register.AL },
            new HashSet<Register>() {Register.RBX, Register.EBX, Register.BX, Register.BH, Register.BL },
            new HashSet<Register>() {Register.RCX, Register.ECX, Register.CX, Register.CH, Register.CL },
            new HashSet<Register>() {Register.RDX, Register.EDX, Register.DX, Register.DH, Register.DL },
            new HashSet<Register>() {Register.RSI, Register.ESI, Register.SI, Register.None, Register.SIL },
            new HashSet<Register>() {Register.RDI, Register.EDI, Register.DI, Register.None, Register.DIL },
            new HashSet<Register>() {Register.RBP, Register.EBP, Register.BP, Register.None, Register.BPL },
            new HashSet<Register>() {Register.RSP, Register.ESP, Register.SP, Register.None, Register.SPL },
            new HashSet<Register>() {Register.R8, Register.R8D, Register.R8W, Register.None, Register.R8L },
            new HashSet<Register>() {Register.R9, Register.R9D, Register.R9W, Register.None, Register.R9L },
            new HashSet<Register>() {Register.R10, Register.R10D, Register.R10W, Register.None, Register.R10L },
            new HashSet<Register>() {Register.R11, Register.R11D, Register.R11W, Register.None, Register.R11L },
            new HashSet<Register>() {Register.R12, Register.R12D, Register.R12W, Register.None, Register.R12L },
            new HashSet<Register>() {Register.R13, Register.R13D, Register.R13W, Register.None, Register.R13L },
            new HashSet<Register>() {Register.R14, Register.R14D, Register.R14W, Register.None, Register.R14L },
            new HashSet<Register>() {Register.R15, Register.R15D, Register.R15W, Register.None, Register.R15L },
        };

        public static bool IsBranch(this FlowControl flowControl)
        {
            if (flowControl == FlowControl.UnconditionalBranch || flowControl == FlowControl.IndirectBranch || flowControl == FlowControl.ConditionalBranch)
                return true;

            return false;
        }

        public static bool IsRet(this FlowControl flowControl)
        {
            return flowControl == FlowControl.Return;
        }

        public static bool IsConditional(this FlowControl flowControl)
        {
            return flowControl == FlowControl.ConditionalBranch;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImmediate(this OpKind kind)
        {
            switch (kind)
            {
                case OpKind.Immediate16:
                case OpKind.Immediate32:
                case OpKind.Immediate32to64:
                case OpKind.Immediate64:
                case OpKind.Immediate8:
                case OpKind.Immediate8to16:
                case OpKind.Immediate8to32:
                case OpKind.Immediate8to64:
                case OpKind.Immediate8_2nd:
                    return true;

                default:
                    return false;

            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBranchOpKind(this OpKind kind)
        {
            switch (kind)
            {
                case OpKind.FarBranch16:
                case OpKind.FarBranch32:
                case OpKind.NearBranch16:
                case OpKind.NearBranch32:
                case OpKind.NearBranch64:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsExplicitImmediate(this OpKind kind)
        {
            return explicitImmediateKinds.Contains(kind);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMemory(this OpKind kind)
        {
            switch (kind)
            {
                case OpKind.MemorySegSI:
                case OpKind.MemorySegESI:
                case OpKind.MemorySegRSI:
                case OpKind.MemorySegDI:
                case OpKind.MemorySegEDI:
                case OpKind.MemorySegRDI:
                case OpKind.MemoryESDI:
                case OpKind.MemoryESEDI:
                case OpKind.MemoryESRDI:
                case OpKind.Memory:
                    return true;

                default:
                    return false;
            }
        }

        public static uint GetImmediateSize(this OpKind kind)
        {
            switch(kind)
            {
                case OpKind.FarBranch16:
                    return 2;
                case OpKind.FarBranch32:
                    return 4;
                case OpKind.Immediate8:
                    return 1;
                case OpKind.Immediate8_2nd:
                    return 1;
                case OpKind.Immediate16:
                    return 2;
                case OpKind.Immediate32:
                    return 4;
                case OpKind.Immediate64:
                    return 8;
                case OpKind.Immediate8to16:
                    return 2;
                case OpKind.Immediate8to32:
                    return 4;
                case OpKind.Immediate8to64:
                    return 8;
                case OpKind.Immediate32to64:
                    return 8;
                default:
                    throw new InvalidOperationException(String.Format("Operand {0} is not an immediate.", kind));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetBranchSize(this OpKind kind)
        {
            switch (kind)
            {
                case OpKind.FarBranch16:
                    return 2;
                case OpKind.FarBranch32:
                    return 4;
                case OpKind.NearBranch16:
                    return 2;
                case OpKind.NearBranch32:
                    return 4;
                case OpKind.NearBranch64:
                    return 8;
                default:
                    throw new InvalidOperationException(String.Format("Operand {0} is not a branch.", kind));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetBranchTarget(this Instruction instruction, OpKind kind)
        {
            switch (kind)
            {
                case OpKind.FarBranch16:
                    return instruction.FarBranch16;
                case OpKind.FarBranch32:
                    return instruction.FarBranch32;
                case OpKind.NearBranch16:
                    return instruction.NearBranch16;
                case OpKind.NearBranch32:
                    return instruction.NearBranch32;
                case OpKind.NearBranch64:
                    return instruction.NearBranch64;
                default:
                    throw new InvalidOperationException(String.Format("Operand {0} is not a branch.", kind));
            }
        }
    }
}
