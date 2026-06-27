<#
.SYNOPSIS
    Assembles the OpenCvSharp binary release zip (managed libs + native extern + docs).

.DESCRIPTION
    Replaces the former standalone OpenCvSharp.ReleaseMaker C# tool. It simply stages a
    fixed set of build outputs into a known directory layout and compresses them:

        ManagedLib/net8.0/   OpenCvSharp, GdipExtensions, WpfExtensions (dll/pdb/config)
        NativeLib/win/x64/   OpenCvSharpExtern (dll/pdb)
        XmlDoc/              WpfExtensions XML doc
        LICENSE, README.md

    Missing optional files (pdb/config/xml) are skipped rather than treated as errors.

.PARAMETER WorkspaceDir
    Repository root (contains src/, LICENSE, README.md).

.PARAMETER OutputDir
    Directory the resulting zip is written to.

.PARAMETER Version
    OpenCV version string, e.g. 5.0.0. The zip is named OpenCvSharp-<Version>-<yyyyMMdd>.zip.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)] [string] $WorkspaceDir,
    [Parameter(Mandatory = $true)] [string] $OutputDir,
    [Parameter(Mandatory = $true)] [string] $Version
)

$ErrorActionPreference = "Stop"

$srcDir = Join-Path $WorkspaceDir "src"
$date = Get-Date -Format "yyyyMMdd"
$zipName = "OpenCvSharp-$Version-$date.zip"
$zipPath = Join-Path $OutputDir $zipName

# Managed libraries: OpenCvSharp 5 targets net8.0 only.
$managedFiles = @(
    "OpenCvSharp\bin\Release\net8.0\OpenCvSharp.dll",
    "OpenCvSharp\bin\Release\net8.0\OpenCvSharp.dll.config",
    "OpenCvSharp\bin\Release\net8.0\OpenCvSharp.pdb",
    "OpenCvSharp.GdipExtensions\bin\Release\net8.0\OpenCvSharp.GdipExtensions.dll",
    "OpenCvSharp.GdipExtensions\bin\Release\net8.0\OpenCvSharp.GdipExtensions.pdb",
    "OpenCvSharp.WpfExtensions\bin\Release\net8.0-windows\OpenCvSharp.WpfExtensions.dll",
    "OpenCvSharp.WpfExtensions\bin\Release\net8.0-windows\OpenCvSharp.WpfExtensions.pdb"
)
$xmlFiles = @(
    "OpenCvSharp.WpfExtensions\OpenCvSharp.WpfExtensions.xml"
)
# cmake's Visual Studio generator outputs the native lib here.
$externDir = Join-Path $srcDir "build\OpenCvSharpExtern\Release"

$staging = Join-Path ([System.IO.Path]::GetTempPath()) ("ocvs-release-" + [System.Guid]::NewGuid().ToString("N"))
New-Item -ItemType Directory -Path $staging -Force | Out-Null

try {
    $managedDst = Join-Path $staging "ManagedLib\net8.0"
    New-Item -ItemType Directory -Path $managedDst -Force | Out-Null
    foreach ($rel in $managedFiles) {
        $path = Join-Path $srcDir $rel
        if (Test-Path $path) {
            Copy-Item $path -Destination $managedDst
        }
        else {
            Write-Host "Skipping missing file: $path"
        }
    }

    $xmlDst = Join-Path $staging "XmlDoc"
    New-Item -ItemType Directory -Path $xmlDst -Force | Out-Null
    foreach ($rel in $xmlFiles) {
        $path = Join-Path $srcDir $rel
        if (Test-Path $path) {
            Copy-Item $path -Destination $xmlDst
        }
    }

    $nativeDst = Join-Path $staging "NativeLib\win\x64"
    New-Item -ItemType Directory -Path $nativeDst -Force | Out-Null
    foreach ($ext in @("dll", "pdb")) {
        $path = Join-Path $externDir "OpenCvSharpExtern.$ext"
        if (Test-Path $path) {
            Copy-Item $path -Destination $nativeDst
        }
        else {
            Write-Host "Skipping missing file: $path"
        }
    }

    foreach ($name in @("LICENSE", "README.md")) {
        $path = Join-Path $WorkspaceDir $name
        if (Test-Path $path) {
            Copy-Item $path -Destination $staging
        }
    }

    New-Item -ItemType Directory -Path $OutputDir -Force | Out-Null
    if (Test-Path $zipPath) {
        Remove-Item $zipPath -Force
    }
    Compress-Archive -Path (Join-Path $staging "*") -DestinationPath $zipPath -CompressionLevel Optimal
    Write-Host "Created release package: $zipPath"
}
finally {
    Remove-Item $staging -Recurse -Force -ErrorAction SilentlyContinue
}
