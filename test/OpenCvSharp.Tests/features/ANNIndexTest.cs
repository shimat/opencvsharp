using Xunit;

namespace OpenCvSharp.Tests.Features;

// ReSharper disable once InconsistentNaming
public class ANNIndexTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var index = ANNIndex.Create(8);
        Assert.NotEqual(IntPtr.Zero, index.RawPtr);
    }

    [Fact]
    public void AddBuildAndSearch()
    {
        const int dim = 8;
        const int count = 100;

        using var features = new Mat(count, dim, MatType.CV_32F);
        Cv2.Randu(features, 0, 1);

        // Make a known row that we will query for.
        using var query = features.Row(42).Clone();

        using var index = ANNIndex.Create(dim, ANNIndexDistance.Euclidean);
        index.SetSeed(42);
        index.AddItems(features);
        index.Build(10);

        Assert.Equal(count, index.GetItemNumber());
        Assert.True(index.GetTreeNumber() >= 1);

        using var indices = new Mat();
        using var dists = new Mat();
        index.KnnSearch(query, indices, dists, knn: 5);

        Assert.Equal(5, indices.Total());
        Assert.Equal(5, dists.Total());

        // The nearest neighbor of row 42 should be row 42 itself.
        var nearest = indices.Get<int>(0);
        Assert.Equal(42, nearest);
    }

    [Fact]
    public void SaveAndLoad()
    {
        const int dim = 4;
        using var features = new Mat(20, dim, MatType.CV_32F);
        Cv2.Randu(features, 0, 1);

        var path = Path.Combine(Path.GetTempPath(), $"annoy_{Guid.NewGuid():N}.ann");
        try
        {
            using (var index = ANNIndex.Create(dim))
            {
                index.AddItems(features);
                index.Build(5);
                index.Save(path);
            }

            Assert.True(File.Exists(path));

            using var loaded = ANNIndex.Create(dim);
            loaded.Load(path);
            Assert.Equal(20, loaded.GetItemNumber());
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
