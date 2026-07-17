using OpenCvSharp.OptFlow;
using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// ReSharper disable once InconsistentNaming
public class GPCForestTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var forest = GPCForest5.Create();
        forest.Dispose();
    }

    [Fact]
    public void TrainingParamsDefaults()
    {
        var p = new GPCTrainingParams();

        Assert.Equal(20u, p.MaxTreeDepth);
        Assert.Equal(3, p.MinNumberOfSamples);
        Assert.Equal(GPCDescType.DCT, p.DescriptorType);
        Assert.True(p.PrintProgress);
    }

    [Fact]
    public void TrainingParamsPropertyRoundTrip()
    {
        var p = new GPCTrainingParams
        {
            MaxTreeDepth = 10,
            MinNumberOfSamples = 5,
            DescriptorType = GPCDescType.WHT,
            PrintProgress = false,
        };

        Assert.Equal(10u, p.MaxTreeDepth);
        Assert.Equal(5, p.MinNumberOfSamples);
        Assert.Equal(GPCDescType.WHT, p.DescriptorType);
        Assert.False(p.PrintProgress);
    }

    [Fact]
    public void MatchingParamsDefaults()
    {
        var p = new GPCMatchingParams();

        Assert.False(p.UseOpenCL);
    }

    [Fact]
    public void MatchingParamsPropertyRoundTrip()
    {
        var p = new GPCMatchingParams(useOpenCL: true);
        Assert.True(p.UseOpenCL);

        p.UseOpenCL = false;
        Assert.False(p.UseOpenCL);
    }

    [Fact(Skip = "requires GPC training fixture data not available in this repo")]
    public void TrainAndFindCorrespondences()
    {
        // A full GPC train+match pipeline needs realistic image pairs with accurate ground-truth
        // optical flow (as used by upstream OpenCV's own GPC samples/tests). Fabricating such data
        // synthetically would not exercise the algorithm meaningfully, and no such fixture is
        // checked into this repository. This test documents the intended usage and is skipped.
        using var forest = GPCForest5.Create();
        using var samples = GPCTrainingSamples.Create(
            imagesFrom: [],
            imagesTo: [],
            gt: []);

        forest.Train(samples, new GPCTrainingParams());

        using var imgFrom = LoadImage("lenna.png");
        using var imgTo = LoadImage("lenna.png");
        forest.FindCorrespondences(imgFrom, imgTo, out var pointsFrom, out var pointsTo);

        Assert.Equal(pointsFrom.Length, pointsTo.Length);
    }
}
