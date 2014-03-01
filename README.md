#OpenCvSharp
Cross platform wrapper of OpenCV for .NET Framework.

OpenCVを.NET Frameworkから利用するための、クロスプラットフォームで動作するラッパーです。

## Installation
### NuGet
If you have Visual Studio 2012 or later, it is advisable to use [NuGet](http://www.nuget.org/). Search *'opencvsharp'* on the NuGet Package Manager.
* [x86 package](https://www.nuget.org/packages/OpenCvSharp-x86/) - for 32-bit OS
* [x64 package](https://www.nuget.org/packages/OpenCvSharp-x64/) - for 64-bit OS

### Downloads
If you do not use NuGet, get DLL files from the [release page](https://github.com/shimat/opencvsharp/releases).

## Requirements
* [OpenCV 2.4.8](http://opencv.org/)
* [Visual C++ 20xx Redistributable Package](http://www.microsoft.com/ja-jp/download/details.aspx?id=30679)
* [.NET Framework 2.0](http://www.microsoft.com/ja-jp/download/details.aspx?id=1639) or later / [Mono](www.mono-project.com/)

## Features
* OpenCvSharp wraps more OpenCV's functions than SharperCV and OpenCVDotNet.
* Many classes of OpenCvSharp implement IDisposable. There is no need to manage unsafe resources. 
* OpenCvSharp does not force object-oriented programming style on you. You can also call native-style OpenCV functions.
* OpenCvSharp provides functions for converting from IplImage into Bitmap(GDI+) or WriteableBitmap(WPF).
* OpenCvSharp can work on [Mono](www.mono-project.com/). It can run on any platform which [Mono](www.mono-project.com/) supports (e.g. Linux and MacOSX). 

-----

* OpenCvSharpはSharperCVやOpenCVDotNetといった他のOpenCVのラッパーよりも多くの関数を実装しています。
* 多くのクラスがIDisposableインターフェイスを実装しているので、ネイティブリソース管理が容易です。
* オブジェクト指向な書き方を強制しません。OpenCVのネイティブの関数をそのままの形式で呼べます。
* GDI+やWPFとの相互利用が可能です。OpenCVのIplImageとGDI+のBitmapやWPFのWriteableBitmapとの変換機能があります。
* [Mono](www.mono-project.com/)に対応しています。LinuxやMacOSX等のクロスプラットフォームで動作します。
    　

## Usage
For more details, see the **[Wiki](https://github.com/shimat/opencvsharp/wiki)** page.
### C style
```C#
// Edge detection by Canny algorithm
using OpenCvSharp;

class Program 
{
    static void Main() 
    {
        IplImage src = Cv.LoadImage("lenna.png", LoadMode.GrayScale);
        IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 1);
        Cv.Canny(src, dst, 50, 200);
        Cv.NamedWindow("src image");  
        Cv.ShowImage("src image", src);
        Cv.NamedWindow("dst image");  
        Cv.ShowImage("dst image", dst);
        Cv.WaitKey();
        Cv.DestroyAllWindows();
        Cv.ReleaseImage(src);
        Cv.ReleaseImage(dst);          
    }
}
```

### Wrapper-style (for OpenCV C Interface)

```C#
// Edge detection by Canny algorithm
using OpenCvSharp;

class Program 
{
    static void Main() 
    {
        using (IplImage src = new IplImage("lenna.png", LoadMode.GrayScale))
        using (IplImage dst = new IplImage(src.Size, BitDepth.U8, 1)) 
        {
            src.Canny(dst, 50, 200);
            using (new CvWindow("src image", src)) 
            using (new CvWindow("dst image", dst)) 
            {
                Cv.WaitKey();
            }
        }
    }
}
```

### C++ style

```C#
// Edge detection by Canny algorithm
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

class Program 
{
    static void Main() 
    {
        Mat src = new Mat("lenna.png", LoadMode.GrayScale);
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


## License
OpenCvSharp is released under the [LGPL](https://github.com/shimat/opencvsharp/blob/master/LICENSE.txt).

This library uses [cvBlob](http://code.google.com/p/cvblob/) to implement blob extraction. cvBlob is under the LGPL, so OpenCvSharp follows the cvBlob licensing.


[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/shimat/opencvsharp/trend.png)](https://bitdeli.com/free "Bitdeli Badge")

