using System.Collections.Generic;

namespace XmlTools
{
    public class XmlComplexType : XmlTypeWithAttributes
    {
        public List<XmlElement> PossibleChildElements { get; set; }
    }
}