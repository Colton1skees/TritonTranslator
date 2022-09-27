using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;
using TritonTranslator.Intermediate;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Conversion
{
    public class AstToIntermediateConverter : IAstToIntermediateConverter
    {
        private uint temporaryCount = 0;

        private List<AbstractInst> instructions = new List<AbstractInst>();

        public IOperand FromAst(AbstractNode node)
        {
           switch(node)
           {
                default:
                    throw new InvalidOperationException(String.Format("Node type {0} is not supported.", node.Type));
           }

            return null;
        }

        private InstAdd FromBvadd(BvaddNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstAdd(dest, op1, op2);
            return inst;
        }

        private InstAnd FromBvand(BvandNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstAnd(dest, op1, op2);
            return inst;
        }

        private InstAshr FromBvashr(BvashrNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstAshr(dest, op1, op2);
            return inst;
        }

        private InstLshr FromBvlshr(BvlshrNode node)
        {
            return null;
        }

        private InstMul FromBvmul(BvmulNode node)
        {
            return null;
        }

        private InstNeg FromBvneg(BvnegNode node)
        {
            return null;
        }

        private InstCopy FromBvNode(BvNode node)
        {
            return null;
        }

        private InstNot FromBvnot(BvnotNode node)
        {
            return null;
        }

        private InstOr FromBvor(BvorNode node)
        {
            return null;
        }

        private InstRol FromBvrol(BvrolNode node)
        {
            return null;
        }

        private InstRor FromBvror(BvrorNode node)
        {
            return null;
        }

        private InstSdiv FromBvsdiv(BvsdivNode node)
        {
            return null;
        }

        private InstCond FromBvsge(BvsgeNode node)
        {
            return null;
        }

        private InstCond FromBvsgt(BvsgtNode node)
        {
            return null;
        }

        private InstShl FromBvshl(BvshlNode node)
        {
            return null;
        }

        private InstCond FromBvsle(BvsleNode node)
        {
            return null;
        }

        private InstCond FromBvslt(BvsltNode node)
        {
            return null;
        }

        private InstSmod FromBvsmod(BvsmodNode node)
        {
            return null;
        }

        private InstSrem FromBvsrem(BvsremNode node)
        {
            return null;
        }

        private InstSub FromBvsub(BvsubNode node)
        {
            return null;
        }

        private InstUdiv FromBvudiv(BvudivNode node)
        {
            return null;
        }

        private InstCond FromBvuge(BvugeNode node)
        {
            return null;
        }

        private InstCond FromBvugt(BvugtNode node)
        {
            return null;
        }

        private InstCond FromBvule(BvuleNode node)
        {
            return null;
        }

        private InstCond FromBvult(BvultNode node)
        {
            return null;
        }

        private InstUrem FromBvurem(BvuremNode node)
        {
            return null;
        }

        private InstXor FromBvxor(BvxorNode node)
        {
            return null;
        }

        private InstConcat FromConcat(ConcatNode node)
        {
            return null;
        }

        private InstCond FromEqual(EqualNode node)
        {
            return null;
        }

        private InstExtract FromExtract(ExtractNode node)
        {
            return null;
        }

        private InstCopy FromInteger(IntegerNode node)
        {
            return null;
        }

        private InstSelect FromIte(IteNode node)
        {
            return null;
        }

        private InstLoad FromMemory(MemoryNode node)
        {
            return null;
        }

        private InstCopy FromReference(ReferenceNode node)
        {
            return null;
        }

        private InstCopy FromRegister(RegisterNode node)
        {
            return null;
        }

        private InstSx FromSx(SxNode node)
        {
            return null;
        }

        private InstCopy FromUndef(UndefNode node)
        {
            return null;
        }

        private InstZx FromZx(ZxNode node)
        {
            return null;
        }

        private TemporaryOperand GetTemporary(uint bitSize)
        {
            var temp = new TemporaryOperand(temporaryCount, bitSize);
            temporaryCount++;
            return temp;
        }
    }
}
