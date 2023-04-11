// Load Triton's x86semantics.cpp file.
using SemanticExtractor.Parsing;
using Triton.Converter;

var lines = File.ReadAllLines("x86semantics.cpp").ToList();

var methodDefinitions = MethodExtractor.ExtractMethodDefinitions(lines);

foreach(var def in methodDefinitions)
{
    Console.WriteLine(MethodExtractor.GetMethodName(def[0]));
}

var target = methodDefinitions.Single(x => MethodExtractor.GetMethodName(x[0]) == "div_s");


var contents = string.Join(Environment.NewLine, target.ToArray());
Console.WriteLine(contents);
SemanticMethodParser.ParseMethod(contents);

/*
// Preprocess it.
var preprocessor = new SemanticPreprocessor(lines);

var output = preprocessor.Output;
File.WriteAllLines("output.cs", output);
*/

Console.WriteLine("Processed.");
Console.ReadLine();