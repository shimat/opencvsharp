# OpenCvSharp

A cross-platform .NET wrapper for [OpenCV](https://opencv.org/), providing image processing and computer vision functionality.

> This is the **OpenCvSharp5** family (OpenCV 5.x, .NET 8+). If you need .NET Framework, Unity, or another pre-.NET 8 runtime, use the **OpenCvSharp4** family (OpenCV 4.13.0) instead.

> 🔄 **Already using OpenCvSharp4?** See the [Migration Guide (4 → 5)](https://github.com/shimat/opencvsharp/blob/main/docs/migration-4-to-5.md) on GitHub for target framework changes, package/namespace renames, and OpenCV 5 API changes.

## Supported Platforms

| Platform | Target Framework |
|---|---|
| .NET 8.0 or later | `net8.0` |
| Windows desktop (.NET 8+) | `net8.0-windows` (WpfExtensions) |

Target OpenCV version: **5.0.x** (with opencv_contrib)

## Quick Start

### Windows

```bash
dotnet add package OpenCvSharp5.Windows
```

### Linux / Ubuntu

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.official.runtime.linux-x64
```

### macOS

```bash
dotnet add package OpenCvSharp5
# Intel (x64):
dotnet add package OpenCvSharp5.runtime.osx.x64
# Apple Silicon (arm64):
dotnet add package OpenCvSharp5.runtime.osx.arm64
```

For more installation options, see [Installation on GitHub](https://github.com/shimat/opencvsharp#installation).

## Requirements

### Windows
- (Windows Server only) Media Foundation:
  ```powershell
  Install-WindowsFeature Server-Media-Foundation
  ```

### Linux (Ubuntu and other distributions)
The official `OpenCvSharp5.official.runtime.linux-x64` package is built on manylinux_2_28 (glibc 2.28) and works on Ubuntu 20.04+, Debian 10+, RHEL/AlmaLinux 8+, and other Linux distributions.

- **Full package**: uses GTK3 for `highgui` support (`Cv2.ImShow`, `Cv2.WaitKey`, etc.). GTK3 (`libgtk-3.so.0`) is pre-installed on standard Ubuntu/Debian/RHEL environments and typically requires no action. In minimal or container environments where GTK3 is absent, install it manually: Ubuntu/Debian: `apt-get install libgtk-3-0`; RHEL/AlmaLinux: `dnf install gtk3`. Alternatively, use the **slim** package which has no GUI dependencies.
- **Slim package** (`OpenCvSharp5.official.runtime.linux-x64.slim`): `highgui` is disabled; no GTK3 or other GUI dependencies. Suitable for headless and container environments.

### macOS (Intel and Apple Silicon)
The `OpenCvSharp5.runtime.osx.x64` and `OpenCvSharp5.runtime.osx.arm64` packages provide native bindings for macOS. FFmpeg, Tesseract, Freetype, and all standard OpenCV modules are statically linked.

## Slim Profile

The `slim` runtime packages (`OpenCvSharp5.Windows.Slim`, `OpenCvSharp5.official.runtime.linux-x64.slim`, etc.) bundle a smaller native library:

| | Modules |
|---|---|
| **Enabled** | `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `objdetect`, `photo`, `ml`, `video`, `stitching`, `barcode` |
| **Disabled** | `contrib`, `dnn`, `videoio`, `highgui` |

## Usage

**Always release `Mat` and other `IDisposable` resources using the `using` statement:**

```csharp
using OpenCvSharp;

// Edge detection using Canny algorithm
using var src = new Mat("lenna.png", ImreadModes.Grayscale);
using var dst = new Mat();

Cv2.Canny(src, dst, 50, 200);
using (new Window("src image", src))
using (new Window("dst image", dst))
{
    Cv2.WaitKey();
}
```

`Mat` arithmetic operators (`+`, `-`, `*`, `/`, comparisons, bitwise, `T()`, `Inv()`, ...) return a
lazily-evaluated managed expression tree that holds no unmanaged resources, so chained expressions
never leak. Just receive the result in a `using Mat`:

```csharp
using var src = new Mat("lenna.png", ImreadModes.Grayscale);

// The intermediate (src * 0.8) holds no native resource; nothing leaks.
using Mat dst = 255 - src * 0.8;
```

> **Note:** OpenCvSharp does not support Unity, Xamarin, CUDA or UWP.

## Resources

- [GitHub Repository](https://github.com/shimat/opencvsharp)
- [Code Samples](https://github.com/shimat/opencvsharp_samples/)
- [API Documentation](https://shimat.github.io/opencvsharp/api/OpenCvSharp.html)
- [Issue Tracker](https://github.com/shimat/opencvsharp/issues)