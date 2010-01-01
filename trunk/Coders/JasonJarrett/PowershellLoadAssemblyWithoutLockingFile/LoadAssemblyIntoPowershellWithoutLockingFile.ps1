$file = ".\Moq.dll"
$tempFileName = ".\Moq-Renamed.dll"

$assemblyBytes = [System.IO.File]::ReadAllBytes($file)

#TODO: what to do if assembly depends on something else that isn't loaded?
$assemblyLoaded = [System.Reflection.Assembly]::Load($assemblyBytes);

# notice that we can move the file on disk after 
# it's loaded into the powershell runtime
mv $file $tempFileName
mv $tempFileName $file 

# and echo the assembly information to show it's still in memory...
echo $assemblyLoaded
