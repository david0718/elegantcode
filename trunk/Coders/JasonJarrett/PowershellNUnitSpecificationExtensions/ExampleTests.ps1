#
# Update-TypeData -prependPath NUnitSpecificationExtensions.ps1xml
#

[System.Reflection.Assembly]::LoadFrom("C:\Program Files\NUnit 2.5.2\bin\net-2.0\framework\nunit.framework.dll") | Out-Null

$true.ShouldBeTrue()

$false.ShouldBeFalse()

"a".ShouldEqual("a")

"a".ShouldNotEqual("b")
