[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string] $MediaMtxVersion
)

$ErrorActionPreference = "Stop"

$archiveName = "mediamtx_v${MediaMtxVersion}_windows_amd64.zip"
$downloadBase = "https://github.com/bluenviron/mediamtx/releases/download/v${MediaMtxVersion}"
$serverDir = Join-Path $env:RUNNER_TEMP "mediamtx"
$archivePath = Join-Path $env:RUNNER_TEMP $archiveName
$checksumsPath = Join-Path $env:RUNNER_TEMP "mediamtx-checksums.sha256"
$stdoutPath = Join-Path $env:RUNNER_TEMP "mediamtx.stdout.log"
$stderrPath = Join-Path $env:RUNNER_TEMP "mediamtx.stderr.log"
$server = $null

try {
    Invoke-WebRequest "$downloadBase/$archiveName" -OutFile $archivePath
    Invoke-WebRequest "$downloadBase/checksums.sha256" -OutFile $checksumsPath

    $checksumLine = Get-Content $checksumsPath |
        Where-Object { $_ -match "[ *]$([regex]::Escape($archiveName))$" }
    if (-not $checksumLine) {
        throw "Checksum not found for $archiveName"
    }

    $expectedChecksum = ($checksumLine -split "\s+")[0].ToLowerInvariant()
    $actualChecksum = (Get-FileHash $archivePath -Algorithm SHA256).Hash.ToLowerInvariant()
    if ($actualChecksum -ne $expectedChecksum) {
        throw "Checksum mismatch for ${archiveName}: expected $expectedChecksum, got $actualChecksum"
    }

    Expand-Archive $archivePath -DestinationPath $serverDir
    $server = Start-Process `
        (Join-Path $serverDir "mediamtx.exe") `
        -ArgumentList "${env:GITHUB_WORKSPACE}\test\rtsp\mediamtx.yml" `
        -RedirectStandardOutput $stdoutPath `
        -RedirectStandardError $stderrPath `
        -WindowStyle Hidden `
        -PassThru

    $ready = $false
    for ($attempt = 1; $attempt -le 30; $attempt++) {
        if ($server.HasExited) {
            Get-Content $stdoutPath, $stderrPath -ErrorAction SilentlyContinue
            throw "MediaMTX exited with code $($server.ExitCode)"
        }
        if ((Get-Content $stdoutPath -Raw -ErrorAction SilentlyContinue) -match "stream is available") {
            $ready = $true
            break
        }
        Start-Sleep -Seconds 1
    }

    if (-not $ready) {
        Get-Content $stdoutPath, $stderrPath -ErrorAction SilentlyContinue
        throw "Timed out waiting for MediaMTX"
    }

    $env:OPENCVSHARP_TEST_RTSP_URL = "rtsp://127.0.0.1:8554/test"
    dotnet test test\OpenCvSharp.Tests -c Release -f net10.0 --runtime win-x64 `
        --no-build --no-restore `
        --filter "FullyQualifiedName=OpenCvSharp.Tests.VideoIO.VideoCaptureTest.ReadRtspStreamWithFFmpeg"
    if ($LASTEXITCODE -ne 0) {
        Get-Content $stdoutPath, $stderrPath -ErrorAction SilentlyContinue
        throw "RTSP integration test failed with exit code $LASTEXITCODE"
    }
}
finally {
    if ($server -and -not $server.HasExited) {
        Stop-Process -Id $server.Id -Force -ErrorAction SilentlyContinue
    }
}
