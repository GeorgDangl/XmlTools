using System.Text.RegularExpressions;

namespace XmlTools.CodeGenerator
{
    public static class TypeNameClassTranslator
    {
        public static string GetFriendlyTypeName(XmlType xmlType)
        {
            if (string.IsNullOrWhiteSpace(xmlType?.Name))
            {
                throw new System.ArgumentNullException();
            }
            var originalTypeName = xmlType.Name;
            var friendlyTypeName = ReplaceInvalidCharsWithUnderscore(originalTypeName);
            friendlyTypeName = PrependUnderscoreIfStartsWithDigit(friendlyTypeName);
            return friendlyTypeName;
        }

        private static string ReplaceInvalidCharsWithUnderscore(string typeName)
        {
            var friendlyTypeName = typeName
                .Replace('.', '_')
                .Replace('-', '_')
                .Replace(':', '_');
            return friendlyTypeName;
        }

        private static string PrependUnderscoreIfStartsWithDigit(string typeName)
        {
            var friendlyTypeName = Regex.Replace(typeName, @"^(\d.*)", "_$1");
            return friendlyTypeName;
        }
    }
}