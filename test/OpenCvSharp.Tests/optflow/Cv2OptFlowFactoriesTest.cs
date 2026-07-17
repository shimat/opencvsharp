using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// Covers the free-function createOptFlow_* factories in optflow.hpp that return the opaque
// base Ptr<DenseOpticalFlow>/Ptr<SparseOpticalFlow> type (DeepFlow, SimpleFlow, Farneback, SparseToDense).
public class Cv2OptFlowFactoriesTest : TestBase
{
    private static (Mat prev, Mat next) MakeShiftedGrayPair()
    {
        var prev = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(prev, new Rect(20, 20, 16, 16), Scalar.All(255), -1);
        var next = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(next, new Rect(22, 20, 16, 16), Scalar.All(255), -1); // shifted +2 px in x
        return (prev, next);
    }

    [Fact]
    public void CreateOptFlow_DeepFlow_CalcSmoke()
    {
        var (prev, next) = MakeShiftedGrayPair();
        using (prev)
        using (next)
        using (var flow = Cv2.OptFlow.CreateOptFlow_DeepFlow())
        using (var flowMat = new Mat())
        {
            flow.Calc(prev, next, flowMat);

            Assert.Equal(prev.Size(), flowMat.Size());
            Assert.Equal(2, flowMat.Channels());
        }
    }

    [Fact]
    public void CreateOptFlow_SimpleFlow_CalcSmoke()
    {
        // calcOpticalFlowSF (backing this factory) requires an 8-bit 3-channel image.
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 48, 48)];
        using var to = src[new Rect(2, 0, 48, 48)];
        using var flow = Cv2.OptFlow.CreateOptFlow_SimpleFlow();
        using var flowMat = new Mat();

        flow.Calc(from, to, flowMat);

        Assert.Equal(from.Size(), flowMat.Size());
        Assert.Equal(2, flowMat.Channels());
    }

    [Fact]
    public void CreateOptFlow_Farneback_CalcSmoke()
    {
        var (prev, next) = MakeShiftedGrayPair();
        using (prev)
        using (next)
        using (var flow = Cv2.OptFlow.CreateOptFlow_Farneback())
        using (var flowMat = new Mat())
        {
            flow.Calc(prev, next, flowMat);

            Assert.Equal(prev.Size(), flowMat.Size());
            Assert.Equal(2, flowMat.Channels());
        }
    }

    [Fact]
    public void CreateOptFlow_SparseToDense_CalcSmoke()
    {
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 64, 64)];
        using var to = src[new Rect(2, 0, 64, 64)];
        using var flow = Cv2.OptFlow.CreateOptFlow_SparseToDense();
        using var flowMat = new Mat();

        flow.Calc(from, to, flowMat);

        Assert.Equal(from.Size(), flowMat.Size());
        Assert.Equal(2, flowMat.Channels());
    }
}
