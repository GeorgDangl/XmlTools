using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace XmlTools.Tests.CodeGenerator
{
    public static class SchemaCorrectorHelper
    {
        public const string GENERATED_CODE_NAMESPACE = "InMemoryXmlToolsTest";
        public const string CODE_GENERATOR_CLASSNAME = "SchemaCorrector";
        public const string CODE_GENERATOR_METHOD_NAME = "CorrectDocument";

        public static string GetSchemaCorrectorCode(ParserTestFile testFile)
        {
            using (var schemaStream = TestFilesFactory.GetStreamForTestFile(testFile))
            {
                var xmlSchema = new XmlTools.Parser.XmlSchemaParser(schemaStream).GetSchema();
                var codeGenOptions = new XmlTools.CodeGenerator.CodeGeneratorOptions
                {
                    Namespace = GENERATED_CODE_NAMESPACE
                };
                var codeGen = new XmlTools.CodeGenerator.XmlSchemaCorrectorGenerator(xmlSchema, codeGenOptions);
                var generatedCode = codeGen.GenerateCode();
                return generatedCode;
            }
        }

        public static XDocument CorrectXmlInstanceForSchema(ParserTestFile schema, XDocument xmlInstance)
        {
            var compilation = GetCompilationForSchema(schema);
            var assembly = CompileLoadAndGetAssembly(compilation);
            var codeCorrectorType = assembly.GetType($"{GENERATED_CODE_NAMESPACE}.{CODE_GENERATOR_CLASSNAME}");
            var codeCorrector = Activator.CreateInstance(codeCorrectorType, xmlInstance);
            var codeCorrectorMethod = codeCorrectorType.GetTypeInfo().GetDeclaredMethod(CODE_GENERATOR_METHOD_NAME);
            var correctedInstance = codeCorrectorMethod.Invoke(codeCorrector, null);
            return correctedInstance as XDocument;
        }

        private static CSharpCompilation GetCompilationForSchema(ParserTestFile testFile)
        {
            var xmlCorrectorCode = GetSchemaCorrectorCode(testFile);
            var syntaxTree = CSharpSyntaxTree.ParseText(xmlCorrectorCode);
            string assemblyName = Path.GetRandomFileName();
            var references = GetAssemblyReferences();
            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            return compilation;
        }

        private static Assembly CompileLoadAndGetAssembly(CSharpCompilation compilation)
        {
            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms);
                ThrowExceptionIfCompilationFailure(result);
                ms.Seek(0, SeekOrigin.Begin);
#if NETSTANDARD
                var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(ms);
#endif
#if NET461
                var assembly = Assembly.Load(ms.ToArray());
#endif
                return assembly;
            }
        }

        private static void ThrowExceptionIfCompilationFailure(EmitResult result)
        {
            if (!result.Success)
            {
                var compilationErrors = result.Diagnostics.Where(diagnostic =>
                    diagnostic.IsWarningAsError ||
                    diagnostic.Severity == DiagnosticSeverity.Error)
                    .ToList();
                if (compilationErrors.Any())
                {
                    var firstError = compilationErrors.First();
                    var errorNumber = firstError.Id;
                    var errorDescription = firstError.GetMessage();
                    var firstErrorMessage = $"{errorNumber}: {errorDescription};";
                    throw new Exception($"Compilation failed, first error is: {firstErrorMessage}");
                }
            }
        }

        private static IEnumerable<MetadataReference> GetAssemblyReferences()
        {
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "mscorlib.dll")),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "System.Runtime.dll")),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "System.Collections.dll")),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "System.Xml.ReaderWriter.dll")),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "System.Xml.dll")),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "System.Private.Xml.dll")),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).GetTypeInfo().Assembly.Location, "..", "System.Text.RegularExpressions.dll")),
                MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(XElement).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.CodeDom.Compiler.GeneratedCodeAttribute).GetTypeInfo().Assembly.Location)
            };

            return references;
        }
    }
}
