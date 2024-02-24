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
        int[] c = { 0, 0, 0, 0, 1, 1, 1 };

        using (var data = new Mat(d.GetLength(0), d.GetLength(1), MatType.CV_64FC1, d))
        using (var classes = new Mat(c.Length, 1, MatType.CV_32SC1, c))
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
            }
        }
    }
}
