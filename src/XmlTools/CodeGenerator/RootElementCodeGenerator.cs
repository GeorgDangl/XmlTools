using System.Collections.Generic;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class RootElementCodeGenerator
    {
        private const string ROOT_ELEMENT_VARIABLE_NAME = "rootElement";

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
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine($"var {ROOT_ELEMENT_VARIABLE_NAME} = {CodeGeneratorConstants.PRIVATE_XDOCUMENT_FIELD_NAME}.Root;");
                _stringBuilder.AppendLine($"switch ({ROOT_ELEMENT_VARIABLE_NAME}.Name.LocalName.ToUpperInvariant())");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    var rootElements = _schema.RootElements;
                    GenerateRootElementValidation(rootElements);
                }
                _stringBuilder.AppendLine($"return {CodeGeneratorConstants.PRIVATE_XDOCUMENT_FIELD_NAME};");
            }
        }

        private void GenerateRootElementValidation(List<XmlElement> rootElements)
        {
            foreach (var rootElement in rootElements)
            {
                _stringBuilder.AppendLine($"case \"{rootElement.Name.ToUpperInvariant()}\":");
                XmlElementNameCorrectorCodeGenerator.GenerateElementNameCorrector(rootElement, _stringBuilder, ROOT_ELEMENT_VARIABLE_NAME);
                var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(rootElement.Type);
                _stringBuilder.AppendLine($"{elementCheckMethodName}({ROOT_ELEMENT_VARIABLE_NAME});");
                _stringBuilder.AppendLine("break;");
            }
        }
    }
}