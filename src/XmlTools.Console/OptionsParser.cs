﻿using CommandLine;

namespace XmlTools.Console
{
    public class OptionsParser
    {
        public OptionsParser(string[] commandLineArguments)
        {
            _commandLineArguments = commandLineArguments;
            ParseOptions();
        }

        private readonly string[] _commandLineArguments;
        public bool IsValid { get; private set; }
        public Options Result { get; private set; }

        private void ParseOptions()
        {
            var parsedOptions = CommandLine.Parser.Default.ParseArguments<Options>(_commandLineArguments);
            var parserResult = parsedOptions as Parsed<Options>;
            if (parserResult != null)
            {
                IsValid = true;
                Result = parserResult.Value;
            }
        }
    }
}