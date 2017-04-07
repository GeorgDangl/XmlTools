using XmlTools.CodeGenerator;

namespace XmlTools.Console
{
    public class CodeGenerator
    {
        public CodeGenerator(XmlSchema xmlSchema, string generatedCodeNamespace)
        {
            _xmlSchema = xmlSchema;
            _generatedCodeNamespace = generatedCodeNamespace;
        }

        private readonly XmlSchema _xmlSchema;
        private readonly string _generatedCodeNamespace;

        public string GenerateCode()
        {
            var options = GetOptions();
            var codeGenerator = new XmlSchemaCorrectorGenerator(_xmlSchema, options);
            var generatedCode = codeGenerator.GenerateCode();
            return generatedCode;
        }

        private CodeGeneratorOptions GetOptions()
        {
            var options = new CodeGeneratorOptions
            {
                Namespace = _generatedCodeNamespace
            };
            return options;
        }
    }
}