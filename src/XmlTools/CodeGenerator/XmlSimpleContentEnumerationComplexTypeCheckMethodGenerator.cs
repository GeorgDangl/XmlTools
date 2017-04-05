using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlSimpleContentEnumerationComplexTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlSimpleContentEnumerationComplexTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlSimpleContentEnumerationComplexType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            var xmlEnumerationType = xmlType as XmlSimpleContentEnumerationComplexType;
            if (xmlEnumerationType == null)
            {
                throw new System.InvalidOperationException($"This class can only generate check methods for {nameof(XmlSimpleContentEnumerationComplexType)} types");
            }
            ComplexTypeAttributeCheckGenerator.GenerateAttributesCheckingCode(xmlEnumerationType, _stringBuilder);
            EnumerationTypeValueCheckGenerator.GenerateEnumerationValueCheckingCode(xmlEnumerationType.EnumerationValues, _stringBuilder, CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME);
        }
    }
}