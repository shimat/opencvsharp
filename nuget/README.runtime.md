# OpenCvSharp Native Runtime Package

This is an **internal implementation package** for [OpenCvSharp](https://github.com/shimat/opencvsharp). It provides the native OpenCV shared library (`OpenCvSharpExtern`) for a specific platform.

> In most cases you do not need to reference this package directly. Use one of the all-in-one packages instead:
> - **Windows:** `OpenCvSharp5.Windows` or `OpenCvSharp5.Windows.Slim`
> - **Linux:** `OpenCvSharp5` + `OpenCvSharp5.official.runtime.linux-x64`

> The `OpenCvSharp5.*` runtime packages target OpenCV 5.x. An identically-named `OpenCvSharp4.*` counterpart (OpenCV 4.13.0) is also published for .NET Framework / older runtimes.

The Linux `linux-x64` packages are built on **manylinux_2_28** (glibc 2.28) and work on Ubuntu 20.04+, Debian 10+, RHEL/AlmaLinux 8+, and other Linux distributions. The full (non-slim) package includes FFmpeg (LGPL v2.1) and Tesseract statically linked.

> **Linux `highgui` dependency:** The **full** `linux-x64` package uses GTK3 for `highgui` (`Cv2.ImShow`, `Cv2.WaitKey`, etc.). GTK3 is pre-installed on standard Ubuntu/Debian/RHEL environments. In minimal or container environments where it is absent, install it manually:
> - Ubuntu/Debian: `apt-get install libgtk-3-0`
> - RHEL/AlmaLinux: `dnf install gtk3`
>
> For headless servers or minimal containers, use the **slim** package (`OpenCvSharp5.official.runtime.linux-x64.slim`) instead, which disables `highgui` and has no GUI dependencies.

## Available Runtime Packages

| Package | Platform |
|---|---|
| `OpenCvSharp5.runtime.win` | Windows x64 |
| `OpenCvSharp5.runtime.win.slim` | Windows x64 (slim) |
| `OpenCvSharp5.runtime.win-arm64` | Windows ARM64 (Snapdragon X and other arm64 devices). FFmpeg not included. |
| `OpenCvSharp5.runtime.win-arm64.slim` | Windows ARM64 (slim) |
| `OpenCvSharp5.official.runtime.linux-x64` | Linux x64 (portable, manylinux_2_28) |
| `OpenCvSharp5.official.runtime.linux-x64.slim` | Linux x64 (portable, manylinux_2_28, slim) |
| `OpenCvSharp5.runtime.linux-arm64` | Linux ARM64 (AArch64) |
| `OpenCvSharp5.runtime.linux-arm` | Linux ARM64 — **deprecated**, use `linux-arm64` |
| `OpenCvSharp5.runtime.osx.10.15-x64` | macOS 10.15+ x64 |

> **Note:** `OpenCvSharp5.official.runtime.ubuntu.22.04-x64`, `ubuntu.22.04-x64.slim`, `ubuntu.24.04-x64`, and `ubuntu.24.04-x64.slim` are **deprecated**. Migrate to the portable `linux-x64` packages.
> **Note:** `OpenCvSharp5.runtime.linux-arm` has been renamed to `OpenCvSharp5.runtime.linux-arm64` to correctly reflect the ARM64 (AArch64) RID. The old package is kept as a compatibility shim that automatically pulls in the renamed package, but new projects should reference `OpenCvSharp5.runtime.linux-arm64` directly.

## Slim Profile

The `slim` packages bundle a smaller native library with a reduced OpenCV module set:

| | Modules |
|---|---|
| **Enabled** | `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `objdetect`, `photo` |
| **Disabled** | `contrib`, `dnn`, `ml`, `video`, `videoio`, `highgui`, `stitching`, `barcode` |

## Resources

- [GitHub Repository](https://github.com/shimat/opencvsharp)
- [OpenCvSharp5 (managed package)](https://www.nuget.org/packages/OpenCvSharp5)
- [Issue Tracker](https://github.com/shimat/opencvsharp/issues)