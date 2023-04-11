using SemanticExtractor.DSL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SemanticExtractor.Parsing.TritonSemanticsParser;

namespace SemanticExtractor.Parsing
{
    public static class DslConverter
    {
        public static DslType GetTypeNode(TypeContext context)
        {
            return context switch
            {
                VoidTypeContext => new VoidType(),
                BoolTypeContext => new BoolType(),
                SymbolicExpressionTypeContext => new SymbolicExpressionType(),
                AbstractNodeTypeContext => new AbstractNodeType(),
                OperandWrapperTypeContext => new OperandWrapperType(),
                InstTypeContext => new InstructionType(),
                Uint32TypeContext => new Uint32Type(),
                SizeContext => new SizeType(),
                _ => throw new InvalidOperationException($"Cannot handle type: {context.GetText()}")
            };
        }
    }
}
