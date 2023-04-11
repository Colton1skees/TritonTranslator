using Antlr4.Runtime.Misc;
using SemanticExtractor.DSL;
using SemanticExtractor.DSL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SemanticExtractor.Parsing.TritonSemanticsParser;

namespace SemanticExtractor.Parsing
{
    public class DslTranslationVisitor : TritonSemanticsBaseVisitor<DslNode>
    {
        private Dictionary<string, DslVariable> variables = new();

        public override DslNode VisitFunc_declaration([NotNull] TritonSemanticsParser.Func_declarationContext context)
        {
            // Use the prototype to construct a bare function node,
            // containing just the name and arguments.
            var functionNode = (DslFuncNode)Visit(context.func_prototype());

            var statements = context.statement().Select(x => (DslStatement)Visit(x));
            functionNode.Statements.AddRange(statements);

            Console.WriteLine(functionNode);
            return functionNode;
        }

        public override DslNode VisitFunc_prototype([NotNull] TritonSemanticsParser.Func_prototypeContext context)
        {
            // Set the name of the function.
            var func = new DslFuncNode();
            func.Name = context.ID(1).GetText();

            // Set the return type of the function.
            func.ReturnType = DslConverter.GetTypeNode(context.type(0));

            // Iterate through type node within the prototype object.
            // Note that we skip the first node here sin
            for(int i = 1; i < context.type().Length; i++)
            {
                var argType = DslConverter.GetTypeNode(context.type(i)); 
                var argName = context.ID(i + 1).GetText(); ;
                var arg = new DslFuncArgument(argName, argType);
                func.Arguments.Add(arg);
            }

            return func;
        }

        public override DslNode VisitStandardAssignment([NotNull] TritonSemanticsParser.StandardAssignmentContext context)
        {
            // Get the assignment destination.
            var dest = context.assignment_destination();

            // Handle the case where a new variable is being defined. 
            if(dest is NewAssignmentDestinationContext newAssignmentDest)
            {
                // Get the source expression(i.e. the value assigned to the destination.
                var source = (DslEvaluatable)VisitAny_evaluatable(context.any_evaluatable());

                // Create the destination variable.
                var destName = newAssignmentDest.new_var_def().ID().GetText();
                var destVar = new DslVariable(destName, source.Type);
                variables.Add(destVar.Name, destVar);
                return new DslAssignment(destVar, source);
            }

            // Otherwise, handle the case where an existing variable is being assigned to.
            else if(dest is ExistingAssignmentDestinationContext existingAssignmentDest)
            {

            }

            return base.VisitStandardAssignment(context);
        }
    }
}
