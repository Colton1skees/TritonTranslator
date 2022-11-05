using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;
using TritonTranslator.Expression;
using TritonTranslator.Intermediate;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Conversion
{
    /// <summary>
    /// Class for translating an AST based representation to three address code form.
    /// </summary>
    public interface IAstToIntermediateConverter
    {
        /// <summary>
        /// Gets a three address code representation of an AST.
        /// </summary>
        /// <param name="symbolicExpression"></param>
        /// <returns></returns>
        public IEnumerable<AbstractInst> ConvertFromSymbolicExpression(SymbolicExpression symbolicExpression);

        /// <summary>
        /// Gets a three address code representation of an AST.
        /// </summary>
        /// <param name="node">The AST node.</param>
        public IEnumerable<AbstractInst> ConvertFromAst(AbstractNode node);
    }
}
