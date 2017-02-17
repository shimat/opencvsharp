#OpenCvSharp [![Build status](https://ci.appveyor.com/api/projects/status/dvjexft02s6b3re6/branch/master?svg=true)](https://ci.appveyor.com/project/shimat/opencvsharp/branch/master)
Cross platform wrapper of OpenCV for .NET Framework.

Old versions of OpenCvSharp is maintained in [opencvsharp_2410](https://github.com/shimat/opencvsharp_2410).

## Installation
### NuGet
If you have Visual Studio 2012 or later, it is recommended to use [NuGet](http://www.nuget.org/). Search *'opencvsharp'* on the NuGet Package Manager.

| Package                                                      | NuGet                                                                                                                      |
|--------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------|
| OpenCV3.2 All-in-one package - bundles native OpenCV DLLs    | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp3-AnyCPU.svg)](https://badge.fury.io/nu/OpenCvSharp3-AnyCPU)         |
| OpenCV3.2 Minimum package                                    | [![NuGet version](https://badge.fury.io/nu/OpenCvSharp3-WithoutDll.svg)](https://badge.fury.io/nu/OpenCvSharp3-WithoutDll) |

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Requirements
* [OpenCV 3.2](http://opencv.org/)
* [Visual C++ 2015 Redistributable Package](https://www.microsoft.com/en-US/download/details.aspx?id=53840)
* [.NET Framework 2.0](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) or later / [.NET Core](https://www.microsoft.com/net/core#windowsvs2015) / [Mono](http://www.mono-project.com/Main_Page)

OpenCvSharp may not work on Unity platform. Please consider using [OpenCV for Unity](https://www.assetstore.unity3d.com/en/#!/content/21088)

## Documents
http://shimat.github.io/opencvsharp/

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

## License
OpenCvSharp is licensed under the 
**BSD 3-Clause License**. See [LICENSE.txt](https://github.com/shimat/opencvsharp/blob/master/LICENSE.txt).

OpenCvSharp.Blob uses [cvBlob](https://code.google.com/p/cvblob/) to implement blob extraction.
