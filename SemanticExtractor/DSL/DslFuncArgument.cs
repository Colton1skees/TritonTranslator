using SemanticExtractor.DSL;
using SemanticExtractor.DSL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.DSL
{
    public class DslFuncArgument : DslVariable
    {
        public DslFuncArgument(string name, DslType type) : base(name, type)
        {

        }
    }
}
