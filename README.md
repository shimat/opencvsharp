# OpenCvSharp [![Build status](https://ci.appveyor.com/api/projects/status/dvjexft02s6b3re6/branch/master?svg=true)](https://ci.appveyor.com/project/shimat/opencvsharp/branch/master) ![AppVeyor tests](https://img.shields.io/appveyor/tests/shimat/opencvsharp.svg) [![GitHub license](https://img.shields.io/github/license/shimat/opencvsharp.svg)](https://github.com/shimat/opencvsharp/blob/master/LICENSE) 

Cross platform wrapper of OpenCV for .NET Framework.

Old versions of OpenCvSharp is maintained in [opencvsharp_2410](https://github.com/shimat/opencvsharp_2410).

## Installation
### NuGet
If you have Visual Studio 2012 or later, it is recommended to use [NuGet](http://www.nuget.org/). Search *'opencvsharp3'* on the NuGet Package Manager.

| Package                                                      | NuGet                                                                                                                      |
|--------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------|
| All-in-one package - bundles native OpenCV DLLs    | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp3-AnyCPU.svg)](https://badge.fury.io/nu/OpenCvSharp3-AnyCPU)         |
| Minimum package                                    | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp3-WithoutDll.svg)](https://badge.fury.io/nu/OpenCvSharp3-WithoutDll) |
| Development Build Package    | https://ci.appveyor.com/nuget/opencvsharp |

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Requirements
* [OpenCV 3.4.1](http://opencv.org/)
* [Visual C++ 2017 Redistributable Package](https://go.microsoft.com/fwlink/?LinkId=746572)
* [.NET Framework 2.0](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) or later / [.NET Core 2.0](https://www.microsoft.com/net/download) / [Mono](http://www.mono-project.com/Main_Page)

OpenCvSharp may not work on UWP and Unity platform. Please consider using [OpenCV for Unity](https://www.assetstore.unity3d.com/en/#!/content/21088)

## Documents
https://shimat.github.io/opencvsharp_docs/index.html

## Usage
For more details, see the **[Wiki](https://github.com/shimat/opencvsharp/wiki)** page.

```C#
// Edge detection by Canny algorithm
using OpenCvSharp;

class Program 
{
    static void Main() 
    {
        Mat src = new Mat("lenna.png", ImreadModes.GrayScale);
        // Mat src = Cv2.ImRead("lenna.png", ImreadModes.GrayScale);
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
- Install Visual Studio 2017 or later
  - VC++ features are required.
- Get all submodules
```
git submodule update --init --recursive
```
- Get tesseract and leptonica libs
  - Unzip `x64.zip` and `x86.zip` in `tesseract\build\v141`
- Build OpenCvSharp
  - Open `OpenCvSharp.sln` and build

## License
Licensed under the [BSD 3-Clause License](https://github.com/shimat/opencvsharp/blob/master/LICENSE).
