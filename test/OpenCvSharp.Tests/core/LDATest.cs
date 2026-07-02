using Xunit;

namespace OpenCvSharp.Tests.Core;

// ReSharper disable once InconsistentNaming
public class LDATest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using (var lda = new LDA())
        {
            GC.KeepAlive(lda);
        }
    }

    // https://blog.csdn.net/kekong0713/article/details/53606880
    [Fact]
    // ReSharper disable once InconsistentNaming
    public void LDASample()
    {
        double[,] d = {{2.95,6.63},{2.53,7.79},{3.57,5.65},{3.16,5.47},{2.58,4.46},{2.16,6.22},{3.27,3.52}};
        int[] c = [0, 0, 0, 0, 1, 1, 1];

        using (var data = Mat.FromPixelData(d.GetLength(0), d.GetLength(1), MatType.CV_64FC1, d))
        using (var classes = Mat.FromPixelData(c.Length, 1, MatType.CV_32SC1, c))
        using (var lda = new LDA(data, classes))
        {
            using (var eigenvectors = lda.Eigenvectors())
            {
                Assert.Equal(2, eigenvectors.Rows);
                Assert.Equal(1, eigenvectors.Cols);
                Assert.Equal(-1.5836, eigenvectors.Get<double>(0), 4);
                Assert.Equal(-0.659729, eigenvectors.Get<double>(1), 4);
            }

            using (var eigenvalues = lda.Eigenvalues())
            {
                Assert.Equal(1, eigenvalues.Rows);
                Assert.Equal(1, eigenvalues.Cols);
                Assert.Equal(3.1447, eigenvalues.Get<double>(0), 4);
            }

            using (var project = lda.Project(data))
            {
                Assert.Equal(d.GetLength(0), project.Rows);
                Assert.Equal(1, project.Cols);

                Assert.Equal(-9.04562, project.Get<double>(0), 5);
                Assert.Equal(-9.14579, project.Get<double>(1), 5);
                Assert.Equal(-9.38091, project.Get<double>(2), 5);
                Assert.Equal(-8.61289, project.Get<double>(3), 5);
                Assert.Equal(-7.02807, project.Get<double>(4), 5);
                Assert.Equal(-7.52409, project.Get<double>(5), 5);
                Assert.Equal(-7.50061, project.Get<double>(6), 5);

                using var reconstructed = lda.Reconstruct(project);
                Assert.Equal(d.GetLength(0), reconstructed.Rows);
                Assert.Equal(d.GetLength(1), reconstructed.Cols);
            }
        }
    }

    [Fact]
    public void SubspaceProjectAndReconstruct()
    {
        // With an identity basis and a zero mean, subspaceProject/subspaceReconstruct
        // reduce to the identity transform (src*W and src*W^T respectively), giving an
        // exact round trip that is easy to verify without depending on LDA's own numerics.
        using var w = Mat.EyeMat(2, 2, MatType.CV_64FC1);
        using var mean = Mat.ZerosMat(1, 2, MatType.CV_64FC1);
        using var src = Mat.FromPixelData(2, 2, MatType.CV_64FC1, new double[] { 1, 2, 3, 4 });

        using var projected = LDA.SubspaceProject(w, mean, src);
        Assert.Equal(2, projected.Rows);
        Assert.Equal(2, projected.Cols);
        Assert.Equal(1.0, projected.Get<double>(0, 0), 6);
        Assert.Equal(2.0, projected.Get<double>(0, 1), 6);
        Assert.Equal(3.0, projected.Get<double>(1, 0), 6);
        Assert.Equal(4.0, projected.Get<double>(1, 1), 6);

        using var reconstructed = LDA.SubspaceReconstruct(w, mean, projected);
        Assert.Equal(2, reconstructed.Rows);
        Assert.Equal(2, reconstructed.Cols);
        Assert.Equal(1.0, reconstructed.Get<double>(0, 0), 6);
        Assert.Equal(2.0, reconstructed.Get<double>(0, 1), 6);
        Assert.Equal(3.0, reconstructed.Get<double>(1, 0), 6);
        Assert.Equal(4.0, reconstructed.Get<double>(1, 1), 6);
    }
}
