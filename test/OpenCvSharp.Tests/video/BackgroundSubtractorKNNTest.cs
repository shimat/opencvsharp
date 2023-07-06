using Xunit;

namespace OpenCvSharp.Tests.Video;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorKNNTest : TestBase
{
    [Fact]
    public void CheckProperties()
    {
        using (var knn = BackgroundSubtractorKNN.Create())
        {
            knn.DetectShadows = knn.DetectShadows;
            knn.History = knn.History;
            knn.ShadowThreshold = knn.ShadowThreshold;
            knn.ShadowValue = knn.ShadowValue;
            knn.Dist2Threshold = knn.Dist2Threshold;
            knn.KNNSamples = knn.KNNSamples;
            knn.NSamples = knn.NSamples;
        }
    }

    [Fact]
    public void Apply()
    {
        using (var knn = BackgroundSubtractorKNN.Create())
        using (var src = LoadImage("lenna.png"))
        using (var dst = new Mat())
        {
            knn.Apply(src, dst);
        }
    }
}
