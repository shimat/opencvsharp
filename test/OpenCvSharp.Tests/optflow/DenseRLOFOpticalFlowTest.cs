using OpenCvSharp.OptFlow;
using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// ReSharper disable once InconsistentNaming
public class DenseRLOFOpticalFlowTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var flow = DenseRLOFOpticalFlow.Create();
    }

    [Fact]
    public void CreateViaCv2Factory()
    {
        using var flow = Cv2.OptFlow.CreateOptFlow_DenseRLOF();
    }

    [Fact]
    public void CheckProperties()
    {
        using var flow = DenseRLOFOpticalFlow.Create();

        flow.ForwardBackward = 2.5f;
        Assert.Equal(2.5f, flow.ForwardBackward);

        flow.GridStep = new Size(4, 4);
        Assert.Equal(new Size(4, 4), flow.GridStep);

        flow.Interpolation = InterpolationType.Geo;
        Assert.Equal(InterpolationType.Geo, flow.Interpolation);

        flow.EpicK = 64;
        Assert.Equal(64, flow.EpicK);

        flow.EpicSigma = 0.1f;
        Assert.Equal(0.1f, flow.EpicSigma);

        flow.EpicLambda = 500f;
        Assert.Equal(500f, flow.EpicLambda);

        flow.FgsLambda = 400f;
        Assert.Equal(400f, flow.FgsLambda);

        flow.FgsSigma = 1.0f;
        Assert.Equal(1.0f, flow.FgsSigma);

        flow.UsePostProc = false;
        Assert.False(flow.UsePostProc);
        flow.UsePostProc = true;
        Assert.True(flow.UsePostProc);

        flow.UseVariationalRefinement = true;
        Assert.True(flow.UseVariationalRefinement);

        flow.RicSpSize = 10;
        Assert.Equal(10, flow.RicSpSize);

        flow.RicSlicType = 101;
        Assert.Equal(101, flow.RicSlicType);
    }

    [Fact]
    public void RLOFOpticalFlowParameterRoundTrip()
    {
        using var flow = DenseRLOFOpticalFlow.Create();
        using var param = new RLOFOpticalFlowParameter { MaxIteration = 15 };

        flow.RLOFOpticalFlowParameter = param;

        using var readBack = flow.RLOFOpticalFlowParameter;
        Assert.Equal(15, readBack.MaxIteration);
    }

    [Fact]
    public void Calc()
    {
        // RLOF's default SupportRegionType (Cross) requires an 8-bit 3-channel image.
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 48, 48)];
        using var to = src[new Rect(2, 0, 48, 48)];
        using var flow = DenseRLOFOpticalFlow.Create();
        using var flowMat = new Mat();

        flow.Calc(from, to, flowMat);

        Assert.Equal(from.Size(), flowMat.Size());
        Assert.Equal(2, flowMat.Channels());
    }

    [Fact]
    public void CalcOpticalFlowDenseRLOFViaCv2()
    {
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 48, 48)];
        using var to = src[new Rect(2, 0, 48, 48)];
        using var flow = new Mat();

        Cv2.OptFlow.CalcOpticalFlowDenseRLOF(from, to, flow);

        Assert.Equal(from.Size(), flow.Size());
        Assert.Equal(2, flow.Channels());
    }
}
