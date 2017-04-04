using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlSimpleTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlSimpleTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlSimpleType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            _stringBuilder.AppendLine("// There's currently no implementations for correcting the content of an Xml simpleType");
        }
    }

}