using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;
using TritonTranslator.Ast;

namespace TritonTranslator.Expression
{
    /// <summary>
    /// Class for storing instantiated expression ASTs.
    /// </summary>
    internal interface IExpressionDatabase
    {
        public List<SymbolicExpression> SymbolicExpressions { get; }

        public IEnumerable<AbstractNode> GetSymbolicExpressions();

        public AbstractNode StoreSymbolicAssignment(Instruction inst, AbstractNode node, OperandWrapper dst, string comment);

        public AbstractNode StoreSymbolicRegisterAssignment(Instruction inst, AbstractNode node, Register reg, string comment);

        public AbstractNode StoreSymbolicExpression(Instruction inst, AbstractNode node, string comment);

        public AbstractNode StoreSymbolicAssignment(Instruction inst, AbstractNode node, AbstractNode dst, string comment);

        public void StorePathConstraint(Instruction inst, AbstractNode expr);
    }
}
