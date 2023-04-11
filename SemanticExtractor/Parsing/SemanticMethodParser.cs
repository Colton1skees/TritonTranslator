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
            var charStream = new AntlrInputStream(method);
            var lexer = new TritonSemanticsLexer(charStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new TritonSemanticsParser(tokenStream);
            parser.BuildParseTree = true;
            
            var dslTranslationVisitor = new DslTranslationVisitor();
        }
    }
}
