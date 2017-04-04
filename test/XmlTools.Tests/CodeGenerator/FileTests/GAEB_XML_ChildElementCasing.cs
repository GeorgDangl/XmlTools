using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTools.Tests.CodeGenerator
{
    public class GAEB_XML_ChildElementCasing : CodeGeneratorTestsBase
    {
        public GAEB_XML_ChildElementCasing() : base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_ChildElementCasing,
            SchemaCorrectorTestFile.GAEB_XML_ChildElementCasing_Expected)
        { }
    }
}
