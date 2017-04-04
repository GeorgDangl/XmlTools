using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlUnknownTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlUnknownTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlUnknownType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            _stringBuilder.AppendLine($"// The Xml type \"{xmlType.Name}\" could not be analyzed, no checks can be made.");
            _stringBuilder.AppendLine("// This might be the case for externally referenced types.");
        }
    }
}