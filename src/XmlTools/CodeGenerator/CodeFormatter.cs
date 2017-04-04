using System.Text;
using System.Text.RegularExpressions;

namespace XmlTools.CodeGenerator
{
    public static class CodeFormatter
    {
        public static string IndentCode(string codeFile)
        {
            var codeLines = Regex.Split(codeFile, "\r\n?|\n");
            var currentIndention = 0;
            var stringBuilder = new StringBuilder();
            foreach (var line in codeLines)
            {
                if (line.Trim() == "{")
                {
                    stringBuilder.AppendLine(new string(' ', currentIndention * 4) + line);
                    currentIndention++;
                }
                else if (line.Trim() == "}")
                {
                    currentIndention--;
                    stringBuilder.AppendLine(new string(' ', currentIndention * 4) + line);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        stringBuilder.AppendLine();
                    }
                    else
                    {
                        stringBuilder.AppendLine(new string(' ', currentIndention * 4) + line);
                    }
                }
            }
            return stringBuilder.ToString().Replace("\t", "    "); // Replacing tabstops with 4 spaces
        }
    }
}
