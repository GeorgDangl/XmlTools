using System;
using System.Diagnostics.CodeAnalysis;
using XmlTools.CodeGenerator;
using Xunit;

namespace XmlTools.Tests.CodeGenerator
{
    public class TypeNameClassTranslatorTests
    {
        private XmlType GetTypeWithName(string typeName)
        {
            return new XmlSimpleType
            {
                Name = typeName
            };
        }

        [Fact]
        public void ArgumentNullExceptionOnNullInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                TypeNameClassTranslator.GetFriendlyTypeName(null);
            });
        }

        [Fact]
        public void ArgumentNullExceptionOnEmptyName()
        {
            var xmlType = GetTypeWithName(string.Empty);
            Assert.Throws<ArgumentNullException>(() =>
            {
                TypeNameClassTranslator.GetFriendlyTypeName(xmlType);
            });
        }

        [Fact]
        public void ArgumentNullExceptionOnNullName()
        {
            var xmlType = GetTypeWithName(null);
            Assert.Throws<ArgumentNullException>(() =>
            {
                TypeNameClassTranslator.GetFriendlyTypeName(xmlType);
            });
        }

        [Fact]
        public void DoesNotAlterSimpleName()
        {
            var typeName = "HansGruber";
            var expectedName = "HansGruber";
            AssertCorrectTransformation(typeName, expectedName);

        }

        [Fact]
        public void ReplaceColonWithUnderscore()
        {
            var typeName = "xs:string";
            var expectedName = "xs_string";
            AssertCorrectTransformation(typeName, expectedName);
        }

        [Fact]
        public void ReplacePointWithUnderscore()
        {
            var typeName = "my.group";
            var expectedName = "my_group";
            AssertCorrectTransformation(typeName, expectedName);
        }

        [Fact]
        public void ReplaceDashWithUnderscore()
        {
            var typeName = "Some-Name";
            var expectedName = "Some_Name";
            AssertCorrectTransformation(typeName, expectedName);
        }

        [Fact]
        public void PrependUnderscoreWhenFirstCharIsDigit()
        {
            var typeName = "14Stories";
            var expectedName = "_14Stories";
            AssertCorrectTransformation(typeName, expectedName);
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void AssertCorrectTransformation(string typeName, string expectedName)
        {
            var xmlType = GetTypeWithName(typeName);
            var actualName = TypeNameClassTranslator.GetFriendlyTypeName(xmlType);
            Assert.Equal(expectedName, actualName);
        }
    }
}