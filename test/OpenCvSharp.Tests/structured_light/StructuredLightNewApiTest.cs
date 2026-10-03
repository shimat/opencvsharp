using OpenCvSharp.StructuredLight;
using Xunit;

namespace OpenCvSharp.Tests;

public class StructuredLightNewApiTest : TestBase
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void SinusoidalPatternRejectsTooFewPeriods(int periods)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SinusoidalPattern.Create(
            new SinusoidalPatternParams { NumberOfPeriods = periods }));
    }

    [Fact]
    public void SinusoidalPatternRejectsMarkersOnOnePixelPeriods()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SinusoidalPattern.Create(
            new SinusoidalPatternParams { Width = 20, Height = 20, NumberOfPeriods = 20, SetMarkers = true }));
    }

    [Fact]
    public void SinusoidalPatternGeneratesImages()
    {
        using var pattern = SinusoidalPattern.Create(new SinusoidalPatternParams
        {
            Width = 64, Height = 48, NumberOfPeriods = 4, SetMarkers = false
        });
        var images = pattern.Generate();
        try
        {
            Assert.NotEmpty(images);
            Assert.All(images, image => Assert.Equal(new Size(64, 48), image.Size()));
        }
        finally
        {
            DisposeAll(images);
        }
    }

    [Fact]
    public void SinusoidalPatternRejectsUnimplementedOperations()
    {
        using var pattern = SinusoidalPattern.Create();
        Assert.Throws<NotSupportedException>(() => pattern.Decode(
            Array.Empty<IEnumerable<Mat>>(), default, Array.Empty<Mat>(), Array.Empty<Mat>()));
        Assert.Throws<NotSupportedException>(() => pattern.FindProCamMatches(default, default));
    }

    [Fact]
    public void SinusoidalPatternComputesPhaseWithImplicitMask()
    {
        using var pattern = SinusoidalPattern.Create(new SinusoidalPatternParams
        {
            Width = 256, Height = 128, NumberOfPeriods = 32,
            Method = SinusoidalPatternMethod.Psp
        });
        var images = pattern.Generate();
        try
        {
            using var phase = new Mat();
            pattern.ComputePhaseMap(images, phase);
            Assert.False(phase.Empty());
            Assert.Throws<ArgumentException>(() => pattern.ComputePhaseMap(images.Take(2), phase));
            using var uPhase = new UMat();
            Assert.Throws<ArgumentException>(() => pattern.ComputePhaseMap(images, uPhase));
            using var wrongPhase = new Mat(1, 1, MatType.CV_32FC1);
            Assert.Throws<ArgumentException>(() => pattern.ComputePhaseMap(images, wrongPhase));
        }
        finally
        {
            DisposeAll(images);
        }
    }

    [Fact]
    public void SinusoidalPatternValidatesUnwrapInputs()
    {
        using var pattern = SinusoidalPattern.Create();
        using var wrapped = new Mat(32, 32, MatType.CV_32FC1, Scalar.All(0));
        using var unwrapped = new Mat();
        using var wrongMask = new Mat(1, 1, MatType.CV_8UC1);
        Assert.Throws<ArgumentException>(() => pattern.UnwrapPhaseMap(
            wrapped, unwrapped, new Size(32, 32), wrongMask));
        pattern.UnwrapPhaseMap(wrapped, unwrapped, new Size(32, 32));
        Assert.Equal(new Size(32, 32), unwrapped.Size());
    }

    [Fact]
    public void SinusoidalPatternRejectsUndersizedPhaseImages()
    {
        using var pattern = SinusoidalPattern.Create();
        using var image1 = new Mat(32, 32, MatType.CV_8UC1);
        using var image2 = new Mat(32, 32, MatType.CV_8UC1);
        using var image3 = new Mat(32, 32, MatType.CV_8UC1);
        using var phase = new Mat();
        Assert.Throws<ArgumentException>(() => pattern.ComputePhaseMap(
            [image1, image2, image3], phase));
    }

    [Fact]
    public void SinusoidalPatternRejectsFloatDataModulationImages()
    {
        using var pattern = SinusoidalPattern.Create();
        using var image1 = new Mat(8, 8, MatType.CV_32FC1);
        using var image2 = new Mat(8, 8, MatType.CV_32FC1);
        using var image3 = new Mat(8, 8, MatType.CV_32FC1);
        using var modulation = new Mat();
        using var mask = new Mat();
        Assert.Throws<ArgumentException>(() => pattern.ComputeDataModulationTerm(
            [image1, image2, image3], modulation, mask));
    }

    private static void DisposeAll(IEnumerable<Mat> mats)
    {
        foreach (var mat in mats)
            mat.Dispose();
    }
}
