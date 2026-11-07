<#
.SYNOPSIS
    Generates a best-effort CycloneDX 1.6 SBOM and a THIRD-PARTY-NOTICES.txt for one Windows native runtime package.

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
        every license is recorded with acknowledgement 'declared', never 'concluded'.
      * The SBOM states these gaps itself: the dependency lists of the DLL and of prebuilt binaries are marked
        with a composition aggregate of 'incomplete', and the limitations are recorded as an annotation.
      * Prebuilt binaries shipped next to the DLL (the FFmpeg videoio plugin) are recorded with hashes and the
        license files OpenCV ships for them, but their own dependencies are not enumerated.
      * The result describes exactly one build. It cannot be reconstructed for releases built before this
        script existed (for example the OpenCvSharp4 4.11.x packages, which were built from shimat/opencv_files).
      * It is not legal advice.

    Outputs, all under -OutputDir:
      sbom/<PackageId>.cdx.json    CycloneDX 1.6 JSON document (packed into the .nupkg)
      THIRD-PARTY-NOTICES.txt      component list plus license texts (packed into the .nupkg)
      licenses/                    license files that are not plain text, e.g. .rtf/.htm (packed into the .nupkg)
      linker-inventory.txt         every linked library and object file with its component (CI artifact only)

    Compatible with Windows PowerShell 5.1 and PowerShell 7.

