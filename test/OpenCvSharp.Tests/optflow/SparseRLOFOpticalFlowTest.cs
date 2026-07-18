using OpenCvSharp.OptFlow;
using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// ReSharper disable once InconsistentNaming
public class SparseRLOFOpticalFlowTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var flow = SparseRLOFOpticalFlow.Create();
    }

    [Fact]
    public void CreateViaCv2Factory()
    {
        using var flow = Cv2.OptFlow.CreateOptFlow_SparseRLOF();
    }

    [Fact]
    public void CheckProperties()
    {
        using var flow = SparseRLOFOpticalFlow.Create();

        flow.ForwardBackward = 3.5f;
        Assert.Equal(3.5f, flow.ForwardBackward);
    }

    [Fact]
    public void RLOFOpticalFlowParameterRoundTrip()
    {
        using var flow = SparseRLOFOpticalFlow.Create();
        using var param = new RLOFOpticalFlowParameter { MaxIteration = 12 };

        flow.RLOFOpticalFlowParameter = param;

        using var readBack = flow.RLOFOpticalFlowParameter;
        Assert.Equal(12, readBack.MaxIteration);
    }

    [Fact]
    public void Calc()
    {
        // RLOF's default SupportRegionType (Cross) requires an 8-bit 3-channel image.
        using var src = LoadImage("lenna.png");
        using var prevImg = src[new Rect(0, 0, 48, 48)];
        using var nextImg = src[new Rect(2, 0, 48, 48)];
        using var flow = SparseRLOFOpticalFlow.Create();
        using var prevPts = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 24, 24 });
        using var nextPts = new Mat();
        using var status = new Mat();
        using var err = new Mat();

        flow.Calc(prevImg, nextImg, prevPts, nextPts, status, err);

        Assert.False(nextPts.Empty());
    }

    [Fact]
    public void CalcOpticalFlowSparseRLOFViaCv2()
    {
        using var src = LoadImage("lenna.png");
        using var prevImg = src[new Rect(0, 0, 48, 48)];
        using var nextImg = src[new Rect(2, 0, 48, 48)];
        using var prevPts = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 24, 24 });
        using var nextPts = new Mat();
        using var status = new Mat();
        using var err = new Mat();

        Cv2.OptFlow.CalcOpticalFlowSparseRLOF(prevImg, nextImg, prevPts, nextPts, status, err);

        Assert.False(nextPts.Empty());
    }
}
