using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;
using TritonTranslator.Ast;

namespace TritonTranslator.Expression
{
    public interface IAstBuilder
    {
        public AbstractNode GetImmediateAst(Instruction inst, Immediate immediate);

        public AbstractNode GetImmediateAst(Immediate immediate);

        public AbstractNode GetOperandAst(Instruction inst, OperandWrapper op);

        public AbstractNode GetOperandAst(Instruction inst, AbstractNode op);

        public AbstractNode GetOperandAst(OperandWrapper op);

        public AbstractNode GetRegisterAst(Instruction inst, Register register);

        public AbstractNode GetRegisterAst(Register register);

        public AbstractNode GetMemoryAst(MemoryAccess access);

        public void InitLeaAst(MemoryAccess access);
    }
}
