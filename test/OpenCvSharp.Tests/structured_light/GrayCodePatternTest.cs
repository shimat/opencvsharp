using OpenCvSharp.StructuredLight;
using Xunit;

namespace OpenCvSharp.Tests.StructuredLight;

public class GrayCodePatternTest : TestBase
{
    [Fact]
    public void GenerateAndDecodeProjectorPixel()
    {
        const int width = 16;
        const int height = 8;
        using var grayCode = GrayCodePattern.Create(width, height);

        var patternImages = grayCode.Generate();
        try
        {
            Assert.Equal(14, grayCode.GetNumberOfPatternImages());
            Assert.Equal(grayCode.GetNumberOfPatternImages(), patternImages.Length);
            Assert.All(patternImages, image =>
            {
                Assert.Equal(width, image.Cols);
                Assert.Equal(height, image.Rows);
                Assert.Equal(MatType.CV_8UC1, image.Type());
            });

            Assert.True(grayCode.TryGetProjectorPixel(
                patternImages,
                x: 11,
                y: 5,
                out var projectorPixel));
            Assert.Equal(new Point(11, 5), projectorPixel);
        }
        finally
        {
            DisposeAll(patternImages);
        }
    }

    [Fact]
    public void DecodeProducesDisparityMap()
    {
        const int width = 16;
        const int height = 8;
        using var grayCode = GrayCodePattern.Create(width, height);
        grayCode.SetWhiteThreshold(1);
        grayCode.SetBlackThreshold(1);

        var firstCameraPatterns = grayCode.Generate();
        var secondCameraPatterns = firstCameraPatterns.Select(ShiftLeft).ToArray();
        try
        {
            using var black = new Mat();
            using var white = new Mat();
            grayCode.GetImagesForShadowMasks(black, white);
            using var blackSecondCamera = black.Clone();
            using var whiteSecondCamera = white.Clone();
            using var disparity = new Mat();

            var decoded = grayCode.Decode(
                [firstCameraPatterns, secondCameraPatterns],
                disparity,
                [black, blackSecondCamera],
                [white, whiteSecondCamera]);

            Assert.True(decoded);
            Assert.Equal(height, disparity.Rows);
            Assert.Equal(width, disparity.Cols);
            Assert.Equal(MatType.CV_64FC1, disparity.Type());
            Assert.Equal(-1.0, disparity.Get<double>(height / 2, width / 2), 6);
        }
        finally
        {
            DisposeAll(firstCameraPatterns);
            DisposeAll(secondCameraPatterns);
        }
    }

    private static Mat ShiftLeft(Mat source)
    {
        using var transformation = Mat.FromArray(new double[,]
        {
            { 1, 0, -1 },
            { 0, 1, 0 },
        });
        var destination = new Mat();
        Cv2.WarpAffine(
            source,
            destination,
            transformation,
            source.Size(),
            InterpolationFlags.Nearest,
            BorderTypes.Replicate);
        return destination;
    }

    private static void DisposeAll(IEnumerable<Mat> images)
    {
        foreach (var image in images)
            image.Dispose();
    }
}
