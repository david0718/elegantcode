
<#
 # Feature Branch
 # 
 # Convention for branches
 #   /RootTeamBranchesCheckoutFolder
 #       /Feature-A/
 #         /lib
 #         /src
 #           /ProjectSolution.sln
 #       /Feature-B/
 #         /lib
 #         /src
 #           /ProjectSolution.sln
 #       /Feature-C/
 #         /lib
 #         /src
 #           /ProjectSolution.sln
 # 
 # Configuration of branch builder powershell script
 # 
 #  # This is the 'key' that we're looking for to signify that a folder is a new "branch"
 #  # we use the -like operator against the full file path when searching
 #  # check here for good example of use http://www.computerperformance.co.uk/powershell/powershell_conditional_operators.htm#Example_2_-Like
 #  $branchSignificantFile = '*\src\ProjectSolution.sln'
 # 
 # 
 #>

 $i = 0
foreach($a in $args)
{
	echo "### DEBUG - args[$i]=$a"
	$i = $i + 1
}

 
 
$branchSignificantFile = '*ClassLibrary1.sln'
$taskToExecuteOnEachFeatureBranch = {
		& 'C:\Windows\Microsoft.NET\Framework\v3.5\MSBuild.exe' ClassLibrary1.sln
}


# In teamcity each Feature branch build is considered a TestSuite with a single Test.
#  - If a build fails/passes then it is reported as a Failed/Passed Test
#  - If there are no changes detected (in that branch) then it is reported as an Ignored Test.
# Spec of test reporting protocol
#  - http://confluence.jetbrains.net/display/TCD5/Build+Script+Interaction+with+TeamCity
function TeamCity-TestSuiteStarted([string]$name) { Write-Output "##teamcity[testSuiteStarted name='$name']" }
function TeamCity-TestSuiteFinished([string]$name) { Write-Output "##teamcity[testSuiteFinished name='$name']" }
function TeamCity-TestStarted([string]$name) { Write-Output "##teamcity[testStarted name='$name']" }
function TeamCity-TestFinished([string]$name) { Write-Output "##teamcity[testFinished name='$name']" }
function TeamCity-TestIgnored([string]$name, [string]$message='') { Write-Output "##teamcity[testIgnored name='$name' message='$message']" }
function TeamCity-BeginTestOutput([string]$name, [string]$output) { Write-Output "##teamcity[testStdOut name='$name' out='" }
function TeamCity-EndTestOutput([string]$name, [string]$output) { Write-Output "']" }
function TeamCity-TestError([string]$name, [string]$output) { Write-Output "##teamcity[testStdErr name='$name' out='$output']" }

<#
Other potential references?
http://www.candland.net/blog/2010/02/08/PsakeBuildsAndTeamCityIntegration.aspx
http://code.google.com/p/hornget/source/detail?r=337
TeamCity work around for powershell http://youtrack.jetbrains.net/issue/TW-6021


TODO: Potential feature - look into the Reporting Build Statistics (http://confluence.jetbrains.net/display/TCD5/Build+Script+Interaction+with+TeamCity)

#>

# DOCS: http://confluence.jetbrains.net/display/TCD5/Risk+Tests+Reordering+in+Custom+Test+Runner
$rootPath = ($pwd).Path

#File where we look for TeamCity change notifications to determine if a build is required in a branch.
#$teamCityChangeSetFilePath = "${teamcity.build.changedFiles.file}"
$teamCityChangeSetFilePath = ".\featureChanges.txt"

if(!(Test-Path $teamCityChangeSetFilePath))
{
	throw "Cannot find teamcity change file [$teamCityChangeSetFilePath]"
}

# go out and find that branch significant file that tells us 
$allFeatureBranchDirectoriesFound = Get-ChildItem -Recurse . | where { $_.Name -like $branchSignificantFile } | Select-Object Directory


foreach($featureBranchDirectory in $allFeatureBranchDirectoriesFound)
{
	$relativeFullname = $featureBranchDirectory.Directory.FullName.SubString($rootPath.Length+1);
<#
	echo "DEBUG - rootPath=$rootPath"
	echo "DEBUG - relativeFullname=$relativeFullname"
	echo "DEBUG - featureBranchDirectory=$featureBranchDirectory"
#>
	TeamCity-TestSuiteStarted $relativeFullname
	
	TeamCity-TestStarted $relativeFullname
	
	    
	if( (Get-Content -Path $teamCityChangeSetFilePath | foreach { $_ -like "$relativeFullname*" } | Measure-Object).Count -gt 0)
	{
		$rootBranchPath = (Get-Item $relativeFullname).Parent.FullName
		Push-Location $relativeFullname

		try
		{
			TeamCity-BeginTestOutput $relativeFullname
			& $taskToExecuteOnEachFeatureBranch
			TeamCity-EndTestOutput

			if ($lastexitcode -ne 0)
			{
				 throw $errorMessage
			}
		}
		catch
		{
			TeamCity-TestError $relativeFullname $error[0]
		}
		Pop-Location
	}
	else
	{
		TeamCity-TestIgnored $relativeFullname 'Branch ignored because no changes detected since last build'	
	}
	
	TeamCity-TestFinished $relativeFullname

	TeamCity-TestSuiteFinished $relativeFullname
}
