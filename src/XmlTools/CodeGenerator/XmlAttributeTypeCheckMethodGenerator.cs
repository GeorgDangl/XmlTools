using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlAttributeTypeCheckMethodGenerator
    {
        public XmlAttributeTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public void GenerateTypeCheckingMethod(XmlType xmlType)
        {
            var checkMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForAttributeCheckMethod(xmlType);
            _stringBuilder.AppendLine($"private void {checkMethodName}(XAttribute attribute)");
            _stringBuilder.AppendLine("{");
            // TODO
            var enumerationType = xmlType as XmlEnumerationType;
            if (enumerationType != null)
            {
                GenerateEnumerationAttributeCheckMethod(enumerationType);
            }
            _stringBuilder.AppendLine("}");
        }

        private void GenerateEnumerationAttributeCheckMethod(XmlEnumerationType xmlEnumerationType)
        {
            _stringBuilder.AppendLine("switch (attribute.Value.ToUpperInvariant())");
            _stringBuilder.AppendLine("{");
            foreach (var allowedValue in xmlEnumerationType.EnumerationValues)
            {
                _stringBuilder.AppendLine($"case \"{allowedValue.ToUpperInvariant()}\":");
                _stringBuilder.AppendLine($"if (attribute.Value != \"{allowedValue}\")");
                _stringBuilder.AppendLine("{");
                _stringBuilder.AppendLine($"attribute.Value = \"{allowedValue}\";");
                _stringBuilder.AppendLine("}");
                _stringBuilder.AppendLine("break;");
            }
            _stringBuilder.AppendLine("default:");
            _stringBuilder.AppendLine("attribute.Remove();");
                _stringBuilder.AppendLine("break;");
            _stringBuilder.AppendLine("}");
        }
    }
}