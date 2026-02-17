# Introduction to OpenCvSharp

OpenCvSharp is a .NET wrapper for OpenCV, one of the most popular open-source computer vision libraries.

## What is OpenCvSharp?

OpenCvSharp provides cross-platform .NET bindings for OpenCV, allowing you to use OpenCV's powerful computer vision and image processing capabilities in your .NET applications.

## Supported Platforms

- **Windows**: x64, x86, UWP
- **Linux**: Ubuntu 22.04, 24.04, ARM
- **macOS**: x64
- **WebAssembly**: Browser-based applications

## Getting Started

### Installation

Install OpenCvSharp via NuGet Package Manager:

```bash
# Core library
dotnet add package OpenCvSharp4

# Native bindings (choose one based on your platform)
dotnet add package OpenCvSharp4.runtime.win                      # Windows
dotnet add package OpenCvSharp4.runtime.ubuntu.24.04-x64         # Ubuntu 24.04
```

### Quick Example

```csharp
using OpenCvSharp;

// Load an image
using var src = Cv2.ImRead("sample.jpg");

// Convert to grayscale
using var gray = new Mat();
Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

// Apply Gaussian blur
using var blurred = new Mat();
Cv2.GaussianBlur(gray, blurred, new Size(5, 5), 0);

// Save the result
Cv2.ImWrite("output.jpg", blurred);
```

## Next Steps

- Explore the [API Reference](../api/index.md) for detailed documentation
- Check out [sample projects](https://github.com/shimat/opencvsharp/tree/main/samples)
- Join the community on [GitHub](https://github.com/shimat/opencvsharp)
