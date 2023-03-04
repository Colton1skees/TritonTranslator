using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;
using TritonTranslator.Arch.X86;
using TritonTranslator.Ast;

namespace TritonTranslator.Expression
{
    public class AstBuilder : IAstBuilder
    {
        private readonly ICpuArchitecture architecture;

        private readonly AstContext astCtxt = new AstContext();

        public AstBuilder(ICpuArchitecture architecture)
        {
            this.architecture = architecture;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetImmediateAst(Instruction inst, Immediate immediate)
        {
            return GetImmediateAst(immediate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetImmediateAst(Immediate immediate)
        {
            return new BvNode(immediate.Value, immediate.BitSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetOperandAst(Instruction inst, OperandWrapper op)
        {
            return GetOperandAst(op);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetOperandAst(Instruction inst, AbstractNode op)
        {
            return op;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetOperandAst(OperandWrapper op)
        {
            switch (op.Type)
            {
                case OperandType.Imm:
                    return new IntegerNode(op.Immediate.Value, op.BitSize);
                case OperandType.Mem:
                    return GetMemoryAst(op.MemoryAccess);
                case OperandType.Reg:
                    return X86Registers.RegisterNodeMapping[op.Register.Id];
                default:
                    throw new InvalidOperationException(string.Format("Cannot convert operand type {0} to ast.", op.Type));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetRegisterAst(Instruction inst, Register register)
        {
            return X86Registers.RegisterNodeMapping[register.Id];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode GetRegisterAst(Register register)
        {
            return X86Registers.RegisterNodeMapping[register.Id];
        }

        public AbstractNode GetMemoryAst(MemoryAccess access)
        {

            var baseReg = access.BaseRegister == null ? X86Registers.Invalid : access.BaseRegister;
            var index = access.IndexRegister == null ? X86Registers.Invalid : access.IndexRegister;
            var seg = access.SegmentReg;
            ulong scaleValue = access.Scale == null ? 1 : access.Scale.Value;
            ulong dispValue = access.Displacement == null ? 0 : access.Displacement.Value;
            uint bitSize = (architecture.IsRegisterValid(baseReg) ? baseReg.BitSize :
                                                  (architecture.IsRegisterValid(index) ? index.BitSize :
                                                    (access.Displacement.BitSize > 0 ? access.Displacement.BitSize :
                                                      architecture.GprSize
                                                    )
                                                  )
                                                );

            // TODO: Handle segmentation and LEAs.
            AbstractNode address = null;
            if (baseReg.Id != register_e.ID_REG_INVALID)
                address = new RegisterNode(baseReg);
            else if (seg != null && architecture.IsRegisterValid(seg))
                address = new RegisterNode(seg);
            else
                throw new InvalidOperationException("Cannot process memory access.");

            
            if(index.Id != register_e.ID_REG_INVALID)
            {
                var offset = scaleValue == 1 ? new RegisterNode(index) : astCtxt.bvmul(astCtxt.bv(scaleValue, bitSize), new RegisterNode(index));
                address = astCtxt.bvadd(address, offset);
            }

            if(dispValue != 0)
                address = astCtxt.bvadd(address, astCtxt.bv(dispValue, bitSize));

            return new MemoryNode(address, access.BitSize);
        }

        public void InitLeaAst(MemoryAccess access)
        {
            // This *should* be a no-op with our implementation
            // of triton's semantics.
        }
    }
}
