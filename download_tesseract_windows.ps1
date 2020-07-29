$uriArray =@(
    "https://github.com/shimat/tesseract_vcpkg/releases/download/2020.07.21/tesseract_vcpkg.0.0.5-beta14.zip"
)

function Download($uri, $outFile) {
    Write-Host "Downloading ${uri}"
    if (!(Test-Path $outFile)) {
        Invoke-WebRequest -Uri $uri -OutFile $outFile -ErrorAction Stop
    }
}

mkdir tesseract_files -Force -ErrorAction Stop | Out-Null
cd tesseract_files

[Net.ServicePointManager]::SecurityProtocol = @([Net.SecurityProtocolType]::Tls,[Net.SecurityProtocolType]::Tls11,[Net.SecurityProtocolType]::Tls12)

foreach($uri in $uriArray){
    $outFile = "tesseract_vcpkg.zip"
    $outFileWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($outFile)
    Download $uri $outFile
    Expand-Archive -Path $outFile -DestinationPath $outFileWithoutExtension -Force -ErrorAction Stop
    Move-Item $outFileWithoutExtension\*\* $outFileWithoutExtension
    Remove-Item -Path $outFile -ErrorAction Stop
}

cd ..
