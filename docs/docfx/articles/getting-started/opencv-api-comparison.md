# OpenCV C++, OpenCV-Python, and OpenCvSharp

OpenCvSharp exposes OpenCV to .NET applications. Its API is intentionally designed to stay as close as practical to the native OpenCV C++ API so that OpenCV concepts, documentation, and code transfer naturally to .NET. Most computer vision concepts, algorithm behavior, and parameter constraints come directly from OpenCV, while the managed surface also follows C# conventions and cannot be translated mechanically from every C++ or Python example.

Use the official OpenCV documentation for algorithm theory and native parameter requirements. Use the OpenCvSharp guides and API reference for .NET package selection, managed types, overloads, resource ownership, and application integration.

## How the three APIs relate

OpenCV is implemented primarily in C++. Its C++ API is therefore the closest description of the native functions that OpenCvSharp eventually calls.

OpenCV-Python is an official generated binding over the same native implementation. Images are normally presented as NumPy arrays, and the binding adapts many C++ output parameters into Python return values. Recent releases also provide `cv2.Mat`, a specialized `numpy.ndarray` subclass for preserving channel information, but it is not the usual image representation in Python code.

OpenCvSharp is a .NET wrapper with a managed API and a native bridge. It preserves many OpenCV names and concepts while representing them with .NET classes, enums, arrays, spans, exceptions, and `IDisposable`.

| Concept | OpenCV C++ | OpenCV-Python | OpenCvSharp |
|---|---|---|---|
| Free function | `cv::GaussianBlur` | `cv2.GaussianBlur` | `Cv2.GaussianBlur` |
| Submodule function | `cv::dnn::readNetFromONNX` | `cv2.dnn.readNetFromONNX` | `Cv2.Dnn.ReadNetFromONNX` |
| Image container | `cv::Mat` | `numpy.ndarray` | `Mat` |
| Image size | `cv::Size` | `(width, height)` tuple | `Size` |
| Coordinate | `cv::Point` | `(x, y)` tuple | `Point` |
| Color conversion enum and value | `cv::ColorConversionCodes` and `cv::COLOR_BGR2GRAY` | `cv2.COLOR_BGR2GRAY` | `ColorConversionCodes.BGR2GRAY` |
| Output image | `OutputArray dst` argument | Usually a return value | Usually a caller-owned `Mat` argument |
| Native failure | `cv::Exception` | `cv2.error` | `OpenCVException` |
| Lifetime | RAII and reference counting | Python and NumPy ownership | `IDisposable` and `using` |

The correspondence is deliberately recognizable, but it is not a promise that every native overload has an identical managed overload.

## The same operation in three languages

The following examples all load a color image, validate it, and convert it to grayscale.

### C++

```cpp
cv::Mat source = cv::imread("input.jpg", cv::IMREAD_COLOR);
if (source.empty())
{
    throw std::runtime_error("Could not read input.jpg.");
}

cv::Mat grayscale;
cv::cvtColor(source, grayscale, cv::COLOR_BGR2GRAY);
```

### Python

```python
import cv2

source = cv2.imread("input.jpg", cv2.IMREAD_COLOR)
if source is None:
    raise RuntimeError("Could not read input.jpg.")

grayscale = cv2.cvtColor(source, cv2.COLOR_BGR2GRAY)
```

### OpenCvSharp

```csharp
using OpenCvSharp;

using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (source.Empty())
{
    throw new InvalidOperationException("Could not read input.jpg.");
}

using var grayscale = new Mat();
Cv2.CvtColor(source, grayscale, ColorConversionCodes.BGR2GRAY);
```

The OpenCvSharp example resembles the C++ API because `grayscale` is an explicit destination. It also adds deterministic disposal because both managed objects own native resources.

## Translating names from C++

Most free functions in the `cv` namespace are static methods on `Cv2`, with .NET-style capitalization:

| C++ | OpenCvSharp |
|---|---|
| `cv::imread` | `Cv2.ImRead` |
| `cv::cvtColor` | `Cv2.CvtColor` |
| `cv::findContours` | `Cv2.FindContours` |
| `cv::warpPerspective` | `Cv2.WarpPerspective` |

Functions in an OpenCV submodule normally use a nested `Cv2` class. For example, `cv::dnn` maps to `Cv2.Dnn`, while wrapper object types remain in namespaces such as `OpenCvSharp.Dnn`.

