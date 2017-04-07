# XmlTools

[![Build Status](https://jenkins.dangl.me/buildStatus/icon?job=XmlTools.Tests)](https://jenkins.dangl.me/job/XmlTools.Tests)

This packages purpose is to correct invalid Xml files where enumeration restrictions
are violated. It's intended to make working with code generated from Xml schemas easier.

While it can be used dynamically (see `XmlTools.Tests.CodeGenerator.SchemaCorrectorHelper` for dynamically
generating the code, compiling in-memory with Roslyn and then working with this code), it's main
use case is to auto generate code that is then used to sanitize incoming Xml.

Features are currently limited to correcting Xml enumeration restrictions.
Both attributes and elements are supported. When an invalid enumeration value
is encountered, it is either **deleted** if it's not valid at all or **case corrected**
if the casing is off.

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
$xmlToolPackages = Join-Path -Path $env:USERPROFILE -ChildPath "\.nuget\packages\XmlTools"
$latestXmlToolConsoleApp = Join-Path -Path ((Get-ChildItem -Path $xmlToolPackages | Sort-Object Fullname -Descending)[0].FullName) -ChildPath "Tool\net46\XmlTools.Console.exe"
# Call the tool to make the conversion
& $latestXmlToolConsoleApp -i $inputPath -o $outputPath -n $namespace
```

Specify the `input schema`, `output code file` and the `namespace` in the batch file and call it
whenever you want to recreate your code.

## Main classes

There's the `XmlSchemaParser` in `XmlTools.Parser` to read Xml schemas and then there's the `XmlSchemaCorrectorGenerator`
in `XmlTools.CodeGenerator` to create validation code.