using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.DSL.Type
{
    public class DslType
    {
        public override string ToString() => this.GetType().Name.Replace("Type", "");
    }
}
