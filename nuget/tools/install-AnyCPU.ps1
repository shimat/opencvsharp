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
    "opencv_calib3d249.dll";
    "opencv_contrib249.dll";
    "opencv_core249.dll";
    "opencv_features2d249.dll";
    "opencv_ffmpeg249.dll";
    "opencv_gpu249.dll";
    "opencv_flann249.dll";
    "opencv_highgui249.dll";
    "opencv_imgproc249.dll";
    "opencv_legacy249.dll";
    "opencv_ml249.dll";
    "opencv_nonfree249.dll";
    "opencv_ocl249.dll";
    "opencv_objdetect249.dll";
    "opencv_photo249.dll";
    "opencv_stitching249.dll";
    "opencv_superres249.dll";
    "opencv_video249.dll";
    "opencv_videostab249.dll";
)
$copyFilesX64 = @(
    "msvcp110.dll";
    "msvcr110.dll";
    "OpenCvSharpExtern.dll";
    "opencv_calib3d249.dll";
    "opencv_contrib249.dll";
    "opencv_core249.dll";
    "opencv_features2d249.dll";
    "opencv_ffmpeg249_64.dll";
    "opencv_gpu249.dll";
    "opencv_flann249.dll";
    "opencv_highgui249.dll";
    "opencv_imgproc249.dll";
    "opencv_legacy249.dll";
    "opencv_ml249.dll";
    "opencv_nonfree249.dll";
    "opencv_ocl249.dll";
    "opencv_objdetect249.dll";
    "opencv_photo249.dll";
    "opencv_stitching249.dll";
    "opencv_superres249.dll";
    "opencv_video249.dll";
    "opencv_videostab249.dll";
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
        

