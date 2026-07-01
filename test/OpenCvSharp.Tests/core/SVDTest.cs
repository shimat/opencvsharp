using Xunit;

namespace OpenCvSharp.Tests.Core;

// ReSharper disable once InconsistentNaming
public class SVDTest : TestBase
{
    private static Mat Diagonal2x2() => Mat.FromPixelData(2, 2, MatType.CV_64FC1, new double[]
    {
        3, 0,
        0, 2
    });

    [Fact]
    public void ConstructAndRun()
    {
        using var src = Diagonal2x2();
        using var svd = new SVD(src, SVD.Flags.None);

        using var w = svd.W();
        using var u = svd.U();
        using var vt = svd.Vt();

        Assert.Equal(2, (int) w.Total());
        Assert.Equal(2, u.Rows);
        Assert.Equal(2, vt.Cols);

        // Singular values of a diagonal matrix are its (sorted, non-negative) diagonal entries.
        Assert.Equal(3.0, w.Get<double>(0), 4);
        Assert.Equal(2.0, w.Get<double>(1), 4);

        using var svd2 = new SVD();
        var ret = svd2.Run(src, SVD.Flags.None);
        Assert.True(ReferenceEquals(svd2, ret));
    }

    [Fact]
    public void BackSubstInstance()
    {
        using var src = Diagonal2x2();
        using var svd = new SVD(src, SVD.Flags.None);

        // Solve src * x = rhs for x = [1, 1] (so rhs = [3, 2] given the diagonal src above).
        using var rhs = Mat.FromPixelData(2, 1, MatType.CV_64FC1, new double[] { 3, 2 });
        using var dst = new Mat();
        svd.BackSubst(rhs, dst);

        Assert.Equal(1.0, dst.Get<double>(0), 4);
        Assert.Equal(1.0, dst.Get<double>(1), 4);
    }

    [Fact]
    public void StaticComputeAndBackSubst()
    {
        using var src = Diagonal2x2();
        using var w = new Mat();
        using var u = new Mat();
        using var vt = new Mat();
        SVD.Compute(src, w, u, vt);

        Assert.Equal(3.0, w.Get<double>(0), 4);
        Assert.Equal(2.0, w.Get<double>(1), 4);

        using var rhs = Mat.FromPixelData(2, 1, MatType.CV_64FC1, new double[] { 3, 2 });
        using var dst = new Mat();
        SVD.BackSubst(w, u, vt, rhs, dst);

        Assert.Equal(1.0, dst.Get<double>(0), 4);
        Assert.Equal(1.0, dst.Get<double>(1), 4);
    }

    [Fact]
    public void StaticComputeSingularValuesOnly()
    {
        using var src = Diagonal2x2();
        using var w = new Mat();
        SVD.Compute(src, w, SVD.Flags.None);

        Assert.Equal(3.0, w.Get<double>(0), 4);
        Assert.Equal(2.0, w.Get<double>(1), 4);
    }

    [Fact]
    public void SolveZ()
    {
        // A singular matrix: rows are linearly dependent, so |m*dst| is minimized (=0)
        // by a non-trivial unit vector dst in its null space.
        using var src = Mat.FromPixelData(2, 2, MatType.CV_64FC1, new double[]
        {
            1, 2,
            2, 4
        });
        using var dst = new Mat();

        SVD.SolveZ(src, dst);

        Assert.Equal(2, (int) dst.Total());
        var norm = Math.Sqrt((dst.Get<double>(0) * dst.Get<double>(0)) + (dst.Get<double>(1) * dst.Get<double>(1)));
        Assert.Equal(1.0, norm, 4);

        // dst must lie in src's null space: src * dst ~= 0.
        var r0 = (src.Get<double>(0, 0) * dst.Get<double>(0)) + (src.Get<double>(0, 1) * dst.Get<double>(1));
        var r1 = (src.Get<double>(1, 0) * dst.Get<double>(0)) + (src.Get<double>(1, 1) * dst.Get<double>(1));
        Assert.True(Math.Abs(r0) < 1e-6);
        Assert.True(Math.Abs(r1) < 1e-6);
    }
}
