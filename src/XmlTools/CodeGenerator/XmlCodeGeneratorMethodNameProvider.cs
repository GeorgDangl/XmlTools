namespace XmlTools.CodeGenerator
{
    public class XmlCodeGeneratorMethodNameProvider
    {
        public static string GetNameForElementTypeCheckMethod(XmlType xmlType)
        {
            var friendlyTypeName = TypeNameClassTranslator.GetFriendlyTypeName(xmlType);
            return $"CheckElementType_{friendlyTypeName}";
        }

        public static string GetNameForAttributeCheckMethod(XmlType xmlType)
        {
            var friendlyTypeName = TypeNameClassTranslator.GetFriendlyTypeName(xmlType);
            return $"CheckAttributeType_{friendlyTypeName}";
        }
    }
}