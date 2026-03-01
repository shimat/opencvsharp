# OpenCvSharp Native Runtime Package

This is an **internal implementation package** for [OpenCvSharp](https://github.com/shimat/opencvsharp). It provides the native OpenCV shared library (`OpenCvSharpExtern`) for a specific platform.

> In most cases you do not need to reference this package directly. Use one of the all-in-one packages instead:
> - **Windows:** `OpenCvSharp4.Windows` or `OpenCvSharp4.Windows.Slim`
> - **Linux:** `OpenCvSharp4` + `OpenCvSharp4.official.runtime.linux-x64`

## Available Runtime Packages

| Package | Platform |
|---|---|
| `OpenCvSharp4.runtime.win` | Windows x64 |
| `OpenCvSharp4.runtime.win.slim` | Windows x64 (slim) |
| `OpenCvSharp4.official.runtime.linux-x64` | Linux x64 (portable RID) |
| `OpenCvSharp4.official.runtime.linux-x64.slim` | Linux x64 (portable RID, slim) |
| `OpenCvSharp4.official.runtime.ubuntu.22.04-x64` | Ubuntu 22.04 x64 |
| `OpenCvSharp4.official.runtime.ubuntu.22.04-x64.slim` | Ubuntu 22.04 x64 (slim) |
| `OpenCvSharp4.official.runtime.ubuntu.24.04-x64` | Ubuntu 24.04 x64 |
| `OpenCvSharp4.official.runtime.ubuntu.24.04-x64.slim` | Ubuntu 24.04 x64 (slim) |
| `OpenCvSharp4.runtime.linux-arm` | Linux ARM |
| `OpenCvSharp4.runtime.osx.10.15-x64` | macOS 10.15+ x64 |

> **Note:** For Linux, the portable `linux-x64` packages are recommended over the distro-specific ones. Distro-specific RIDs are [no longer resolved automatically by .NET 8+](https://learn.microsoft.com/dotnet/core/compatibility/sdk/8.0/rid-graph).

## Slim Profile

The `slim` packages bundle a smaller native library with a reduced OpenCV module set:

| | Modules |
|---|---|
| **Enabled** | `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `objdetect`, `photo` |
| **Disabled** | `contrib`, `dnn`, `ml`, `video`, `videoio`, `highgui`, `stitching`, `barcode` |

## Resources

- [GitHub Repository](https://github.com/shimat/opencvsharp)
- [OpenCvSharp4 (managed package)](https://www.nuget.org/packages/OpenCvSharp4)
- [Issue Tracker](https://github.com/shimat/opencvsharp/issues)