using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public static class EnumerationTypeValueCheckGenerator
    {
        public static void GenerateEnumerationValueCheckingCode(List<string> enumerationValues, StringBuilder stringBuilder, string elementVariableName)
        {
            stringBuilder.AppendLine($"switch ({elementVariableName}.Value.ToUpperInvariant())");
            using (new CodeGeneratorBlockWrapper(stringBuilder))
            {
                GenerateValidatorForEnumerationValues(enumerationValues, stringBuilder, elementVariableName);
                stringBuilder.AppendLine("default:");
                stringBuilder.AppendLine($"{elementVariableName}.Remove();");
                stringBuilder.AppendLine("break;");
            }
        }

        private static void GenerateValidatorForEnumerationValues(List<string> enumerationValues, StringBuilder stringBuilder, string elementVariableName)
        {
            foreach (var possibleValue in enumerationValues.OrderBy(v => v))
            {
                stringBuilder.AppendLine($"case \"{possibleValue.ToUpperInvariant()}\":");
                GenerateValueCaseCorrector(possibleValue, stringBuilder, elementVariableName);
                stringBuilder.AppendLine("break;");
            }
        }

        private static void GenerateValueCaseCorrector(string correctValue, StringBuilder stringBuilder, string elementVariableName)
        {
            stringBuilder.AppendLine($"if ({elementVariableName}.Value != \"{correctValue}\")");
            using (new CodeGeneratorBlockWrapper(stringBuilder))
            {
                stringBuilder.AppendLine($"{elementVariableName}.Value = \"{correctValue}\";");
            }
        }
    }
}