using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlSimpleContentComplexTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlSimpleContentComplexTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlSimpleContentComplexType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            var xmlSimpleContentComplexType = xmlType as XmlSimpleContentComplexType;
            GenerateAttributesCheckingCode(xmlSimpleContentComplexType);
        }

        private void GenerateAttributesCheckingCode(XmlSimpleContentComplexType xmlType)
        {
            if (!xmlType.Attributes.Any())
            {
                return;
            }
            _stringBuilder.AppendLine($"foreach (var attribute in element.Attributes().ToList())");
            _stringBuilder.AppendLine("{");
            _stringBuilder.AppendLine($"switch(attribute.Name.LocalName.ToUpperInvariant())");
            _stringBuilder.AppendLine("{");
            foreach (var attribute in xmlType.Attributes)
            {
                // TODO CHECK CASING OF ATTRIBUTE NAME
                _stringBuilder.AppendLine($"case \"{attribute.Name.ToUpperInvariant()}\":");
                var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForAttributeCheckMethod(attribute.Type);
                _stringBuilder.AppendLine($"{elementCheckMethodName}(attribute);");
                XmlElementNameCorrectorCodeGenerator.GenerateAttributeNameCorrector(attribute, _stringBuilder, "attribute");
                _stringBuilder.AppendLine($"break;");

            }
            _stringBuilder.AppendLine("}");
            _stringBuilder.AppendLine("}");
        }
    }
}