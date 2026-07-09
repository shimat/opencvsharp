using OpenCvSharp.Flann;
using Xunit;

namespace OpenCvSharp.Tests.Flann;

// Coverage for issue #2008 gaps: HierarchicalClusteringIndexParams (previously unwrapped)
// and the SearchParams overload with explore_all_trees.
public class IndexParamsTest : TestBase
{
    [Fact]
    public void HierarchicalClusteringIndexParamsConstructAndSearch()
    {
        var features = new float[,]
        {
            { 0, 0 },
            { 10, 0 },
            { 0, 10 },
            { 10, 10 },
        };
        using var featuresMat = Mat.FromPixelData(4, 2, MatType.CV_32FC1, features);
        using var indexParams = new HierarchicalClusteringIndexParams();

        using var index = new global::OpenCvSharp.Flann.Index(featuresMat, indexParams);

        using var searchParams = new SearchParams();
        index.KnnSearch([1f, 1f], out var indices, out var dists, 1, searchParams);

        Assert.Equal(0, indices[0]);
        Assert.True(dists[0] > 0);
    }

    [Fact]
    public void SearchParamsExploreAllTreesConstructs()
    {
        using var searchParams = new SearchParams(32, 0.0f, true, true);
        Assert.False(searchParams.IsDisposed);
    }
}
