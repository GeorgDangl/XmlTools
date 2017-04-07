using System;
using System.IO;
using CommandLine.Text;

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
                    GenerateCode(optionsParser.Result);
                    System.Console.WriteLine("Finished code generation");
                }
                catch (Exception e)
                {
                    DisplayExceptionDetails(e);
                }
            }
            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
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
    }
}
