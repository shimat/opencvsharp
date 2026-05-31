# OpenCvSharp Runtime for SlideGenerator

[![Build Status](https://github.com/thnhmai06/SlideGenerator.OpenCvSharp/actions/workflows/slidegenerator-runtimes.yml/badge.svg)](https://github.com/thnhmai06/SlideGenerator.OpenCvSharp/actions/workflows/slidegenerator-runtimes.yml)
[![GitHub license](https://img.shields.io/github/license/thnhmai06/SlideGenerator.OpenCvSharp.svg)](LICENSE)

Fork of [shimat/opencvsharp](https://github.com/shimat/opencvsharp) providing pre-built
`OpenCvSharpExtern` native runtime packages for [SlideGenerator](https://github.com/thnhmai06/SlideGenerator).

## What this is

This repo builds and publishes slim `OpenCvSharpExtern` native libraries for 6 platforms.
The build targets **YuNet face detection** — only the OpenCV modules actually used by
`SlideGenerator.Image` are compiled, keeping the libraries small.

Included OpenCV modules: `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `dnn`, `ml`, `objdetect`

Excluded: videoio, highgui, photo, stitching, contrib, Tesseract, FFmpeg, GStreamer

## Packages

Packages are published to [GitHub Packages](https://github.com/thnhmai06?tab=packages).

| Package | RID | Platform |
|---------|-----|----------|
| `SlideGenerator.OpenCvSharp4.runtime.win-x64` | `win-x64` | Windows x64 |
| `SlideGenerator.OpenCvSharp4.runtime.win-arm64` | `win-arm64` | Windows ARM64 |
| `SlideGenerator.OpenCvSharp4.runtime.linux-x64` | `linux-x64` | Linux x64 |
| `SlideGenerator.OpenCvSharp4.runtime.linux-arm64` | `linux-arm64` | Linux ARM64 |
| `SlideGenerator.OpenCvSharp4.runtime.osx-x64` | `osx-x64` | macOS x64 (Intel) |
| `SlideGenerator.OpenCvSharp4.runtime.osx-arm64` | `osx-arm64` | macOS ARM64 (Apple Silicon) |

## Installation

### 1. Add GitHub Packages source

Create or update `nuget.config` in your project/solution root:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="github-thnhmai06" value="https://nuget.pkg.github.com/thnhmai06/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

GitHub Packages requires authentication. Set up credentials via:
```bash
dotnet nuget add source https://nuget.pkg.github.com/thnhmai06/index.json \
  --name github-thnhmai06 \
  --username <your-github-username> \
  --password <your-github-token>
```

### 2. Add packages to your project

Add `OpenCvSharp4` (managed) from nuget.org and the runtime package for your platform:

```xml
<PackageReference Include="OpenCvSharp4" Version="4.13.0.*" />

<!-- Windows x64 -->
<PackageReference Include="SlideGenerator.OpenCvSharp4.runtime.win-x64" Version="4.13.0.*"
    Condition="'$(RuntimeIdentifier)' == 'win-x64' or ('$(RuntimeIdentifier)' == '' and $([MSBuild]::IsOSPlatform('Windows')))" />

<!-- Windows ARM64 -->
<PackageReference Include="SlideGenerator.OpenCvSharp4.runtime.win-arm64" Version="4.13.0.*"
    Condition="'$(RuntimeIdentifier)' == 'win-arm64'" />

<!-- Linux x64 -->
<PackageReference Include="SlideGenerator.OpenCvSharp4.runtime.linux-x64" Version="4.13.0.*"
    Condition="'$(RuntimeIdentifier)' == 'linux-x64'" />

<!-- Linux ARM64 -->
<PackageReference Include="SlideGenerator.OpenCvSharp4.runtime.linux-arm64" Version="4.13.0.*"
    Condition="'$(RuntimeIdentifier)' == 'linux-arm64'" />

<!-- macOS x64 -->
<PackageReference Include="SlideGenerator.OpenCvSharp4.runtime.osx-x64" Version="4.13.0.*"
    Condition="'$(RuntimeIdentifier)' == 'osx-x64'" />

<!-- macOS ARM64 -->
<PackageReference Include="SlideGenerator.OpenCvSharp4.runtime.osx-arm64" Version="4.13.0.*"
    Condition="'$(RuntimeIdentifier)' == 'osx-arm64'" />
```

## CI / Build

Releases are produced by the [`slidegenerator-runtimes.yml`](.github/workflows/slidegenerator-runtimes.yml) workflow.

- **Trigger**: GitHub Release (published) or manual `workflow_dispatch`
- **OpenCV version**: 4.13.0 (git submodule, built from source — static, self-contained)
- **cmake options**: [`cmake/opencv_build_options_yunet.cmake`](cmake/opencv_build_options_yunet.cmake)

| Platform | Runner |
|----------|--------|
| win-x64 | `windows-2025` |
| win-arm64 | `windows-11-arm` |
| linux-x64 | `ubuntu-22.04` |
| linux-arm64 | `ubuntu-24.04-arm` |
| osx-x64 | `macos-13` |
| osx-arm64 | `macos-14` |

## License

[Apache License 2.0](LICENSE) — same as upstream [shimat/opencvsharp](https://github.com/shimat/opencvsharp).
