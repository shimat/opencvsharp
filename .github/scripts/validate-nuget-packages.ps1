$ErrorActionPreference = 'Stop'

$requiredPackages = [ordered]@{
    windows = @(
        'OpenCvSharp5.5.*.nupkg'
        'OpenCvSharp5.GdipExtensions.*.nupkg'
        'OpenCvSharp5.WpfExtensions.*.nupkg'
        'OpenCvSharp5.AvaloniaExtensions.*.nupkg'
        'OpenCvSharp5.runtime.win.[0-9]*.nupkg'
        'OpenCvSharp5.runtime.win-arm64.[0-9]*.nupkg'
        'OpenCvSharp5.runtime.win-arm64.slim.*.nupkg'
        'OpenCvSharp5.runtime.win.slim.*.nupkg'
        'OpenCvSharp5.Windows.[0-9]*.nupkg'
        'OpenCvSharp5.Windows.Slim.*.nupkg'
    )
    'linux-arm64' = @(
        'OpenCvSharp5.runtime.linux-arm.*.nupkg'
        'OpenCvSharp5.runtime.linux-arm64.*.nupkg'
    )
    wasm = @('OpenCvSharp5.runtime.wasm.*.nupkg')
    manylinux = @(
        'OpenCvSharp5.official.runtime.linux-x64.[0-9]*.nupkg'
        'OpenCvSharp5.official.runtime.linux-x64.headless.*.nupkg'
        'OpenCvSharp5.official.runtime.linux-x64.slim.*.nupkg'
        'OpenCvSharp5.official.runtime.linux-arm64.[0-9]*.nupkg'
        'OpenCvSharp5.official.runtime.linux-arm64.headless.*.nupkg'
        'OpenCvSharp5.official.runtime.linux-arm64.slim.*.nupkg'
    )
    macos = @(
        'OpenCvSharp5.runtime.osx.x64.*.nupkg'
        'OpenCvSharp5.runtime.osx.arm64.*.nupkg'
    )
}

# Depth 3 includes files at depth 4 relative to the working directory.
$packages = @(Get-ChildItem -LiteralPath . -Depth 3 -File -Force |
    Where-Object { $_.Name -clike '*.nupkg' })
$skipPlatforms = $env:SKIP_PLATFORMS -split ','
$failed = 0

foreach ($platform in $requiredPackages.Keys) {
    if ($platform -ne 'windows' -and $skipPlatforms -ccontains $platform) {
        Write-Output "skip_platforms: skipping $platform package checks"
        continue
    }

    foreach ($pattern in $requiredPackages[$platform]) {
        if ($packages.Name -clike $pattern) {
            Write-Output "OK: $pattern"
        } else {
            Write-Output "MISSING: $pattern"
            $failed++
        }
    }
}

if ($failed -gt 0) {
    Write-Output ''
    Write-Output "ERROR: $failed package validation issue(s). Detected .nupkg files:"
    $packages.FullName
    exit 1
}
