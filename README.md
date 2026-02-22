![opencvsharp](https://socialify.git.ci/shimat/opencvsharp/image?description=1&forks=1&language=1&owner=1&pattern=Plus&stargazers=1&theme=Light)

[![Github Actions Windows Status](https://github.com/shimat/opencvsharp/workflows/Windows%20Server%202025/badge.svg)](https://github.com/shimat/opencvsharp/actions)  [![Github Actions Ubuntu 22.04 Status](https://github.com/shimat/opencvsharp/workflows/Ubuntu%2022.04/badge.svg)](https://github.com/shimat/opencvsharp/actions)  [![Github Actions Ubuntu 24.04 Status](https://github.com/shimat/opencvsharp/workflows/Ubuntu%2024.04/badge.svg)](https://github.com/shimat/opencvsharp/actions) [![GitHub license](https://img.shields.io/github/license/shimat/opencvsharp.svg)](https://github.com/shimat/opencvsharp/blob/master/LICENSE) 

OpenCvSharp is a cross-platform .NET wrapper for OpenCV, providing a rich set of image processing and computer vision functionality. It supports .NET Framework 4.8, .NET 8 and later, and .NET Standard 2.0.

## Quick Start

### Windows
```bash
dotnet add package OpenCvSharp4.Windows
```

### Linux / Ubuntu
```bash
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.official.runtime.ubuntu.24.04-x64
# optional slim profile (smaller native dependency surface)
# dotnet add package OpenCvSharp4.official.runtime.ubuntu.24.04-x64.slim
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
* [.NET Framework 4.8](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) / [.NET 8](https://www.microsoft.com/net/download) or later / .NET Standard 2.0
* (Windows) [Visual C++ 2022 Redistributable Package](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)
* (Windows Server) Media Foundation
```
PS1> Install-WindowsFeature Server-Media-Foundation
```
* (Ubuntu) You must pre-install all the dependency packages needed to build OpenCV. Many packages such as libjpeg must be installed for OpenCV to work. 
https://docs.opencv.org/4.x/d7/d9f/tutorial_linux_install.html


**OpenCvSharp won't work on Unity and Xamarin platforms.** For Unity, please consider using [OpenCV for Unity](https://assetstore.unity.com/packages/tools/integration/opencv-for-unity-21088) or some other solutions.

**OpenCvSharp does not support CUDA.** If you want to use CUDA features, you need to customize the native bindings yourself.

## Installation

### Windows (except UWP)
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.win` NuGet packages to your project. Alternatively, you can use the `OpenCvSharp4.Windows` all-in-one package.
For a smaller feature profile, pair `OpenCvSharp4` with `OpenCvSharp4.runtime.win.slim`, or use the all-in-one `OpenCvSharp4.Windows.Slim` package.

### UWP
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.uwp` NuGet packages to your project. Note that `OpenCvSharp4.runtime.win` and `OpenCvSharp4.Windows` don't work for UWP. 

### Ubuntu 24.04
Add `OpenCvSharp4` and `OpenCvSharp4.official.runtime.ubuntu.24.04-x64` NuGet packages to your project.
```bash
dotnet new console -n ConsoleApp01
cd ConsoleApp01
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.official.runtime.ubuntu.24.04-x64
# or slim profile:
# dotnet add package OpenCvSharp4.official.runtime.ubuntu.24.04-x64.slim
# -- edit Program.cs --- # 
dotnet run
```

### Other Linux distributions
Add `OpenCvSharp4` and the appropriate Ubuntu runtime package (for example `OpenCvSharp4.official.runtime.ubuntu.24.04-x64`) to your project. The Ubuntu runtime packages are built on the specified Ubuntu releases and may work on similar distributions.


### Slim profile module coverage

The `slim` runtime packages keep a practical subset while reducing runtime dependencies.

- Enabled modules: `core`, `imgproc`, `imgcodecs`, `calib3d`, `features2d`, `flann`, `objdetect`, `photo`
- Disabled modules: `contrib`, `dnn`, `ml`, `video`, `videoio`, `highgui`, `stitching`, `barcode`

This profile is used by:

- `OpenCvSharp4.runtime.win.slim`
- `OpenCvSharp4.Windows.Slim`
- `OpenCvSharp4.official.runtime.ubuntu.22.04-x64.slim`
- `OpenCvSharp4.official.runtime.ubuntu.24.04-x64.slim`

## Usage
For more details, refer to the **[samples](https://github.com/shimat/opencvsharp_samples/)** and **[Wiki](https://github.com/shimat/opencvsharp/wiki)** pages.

**Always remember to release Mat and other IDisposable resources using the `using` syntax:**
```C#
// C# 8
// Edge detection by Canny algorithm
using OpenCvSharp;

class Program 
{
    static void Main() 
    {
        using var src = new Mat("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        
        Cv2.Canny(src, dst, 50, 200);
        using (new Window("src image", src)) 
        using (new Window("dst image", dst)) 
        {
            Cv2.WaitKey();
        }
    }
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
|**[OpenCvSharp4.runtime.win](https://www.nuget.org/packages/OpenCvSharp4.runtime.win/)**| Native bindings for Windows x64/x86 (except UWP) |
|**[OpenCvSharp4.runtime.win.slim](https://www.nuget.org/packages/OpenCvSharp4.runtime.win.slim/)**| Slim native bindings for Windows x64/x86 (except UWP), with `core,imgproc,imgcodecs,calib3d,features2d,flann,objdetect,photo` enabled |
|**[OpenCvSharp4.runtime.uwp](https://www.nuget.org/packages/OpenCvSharp4.runtime.uwp/)**| Native bindings for UWP (Universal Windows Platform) x64/x86/ARM |
|**[OpenCvSharp4.official.runtime.ubuntu.22.04-x64](https://www.nuget.org/packages/OpenCvSharp4.official.runtime.ubuntu.22.04-x64/)**| Native bindings for Ubuntu 22.04 x64 |
|**[OpenCvSharp4.official.runtime.ubuntu.22.04-x64.slim](https://www.nuget.org/packages/OpenCvSharp4.official.runtime.ubuntu.22.04-x64.slim/)**| Slim native bindings for Ubuntu 22.04 x64, with `core,imgproc,imgcodecs,calib3d,features2d,flann,objdetect,photo` enabled |
|**[OpenCvSharp4.official.runtime.ubuntu.24.04-x64](https://www.nuget.org/packages/OpenCvSharp4.official.runtime.ubuntu.24.04-x64/)**| Native bindings for Ubuntu 24.04 x64 |
|**[OpenCvSharp4.official.runtime.ubuntu.24.04-x64.slim](https://www.nuget.org/packages/OpenCvSharp4.official.runtime.ubuntu.24.04-x64.slim/)**| Slim native bindings for Ubuntu 24.04 x64, with `core,imgproc,imgcodecs,calib3d,features2d,flann,objdetect,photo` enabled |
|**[OpenCvSharp4.runtime.linux-arm](https://www.nuget.org/packages/OpenCvSharp4.runtime.linux-arm/)**| Native bindings for Linux Arm |
|**[OpenCvSharp4.runtime.wasm](https://www.nuget.org/packages/OpenCvSharp4.runtime.wasm/)**| Native bindings for WebAssembly |

Native binding (OpenCvSharpExtern.dll / libOpenCvSharpExtern.so) is required for OpenCvSharp to work. To use OpenCvSharp, you should add both `OpenCvSharp4` and `OpenCvSharp4.runtime.*` packages to your project. Currently, native bindings for Windows, UWP, Ubuntu, Linux ARM, and WebAssembly are available.

Packages named OpenCvSharp3-* and OpenCvSharp-* are deprecated.
> [OpenCvSharp3-AnyCPU](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/) / [OpenCvSharp3-WithoutDll](https://www.nuget.org/packages/OpenCvSharp3-WithoutDll/) / [OpenCvSharp-AnyCPU](https://www.nuget.org/packages/OpenCvSharp-AnyCPU/) /  [OpenCvSharp-WithoutDll](https://www.nuget.org/packages/OpenCvSharp-WithoutDll/)

## Downloads
If you are not using NuGet, you can download the DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Docker images
https://github.com/shimat?tab=packages

## OpenCvSharp Build Instructions

### Windows
- Install Visual Studio 2022 or later
  - VC++ features are required.
- Run `download_opencv_windows.ps1` to download OpenCV libs and headers from https://github.com/shimat/opencv_files. Those lib files are precompiled by the owner of OpenCvSharp using GitHub Actions.
```
.\download_opencv_windows.ps1
```
- Build OpenCvSharp
  - Open `OpenCvSharp.sln` and build
  
#### How to customize OpenCV binaries yourself
If you want to use OpenCV features that are not included by default in OpenCvSharp (e.g., GPU support), you will need to build OpenCV yourself. The binary files of OpenCV for OpenCvSharp for Windows are created in the [opencv_files](https://github.com/shimat/opencv_files) repository. See the README for details.

- `git clone --recursive https://github.com/shimat/opencv_files`
- Edit `build_windows.ps1` or `build_uwp.ps1` to customize the CMake parameters
- Run the PowerShell script

### Ubuntu
- Build OpenCV with opencv_contrib: https://docs.opencv.org/4.x/d7/d9f/tutorial_linux_install.html
- Install .NET Core SDK: https://learn.microsoft.com/ja-jp/dotnet/core/install/linux-ubuntu
- Get OpenCvSharp source files
```
git clone https://github.com/shimat/opencvsharp.git
cd opencvsharp
git fetch --all --tags --prune && git checkout ${OPENCVSHARP_VERSION}
```

- Build native wrapper `OpenCvSharpExtern`
```
cd opencvsharp/src
mkdir build
cd build
cmake -D CMAKE_INSTALL_PREFIX=${YOUR_OPENCV_INSTALL_PATH} ..
make -j 
make install
```
You should add a reference to `opencvsharp/src/build/OpenCvSharpExtern/libOpenCvSharpExtern.so`
```
export LD_LIBRARY_PATH="${LD_LIBRARY_PATH}:/home/shimat/opencvsharp/src/build/OpenCvSharpExtern"
```

- Add `OpenCvSharp4` NuGet package to your project
```
dotnet new console -n ConsoleApp01
cd ConsoleApp01
dotnet add package OpenCvSharp4
# -- edit Program.cs --- # 
dotnet run
```
## Customizing OpenCV and OpenCvSharp for embedded (ARM) Platforms

If you want to use OpenCV and OpenCvSharp on an embedded platform like a Raspberry Pi with a 64-bit OS, you have to build both libraries manually, and it's easiest to build it right on your target hardware to avoid cross-compiler toolchain challenges.  [The instructions for this build and install are here](embedded-builds.md).

## Donations
If you find the OpenCvSharp library useful and would like to show your gratitude by donating, here are some donation options. Thank you.

https://github.com/sponsors/shimat
