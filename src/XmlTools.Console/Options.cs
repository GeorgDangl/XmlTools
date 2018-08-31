using CommandLine;
using System.Collections.Generic;

namespace XmlTools.Console
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Relative or absolute path to an Xml schema file")]
        public string InputFilePath { get; set; }

        [Option('o', "output", Required = true, HelpText = "Relative or absolute path to the output code file")]
        public string OutputFilePath { get; set; }

        [Option('n', "namespace", Required = false, HelpText = "Namespace for the generated class")]
        public string Namespace { get; set; }

        [Option('f', "flatten", Required = false, HelpText = "If enabled, groups will be flattened")]
        public bool FlattenGroups { get; set; }

        [Option('s', "specific-groups", Separator = ';', Required = false, HelpText = "If specified in combination with the 'flatten' option, only groups with the given names will be flattened")]
        public string[] SpecificGroupNamesToFlatten { get; set; }

        [Option('m', "merge", Required = false, HelpText = "If enabled, the schema will be merged")]
        public bool MergeSchema { get; set; }
    }
}
