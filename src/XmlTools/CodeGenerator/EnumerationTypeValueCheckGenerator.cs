using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public static class EnumerationTypeValueCheckGenerator
    {
        public static void GenerateEnumerationValueCheckingCode(List<string> enumerationValues, StringBuilder stringBuilder, string elementVariableName)
        {
            GenerateValidatorForEnumerationValues(enumerationValues, stringBuilder, elementVariableName);
            stringBuilder.AppendLine("else");
            using (new CodeGeneratorBlockWrapper(stringBuilder))
            {
                stringBuilder.AppendLine($"{elementVariableName}.Remove();");
            }
        }

        private static void GenerateValidatorForEnumerationValues(List<string> enumerationValues, StringBuilder stringBuilder, string elementVariableName)
        {
            var possibleValues = enumerationValues.OrderBy(v => v).ToList();
            for (var i = 0; i < possibleValues.Count; i++)
            {
                stringBuilder.AppendLine($"{(i == 0 ? "" : "else ")}if ({elementVariableName}.Value.Equals(\"{possibleValues[i]}\", StringComparison.OrdinalIgnoreCase))");
                using (new CodeGeneratorBlockWrapper(stringBuilder))
                {
                    GenerateValueCaseCorrector(possibleValues[i], stringBuilder, elementVariableName);
                }
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