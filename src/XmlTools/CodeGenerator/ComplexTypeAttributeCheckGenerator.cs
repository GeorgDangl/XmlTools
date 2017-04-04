using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public static class ComplexTypeAttributeCheckGenerator
    {
        public static void GenerateAttributesCheckingCode(XmlTypeWithAttributes xmlType, StringBuilder stringBuilder)
        {
            if (!xmlType.Attributes.Any())
            {
                return;
            }
            stringBuilder.AppendLine($"foreach (var {CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME} in {CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Attributes().ToList())");
            using (new CodeGeneratorBlockWrapper(stringBuilder))
            {
                stringBuilder.AppendLine($"switch({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME}.Name.LocalName.ToUpperInvariant())");
                using (new CodeGeneratorBlockWrapper(stringBuilder))
                {
                    foreach (var attribute in xmlType.Attributes)
                    {
                        stringBuilder.AppendLine($"case \"{attribute.Name.ToUpperInvariant()}\":");
                        var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForAttributeCheckMethod(attribute.Type);
                        stringBuilder.AppendLine($"{elementCheckMethodName}({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME});");
                        XmlElementNameCorrectorCodeGenerator.GenerateAttributeNameCorrector(attribute, stringBuilder, CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME);
                        stringBuilder.AppendLine("break;");
                    }
                }
            }
        }
    }
}