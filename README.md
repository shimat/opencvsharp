# OpenCvSharp [![CircleCI](https://circleci.com/gh/shimat/opencvsharp/tree/master.svg?style=svg)](https://circleci.com/gh/shimat/opencvsharp/tree/master) [![Build status](https://ci.appveyor.com/api/projects/status/dvjexft02s6b3re6/branch/master?svg=true)](https://ci.appveyor.com/project/shimat/opencvsharp/branch/master) [![Actions Status](https://github.com/shimat/opencvsharp/workflows/Ubuntu%2016.04/badge.svg)](https://github.com/shimat/opencvsharp/actions) [![GitHub license](https://img.shields.io/github/license/shimat/opencvsharp.svg)](https://github.com/shimat/opencvsharp/blob/master/LICENSE) 

Cross platform wrapper of OpenCV for .NET Framework.

Old versions of OpenCvSharp are stored in [opencvsharp_2410](https://github.com/shimat/opencvsharp_2410).

## Installation
### NuGet

| Package | Description | Link |
|---------|-------------|------|
|**OpenCvSharp4**| OpenCvSharp core libraries | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.svg)](https://badge.fury.io/nu/OpenCvSharp4) |
|**OpenCvSharp4.Windows**| All-in-one package for Windows (except UWP) | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.Windows.svg)](https://badge.fury.io/nu/OpenCvSharp4.Windows) |
|**OpenCvSharp4.runtime.win**| Native bindings for Windows x64/x86 (except UWP) | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.win.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.win) |
|**OpenCvSharp4.runtime.uwp**| Native bindings for UWP (Universal Windows Platform) x64/x86/ARM | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.uwp.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.uwp) |
|**OpenCvSharp4.runtime.ubuntu.18.04-x64**| Native bindings for Ubuntu 18.04 x64 | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.18.04-x64.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.18.04-x64) |
|**OpenCvSharp4.runtime.ubuntu.16.04-x64 (beta)**| Native bindings for Ubuntu 16.04 x64. This is for Google AppEngine Flexible and made in gcr.io/google-appengine/aspnetcore:2.1 docker image. | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.16.04-x64.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.16.04-x64) |
|(beta packages)| Development Build Package    | https://ci.appveyor.com/nuget/opencvsharp |

Native binding (OpenCvSharpExtern.dll / libOpenCvSharpExtern.so) is required to work OpenCvSharp. To use OpenCvSharp, you should add both `OpenCvSharp4` and `OpenCvSharp4.runtime.*` packages to your project. Currently, native bindings for Windows, UWP, Ubuntu 18.04 and Ubuntu 16.04 are released.

