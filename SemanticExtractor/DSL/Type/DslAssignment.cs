using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.DSL.Type
{
    public class DslAssignment : DslStatement
    {
        public DslVariable Destination { get; set; }

        public DslEvaluatable Source { get; set; }

        public DslAssignment(DslVariable destination, DslEvaluatable source)
        {
            Destination = destination;
            Source = source;
        }
    }
}
