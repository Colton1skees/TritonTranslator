using TritonTranslator.Arch;
using TritonTranslator.Arch.X86;
using TritonTranslator.Conversion;

// Initialize data to disassemble.
const ulong exampleCodeRIP = 0x00007FFAC46ACDA4;
byte[] exampleCode = new byte[] {
        0x48, 0x89, 0x5C, 0x24, 0x10, 0x48, 0x89, 0x74, 0x24, 0x18, 0x55, 0x57, 0x41, 0x56, 0x48, 0x8D,
        0xAC, 0x24, 0x00, 0xFF, 0xFF, 0xFF, 0x48, 0x81, 0xEC, 0x00, 0x02, 0x00, 0x00, 0x48, 0x8B, 0x05,
        0x18, 0x57, 0x0A, 0x00, 0x48, 0x33, 0xC4, 0x48, 0x89, 0x85, 0xF0, 0x00, 0x00, 0x00, 0x4C, 0x8B,
        0x05, 0x2F, 0x24, 0x0A, 0x00, 0x48, 0x8D, 0x05, 0x78, 0x7C, 0x04, 0x00, 0x33, 0xFF
    };

// Disassemble all instructions.
var codeBytes = exampleCode;
var codeReader = new Iced.Intel.ByteArrayCodeReader(codeBytes);
var decoder = Iced.Intel.Decoder.Create(64, codeReader);
decoder.IP = exampleCodeRIP;
ulong endRip = decoder.IP + (uint)codeBytes.Length;
var instructions = new List<Iced.Intel.Instruction>();
while (decoder.IP < endRip)
    instructions.Add(decoder.Decode());

// Initialize IR translator
var arch = new X86CpuArchitecture(ArchitectureId.ARCH_X86_64);
var lifter = new X86Translator(arch);

// Traverse all disassembled instructions.
bool printAst = false;
foreach(var instruction in instructions)
{
    Console.WriteLine("Instruction {0}:", instruction);

    // Lift the instruction to our intermediate representation.
    var liftedInstruction = arch.Disassembly(instruction);
    var symbolicExpression = lifter.TranslateInstruction(liftedInstruction);

    var converter = new AstToIntermediateConverter(arch);

    // Dump all lifted expressions.
    foreach (var expr in symbolicExpression)
    {
        // Print the AST form.
        if (printAst)
        {
            Console.WriteLine("AST form:");
            Console.WriteLine("    {0} = {1}", expr.Destination == null ? "NIL" : expr.Destination, expr.Source);
            Console.WriteLine("");
        }

        Console.WriteLine("Flat IR form:");
        var converts = converter.ConvertFromSymbolicExpression(expr);
        foreach (var convert in converts)
        {
            Console.WriteLine("    " + convert);
        }
    }

    Console.WriteLine("------------------------");
}