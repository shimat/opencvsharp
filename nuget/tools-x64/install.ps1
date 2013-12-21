param($installPath, $toolsPath, $package, $project)

$platform = "x64"

# 指定したディレクトリを「新しい場合はコピー」にする
function MarkDirectoryAsCopy($item)
{
    $item.ProjectItems | ForEach-Object { MarkFileAsCopy($_) }
}
# 指定したファイルを「新しい場合はコピー」にする
function MarkFileAsCopy($item)
{
    Try
    {
        Write-Host Try set $item.Name
        $item.Properties.Item("CopyToOutputDirectory").Value = 2 # copy if newer
    }
    Catch
    {
        Write-Host RecurseOn $item.Name
        MarkDirectoryAsCopyToOutputRecursive($item)
    }
}

$copyFiles = @(
    "msvcp110.dll";
    "msvcr110.dll";
    "OpenCvSharpExtern.dll";
    "opencv_calib3d245.dll";
    "opencv_contrib245.dll";
    "opencv_core245.dll";
    "opencv_features2d245.dll";
    "opencv_ffmpeg245_64.dll";
    "opencv_gpu245.dll";
    "opencv_flann245.dll";
    "opencv_highgui245.dll";
    "opencv_imgproc245.dll";
    "opencv_legacy245.dll";
    "opencv_ml245.dll";
    "opencv_nonfree245.dll";
    "opencv_objdetect245.dll";
    "opencv_photo245.dll";
    "opencv_stitching245.dll";
    "opencv_superres245.dll";
    "opencv_ts245.dll";
    "opencv_video245.dll";
    "opencv_videostab245.dll";
)
foreach ( $file in $copyFiles )
{
    MarkFileAsCopy($project.ProjectItems.Item($file))
}



function HasPlatform($manager, $platformName)
{
    $platforms = [Array] $manager.PlatformNames
    $index = [System.Array]::IndexOf($platforms, $platformName)
    $index -ge 0
}

$manager = $project.ConfigurationManager
$configs = [Array] $manager.PlatformNames  
$hasPlatform = HasPlatform $manager $platform
if(-not $hasPlatform)
{
    [void]$manager.AddPlatform($platform, "Any CPU", $true)
}



#foreach ($config in $configs)
#{
#    [System.Windows.Forms.MessageBox]::Show(HasPlatform)
#}
        

