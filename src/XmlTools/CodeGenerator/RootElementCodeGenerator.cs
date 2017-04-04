using System.Text;

namespace XmlTools.CodeGenerator
{
    public class RootElementCodeGenerator
    {
        public RootElementCodeGenerator(XmlSchema schema, StringBuilder stringBuilder)
        {
            _schema = schema;
            _stringBuilder = stringBuilder;
        }

        private readonly XmlSchema _schema;
        private readonly StringBuilder _stringBuilder;

        public void GenerateCheckingCode()
        {
            _stringBuilder.AppendLine("public XDocument CorrectDocument()");
            _stringBuilder.AppendLine("{");

            _stringBuilder.AppendLine("var rootElement = _document.Root;");

            _stringBuilder.AppendLine("switch (rootElement.Name.LocalName.ToUpperInvariant())");
            _stringBuilder.AppendLine("{");

            var rootElements = _schema.RootElements;
            foreach (var rootElement in rootElements)
            {
                _stringBuilder.AppendLine($"case \"{rootElement.Name.ToUpperInvariant()}\":");
                XmlElementNameCorrectorCodeGenerator.GenerateElementNameCorrector(rootElement, _stringBuilder, "rootElement");
                var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(rootElement.Type);
                _stringBuilder.AppendLine($"{elementCheckMethodName}(rootElement);");

                _stringBuilder.AppendLine("break;");
            }

            _stringBuilder.AppendLine("}");
            _stringBuilder.AppendLine("return _document;");
            _stringBuilder.AppendLine("}");
        }
    }
}