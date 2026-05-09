![opencvsharp](https://socialify.git.ci/shimat/opencvsharp/image?description=1&forks=1&language=1&owner=1&pattern=Plus&stargazers=1&theme=Light)

[![Github Actions Windows Status](https://github.com/shimat/opencvsharp/workflows/Windows%20Server%202025/badge.svg)](https://github.com/shimat/opencvsharp/actions)  [![Github Actions Docker Test Status](https://github.com/shimat/opencvsharp/workflows/Docker%20Test/badge.svg)](https://github.com/shimat/opencvsharp/actions)  [![Github Actions manylinux Status](https://github.com/shimat/opencvsharp/workflows/manylinux/badge.svg)](https://github.com/shimat/opencvsharp/actions)  [![Github Actions Wasm Status](https://github.com/shimat/opencvsharp/workflows/Wasm/badge.svg)](https://github.com/shimat/opencvsharp/actions) [![GitHub license](https://img.shields.io/github/license/shimat/opencvsharp.svg)](https://github.com/shimat/opencvsharp/blob/master/LICENSE) 

OpenCvSharp is a cross-platform .NET wrapper for OpenCV, providing a rich set of image processing and computer vision functionality. It supports .NET 8+, .NET Standard 2.0/2.1, and .NET Framework 4.6.1+.

## Quick Start

### Windows
```bash
dotnet add package OpenCvSharp4.Windows
```

### Linux / Ubuntu
```bash
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.official.runtime.linux-x64
# optional slim profile (smaller native dependency surface)
# dotnet add package OpenCvSharp4.official.runtime.linux-x64.slim
```

For more installation options, see the [Installation](#installation) section below.

## Features
* OpenCvSharp is modeled on the native OpenCV C/C++ API style as much as possible.
* Many classes of OpenCvSharp implement IDisposable. Unsafe resources are managed automatically. 
* OpenCvSharp does not force object-oriented programming style on you. You can also call native-style OpenCV functions.
* OpenCvSharp provides functions for converting from `Mat` to `Bitmap` (GDI+) or `WriteableBitmap` (WPF).

## Target OpenCV
* [OpenCV 4.13.0](https://opencv.org/) with [opencv_contrib](https://github.com/opencv/opencv_contrib)

## Requirements
* [.NET 8](https://www.microsoft.com/net/download) or later / .NET Standard 2.0 / .NET Standard 2.1
* .NET Framework 4.6.1 or later is supported via the .NET Standard 2.0 target (WpfExtensions also directly targets .NET Framework 4.8)
* (Windows) [Visual C++ 2022 Redistributable Package](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)
* (Windows Server) Media Foundation
```
PS1> Install-WindowsFeature Server-Media-Foundation
```
* (Linux) The official `OpenCvSharp4.official.runtime.linux-x64` package is built on manylinux_2_28 and works on Ubuntu 20.04+, Debian 10+, RHEL/AlmaLinux 8+, and other Linux distributions with glibc 2.28+. The full package includes FFmpeg (LGPL v2.1) and Tesseract statically linked.
  * The **full** package uses GTK3 for `highgui` support (`Cv2.ImShow`, `Cv2.WaitKey`, etc.). GTK3 is pre-installed on standard Ubuntu/Debian/RHEL environments. In minimal or container environments where it is absent, install it manually (`apt-get install libgtk-3-0` or `dnf install gtk3`), or use the **slim** profile instead.
  * The **slim** package (`OpenCvSharp4.official.runtime.linux-x64.slim`) disables `highgui` and has no GUI dependencies — suitable for headless and container use.


**OpenCvSharp won't work on Unity and Xamarin platforms.** For Unity, please consider using [OpenCV for Unity](https://assetstore.unity.com/packages/tools/integration/opencv-for-unity-21088) or some other solutions.

**OpenCvSharp does not support CUDA.** If you want to use CUDA features, you need to customize the native bindings yourself.

## Installation

### Windows (except UWP)
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.win` NuGet packages to your project. Alternatively, you can use the `OpenCvSharp4.Windows` all-in-one package.
For a smaller feature profile, pair `OpenCvSharp4` with `OpenCvSharp4.runtime.win.slim`, or use the all-in-one `OpenCvSharp4.Windows.Slim` package.

> ⚠️ **`OpenCvSharp4.runtime.uwp` is deprecated and no longer maintained.** The last published version targets OpenCV 4.9.0. New UWP projects are not recommended; consider migrating to WinUI 3.


### Linux (Ubuntu and other distributions)
Add `OpenCvSharp4` and `OpenCvSharp4.official.runtime.linux-x64` NuGet packages to your project. This package uses the portable `linux-x64` RID and works with .NET 8+ publish/deploy workflows out of the box.
```bash
dotnet new console -n ConsoleApp01
cd ConsoleApp01
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.official.runtime.linux-x64
# or slim profile:
# dotnet add package OpenCvSharp4.official.runtime.linux-x64.slim
# -- edit Program.cs --- # 
dotnet run
```

> ⚠️ The distro-specific `OpenCvSharp4.official.runtime.ubuntu.*` packages are **no longer maintained**. Use `OpenCvSharp4.official.runtime.linux-x64` instead.


### Slim profile module coverage

The `slim` runtime packages keep a practical subset while reducing runtime dependencies.

- Enabled modules: `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `objdetect`, `photo`, `ml`, `video`, `stitching`, `barcode`
- Disabled modules: `contrib`, `dnn`, `videoio`, `highgui`

This profile is used by:

- `OpenCvSharp4.runtime.win.slim`
- `OpenCvSharp4.Windows.Slim`
- `OpenCvSharp4.official.runtime.linux-x64.slim`

## Usage
For more details, refer to the **[samples](https://github.com/shimat/opencvsharp_samples/)** and **[Wiki](https://github.com/shimat/opencvsharp/wiki)** pages.

**Always remember to release Mat and other IDisposable resources using the `using` syntax:**
```C#
// Edge detection by Canny algorithm
using OpenCvSharp;

using var src = new Mat("lenna.png", ImreadModes.Grayscale);
using var dst = new Mat();

Cv2.Canny(src, dst, 50, 200);
using (new Window("src image", src))
using (new Window("dst image", dst))
{
    Cv2.WaitKey();
}
```

<details>
<summary><b>Advanced: Using ResourcesTracker for automatic resource management</b></summary>

As mentioned above, objects of classes such as Mat and MatExpr have unmanaged resources and need to be manually released by calling the Dispose() method. Additionally, the +, -, *, and other operators create new objects each time, and these objects need to be disposed to prevent memory leaks. Despite having the using syntax, the code can still look verbose.

Therefore, a ResourcesTracker class is provided. The ResourcesTracker implements the IDisposable interface, and when the Dispose() method is called, all resources tracked by the ResourcesTracker are disposed. The T() method of ResourcesTracker can track an object or an array of objects, and the NewMat() method is equivalent to T(new Mat(...)). All objects that need to be released can be wrapped with T(). For example: t.T(255 - t.T(picMat * 0.8)). Example code is as follows:

```csharp
using (var t = new ResourcesTracker())
{
    Mat mat1 = t.NewMat(new Size(100, 100), MatType.CV_8UC3, new Scalar(0));
    Mat mat3 = t.T(255-t.T(mat1*0.8));
    Mat[] mats1 = t.T(mat3.Split());
    Mat mat4 = t.NewMat();
    Cv2.Merge(new Mat[] { mats1[0], mats1[1], mats1[2] }, mat4);
}

using (var t = new ResourcesTracker())
{
    var src = t.T(new Mat(@"lenna.png", ImreadModes.Grayscale));
    var dst = t.NewMat();
    Cv2.Canny(src, dst, 50, 200);
    var blurredDst = t.T(dst.Blur(new Size(3, 3)));
    t.T(new Window("src image", src));
    t.T(new Window("dst image", blurredDst));
    Cv2.WaitKey();
}      
```

</details>

## Code samples
https://github.com/shimat/opencvsharp_samples/

## API Documents
http://shimat.github.io/opencvsharp/api/OpenCvSharp.html

## NuGet

### Managed libraries

| Package | Description |
|---------|-------------|
|**[OpenCvSharp4](https://www.nuget.org/packages/OpenCvSharp4/)**| OpenCvSharp core libraries |
|**[OpenCvSharp4.Extensions](https://www.nuget.org/packages/OpenCvSharp4.Extensions/)**| GDI+ Extensions |
|**[OpenCvSharp4.WpfExtensions](https://www.nuget.org/packages/OpenCvSharp4.WpfExtensions/)**| WPF Extensions |
|**[OpenCvSharp4.Windows](https://www.nuget.org/packages/OpenCvSharp4.Windows/)**| All-in-one package for Windows (except UWP) |
|**[OpenCvSharp4.Windows.Slim](https://www.nuget.org/packages/OpenCvSharp4.Windows.Slim/)**| All-in-one slim package for Windows (except UWP) |

### Native bindings

| Package | Description |
|---------|-------------|
|**[OpenCvSharp4.runtime.win](https://www.nuget.org/packages/OpenCvSharp4.runtime.win/)**| Native bindings for Windows x64 (except UWP) |
|**[OpenCvSharp4.runtime.win.slim](https://www.nuget.org/packages/OpenCvSharp4.runtime.win.slim/)**| Slim native bindings for Windows x64 (except UWP), with `core,imgproc,imgcodecs,calib3d,features2d,flann,objdetect,photo,ml,video,stitching,barcode` enabled |
|**[OpenCvSharp4.official.runtime.linux-x64](https://www.nuget.org/packages/OpenCvSharp4.official.runtime.linux-x64/)**| Native bindings for Linux x64 (portable RID, recommended). Built on manylinux_2_28. Includes FFmpeg and Tesseract statically linked. Requires GTK3 runtime (`libgtk-3.so.0`) for highgui (`Cv2.ImShow` etc.). |
|**[OpenCvSharp4.official.runtime.linux-x64.slim](https://www.nuget.org/packages/OpenCvSharp4.official.runtime.linux-x64.slim/)**| Slim native bindings for Linux x64 (portable RID), with `core,imgproc,imgcodecs,calib3d,features2d,flann,objdetect,photo,ml,video,stitching,barcode` enabled. No external runtime dependencies. |
|**[OpenCvSharp4.runtime.linux-arm](https://www.nuget.org/packages/OpenCvSharp4.runtime.linux-arm/)**| Native bindings for Linux Arm |
|**[OpenCvSharp4.runtime.wasm](https://www.nuget.org/packages/OpenCvSharp4.runtime.wasm/)**| Native bindings for WebAssembly |

> **Note:** Windows x86 (32-bit) support has been dropped as of the OpenCV 4.13.0 release series.
> The `OpenCvSharp4.runtime.win` and `OpenCvSharp4.runtime.win.slim` packages now ship **x64-only** native binaries.
> Users requiring x86 Windows support should stay on the last OpenCV 4.12.x-based packages.

Native binding (OpenCvSharpExtern.dll / libOpenCvSharpExtern.so) is required for OpenCvSharp to work. To use OpenCvSharp, you should add both `OpenCvSharp4` and `OpenCvSharp4.runtime.*` packages to your project. Currently, native bindings for Windows, Linux x64/ARM, and WebAssembly are available.

Packages named OpenCvSharp3-* and OpenCvSharp-* are deprecated.
> [OpenCvSharp3-AnyCPU](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/) / [OpenCvSharp3-WithoutDll](https://www.nuget.org/packages/OpenCvSharp3-WithoutDll/) / [OpenCvSharp-AnyCPU](https://www.nuget.org/packages/OpenCvSharp-AnyCPU/) /  [OpenCvSharp-WithoutDll](https://www.nuget.org/packages/OpenCvSharp-WithoutDll/)

## Downloads
If you are not using NuGet, you can download the DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Docker images
https://github.com/shimat?tab=packages

## OpenCvSharp Build Instructions

### Windows

#### Prerequisites
- Visual Studio 2022 / 2026, or the corresponding Build Tools, with the **Desktop development with C++** workload
- CMake 3.20+ in PATH (`winget install Kitware.CMake`)
- Git in PATH
- [vcpkg](https://github.com/microsoft/vcpkg) in PATH or `VCPKG_INSTALLATION_ROOT` set
  ```powershell
  git clone https://github.com/microsoft/vcpkg C:\vcpkg
  C:\vcpkg\bootstrap-vcpkg.bat
  # Add C:\vcpkg to PATH, or set $env:VCPKG_INSTALLATION_ROOT = 'C:\vcpkg'
  ```

#### Steps
1. Clone the repository with submodules (opencv + opencv_contrib are included as submodules):
   ```powershell
   git clone --recursive https://github.com/shimat/opencvsharp.git
   cd opencvsharp
   ```
   If you already cloned without submodules:
   ```powershell
   git submodule update --init --recursive
   ```

2. Build OpenCV from source (Tesseract and other native dependencies are automatically installed via vcpkg):
   ```powershell
   # Install vcpkg dependencies (only needed once, or after vcpkg.json changes)
   C:\vcpkg\vcpkg.exe install --triplet x64-windows-static --overlay-triplets cmake\triplets --x-install-root vcpkg_installed
   ```
   ```powershell
   .\build_opencv_windows.ps1
   # Use -Jobs N to control parallel build (default: 4)
   .\build_opencv_windows.ps1 -Jobs 8
   ```
   Output is installed to `opencv_artifacts/`.

3. Build the native wrapper `OpenCvSharpExtern`:
   ```powershell
   cmake -S src -B src\build -G "Visual Studio 17 2022" -A x64 `
         -D "CMAKE_PREFIX_PATH=$PWD\opencv_artifacts" `
         -D CMAKE_TOOLCHAIN_FILE="C:\vcpkg\scripts\buildsystems\vcpkg.cmake" `
         -D VCPKG_TARGET_TRIPLET=x64-windows-static `
         -D "VCPKG_INSTALLED_DIR=$PWD\vcpkg_installed" `
         -D "VCPKG_OVERLAY_TRIPLETS=$PWD\cmake\triplets"
   cmake --build src\build --config Release
   ```

4. Build the managed OpenCvSharp library:
   - Open `OpenCvSharp.sln` and build, or:
   ```powershell
   dotnet build src/OpenCvSharp/OpenCvSharp.csproj -c Release
   ```
   > **Note on the native DLL:** Step 3 automatically copies `OpenCvSharpExtern.dll` into `test/OpenCvSharp.Tests/` as a post-build step, so `dotnet test` works out of the box.
   > For your own application, either add `src\build\OpenCvSharpExtern\Release` to `PATH`, or copy `OpenCvSharpExtern.dll` alongside your app's output directory.

### Ubuntu

Tesseract and image libraries (libjpeg-turbo, libpng, libtiff, libwebp) can be managed either via **vcpkg** (recommended, consistent with Windows) or via the system package manager.

#### Option A: vcpkg (recommended)

Prerequisites: `cmake`, `git`, `g++`, vcpkg installed.

```bash
git clone --recursive https://github.com/shimat/opencvsharp.git
cd opencvsharp
git submodule update --init --recursive
```

```bash
# Install dependencies via vcpkg
/path/to/vcpkg/vcpkg install \
  --triplet x64-linux-static \
  --overlay-triplets cmake/triplets
```

Build OpenCV and OpenCvSharpExtern pointing to vcpkg:
```bash
cmake -C cmake/opencv_build_options.cmake \
      -S opencv -B opencv/build \
      -D OPENCV_EXTRA_MODULES_PATH=$PWD/opencv_contrib/modules \
      -D CMAKE_INSTALL_PREFIX=$PWD/opencv_artifacts \
      -D CMAKE_TOOLCHAIN_FILE=/path/to/vcpkg/scripts/buildsystems/vcpkg.cmake \
      -D VCPKG_TARGET_TRIPLET=x64-linux-static
cmake --build opencv/build -j$(nproc)
cmake --install opencv/build

cmake -S src -B src/build \
      -D CMAKE_BUILD_TYPE=Release \
      -D CMAKE_PREFIX_PATH=$PWD/opencv_artifacts \
      -D CMAKE_TOOLCHAIN_FILE=/path/to/vcpkg/scripts/buildsystems/vcpkg.cmake \
      -D VCPKG_TARGET_TRIPLET=x64-linux-static
cmake --build src/build -j$(nproc)
```

#### Option B: system packages (apt)

```bash
sudo apt-get install -y g++ cmake libtesseract-dev \
  libjpeg-dev libpng-dev libtiff-dev libwebp-dev \
  libavcodec-dev libavformat-dev libswscale-dev
```

Build OpenCV from source: https://docs.opencv.org/4.x/d7/d9f/tutorial_linux_install.html

Then build the native wrapper:
```bash
cmake -S src -B src/build \
      -D CMAKE_BUILD_TYPE=Release \
      -D CMAKE_PREFIX_PATH=${YOUR_OPENCV_INSTALL_PATH}
cmake --build src/build -j$(nproc)
```

Add a reference to the built shared library:
```bash
export LD_LIBRARY_PATH="${LD_LIBRARY_PATH}:/path/to/opencvsharp/src/build/OpenCvSharpExtern"
```

#### Build managed library (both options)
```bash
dotnet build src/OpenCvSharp/OpenCvSharp.csproj -c Release
```
## Customizing OpenCV and OpenCvSharp for embedded (ARM) Platforms

If you want to use OpenCV and OpenCvSharp on an embedded platform like a Raspberry Pi with a 64-bit OS, you have to build both libraries manually, and it's easiest to build it right on your target hardware to avoid cross-compiler toolchain challenges.  [The instructions for this build and install are here](docs/embedded-builds.md).

## Donations
If you find the OpenCvSharp library useful and would like to show your gratitude by donating, here are some donation options. Thank you.

https://github.com/sponsors/shimat
