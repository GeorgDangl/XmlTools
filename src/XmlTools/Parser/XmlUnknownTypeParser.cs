using System.Collections.Generic;

namespace XmlTools.Parser
{
    public class XmlUnknownTypeParser
    {
        private readonly Dictionary<string, XmlUnknownType> _parsedTypes = new Dictionary<string, XmlUnknownType>();

        public XmlUnknownType GetUnknownTypeDefinitionByName(string typeName)
        {
            if (_parsedTypes.ContainsKey(typeName))
            {
                return _parsedTypes[typeName];
            }
            var unknownType = new XmlUnknownType
            {
                Name = typeName
            };
            _parsedTypes.Add(typeName, unknownType);
            return unknownType;
        }
    }
}