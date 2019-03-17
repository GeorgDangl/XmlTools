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
            _stringBuilder.AppendLine("// Replaces decimals in a XML file that are not correctly formatted according to the XML specification.");
            _stringBuilder.AppendLine("// Use case: Sometimes a decimal is given with thousands separators, e.g. \"1.000,00\" or \"1,000.00\". This will be");
            _stringBuilder.AppendLine("// transformed to \"1000,00\" or \"1000.00\" to comply with the XML decimal specification.");
            _stringBuilder.AppendLine("// The decimal separator (point or comma) is kept as-is, since regular Xml implementations handle that well.");
            _stringBuilder.AppendLine($"var elementDecimalValue = {CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value;");
            _stringBuilder.AppendLine("string commaSeparatedPattern = @\"^([0-9,]+[.]\\d*)$\";");
            _stringBuilder.AppendLine("string pointSeparatedPattern = @\"^([0-9.]+[,]\\d*)$\";");
            _stringBuilder.AppendLine("if (Regex.IsMatch(elementDecimalValue, commaSeparatedPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value = elementDecimalValue.Replace(\",\", string.Empty);");
            }
            _stringBuilder.AppendLine("else if (Regex.IsMatch(elementDecimalValue, pointSeparatedPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value = elementDecimalValue.Replace(\".\", string.Empty);");
            }

            _stringBuilder.AppendLine("else if (string.IsNullOrWhiteSpace(elementDecimalValue))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("// In cases where no actual value is specified for the numerical value, the element is removed");
                _stringBuilder.AppendLine("// to avoid parser errors downstream");
                _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Remove();");
            }
        }
    }
}
