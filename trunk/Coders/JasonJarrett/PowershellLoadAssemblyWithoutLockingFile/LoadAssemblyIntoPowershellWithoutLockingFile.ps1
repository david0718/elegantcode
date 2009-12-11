$file = ".\Moq.dll"
$tempFileName = ".\Moq-Renamed.dll"

$fileStream = ([System.IO.FileInfo] (Get-Item $file)).OpenRead();
$assemblyBytes = new-object byte[] $fileStream.Length
$fileStream.Read($assemblyBytes, 0, $fileStream.Length);
$fileStream.Close();

$assemblyLoaded = [System.Reflection.Assembly]::Load($assemblyBytes);

# notice that we can move the file on disk after 
# it's loaded into the powershell runtime
mv $file $tempFileName
mv $tempFileName $file 

# and echo the assembly information to show it's still in memory...
echo $assemblyLoaded
