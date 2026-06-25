using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

// Tests for the OpenCV 5 USAC additions: the PolishingMethod enum / UsacParams.FinalPolisher
// fields and the findFundamentalMat UsacParams overload.
public class UsacParamsTest : TestBase
{
    [Fact]
    public void DefaultsMatchOpenCv()
    {
        var p = new UsacParams();
        // cv::UsacParams() sets final_polisher = COV_POLISHER and final_polisher_iterations = 3.
        Assert.Equal(PolishingMethod.COV_POLISHER, p.FinalPolisher);
        Assert.Equal(3, p.FinalPolisherIterations);
    }

    [Fact]
    public void PolishingMethodValues()
    {
        Assert.Equal(0, (int)PolishingMethod.NONE_POLISHER);
        Assert.Equal(1, (int)PolishingMethod.LSQ_POLISHER);
        Assert.Equal(2, (int)PolishingMethod.MAGSAC);
        Assert.Equal(3, (int)PolishingMethod.COV_POLISHER);
    }

    [Fact]
    public void FindFundamentalMatUsac()
    {
        var points1 = Enumerable.Range(1, 12).Select(i => new Point2f(i * 10, (i * 7 % 13) * 11)).ToArray();
        var points2 = points1.Select(p => new Point2f(p.X + (p.X / 10), p.Y - 2)).ToArray();

        using var m1 = Mat.FromArray(points1);
        using var m2 = Mat.FromArray(points2);
        using var mask = new Mat();
        var usacParams = new UsacParams
        {
            FinalPolisher = PolishingMethod.LSQ_POLISHER,
            FinalPolisherIterations = 5,
        };

        // Smoke test: the USAC overload must reach OpenCV and return a matrix (possibly empty)
        // without a P/Invoke failure.
        using var f = Cv2.FindFundamentalMat(m1, m2, mask, usacParams);
        Assert.NotNull(f);
    }
}
