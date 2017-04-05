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
            EnumerationTypeValueCheckGenerator.GenerateEnumerationValueCheckingCode(xmlEnumerationType.EnumerationValues, _stringBuilder, CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME);
        }
    }
}