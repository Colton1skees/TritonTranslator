using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Arch
{
    /// <summary>
    /// Cpu architecture.
    /// </summary>
    public enum ArchitectureId
    {
        /// <summary>
        /// Invalid architecture.
        /// </summary>
        ARCH_INVALID = 0, 
        /// <summary>
        /// AArch64 architecture.
        /// </summary>
        ARCH_AARCH64, 
        /// <summary>
        /// ARM32 architecture.
        /// </summary>
        ARCH_ARM32,  
        /// <summary>
        /// X86 architecture.
        /// </summary>
        ARCH_X86, 
        /// <summary>
        /// X86_64 architecture.
        /// </summary>
        ARCH_X86_64,  
    }

    /// <summary>
    /// Class for querying information about an architecture.
    /// </summary>
    public interface ICpuArchitecture
    {
        public ArchitectureId ArchitectureId { get; }

        public uint GprSize { get; }

        public bool IsRegisterValid(register_e register);

        public bool IsRegisterValid(Register register);

        public Register GetRegister(register_e id);

        public Register GetRegister(string name);

        public IEnumerable<Register> GetRegisters();

        public Register GetRootParentRegister(register_e id);

        public Register GetRootParentRegister(Register reg);

        public Register GetParentRegister(register_e id);

        public Register GetParentRegister(Register reg);

        public Register GetProgramCounter();

        public Register GetStackPointer();

        public Instruction Disassembly(Iced.Intel.Instruction instruction);
    }
}
