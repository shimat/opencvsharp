# OpenCV Examples

These examples show how to express common OpenCV workflows with OpenCvSharp. They focus on composing OpenCV operations in C# and on the managed signatures, enums, return values, and ownership decisions that differ from C++ or Python.

Use the official OpenCV documentation for algorithm theory, parameter definitions, supported data types, and numerical behavior. Use the [OpenCvSharp and .NET guides](../guides/index.md) for `Mat` ownership, array proxies, native memory, pixel access, encoding, UI integration, and application-specific concerns.

## Start with a complete pipeline

[Build an Image Processing Pipeline](image-processing-pipeline.md) combines color conversion, blurring, thresholding, morphology, contour extraction, filtering, and drawing in one example. It is a useful starting point before exploring an individual feature in more detail.

## Explore OpenCV features

- [Histograms and Contrast](histograms-and-contrast.md) calculates, plots, masks, and equalizes histograms.
- [Geometric Transformations](geometric-transformations.md) resizes, crops, rotates, and rectifies images.
- [Thresholding, Masks, and Morphology](thresholding-masks-morphology.md) creates and refines binary masks.
- [Contours and Shape Analysis](contours-shape-analysis.md) measures boundaries and connected components.
- [Feature Detection and Matching](feature-detection-and-matching.md) detects, describes, and matches local features.

## Before adapting an example

Confirm the expected image depth, channel count, color order, and value range in the linked OpenCV reference. Treat example parameters as starting points rather than universal defaults, and evaluate them against representative input from the application.

When translating an OpenCV C++ or Python example, first read [From OpenCV C++ or Python](../getting-started/opencv-api-comparison.md) for naming, output arguments, NumPy differences, and disposal requirements.
