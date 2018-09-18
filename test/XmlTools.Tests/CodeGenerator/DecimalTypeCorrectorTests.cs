using System.Xml.Linq;
using XmlTools.Tests.CodeGenerator.FileTests;
using Xunit;

namespace XmlTools.Tests.CodeGenerator
{
    public class DecimalTypeCorrectorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("1", "1")]
        [InlineData("1,00", "1,00")]
        [InlineData("1.00", "1.00")]
        [InlineData(".0", ".0")]
        [InlineData(".01", ".01")]
        [InlineData("1.01", "1.01")]
        [InlineData(",0", ",0")]
        [InlineData(",01", ",01")]
        [InlineData("1,01", "1,01")]
        [InlineData("1.000,12", "1000,12")]
        [InlineData("1,000.12", "1000.12")]
        [InlineData("123.456.789,01", "123456789,01")]
        [InlineData("123,456,789.01", "123456789.01")]
        public void CorrectsNumber(string sourceValue, string expectedValue)
        {
            var schemaFile = ParserTestFile.GAEB_XML_3_1_Schema;
            var invalidXDoc = XDocument.Parse(GetXmlStringWithValue(sourceValue));
            var correctedXDoc = SchemaCorrectorHelper.CorrectXmlInstanceForSchema(schemaFile, invalidXDoc);
            var expectedXDoc = XDocument.Parse(GetXmlStringWithValue(expectedValue));
            var xDocComparator = new XDocumentComparator(expectedXDoc, correctedXDoc);
            xDocComparator.AssertXDocumentsAreEqual();
        }

        private static string GetXmlStringWithValue(string value)
        {
            return $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<GAEB xmlns=""http://www.gaeb.de/GAEB_DA_XML/200407"">
	<GAEBInfo>
		<Version>3.1</Version>
		<VersDate>2009-12</VersDate>
	</GAEBInfo>
	<Award>
		<DP>83</DP>
		<BoQ>
			<BoQBody>
				<BoQCtgy RNoPart=""1"">
					<BoQBody>
						<Itemlist>
							<Item RNoPart=""2"">
								<Qty>59</Qty>
								<QU>stck</QU>
								<UP>170,45</UP>
								<IT>{value}</IT>
							</Item>
						</Itemlist>
					</BoQBody>
				</BoQCtgy>
			</BoQBody>
		</BoQ>
	</Award>
</GAEB>";
        }
    }
}
