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
        }
        finally
        {
            DisposeAll(images);
        }
    }

    private static void DisposeAll(IEnumerable<Mat> mats)
    {
        foreach (var mat in mats)
            mat.Dispose();
    }
}
