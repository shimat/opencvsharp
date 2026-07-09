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
        using var indexParams = new LinearIndexParams();

        using var index = new global::OpenCvSharp.Flann.Index(featuresMat, indexParams);

        // The nearest point to (1, 1) is (0, 0) at index 0.
        using var searchParams = new SearchParams();
        index.KnnSearch([1f, 1f], out var indices, out var dists, 1, searchParams);

        Assert.Equal(0, indices[0]);
        Assert.True(dists[0] > 0);
    }

    [Fact]
    public void DefaultConstructorThenBuild()
    {
        var features = new float[,]
        {
            { 0, 0 },
            { 10, 0 },
            { 0, 10 },
            { 10, 10 },
        };
        using var featuresMat = Mat.FromPixelData(4, 2, MatType.CV_32FC1, features);
        using var indexParams = new KDTreeIndexParams();

        using var index = new global::OpenCvSharp.Flann.Index();
        index.Build(featuresMat, indexParams);

        Assert.Equal(FlannAlgorithm.KDTree, index.GetAlgorithm());
        Assert.Equal(FlannDistance.L2, index.GetDistance());

        using var searchParams = new SearchParams();
        index.KnnSearch([1f, 1f], out var indices, out var dists, 1, searchParams);
        Assert.Equal(0, indices[0]);
    }

    [Fact]
    public void SaveLoadRoundTrip()
    {
        const string fileName = "flann_index.dat";
        var features = new float[,]
        {
            { 0, 0 },
            { 10, 0 },
            { 0, 10 },
            { 10, 10 },
        };
        using var featuresMat = Mat.FromPixelData(4, 2, MatType.CV_32FC1, features);
        using var indexParams = new LinearIndexParams();

        using (var index = new global::OpenCvSharp.Flann.Index(featuresMat, indexParams))
        {
            index.Save(fileName);
        }

        using var loaded = new global::OpenCvSharp.Flann.Index();
        var loadedOk = loaded.Load(featuresMat, fileName);
        Assert.True(loadedOk);

        using var searchParams = new SearchParams();
        loaded.KnnSearch([1f, 1f], out var indices, out _, 1, searchParams);
        Assert.Equal(0, indices[0]);

        loaded.Release();
    }
}
