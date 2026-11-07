<#
.SYNOPSIS
    Generates a best-effort SPDX 2.3 SBOM and a THIRD-PARTY-NOTICES.txt for one Windows native runtime package.

.DESCRIPTION
    OpenCvSharpExtern.dll is a single DLL that statically links OpenCV, opencv_contrib, libraries that OpenCV
    bundles (Intel IPP ICV/IW, protobuf, ...) and vcpkg packages (Tesseract, Leptonica, image codecs, ...).
    This script works out which of those actually ended up in one particular build of the DLL and records them
    with versions, sources and license information:

      * The MSVC linker map (written when OpenCvSharpExtern is configured with
        -D OPENCVSHARP_GENERATE_LINKER_MAP=ON) lists every object file the linker pulled in, as
        <library>:<object>. A static library whose objects were all left out does not appear at all.
      * Each library is attributed to a component:
          - opencv_<module>*.lib            -> OpenCV, or opencv_contrib if opencv_contrib/modules/<module> exists
          - a library installed by vcpkg    -> that vcpkg port (vcpkg_installed/vcpkg/info/*.list); version,
                                               declared license and upstream source come from the port's
                                               share/<port>/vcpkg.spdx.json
          - a library OpenCV bundles        -> a known opencv/3rdparty component (table below)
          - the static MSVC C/C++ runtime, and Windows import libraries (which only add DLL imports)
          - anything else                   -> reported as unresolved, never guessed
      * License texts come from vcpkg's share/<port>/copyright files, the OpenCV / opencv_contrib LICENSE files
        and the license files OpenCV installs into etc/licenses.

    KNOWN GAPS - the output is an inventory aid, not a complete or authoritative bill of materials:
      * Code that OpenCV compiles directly into its module libraries (sources vendored inside a module,
        generated protobuf code, header-only libraries such as flatbuffers or the OpenCL headers) never shows
        up as a separate library in the map. It is covered only as far as OpenCV's own etc/licenses files cover
        it; those files are reproduced in THIRD-PARTY-NOTICES.txt even when no component can be matched.
      * License values are what vcpkg port metadata or upstream declare. They are not reviewed conclusions, so
        licenseConcluded is always NOASSERTION.
      * Prebuilt binaries shipped next to the DLL (the FFmpeg videoio plugin) are recorded with hashes and the
        license files OpenCV ships for them, but their own dependencies are not enumerated.
      * The result describes exactly one build. It cannot be reconstructed for releases built before this
        script existed (for example the OpenCvSharp4 4.11.x packages, which were built from shimat/opencv_files).
      * It is not legal advice.

    Outputs, all under -OutputDir:
      sbom/<PackageId>.spdx.json   SPDX 2.3 document (packed into the .nupkg)
      THIRD-PARTY-NOTICES.txt      component list plus license texts (packed into the .nupkg)
      licenses/                    license files that are not plain text, e.g. .rtf/.htm (packed into the .nupkg)
      linker-inventory.txt         every linked library and object file with its component (CI artifact only)

    Compatible with Windows PowerShell 5.1 and PowerShell 7.

.EXAMPLE
    ./scripts/generate_sbom.ps1 -PackageId OpenCvSharp5.runtime.win -PackageVersion 5.0.0.20261107 `
        -RuntimeIdentifier win-x64 -Triplet x64-windows-static `
        -NativeBinary src/build/OpenCvSharpExtern/Release/OpenCvSharpExtern.dll `
        -LinkerMap src/build/OpenCvSharpExtern/OpenCvSharpExtern.map `
        -OpenCvInstallDir opencv_artifacts -VcpkgInstalledDir vcpkg_installed `
        -AdditionalBinaries opencv_artifacts/x64/vc18/bin/opencv_videoio_ffmpeg500_64.dll `
        -OutputDir sbom/win-x64
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)] [string] $PackageId,
    [Parameter(Mandatory = $true)] [string] $PackageVersion,
    [Parameter(Mandatory = $true)] [string] $RuntimeIdentifier,
    [Parameter(Mandatory = $true)] [string] $NativeBinary,
    [Parameter(Mandatory = $true)] [string] $LinkerMap,
    [Parameter(Mandatory = $true)] [string] $OpenCvInstallDir,
    [Parameter(Mandatory = $true)] [string] $VcpkgInstalledDir,
    [Parameter(Mandatory = $true)] [string] $Triplet,
    [Parameter(Mandatory = $true)] [string] $OutputDir,
    # Prebuilt binaries packed next to the DLL in runtimes/<rid>/native (e.g. the FFmpeg videoio plugin).
    [string[]] $AdditionalBinaries = @(),
    # OpenCvSharpExtern CMake options that differ from the defaults (e.g. NO_CONTRIB=ON for the slim build).
    [string[]] $BuildOptions = @(),
    [string] $RepoRoot = (Split-Path $PSScriptRoot -Parent),
    # Defaults to <RepoRoot>/cmake/opencv_build_options.cmake.
    [string] $OpenCvBuildOptionsFile = '',
    # Fail instead of warning when a linked library cannot be attributed to a component.
    [switch] $FailOnUnresolved
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# ---------------------------------------------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------------------------------------------

function Resolve-FullPath([string] $Path) {
    return $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($Path)
}

function Get-NormalizedPath([string] $Path) {
    return [System.IO.Path]::GetFullPath($Path).TrimEnd('\', '/').Replace('/', '\')
}

function Assert-File([string] $Path, [string] $What) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) { throw "$What not found: $Path" }
}

function Get-JsonProperty($Object, [string] $Name) {
    if ($null -eq $Object) { return $null }
    $property = $Object.PSObject.Properties[$Name]
    if ($null -eq $property) { return $null }
    return $property.Value
}

function Read-TextFile([string] $Path) {
    # File.ReadAllText detects a BOM and otherwise assumes UTF-8 (Get-Content -Raw assumes ANSI on PowerShell 5.1).
    return [System.IO.File]::ReadAllText($Path)
}

function Write-TextFile([string] $Path, [string] $Content) {
    $directory = Split-Path -Parent $Path
    if ($directory) { New-Item -ItemType Directory -Force -Path $directory | Out-Null }
    [System.IO.File]::WriteAllText($Path, $Content, (New-Object System.Text.UTF8Encoding($false)))
}

function Get-GitCommit([string] $Path) {
    # Returns HEAD of the repository whose top level is exactly $Path. An uninitialized submodule directory would
    # otherwise silently report the parent repository's commit.
    if (-not (Test-Path -LiteralPath $Path -PathType Container)) { return $null }
    $ErrorActionPreference = 'Continue'
    try {
        $topLevel = & git -C $Path rev-parse --show-toplevel 2>$null
        if ($LASTEXITCODE -ne 0 -or -not $topLevel) { return $null }
        if ((Get-NormalizedPath "$topLevel") -ne (Get-NormalizedPath $Path)) { return $null }
        $sha = & git -C $Path rev-parse HEAD 2>$null
        if ($LASTEXITCODE -ne 0 -or -not $sha) { return $null }
        return "$sha".Trim()
    }
    finally {
        # A failed probe must not leak a non-zero $LASTEXITCODE: GitHub's pwsh shell exits with it.
        $global:LASTEXITCODE = 0
    }
}

function Get-Checksums([string] $Path) {
    return @(
        [ordered]@{ algorithm = 'SHA1'; checksumValue = (Get-FileHash -LiteralPath $Path -Algorithm SHA1).Hash.ToLowerInvariant() },
        [ordered]@{ algorithm = 'SHA256'; checksumValue = (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant() }
    )
}

function ConvertTo-SpdxId([string] $Prefix, [string] $Value) {
    return "SPDXRef-$Prefix-" + ($Value -replace '[^A-Za-z0-9.\-]+', '-')
}

function Get-GitHubPurl([string] $DownloadLocation) {
    # git+https://github.com/<owner>/<repo>[.git]@<ref>  ->  pkg:github/<owner>/<repo>@<ref>
    if ($DownloadLocation -match '^git\+https://github\.com/(?<owner>[^/]+)/(?<repo>[^/@#]+?)(?:\.git)?@(?<ref>[^#\s]+)$') {
        return 'pkg:github/{0}/{1}@{2}' -f $Matches.owner.ToLowerInvariant(), $Matches.repo.ToLowerInvariant(), $Matches.ref
    }
    return $null
}

function Write-BuildWarning([string] $Message) {
    if ($env:GITHUB_ACTIONS -eq 'true') { Write-Host "::warning title=SBOM::$Message" } else { Write-Warning $Message }
}

function Read-LinkerMap([string] $Path) {
    # MSVC /MAP format, "Publics by Value" and "Static symbols" sections:
    #  0001:00000e00       ?used_fn@@YAHH@Z           0000000180001e00 f   mylib:a.obj
    #  0002:00000000       __imp_GetTickCount         0000000180012000     kernel32:KERNEL32.dll
    #  0001:00000000       api                        0000000180001000 f   dll.obj            (own object file)
    $libraries = @{}
    $ownObjects = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
    $inSymbols = $false
    foreach ($line in [System.IO.File]::ReadLines($Path)) {
        if (-not $inSymbols) {
            if ($line -match '\bLib:Object\s*$') { $inSymbols = $true }
            continue
        }
        if ($line -notmatch '^\s*[0-9A-Fa-f]{4}:[0-9A-Fa-f]{8}\s+\S+\s+[0-9A-Fa-f]{8,16}\s+(?:[fi]\s+)*(?<source>\S.*?)\s*$') { continue }
        $source = $Matches.source
        if ($source.StartsWith('<')) { continue }    # <absolute>, <common>, <linker-defined>
        $colon = $source.IndexOf(':')
        if ($colon -le 0 -or $source -match '^[A-Za-z]:\\') {
            $leaf = [System.IO.Path]::GetFileName($source)
            if (-not $leaf.EndsWith('.exp', [System.StringComparison]::OrdinalIgnoreCase)) { [void]$ownObjects.Add($leaf) }
            continue
        }
        $library = [System.IO.Path]::GetFileName($source.Substring(0, $colon))
        if ($library.EndsWith('.lib', [System.StringComparison]::OrdinalIgnoreCase)) { $library = $library.Substring(0, $library.Length - 4) }
        $key = $library.ToLowerInvariant()
        if (-not $libraries.ContainsKey($key)) {
            $libraries[$key] = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
        }
        [void]$libraries[$key].Add($source.Substring($colon + 1))
    }
    if (-not $inSymbols) { throw "No 'Publics by Value ... Lib:Object' section found in linker map $Path" }
    return [pscustomobject]@{ Libraries = $libraries; OwnObjects = $ownObjects }
}

function Read-VcpkgIndex([string] $InstalledDir, [string] $Triplet) {
    # vcpkg_installed/vcpkg/info/<port>_<version>_<triplet>.list lists every file a port installed.
    $libraryToPort = @{}
    $portVersions = @{}
    $infoDir = Join-Path $InstalledDir 'vcpkg/info'
    if (-not (Test-Path -LiteralPath $infoDir)) {
        Write-BuildWarning "vcpkg info directory not found: $infoDir"
        return [pscustomobject]@{ LibraryToPort = $libraryToPort; PortVersions = $portVersions }
    }
    $libPattern = '^' + [regex]::Escape($Triplet) + '/lib/(?<name>[^/]+)\.lib$'
    foreach ($list in @(Get-ChildItem -LiteralPath $infoDir -Filter "*_$Triplet.list")) {
        $stem = $list.BaseName
        $firstUnderscore = $stem.IndexOf('_')
        $port = $stem.Substring(0, $firstUnderscore)
        $versionLength = $stem.Length - $firstUnderscore - 1 - $Triplet.Length - 1
        if ($versionLength -gt 0) { $portVersions[$port] = $stem.Substring($firstUnderscore + 1, $versionLength) }
        foreach ($entry in [System.IO.File]::ReadLines($list.FullName)) {
            if ($entry -match $libPattern) { $libraryToPort[$Matches.name.ToLowerInvariant()] = $port }
        }
    }
    return [pscustomobject]@{ LibraryToPort = $libraryToPort; PortVersions = $portVersions }
}

function Get-OpenCvVersion([string] $OpenCvSource) {
    $header = Join-Path $OpenCvSource 'modules/core/include/opencv2/core/version.hpp'
    if (-not (Test-Path -LiteralPath $header)) { return $null }
    $text = Read-TextFile $header
    $parts = @()
    foreach ($name in 'MAJOR', 'MINOR', 'REVISION') {
        if ($text -notmatch "#define\s+CV_VERSION_$name\s+(\d+)") { return $null }
        $parts += $Matches[1]
    }
    $status = ''
    if ($text -match '#define\s+CV_VERSION_STATUS\s+"([^"]*)"') { $status = $Matches[1] }
    return ($parts -join '.') + $status
}

function Find-InFile([string] $Path, [string] $Pattern) {
    if (-not (Test-Path -LiteralPath $Path)) { return $null }
    $match = [regex]::Match((Read-TextFile $Path), $Pattern)
    if ($match.Success) { return $match } else { return $null }
}

# ---------------------------------------------------------------------------------------------------------------
# Inputs
# ---------------------------------------------------------------------------------------------------------------

$RepoRoot = Resolve-FullPath $RepoRoot
$NativeBinary = Resolve-FullPath $NativeBinary
$LinkerMap = Resolve-FullPath $LinkerMap
$OpenCvInstallDir = Resolve-FullPath $OpenCvInstallDir
$VcpkgInstalledDir = Resolve-FullPath $VcpkgInstalledDir
$OutputDir = Resolve-FullPath $OutputDir
if (-not $OpenCvBuildOptionsFile) { $OpenCvBuildOptionsFile = Join-Path $RepoRoot 'cmake/opencv_build_options.cmake' }
$AdditionalBinaries = @($AdditionalBinaries | Where-Object { $_ } | ForEach-Object { Resolve-FullPath $_ })

Assert-File $NativeBinary 'Native binary'
Assert-File $LinkerMap 'Linker map (configure OpenCvSharpExtern with -D OPENCVSHARP_GENERATE_LINKER_MAP=ON)'
foreach ($binary in $AdditionalBinaries) { Assert-File $binary 'Additional binary' }

$openCvSource = Join-Path $RepoRoot 'opencv'
$contribSource = Join-Path $RepoRoot 'opencv_contrib'
$contribModules = Join-Path $contribSource 'modules'
$nativePackagePath = "runtimes/$RuntimeIdentifier/native"

$repositoryUrl = 'https://github.com/shimat/opencvsharp'
if ($env:GITHUB_SERVER_URL -and $env:GITHUB_REPOSITORY) { $repositoryUrl = "$($env:GITHUB_SERVER_URL)/$($env:GITHUB_REPOSITORY)" }

$openCvVersion = Get-OpenCvVersion $openCvSource
$openCvCommit = Get-GitCommit $openCvSource
$contribCommit = Get-GitCommit $contribSource
$opencvsharpCommit = Get-GitCommit $RepoRoot

$vcpkgBaseline = $null
$vcpkgManifest = Join-Path $RepoRoot 'vcpkg.json'
if (Test-Path -LiteralPath $vcpkgManifest) { $vcpkgBaseline = Get-JsonProperty (Read-TextFile $vcpkgManifest | ConvertFrom-Json) 'builtin-baseline' }

$openCvOptions = [ordered]@{}
if (Test-Path -LiteralPath $OpenCvBuildOptionsFile) {
    foreach ($m in [regex]::Matches((Read-TextFile $OpenCvBuildOptionsFile), '(?m)^\s*set\(\s*(\w+)\s+(\S+)\s+CACHE\b')) {
        $openCvOptions[$m.Groups[1].Value] = $m.Groups[2].Value
    }
}
$nonFree = 'unknown'
if ($openCvOptions.Contains('OPENCV_ENABLE_NONFREE')) { $nonFree = $openCvOptions['OPENCV_ENABLE_NONFREE'] }

$map = Read-LinkerMap $LinkerMap
$vcpkg = Read-VcpkgIndex $VcpkgInstalledDir $Triplet

$openCvLibraries = @{}
foreach ($lib in @(Get-ChildItem -LiteralPath $OpenCvInstallDir -Recurse -File -Filter '*.lib' -ErrorAction SilentlyContinue)) {
    $openCvLibraries[$lib.BaseName.ToLowerInvariant()] = $lib.FullName
}

$openCvLicenseDir = Join-Path $OpenCvInstallDir 'etc/licenses'
if (-not (Test-Path -LiteralPath $openCvLicenseDir)) {
    $openCvLicenseDir = @(Get-ChildItem -LiteralPath $OpenCvInstallDir -Recurse -Directory -Filter 'licenses' -ErrorAction SilentlyContinue |
        Select-Object -First 1 -ExpandProperty FullName)
    if ($openCvLicenseDir.Count -gt 0) { $openCvLicenseDir = $openCvLicenseDir[0] } else { $openCvLicenseDir = $null }
}
if (-not $openCvLicenseDir) { Write-BuildWarning "No licenses directory found under $OpenCvInstallDir" }

# Libraries that OpenCV builds or downloads itself (opencv/3rdparty). LicenseFiles are the name patterns that
# OpenCV's ocv_install_3rdparty_licenses() uses in etc/licenses. Versions are probed from the OpenCV sources
# where that is cheap; otherwise they stay unknown.
$ippicvCmake = Join-Path $openCvSource '3rdparty/ippicv/ippicv.cmake'
$ippVersionMatch = Find-InFile $ippicvCmake 'ippicv_(\d{4}\.\d+(?:\.\d+)?)_win_intel64_(\d{8})'
$ippVersion = $null
if ($ippVersionMatch) { $ippVersion = '{0} ({1})' -f $ippVersionMatch.Groups[1].Value, $ippVersionMatch.Groups[2].Value }
$ippCommitMatch = Find-InFile $ippicvCmake 'IPPICV_COMMIT\s+"?([0-9a-f]{7,40})'
$ippDownload = 'NOASSERTION'
if ($ippCommitMatch) { $ippDownload = 'git+https://github.com/opencv/opencv_3rdparty@' + $ippCommitMatch.Groups[1].Value }
$protobufVersion = $null
$protobufMatch = Find-InFile (Join-Path $openCvSource '3rdparty/protobuf/src/google/protobuf/stubs/common.h') '#define\s+GOOGLE_PROTOBUF_VERSION\s+(\d+)'
if ($protobufMatch) {
    $n = [int]$protobufMatch.Groups[1].Value
    $protobufVersion = '{0}.{1}.{2}' -f [math]::Floor($n / 1000000), ([math]::Floor($n / 1000) % 1000), ($n % 1000)
}

$bundledTable = @(
    @{ Pattern = '^ippicv'; Id = 'ippicv'; Name = 'Intel IPP ICV (Integrated Performance Primitives subset distributed for OpenCV)'; Supplier = 'Organization: Intel Corporation'; Version = $ippVersion; DownloadLocation = $ippDownload; LicenseFiles = @('ippicv-*'); Comment = 'Proprietary Intel license, not Apache-2.0. See the ippicv-* license files.' },
    @{ Pattern = '^ippiw'; Id = 'ippiw'; Name = 'Intel IPP Integration Wrappers (IPP IW)'; Supplier = 'Organization: Intel Corporation'; Version = $ippVersion; DownloadLocation = $ippDownload; LicenseFiles = @('ippiw-*'); Comment = 'Shipped in the same package as IPP ICV. See the ippiw-* license files.' },
    @{ Pattern = '^ittnotify'; Id = 'ittnotify'; Name = 'Intel ITT API (ittnotify)'; Supplier = 'Organization: Intel Corporation'; License = 'BSD-3-Clause OR GPL-2.0-only'; LicenseFiles = @('ittnotify-*') },
    @{ Pattern = '^libprotobuf'; Id = 'protobuf'; Name = 'Protocol Buffers (copy bundled with OpenCV)'; Supplier = 'Organization: Google LLC'; Version = $protobufVersion; License = 'BSD-3-Clause'; LicenseFiles = @('protobuf-*') },
    @{ Pattern = '^libopenjp2'; Id = 'openjpeg'; Name = 'OpenJPEG (copy bundled with OpenCV)'; License = 'BSD-2-Clause'; LicenseFiles = @('openjpeg-*') },
    @{ Pattern = '^quirc'; Id = 'quirc'; Name = 'quirc (copy bundled with OpenCV)'; License = 'ISC'; LicenseFiles = @('quirc-*') },
    @{ Pattern = '^(ilmimf|openexr)'; Id = 'openexr'; Name = 'OpenEXR (copy bundled with OpenCV)'; License = 'BSD-3-Clause'; LicenseFiles = @('openexr-*') },
    @{ Pattern = '^libspng'; Id = 'libspng'; Name = 'libspng (copy bundled with OpenCV)'; License = 'BSD-2-Clause'; LicenseFiles = @('libspng-*') },
    @{ Pattern = '^mlas'; Id = 'mlas'; Name = 'MLAS (copy bundled with OpenCV dnn)'; Supplier = 'Organization: Microsoft Corporation'; License = 'MIT'; LicenseFiles = @('mlas-*') },
    @{ Pattern = '^kleidicv'; Id = 'kleidicv'; Name = 'KleidiCV (copy bundled with OpenCV)'; Supplier = 'Organization: Arm Limited'; License = 'Apache-2.0'; LicenseFiles = @('kleidicv-*') }
)
# License file patterns for components that are not static libraries.
$ffmpegLicenseFiles = @('ffmpeg-*')

$runtimePattern = '^(libcmt|libcpmt1?|libconcrt|libvcruntime|libucrt|oldnames|legacy_stdio_definitions|msvcrt|msvcprt|vcruntime|ucrt|concrt|delayimp)d?$'
$sdkStaticPattern = '^(uuid|strmiids|mfuuid|dxguid|wbemuuid|comsuppw?|ksguid|ksuser)$'

# ---------------------------------------------------------------------------------------------------------------
# Components
# ---------------------------------------------------------------------------------------------------------------

$components = [ordered]@{}
$kindOrder = @{ 'opencvsharp' = 0; 'opencv' = 1; 'opencv_contrib' = 2; 'opencv-bundled' = 3; 'vcpkg' = 4; 'prebuilt' = 5; 'msvc-runtime' = 6; 'unresolved' = 7 }

function Get-Component([string] $Id, [hashtable] $Properties) {
    if (-not $script:components.Contains($Id)) {
        $component = [ordered]@{
            Id = $Id; Kind = 'unresolved'; Name = $Id; Version = $null; Supplier = 'NOASSERTION'; DownloadLocation = 'NOASSERTION'
            Homepage = $null; License = 'NOASSERTION'; Purl = $null; Comment = $null
            LicenseFiles = New-Object System.Collections.Generic.List[string]
            LicenseFilePatterns = @()
            Libraries = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
            ObjectCount = 0
        }
        foreach ($key in $Properties.Keys) {
            if ($key -eq 'LicenseFiles') { foreach ($f in $Properties[$key]) { if ($f -and (Test-Path -LiteralPath $f)) { $component.LicenseFiles.Add($f) } } }
            elseif ($null -ne $Properties[$key]) { $component[$key] = $Properties[$key] }
        }
        $script:components[$Id] = $component
    }
    return $script:components[$Id]
}

function Get-OpenCvComponent([bool] $Contrib) {
    if ($Contrib) {
        $download = 'NOASSERTION'
        if ($contribCommit) { $download = "git+https://github.com/opencv/opencv_contrib@$contribCommit" }
        return Get-Component 'opencv_contrib' @{
            Kind = 'opencv_contrib'; Name = 'opencv_contrib'; Version = $openCvVersion; Supplier = 'Organization: OpenCV'
            DownloadLocation = $download; Purl = (Get-GitHubPurl $download); Homepage = 'https://github.com/opencv/opencv_contrib'; License = 'Apache-2.0'
            LicenseFiles = @((Join-Path $contribSource 'LICENSE'))
            Comment = "Built with OPENCV_ENABLE_NONFREE=$nonFree. Non-free (patent-encumbered) implementations live in contrib modules; the linked libraries and objects are listed in linker-inventory.txt."
        }
    }
    $download = 'NOASSERTION'
    if ($openCvCommit) { $download = "git+https://github.com/opencv/opencv@$openCvCommit" }
    $optionText = ($openCvOptions.Keys | ForEach-Object { "$_=$($openCvOptions[$_])" }) -join ', '
    return Get-Component 'opencv' @{
        Kind = 'opencv'; Name = 'OpenCV'; Version = $openCvVersion; Supplier = 'Organization: OpenCV'
        DownloadLocation = $download; Purl = (Get-GitHubPurl $download); Homepage = 'https://opencv.org'; License = 'Apache-2.0'
        LicenseFiles = @((Join-Path $openCvSource 'LICENSE'), (Join-Path $openCvSource 'COPYRIGHT'))
        Comment = "Static build. CMake initial cache ($([System.IO.Path]::GetFileName($OpenCvBuildOptionsFile))): $optionText. Platform-specific -D options passed by the workflow are not included here."
    }
}

function Get-VcpkgComponent([string] $Port) {
    $id = "vcpkg-$Port"
    if ($script:components.Contains($id)) { return $script:components[$id] }
    $shareDir = Join-Path $VcpkgInstalledDir "$Triplet/share/$Port"
    $version = $vcpkg.PortVersions[$Port]
    $license = 'NOASSERTION'
    $homepage = $null
    $download = 'NOASSERTION'
    $notes = New-Object System.Collections.Generic.List[string]
    $notes.Add("Installed by vcpkg (port '$Port', triplet $Triplet, builtin-baseline $vcpkgBaseline).")
    $spdxPath = Join-Path $shareDir 'vcpkg.spdx.json'
    if (Test-Path -LiteralPath $spdxPath) {
        $portDoc = Read-TextFile $spdxPath | ConvertFrom-Json
        $packages = @(Get-JsonProperty $portDoc 'packages')
        $portPackage = $packages | Where-Object { (Get-JsonProperty $_ 'SPDXID') -eq 'SPDXRef-port' } | Select-Object -First 1
        if ($portPackage) {
            $v = Get-JsonProperty $portPackage 'versionInfo'
            if ($v) { $version = $v }
            $homepage = Get-JsonProperty $portPackage 'homepage'
            foreach ($field in 'licenseDeclared', 'licenseConcluded') {
                $value = Get-JsonProperty $portPackage $field
                if ($value -and $value -ne 'NOASSERTION' -and $value -ne 'NONE') { $license = $value; break }
            }
        }
        $resources = @($packages | Where-Object { "$(Get-JsonProperty $_ 'SPDXID')" -like 'SPDXRef-resource-*' })
        foreach ($resource in $resources) {
            $location = Get-JsonProperty $resource 'downloadLocation'
            if (-not $location -or $location -eq 'NOASSERTION') { continue }
            if ($download -eq 'NOASSERTION') { $download = $location } else { $notes.Add("Additional source: $location") }
        }
    } else {
        $notes.Add('vcpkg.spdx.json not found; version taken from the vcpkg info file name.')
    }
    if ($license -like '*LicenseRef-*') {
        # A LicenseRef needs an extracted license text in the document; keep the value as a note instead.
        $notes.Add("Declared license (vcpkg): $license")
        $license = 'NOASSERTION'
    }
    return Get-Component $id @{
        Kind = 'vcpkg'; Name = $Port; Version = $version; DownloadLocation = $download; Purl = (Get-GitHubPurl $download)
        Homepage = $homepage; License = $license; LicenseFiles = @((Join-Path $shareDir 'copyright')); Comment = ($notes -join ' ')
    }
}

# OpenCvSharp's own object files
$opencvsharpDownload = 'NOASSERTION'
if ($opencvsharpCommit) { $opencvsharpDownload = "git+$repositoryUrl@$opencvsharpCommit" }
$opencvsharpComment = 'OpenCvSharpExtern (src/OpenCvSharpExtern).'
if (@($BuildOptions).Count -gt 0) { $opencvsharpComment += ' CMake options: ' + ($BuildOptions -join ', ') + '.' }
$opencvsharp = Get-Component 'opencvsharp' @{
    Kind = 'opencvsharp'; Name = 'OpenCvSharp'; Version = $PackageVersion; Supplier = 'Organization: OpenCvSharp'
    DownloadLocation = $opencvsharpDownload; Purl = (Get-GitHubPurl $opencvsharpDownload); Homepage = $repositoryUrl; License = 'Apache-2.0'
    LicenseFiles = @((Join-Path $RepoRoot 'LICENSE')); Comment = $opencvsharpComment
}
$opencvsharp.ObjectCount = $map.OwnObjects.Count

$inventory = New-Object System.Collections.Generic.List[object]
$systemImports = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
$unresolved = New-Object System.Collections.Generic.List[string]

foreach ($library in @($map.Libraries.Keys | Sort-Object)) {
    $objects = $map.Libraries[$library]
    $component = $null
    $label = $null

    if ($library -match '^opencv_(?<module>[a-z0-9_]+?)\d*$') {
        $isContrib = Test-Path -LiteralPath (Join-Path $contribModules $Matches.module)
        $component = Get-OpenCvComponent $isContrib
    }
    elseif ($vcpkg.LibraryToPort.ContainsKey($library)) {
        $component = Get-VcpkgComponent $vcpkg.LibraryToPort[$library]
    }
    else {
        $entry = $bundledTable | Where-Object { $library -match $_.Pattern } | Select-Object -First 1
        if ($entry) {
            $properties = @{ Kind = 'opencv-bundled'; License = 'NOASSERTION' }
            foreach ($key in $entry.Keys) { if ($key -ne 'Pattern' -and $key -ne 'Id' -and $key -ne 'LicenseFiles') { $properties[$key] = $entry[$key] } }
            $properties['LicenseFilePatterns'] = $entry.LicenseFiles
            $component = Get-Component "bundled-$($entry.Id)" $properties
        }
        elseif ($library -match $runtimePattern) {
            $component = Get-Component 'msvc-runtime' @{
                Kind = 'msvc-runtime'; Name = 'Microsoft C/C++ runtime libraries (static)'; Supplier = 'Organization: Microsoft Corporation'
                Comment = 'Static CRT/STL from the MSVC toolset and Windows SDK used for the build. Their terms are Microsoft license terms that have no SPDX identifier.'
            }
        }
        elseif (@($objects | Where-Object { -not $_.EndsWith('.dll', [System.StringComparison]::OrdinalIgnoreCase) }).Count -eq 0) {
            foreach ($o in $objects) { [void]$systemImports.Add($o) }
            $label = 'Windows import library (DLL imports only)'
        }
        elseif ($library -match $sdkStaticPattern) {
            $label = 'Windows SDK static library'
        }
        else {
            $hint = 'It was found neither in the vcpkg install tree nor among the libraries this script knows OpenCV to bundle.'
            if ($openCvLibraries.ContainsKey($library)) {
                $relative = $openCvLibraries[$library].Substring($OpenCvInstallDir.Length).TrimStart('\', '/').Replace('\', '/')
                $hint = "It is installed by the OpenCV build ($relative), probably from opencv/3rdparty, but is not in this script's table of known bundled libraries."
            }
            $component = Get-Component "unresolved-$library" @{
                Kind = 'unresolved'; Name = "$library.lib (not identified)"
                Comment = "Objects from this library are linked into the DLL. $hint"
            }
            $unresolved.Add($library)
        }
    }

    if ($component) {
        [void]$component.Libraries.Add("$library.lib")
        $component.ObjectCount += $objects.Count
        $label = $component.Name
    }
    $inventory.Add([pscustomobject]@{ Library = $library; Component = $label; Objects = $objects })
}

# Prebuilt binaries shipped next to the DLL
$prebuiltFiles = New-Object System.Collections.Generic.List[object]
foreach ($binary in $AdditionalBinaries) {
    $leaf = [System.IO.Path]::GetFileName($binary)
    if ($leaf -like 'opencv_videoio_ffmpeg*') {
        $commitMatch = Find-InFile (Join-Path $openCvSource '3rdparty/ffmpeg/ffmpeg.cmake') 'FFMPEG_BINARIES_COMMIT\s+"?([0-9a-f]{7,40})'
        $download = 'NOASSERTION'
        if ($commitMatch) { $download = 'git+https://github.com/opencv/opencv_3rdparty@' + $commitMatch.Groups[1].Value }
        $component = Get-Component 'ffmpeg' @{
            Kind = 'prebuilt'; Name = 'FFmpeg (opencv_videoio_ffmpeg plugin, prebuilt by OpenCV)'; Supplier = 'Organization: OpenCV'
            DownloadLocation = $download; Homepage = 'https://ffmpeg.org'; License = 'LGPL-2.1-or-later'; LicenseFilePatterns = $ffmpegLicenseFiles
            Comment = "Downloaded prebuilt by OpenCV's build (opencv/3rdparty/ffmpeg/ffmpeg.cmake), not compiled by this workflow. The declared license follows the license file OpenCV ships with it. The libraries statically linked into this plugin are not enumerated here."
        }
    } else {
        $component = Get-Component "prebuilt-$leaf" @{
            Kind = 'unresolved'; Name = "$leaf (prebuilt, not identified)"; Comment = 'Shipped next to OpenCvSharpExtern.dll; origin not identified by this script.'
        }
        $unresolved.Add($leaf)
    }
    [void]$component.Libraries.Add($leaf)
    $prebuiltFiles.Add([pscustomobject]@{ Path = $binary; Leaf = $leaf; Component = $component })
}

# License files installed by OpenCV: attach them to linked components, drop those of known components that are
# not linked into this binary, and keep everything else as unattributed (code vendored inside OpenCV modules).
$knownPatterns = @($bundledTable | ForEach-Object { $_.LicenseFiles }) + $ffmpegLicenseFiles
$unattributedLicenseFiles = New-Object System.Collections.Generic.List[string]
$omittedLicenseFiles = New-Object System.Collections.Generic.List[string]
if ($openCvLicenseDir) {
    foreach ($file in @(Get-ChildItem -LiteralPath $openCvLicenseDir -File | Sort-Object Name)) {
        $owner = $null
        foreach ($component in $components.Values) {
            foreach ($pattern in @($component.LicenseFilePatterns)) { if ($pattern -and $file.Name -like $pattern) { $owner = $component; break } }
            if ($owner) { break }
        }
        if ($owner) { $owner.LicenseFiles.Add($file.FullName); continue }
        $isKnown = @($knownPatterns | Where-Object { $file.Name -like $_ }).Count -gt 0
        if ($isKnown) { $omittedLicenseFiles.Add($file.Name) } else { $unattributedLicenseFiles.Add($file.FullName) }
    }
}

$orderedComponents = @($components.Values | Sort-Object @{ Expression = { $kindOrder[$_.Kind] } }, @{ Expression = { $_.Name } })
$contribLibraries = @()
if ($components.Contains('opencv_contrib')) { $contribLibraries = @($components['opencv_contrib'].Libraries) }

foreach ($library in $unresolved) {
    Write-BuildWarning "Could not attribute '$library' to a known component; it is recorded as unresolved in the SBOM."
}

# ---------------------------------------------------------------------------------------------------------------
# Output
# ---------------------------------------------------------------------------------------------------------------

foreach ($stale in 'sbom', 'licenses', 'THIRD-PARTY-NOTICES.txt', 'linker-inventory.txt') {
    $path = Join-Path $OutputDir $stale
    if (Test-Path -LiteralPath $path) { Remove-Item -LiteralPath $path -Recurse -Force }
}
New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null

$limitations = 'Best-effort inventory generated by scripts/generate_sbom.ps1 from the MSVC linker map of this build, vcpkg port metadata and the license files OpenCV installs. It is not guaranteed to be complete: code that OpenCV compiles directly into its module libraries (vendored sources, generated code, header-only libraries) is not identified as separate components, the dependencies of prebuilt binaries are not enumerated, and license values are declared values that have not been reviewed (licenseConcluded is NOASSERTION throughout). It is not legal advice.'
$contribSummary = 'none'
if ($contribLibraries.Count -gt 0) { $contribSummary = $contribLibraries -join ', ' }

# --- SPDX 2.3 ---------------------------------------------------------------------------------------------------
$rootId = 'SPDXRef-Package-NuGet'
$dllId = 'SPDXRef-File-' + ([System.IO.Path]::GetFileName($NativeBinary) -replace '[^A-Za-z0-9.\-]+', '-')
$packages = New-Object System.Collections.Generic.List[object]
$files = New-Object System.Collections.Generic.List[object]
$relationships = New-Object System.Collections.Generic.List[object]

$packages.Add([ordered]@{
    name = $PackageId
    SPDXID = $rootId
    versionInfo = $PackageVersion
    supplier = 'Organization: OpenCvSharp'
    downloadLocation = "https://www.nuget.org/packages/$PackageId/$PackageVersion"
    # true because the package CONTAINS the hashed native binaries below (SPDX forbids that with false).
    filesAnalyzed = $true
    homepage = $repositoryUrl
    licenseConcluded = 'NOASSERTION'
    licenseDeclared = 'Apache-2.0'
    copyrightText = 'NOASSERTION'
    primaryPackagePurpose = 'LIBRARY'
    externalRefs = @([ordered]@{ referenceCategory = 'PACKAGE-MANAGER'; referenceType = 'purl'; referenceLocator = "pkg:nuget/$PackageId@$PackageVersion" })
    comment = 'Apache-2.0 is the license of OpenCvSharp itself, as declared in the NuGet metadata. The native binaries in this package also contain the third-party components described in this document, under their own licenses.'
})
$relationships.Add([ordered]@{ spdxElementId = 'SPDXRef-DOCUMENT'; relationshipType = 'DESCRIBES'; relatedSpdxElement = $rootId })

$files.Add([ordered]@{
    fileName = "./$nativePackagePath/$([System.IO.Path]::GetFileName($NativeBinary))"
    SPDXID = $dllId
    fileTypes = @('BINARY')
    checksums = Get-Checksums $NativeBinary
    licenseConcluded = 'NOASSERTION'
    copyrightText = 'NOASSERTION'
    comment = "Built from OpenCvSharpExtern; statically links the components related to it by STATIC_LINK. OPENCV_ENABLE_NONFREE=$nonFree. opencv_contrib libraries with linked objects: $contribSummary."
})
$relationships.Add([ordered]@{ spdxElementId = $rootId; relationshipType = 'CONTAINS'; relatedSpdxElement = $dllId })

foreach ($prebuilt in $prebuiltFiles) {
    $fileId = 'SPDXRef-File-' + ($prebuilt.Leaf -replace '[^A-Za-z0-9.\-]+', '-')
    $files.Add([ordered]@{
        fileName = "./$nativePackagePath/$($prebuilt.Leaf)"
        SPDXID = $fileId
        fileTypes = @('BINARY')
        checksums = Get-Checksums $prebuilt.Path
        licenseConcluded = 'NOASSERTION'
        copyrightText = 'NOASSERTION'
    })
    $relationships.Add([ordered]@{ spdxElementId = $rootId; relationshipType = 'CONTAINS'; relatedSpdxElement = $fileId })
    $relationships.Add([ordered]@{ spdxElementId = $fileId; relationshipType = 'GENERATED_FROM'; relatedSpdxElement = (ConvertTo-SpdxId 'Package' $prebuilt.Component.Id) })
}

foreach ($component in $orderedComponents) {
    $spdxId = ConvertTo-SpdxId 'Package' $component.Id
    $package = [ordered]@{ name = $component.Name; SPDXID = $spdxId }
    if ($component.Version) { $package.versionInfo = "$($component.Version)" }
    $package.supplier = $component.Supplier
    $package.downloadLocation = $component.DownloadLocation
    $package.filesAnalyzed = $false
    if ($component.Homepage) { $package.homepage = $component.Homepage }
    $package.licenseConcluded = 'NOASSERTION'
    $package.licenseDeclared = $component.License
    $package.copyrightText = 'NOASSERTION'
    if ($component.Purl) {
        $package.externalRefs = @([ordered]@{ referenceCategory = 'PACKAGE-MANAGER'; referenceType = 'purl'; referenceLocator = $component.Purl })
    }
    $notes = @()
    if ($component.Comment) { $notes += $component.Comment }
    if ($component.Kind -ne 'prebuilt' -and $component.Libraries.Count -gt 0) {
        $notes += "Linked libraries: $(@($component.Libraries) -join ', ') ($($component.ObjectCount) object files)."
    }
    if ($component.Kind -eq 'opencv' -and $unattributedLicenseFiles.Count -gt 0) {
        $notes += 'OpenCV also installs license files for code vendored inside its modules: ' + (@($unattributedLicenseFiles | ForEach-Object { [System.IO.Path]::GetFileName($_) }) -join ', ') + '.'
    }
    if ($notes.Count -gt 0) { $package.comment = $notes -join ' ' }
    $packages.Add($package)
    if ($component.Kind -ne 'prebuilt') {
        $relationships.Add([ordered]@{ spdxElementId = $dllId; relationshipType = 'STATIC_LINK'; relatedSpdxElement = $spdxId })
    }
}

$creationComment = @()
if ($env:GITHUB_RUN_ID) { $creationComment += "Workflow run: $($env:GITHUB_SERVER_URL)/$($env:GITHUB_REPOSITORY)/actions/runs/$($env:GITHUB_RUN_ID)." }
if ($env:ImageOS) { $creationComment += "Runner image: $($env:ImageOS) $($env:ImageVersion)." }
if ($vcpkgBaseline) { $creationComment += "vcpkg builtin-baseline: $vcpkgBaseline." }
$creationInfo = [ordered]@{
    created = [DateTime]::UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", [System.Globalization.CultureInfo]::InvariantCulture)
    creators = @('Tool: opencvsharp-generate_sbom.ps1', 'Organization: OpenCvSharp')
}
if ($creationComment.Count -gt 0) { $creationInfo.comment = $creationComment -join ' ' }

$document = [ordered]@{
    spdxVersion = 'SPDX-2.3'
    dataLicense = 'CC0-1.0'
    SPDXID = 'SPDXRef-DOCUMENT'
    name = "$PackageId $PackageVersion ($RuntimeIdentifier)"
    documentNamespace = "$repositoryUrl/sbom/$PackageId/$PackageVersion/$([guid]::NewGuid())"
    creationInfo = $creationInfo
    comment = $limitations
    packages = $packages.ToArray()
    files = $files.ToArray()
    relationships = $relationships.ToArray()
}
$sbomPath = Join-Path $OutputDir "sbom/$PackageId.spdx.json"
Write-TextFile $sbomPath (($document | ConvertTo-Json -Depth 20) + "`n")

# --- THIRD-PARTY-NOTICES.txt ------------------------------------------------------------------------------------
$binaryExtensions = @('.rtf', '.htm', '.html', '.pdf', '.doc', '.docx')
$rule = '=' * 100
$notices = New-Object System.Text.StringBuilder
function Add-Notice([string] $Text = '') { [void]$script:notices.Append($Text).Append("`n") }

function Add-LicenseFile([string] $Path, [string] $ComponentId) {
    $leaf = [System.IO.Path]::GetFileName($Path)
    $text = $null
    if ($binaryExtensions -notcontains [System.IO.Path]::GetExtension($Path).ToLowerInvariant()) {
        $text = Read-TextFile $Path
        if ($text.IndexOf([char]0) -ge 0) { $text = $null }
    }
    if ($null -ne $text) {
        Add-Notice "----- $leaf -----"
        Add-Notice $text.Replace("`r`n", "`n").TrimEnd()
        Add-Notice
        return
    }
    # Files from OpenCV's etc/licenses already carry a component prefix (e.g. ippicv-EULA.rtf).
    $target = $leaf
    $fromOpenCv = $script:openCvLicenseDir -and $Path.StartsWith($script:openCvLicenseDir, [System.StringComparison]::OrdinalIgnoreCase)
    if (-not $fromOpenCv -and $ComponentId) { $target = "$ComponentId-$leaf" }
    $licensesDir = Join-Path $script:OutputDir 'licenses'
    New-Item -ItemType Directory -Force -Path $licensesDir | Out-Null
    Copy-Item -LiteralPath $Path -Destination (Join-Path $licensesDir $target) -Force
    Add-Notice "----- ${leaf} (not plain text, included as licenses/$target) -----"
    Add-Notice
}

$shippedBinaries = @([System.IO.Path]::GetFileName($NativeBinary)) + @($prebuiltFiles | ForEach-Object { $_.Leaf })
Add-Notice 'THIRD-PARTY SOFTWARE NOTICES AND INFORMATION'
Add-Notice "$PackageId $PackageVersion ($RuntimeIdentifier)"
Add-Notice
Add-Notice "This package ships $($shippedBinaries -join ', ') in $nativePackagePath. OpenCvSharpExtern.dll statically links OpenCV and the third-party components listed below. The list was generated from the linker map of this particular build; a machine-readable SPDX 2.3 document for the same build is included as sbom/$PackageId.spdx.json."
Add-Notice
Add-Notice "IMPORTANT: this list is generated automatically and is best-effort; it may be incomplete. Code that OpenCV compiles directly into its own module libraries, header-only libraries and the dependencies of prebuilt binaries are not identified individually (the license files OpenCV installs for such code are reproduced at the end). License identifiers are as declared upstream and have not been reviewed. This is not legal advice; please review the upstream license terms yourself."
Add-Notice
Add-Notice 'COMPONENTS'
Add-Notice
$index = 1
foreach ($component in $orderedComponents) {
    $version = ''
    if ($component.Version) { $version = " $($component.Version)" }
    Add-Notice ("{0,3}. {1}{2}" -f $index, $component.Name, $version)
    Add-Notice "     License (declared): $($component.License)"
    if ($component.DownloadLocation -ne 'NOASSERTION') { Add-Notice "     Source: $($component.DownloadLocation)" }
    elseif ($component.Homepage) { Add-Notice "     Homepage: $($component.Homepage)" }
    if ($component.Libraries.Count -gt 0) { Add-Notice "     Files: $(@($component.Libraries) -join ', ')" }
    $index++
}
Add-Notice
foreach ($component in $orderedComponents) {
    if ($component.LicenseFiles.Count -eq 0 -and -not $component.Comment) { continue }
    Add-Notice $rule
    $version = ''
    if ($component.Version) { $version = " $($component.Version)" }
    Add-Notice "$($component.Name)$version"
    if ($component.Comment) { Add-Notice $component.Comment }
    Add-Notice $rule
    Add-Notice
    if ($component.LicenseFiles.Count -eq 0) { Add-Notice '(no license file available to this script)'; Add-Notice }
    foreach ($file in $component.LicenseFiles) { Add-LicenseFile $file $component.Id }
}
if ($unattributedLicenseFiles.Count -gt 0) {
    Add-Notice $rule
    Add-Notice 'Other license files installed by OpenCV'
    Add-Notice 'OpenCV installs these for code vendored inside its module libraries. They could not be matched to a separately linked library, so they are reproduced here in full.'
    Add-Notice $rule
    Add-Notice
    foreach ($file in $unattributedLicenseFiles) { Add-LicenseFile $file 'opencv' }
}
if ($omittedLicenseFiles.Count -gt 0) {
    Add-Notice "Not included because the corresponding component is not linked into or shipped with this binary: $($omittedLicenseFiles -join ', ')."
}
Write-TextFile (Join-Path $OutputDir 'THIRD-PARTY-NOTICES.txt') $notices.ToString()

# --- linker-inventory.txt ---------------------------------------------------------------------------------------
$inventoryText = New-Object System.Text.StringBuilder
[void]$inventoryText.Append("# Static libraries and object files linked into $([System.IO.Path]::GetFileName($NativeBinary)) ($PackageId $PackageVersion)`n")
[void]$inventoryText.Append("# Source: $([System.IO.Path]::GetFileName($LinkerMap)). Format: <library> -> <component> (<object count>), then one object per line.`n`n")
[void]$inventoryText.Append("(OpenCvSharpExtern object files) -> $($opencvsharp.Name) ($($map.OwnObjects.Count))`n")
foreach ($o in $map.OwnObjects) { [void]$inventoryText.Append("    $o`n") }
foreach ($item in $inventory) {
    [void]$inventoryText.Append("$($item.Library) -> $($item.Component) ($($item.Objects.Count))`n")
    foreach ($o in $item.Objects) { [void]$inventoryText.Append("    $o`n") }
}
Write-TextFile (Join-Path $OutputDir 'linker-inventory.txt') $inventoryText.ToString()

# --- Summary ----------------------------------------------------------------------------------------------------
$summary = New-Object System.Text.StringBuilder
[void]$summary.Append("### SBOM: $PackageId ($RuntimeIdentifier)`n`n")
[void]$summary.Append("OPENCV_ENABLE_NONFREE=$nonFree; opencv_contrib libraries with linked objects: $contribSummary`n`n")
[void]$summary.Append("| Component | Version | Declared license | Linked libraries / files |`n|---|---|---|---|`n")
foreach ($component in $orderedComponents) {
    [void]$summary.Append("| $($component.Name) | $($component.Version) | $($component.License) | $(@($component.Libraries) -join ', ') |`n")
}
if ($systemImports.Count -gt 0) { [void]$summary.Append("`nImports from system DLLs: $(@($systemImports) -join ', ')`n") }
Write-Host $summary.ToString()
if ($env:GITHUB_STEP_SUMMARY) {
    [System.IO.File]::AppendAllText($env:GITHUB_STEP_SUMMARY, $summary.ToString() + "`n", (New-Object System.Text.UTF8Encoding($false)))
}
Write-Host "Wrote $sbomPath"

if ($FailOnUnresolved -and $unresolved.Count -gt 0) {
    throw "Unresolved libraries or binaries: $($unresolved -join ', ')"
}
