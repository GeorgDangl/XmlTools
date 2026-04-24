using System.Linq;
using System.Xml.Linq;
using XmlTools.Tests.CodeGenerator;
using XmlTools.Tests.CodeGenerator.FileTests;
using Xunit;

namespace XmlTools.Tests.Regression
{
    public class DecimalAttributeCorrection
    {
        [Fact]
        public void CanReadGaebXmlFileWithInvalidDecimalValueAttribute()
        {
            var xmlString = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GAEB xmlns=""http://www.gaeb.de/GAEB_DA_XML/DA83/3.3"">
  <GAEBInfo>
    <Version>3.3</Version>
    <VersDate>2021-05</VersDate>
    <Date>2026-04-08</Date>
    <Time>16:35:58</Time>
  </GAEBInfo>
  <Award>
    <DP>83</DP>
    <BoQ ID=""B1"">
      <BoQBody>
        <BoQCtgy ID=""C14"" RNoPart=""14"">
          <BoQBody>
            <Itemlist>
              <Item ID=""I552"" RNoPart=""380"">
                <Description>
                  <CompleteText>
                    <DetailTxt>
                      <TextComplement Kind=""Owner"" MarkLbl=""2"">
                        <ComplBodyDec Value=""0,8"" />
                        <ComplBody>
                          <span> 0,8 </span>
                        </ComplBody>
                      </TextComplement>
                    </DetailTxt>
                  </CompleteText>
                </Description>
              </Item>
            </Itemlist>
          </BoQBody>
        </BoQCtgy>
      </BoQBody>
    </BoQ>
  </Award>
</GAEB>
";

            var schemaFile = ParserTestFile.GAEB_XML_3_3_Schema;
            var invalidXDoc = XDocument.Parse(xmlString);
            var correctedXDoc = SchemaCorrectorHelper.CorrectXmlInstanceForSchema(schemaFile, invalidXDoc);

            var expectedXDoc = XDocument.Parse(xmlString);
            var expectedNode = expectedXDoc.Descendants().Single(d => d.Name.LocalName == "ComplBodyDec");
            expectedNode.Attribute("Value").Value = "0.8";

            var xDocComparator = new XDocumentComparator(expectedXDoc, correctedXDoc);
            xDocComparator.AssertXDocumentsAreEqual();
        }
    }
}
