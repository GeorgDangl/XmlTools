using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlIntegerTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlIntegerTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlIntegerType);
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
            _stringBuilder.AppendLine("// Replaces integers in a XML file that are not correctly formatted according to the XML specification.");
            _stringBuilder.AppendLine("// Use case: Sometimes a integer is given with thousands separators, e.g. \"1.000\" or \"1,000\". This will be");
            _stringBuilder.AppendLine("// transformed to \"1000\" to comply with the XML decimal specification.");
            _stringBuilder.AppendLine($"var elementIntegerValue = {attributeVariableName}.Value?.Trim();");
            if (checkForChildNodes)
            {
                // For non-simple types, we're also checking if there are child nodes
                _stringBuilder.AppendLine($"if ({attributeVariableName}.Nodes().Any(node => !(node is XText)))");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    _stringBuilder.AppendLine("// An integer value should only have text nodes");
                    _stringBuilder.AppendLine("element.Remove();");
                    _stringBuilder.AppendLine("return;");
                }
            }

            _stringBuilder.AppendLine("string numericalPattern = @\"^(\\s*-?\\s*[0-9]+\\s*)$\";");
            _stringBuilder.AppendLine("if (string.IsNullOrWhiteSpace(elementIntegerValue))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("// In cases where no actual value is specified for the numerical value, the element is removed");
                _stringBuilder.AppendLine("// to avoid parser errors downstream");
                _stringBuilder.AppendLine($"{attributeVariableName}.Remove();");
            }
            _stringBuilder.AppendLine("else if (!Regex.IsMatch(elementIntegerValue, numericalPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("// When it's not numeric at all it should be removed");
                _stringBuilder.AppendLine($"{attributeVariableName}.Remove();");
            }
        }
    }
}
