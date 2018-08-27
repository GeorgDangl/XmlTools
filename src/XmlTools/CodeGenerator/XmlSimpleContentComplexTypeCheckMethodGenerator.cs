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
            ComplexTypeAttributeCheckGenerator.GenerateAttributesCheckingCode(xmlSimpleContentComplexType, _stringBuilder);
        }
    }
}
