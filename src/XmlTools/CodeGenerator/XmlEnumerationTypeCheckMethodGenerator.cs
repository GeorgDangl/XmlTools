using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlEnumerationTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlEnumerationTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlEnumerationType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            var xmlEnumerationType = xmlType as XmlEnumerationType;
            if (xmlEnumerationType == null)
            {
                throw new System.InvalidOperationException($"This class can only generate check methods for {nameof(XmlEnumerationType)} types");
            }
            _stringBuilder.AppendLine($"switch ({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value.ToUpperInvariant())");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                GenerateValidatorForEnumerationValues(xmlEnumerationType);
                _stringBuilder.AppendLine("default:");
                _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Remove();");
                _stringBuilder.AppendLine("break;");
            }
        }

        private void GenerateValidatorForEnumerationValues(XmlEnumerationType xmlEnumerationType)
        {
            foreach (var possibleValue in xmlEnumerationType.EnumerationValues.OrderBy(v => v))
            {
                _stringBuilder.AppendLine($"case \"{possibleValue.ToUpperInvariant()}\":");
                GenerateValueCaseCorrector(possibleValue);
                _stringBuilder.AppendLine("break;");
            }
        }

        private void GenerateValueCaseCorrector(string correctValue)
        {
            _stringBuilder.AppendLine($"if ({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value != \"{correctValue}\")");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value = \"{correctValue}\";");
            }
        }
    }
}