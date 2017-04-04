using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlComplexTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
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
            GenerateAttributesCheckingCode(xmlComplexType);
            GenerateElementsCheckingCode(xmlComplexType);
        }

        private void GenerateElementsCheckingCode(XmlComplexType xmlType)
        {
            if (!xmlType.PossibleChildElements.Any())
            {
                return;
            }
            _stringBuilder.AppendLine("foreach (var child in element.Elements().ToList())");
            _stringBuilder.AppendLine("{");
            _stringBuilder.AppendLine("switch(child.Name.LocalName.ToUpperInvariant())");
            _stringBuilder.AppendLine("{");
            foreach (var element in xmlType.PossibleChildElements)
            {
                // TODO CHECK CASING OF ELEMENT NAME
                _stringBuilder.AppendLine($"case \"{element.Name.ToUpperInvariant()}\":");
                XmlElementNameCorrectorCodeGenerator.GenerateElementNameCorrector(element, _stringBuilder, "child");
                var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(element.Type);
                _stringBuilder.AppendLine($"{elementCheckMethodName}(child);");
                _stringBuilder.AppendLine("break;");
            }
            _stringBuilder.AppendLine("}");
            _stringBuilder.AppendLine("}");
        }

        private void GenerateAttributesCheckingCode(XmlComplexType xmlType)
        {
            if (!xmlType.Attributes.Any())
            {
                return;
            }
            _stringBuilder.AppendLine("foreach (var attribute in element.Attributes().ToList())");
            _stringBuilder.AppendLine("{");
            _stringBuilder.AppendLine("switch(attribute.Name.LocalName.ToUpperInvariant())");
            _stringBuilder.AppendLine("{");
            foreach (var attribute in xmlType.Attributes)
            {
                // TODO CHECK CASING OF ATTRIBUTE NAME
                _stringBuilder.AppendLine($"case \"{attribute.Name.ToUpperInvariant()}\":");
                var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForAttributeCheckMethod(attribute.Type);
                _stringBuilder.AppendLine($"{elementCheckMethodName}(attribute);");
                XmlElementNameCorrectorCodeGenerator.GenerateAttributeNameCorrector(attribute, _stringBuilder, "attribute");
                _stringBuilder.AppendLine("break;");

            }
            _stringBuilder.AppendLine("}");
            _stringBuilder.AppendLine("}");
        }
    }
}