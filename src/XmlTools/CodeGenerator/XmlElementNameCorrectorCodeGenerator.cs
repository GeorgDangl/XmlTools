using System.Text;

namespace XmlTools.CodeGenerator
{
    public static class XmlElementNameCorrectorCodeGenerator
    {
        public static void GenerateElementNameCorrector(XmlElement element, StringBuilder stringBuilder, string elementVariable)
        {
            stringBuilder.AppendLine($"if ({elementVariable}.Name.LocalName != \"{element.Name}\")");
            using (new CodeGeneratorBlockWrapper(stringBuilder))
            {
                stringBuilder.AppendLine($"{elementVariable}.Name = {elementVariable}.Name.Namespace + \"{element.Name}\";");
            }
        }

        public static void GenerateAttributeNameCorrector(XmlAttribute attribute, StringBuilder stringBuilder, string attributeVariable)
        {
            stringBuilder.AppendLine($"if ({attributeVariable}.Name.LocalName != \"{attribute.Name}\")");
            using (new CodeGeneratorBlockWrapper(stringBuilder))
            {
                stringBuilder.AppendLine($"{attributeVariable}.Remove();");
                stringBuilder.AppendLine($"{attributeVariable}.Parent.SetAttributeValue({attributeVariable}.Name.Namespace + \"{attribute.Name}\", {attributeVariable}.Value);");
            }
        }
    }
}