using System.Collections.Generic;

namespace XmlTools
{
    public abstract class XmlTypeWithAttributes : XmlType
    {
        public List<XmlAttribute> Attributes { get; set; }
    }
}