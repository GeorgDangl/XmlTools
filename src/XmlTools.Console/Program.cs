using CommandLine.Text;
using System;
using System.IO;
using XmlTools.Merger;

namespace XmlTools.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsParser = new OptionsParser(args);
            if (optionsParser.IsValid)
            {
                System.Console.WriteLine(HeadingInfo.Default);
                System.Console.WriteLine(CopyrightInfo.Default);
                try
                {
                    if (optionsParser.Result.FlattenGroups)
                    {
                        FlattenGroups(optionsParser.Result);
                        System.Console.WriteLine("Flattened groups");
                    }
                    else if (optionsParser.Result.MergeSchema)
                    {
                        MergeSchema(optionsParser.Result);
                        System.Console.WriteLine("Merged schemas");
                    }
                    else
                    {
                        GenerateCode(optionsParser.Result);
                        System.Console.WriteLine("Finished code generation");
                    }
                }
                catch (Exception e)
                {
                    DisplayExceptionDetails(e);
                }
            }
        }

        private static void DisplayExceptionDetails(Exception e)
        {
            System.Console.Write(e.ToString());
            System.Console.WriteLine();
        }

        private static void GenerateCode(Options options)
        {
            var inputPath = Path.GetFullPath(options.InputFilePath);
            var outputPath = Path.GetFullPath(options.OutputFilePath);
            using (var inputFileStream = File.OpenRead(inputPath))
            {
                var schemaParser = new SchemaParser(inputFileStream);
                var schema = schemaParser.GetSchema();
                var codeGen = new CodeGenerator(schema, options.Namespace);
                var code = codeGen.GenerateCode();
                using (var outputFileStream = File.CreateText(outputPath))
                {
                    outputFileStream.Write(code);
                }
            }
        }

        private static void FlattenGroups(Options options)
        {
            var inputPath = Path.GetFullPath(options.InputFilePath);
            var outputPath = Path.GetFullPath(options.OutputFilePath);
            using (var inputFileStream = File.OpenRead(inputPath))
            {
                using (var flattenedStream = new GroupFlattener.Flattener(inputFileStream).FlattenGroups())
                {
                    using (var outputFileStream = File.Create(outputPath))
                    {
                        flattenedStream.CopyTo(outputFileStream);
                    }
                }
            }
        }

        private static void MergeSchema(Options options)
        {
            var inputPath = Path.GetFullPath(options.InputFilePath);
            var outputPath = Path.GetFullPath(options.OutputFilePath);
            using (var inputFileStream = File.OpenRead(inputPath))
            {
                Func<string, Stream> loadReference = reference =>
                {
                    var basePath = Path.GetDirectoryName(inputPath);
                    var fullPath = Path.Combine(basePath, reference);
                    return File.Open(fullPath, FileMode.Open);
                };

                var merger = new SimpleMerger(inputFileStream, loadReference);
                using (var mergedStream = merger.MergeSchemas())
                {
                    using (var outputFileStream = File.Create(outputPath))
                    {
                        mergedStream.CopyTo(outputFileStream);
                    }
                }
            }
        }
    }
}
