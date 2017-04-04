using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlAttributeTypeCheckMethodGenerator
    {
        private const string ATTRIBUTE_VARIABLE_NAME = "attribute";

        public XmlAttributeTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public void GenerateTypeCheckingMethod(XmlType xmlType)
        {
            var checkMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForAttributeCheckMethod(xmlType);
            _stringBuilder.AppendLine($"private void {checkMethodName}(XAttribute {ATTRIBUTE_VARIABLE_NAME})");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                var enumerationType = xmlType as XmlEnumerationType;
                if (enumerationType != null)
                {
                    GenerateEnumerationAttributeCheckMethod(enumerationType);
                }
                else
                {
                    _stringBuilder.AppendLine("// Only attributes with enumeration restriction are currently supported for validation");
                }
            }
        }

        private void GenerateEnumerationAttributeCheckMethod(XmlEnumerationType xmlEnumerationType)
        {
            _stringBuilder.AppendLine($"switch ({ATTRIBUTE_VARIABLE_NAME}.Value.ToUpperInvariant())");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                foreach (var allowedValue in xmlEnumerationType.EnumerationValues)
                {
                    _stringBuilder.AppendLine($"case \"{allowedValue.ToUpperInvariant()}\":");
                    _stringBuilder.AppendLine($"if ({ATTRIBUTE_VARIABLE_NAME}.Value != \"{allowedValue}\")");
                    using (new CodeGeneratorBlockWrapper(_stringBuilder))
                    {
                        _stringBuilder.AppendLine($"{ATTRIBUTE_VARIABLE_NAME}.Value = \"{allowedValue}\";");
                    }
                    _stringBuilder.AppendLine("break;");
                }
                _stringBuilder.AppendLine("default:");
                _stringBuilder.AppendLine($"{ATTRIBUTE_VARIABLE_NAME}.Remove();");
                _stringBuilder.AppendLine("break;");
            }
        }
    }
}