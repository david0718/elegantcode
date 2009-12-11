
function get-assembly-version() {
    param([string] $file)
    
	# load the assembly bytes quickly - as to not lock the file for too long
	$fileStream = ([System.IO.FileInfo] (Get-Item $file)).OpenRead()
	$assemblyBytes = new-object byte[] $fileStream.Length
	$fileStream.Read($assemblyBytes, 0, $fileStream.Length) | Out-Null #out null this because this function should only return the version & this call was outputting some garbage number
	$fileStream.Close()
    
	# return the version of the assembly
	[System.Reflection.Assembly]::Load($assemblyBytes).GetName().Version;
}

$version = get-assembly-version(".\Moq.dll")

echo "Loaded v$($version.Major).$($version.Minor).$($version.Build).$($version.Revision) version of $file"
