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
    "msvcp100.dll";
    "msvcr100.dll";
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
    "opencv_objdetect248.dll";
    "opencv_ocl248.dll";
    "opencv_photo248.dll";
    "opencv_stitching248.dll";
    "opencv_superres248.dll";
    "opencv_video248.dll";
    "opencv_videostab248.dll";
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
        

