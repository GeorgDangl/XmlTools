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
            _stringBuilder.AppendLine("// Simple types should only have elements");
            _stringBuilder.AppendLine($"if ({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.HasElements)");
            _stringBuilder.AppendLine("{");
            _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Remove();");
            _stringBuilder.AppendLine("}");
        }
    }
}