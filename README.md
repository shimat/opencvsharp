# OpenCvSharp
[![Github Actions Windows Status](https://github.com/shimat/opencvsharp/workflows/Windows%20Server%202019/badge.svg)](https://github.com/shimat/opencvsharp/actions)  [![Github Actions Ubuntu Status](https://github.com/shimat/opencvsharp/workflows/Ubuntu%2018.04/badge.svg)](https://github.com/shimat/opencvsharp/actions) [![Github Actions MacOS Status](https://github.com/shimat/opencvsharp/workflows/macOS%2010.15/badge.svg)](https://github.com/shimat/opencvsharp/actions) [![GitHub license](https://img.shields.io/github/license/shimat/opencvsharp.svg)](https://github.com/shimat/opencvsharp/blob/master/LICENSE) 

Wrapper of OpenCV for .NET

Old versions of OpenCvSharp are stored in [opencvsharp_2410](https://github.com/shimat/opencvsharp_2410).

## NuGet

| Package | Description | Link |
|---------|-------------|------|
|**OpenCvSharp4**| OpenCvSharp core libraries | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.svg)](https://badge.fury.io/nu/OpenCvSharp4) |
|**OpenCvSharp4.WpfExtensions**| WPF Extensions | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.WpfExtensions.svg)](https://badge.fury.io/nu/OpenCvSharp4.WpfExtensions) |
|**OpenCvSharp4.Windows**| All-in-one package for Windows (except UWP) | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.Windows.svg)](https://badge.fury.io/nu/OpenCvSharp4.Windows) |
|**OpenCvSharp4.runtime.win**| Native bindings for Windows x64/x86 (except UWP) | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.win.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.win) |
|**OpenCvSharp4.runtime.uwp**| Native bindings for UWP (Universal Windows Platform) x64/x86/ARM | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.uwp.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.uwp) |
|**OpenCvSharp4.runtime.ubuntu.18.04-x64**| Native bindings for Ubuntu 18.04 x64 | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.18.04-x64.svg)](https://badge.fury.io/nu/OpenCvSharp4.runtime.ubuntu.18.04-x64) |
|**OpenCvSharp4.runtime.osx.10.15-x64**| Native bindings for macOS 10.15 x64 | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp4.runtime.osx.10.15-x64.svg)](https://www.nuget.org/packages/OpenCvSharp4.runtime.osx.10.15-x64/) |

Native binding (OpenCvSharpExtern.dll / libOpenCvSharpExtern.so) is required to work OpenCvSharp. To use OpenCvSharp, you should add both `OpenCvSharp4` and `OpenCvSharp4.runtime.*` packages to your project. Currently, native bindings for Windows, UWP, Ubuntu 18.04 and macOS are released.

Packages named OpenCvSharp3-* and OpenCvSharp-* are deprecated.
> [OpenCvSharp3-AnyCPU](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/) / [OpenCvSharp3-WithoutDll](https://www.nuget.org/packages/OpenCvSharp3-WithoutDll/) / [OpenCvSharp-AnyCPU](https://www.nuget.org/packages/OpenCvSharp-AnyCPU/) /  [OpenCvSharp-WithoutDll](https://www.nuget.org/packages/OpenCvSharp-WithoutDll/)

## Docker images
https://hub.docker.com/u/shimat
- Ubuntu 18.04 (.NET Core 3.1): [shimat/ubuntu18-dotnetcore3.1-opencv4.5.0](https://hub.docker.com/r/shimat/ubuntu18-dotnetcore3.1-opencv4.5.0)
- For Google App Engine Flexible (.NET Core 3.1): [shimat/appengine-aspnetcore3.1-opencv4.5.0](https://hub.docker.com/r/shimat/appengine-aspnetcore3.1-opencv4.5.0)
- For AWS Lambda (.NET 5): [shimat/al2-dotnet5-opencv4.5.0](https://hub.docker.com/r/shimat/al2-dotnet5-opencv4.5.0)
  - Code sample: https://github.com/shimat/opencvsharp_AWSLambdaSample

## Installation

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

### Google AppEngine Flexible (Ubuntu 16.04)
Some Docker images are provided to use OpenCvSharp with AppEngine Flexible. The native binding (libOpenCvSharpExtern) is already built in the docker image and you don't need to worry about it.
```
FROM shimat/appengine-aspnetcore3.1-opencv4.5.0:20201030

ADD ./ /app 
ENV ASPNETCORE_URLS=http://*:${PORT} 

WORKDIR /app 
ENTRYPOINT [ "dotnet", "YourAspNetCoreProject.dll" ]
```

### Ubuntu 18.04 Docker image
You can use the `shimat/ubuntu18-dotnetcore3.1-opencv4.5.0` docker image.
This issue may be helpful: https://github.com/shimat/opencvsharp/issues/920

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Target OpenCV
* [OpenCV 4.5.1](http://opencv.org/) with [opencv_contrib](https://github.com/opencv/opencv_contrib)

## Requirements
* [.NET Framework 4.6.1](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) / [.NET Core 2.0](https://www.microsoft.com/net/download) / [Mono](http://www.mono-project.com/Main_Page)
* (Windows) [Visual C++ 2019 Redistributable Package](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)
* (Windows Server) Media Foundation
```
PS1> Install-WindowsFeature Server-Media-Foundation
```
* (Ubuntu, Mac) You must pre-install all the dependency packages needed to build OpenCV. Many packages such as libjpeg must be installed in order to work OpenCV. 
https://www.learnopencv.com/install-opencv-4-on-ubuntu-18-04/


**OpenCvSharp won't work on Unity and Xamarin platform.** For Unity, please consider using [OpenCV for Unity](https://assetstore.unity.com/packages/tools/integration/opencv-for-unity-21088) or some other solutions.

**OpenCvSharp does not support CUDA.** If you want to use the CUDA features, you need to customize the native bindings yourself.

## Usage
For more details, see **[samples](https://github.com/shimat/opencvsharp_samples/)** and **[Wiki](https://github.com/shimat/opencvsharp/wiki)** pages.

**Always remember to release Mat instances! The `using` syntax is useful.**
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

As mentioned above, objects of classes, such as Mat and MatExpr, have unmanaged resources and need to be manually released by calling the Dispose() method. Worst of all, the +, -, *, and other operators create new objects each time, and these objects need to be disposed, or there will be memory leaks. Despite having the using syntax, the code still looks very verbose.

Therefore, a ResourcesTracker class is provided. The ResourcesTracker implements the IDisposable interface, and when the Dispose() method is called, all resources tracked by the ResourcesTracker are disposed. The T() method of ResourcesTracker can trace an object or an array of objects, and the method NewMat() is like T(new Mat(...). All the objects that need to be released can be wrapped with T().For example: t.T(255 - t.T(picMat * 0.8)) . Example code is as following:

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


## Features
* OpenCvSharp is modeled on the native OpenCV C/C++ API style as much as possible.
* Many classes of OpenCvSharp implement IDisposable. There is no need to manage unsafe resources. 
* OpenCvSharp does not force object-oriented programming style on you. You can also call native-style OpenCV functions.
* OpenCvSharp provides functions for converting from `Mat` into `Bitmap`(GDI+) or `WriteableBitmap`(WPF).

## Code samples
https://github.com/shimat/opencvsharp_samples/

## Documents
http://shimat.github.io/opencvsharp/api/OpenCvSharp.html

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

## Donations
If you find the OpenCvSharp library useful and would like to show your gratitude by donating, here are some donation options. Thank you.

https://github.com/sponsors/shimat
