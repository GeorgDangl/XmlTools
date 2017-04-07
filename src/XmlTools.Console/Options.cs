using CommandLine;

namespace XmlTools.Console
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Relative or absolute path to an Xml schema file")]
        public string InputFilePath { get; set; }

        [Option('o', "output", Required = true, HelpText = "Relative or absolute path to the output code file")]
        public string OutputFilePath { get; set; }

        [Option('n', "namespace", Required = true, HelpText = "Namespace for the generated class")]
        public string Namespace { get; set; }
    }
}