.EXAMPLE
    ./scripts/generate_sbom.ps1 -PackageId OpenCvSharp5.runtime.win -PackageVersion 5.0.0.20261107-beta `
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

function Get-Hashes([string] $Path) {
    # SHA-512 is what BSI TR-03183-2 asks for; SHA-256 is what gh attestation verify and most tools use.
    return @(
        [ordered]@{ alg = 'SHA-256'; content = (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant() },
        [ordered]@{ alg = 'SHA-512'; content = (Get-FileHash -LiteralPath $Path -Algorithm SHA512).Hash.ToLowerInvariant() }
    )
}

function ConvertTo-BomRef([string] $Prefix, [string] $Value) {
    return "${Prefix}:" + ($Value -replace '[^A-Za-z0-9.\-_]+', '-')
}

function New-BomProperty([string] $Name, [string] $Value) {
    return [ordered]@{ name = "opencvsharp:$Name"; value = $Value }
}

function Get-SourceReference([string] $Location) {
    # git+https://<host>/<owner>/<repo>[.git]@<ref>  ->  vcs reference; a plain http(s) URL  ->  distribution reference.
    if (-not $Location) { return $null }
    if ($Location -match '^git\+(?<url>https?://[^@#\s]+?)(?:@(?<ref>[^#\s]+))?$') {
        $reference = [ordered]@{ type = 'vcs'; url = $Matches.url }
        if ($Matches.ref) { $reference.comment = "Revision $($Matches.ref)" }
        return $reference
    }
    if ($Location -match '^https?://') { return [ordered]@{ type = 'distribution'; url = $Location } }
    return $null
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
# ippicv.cmake sets IPPICV_COMMIT per platform, so record the pinned Windows x64 package name instead of a commit.
$ippPackageMatch = Find-InFile (Join-Path $openCvSource '3rdparty/ippicv/ippicv.cmake') 'ippicv_(\d{4}\.\d+(?:\.\d+)?)_win_intel64_(\d{8})_general\.zip'
$ippVersion = $null
$ippPackageNote = ''
if ($ippPackageMatch) {
    $ippVersion = '{0} ({1})' -f $ippPackageMatch.Groups[1].Value, $ippPackageMatch.Groups[2].Value
    $ippPackageNote = " Downloaded by OpenCV's build as $($ippPackageMatch.Value) from opencv/opencv_3rdparty (pinned in opencv/3rdparty/ippicv/ippicv.cmake)."
}
$protobufVersion = $null
$protobufMatch = Find-InFile (Join-Path $openCvSource '3rdparty/protobuf/src/google/protobuf/stubs/common.h') '#define\s+GOOGLE_PROTOBUF_VERSION\s+(\d+)'
if ($protobufMatch) {
    $n = [int]$protobufMatch.Groups[1].Value
    $protobufVersion = '{0}.{1}.{2}' -f [math]::Floor($n / 1000000), ([math]::Floor($n / 1000) % 1000), ($n % 1000)
}

$bundledTable = @(
    @{ Pattern = '^ippicv'; Id = 'ippicv'; Name = 'Intel IPP ICV (Integrated Performance Primitives subset distributed for OpenCV)'; Supplier = 'Intel Corporation'; Version = $ippVersion; LicenseFiles = @('ippicv-*'); Comment = "Proprietary Intel license, not Apache-2.0. See the ippicv-* license files.$ippPackageNote" },
    @{ Pattern = '^ippiw'; Id = 'ippiw'; Name = 'Intel IPP Integration Wrappers (IPP IW)'; Supplier = 'Intel Corporation'; Version = $ippVersion; LicenseFiles = @('ippiw-*'); Comment = "Built from sources shipped in the IPP ICV package. See the ippiw-* license files.$ippPackageNote" },
    @{ Pattern = '^ittnotify'; Id = 'ittnotify'; Name = 'Intel ITT API (ittnotify)'; Supplier = 'Intel Corporation'; License = 'BSD-3-Clause OR GPL-2.0-only'; LicenseFiles = @('ittnotify-*') },
    @{ Pattern = '^libprotobuf'; Id = 'protobuf'; Name = 'Protocol Buffers (copy bundled with OpenCV)'; Supplier = 'Google LLC'; Version = $protobufVersion; License = 'BSD-3-Clause'; LicenseFiles = @('protobuf-*') },
    @{ Pattern = '^libopenjp2'; Id = 'openjpeg'; Name = 'OpenJPEG (copy bundled with OpenCV)'; License = 'BSD-2-Clause'; LicenseFiles = @('libopenjp2-*') },
    @{ Pattern = '^(lib)?clapack'; Id = 'clapack'; Name = 'CLAPACK (LAPACK, copy bundled with OpenCV)'; LicenseFiles = @('clapack-*'); Comment = 'BSD-style LAPACK license; see clapack-lapack_LICENSE.' },
    @{ Pattern = '^quirc'; Id = 'quirc'; Name = 'quirc (copy bundled with OpenCV)'; License = 'ISC'; LicenseFiles = @('quirc-*') },
    @{ Pattern = '^(ilmimf|openexr)'; Id = 'openexr'; Name = 'OpenEXR (copy bundled with OpenCV)'; License = 'BSD-3-Clause'; LicenseFiles = @('openexr-*') },
    @{ Pattern = '^libspng'; Id = 'libspng'; Name = 'libspng (copy bundled with OpenCV)'; License = 'BSD-2-Clause'; LicenseFiles = @('libspng-*') },
    @{ Pattern = '^tbb'; Id = 'tbb'; Name = 'oneTBB (copy bundled with OpenCV)'; Supplier = 'Intel Corporation'; License = 'Apache-2.0'; LicenseFiles = @('tbb-*') },
    @{ Pattern = '^kleidicv'; Id = 'kleidicv'; Name = 'KleidiCV (copy bundled with OpenCV)'; Supplier = 'Arm Limited'; License = 'Apache-2.0'; LicenseFiles = @('kleidicv-*') }
)
# MLAS is not listed: OpenCV 5 compiles it as an OBJECT library into opencv_dnn, so it never shows up as its own
# library in the map (and Windows CI builds disable it). It is covered by the OpenCV component and its license files.
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
            Id = $Id; Kind = 'unresolved'; Name = $Id; Version = $null; Supplier = $null; DownloadLocation = $null
            # License is an SPDX license expression as declared upstream, or $null when nothing usable is declared.
            Homepage = $null; License = $null; Purl = $null; Comment = $null
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
        $download = $null
        if ($contribCommit) { $download = "git+https://github.com/opencv/opencv_contrib@$contribCommit" }
        return Get-Component 'opencv_contrib' @{
            Kind = 'opencv_contrib'; Name = 'opencv_contrib'; Version = $openCvVersion; Supplier = 'OpenCV'
            DownloadLocation = $download; Purl = (Get-GitHubPurl $download); Homepage = 'https://github.com/opencv/opencv_contrib'; License = 'Apache-2.0'
            LicenseFiles = @((Join-Path $contribSource 'LICENSE'))
            Comment = "Built with OPENCV_ENABLE_NONFREE=$nonFree. Non-free (patent-encumbered) implementations live in contrib modules; the linked libraries and objects are listed in linker-inventory.txt."
        }
    }
    $download = $null
    if ($openCvCommit) { $download = "git+https://github.com/opencv/opencv@$openCvCommit" }
    $optionText = ($openCvOptions.Keys | ForEach-Object { "$_=$($openCvOptions[$_])" }) -join ', '
    return Get-Component 'opencv' @{
        Kind = 'opencv'; Name = 'OpenCV'; Version = $openCvVersion; Supplier = 'OpenCV'
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
    $license = $null
    $homepage = $null
    $download = $null
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
            if (-not $download) { $download = $location } else { $notes.Add("Additional source: $location") }
        }
    } else {
        $notes.Add('vcpkg.spdx.json not found; version taken from the vcpkg info file name.')
    }
    if ($license -and $license -like '*LicenseRef-*') {
        # A LicenseRef only has a meaning inside vcpkg's own SPDX document; keep the value as a note instead.
        $notes.Add("Declared license (vcpkg): $license")
        $license = $null
    }
    return Get-Component $id @{
        Kind = 'vcpkg'; Name = $Port; Version = $version; DownloadLocation = $download; Purl = (Get-GitHubPurl $download)
        Homepage = $homepage; License = $license; LicenseFiles = @((Join-Path $shareDir 'copyright')); Comment = ($notes -join ' ')
    }
}

# OpenCvSharp's own object files
$opencvsharpDownload = $null
if ($opencvsharpCommit) { $opencvsharpDownload = "git+$repositoryUrl@$opencvsharpCommit" }
$opencvsharpComment = 'OpenCvSharpExtern (src/OpenCvSharpExtern).'
if (@($BuildOptions).Count -gt 0) { $opencvsharpComment += ' CMake options: ' + ($BuildOptions -join ', ') + '.' }
$opencvsharp = Get-Component 'opencvsharp' @{
    Kind = 'opencvsharp'; Name = 'OpenCvSharp'; Version = $PackageVersion; Supplier = 'OpenCvSharp'
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
            $properties = @{ Kind = 'opencv-bundled' }
            foreach ($key in $entry.Keys) { if ($key -ne 'Pattern' -and $key -ne 'Id' -and $key -ne 'LicenseFiles') { $properties[$key] = $entry[$key] } }
            $properties['LicenseFilePatterns'] = $entry.LicenseFiles
            $component = Get-Component "bundled-$($entry.Id)" $properties
        }
        elseif ($library -match $runtimePattern) {
            $component = Get-Component 'msvc-runtime' @{
                Kind = 'msvc-runtime'; Name = 'Microsoft C/C++ runtime libraries (static)'; Supplier = 'Microsoft Corporation'
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
        $download = $null
        if ($commitMatch) { $download = 'git+https://github.com/opencv/opencv_3rdparty@' + $commitMatch.Groups[1].Value }
        $component = Get-Component 'ffmpeg' @{
            Kind = 'prebuilt'; Name = 'FFmpeg (opencv_videoio_ffmpeg plugin, prebuilt by OpenCV)'; Supplier = 'OpenCV'
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

$limitations = 'Best-effort inventory generated by scripts/generate_sbom.ps1 from the MSVC linker map of this build, vcpkg port metadata and the license files OpenCV installs. It is not guaranteed to be complete: code that OpenCV compiles directly into its module libraries (vendored sources, generated code, header-only libraries) is not identified as separate components, the dependencies of prebuilt binaries are not enumerated, and license values are declared values that have not been reviewed (they are recorded with acknowledgement ''declared''). It is not legal advice.'
$contribSummary = 'none'
if ($contribLibraries.Count -gt 0) { $contribSummary = $contribLibraries -join ', ' }

# --- CycloneDX 1.6 ----------------------------------------------------------------------------------------------
# Layout: metadata.component is the NuGet package. The top-level components are the binaries it ships (type 'file',
# with hashes) and the components linked into them (type 'library'). The dependency graph says what is in what:
# package -> shipped binaries, OpenCvSharpExtern.dll -> statically linked components, prebuilt binary -> its origin.
$generatedAt = [DateTime]::UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", [System.Globalization.CultureInfo]::InvariantCulture)
$supplier = [ordered]@{ name = 'OpenCvSharp'; url = @($repositoryUrl) }
$rootRef = "pkg:nuget/$PackageId@$PackageVersion"
$dllName = [System.IO.Path]::GetFileName($NativeBinary)
$dllRef = ConvertTo-BomRef 'file' $dllName
$bomComponents = New-Object System.Collections.Generic.List[object]
$dependencies = New-Object System.Collections.Generic.List[object]

$dllProperties = @(
    (New-BomProperty 'package-path' "$nativePackagePath/$dllName"),
    (New-BomProperty 'opencv-enable-nonfree' $nonFree),
    (New-BomProperty 'opencv-contrib-libraries' $contribSummary)
)
$bomComponents.Add([ordered]@{
    type = 'file'
    'bom-ref' = $dllRef
    supplier = $supplier
    name = $dllName
    version = $PackageVersion
    description = 'Built from OpenCvSharpExtern. Statically links the components listed as its dependencies.'
    hashes = @(Get-Hashes $NativeBinary)
    properties = $dllProperties
})

$prebuiltComponentIds = @{}
$prebuiltRefs = New-Object System.Collections.Generic.List[string]
foreach ($prebuilt in $prebuiltFiles) {
    $fileRef = ConvertTo-BomRef 'file' $prebuilt.Leaf
    $prebuiltRefs.Add($fileRef)
    $prebuiltComponentIds[$prebuilt.Component.Id] = $true
    $bomComponents.Add([ordered]@{
        type = 'file'
        'bom-ref' = $fileRef
        name = $prebuilt.Leaf
        description = 'Prebuilt binary shipped next to OpenCvSharpExtern.dll. Its origin is listed as its dependency.'
        hashes = @(Get-Hashes $prebuilt.Path)
        properties = @((New-BomProperty 'package-path' "$nativePackagePath/$($prebuilt.Leaf)"))
    })
    $dependencies.Add([ordered]@{ ref = $fileRef; dependsOn = @((ConvertTo-BomRef 'component' $prebuilt.Component.Id)) })
}

$linkedRefs = New-Object System.Collections.Generic.List[string]
foreach ($component in $orderedComponents) {
    $ref = ConvertTo-BomRef 'component' $component.Id
    $bomComponent = [ordered]@{ type = 'library'; 'bom-ref' = $ref }
    if ($component.Supplier) { $bomComponent.supplier = [ordered]@{ name = $component.Supplier } }
    $bomComponent.name = $component.Name
    if ($component.Version) { $bomComponent.version = "$($component.Version)" }
    if ($component.Comment) { $bomComponent.description = $component.Comment }
    if ($component.License) {
        # Never 'concluded': nothing here has been reviewed.
        $bomComponent.licenses = @([ordered]@{ expression = $component.License; acknowledgement = 'declared' })
    }
    if ($component.Purl) { $bomComponent.purl = $component.Purl }
    $references = New-Object System.Collections.Generic.List[object]
    $source = Get-SourceReference $component.DownloadLocation
    if ($source) { $references.Add($source) }
    if ($component.Homepage) { $references.Add([ordered]@{ type = 'website'; url = $component.Homepage }) }
    if ($references.Count -gt 0) { $bomComponent.externalReferences = $references.ToArray() }
    $properties = New-Object System.Collections.Generic.List[object]
    $properties.Add((New-BomProperty 'origin' $component.Kind))
    if ($component.Kind -ne 'prebuilt' -and $component.Libraries.Count -gt 0) {
        $properties.Add((New-BomProperty 'linked-libraries' (@($component.Libraries) -join ', ')))
    }
    if ($component.ObjectCount -gt 0) { $properties.Add((New-BomProperty 'linked-object-files' "$($component.ObjectCount)")) }
    if ($component.Kind -eq 'opencv' -and $unattributedLicenseFiles.Count -gt 0) {
        $properties.Add((New-BomProperty 'vendored-license-files' (@($unattributedLicenseFiles | ForEach-Object { [System.IO.Path]::GetFileName($_) }) -join ', ')))
    }
    $bomComponent.properties = $properties.ToArray()
    $bomComponents.Add($bomComponent)
    if (-not $prebuiltComponentIds.ContainsKey($component.Id)) { $linkedRefs.Add($ref) }
}

$shippedRefs = @($dllRef) + @($prebuiltRefs)
$dependencies.Insert(0, [ordered]@{ ref = $dllRef; dependsOn = $linkedRefs.ToArray() })
$dependencies.Insert(0, [ordered]@{ ref = $rootRef; dependsOn = $shippedRefs })

$metadataProperties = New-Object System.Collections.Generic.List[object]
if ($env:GITHUB_RUN_ID) { $metadataProperties.Add((New-BomProperty 'workflow-run' "$($env:GITHUB_SERVER_URL)/$($env:GITHUB_REPOSITORY)/actions/runs/$($env:GITHUB_RUN_ID)")) }
if ($env:ImageOS) { $metadataProperties.Add((New-BomProperty 'runner-image' "$($env:ImageOS) $($env:ImageVersion)")) }
if ($vcpkgBaseline) { $metadataProperties.Add((New-BomProperty 'vcpkg-builtin-baseline' $vcpkgBaseline)) }
$toolReference = [ordered]@{ type = 'vcs'; url = $repositoryUrl }
if ($opencvsharpCommit) { $toolReference.comment = "scripts/generate_sbom.ps1 at revision $opencvsharpCommit" }

$metadata = [ordered]@{
    timestamp = $generatedAt
    lifecycles = @([ordered]@{ phase = 'build' })
    tools = [ordered]@{
        components = @([ordered]@{ type = 'application'; name = 'generate_sbom.ps1'; group = 'OpenCvSharp'; externalReferences = @($toolReference) })
    }
    component = [ordered]@{
        type = 'library'
        'bom-ref' = $rootRef
        supplier = $supplier
        name = $PackageId
        version = $PackageVersion
        description = 'Apache-2.0 is the license of OpenCvSharp itself, as declared in the NuGet metadata. The native binaries in this package also contain the third-party components listed in this SBOM, under their own licenses.'
        licenses = @([ordered]@{ expression = 'Apache-2.0'; acknowledgement = 'declared' })
        purl = $rootRef
        externalReferences = @(
            [ordered]@{ type = 'distribution'; url = "https://www.nuget.org/packages/$PackageId/$PackageVersion" },
            [ordered]@{ type = 'website'; url = $repositoryUrl }
        )
    }
    supplier = $supplier
}
if ($metadataProperties.Count -gt 0) { $metadata.properties = $metadataProperties.ToArray() }

$bom = [ordered]@{
    '$schema' = 'http://cyclonedx.org/schema/bom-1.6.schema.json'
    bomFormat = 'CycloneDX'
    specVersion = '1.6'
    serialNumber = "urn:uuid:$([guid]::NewGuid())"
    version = 1
    metadata = $metadata
    components = $bomComponents.ToArray()
    dependencies = $dependencies.ToArray()
    # The dependency lists of the shipped binaries are known to be incomplete (see KNOWN GAPS above).
    compositions = @([ordered]@{ aggregate = 'incomplete'; dependencies = $shippedRefs })
    annotations = @([ordered]@{
        subjects = @($rootRef)
        annotator = [ordered]@{ organization = $supplier }
        timestamp = $generatedAt
        text = $limitations
    })
}
$sbomPath = Join-Path $OutputDir "sbom/$PackageId.cdx.json"
Write-TextFile $sbomPath (($bom | ConvertTo-Json -Depth 20) + "`n")

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
Add-Notice "This package ships $($shippedBinaries -join ', ') in $nativePackagePath. OpenCvSharpExtern.dll statically links OpenCV and the third-party components listed below. The list was generated from the linker map of this particular build; a machine-readable CycloneDX 1.6 SBOM for the same build is included as sbom/$PackageId.cdx.json."
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
    $declared = 'none declared, see the license texts below'
    if ($component.License) { $declared = $component.License }
    Add-Notice "     License (declared): $declared"
    if ($component.DownloadLocation) { Add-Notice "     Source: $($component.DownloadLocation)" }
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
