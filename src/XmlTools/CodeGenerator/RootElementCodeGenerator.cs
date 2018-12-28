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
                GenerateRootElementValidation(_schema.RootElements);
                _stringBuilder.AppendLine($"return {CodeGeneratorConstants.PRIVATE_XDOCUMENT_FIELD_NAME};");
            }
        }

        private void GenerateRootElementValidation(List<XmlElement> rootElements)
        {
            for (var i = 0; i < rootElements.Count; i++)
            {
                var rootElement = rootElements[i];
                _stringBuilder.AppendLine($"{(i == 0 ? "" : "else ")}if ({ROOT_ELEMENT_VARIABLE_NAME}.Name.LocalName.Equals(\"{rootElement.Name}\", StringComparison.OrdinalIgnoreCase))");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    XmlElementNameCorrectorCodeGenerator.GenerateElementNameCorrector(rootElement, _stringBuilder, ROOT_ELEMENT_VARIABLE_NAME);
                    var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(rootElement.Type);
                    _stringBuilder.AppendLine($"{elementCheckMethodName}({ROOT_ELEMENT_VARIABLE_NAME});");
                }
            }
        }
    }
}