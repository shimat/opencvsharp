# OpenCvSharp [![Build status](https://ci.appveyor.com/api/projects/status/dvjexft02s6b3re6/branch/master?svg=true)](https://ci.appveyor.com/project/shimat/opencvsharp/branch/master) [![GitHub license](https://img.shields.io/github/license/shimat/opencvsharp.svg)](https://github.com/shimat/opencvsharp/blob/master/LICENSE) 

Cross platform wrapper of OpenCV for .NET Framework.

Old versions of OpenCvSharp are maintained in [opencvsharp_2410](https://github.com/shimat/opencvsharp_2410).

## Installation
### NuGet

| Package | Description | Link |
|---------|-------------|------|
|**OpenCvSharp4**| OpenCvSharp core libraries | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.svg)](https://badge.fury.io/nu/OpenCvSharp4) |
|**OpenCvSharp4.Windows**| All-in-one package for Windows - same as [OpenCvSharp3-AnyCPU](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/) | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.Windows.svg)](https://badge.fury.io/nu/OpenCvSharp4.Windows) |
|**OpenCvSharp4.runtime.win**| Native bindings for Windows x64/x86 | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.win.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.win) |
|**OpenCvSharp4.runtime.ubuntu.18.04-x64**| Native bindings for Ubuntu 18.04 x64 | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.18.04-x64.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.18.04-x64) |
|(beta packages)| Development Build Package    | https://ci.appveyor.com/nuget/opencvsharp |

Native binding (OpenCvSharpExtern.dll / libOpenCvSharpExtern.so) is required to work OpenCvSharp. To use OpenCvSharp, you should add both `OpenCvSharp4` and `OpenCvSharp4.runtime.*` packages to your project. Currently, native bindings for Windows and Ubuntu 18.04 are released.

Packages named OpenCvSharp3-* and OpenCvSharp-* are deprecated.
- [OpenCvSharp3-AnyCPU](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/)
- [OpenCvSharp3-WithoutDll](https://www.nuget.org/packages/OpenCvSharp3-WithoutDll/)
- [OpenCvSharp-AnyCPU](https://www.nuget.org/packages/OpenCvSharp-AnyCPU/)
- [OpenCvSharp-WithoutDll](https://www.nuget.org/packages/OpenCvSharp-WithoutDll/)

### Windows
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.win` NuGet packages to your project. You can use `OpenCvSharp4.Windows` instead.

### Ubuntu 18.04
Add `OpenCvSharp4` and `OpenCvSharp4.runtime.ubuntu.18.04.x64` NuGet packages to your project
```
dotnet new console -n ConsoleApp01
cd ConsoleApp01
dotnet add package OpenCvSharp4
dotnet add package OpenCvSharp4.runtime.ubuntu.18.04-x64
# -- edit Program.cs --- # 
dotnet run
```

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Requirements
* [OpenCV 4.0.1](http://opencv.org/) with [opencv_contrib](https://github.com/opencv/opencv_contrib)
* (Windows)[Visual C++ 2017 Redistributable Package](https://go.microsoft.com/fwlink/?LinkId=746572)
* [.NET Framework 2.0](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) or later / [.NET Core 2.0](https://www.microsoft.com/net/download) / [Mono](http://www.mono-project.com/Main_Page)

OpenCvSharp may not work on UWP and Unity platform. Please consider using [OpenCV for Unity](https://www.assetstore.unity3d.com/en/#!/content/21088)

## Documents
https://shimat.github.io/opencvsharp_docs/index.html

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
* OpenCvSharp provides functions for converting from Mat/IplImage into Bitmap(GDI+) or WriteableBitmap(WPF).
* OpenCvSharp can work on [Mono](http://www.mono-project.com/Main_Page). It can run on any platform which [Mono](http://www.mono-project.com/Main_Page) supports (e.g. Linux). 

## OpenCvSharp Build Instructions
### Windows
- Install Visual Studio 2017 or later
  - VC++ features are required.
- Get all submodules
```
git submodule update --init --recursive
```
- Build OpenCvSharp
  - Open `OpenCvSharp.sln` and build

### Ubuntu 18.04

- Build OpenCV with opencv_contrib. 
  - https://www.learnopencv.com/install-opencv-4-on-ubuntu-18-04/
- Install .NET Core SDK. https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-2.1.202
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
Refer to the [Dockerfile](https://github.com/shimat/opencvsharp/blob/master/Dockerfile) and [Wiki pages](https://github.com/shimat/opencvsharp/wiki).

## License
Licensed under the [BSD 3-Clause License](https://github.com/shimat/opencvsharp/blob/master/LICENSE).

## Donations

If you find the OpenCvSharp library useful and would like to show your gratitude by donating, here are some donation options. Thank you.

Type | Address
------ | -------
**BTC** (Bitcoin) | 3EWhyNe3xzNNrbUgk4nXAVEkaWdpGncotc
**BCH** (Bitcoin Cash) | 3EWhyNe3xzNNrbUgk4nXAVEkaWdpGncotc
**ETH** (Ethereum) | 0x8a6089d60812ec88822d81bc6c65ba4ae63ea269
**LTC** (Litecoin) | LLpmBjjVGZf93MEohEZpkADMpnyqAS3iQC
