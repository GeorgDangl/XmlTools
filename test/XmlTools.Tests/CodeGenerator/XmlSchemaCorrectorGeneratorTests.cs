using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.DependencyModel;
using Xunit;

namespace XmlTools.Tests.CodeGenerator
{
    public class XmlSchemaCorrectorGeneratorTests
    {
        [Fact]
        public void WriteCodeGenToDisk()
        {
            const string outputFilePath = @"C:\Users\Georg\Downloads\CodeGenOutput\Generated.cs";
            {
                var generatedCode = SchemaCorrectorHelper.GetSchemaCorrectorCode(ParserTestFile.GAEB_XML_3_1_Schema);
                using (var fs = File.CreateText(outputFilePath))
                {
                    fs.Write(generatedCode);
                }
            }
        }

        [Fact]
        public void CanGenerateCode_GAEB_XML_3_1_Schema()
        {
            var generatedCode = SchemaCorrectorHelper.GetSchemaCorrectorCode(ParserTestFile.GAEB_XML_3_1_Schema);
            var didGenerateCode = !string.IsNullOrWhiteSpace(generatedCode);
            Assert.True(didGenerateCode);
        }

        [Fact]
        public void CanGenerateCode_GreenBuildingXML_Ver6_01()
        {
            var generatedCode = SchemaCorrectorHelper.GetSchemaCorrectorCode(ParserTestFile.GreenBuildingXML_Ver6_01);
            var didGenerateCode = !string.IsNullOrWhiteSpace(generatedCode);
            Assert.True(didGenerateCode);
        }
    }
}
