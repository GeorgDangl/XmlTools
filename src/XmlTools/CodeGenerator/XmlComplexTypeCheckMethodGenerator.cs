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
                for (var i = 0; i < xmlType.PossibleChildElements.Count; i++)
                {
                    var element = xmlType.PossibleChildElements[i];

                    _stringBuilder.AppendLine($"{(i == 0 ? "" : "else ")}if ({CHILD_ELEMENT_VARIABLE_NAME}.Name.LocalName.Equals(\"{element.Name}\", StringComparison.OrdinalIgnoreCase))");
                    using (new CodeGeneratorBlockWrapper(_stringBuilder))
                    {
                        XmlElementNameCorrectorCodeGenerator.GenerateElementNameCorrector(element, _stringBuilder, CHILD_ELEMENT_VARIABLE_NAME);
                        var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(element.Type);
                        _stringBuilder.AppendLine($"{elementCheckMethodName}({CHILD_ELEMENT_VARIABLE_NAME});");
                    }
                }
            }
        }
    }
}