using Xunit;

namespace OpenCvSharp.Tests.Core;

// ReSharper disable once InconsistentNaming
public class PCATest : TestBase
{
    // Samples lying exactly on the line y = 2x: rank-1 variation, so a single
    // principal component perfectly reconstructs the original data.
    private static Mat RankOneData() => Mat.FromPixelData(4, 2, MatType.CV_64FC1, new double[]
    {
        0, 0,
        1, 2,
        2, 4,
        3, 6
    });

    [Fact]
    public void ConstructAndProjectAndBackProject()
    {
        using var data = RankOneData();
        using var mean = new Mat();
        using var pca = new PCA(data, mean, PCA.Flags.DataAsRow, 1);

        Assert.Equal(1, pca.Eigenvectors.Rows);
        Assert.Equal(2, pca.Eigenvectors.Cols);

        using var projected = pca.Project(data);
        Assert.Equal(4, projected.Rows);
        Assert.Equal(1, projected.Cols);

        using var backProjected = pca.BackProject(projected);
        Assert.Equal(4, backProjected.Rows);
        Assert.Equal(2, backProjected.Cols);
        for (var i = 0; i < 4; i++)
        {
            Assert.Equal(data.Get<double>(i, 0), backProjected.Get<double>(i, 0), 4);
            Assert.Equal(data.Get<double>(i, 1), backProjected.Get<double>(i, 1), 4);
        }
    }

    [Fact]
    public void ProjectAndBackProjectOutParam()
    {
        using var data = RankOneData();
        using var mean = new Mat();
        using var pca = new PCA(data, mean, PCA.Flags.DataAsRow, 1);

        using var projected = new Mat();
        pca.Project(data, projected);
        Assert.Equal(4, projected.Rows);
        Assert.Equal(1, projected.Cols);

        using var backProjected = new Mat();
        pca.BackProject(projected, backProjected);
        Assert.Equal(4, backProjected.Rows);
        Assert.Equal(2, backProjected.Cols);
    }

    [Fact]
    public void ComputeVar()
    {
        using var data = RankOneData();
        using var mean = new Mat();
        using var pca = new PCA();

        var ret = pca.ComputeVar(data, mean, PCA.Flags.DataAsRow, 0.99);

        Assert.True(ReferenceEquals(pca, ret));
        // retainedVariance decides how many components to keep (at least 1, at most the
        // dimensionality); the exact count is an OpenCV numerical decision, not ours to pin down.
        Assert.InRange(pca.Eigenvectors.Rows, 1, 2);
        Assert.Equal(2, pca.Eigenvectors.Cols);
    }

    [Fact]
    public void ComputeReusesStructure()
    {
        using var data = RankOneData();
        using var mean = new Mat();
        using var pca = new PCA();

        var ret = pca.Compute(data, mean, PCA.Flags.DataAsRow, 1);

        Assert.True(ReferenceEquals(pca, ret));
        Assert.Equal(1, pca.Eigenvectors.Rows);
    }
}
