﻿using System;
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
            var baseReg = access.BaseRegister;
            var index = access.IndexRegister;
            var seg = access.SegmentReg;
            ulong scaleValue = access.Scale.Value;
            ulong dispValue = access.Displacement.Value;
            uint bitSize = (architecture.IsRegisterValid(baseReg) ? baseReg.BitSize :
                                                  (architecture.IsRegisterValid(index) ? index.BitSize :
                                                    (access.Displacement.BitSize > 0 ? access.Displacement.BitSize :
                                                      architecture.GprSize
                                                    )
                                                  )
                                                );

            /* Initialize the AST of the memory access (LEA) -> ((pc + base) + (index * scale) + disp) */
            var pcPlusBaseAst = access.PcRelative > 0 ? astCtxt.bv(access.PcRelative, bitSize) :
                                      (architecture.IsRegisterValid(baseReg) ? GetRegisterAst(baseReg) :
                                        astCtxt.bv(0, bitSize));

            var indexMulScaleAst = astCtxt.bvmul(
                                      (architecture.IsRegisterValid(index) ? GetRegisterAst(index) : astCtxt.bv(0, bitSize)),
                                      astCtxt.bv(scaleValue, bitSize)
                                    );

            // Triton has some 'isSubtracted' property which seems to only apply for ARM operands.
            // For x86, we always default this to false.
            bool isSubtracted = false;

            var dispAst = astCtxt.bv(dispValue, bitSize);
            var leaAst = astCtxt.bvadd(
                                      isSubtracted ? astCtxt.bvsub(pcPlusBaseAst, indexMulScaleAst) : astCtxt.bvadd(pcPlusBaseAst, indexMulScaleAst),
                                      dispAst
                                    );

            /* Use segments as base address instead of selector into the GDT. */
            if (architecture.IsRegisterValid(seg))
            {
                leaAst = astCtxt.bvadd(
                           GetRegisterAst(seg),
                           astCtxt.sx((seg.BitSize - bitSize), leaAst)
                         );
            }

            return new MemoryNode(leaAst, access.BitSize);
        }

        public void InitLeaAst(MemoryAccess access)
        {
            // This *should* be a no-op with our implementation
            // of triton's semantics.
        }
    }
}
