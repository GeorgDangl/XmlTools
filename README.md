# XmlTools

[![Build Status](https://jenkins.dangl.me/buildStatus/icon?job=XmlTools/develop)](https://jenkins.dangl.me/job/XmlTools/develop)  
[![NuGet](https://img.shields.io/nuget/v/XmlTools.svg)](https://www.nuget.org/packages/XmlTools)  

[Online Documentation](https://docs.dangl-it.com/Projects/XmlTools)

This packages purpose is to correct invalid Xml files where enumeration restrictions or Xml date format masks
are violated. It's intended to make working with code generated from Xml schemas easier.

While it can be used dynamically (see `XmlTools.Tests.CodeGenerator.SchemaCorrectorHelper` for dynamically
generating the code, compiling in-memory with Roslyn and then working with this code), it's main
use case is to auto generate code that is then used to sanitize incoming Xml.

Features are currently limited to correcting Xml enumeration restrictions, fixing invalid Xsd decimals and
repairing or removing invalid Xml date elements.
Both attributes and elements are supported. When an invalid enumeration value
is encountered, it is either **deleted** if it's not valid at all or **case corrected**
if the casing is off.

## CLI Options

| Parameter | Description |
|-----------|-------------|
| `-i`, `--input`           | Relative or absolute path to an Xml schema file |
| `-o`, `--output`          | Relative or absolute path to the output file |
| `-n`, `--namespace`       | Namespace for the generated class |
| `-f`, `--flatten`         | If enabled, groups will be flattened |
| `-s`, `--specific-groups` | If specified in combination with the 'flatten' option, only groups with the given names will be flattened |
| `-m`, `--merge`           | If enabled, the schema will be merged |
| --help                | Shows help |

### Flattening

Flattening means that Xsd `group` and `attributeGroup` elements are rebuilt so that the elements within are directly defined where previously only the group reference would be used.

### Merging

When merging Xsd schemas, other schema files that are referenced are loaded and will be embedded directly in the original. This only works for file-path references, Urls will not be resolved.

## Using the XmlTools.Console app to create validation code

With the package available in the local NuGet cache, you need to create two files:

**codegen.bat**

```Batchfile
    Powershell.exe -executionpolicy remotesigned -File  "%~dp0\codegen.ps1" Schema\MySchema.xsd Schema\MySchemaCorrector.cs MyNamespace
```

**codegen.ps1**

```PowerShell
param([string]$inputPath, [string]$outputPath, [string]$namespace)
# Find the latest version of the XmlTools.Console app
$xmlToolPackages = Join-Path -Path $env:USERPROFILE -ChildPath "\.nuget\packages\XmlTools.Console"
$latestXmlToolConsoleApp = Join-Path -Path ((Get-ChildItem -Path $xmlToolPackages | Sort-Object Fullname -Descending)[0].FullName) -ChildPath "tools\net461\XmlTools.Console.exe"
# Call the tool to make the conversion
& $latestXmlToolConsoleApp -i $inputPath -o $outputPath -n $namespace
```

Specify the `input schema`, `output code file` and the `namespace` in the batch file and call it
whenever you want to recreate your code.

## Main classes

There's the `XmlSchemaParser` in `XmlTools.Parser` to read Xml schemas and then there's the `XmlSchemaCorrectorGenerator`
in `XmlTools.CodeGenerator` to create validation code.

### Flattener

The function of the `XmlTools.GroupFlattener.Flattener` is to flatten or unroll groups. Many Xml tools have trouble
with resolving circular group references, so this is an easy way to fix this while still preserving the schema. In addition,
it makes sure that any elements of type `xs:key` will have their unique naming restored.

The group flattener supports an optional argument of type `List<string>` to only flatten groups with the given names. This is sometimes
useful to only flatten groups that resolve to a circular reference, which may cause errors with some Xsd-to-Code generators.
