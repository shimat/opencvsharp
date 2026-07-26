# Histograms and Contrast

An image histogram counts how many pixels fall into each intensity range. Histograms are useful for diagnosing exposure, comparing image distributions, selecting thresholds, and improving contrast.

## Calculate a grayscale histogram

This example calculates 256 bins over the complete intensity range of an 8-bit grayscale image:

```csharp
using OpenCvSharp;

using var source = Cv2.ImRead("input.jpg", ImreadModes.Grayscale);
if (source.Empty())
{
    throw new FileNotFoundException("Could not decode input.jpg.");
}

using var histogram = new Mat();
Cv2.CalcHist(
    images: [source],
    channels: [0],
    mask: default,
    hist: histogram,
    dims: 1,
    histSize: [256],
    ranges: [new Rangef(0, 256)]);

float darkPixelCount = histogram.At<float>(32);
Console.WriteLine($"Pixels with intensity 32: {darkPixelCount}");
```

The result is a `CV_32FC1` matrix with one row per bin. The range end is exclusive, so `[0, 256)` covers every possible value in an 8-bit image.

## Plot the histogram

Normalize the bin counts to the plot height before drawing them:

```csharp
const int plotWidth = 512;
const int plotHeight = 300;

using var normalized = new Mat();
Cv2.Normalize(
    histogram,
    normalized,
    alpha: 0,
    beta: plotHeight - 1,
    normType: NormTypes.MinMax);

using var plot = new Mat(
    rows: plotHeight,
    cols: plotWidth,
    type: MatType.CV_8UC3,
    s: Scalar.White);

int binWidth = plotWidth / 256;
for (int bin = 1; bin < 256; bin++)
{
    int previousHeight = (int)Math.Round(normalized.At<float>(bin - 1));
    int currentHeight = (int)Math.Round(normalized.At<float>(bin));

    Cv2.Line(
        plot,
        new Point((bin - 1) * binWidth, plotHeight - 1 - previousHeight),
        new Point(bin * binWidth, plotHeight - 1 - currentHeight),
        Scalar.Black,
        thickness: 2);
}

Cv2.ImWrite("histogram.png", plot);
```

Normalization here is only for display. Preserve the original histogram when its counts or proportions will be used in later calculations.

## Limit calculation to a region

`CalcHist` accepts an 8-bit single-channel mask. Nonzero mask pixels select the source pixels to include:

```csharp
using var mask = new Mat(source.Size(), MatType.CV_8UC1, Scalar.Black);
Cv2.Rectangle(
    mask,
    new Rect(50, 40, 200, 150),
    Scalar.White,
    thickness: -1);

using var regionHistogram = new Mat();
Cv2.CalcHist(
    images: [source],
    channels: [0],
    mask: mask,
    hist: regionHistogram,
    dims: 1,
    histSize: [256],
    ranges: [new Rangef(0, 256)]);
```

The mask must have the same width and height as the source image.

## Improve grayscale contrast

Global histogram equalization redistributes intensities across the complete image:

```csharp
using var equalized = new Mat();
Cv2.EqualizeHist(source, equalized);
```

It works on an 8-bit single-channel source. It can over-amplify noise or produce unnatural results when illumination varies across the image.

Contrast Limited Adaptive Histogram Equalization (CLAHE) processes local tiles and limits amplification:

```csharp
using var clahe = Cv2.CreateCLAHE(
    clipLimit: 2.0,
    tileGridSize: new Size(8, 8));
using var improved = new Mat();

clahe.Apply(source, improved);
Cv2.ImWrite("improved.png", improved);
```

Treat `clipLimit` and `tileGridSize` as parameters to tune against representative images. Smaller tiles adapt to more local variation but can emphasize noise and tile boundaries.

## Color histograms

For a BGR image, channel index 0 is blue, 1 is green, and 2 is red. Separate BGR channel histograms describe the storage channels, but they are often poor measures of perceived color similarity. Convert to a color space such as HSV or Lab first when hue, saturation, or perceptual brightness is the quantity of interest.

## Common mistakes

- Match the histogram range to the source depth and the intended values; `[0, 256)` is specific to an 8-bit intensity channel.
- Do not compare raw bin counts from images or masks containing different numbers of pixels. Normalize the histograms first.
- Histogram similarity does not preserve spatial layout. Two visually different images can have the same histogram.
- Use a mask for a region of interest when the surrounding background would dominate the distribution.

## Related guides

- [Mat Basics](../guides/mat-basics.md)
- [Image Processing Pipeline](image-processing-pipeline.md)
- [Pixel Access](../guides/pixel-access.md)

## Official OpenCV references

- [OpenCV histogram API](https://docs.opencv.org/5.0/main_modules/imgproc_hist.html)
- [Histogram calculation tutorial](https://docs.opencv.org/5.0/tutorials/imgproc/histograms/histogram_calculation/histogram_calculation.html)
- [Histogram equalization tutorial](https://docs.opencv.org/5.0/tutorials/imgproc/histograms/histogram_equalization/histogram_equalization.html)

## Related API

- [Cv2.CalcHist](xref:OpenCvSharp.Cv2.CalcHist*)
- [Cv2.EqualizeHist](xref:OpenCvSharp.Cv2.EqualizeHist*)
- [CLAHE](xref:OpenCvSharp.CLAHE)