Packages named OpenCvSharp3-* and OpenCvSharp-* are deprecated.
> [OpenCvSharp3-AnyCPU](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/) / [OpenCvSharp3-WithoutDll](https://www.nuget.org/packages/OpenCvSharp3-WithoutDll/) / [OpenCvSharp-AnyCPU](https://www.nuget.org/packages/OpenCvSharp-AnyCPU/) /  [OpenCvSharp-WithoutDll](https://www.nuget.org/packages/OpenCvSharp-WithoutDll/)

### Windows (except UWP)
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.win` NuGet packages to your project. You can use `OpenCvSharp4.Windows` instead.

### UWP
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.uwp` NuGet packages to your project. Note that `OpenCvSharp4.runtime.win` and `OpenCvSharp4.Windows` don't work for UWP. 

### Ubuntu 18.04
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.ubuntu.18.04.x64` NuGet packages to your project.
```
dotnet new console -n ConsoleApp01
cd ConsoleApp01
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.runtime.ubuntu.18.04-x64
# -- edit Program.cs --- # 
dotnet run
```

### Ubuntu 16.04 (Google AppEngine Flexible)
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.ubuntu.16.04.x64 (beta)` NuGet packages to your project.

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Target OpenCV
* [OpenCV 4.3.0](http://opencv.org/) with [opencv_contrib](https://github.com/opencv/opencv_contrib)

## Requirements
* (Windows)[Visual C++ 2019 Redistributable Package](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)
* [.NET Framework 4.6.1](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) or later / [.NET Core 2.0](https://www.microsoft.com/net/download) / [Mono](http://www.mono-project.com/Main_Page)

OpenCvSharp may not work on Unity platform. Please consider using [OpenCV for Unity](https://www.assetstore.unity3d.com/en/#!/content/21088)

## Usage
For more details, see **[samples](https://github.com/shimat/opencvsharp_samples/)** and **[Wiki](https://github.com/shimat/opencvsharp/wiki)** pages.

```C#
// Edge detection by Canny algorithm
using OpenCvSharp;

class Program 
{
    static void Main() 
    {
        Mat src = new Mat("lenna.png", ImreadModes.Grayscale);
        // Mat src = Cv2.ImRead("lenna.png", ImreadModes.Grayscale);
        Mat dst = new Mat();
        
        Cv2.Canny(src, dst, 50, 200);
        using (new Window("src image", src)) 
        using (new Window("dst image", dst)) 
        {
            Cv2.WaitKey();
        }
    }
}
```

## Features
* OpenCvSharp is modeled on the native OpenCV C/C++ API style as much as possible.
* Many classes of OpenCvSharp implement IDisposable. There is no need to manage unsafe resources. 
* OpenCvSharp does not force object-oriented programming style on you. You can also call native-style OpenCV functions.
* OpenCvSharp provides functions for converting from `Mat` into `Bitmap`(GDI+) or `WriteableBitmap`(WPF).

## Code samples
https://github.com/shimat/opencvsharp_samples/

## Documents
https://shimat.github.io/opencvsharp_docs/index.html

## OpenCvSharp Build Instructions
### Windows
- Install Visual Studio 2019 or later
  - VC++ features are required.
- Run `download_opencv_windows.ps1` to download OpenCV libs and headers from https://github.com/shimat/opencv_files. Those lib files are precompiled by the owner of OpenCvSharp using AppVeyor CI.
```
.\download_opencv_windows.ps1
```
- Build OpenCvSharp
  - Open `OpenCvSharp.sln` and build
  
#### How to customize OpenCV binaries yourself
If you want to use some OpenCV features that are not provided by default in OpenCvSharp (e.g. GPU), you will have to build OpenCV yourself. The binary files of OpenCV for OpenCvSharp for Windows are created in the [opencv_files](https://github.com/shimat/opencv_files) repository. See the README.

- `git clone --recursive https://github.com/shimat/opencv_files`
- Edit `build_windows.ps1` or `build_uwp.ps1` to customize the CMake parameters .
- Run the PowerShell script.

### Ubuntu 18.04

- Build OpenCV with opencv_contrib. 
  - https://www.learnopencv.com/install-opencv-4-on-ubuntu-18-04/
- Install .NET Core SDK. https://docs.microsoft.com/ja-jp/dotnet/core/install/linux-package-manager-ubuntu-1804
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
You should add reference to `opencvsharp/src/build/OpenCvSharpExtern/libOpenCvSharpExtern.so`
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

### Older Ubuntu
Refer to the [Dockerfile](https://github.com/shimat/opencvsharp/blob/master/docker/google-appengine-ubuntu.16.04-x64/Dockerfile) and [Wiki pages](https://github.com/shimat/opencvsharp/wiki).

## License
Licensed under the [BSD 3-Clause License](https://github.com/shimat/opencvsharp/blob/master/LICENSE).

## Chat
https://riot.im/app/#/room/#opencvsharp:matrix.org

## Donations

If you find the OpenCvSharp library useful and would like to show your gratitude by donating, here are some donation options. Thank you.

https://github.com/sponsors/shimat

Type | Address
------ | -------
**BTC** (Bitcoin) | 3EWhyNe3xzNNrbUgk4nXAVEkaWdpGncotc
**BCH** (Bitcoin Cash) | 3EWhyNe3xzNNrbUgk4nXAVEkaWdpGncotc
**ETH** (Ethereum) | 0x8a6089d60812ec88822d81bc6c65ba4ae63ea269
**LTC** (Litecoin) | LLpmBjjVGZf93MEohEZpkADMpnyqAS3iQC
