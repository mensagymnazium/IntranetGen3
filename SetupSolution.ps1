param (
	[string]$NewFullName = "MensaGymnazium.IntranetGen3",
    [string]$NewSolutionName = "IntranetGen3",
	[string]$NewWebProjectPort = "44319",

    [string]$OriginalSolutionName = "IntranetGen3",
	[string]$OriginalWebProjectPort = "44319",
	[string]$OriginalFullName = "MensaGymnazium.IntranetGen3"
)

[string]$SolutionFolder = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path);

Get-ChildItem -recurse $SolutionFolder -include *.cs,*.csproj,*.config,*.ps1,*.json,*.tsx,*.cshtml,*.props,*.razor,*.json,*.html,*.js | where { $_ -is [System.IO.FileInfo] } | where { !$_.FullName.Contains("\packages\") } | where { !$_.FullName.Contains("\obj\") } | where { !$_.FullName.Contains("package.json") } | where { !$_.Name.Equals("_SetApplicationName.ps1") } |
Foreach-Object {
    Set-ItemProperty $_.FullName -name IsReadOnly -value $false
    [string]$Content = [IO.File]::ReadAllText($_.FullName)
    $Content = $Content.Replace($OriginalFullName, $NewFullName)
    $Content = $Content.Replace($OriginalSolutionName, $NewSolutionName)
    $Content = $Content.Replace($OriginalWebProjectPort, $NewWebProjectPort)
    [IO.File]::WriteAllText($_.FullName, $Content, [System.Text.Encoding]::UTF8)
}

Rename-Item -path ([System.IO.Path]::Combine($SolutionFolder, $OriginalSolutionName + '.sln')) -newName ($NewSolutionName + '.sln')
Rename-Item -path ([System.IO.Path]::Combine($SolutionFolder, 'Entity\IntranetGen3DbContext.cs')) -newName ($NewSolutionName + 'DbContext.cs')
Rename-Item -path ([System.IO.Path]::Combine($SolutionFolder, 'Entity\IntranetGen3DesignTimeDbContextFactory.cs')) -newName ($NewSolutionName + 'DesignTimeDbContextFactory.cs')
Rename-Item -path ([System.IO.Path]::Combine($SolutionFolder, 'Entity.Tests\IntranetGen3DbContextTests.cs')) -newName ($NewSolutionName + 'DbContextTests.cs')
