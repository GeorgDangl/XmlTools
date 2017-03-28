using System.Collections.Generic;

namespace XmlTools
{
    public class XmlSimpleContentEnumerationComplexType : XmlSimpleContentComplexType
    {
        public List<string> EnumerationValues { get; set; }
    }
}