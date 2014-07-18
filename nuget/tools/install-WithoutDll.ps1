param($installPath, $toolsPath, $package, $project)

$platforms = @(
    "x86";
    "x64";
)

function HasPlatform($manager, $platformName)
{
    $myPlatforms = [Array] $manager.PlatformNames
    $index = [System.Array]::IndexOf($myPlatforms, $platformName)
    $index -ge 0
}

$manager = $project.ConfigurationManager
$configs = [Array] $manager.PlatformNames  

foreach ($p in $platforms)
{
    $hasPlatform = HasPlatform $manager $p
    if(-not $hasPlatform)
    {
        [void]$manager.AddPlatform($p, "Any CPU", $true)
    }
}
