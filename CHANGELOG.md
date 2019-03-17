# Changelog

All notable changes to **XmlTools** are documented here.

## v0.6.1:
- The schema corrector now removes elements that are marked as numerical but which have either no value at all or are self-closing in Xml

## v0.6.0:
- The schema corrector now uses `string.Equals()` for case invariant comparisons to reduce the count of object allocations that comes with `.ToUpperInvariant()`

## v0.5.1:
- Configure package description for NuGet packages

## v0.5.0:
- Schema corrector now fixes invalid Xsd decimal types

## v0.4.1:
- Add feature to only flatten groups with specific names

## v0.4.0:
- Add feature to merge multiple schemas

## v0.3.1
- Fix comment style in generated code

## v0.3.0:
- Add feature to repair or remove invalid Xml date elements

## v0.2.0
- Add `GroupFlattener`

## v0.1.2
- Fix bug where attributes could not be corrected when they had wrong casing

## v0.1.1
- Fixes duplicate enumeration values and disables compiler warning about missing Xml comments for the generated class

## v0.1.0
- Initial Release
