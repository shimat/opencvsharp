using Xunit;

namespace OpenCvSharp.Tests.Video;

public class FarnebackOpticalFlowTest : TestBase
{
    private static (Mat prev, Mat next) MakeShiftedPair()
    {
        var prev = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(prev, new Rect(20, 20, 16, 16), Scalar.All(255), -1);
        var next = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(next, new Rect(22, 20, 16, 16), Scalar.All(255), -1); // shifted +2 px in x
        return (prev, next);
    }

    [Fact]
    public void CreateAndDispose()
    {
        using var flow = FarnebackOpticalFlow.Create();
    }

    [Fact]
    public void CheckProperties()
    {
        using var flow = FarnebackOpticalFlow.Create();

        flow.NumLevels = 4;
        Assert.Equal(4, flow.NumLevels);

        flow.PyrScale = 0.4;
        Assert.Equal(0.4, flow.PyrScale);

        flow.FastPyramids = true;
        Assert.True(flow.FastPyramids);
        flow.FastPyramids = false;
        Assert.False(flow.FastPyramids);

        flow.WinSize = 11;
        Assert.Equal(11, flow.WinSize);

        flow.NumIters = 8;
        Assert.Equal(8, flow.NumIters);

        flow.PolyN = 7;
        Assert.Equal(7, flow.PolyN);

        flow.PolySigma = 1.5;
        Assert.Equal(1.5, flow.PolySigma);

        flow.Flags = (int)OpticalFlowFlags.FarnebackGaussian;
        Assert.Equal((int)OpticalFlowFlags.FarnebackGaussian, flow.Flags);
    }

    [Fact]
    public void Calc()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        using (var flow = FarnebackOpticalFlow.Create())
        using (var flowMat = new Mat())
        {
            flow.Calc(prev, next, flowMat);

            Assert.Equal(prev.Size(), flowMat.Size());
            Assert.Equal(2, flowMat.Channels());
        }
    }

    [Fact]
    public void CollectGarbage()
    {
        using var flow = FarnebackOpticalFlow.Create();
        flow.CollectGarbage();
    }
}
