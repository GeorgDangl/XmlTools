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
                for (var i = 0; i < xmlType.Attributes.Count; i++)
                {
                    var attribute = xmlType.Attributes[i];
                    stringBuilder.AppendLine($"{(i == 0 ? "" : "else ")}if ({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME}.Name.LocalName.Equals(\"{attribute.Name}\", StringComparison.OrdinalIgnoreCase))");
                    using (new CodeGeneratorBlockWrapper(stringBuilder))
                    {
                        var elementCheckMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForAttributeCheckMethod(attribute.Type);
                        stringBuilder.AppendLine($"{elementCheckMethodName}({CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME});");
                        XmlElementNameCorrectorCodeGenerator.GenerateAttributeNameCorrector(attribute, stringBuilder, CodeGeneratorConstants.ELEMENT_CHECK_METHOD_CHILD_ATTRIBUTE_VARIABLE_NAME);
                    }
                }
            }
        }
    }
}