using SemanticExtractor.DSL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.DSL
{
    public class DslFuncNode : DslNode
    {
        public string Name { get; set; }

        public DslType ReturnType { get; set; }

        public List<DslFuncArgument> Arguments { get; } = new List<DslFuncArgument>();

        public List<DslStatement> Statements { get; }  = new List<DslStatement>();
    }
}
