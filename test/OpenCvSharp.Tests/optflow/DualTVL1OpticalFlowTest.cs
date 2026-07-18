using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// NB: cv::optflow::DualTVL1OpticalFlow is referenced with its full OpenCvSharp.OptFlow.* name below
// because the sibling superres module already has a flat (namespace OpenCvSharp) DualTVL1OpticalFlow
// class wrapping the unrelated cv::superres::DualTVL1OpticalFlow. Since this file's own namespace
// (OpenCvSharp.Tests.OptFlow) nests under OpenCvSharp, that flat type would otherwise win name
// resolution over a `using OpenCvSharp.OptFlow;` import (or alias) for the same simple name.

// ReSharper disable once InconsistentNaming
public class DualTVL1OpticalFlowTest : TestBase
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
        using var flow = OpenCvSharp.OptFlow.DualTVL1OpticalFlow.Create();
    }

    [Fact]
    public void CreateViaCv2Factory()
    {
        using var flow = Cv2.OptFlow.CreateOptFlow_DualTVL1();
    }

    [Fact]
    public void CheckProperties()
    {
        using var flow = OpenCvSharp.OptFlow.DualTVL1OpticalFlow.Create();

        flow.Tau = 0.3;
        Assert.Equal(0.3, flow.Tau);

        flow.Lambda = 0.1;
        Assert.Equal(0.1, flow.Lambda);

        flow.Theta = 0.35;
        Assert.Equal(0.35, flow.Theta);

        flow.Gamma = 0.1;
        Assert.Equal(0.1, flow.Gamma);

        flow.ScalesNumber = 3;
        Assert.Equal(3, flow.ScalesNumber);

        flow.WarpingsNumber = 4;
        Assert.Equal(4, flow.WarpingsNumber);

        flow.Epsilon = 0.02;
        Assert.Equal(0.02, flow.Epsilon);

        flow.InnerIterations = 20;
        Assert.Equal(20, flow.InnerIterations);

        flow.OuterIterations = 8;
        Assert.Equal(8, flow.OuterIterations);

        flow.ScaleStep = 0.7;
        Assert.Equal(0.7, flow.ScaleStep);

        flow.MedianFiltering = 3;
        Assert.Equal(3, flow.MedianFiltering);

        flow.UseInitialFlow = true;
        Assert.True(flow.UseInitialFlow);
        flow.UseInitialFlow = false;
        Assert.False(flow.UseInitialFlow);
    }

    [Fact]
    public void Calc()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        using (var flow = OpenCvSharp.OptFlow.DualTVL1OpticalFlow.Create())
        using (var flowMat = new Mat())
        {
            flow.Calc(prev, next, flowMat);

            Assert.Equal(prev.Size(), flowMat.Size());
            Assert.Equal(2, flowMat.Channels());
        }
    }
}
