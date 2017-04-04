using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlComplexTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        private const string CHILD_ELEMENT_VARIABLE_NAME = "child";

        public XmlComplexTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlComplexType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            var xmlComplexType = xmlType as XmlComplexType;
            ComplexTypeAttributeCheckGenerator.GenerateAttributesCheckingCode(xmlComplexType, _stringBuilder);
            GenerateElementsCheckingCode(xmlComplexType);
        }

        private void GenerateElementsCheckingCode(XmlComplexType xmlType)
        {
            if (!xmlType.PossibleChildElements.Any())
            {
                return;
            }
            _stringBuilder.AppendLine($"foreach (var {CHILD_ELEMENT_VARIABLE_NAME} in {CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Elements().ToList())");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"switch({CHILD_ELEMENT_VARIABLE_NAME}.Name.LocalName.ToUpperInvariant())");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    foreach (var element in xmlType.PossibleChildElements)
                    {
                        _stringBuilder.AppendLine($"case \"{element.Name.ToUpperInvariant()}\":");
                        XmlElementNameCorrectorCodeGenerator.GenerateElementNameCorrector(element, _stringBuilder, CHILD_ELEMENT_VARIABLE_NAME);
                        var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(element.Type);
                        _stringBuilder.AppendLine($"{elementCheckMethodName}({CHILD_ELEMENT_VARIABLE_NAME});");
                        _stringBuilder.AppendLine("break;");
                    }
                }
            }
        }
    }
}