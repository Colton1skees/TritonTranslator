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
        // The of generated temporaries.
        private uint temporaryCount = 0;

        // A list of all generated instructions.
        private List<AbstractInst> instructions = new List<AbstractInst>();

        // Workaround to avoid hash consing with reference nodes. TODO: Refactor.
        private Dictionary<ReferenceNode, InstCopy> translatedReferences = new Dictionary<ReferenceNode, InstCopy>();

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
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstLshr(dest, op1, op2);
            return inst;
        }

        private InstMul FromBvmul(BvmulNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstMul(dest, op1, op2);
            return inst;
        }

        private InstNeg FromBvneg(BvnegNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstNeg(dest, op1);
            return inst;
        }

        private InstCopy FromBvNode(BvNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var immediate = (IntegerNode)node.Expr1;
            var op1 = new ImmediateOperand(immediate.Value, immediate.BitSize);
            var inst = new InstCopy(dest, op1);
            return inst;
        }

        private InstNot FromBvnot(BvnotNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstNot(dest, op1);
            return inst;
        }

        private InstOr FromBvor(BvorNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstOr(dest, op1, op2);
            return inst;
        }

        private InstRol FromBvrol(BvrolNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstRol(dest, op1, op2);
            return inst;
        }

        private InstRor FromBvror(BvrorNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstRor(dest, op1, op2);
            return inst;
        }

        private InstSdiv FromBvsdiv(BvsdivNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstSdiv(dest, op1, op2);
            return inst;
        }

        private InstCond FromBvsge(BvsgeNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Sge, dest, op1, op2);
            return inst;
        }

        private InstCond FromBvsgt(BvsgtNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Sgt, dest, op1, op2);
            return inst;
        }

        private InstShl FromBvshl(BvshlNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstShl(dest, op1, op2);
            return inst;
        }

        private InstCond FromBvsle(BvsleNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Sle, dest, op1, op2);
            return inst;
        }

        private InstCond FromBvslt(BvsltNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Slt, dest, op1, op2);
            return inst;
        }

        private InstSmod FromBvsmod(BvsmodNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstSmod(dest, op1, op2);
            return inst;
        }

        private InstSrem FromBvsrem(BvsremNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstSrem(dest, op1, op2);
            return inst;
        }

        private InstSub FromBvsub(BvsubNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstSub(dest, op1, op2);
            return inst;
        }

        private InstUdiv FromBvudiv(BvudivNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstUdiv(dest, op1, op2);
            return inst;
        }

        private InstCond FromBvuge(BvugeNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Uge, dest, op1, op2);
            return inst;
        }

        private InstCond FromBvugt(BvugtNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Ugt, dest, op1, op2);
            return inst;
        }

        private InstCond FromBvule(BvuleNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Ule, dest, op1, op2);
            return inst;
        }

        private InstCond FromBvult(BvultNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Ult, dest, op1, op2);
            return inst;
        }

        private InstUrem FromBvurem(BvuremNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstUrem(dest, op1, op2);
            return inst;
        }

        private InstXor FromBvxor(BvxorNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstXor(dest, op1, op2);
            return inst;
        }

        private InstConcat FromConcat(ConcatNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var ops = node.Children.Select(x => FromAst(x));
            var inst = new InstConcat(dest, ops);
            return inst;
        }

        private InstCond FromEqual(EqualNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstCond(CondType.Eq, dest, op1, op2);
            return inst;
        }

        private InstExtract FromExtract(ExtractNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var op3 = FromAst(node.Expr3);
            var inst = new InstExtract(dest, op1, op2, op3);
            return inst;
        }

        private InstCopy FromInteger(IntegerNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = new ImmediateOperand(node.Value, node.BitSize);
            var inst = new InstCopy(dest, op1);
            return inst;
        }

        private InstSelect FromIte(IteNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var op3 = FromAst(node.Expr3);
            var inst = new InstSelect(dest, op1, op2, op3);
            return inst;
        }

        private InstLoad FromMemory(MemoryNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var sizeOp = new ImmediateOperand(node.BitSize, node.BitSize);
            var inst = new InstLoad(dest, op1, sizeOp);
            return inst;
        }

        private InstCopy FromReference(ReferenceNode node)
        {
            // Triton uses the reference node instruction to avoid
            // duplicating ASTs. To avoid unnnecessary hash consing,
            // we maintain a lookup table of all translated references.
            // This should not be a problem, since reference nodes
            // never leave the scope of a single instruction.
            if (translatedReferences.ContainsKey(node))
                return translatedReferences[node];

            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstCopy(dest, op1);
            return inst;
        }

        private InstCopy FromRegister(RegisterNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = new RegisterOperand(node.Register);
            var inst = new InstCopy(dest, op1);
            return inst;
        }

        private InstSx FromSx(SxNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstSx(dest, op1, op2);
            return inst;
        }

        private InstCopy FromUndef(UndefNode node)
        {
            // Emulate undefined behavior via reading from
            // an undefined temporary.
            var dest = GetTemporary(node.BitSize);
            var op1 = GetTemporary(node.BitSize);
            var inst = new InstCopy(dest, dest);
            return inst;
        }

        private InstZx FromZx(ZxNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var op2 = FromAst(node.Expr2);
            var inst = new InstZx(dest, op1, op2);
            return inst;
        }

        private TemporaryOperand GetTemporary(uint bitSize)
        {
            var temp = new TemporaryOperand(temporaryCount, bitSize);
            temporaryCount++;
            return temp;
        }
    }
}
