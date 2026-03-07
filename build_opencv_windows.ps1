# Build OpenCV from source for Windows x64 development.
# Output: opencv_artifacts/ (include/ + lib/ + bin/)
#
# Prerequisites:
#   - Visual Studio 2022 or 2026 Build Tools (with "Desktop development with C++" workload; VS 2019 is not supported)
#   - CMake 3.20+  (available in PATH)
#   - Git          (available in PATH, with submodules initialized)
#   - vcpkg        (available in PATH or VCPKG_INSTALLATION_ROOT set)
#
# Usage:
#   .\build_opencv_windows.ps1
#   .\build_opencv_windows.ps1 -Jobs 8
#
# Before first run, initialize submodules if not already done:
#   git submodule update --init --recursive

param(
    [int]$Jobs = 4
)

$ErrorActionPreference = "Stop"
$RepoRoot = $PSScriptRoot

function Require-Command($name) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Required command '$name' not found in PATH."
    }
}

if (-not (Get-Command cmake -ErrorAction SilentlyContinue)) {
    Write-Error @"
cmake was not found in PATH.

To fix this, choose one of the following:
  1. Install CMake via winget:
       winget install Kitware.CMake
     Then reopen this terminal so PATH is updated.
  2. Install CMake 3.20+ from https://cmake.org/download/ and add it to PATH.
  3. Launch this script from a developer shell that includes cmake in PATH.
"@
    exit 1
}
Require-Command git

# ---------------------------------------------------------------------------
# Verify submodules are present
# ---------------------------------------------------------------------------
if (-not (Test-Path "$RepoRoot/opencv/CMakeLists.txt")) {
    throw "opencv submodule not found. Run: git submodule update --init --recursive"
}
if (-not (Test-Path "$RepoRoot/opencv_contrib/modules")) {
    throw "opencv_contrib submodule not found. Run: git submodule update --init --recursive"
}

$OpenCvVersion = (git -C "$RepoRoot/opencv" describe --tags --exact-match 2>$null)
if (-not $OpenCvVersion) { $OpenCvVersion = (git -C "$RepoRoot/opencv" rev-parse --short HEAD) }
Write-Host "OpenCV version: $OpenCvVersion"

# ---------------------------------------------------------------------------
# Detect Visual Studio generator via vswhere
# ---------------------------------------------------------------------------
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
if (-not (Test-Path $vswhere)) {
    throw "vswhere.exe not found at '$vswhere'. Install Visual Studio or Build Tools first."
}
$vsInfo = & $vswhere -latest -products * -requires Microsoft.VisualStudio.Component.VC.Tools.x86.x64 -format json 2>$null | ConvertFrom-Json
if (-not $vsInfo) {
    throw "No Visual Studio installation with C++ tools found. Install 'Desktop development with C++' workload."
}
$vsMajor = [int]($vsInfo.installationVersion.Split('.')[0])
$generatorMap = @{
    17 = "Visual Studio 17 2022"
    18 = "Visual Studio 18 2026"
}
$vsGenerator = $generatorMap[$vsMajor]
if (-not $vsGenerator) {
    throw "Unsupported Visual Studio major version: $vsMajor (from '$($vsInfo.installationVersion)'). Visual Studio 2022 or 2026 is required."
}
Write-Host "Using generator: $vsGenerator ($($vsInfo.displayName))"

# ---------------------------------------------------------------------------
# Configure
# ---------------------------------------------------------------------------
$buildDir   = "$RepoRoot/opencv/build-vs$vsMajor"
$installDir = "$RepoRoot/opencv_artifacts"

# ---------------------------------------------------------------------------
# Resolve Tesseract prefix via vcpkg
# ---------------------------------------------------------------------------
$vcpkgRoot = $env:VCPKG_INSTALLATION_ROOT
if (-not $vcpkgRoot) {
    $vcpkgCmd = Get-Command vcpkg -ErrorAction SilentlyContinue
    if ($vcpkgCmd) { $vcpkgRoot = Split-Path $vcpkgCmd.Source }
}
if (-not $vcpkgRoot) {
    Write-Error @"
vcpkg was not found.

Install vcpkg and add it to PATH:
  git clone https://github.com/microsoft/vcpkg C:\vcpkg
  C:\vcpkg\bootstrap-vcpkg.bat
  # Then add C:\vcpkg to PATH, or set:
  #   `$env:VCPKG_INSTALLATION_ROOT = 'C:\vcpkg'
"@
    exit 1
}
$vcpkgToolchain = "$vcpkgRoot/scripts/buildsystems/vcpkg.cmake"
$vcpkgInstalledDir = "$RepoRoot/vcpkg_installed"
Write-Host "Using vcpkg toolchain: $vcpkgToolchain"

Write-Host "Configuring OpenCV $OpenCvVersion ..."
cmake `
    -C "$RepoRoot/cmake/opencv_build_options.cmake" `
    -S "$RepoRoot/opencv" `
    -B "$buildDir" `
    -G "$vsGenerator" -A x64 `
    -D "CMAKE_TOOLCHAIN_FILE=$vcpkgToolchain" `
    -D "VCPKG_TARGET_TRIPLET=x64-windows-static" `
    -D "VCPKG_INSTALLED_DIR=$vcpkgInstalledDir" `
    -D "VCPKG_OVERLAY_TRIPLETS=$RepoRoot/cmake/triplets" `
    -D "OPENCV_EXTRA_MODULES_PATH=$RepoRoot/opencv_contrib/modules" `
    -D "CMAKE_INSTALL_PREFIX=$installDir"

# ---------------------------------------------------------------------------
# Build + Install
# ---------------------------------------------------------------------------
Write-Host "Building OpenCV (this takes 30-60 minutes on first run) ..."
cmake --build "$buildDir" --config Release -j $Jobs
cmake --install "$buildDir" --config Release

Write-Host ""
Write-Host "Done. OpenCV installed to: $installDir"
Write-Host ""
Write-Host "Next step — configure and build OpenCvSharpExtern:"
Write-Host "  cmake -S src -B src\build -G `"$vsGenerator`" -A x64 ``"
Write-Host "        -D `"CMAKE_PREFIX_PATH=`$PWD\opencv_artifacts`" ``"
Write-Host "        -D CMAKE_TOOLCHAIN_FILE=`"$vcpkgToolchain`" ``"
Write-Host "        -D VCPKG_TARGET_TRIPLET=x64-windows-static ``"
Write-Host "        -D `"VCPKG_INSTALLED_DIR=`$PWD\vcpkg_installed`" ``"
Write-Host "        -D `"VCPKG_OVERLAY_TRIPLETS=`$PWD\cmake\triplets`""
Write-Host "  cmake --build src\build --config Release"
