$tag = "4.3.0.20200404"
$uriArray =@(
    "https://github.com/shimat/opencv_files/releases/download/${tag}/opencv430_win_x64.zip"
    "https://github.com/shimat/opencv_files/releases/download/${tag}/opencv430_win_x86.zip" 
    "https://github.com/shimat/opencv_files/releases/download/${tag}/opencv430_uwp_x64.zip" 
    "https://github.com/shimat/opencv_files/releases/download/${tag}/opencv430_uwp_x86.zip"
    "https://github.com/shimat/opencv_files/releases/download/${tag}/opencv430_uwp_ARM.zip"
)

function Download($uri, $outFile) {
    Write-Host "Downloading ${uri}"
    if (!(Test-Path $outFile)) {
        Invoke-WebRequest -Uri $uri -OutFile $outFile -ErrorAction Stop
    }
}

mkdir opencv_files -Force -ErrorAction Stop | Out-Null
cd opencv_files

foreach($uri in $uriArray){
    $outFile = [System.IO.Path]::GetFileName($uri)
    $outFileWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($uri)
    Download $uri $outFile
    Expand-Archive -Path $outFile -DestinationPath $outFileWithoutExtension -Force -ErrorAction Stop
    Remove-Item -Path $outFile -ErrorAction Stop
}

cd ..
