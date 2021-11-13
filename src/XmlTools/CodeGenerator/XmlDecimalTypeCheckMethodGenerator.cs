using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlDecimalTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlDecimalTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlDecimalType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            GenerateCheckCode(CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME, true);
        }

        public void GenerateCheckMethodBodyForAttributeValue(string attributeVariableName)
        {
            GenerateCheckCode(attributeVariableName, false);
        }

        private void GenerateCheckCode(string attributeVariableName, bool checkForChildNodes)
        {
            _stringBuilder.AppendLine("// Replaces decimals in a XML file that are not correctly formatted according to the XML specification.");
            _stringBuilder.AppendLine("// Use case: Sometimes a decimal is given with thousands separators, e.g. \"1.000,00\" or \"1,000.00\". This will be");
            _stringBuilder.AppendLine("// transformed to \"1000,00\" or \"1000.00\" to comply with the XML decimal specification.");
            _stringBuilder.AppendLine("// The decimal separator (point or comma) is kept as-is, since regular Xml implementations handle that well.");
            _stringBuilder.AppendLine($"var elementDecimalValue = {attributeVariableName}.Value?.Trim();");
            if (checkForChildNodes)
            {
                // For non-simple types, we're also checking if there are child nodes
                _stringBuilder.AppendLine($"if ({attributeVariableName}.Nodes().Any(node => !(node is XText)))");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    _stringBuilder.AppendLine("// A decimal value should only have text nodes");
                    _stringBuilder.AppendLine("element.Remove();");
                    _stringBuilder.AppendLine("return;");
                }
            }
            _stringBuilder.AppendLine("// In case there are multiple points or commas adjacent to eachother");
            _stringBuilder.AppendLine(@"elementDecimalValue = Regex.Replace(elementDecimalValue, ""\\.+"", ""."");");
            _stringBuilder.AppendLine("elementDecimalValue = Regex.Replace(elementDecimalValue, \",+\", \",\");");
            _stringBuilder.AppendLine("string commaSeparatedPattern = @\"^(-?\\s*[0-9,]+[.]\\d*)$\";");
            _stringBuilder.AppendLine("string pointSeparatedPattern = @\"^(-?\\s*[0-9.]+[,]\\d*)$\";");
            _stringBuilder.AppendLine("string numericalPattern = @\"^(\\s*-?\\s*[0-9.,]+\\s*)$\";");
            _stringBuilder.AppendLine("if (Regex.IsMatch(elementDecimalValue, commaSeparatedPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"{attributeVariableName}.Value = elementDecimalValue.Replace(\",\", string.Empty);");
            }
            _stringBuilder.AppendLine("else if (Regex.IsMatch(elementDecimalValue, pointSeparatedPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"{attributeVariableName}.Value = elementDecimalValue.Replace(\".\", string.Empty);");
            }

            _stringBuilder.AppendLine("else if (string.IsNullOrWhiteSpace(elementDecimalValue))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("// In cases where no actual value is specified for the numerical value, the element is removed");
                _stringBuilder.AppendLine("// to avoid parser errors downstream");
                _stringBuilder.AppendLine($"{attributeVariableName}.Remove();");
            }
            _stringBuilder.AppendLine("else if (!Regex.IsMatch(elementDecimalValue, numericalPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("// When it's not numeric at all it should be removed");
                _stringBuilder.AppendLine($"{attributeVariableName}.Remove();");
            }
        }
    }
}
