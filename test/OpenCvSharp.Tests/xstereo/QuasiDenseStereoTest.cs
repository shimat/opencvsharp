using Xunit;

namespace OpenCvSharp.Tests.XStereo;

public class QuasiDenseStereoTest : TestBase
{
    [Fact]
    public void ProcessAndGetDisparity()
    {
        using var imgLeft = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var imgRight = imgLeft.Clone();

        using var qds = QuasiDenseStereo.Create(new Size(imgLeft.Width, imgLeft.Height));
        qds.Process(imgLeft, imgRight);

        using var disparity = qds.GetDisparity();
        Assert.False(disparity.Empty());
        Assert.Equal(imgLeft.Rows, disparity.Rows);
        Assert.Equal(imgLeft.Cols, disparity.Cols);

        var sparseMatches = qds.GetSparseMatches();
        Assert.NotEmpty(sparseMatches);

        var denseMatches = qds.GetDenseMatches();
        Assert.NotEmpty(denseMatches);

        // imgLeft and imgRight are identical, so corresponding points should map to themselves.
        var match = qds.GetMatch(imgLeft.Width / 2, imgLeft.Height / 2);
        Assert.True(match.X >= 0 && match.Y >= 0);
    }

    [Fact]
    public void ParamGetSet()
    {
        using var qds = QuasiDenseStereo.Create(new Size(100, 100));

        var param = qds.Param;
        param.CorrWinSizeX = 7;
        param.CorrWinSizeY = 7;
        qds.Param = param;

        var updated = qds.Param;
        Assert.Equal(7, updated.CorrWinSizeX);
        Assert.Equal(7, updated.CorrWinSizeY);
    }
}
