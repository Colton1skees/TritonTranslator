using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch.X86;
using TritonTranslator.Conversion;

namespace TritonTranslator.Examples
{
    public class PerformanceBenchmark
    {
        private static readonly ulong exampleCodeRIP = 0x00007FFAC46ACDA4;

        private static readonly byte[] exampleCode =
        {
            0x48, 0x89, 0x5C, 0x24, 0x10, 0x48, 0x89, 0x74, 0x24, 0x18, 0x55, 0x57, 0x41, 0x56, 0x48, 0x8D,
            0xAC, 0x24, 0x00, 0xFF, 0xFF, 0xFF, 0x48, 0x81, 0xEC, 0x00, 0x02, 0x00, 0x00, 0x48, 0x8B, 0x05,
            0x18, 0x57, 0x0A, 0x00, 0x48, 0x33, 0xC4, 0x48, 0x89, 0x85, 0xF0, 0x00, 0x00, 0x00, 0x4C, 0x8B,
            0x05, 0x2F, 0x24, 0x0A, 0x00, 0x48, 0x8D, 0x05, 0x78, 0x7C, 0x04, 0x00, 0x33, 0xFF
        };

        private readonly X86CpuArchitecture arch = new(Arch.ArchitectureId.ARCH_X86_64);

        private readonly X86Translator lifter;

        private readonly AstToIntermediateConverter converter;

        public PerformanceBenchmark()
        {
            lifter = new X86Translator(arch);
            converter = new AstToIntermediateConverter(arch);
        }

        public void Execute()
        {
            // Disassemble all instructions.
            var codeBytes = exampleCode;
            var codeReader = new Iced.Intel.ByteArrayCodeReader(codeBytes);
            var decoder = Iced.Intel.Decoder.Create(64, codeReader);
            decoder.IP = exampleCodeRIP;
            ulong endRip = decoder.IP + (uint)codeBytes.Length;
            var instructions = new List<Iced.Intel.Instruction>();
            while (decoder.IP < endRip)
                instructions.Add(decoder.Decode());

            var sw = Stopwatch.StartNew();
            int limit = 100000;
            int total = 0;
            for (int count = 0; count < limit; count++)
            {
                foreach (var instruction in instructions)
                {
                    total++;
                    var liftedInstruction = arch.Disassembly(instruction);
                    var symbolicExpression = lifter.TranslateInstruction(liftedInstruction);
                }
            }

            sw.Stop();
            Console.WriteLine($"Took {sw.ElapsedMilliseconds}ms to lift {limit * instructions.Count} instructions.");
        }
    }
}
