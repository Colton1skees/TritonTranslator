using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;
using TritonTranslator.Ast;
using TritonTranslator.Expression;
using TritonTranslator.Intermediate;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Conversion
{
    public class AstToIntermediateConverter : IAstToIntermediateConverter
    {
        private readonly ICpuArchitecture architecture;

        // A list of all generated instructions.
        private List<AbstractInst> instructions = new();

        // Workaround to avoid hash consing with reference nodes. TODO: Refactor.
        private Dictionary<ReferenceNode, InstCopy> translatedReferences = new();

        public AstToIntermediateConverter(ICpuArchitecture architecture)
        {
            this.architecture = architecture;
        }

        public IEnumerable<AbstractInst> ConvertFromSymbolicExpression(SymbolicExpression symbolicExpression)
        {
            // Create a pure / side effect free 3AC representation.
            var instructions = (List<AbstractInst>)ConvertFromAst(symbolicExpression.Source);

            // If the symbolic expression does not have a destination, exit.
            if (symbolicExpression.Destination == null)
                return instructions;

            // This relies on the assumption that the destination of the last instruction
            // will always contain the root AST evaluation. In practice, this should always work.
            // TODO: Refactor.
            var expressionDestinationNode = symbolicExpression.Destination;
            if(expressionDestinationNode is RegisterNode regNode)
            {
                // Store the AST result to the register destination.
                var destInst = new InstCopy(new RegisterOperand(regNode.Register), instructions.Last().Dest);
                instructions.Add(destInst);
            }

            else if(expressionDestinationNode is TemporaryNode tempNode)
            {
                // Store the AST result to the register destination.
                var destInst = new InstCopy(new TemporaryOperand(tempNode.Uid, tempNode.BitSize), instructions.Last().Dest);
                instructions.Add(destInst);
            }

            else if(expressionDestinationNode is MemoryNode memNode)
            {
                var destValue = instructions.Last().Dest;

                // Create an instruction sequence to compute the memory address.
                var memoryInstructions = (List<AbstractInst>)ConvertFromAst(memNode.Expr1);
                instructions.AddRange(memoryInstructions);
                var op1 = instructions.Last().Dest;

                // Create an instruction to store the AST result to the destination memory address.
                var destInst = new InstStore(instructions.Last().Dest, destValue);
                instructions.Add(destInst);
            }

            else
            {
                throw new InvalidOperationException($"Node type of {expressionDestinationNode.GetType().Name} is not a supported destination node type.");
            }

            return instructions;
        }

        public IEnumerable<AbstractInst> ConvertFromAst(AbstractNode node)
        {
            // Build and create a reference to the list of instructions.
            FromAst(node);
            var result = instructions;

            // Create a new instruction list.
            instructions = new List<AbstractInst>();
            translatedReferences.Clear();
            return result;
        }

        private IOperand FromAst(AbstractNode ast)
        {
           AbstractInst inst = null;
           switch(ast)
           {
                case BvaddNode node:
                    inst = FromBvadd(node);
                    break;
                case BvandNode node:
                    inst = FromBvand(node);
                    break;
                case BvashrNode node:
                    inst = FromBvashr(node);
                    break;
                case BvlshrNode node:
                    inst = FromBvlshr(node);
                    break;
                case BvmulNode node:
                    inst = FromBvmul(node);
                    break;
                case BvnegNode node:
                    inst = FromBvneg(node);
                    break;
                case BvNode node:
                    inst = FromBvNode(node);
                    break;
                case BvnotNode node:
                    inst = FromBvnot(node);
                    break;
                case BvorNode node:
                    inst = FromBvor(node);
                    break;
                case BvrolNode node:
                    inst = FromBvrol(node);
                    break;
                case BvrorNode node:
                    inst = FromBvror(node);
                    break;
                case BvsdivNode node:
                    inst = FromBvsdiv(node);
                    break;
                case BvsgeNode node:
                    inst = FromBvsge(node);
                    break;
                case BvsgtNode node:
                    inst = FromBvsgt(node);
                    break;
                case BvshlNode node:
                    inst = FromBvshl(node);
                    break;
                case BvsleNode node:
                    inst = FromBvsle(node);
                    break;
                case BvsltNode node:
                    inst = FromBvslt(node);
                    break;
                case BvsmodNode node:
                    inst = FromBvsmod(node);
                    break;
                case BvsremNode node:
                    inst = FromBvsrem(node);
                    break;
                case BvsubNode node:
                    inst = FromBvsub(node);
                    break;
                case BvudivNode node:
                    inst = FromBvudiv(node);
                    break;
                case BvugeNode node:
                    inst = FromBvuge(node);
                    break;
                case BvugtNode node:
                    inst = FromBvugt(node);
                    break;
                case BvuleNode node:
                    inst = FromBvule(node);
                    break;
                case BvultNode node:
                    inst = FromBvult(node);
                    break;
                case BvuremNode node:
                    inst = FromBvurem(node);
                    break;
                case BvxorNode node:
                    inst = FromBvxor(node);
                    break;
                case ConcatNode node:
                    inst = FromConcat(node);
                    break;
                case EqualNode node:
                    inst = FromEqual(node);
                    break;
                case ExtractNode node:
                    inst = FromExtract(node);
                    break;
                case IntegerNode node:
                    inst = FromInteger(node);
                    break;
                case IteNode node:
                    inst = FromIte(node);
                    break;
                case MemoryNode node:
                    inst = FromMemoryLoad(node);
                    break;
                case ReferenceNode node:
                    inst = FromReference(node);
                    break;
                case RegisterNode node:
                    inst = FromRegister(node);
                    break;
                case SxNode node:
                    inst = FromSx(node);
                    break;
                case UndefNode node:
                    inst = FromUndef(node);
                    break;
                case ZxNode node:
                    inst = FromZx(node);
                    break;
                case ZeroNode node:
                    inst = FromZero(node);
                    break;
                case CarryNode node:
                    inst = FromCarry(node);
                    break;
                case OverflowNode node:
                    inst = FromOverflow(node);
                    break;
                case SignNode node:
                    inst = FromSign(node);
                    break;
                case ParityNode node:
                    inst = FromParity(node);
                    break;
                case TemporaryNode node:
                    inst = FromTemporary(node);
                    break;
                default:
                    throw new InvalidOperationException(String.Format("Node type {0} is not supported.", ast.Type));
           }

            instructions.Add(inst);
            return inst.Dest;
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
            // Create a temporary to store the result.
            var dest = GetTemporary(node.BitSize);

            // Get the immediate high.
            var immediate1 = (IntegerNode)node.Expr1;
            var op1 = new ImmediateOperand(immediate1.Value, immediate1.BitSize);

            // Get the immediate low.
            var immediate2 = (IntegerNode)node.Expr2;
            var op2 = new ImmediateOperand(immediate2.Value, immediate2.BitSize);

            // Construct the extract instruction.
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

        private InstLoad FromMemoryLoad(MemoryNode node)
        {
            // ASTs have no concept of destinations, so we can't load or store.
            // Instead, we move the address computation expression to a temporary. 
            var dest = GetTemporary(node.BitSize);
            var addressOperand = FromAst(node.Expr1);
            var sizeOperand = new ImmediateOperand(node.BitSize, addressOperand.Bitsize);
            var inst = new InstLoad(dest, addressOperand, sizeOperand);
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

        private InstCopy FromTemporary(TemporaryNode node)
        {
            if (node.Uid.ToString().StartsWith("t16"))
                Debugger.Break();
            var dest = GetTemporary(node.BitSize);
            var op1 = new TemporaryOperand(node.Uid, node.BitSize);
            var inst = new InstCopy(dest, op1);
            return inst;
        }

        private InstSx FromSx(SxNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var immediate = (IntegerNode)node.Expr1;
            var op1 = new ImmediateOperand(immediate.Value, immediate.BitSize);
            var op2 = FromAst(node.Expr2);
            var inst = new InstSx(dest, op1, op2);
            return inst;
        }

        private InstCopy FromUndef(UndefNode node)
        {
            // Substitute undefined behavior with a
            // hardcoded constant.
            var dest = GetTemporary(node.BitSize);
            var op1 = new ImmediateOperand(0, node.BitSize);
            var inst = new InstCopy(dest, op1);
            return inst;
        }

        private InstZx FromZx(ZxNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var immediate = (IntegerNode)node.Expr1;
            var op1 = new ImmediateOperand(immediate.Value, immediate.BitSize);
            var op2 = FromAst(node.Expr2);
            var inst = new InstZx(dest, op1, op2);
            return inst;
        }

        private InstZero FromZero(ZeroNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstZero(dest, op1);
            return inst;
        }

        private InstCarry FromCarry(CarryNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstCarry(dest, op1);
            return inst;
        }

        private InstOverflow FromOverflow(OverflowNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstOverflow(dest, op1);
            return inst;
        }

        private InstSign FromSign(SignNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstSign(dest, op1);
            return inst;
        }

        private InstParity FromParity(ParityNode node)
        {
            var dest = GetTemporary(node.BitSize);
            var op1 = FromAst(node.Expr1);
            var inst = new InstParity(dest, op1);
            return inst;
        }

        private TemporaryOperand GetTemporary(uint bitSize)
        {
            var temp = new TemporaryOperand(architecture.GetUniqueTemporaryId(), bitSize);
            return temp;
        }
    }
}
