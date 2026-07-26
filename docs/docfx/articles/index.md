# OpenCvSharp Guides

These guides explain how to select, install, and use OpenCvSharp. They complement the [API reference](../api/index.md), which is generated from the OpenCvSharp source code and XML documentation comments.

## New users

Start with these pages in order:

1. [Choose a version and package](getting-started/package-selection.md).
2. [Install OpenCvSharp](getting-started/installation.md).
3. [Build your first application](getting-started/first-application.md).
4. Learn the [fundamentals of Mat](guides/mat-basics.md).
5. Learn how to [manage native resources](guides/resource-management.md).

Already familiar with OpenCV C++ or OpenCV-Python? Start with the [API comparison and translation guide](getting-started/opencv-api-comparison.md).

## Common tasks

- [Build an image processing pipeline](guides/image-processing-pipeline.md)
- [Analyze histograms and improve contrast](guides/histograms-and-contrast.md)
- [Resize, crop, rotate, and rectify images](guides/geometric-transformations.md)
- [Create and refine masks](guides/thresholding-masks-morphology.md)
- [Measure contours and connected components](guides/contours-shape-analysis.md)
- [Access and modify pixels](guides/pixel-access.md)
- [Encode images and convert UI image types](guides/image-conversion.md)
- [Display images in .NET UI frameworks](guides/displaying-images-dotnet.md)
- [Read and write video](guides/video-io.md)
- [Detect and match local features](guides/feature-detection-and-matching.md)
- [Store matrices and parameters in YAML, XML, or JSON](guides/file-storage.md)

## Existing applications

OpenCvSharp5 is recommended for new applications targeting .NET 8 or later. Applications that use OpenCvSharp4 can follow the [OpenCvSharp4 to OpenCvSharp5 migration guide](https://github.com/shimat/opencvsharp/blob/main/docs/migration-4-to-5.md).

## Get help

Start with [Common Errors and Diagnostics](troubleshooting/common-errors.md) when an operation fails or produces unexpected output. Check [Native Library Loading](troubleshooting/native-library-loading.md) when an application builds successfully but cannot load `OpenCvSharpExtern` at run time. For problems not covered here, search or open an issue in the [OpenCvSharp issue tracker](https://github.com/shimat/opencvsharp/issues).
