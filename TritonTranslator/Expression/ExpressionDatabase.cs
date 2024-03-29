﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;
using TritonTranslator.Ast;

namespace TritonTranslator.Expression
{
    internal class ExpressionDatabase : IExpressionDatabase
    {
        private readonly IAstBuilder astBuilder;

        public List<SymbolicExpression> SymbolicExpressions { get; } = new List<SymbolicExpression>();

        public ExpressionDatabase(IAstBuilder astBuilder)
        {
            this.astBuilder = astBuilder;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<AbstractNode> GetSymbolicExpressions()
        {
            // Internally this is only used in the rdtsc implementation.
            // TODO: Update the rdtsc semantics.
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode StoreSymbolicAssignment(Instruction instruction, AbstractNode node, OperandWrapper dst, string comment)
        {
            return StoreSymbolicAssignment(instruction, node, astBuilder.GetOperandAst(dst), comment);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode StoreSymbolicRegisterAssignment(Instruction inst, AbstractNode node, Register reg, string comment)
        {
            return StoreSymbolicAssignment(inst, node, astBuilder.GetRegisterAst(reg), comment);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode StoreSymbolicExpression(Instruction inst, AbstractNode node, string comment)
        {
            return StoreSymbolicAssignment(inst, node, (AbstractNode)null, comment);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AbstractNode StoreSymbolicAssignment(Instruction instruction, AbstractNode node, AbstractNode dst, string comment)
        {
            SymbolicExpressions.Add(new SymbolicExpression(node, dst));
            return node;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StorePathConstraint(Instruction inst, AbstractNode expr)
        {
            // This method is a no-op, since path constraints may be collected
            // via walking the generated ASTs instead.
        }
    }
}
