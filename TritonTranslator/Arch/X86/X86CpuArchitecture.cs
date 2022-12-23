using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Extensions;

namespace TritonTranslator.Arch.X86
{
    public class X86CpuArchitecture : ICpuArchitecture
    {
        private bool Is64Bit => ArchitectureId == ArchitectureId.ARCH_X86_64;

        public ArchitectureId ArchitectureId { get; }

        public uint GprSize => Is64Bit ? ByteSizes.Qword : ByteSizes.Dword;

        public X86CpuArchitecture(ArchitectureId architectureId)
        {
            ArchitectureId = architectureId;
            if (architectureId != ArchitectureId.ARCH_X86 && architectureId != ArchitectureId.ARCH_X86_64)
                throw new InvalidOperationException(String.Format("Architecture {0} is not supported by {1}", architectureId, nameof(X86CpuArchitecture)));
        }

        public bool IsRegisterValid(register_e register)
        {
            bool isInvalid = register != register_e.ID_REG_INVALID;

            bool isFlag = (register >= register_e.ID_REG_X86_AC && register <= register_e.ID_REG_X86_FZ) ? true : false;

            return isInvalid || isFlag;
        }

        public bool IsRegisterValid(Register register)
        {
            return IsRegisterValid(register.Id);
        }

        public bool IsFlagRegister(Register register)
        {
            return IsFlagRegister(register.Id);
        }

        public bool IsFlagRegister(register_e register)
        {
            switch(register)
            {
                case register_e.ID_REG_X86_CF:
                case register_e.ID_REG_X86_PF:
                case register_e.ID_REG_X86_AF:
                case register_e.ID_REG_X86_ZF:
                case register_e.ID_REG_X86_SF:
                case register_e.ID_REG_X86_TF:
                case register_e.ID_REG_X86_IF:
                case register_e.ID_REG_X86_DF:
                case register_e.ID_REG_X86_OF:
                case register_e.ID_REG_X86_NT:
                case register_e.ID_REG_X86_RF:
                case register_e.ID_REG_X86_VM:
                case register_e.ID_REG_X86_AC:
                case register_e.ID_REG_X86_VIF:
                case register_e.ID_REG_X86_VIP:
                case register_e.ID_REG_X86_ID:
                    return true;
            }

            return false;
        }

        public Register GetRegister(register_e id)
        {
            return X86Registers.RegisterMapping[id];
        }

        public Register GetRegister(string name)
        {
            return X86Registers.RegisterNameMapping[name];
        }

        public IEnumerable<Register> GetRegisters()
        {
            return X86Registers.RegisterMapping.Select(x => x.Value);
        }

        public Register GetRootParentRegister(register_e regId)
        {
            while (true)
            {
                var reg = X86Registers.RegisterMapping[regId];
                if (reg.ParentId == regId)
                    return reg;

                regId = reg.ParentId;
            }
        }

        public Register GetRootParentRegister(Register reg)
        {
            return GetRootParentRegister(reg.Id);
        }

        public Register GetParentRegister(register_e id)
        {
            var parentId = X86Registers.RegisterMapping[id].ParentId;
            return X86Registers.RegisterMapping[parentId];
        }

        public Register GetParentRegister(Register reg)
        {
            return GetParentRegister(reg.Id);
        }

        public Register GetProgramCounter()
        {
            return Is64Bit ? X86Registers.Rip : X86Registers.Eip;
        }

        public Register GetStackPointer()
        {
            return Is64Bit ? X86Registers.Rsp : X86Registers.Esp;
        }

        public Instruction Disassembly(Iced.Intel.Instruction instruction)
        {
            Instruction inst = new Instruction(instruction.OpCount);
            inst.Address = instruction.IP;
            inst.Size = (uint)instruction.Length;
            inst.Type = instruction.Mnemonic;
            inst.Prefix = GetTritonPrefix(instruction);

            for (int i = 0; i < instruction.OpCount; i++)
            {
                var opKind = instruction.GetOpKind(i);
                if (opKind.IsImmediate())
                {
                    inst.Operands.Add(new OperandWrapper(new Immediate((ulong)instruction.GetImmediate(i), opKind.GetImmediateSize())));
                }

                else if (opKind.IsMemory())
                {
                    // Set the size of the memory access.
                    var mem = new MemoryAccess();
                    int size = 0;
                    if (inst.Type == Iced.Intel.Mnemonic.Lea)
                        size = Iced.Intel.RegisterExtensions.GetSize(instruction.Op0Register);
                    else
                        size = Iced.Intel.MemorySizeExtensions.GetSize(instruction.MemorySize);
                    mem.SetBits((uint)(size * BitSizes.Byte) - 1, 0);

                    // TODO: Revisit and properly handle segmentation.
                    var segment = true ? X86Registers.Invalid :(IcedRegisterToTritonRegister(instruction.MemorySegment));
                    var baseReg = IcedRegisterToTritonRegister(instruction.MemoryBase);
                    var index = IcedRegisterToTritonRegister(instruction.MemoryIndex);

                    uint immSize = (
                        IsRegisterValid(baseReg.Id) ? baseReg.Size :
                        IsRegisterValid(index.Id) ? index.Size :
                        GprSize);

                    // Note: This is a semi-hacky way of addressing RIP relative memory handling.
                    var disp = instruction.IsIPRelativeMemoryOperand ? new Immediate((ulong)instruction.IPRelativeMemoryAddress - instruction.IP, immSize)
                        : new Immediate((ulong)instruction.MemoryDisplacement64, immSize);
                    var scale = new Immediate((ulong)instruction.MemoryIndexScale, immSize);


                    mem.SegmentReg = segment;
                    mem.BaseRegister = baseReg;
                    mem.IndexRegister = index;
                    mem.Displacement = disp;
                    mem.Scale = scale;

                    inst.Operands.Add(mem);
                }

                else if (opKind == Iced.Intel.OpKind.Register)
                {
                    var reg = IcedRegisterToTritonRegister(instruction.GetOpRegister(i));
                    inst.Operands.Add(reg);
                }

                else if(opKind.IsBranchOpKind())
                {
                    inst.Operands.Add(new OperandWrapper(new Immediate((ulong)instruction.GetBranchTarget(opKind), opKind.GetBranchSize())));
                }

                else
                {
                    throw new Exception(String.Format("Operand kind {0} is not valid.", opKind));
                }
            }

            return inst;
        }

        private Prefix GetTritonPrefix(Iced.Intel.Instruction instruction)
        {
            if (instruction.HasLockPrefix)
                return Prefix.ID_PREFIX_LOCK;
            if (instruction.HasRepPrefix)
                return Prefix.ID_PREFIX_REP;
            if (instruction.HasRepnePrefix)
                return Prefix.ID_PREFIX_REPNE;
            return Prefix.ID_PREFIX_INVALID;
        }

        private Register IcedRegisterToTritonRegister(Iced.Intel.Register regId)
        {
            if (regId == Iced.Intel.Register.None)
                return X86Registers.Invalid;

            return X86Registers.IcedRegisterMapping[regId];
        }
    }
}
