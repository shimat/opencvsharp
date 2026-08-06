# OpenCvSharp Documentation

These guides explain how to select, install, and use OpenCvSharp. They complement the [API reference](../api/index.md), which is generated from the OpenCvSharp source code and XML documentation comments.

## New users

Start with these pages in order:

1. [Choose a version and package](getting-started/package-selection.md).
2. [Install OpenCvSharp](getting-started/installation.md).
3. [Build your first application](getting-started/first-application.md).
4. Learn the [fundamentals of Mat](guides/mat-basics.md).
5. Learn how to [manage native resources](guides/resource-management.md).
6. Understand [array proxies and in-place processing](guides/input-output-arrays-and-in-place.md), then learn how to control [copies and native memory](guides/memory-copy-and-performance.md).

Already familiar with OpenCV C++ or Python (`cv2`)? Start with the [API comparison and translation guide](getting-started/opencv-api-comparison.md).

## OpenCvSharp and .NET guides

- [Browse the OpenCvSharp and .NET guides](guides/index.md)
- [Learn the Mat data model](guides/mat-basics.md)
- [Manage native resources](guides/resource-management.md)
- [Use InputArray, OutputArray, and in-place processing safely](guides/input-output-arrays-and-in-place.md)
- [Control copies, native memory, and hot-loop allocations](guides/memory-copy-and-performance.md)
- [Use and benchmark OpenCL acceleration with UMat](guides/opencl-and-umat.md)
- [Access and modify pixels](guides/pixel-access.md)
- [Encode images and convert UI image types](guides/image-conversion.md)
- [Store matrices and parameters in YAML, XML, or JSON](guides/file-storage.md)
- [Process uploaded images and streams in ASP.NET Core](guides/aspnet-image-processing.md)
- [Display images in .NET UI frameworks](guides/displaying-images-dotnet.md)
- [Read and write video](guides/video-io.md)

## OpenCV examples

These examples demonstrate OpenCV features through their OpenCvSharp APIs. Use the official OpenCV references linked from each page for algorithm theory and parameter definitions.

- [Browse the OpenCV examples](opencv-examples/index.md)
- [Build an image processing pipeline](opencv-examples/image-processing-pipeline.md)
- [Analyze histograms and improve contrast](opencv-examples/histograms-and-contrast.md)
- [Resize, crop, rotate, and rectify images](opencv-examples/geometric-transformations.md)
- [Create and refine masks](opencv-examples/thresholding-masks-morphology.md)
- [Measure contours and connected components](opencv-examples/contours-shape-analysis.md)
- [Detect and match local features](opencv-examples/feature-detection-and-matching.md)

## Existing applications

OpenCvSharp5 is recommended for new applications targeting .NET 8 or later. Applications that use OpenCvSharp4 can follow the [OpenCvSharp4 to OpenCvSharp5 migration guide](https://github.com/shimat/opencvsharp/blob/main/docs/migration-4-to-5.md).

## Get help

Start with [Common Errors and Diagnostics](troubleshooting/common-errors.md) when an operation fails or produces unexpected output. Check [Native Library Loading](troubleshooting/native-library-loading.md) when an application builds successfully but cannot load `OpenCvSharpExtern` at run time. For problems not covered here, search or open an issue in the [OpenCvSharp issue tracker](https://github.com/shimat/opencvsharp/issues).
