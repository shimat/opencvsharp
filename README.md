#OpenCvSharp
Cross platform wrapper of OpenCV for .NET Framework.

OpenCVを.NET Frameworkから利用するための、クロスプラットフォームで動作するラッパーです。

## Installation
### NuGet
If you have Visual Studio 2012 or later, it is recommended to use [NuGet](http://www.nuget.org/). Search *'opencvsharp'* on the NuGet Package Manager.

* [OpenCV3.2 All-in-one package](https://www.nuget.org/packages/OpenCvSharp3-AnyCPU/) - bundles native OpenCV DLLs
* [OpenCV3.2 Minimum package](https://www.nuget.org/packages/OpenCvSharp3-WithoutDll/) 
* [OpenCV2.4.10 All-in-one package](https://www.nuget.org/packages/OpenCvSharp-AnyCPU/) - bundles native OpenCV DLLs
* [OpenCV2.4.10 Minimum package](https://www.nuget.org/packages/OpenCvSharp-WithoutDll/) 

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Requirements
* [OpenCV 3.1 / 2.4.10](http://opencv.org/)
* [Visual C++ 2015 Redistributable Package](https://www.microsoft.com/en-US/download/details.aspx?id=53840) / [Visual C++ 2013 Redistributable Package](http://www.microsoft.com/en-US/download/details.aspx?id=30679) 
* [.NET Framework 2.0](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) or later / [Mono](http://www.mono-project.com/Main_Page)

On Windows, OpenCvSharp requires OpenCV DLL files built with VC++2013 (msvcr120.dll). The official pre-built DLL files in build/[x86 or x64]/vc12/bin are suitable.

## Documents
http://shimat.github.io/opencvsharp/

## Usage
For more details, see the **[Wiki](https://github.com/shimat/opencvsharp/wiki)** page.

```C#
// Edge detection by Canny algorithm
using OpenCvSharp;
// using OpenCvSharp.CPlusPlus;  //for OpenCvSharp2

class Program 
{
    static void Main() 
    {
        Mat src = new Mat("lenna.png", ImreadModes.GrayScale);   // OpenCvSharp 3.x
        //Mat src = new Mat("lenna.png", LoadMode.GrayScale); // OpenCvSharp 2.4.x
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

-----

* オリジナルのC/C++コードと可能な限り似た記述ができるように設計しています。
* 多くのクラスがIDisposableインターフェイスを実装しているので、ネイティブリソース管理が容易です。
* オブジェクト指向な書き方を強制しません。OpenCVのネイティブの関数をそのままの形式で呼べます。
* GDI+やWPFとの相互利用が可能です。OpenCVのMat/IplImageとGDI+のBitmapやWPFのWriteableBitmapとの変換機能があります。
* [Mono](http://www.mono-project.com/Main_Page)に対応しています。Linux等のクロスプラットフォームで動作します。


## License
OpenCvSharp is licensed under the 
**BSD 3-Clause License**. See [LICENSE.txt](https://github.com/shimat/opencvsharp/blob/master/LICENSE.txt).

OpenCvSharp.Blob uses [cvBlob](https://code.google.com/p/cvblob/) to implement blob extraction.
