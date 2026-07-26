# Display Images in .NET Applications

OpenCV's HighGUI windows are useful for experiments, but production .NET applications normally display images through their UI framework. OpenCvSharp provides separate extension packages that convert `Mat` objects to framework-native bitmap types.

## Choose the integration package

Install the package that matches the application:

| UI technology | Package | Primary bitmap type |
|---|---|---|
| WPF | `OpenCvSharp5.WpfExtensions` | `BitmapSource` or `WriteableBitmap` |
| Windows Forms or GDI+ | `OpenCvSharp5.GdipExtensions` | `System.Drawing.Bitmap` |
| Avalonia | `OpenCvSharp5.AvaloniaExtensions` | `Avalonia.Media.Imaging.WriteableBitmap` |

These packages supplement the core `OpenCvSharp5` package and a matching native runtime package. See [Installation](../getting-started/installation.md) for the complete package combination.

## Display a Mat in WPF

Add the WPF extension package:

```bash
dotnet add package OpenCvSharp5.WpfExtensions
```

Convert a `Mat` to a `BitmapSource` and assign it to an `Image` control:

```csharp
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System.Windows.Media.Imaging;

using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (image.Empty())
{
    throw new IOException("Could not read input.jpg.");
}

BitmapSource imageSource = image.ToBitmapSource();
PreviewImage.Source = imageSource;
```

`ToBitmapSource` handles the channel order expected by WPF. If a bitmap is created on a worker thread and then passed to the UI thread, freeze it before publishing it:

```csharp
BitmapSource imageSource = image.ToBitmapSource();
imageSource.Freeze();
```

For a stream of identically sized frames, reuse a `WriteableBitmap` instead of allocating a new bitmap for every frame:

```csharp
WriteableBitmap displayBitmap = firstFrame.ToWriteableBitmap();
PreviewImage.Source = displayBitmap;

// Run on the UI thread when updating the bound bitmap.
WriteableBitmapConverter.ToWriteableBitmap(nextFrame, displayBitmap);
```

The source `Mat` and destination bitmap must keep compatible dimensions and pixel formats.

## Display a Mat in Avalonia

Add the Avalonia extension package:

```bash
dotnet add package OpenCvSharp5.AvaloniaExtensions
```

Convert a frame and assign it to an Avalonia `Image` control:

```csharp
using Avalonia.Media.Imaging;
using OpenCvSharp;
using OpenCvSharp.AvaloniaExtensions;

using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (image.Empty())
{
    throw new IOException("Could not read input.jpg.");
}

WriteableBitmap bitmap = image.ToWriteableBitmap();
PreviewImage.Source = bitmap;
```

The Avalonia converter accepts one-, three-, and four-channel `Mat` objects and creates a BGRA bitmap. Reuse an existing bitmap for repeated frames of the same size:

```csharp
WriteableBitmapConverter.ToWriteableBitmap(nextFrame, bitmap);
```

Update UI-owned bitmap objects through Avalonia's UI thread or dispatcher.

## Convert between Mat and System.Drawing.Bitmap

Add the GDI+ extension package:

```bash
dotnet add package OpenCvSharp5.GdipExtensions
```

Use the conversion extension methods:

```csharp
using OpenCvSharp;
using OpenCvSharp.GdipExtensions;
using System.Drawing;

using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
using Bitmap bitmap = image.ToBitmap();
using Mat roundTrip = bitmap.ToMat();
```

`System.Drawing.Common` is supported for Windows desktop use. Prefer WPF or Avalonia-native bitmap types in those frameworks rather than converting through `System.Drawing.Bitmap`.

## Keep processing away from the UI thread

A responsive camera or video application normally separates work into stages:

1. Read and process a frame on a worker task.
2. Produce an owned final `Mat` or encoded image buffer.
3. Dispatch only the display update to the UI thread.
4. Dispose replaced frames and stop the worker when the view closes.

Do not mutate the same `Mat` concurrently from capture, processing, and rendering code. Either transfer ownership of each frame or synchronize access. A `Mat` region of interest also shares storage with its parent and is not an independent frame.

For long-running streams, reuse destination `Mat` and bitmap objects when dimensions remain stable. Avoid creating an unbounded queue of frames when rendering is slower than capture; keep only the newest frame or use a bounded channel.

## HighGUI is different

`Cv2.ImShow` and `Cv2.WaitKey` use OpenCV's HighGUI backend. They are convenient for samples and debugging, but they do not integrate with WPF, Windows Forms, or Avalonia layout and event systems. Headless runtime packages disable HighGUI entirely.

Use a framework extension package for application UI, and use [Image Encoding and Conversion](image-conversion.md) when the destination is a file, HTTP response, or in-memory byte buffer rather than a control.

## From C++ or Python

C++ and Python tutorials frequently call `cv::imshow` or `cv2.imshow`. In a .NET desktop application, translate the image-processing portion but replace HighGUI display calls with the framework conversion described above. The `Mat` remains BGR or BGRA unless a converter or explicit `Cv2.CvtColor` operation changes it.

## Official OpenCV references

- [OpenCV application utilities](https://docs.opencv.org/5.0/tutorials/application_utils/application_utils.html)
- [OpenCV configuration options for GUI backends](https://docs.opencv.org/5.0/tutorials/introduction/config_reference/config_reference.html)

## Related OpenCvSharp API

- [OpenCvSharp5.WpfExtensions package](https://www.nuget.org/packages/OpenCvSharp5.WpfExtensions)
- [OpenCvSharp5.GdipExtensions package](https://www.nuget.org/packages/OpenCvSharp5.GdipExtensions)
- [OpenCvSharp5.AvaloniaExtensions package](https://www.nuget.org/packages/OpenCvSharp5.AvaloniaExtensions)
- [Mat](xref:OpenCvSharp.Mat)
