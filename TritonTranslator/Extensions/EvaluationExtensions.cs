using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;
using TritonTranslator.Expression;

namespace TritonTranslator.Extensions
{
    internal static class EvaluationExtensions
    {
        // This is an artifact left over from transpiling the semantics.
        // TODO: Manually edit all semantics to remove dependencies on
        // concrete evaluations.
        public static Evaluation Evaluate(this AbstractNode node)
        {
            return Evaluation.Instance;
        }
    }
}
