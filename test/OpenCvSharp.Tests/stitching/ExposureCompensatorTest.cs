using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class ExposureCompensatorTest : TestBase
{
    private static (Mat image, Mat mask) MakeImageAndMask()
    {
        var image = new Mat(new Size(50, 50), MatType.CV_8UC3, Scalar.All(128));
        var mask = new Mat(new Size(50, 50), MatType.CV_8UC1, Scalar.All(255));
        return (image, mask);
    }

    [Theory]
    [InlineData(ExposureCompensatorType.No)]
    [InlineData(ExposureCompensatorType.Gain)]
    [InlineData(ExposureCompensatorType.GainBlocks)]
    [InlineData(ExposureCompensatorType.Channels)]
    [InlineData(ExposureCompensatorType.ChannelsBlocks)]
    public void CreateDefaultFeedApply(ExposureCompensatorType type)
    {
        using var compensator = ExposureCompensator.CreateDefault(type);
        var (image1, mask1) = MakeImageAndMask();
        var (image2, mask2) = MakeImageAndMask();
        try
        {
            compensator.Feed([new Point(0, 0), new Point(30, 0)], [image1, image2], [mask1, mask2]);
            compensator.Apply(0, new Point(0, 0), image1, mask1);
        }
        finally
        {
            image1.Dispose();
            mask1.Dispose();
            image2.Dispose();
            mask2.Dispose();
        }
    }

    [Fact]
    public void GainCompensatorProperties()
    {
        using var compensator = new GainCompensator(nrFeeds: 2);
        Assert.Equal(2, compensator.NrFeeds);
        compensator.NrFeeds = 3;
        Assert.Equal(3, compensator.NrFeeds);
        compensator.SimilarityThreshold = 0.5;
        Assert.Equal(0.5, compensator.SimilarityThreshold);
    }

    [Fact]
    public void ChannelsCompensatorProperties()
    {
        using var compensator = new ChannelsCompensator(nrFeeds: 2);
        Assert.Equal(2, compensator.NrFeeds);
        compensator.SimilarityThreshold = 0.7;
        Assert.Equal(0.7, compensator.SimilarityThreshold);
    }

    [Fact]
    public void BlocksGainCompensatorProperties()
    {
        using var compensator = new BlocksGainCompensator(16, 16, 1);
        Assert.Equal(new Size(16, 16), compensator.BlockSize);
        compensator.BlockSize = new Size(8, 8);
        Assert.Equal(new Size(8, 8), compensator.BlockSize);
        compensator.NrGainsFilteringIterations = 3;
        Assert.Equal(3, compensator.NrGainsFilteringIterations);
    }

    [Fact]
    public void BlocksChannelsCompensatorProperties()
    {
        using var compensator = new BlocksChannelsCompensator(16, 16, 1);
        Assert.Equal(new Size(16, 16), compensator.BlockSize);
    }

    [Fact]
    public void UpdateGainProperty()
    {
        using var compensator = new GainCompensator();
        compensator.UpdateGain = false;
        Assert.False(compensator.UpdateGain);
        compensator.UpdateGain = true;
        Assert.True(compensator.UpdateGain);
    }
}
