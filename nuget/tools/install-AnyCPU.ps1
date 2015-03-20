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
    "msvcp120.dll";
    "msvcr120.dll";
    "OpenCvSharpExtern.dll";
    "opencv_calib3d2410.dll";
    "opencv_contrib2410.dll";
    "opencv_core2410.dll";
    "opencv_features2d2410.dll";
    "opencv_ffmpeg2410.dll";
    "opencv_gpu2410.dll";
    "opencv_flann2410.dll";
    "opencv_highgui2410.dll";
    "opencv_imgproc2410.dll";
    "opencv_legacy2410.dll";
    "opencv_ml2410.dll";
    "opencv_nonfree2410.dll";
    "opencv_ocl2410.dll";
    "opencv_objdetect2410.dll";
    "opencv_photo2410.dll";
    "opencv_stitching2410.dll";
    "opencv_superres2410.dll";
    "opencv_video2410.dll";
    "opencv_videostab2410.dll";
)
$copyFilesX64 = @(
    "msvcp120.dll";
    "msvcr120.dll";
    "OpenCvSharpExtern.dll";
    "opencv_calib3d2410.dll";
    "opencv_contrib2410.dll";
    "opencv_core2410.dll";
    "opencv_features2d2410.dll";
    "opencv_ffmpeg2410_64.dll";
    "opencv_gpu2410.dll";
    "opencv_flann2410.dll";
    "opencv_highgui2410.dll";
    "opencv_imgproc2410.dll";
    "opencv_legacy2410.dll";
    "opencv_ml2410.dll";
    "opencv_nonfree2410.dll";
    "opencv_ocl2410.dll";
    "opencv_objdetect2410.dll";
    "opencv_photo2410.dll";
    "opencv_stitching2410.dll";
    "opencv_superres2410.dll";
    "opencv_video2410.dll";
    "opencv_videostab2410.dll";
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
        

