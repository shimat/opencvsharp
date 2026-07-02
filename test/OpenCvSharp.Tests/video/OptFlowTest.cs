using Xunit;

namespace OpenCvSharp.Tests.Video;

// ArrayProxy migration coverage (issue #1976): one test per migrated Cv2.OptFlow method.
public class OptFlowTest : TestBase
{
    private static Mat MakeSilhouette(int offset)
    {
        var mat = Mat.ZerosMat(64, 64, MatType.CV_8UC1);
        Cv2.Rectangle(mat, new Rect(20 + offset, 20, 16, 16), Scalar.All(255), -1);
        return mat;
    }

    [Fact]
    public void MotionHistoryPipeline()
    {
        using var mhi = Mat.ZerosMat(64, 64, MatType.CV_32FC1);

        using (var silhouette1 = MakeSilhouette(0))
            Cv2.OptFlow.UpdateMotionHistory(silhouette1, mhi, 1.0, 1.0);
        using (var silhouette2 = MakeSilhouette(4))
            Cv2.OptFlow.UpdateMotionHistory(silhouette2, mhi, 2.0, 1.0);

        Assert.True(Cv2.CountNonZero(mhi) > 0);

        using var mask = new Mat();
        using var orientation = new Mat();
        Cv2.OptFlow.CalcMotionGradient(mhi, mask, orientation, 0.25, 1.0);

        Assert.Equal(mhi.Size(), mask.Size());
        Assert.Equal(mhi.Size(), orientation.Size());

        var angle = Cv2.OptFlow.CalcGlobalOrientation(orientation, mask, mhi, 2.0, 1.0);
        Assert.False(double.IsNaN(angle));

        using var segmask = new Mat();
        Cv2.OptFlow.SegmentMotion(mhi, segmask, out var boundingRects, 2.0, 0.5);
        Assert.Equal(mhi.Size(), segmask.Size());
        Assert.NotNull(boundingRects);
    }

    [Fact]
    public void CalcOpticalFlowSF()
    {
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 48, 48)];
        using var to = src[new Rect(2, 0, 48, 48)];
        using var flow = new Mat();

        Cv2.OptFlow.CalcOpticalFlowSF(from, to, flow, 3, 2, 4);

        Assert.Equal(from.Size(), flow.Size());
        Assert.Equal(2, flow.Channels());
    }

    [Fact]
    public void CalcOpticalFlowSFWithAllParams()
    {
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 48, 48)];
        using var to = src[new Rect(2, 0, 48, 48)];
        using var flow = new Mat();

        Cv2.OptFlow.CalcOpticalFlowSF(
            from, to, flow, 3, 2, 4,
            sigmaDist: 4.1, sigmaColor: 25.5, postprocessWindow: 18,
            sigmaDistFix: 55.0, sigmaColorFix: 25.5, occThr: 0.35,
            upscaleAveragingRadius: 18, upscaleSigmaDist: 55.0, upscaleSigmaColor: 25.5,
            speedUpThr: 10);

        Assert.Equal(from.Size(), flow.Size());
        Assert.Equal(2, flow.Channels());
    }

    [Fact]
    public void CalcOpticalFlowSparseToDense()
    {
        using var src = LoadImage("lenna.png");
        using var from = src[new Rect(0, 0, 64, 64)];
        using var to = src[new Rect(2, 0, 64, 64)];
        using var flow = new Mat();

        Cv2.OptFlow.CalcOpticalFlowSparseToDense(from, to, flow, gridStep: 4);

        Assert.Equal(from.Size(), flow.Size());
        Assert.Equal(2, flow.Channels());
    }
}
