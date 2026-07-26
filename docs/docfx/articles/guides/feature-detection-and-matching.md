# Feature Detection and Matching

Local features describe visually distinctive points so that the same scene or object can be associated across images. A typical workflow detects keypoints, computes a descriptor for each point, matches descriptors, and rejects ambiguous matches.

This guide replaces the old per-algorithm Wiki examples for BRISK, ORB, FREAK, MSER, SIFT, SURF, and StarDetector. Those short examples used obsolete APIs and did not explain how detector, descriptor, and matcher choices must agree.

## Choose a feature algorithm

| Algorithm | Descriptor | Matcher norm | Typical reason to choose it |
|---|---|---|---|
| ORB | Binary | `Hamming` | Fast general-purpose baseline with no extra model files |
| BRISK | Binary | `Hamming` | Binary features with scale and rotation handling |
| AKAZE | Usually binary | `Hamming` | Nonlinear scale-space features |
| SIFT | Floating point | `L2` | More robust matching when computation cost is acceptable |

Some algorithms only detect keypoints, and some only compute descriptors. For example, MSER detects regions and FREAK computes a descriptor for supplied keypoints. Combine such components only when their keypoint and descriptor requirements are compatible.

Algorithms under `xfeatures2d`, including SURF and FREAK, require a runtime package that contains the corresponding OpenCV contrib module. Prefer a core algorithm such as ORB or SIFT unless a contrib algorithm is specifically required.

## Match two images with ORB

The following example uses two-nearest-neighbor matching and Lowe's ratio test to discard ambiguous matches:

```csharp
using OpenCvSharp;

using var image1 = Cv2.ImRead("object.jpg", ImreadModes.Grayscale);
using var image2 = Cv2.ImRead("scene.jpg", ImreadModes.Grayscale);
if (image1.Empty() || image2.Empty())
{
    throw new FileNotFoundException("Could not decode one or both input images.");
}

using var orb = ORB.Create(nFeatures: 1_000);
using var descriptors1 = new Mat();
using var descriptors2 = new Mat();

orb.DetectAndCompute(image1, default, out KeyPoint[] keypoints1, descriptors1);
orb.DetectAndCompute(image2, default, out KeyPoint[] keypoints2, descriptors2);

if (descriptors1.Empty() || descriptors2.Empty())
{
    throw new InvalidOperationException("No descriptors were found in one or both images.");
}

using var matcher = new BFMatcher(NormTypes.Hamming);
DMatch[][] nearestNeighbors = matcher.KnnMatch(
    descriptors1,
    descriptors2,
    k: 2);

DMatch[] goodMatches = nearestNeighbors
    .Where(matches => matches.Length == 2)
    .Where(matches => matches[0].Distance < 0.75f * matches[1].Distance)
    .Select(matches => matches[0])
    .ToArray();

using var visualization = new Mat();
Cv2.DrawMatches(
    image1,
    keypoints1,
    image2,
    keypoints2,
    goodMatches,
    visualization,
    flags: DrawMatchesFlags.NotDrawSinglePoints);

Cv2.ImWrite("matches.jpg", visualization);
```

The ratio `0.75` is a starting point, not a universal threshold. A lower value keeps fewer, less ambiguous matches. Evaluate it against representative data.

## Match the norm to the descriptor

The matcher compares descriptor rows. Binary descriptors such as ORB and BRISK represent bit patterns and require Hamming distance. Floating-point descriptors such as SIFT require L2 distance.

Using the wrong norm may produce poor results even though the code compiles:

```csharp
using var orbMatcher = new BFMatcher(NormTypes.Hamming);
using var siftMatcher = new BFMatcher(NormTypes.L2);
```

ORB with `WTA_K` equal to 3 or 4 requires `NormTypes.Hamming2` instead of `Hamming`.

## Matching is not geometric verification

Descriptor similarity alone does not prove that all accepted pairs belong to one object or scene transformation. For planar objects, estimate a homography with RANSAC from the matched keypoint coordinates and keep only inliers. For 3D scenes or calibrated cameras, choose a geometric model appropriate to the application.

Good production checks often include:

- A minimum number of accepted matches.
- A minimum number or ratio of geometric inliers.
- Limits on the estimated scale, orientation, or projected shape.
- Tests on images that contain no valid match.

## Reuse algorithm objects

Creating detectors and matchers for every frame adds unnecessary overhead. In a video or service pipeline, create them once, reuse them for sequential calls, and dispose them when the pipeline shuts down. Do not use one mutable native algorithm instance concurrently from multiple threads unless the underlying OpenCV API documents that use as safe.

## Related guides

- [Mat Basics](mat-basics.md)
- [Image Processing Pipeline](image-processing-pipeline.md)
- [Resource Management](resource-management.md)

## Official OpenCV references

- [OpenCV features framework](https://docs.opencv.org/5.0/main_modules/features.html)
- [OpenCV feature tutorials](https://docs.opencv.org/5.0/tutorials/features/features.html)

## Related API

- [ORB](xref:OpenCvSharp.ORB)
- [SIFT](xref:OpenCvSharp.SIFT)
- [BFMatcher](xref:OpenCvSharp.BFMatcher)
- [Cv2.DrawMatches](xref:OpenCvSharp.Cv2.DrawMatches*)
