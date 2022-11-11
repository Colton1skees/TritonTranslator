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
        public AbstractNode Source { get; set; }

        public AbstractNode Destination { get; set; }

        public SymbolicExpression(AbstractNode source, AbstractNode destination)
        {
            Source = source;
            Destination = destination;

            if(Destination != null && Source.BitSize != Destination.BitSize)
            {
                var errMsg = String.Format("Expression source size {0} does not match destination {1}.", source.BitSize, destination.BitSize);
                throw new InvalidOperationException(errMsg);
            }
        }
    }
}
