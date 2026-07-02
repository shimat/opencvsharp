using OpenCvSharp.Flann;
using Xunit;

namespace OpenCvSharp.Tests.Flann;

// ArrayProxy migration coverage (issue #1976): OpenCvSharp.Flann.Index had no test before.
public class IndexTest : TestBase
{
    [Fact]
    public void ConstructAndKnnSearch()
    {
        var features = new float[,]
        {
            { 0, 0 },
            { 10, 0 },
            { 0, 10 },
            { 10, 10 },
        };
        using var featuresMat = Mat.FromPixelData(4, 2, MatType.CV_32FC1, features);

        using var index = new global::OpenCvSharp.Flann.Index(featuresMat, new LinearIndexParams());

        // The nearest point to (1, 1) is (0, 0) at index 0.
        index.KnnSearch([1f, 1f], out var indices, out var dists, 1, new SearchParams());

        Assert.Equal(0, indices[0]);
        Assert.True(dists[0] > 0);
    }
}
