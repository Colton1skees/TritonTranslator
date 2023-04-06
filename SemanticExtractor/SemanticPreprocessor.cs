using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Triton.Converter
{
    /// <summary>
    /// This class iteratively replaces / removes substrings until we arrive
    /// at a valid and compilable C# implementation of Triton's x86 lifter.
    /// 
    /// </summary>
    public class SemanticPreprocessor
    {
        private readonly string semanticsInputPath;

        private readonly string transpiledOutputPath;

        private List<string> lines;

        public IReadOnlyList<string> Output => lines.AsReadOnly();

        public SemanticPreprocessor(IReadOnlyList<string> lines)
        {
            this.lines = lines.ToList();
            Preprocess();
        }

        private void Preprocess()
        {
            // Replace common instances of C++ syntax with C# equivalents.
            ReplaceCppSyntax();

            // Replace usages of triton width variables with C# equivalents.
            ReplaceTritonSizes();

            // Replace common C++ type usages with C# type usages.
            ReplaceCppTypes();

            // Map triton types to our types
            Replace("triton::arch::Architecture*", "Architecture");
            Replace("triton::engines::symbolic::SymbolicEngine*", "SymbolicEngine");
            Replace("triton::ast::SharedAstContext", "AstContext");

            // Convert exceptions to .NET equivalents.
            Replace("triton::exceptions::Semantics", "new Exception");

            // Discard the "x86semantics::" method implementation prefix.
            Replace("x86Semantics::", "");

            // Use C# prefixes.
            Replace("triton::arch::x86::ID_PREFIX_", "Prefix.ID_PREFIX_");

            // Convert all triton::Instruction(and it's subcomponents) to
            // our implementation.
            Replace("triton::arch::register_e", "register_e");
            ReplaceType("triton::arch::Instruction", "Instruction");
            ReplaceType("triton::arch::OperandWrapper", "OperandWrapper");
            Replace("triton::arch::Immediate", "Immediate");
            ReplaceType("Immediate", "Immediate");
            ReplaceType("triton::arch::MemoryAccess", "MemoryAccess");
            ReplaceType("triton::arch::Register", "Register");
            ReplaceType("arch::Register", "Register");

            // Convert all instruction getters to property accesses.
            Replace("getType()", "Type");
            Replace("getSize()", "Size");
            Replace("getBitSize()", "BitSize");
            Replace("getAddress()", "Address");
            Replace("getNextAddress()", "NextAddress");
            Replace("getPrefix()", "Prefix");
            Replace(".setPrefix(Prefix.ID_PREFIX_REPE);", ".Prefix = Prefix.ID_PREFIX_REP;");
            Replace("getNextAddress()", "NextAddress");
            Replace("getLow()", "Low");
            Replace("getHigh()", "High");
            Replace("getRegister()", "Register");
            Replace("getConstRegister()", "Register");
            Replace("getMemory()", "MemoryAccess");
            Replace("getConstMemory()", "MemoryAccess");
            Replace("getImmediate()", "Immediate");
            Replace("getId()", "Id");
            Replace("getDisplacement()", "Displacement");
            Replace("getBaseRegister()", "BaseRegister");
            Replace("getIndexRegister()", "IndexRegister");
            Replace("getScale()", "Scale");
            Replace("getBitvectorSize()", "BitvectorSize");
            Replace(".getValue()", "GetValue()");

            Replace("triton::arch::OP_REG", "OperandType.Reg");
            Replace("triton::arch::OP_MEM", "OperandType.Mem");
            Replace("triton::arch::OP_IMM", "OperandType.Imm");

            // Convert all usages of ast::SharedAbstractNode to our implementation.
            ReplaceType("triton::ast::SharedAbstractNode", "AbstractNode");

            // Replace all references to "SharedSymbolicExpression" with an
            // abstract node.
            ReplaceType("triton::engines::symbolic::SharedSymbolicExpression", "AbstractNode");

            // Few and far between changes needed for compatibility.
            Replace("ID_REG_X86_", "register_e.ID_REG_X86_");
            Replace("triton::arch::register_e", "register_e");
            Replace("id >= register_e", "id >= (uint)register_e");
            Replace("id <= register_e", "id <= (uint)register_e");
            Replace("uint id = ", "uint id = (uint)");

            // Remove all calls to inst.removeWrittenRegister().
            Remove("removeWrittenRegister");

            // Remove the taint engine.
            Remove("taint");
            Remove("Taint");

            // Remove all calls to "setConditionTaken".
            Remove("setConditionTaken");

            // Make correct use of our C# Architecture implementation.
            ReplaceTritonArchitecture();

            // Assign a default value to boolean operators.
            Replace("bool vol", "bool vol = false");
            
            // Remove convert_to operators.
            Replace(".evaluate().convert_to<UInt64>()", ".evaluate()");
            Replace(".evaluate().convert_to<uint>()", ".evaluate()");

            // Assign default values to lists.
            InstantiateLists();

            // Fix up instantiation syntax of accumulators.
            Replace("OperandWrapper accumulator(", "OperandWrapper accumulator = new OperandWrapper(");
            Replace("OperandWrapper accumulatorp(", "OperandWrapper accumulatorp = new OperandWrapper(");

            Replace("OP_REG", "OperandType.Reg");
            Replace("static_cast<uint>", "(uint)");
            Replace("var base", "var baseReg");
            Replace("Register base", "Register baseReg");
            Replace("(base)", "(baseReg");
            Replace("(base.Size)", "(baseReg.Size)");
            Replace("GetConcreteRegisterValue(base)", "GetConcreteRegisterValue(baseReg)");

            Replace("std::list<AbstractNode> bytes;", "List<AbstractNode> bytes = new List<AbstractNode>();");
            Replace("push_front(", "Insert(0, ");

            Remove("removeReadRegister");

            Replace(".getValue()", "Value");

            Replace(".convert_to<UInt64>()", "");
        }

        private void InstantiateLists()
        {
            List<string> outLines = new List<string>();

            foreach (var line in lines)
            {
                if (!line.Contains("List<AbstractNode>"))
                {
                    outLines.Add(line);
                }
                else
                {
                    var split = line.Split('(', ')');
                    if (split.Length == 1)
                    {
                        var removedSemiColon = line.Replace(";", "");
                        outLines.Add(removedSemiColon + " = new List<AbstractNode>();");
                    }
                    else if (split.Length == 3)
                    {
                        // Remove the text in parenthesis(parameters).
                        var newLine = line.Replace(split[1], "");

                        // Remove the semicolon.
                        newLine = newLine.Replace(";", "");

                        newLine = newLine.Replace("(", "");
                        newLine = newLine.Replace(")", "");

                        var text = String.Format("{0} = new List<AbstractNode>() {{ {1} }};", newLine, split[1]);

                        outLines.Add(text);
                    }
                    else
                    {
                        throw new Exception("??");
                    }
                }
            }

            lines = outLines;
        }


        private void Remove(string substring)
        {
            List<string> outLines = new List<string>();
            foreach (var line in lines)
            {
                if (line.Contains(substring))
                {
                    string space = "";
                    foreach (var character in line)
                    {
                        if (char.IsWhiteSpace(character))
                            space += " ";
                    }

                    var text = space + "((Action)(() => { }))();";
                    outLines.Add(text);
                }
                else
                {
                    outLines.Add(line);
                }
            }

            lines = outLines;
        }

        private void RemoveReferenceOperators()
        {
            // Convert all (op1 && op2) and (comment & comment) sequences
            // to placeholders.
            Replace(" & ", "COMMENT_PLACEHOLDER");
            Replace(" && ", "AND_PLACEHOLDER");

            // Remove all reference operators.
            Replace("&", "");

            // Swap back the placeholders with their original values.
            Replace("COMMENT_PLACEHOLDER", " & ");
            Replace("AND_PLACEHOLDER", " && ");
        }

        private void Replace(string oldValue, string newValue)
        {
            lines = lines.Select(x => x.Replace(oldValue, newValue)).ToList();
        }

        /// <summary>
        /// Converts all inapplicable C++ syntax to the C# equivalent.
        /// </summary>
        private void ReplaceCppSyntax()
        {
            // Discard all includes.
            Remove("#include");

            // Convert all "->" operators to "."
            Replace("->", ".");

            RemoveReferenceOperators();

            // Convert the C++ capstone enum to the C# binding equivalent.
            Replace("ID_INS", "X86_INS");

            // Convert all uses of "auto" to "var".
            Replace("auto ", "var ");

            // Convert nullptr to null.
            Replace("nullptr", "null");

            // Remove const keyword.
            Replace("const ", "");
        }

        private void ReplaceCppTypes()
        {
            // Replace std::vector;
            Replace("std::vector", "List");
            Remove("reserve");
            Replace("push_back", "Add");
            Replace(".size()", ".Count()");

            Replace("std::string", "string");
        }

        private void ReplaceTritonArchitecture()
        {
            // Fix capitalization.
            Replace("architecture.getRegister", "architecture.GetRegister");
            Replace("architecture.getParentRegister", "architecture.GetParentRegister");
            Replace("architecture.getStackPointer", "architecture.GetStackPointer");
            Replace("architecture.getProgramCounter", "architecture.GetProgramCounter");
            Replace("architecture.isRegisterValid", "architecture.IsRegisterValid");
            Replace("architecture.getConcreteRegisterValue", "architecture.GetConcreteRegisterValue");
            Replace("architecture.getStackPointer", "architecture.GetStackPointer");
        }

        private void ReplaceTritonSizes()
        {
            // Convert all triton sizes bit sizes to C#.
            Replace("triton::bitsize::flag", "BitSizes.Flag");
            Replace("triton::bitsize::byte", "BitSizes.Byte");
            Replace("triton::bitsize::word", "BitSizes.Word");
            Replace("triton::bitsize::dword", "BitSizes.Dword");
            Replace("triton::bitsize::qword", "BitSizes.Qword");
            Replace("triton::bitsize::fword", "BitSizes.Fword");
            Replace("triton::bitsize::dqword", "BitSizes.Dqword");
            Replace("triton::bitsize::qqword", "BitSizes.Qqword");
            Replace("triton::bitsize::dqqword", "BitSizes.Dqqword");

            // Convert all triton byte sizes to C#.
            Replace("triton::size::byte", "ByteSizes.Byte");
            Replace("triton::size::word", "ByteSizes.Word");
            Replace("triton::size::dword", "ByteSizes.Dword");
            Replace("triton::size::qword", "ByteSizes.Qword");
            Replace("triton::size::fword", "ByteSizes.Fword");
            Replace("triton::size::dqword", "ByteSizes.Dqword");
            Replace("triton::size::qqword", "ByteSizes.Qqword");
            Replace("triton::size::dqqword", "ByteSizes.Dqqword");
            Replace("triton::size::max_supported", "ByteSizes.MaxSupported");

            // Convert integers back to C# equivalents
            Replace("triton::uint64", "UInt64");
            Replace("triton::uint32", "uint");
            Replace("uint32", "uint");
        }

        private void ReplaceType(string oldValue, string newValue)
        {
            List<string> outLines = new List<string>();
            foreach (var line in lines)
            {
                // Skip if old value is not present.
                if (!line.Contains(oldValue))
                {
                    outLines.Add(line);
                }

                // Convert instantiations to a .NET equivalent.
                else if ((!line.Contains("void") && !line.Contains("bool") && !line.Contains("UInt64")) && (line.Contains(" = " + oldValue) || line.Contains("(" + oldValue)))
                {
                    outLines.Add(line.Replace(oldValue, "new " + newValue));
                }

                // Otherwise, replace normally.
                else
                {
                    outLines.Add(line.Replace(oldValue, newValue));
                }
            }

            lines = outLines;
        }
    }
}