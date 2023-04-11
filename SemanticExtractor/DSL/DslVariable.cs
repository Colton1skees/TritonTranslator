using SemanticExtractor.DSL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.DSL
{
    public class DslVariable : DslEvaluatable
    {
        public string Name { get; set; }

        public DslType Type { get; set; }

        public DslVariable(string name, DslType type)
        {
            Name = name;
            Type = type;
        }
    }
}
