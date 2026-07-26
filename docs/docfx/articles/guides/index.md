# OpenCvSharp and .NET Guides

These guides cover the parts of using OpenCV that are specific to OpenCvSharp, C#, and .NET applications. They focus on managed and native ownership, API shapes, memory access, framework integration, and resource lifetimes rather than repeating OpenCV's algorithm documentation.

## Core data and ownership

- [Mat Basics](mat-basics.md) introduces the managed wrapper around `cv::Mat`, including views, clones, types, and dimensions.
- [Resource Management](resource-management.md) explains deterministic disposal and ownership transfer for native resources.
- [InputArray, OutputArray, and In-place Processing](input-output-arrays-and-in-place.md) explains temporary proxies, destination arguments, and safe in-place operations.
- [Copies, Native Memory, and Performance](memory-copy-and-performance.md) distinguishes headers, views, clones, managed copies, and reusable buffers.
- [Pixel Access](pixel-access.md) compares indexed, row-based, span-based, and pointer-based access.

## Application integration

- [Image Encoding and Conversion](image-conversion.md) converts between `Mat`, encoded byte buffers, and framework bitmap types.
- [File Storage](file-storage.md) reads and writes OpenCV documents and integrates `FileNode` with `System.Text.Json`.
- [ASP.NET Core Image Uploads and Streams](aspnet-image-processing.md) processes bounded uploads, streams, and HTTP responses.
- [Display Images in .NET Applications](displaying-images-dotnet.md) integrates WPF, Windows Forms, and Avalonia controls.
- [Video I/O](video-io.md) covers capture loops, writers, backends, and resource ownership.

## OpenCV algorithms

Continue to the [OpenCV Examples](../opencv-examples/index.md) for C# examples of image-processing, transformation, contour, histogram, and feature APIs. Those pages link to the official OpenCV documentation for algorithm theory and parameter definitions.
