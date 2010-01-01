
function get-assembly-version() {
    param([string] $file)
    
	$version = [System.Reflection.AssemblyName]::GetAssemblyName($file).Version;

	$version
}

$version = get-assembly-version(".\Moq.dll")

echo "Loaded v$($version.Major).$($version.Minor).$($version.Build).$($version.Revision) version of $file"
