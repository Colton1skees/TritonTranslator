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
    /// <summary>
    /// Class for translating an AST based representation to three address code form.
    /// </summary>
    public interface IAstToIntermediateConverter
    {
        public IEnumerable<AbstractInst> Convert(AbstractNode node);
    }
}
