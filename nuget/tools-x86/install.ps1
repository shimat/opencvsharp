param($installPath, $toolsPath, $package, $project)

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

$platforms = @(
    "x86";
    "x64";
)
$copyFilesX86 = @(
    "msvcp110.dll";
    "msvcr110.dll";
    "OpenCvSharpExtern.dll";
    "opencv_calib3d248.dll";
    "opencv_contrib248.dll";
    "opencv_core248.dll";
    "opencv_features2d248.dll";
    "opencv_ffmpeg248.dll";
    "opencv_gpu248.dll";
    "opencv_flann248.dll";
    "opencv_highgui248.dll";
    "opencv_imgproc248.dll";
    "opencv_legacy248.dll";
    "opencv_ml248.dll";
    "opencv_nonfree248.dll";
    "opencv_ocl248.dll";
    "opencv_objdetect248.dll";
    "opencv_photo248.dll";
    "opencv_stitching248.dll";
    "opencv_superres248.dll";
    "opencv_video248.dll";
    "opencv_videostab248.dll";
)
$copyFilesX64 = @(
    "msvcp110.dll";
    "msvcr110.dll";
    "OpenCvSharpExtern.dll";
    "opencv_calib3d248.dll";
    "opencv_contrib248.dll";
    "opencv_core248.dll";
    "opencv_features2d248.dll";
    "opencv_ffmpeg248_64.dll";
    "opencv_gpu248.dll";
    "opencv_flann248.dll";
    "opencv_highgui248.dll";
    "opencv_imgproc248.dll";
    "opencv_legacy248.dll";
    "opencv_ml248.dll";
    "opencv_nonfree248.dll";
    "opencv_ocl248.dll";
    "opencv_objdetect248.dll";
    "opencv_photo248.dll";
    "opencv_stitching248.dll";
    "opencv_superres248.dll";
    "opencv_video248.dll";
    "opencv_videostab248.dll";
)

# x86
foreach ($file in $copyFilesX86)
{
    $dllDir = $project.ProjectItems.Item("dll")
    $platFormDir = $dllDir.ProjectItems.Item("x86")
    MarkFileAsCopy($platFormDir.ProjectItems.Item($file))
}
# x64
foreach ($file in $copyFilesX64)
{
    $dllDir = $project.ProjectItems.Item("dll")
    $platFormDir = $dllDir.ProjectItems.Item("x64")
    MarkFileAsCopy($platFormDir.ProjectItems.Item($file))
}



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


#foreach ($config in $configs)
#{
#    [System.Windows.Forms.MessageBox]::Show(HasPlatform)
#}
        

