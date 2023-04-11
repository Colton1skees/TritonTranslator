using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.Parsing
{
    public static class MethodExtractor
    {
        public static IReadOnlyList<IReadOnlyList<string>> ExtractMethodDefinitions(List<string> lines)
        {
            var methodDefinitions = new List<List<string>>();

            List<string> currentMethodDef = null;
            int numOpenBrackets = 0;
            foreach(var line in lines)
            {
                // If we encounter the start of a method, start keeping track of the contents.
                if(line.Contains("x86Semantics::") && !line.Contains("triton::exceptions::Semantics"))
                    currentMethodDef = new List<string>();

                // If the current line does not belong to any method, then skip it.
                if (currentMethodDef == null)
                    continue;

                // Since the line belongs to a method, store it.
                currentMethodDef.Add(line);
               
                // Increment the current open bracket count via the number of opening brackets.
                numOpenBrackets += line.Count(x => x == '{');

                // Count the number of close brackets.
                var numCloseBrackets = line.Count(x => x == '}');

                // Decrement the amount of opening brackets by the amount of closing brackets
                // within the current line.
                numOpenBrackets -= numCloseBrackets;

                // If the number of opening brackets is equal to zero,
                // then we have reached the end of the method definition.
                if (numOpenBrackets != 0)
                    continue;

                methodDefinitions.Add(currentMethodDef);
                numOpenBrackets = 0;
                currentMethodDef = null;
            }

            return methodDefinitions;
        }

        public static string GetMethodName(string line)
        {
            return line
                .Split("x86Semantics::", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split("(", StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}
