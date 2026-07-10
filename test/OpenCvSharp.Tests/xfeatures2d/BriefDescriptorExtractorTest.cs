using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class BriefDescriptorExtractorTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var brief = BriefDescriptorExtractor.Create();
        brief.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var brief = BriefDescriptorExtractor.Create();
        using var surf = SURF.Create(500);

        var keypoints = surf.Detect(gray);
        brief.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void Properties()
    {
        using var alg = BriefDescriptorExtractor.Create();

        Assert.Equal(32, alg.DescriptorSize);

        alg.DescriptorSize = 16;
        Assert.Equal(16, alg.DescriptorSize);

        alg.UseOrientation = true;
        Assert.True(alg.UseOrientation);
    }
}
