using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticExtractor.Parsing
{
    public static class SemanticMethodParser
    {
        public static void ParseMethod(string method)
        {
            // Parse the triton semantic method definition.
            var charStream = new AntlrInputStream(method);
            var lexer = new TritonSemanticsLexer(charStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new TritonSemanticsParser(tokenStream);
            parser.BuildParseTree = true;

            // DFS down the AST while building
            var root = parser.root();
            var dslTranslationVisitor = new DslTranslationVisitor();
            dslTranslationVisitor.VisitRoot(root);
        }
    }
}
