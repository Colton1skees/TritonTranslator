using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;

namespace TritonTranslator.Expression
{
    public class SymbolicExpression
    {
        public AbstractNode Source { get; }

        public AbstractNode Destination { get; }

        public SymbolicExpression(AbstractNode source, AbstractNode destination)
        {
            Source = source;
            Destination = destination;
        }
    }
}
