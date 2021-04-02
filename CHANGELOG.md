# Changelog

All notable changes to **XmlTools** are documented here.

## v0.8.0:
- The code generator was updated to now remove XML simple type values that do have elements within them

## v0.7.0:
- Fixed a behavior when extracting the allowed values for an enumeration (a string type with only certain valid values, given as a restriction). Previously, if the parsed type was a derived type, both the values of the base as well as the derived type were considered valid. This has been fixed, so if the derived type specifies restrictions of its own, only those values are used, otherwise the values from the base type are used

## v0.6.5:
- XSD type names with a point `.` are now supported for corrector generation, the point is converted to an underscore `_` when generating a class name

## v0.6.4:
- The decimal corrector now removes decimal elements that have non-numerical content completely

## v0.6.3:
- The decimal corrector now removes decimal values that contain nested nodes, e.g. `<Outer><Inner>123</Inner></Outer>` is removed since `Inner` is not a valid decimal string representation

## v0.6.2:
- The decimal corrector now removes multiple points or commas, e.g. `123..456` is fixed to `123.456`

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
