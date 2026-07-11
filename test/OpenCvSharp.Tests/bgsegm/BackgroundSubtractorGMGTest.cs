using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorGMGTest : TestBase
{
    [Fact]
    public void CheckProperties()
    {
        using var gmg = BackgroundSubtractorGMG.Create();

        gmg.MaxFeatures = 30;
        Assert.Equal(30, gmg.MaxFeatures);

        gmg.DefaultLearningRate = 0.2;
        Assert.Equal(0.2, gmg.DefaultLearningRate);

        gmg.NumFrames = 100;
        Assert.Equal(100, gmg.NumFrames);

        gmg.QuantizationLevels = 20;
        Assert.Equal(20, gmg.QuantizationLevels);

        gmg.BackgroundPrior = 0.5;
        Assert.Equal(0.5, gmg.BackgroundPrior);

        gmg.SmoothingRadius = 3;
        Assert.Equal(3, gmg.SmoothingRadius);

        gmg.DecisionThreshold = 0.9;
        Assert.Equal(0.9, gmg.DecisionThreshold);

        gmg.UpdateBackgroundModel = false;
        Assert.False(gmg.UpdateBackgroundModel);

        gmg.MinVal = 10;
        Assert.Equal(10, gmg.MinVal);

        gmg.MaxVal = 200;
        Assert.Equal(200, gmg.MaxVal);
    }

    [Fact]
    public void Apply()
    {
        using var gmg = BackgroundSubtractorGMG.Create();
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();

        gmg.Apply(src, dst);

        Assert.False(dst.Empty());
    }
}