OpenCvSharp enum types generally mirror named enums declared by the native C++ API. For example, OpenCV declares the unscoped enum `cv::ColorConversionCodes`; because its enumerators are injected into the enclosing `cv` namespace, C++ code normally writes `cv::COLOR_BGR2GRAY` without mentioning the enum type. OpenCvSharp exposes the same grouping through the scoped C# expression `ColorConversionCodes.BGR2GRAY`.

Apply the same rule when translating names such as `cv::INTER_AREA` or `cv::THRESH_OTSU`: identify the native enum declaration or inspect the parameter type, then use the corresponding OpenCvSharp enum member.

## Translating Python examples

Python tutorials are valuable explanations of OpenCV algorithms, but NumPy operations need special attention.

### NumPy arrays are not OpenCvSharp Mat objects

A Python image commonly exposes shape, data type, channels, slicing, broadcasting, and arithmetic through NumPy. OpenCvSharp keeps the native `cv::Mat` model instead:

| Python and NumPy | OpenCvSharp |
|---|---|
| `image.shape` | `image.Rows`, `image.Cols`, and `image.Channels()` |
| `image.dtype` | `image.Depth()` or `image.Type()` |
| `image[y, x]` | `image.At<T>(y, x)` or span-based access |
| `image[y1:y2, x1:x2]` | A `Mat` region of interest |
| NumPy vectorized expression | A corresponding `Cv2` operation, matrix expression, or span loop |

Do not translate a NumPy loop or slice one token at a time. First identify whether the operation is a native OpenCV function. Native operations usually express intent more clearly and avoid repeated managed-to-native calls.

See [Mat Basics](../guides/mat-basics.md) and [Pixel Access](../guides/pixel-access.md) for the OpenCvSharp data model.

### Python often returns C++ output arguments

The generated Python binding turns many C++ `OutputArray` arguments into return values. For example, Python thresholding returns both the selected threshold and the output image:

```python
selected_threshold, binary = cv2.threshold(
    grayscale, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)
```

OpenCvSharp keeps the destination as an argument and returns the scalar result:

```csharp
using var binary = new Mat();
double selectedThreshold = Cv2.Threshold(
    grayscale, binary, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
```

Functions with several Python return values may instead use `out` parameters, arrays, tuples, or result objects in OpenCvSharp. Check the managed signature rather than assuming the Python return shape.

## Resource ownership is a .NET concern

OpenCvSharp objects that own native resources must be disposed. This includes `Mat`, `VideoCapture`, `VideoWriter`, `Net`, feature detectors, and many other wrappers.

Use `using` declarations for local ownership and document ownership when returning an OpenCvSharp object from a method. Garbage collection does not provide timely accounting for native image buffers.

Read [Resource Management](../guides/resource-management.md) before translating a long-running Python application or a C++ pipeline that relies on scope-based RAII.

## Find the corresponding OpenCvSharp API

When starting from an OpenCV C++ or Python page:

1. Identify the C++ function and its module in the official OpenCV reference.
2. Map `cv::functionName` to `Cv2.FunctionName`, or `cv::module::functionName` to `Cv2.Module.FunctionName`.
3. Replace global constants with the enum type accepted by the OpenCvSharp parameter.
4. Search the [OpenCvSharp API reference](../../api/index.md) for the managed overload.
5. Check whether returned images or algorithm objects need disposal.
6. Confirm that the OpenCvSharp and OpenCV versions provide the same module and behavior.

If a direct mapping is missing, search the [issue tracker](https://github.com/shimat/opencvsharp/issues) before assuming that the native feature is unavailable.

## Version and package differences

This documentation describes OpenCvSharp5 and OpenCV 5.x. OpenCvSharp4 wraps the OpenCV 4.x line and targets older .NET applications. Some module names, APIs, data types, and package requirements differ between the two major versions.

See [Choose a Version and Package](package-selection.md) before combining code or documentation from different OpenCV generations.

## Official OpenCV references

- [OpenCV 5 documentation](https://docs.opencv.org/5.0/index.html)
- [OpenCV 5 tutorials](https://docs.opencv.org/5.0/tutorials/tutorials.html)
- [OpenCV-Python tutorials](https://docs.opencv.org/5.0/py_tutorials/py_tutorials.html)
- [How OpenCV-Python bindings work](https://docs.opencv.org/5.0/py_tutorials/py_bindings/py_bindings_basics/py_bindings_basics.html)
