// Load Triton's x86semantics.cpp file.
using Triton.Converter;

var lines = File.ReadAllLines("x86semantics.cpp").ToList();

// Preprocess it.
var preprocessor = new SemanticPreprocessor(lines);

var output = preprocessor.Output;
File.WriteAllLines("output.cs", output);

Console.WriteLine("Processed.");
Console.ReadLine();