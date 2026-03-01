# OpenCvSharp

A cross-platform .NET wrapper for [OpenCV](https://opencv.org/), providing image processing and computer vision functionality.

## Supported Platforms

| Platform | Target Framework |
|---|---|
| .NET 8.0 or later | `net8.0` |
| .NET Standard 2.1 | `netstandard2.1` |
| .NET Standard 2.0 | `netstandard2.0` |
| .NET Framework 4.6.1+ | via `netstandard2.0` |
| .NET Framework 4.8 | direct target (WpfExtensions only) |

Target OpenCV version: **4.13.0** (with opencv_contrib)

## Quick Start

### Windows

```bash
dotnet add package OpenCvSharp4.Windows
```

### Linux / Ubuntu

```bash
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.official.runtime.linux-x64
```

For more installation options, see [Installation on GitHub](https://github.com/shimat/opencvsharp#installation).

## Requirements

### Windows
- [Visual C++ 2022 Redistributable](https://support.microsoft.com/help/2977003/)
- (Windows Server only) Media Foundation:
  ```powershell
  Install-WindowsFeature Server-Media-Foundation
  ```

### Linux (Ubuntu and other distributions)
Pre-install the dependency packages needed for OpenCV. Many packages such as `libjpeg` must be present for OpenCV to work.  
See: [OpenCV Linux install guide](https://docs.opencv.org/4.x/d7/d9f/tutorial_linux_install.html)

## Slim Profile

The `slim` runtime packages (`OpenCvSharp4.Windows.Slim`, `OpenCvSharp4.official.runtime.linux-x64.slim`, etc.) bundle a smaller native library:

| | Modules |
|---|---|
| **Enabled** | `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `objdetect`, `photo` |
| **Disabled** | `contrib`, `dnn`, `ml`, `video`, `videoio`, `highgui`, `stitching`, `barcode` |

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

For complex pipelines, use `ResourcesTracker` to manage multiple resources automatically:

```csharp
using var t = new ResourcesTracker();

var src = t.T(new Mat("lenna.png", ImreadModes.Grayscale));
var dst = t.NewMat();
Cv2.Canny(src, dst, 50, 200);
var blurred = t.T(dst.Blur(new Size(3, 3)));
t.T(new Window("src image", src));
t.T(new Window("dst image", blurred));
Cv2.WaitKey();
```

> **Note:** OpenCvSharp does not support Unity, Xamarin, CUDA or UWP.

## Resources

- [GitHub Repository](https://github.com/shimat/opencvsharp)
- [Code Samples](https://github.com/shimat/opencvsharp_samples/)
- [API Documentation](http://shimat.github.io/opencvsharp/api/OpenCvSharp.html)
- [Issue Tracker](https://github.com/shimat/opencvsharp/issues)