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
            EnumerationTypeValueCheckGenerator.GenerateEnumerationValueCheckingCode(xmlEnumerationType.EnumerationValues, _stringBuilder, ATTRIBUTE_VARIABLE_NAME);
        }
    }
}