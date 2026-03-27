# OpenCvSharp Native Runtime Package

This is an **internal implementation package** for [OpenCvSharp](https://github.com/shimat/opencvsharp). It provides the native OpenCV shared library (`OpenCvSharpExtern`) for a specific platform.

> In most cases you do not need to reference this package directly. Use one of the all-in-one packages instead:
> - **Windows:** `OpenCvSharp4.Windows` or `OpenCvSharp4.Windows.Slim`
> - **Linux:** `OpenCvSharp4` + `OpenCvSharp4.official.runtime.linux-x64`

The Linux `linux-x64` packages are built on **manylinux_2_28** (glibc 2.28) and work on Ubuntu 20.04+, Debian 10+, RHEL/AlmaLinux 8+, and other Linux distributions. The full (non-slim) package includes FFmpeg (LGPL v2.1) and Tesseract statically linked.

> **Linux `highgui` dependency:** The **full** `linux-x64` package uses GTK3 for `highgui` (`Cv2.ImShow`, `Cv2.WaitKey`, etc.). GTK3 is pre-installed on standard Ubuntu/Debian/RHEL environments. In minimal or container environments where it is absent, install it manually:
> - Ubuntu/Debian: `apt-get install libgtk-3-0`
> - RHEL/AlmaLinux: `dnf install gtk3`
>
> For headless servers or minimal containers, use the **slim** package (`OpenCvSharp4.official.runtime.linux-x64.slim`) instead, which disables `highgui` and has no GUI dependencies.

## Available Runtime Packages

| Package | Platform |
|---|---|
| `OpenCvSharp4.runtime.win` | Windows x64 |
| `OpenCvSharp4.runtime.win.slim` | Windows x64 (slim) |
| `OpenCvSharp4.official.runtime.linux-x64` | Linux x64 (portable, manylinux_2_28) |
| `OpenCvSharp4.official.runtime.linux-x64.slim` | Linux x64 (portable, manylinux_2_28, slim) |
| `OpenCvSharp4.runtime.linux-arm` | Linux ARM |
| `OpenCvSharp4.runtime.osx.10.15-x64` | macOS 10.15+ x64 |

> **Note:** `OpenCvSharp4.official.runtime.ubuntu.22.04-x64`, `ubuntu.22.04-x64.slim`, `ubuntu.24.04-x64`, and `ubuntu.24.04-x64.slim` are **deprecated**. Migrate to the portable `linux-x64` packages.

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