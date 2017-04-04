using System.Text;

namespace XmlTools.CodeGenerator
{
    // TODO RENAME - ELEMENT AND ATTRIBUTES
    public static class XmlElementNameCorrectorCodeGenerator
    {
        public static void GenerateElementNameCorrector(XmlElement element, StringBuilder stringBuilder, string elementVariable)
        {
            stringBuilder.AppendLine($"if ({elementVariable}.Name.LocalName != \"{element.Name}\")");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"{elementVariable}.Name = {elementVariable}.Name.Namespace + \"{element.Name}\";");
            stringBuilder.AppendLine("}");
        }

        public static void GenerateAttributeNameCorrector(XmlAttribute attribute, StringBuilder stringBuilder, string attributeVariable)
        {
            stringBuilder.AppendLine($"if ({attributeVariable}.Name.LocalName != \"{attribute.Name}\")");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"{attributeVariable}.Remove();");
            stringBuilder.AppendLine($"{attributeVariable}.Parent.SetAttributeValue({attributeVariable}.Name.Namespace + \"{attribute.Name}\", {attributeVariable}.Value);");
            stringBuilder.AppendLine("}");
        }
    }
}