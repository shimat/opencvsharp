using Xunit;

namespace OpenCvSharp.Tests.Video;

public class SparsePyrLKOpticalFlowTest : TestBase
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
        using var flow = SparsePyrLKOpticalFlow.Create();
    }

    [Fact]
    public void CheckProperties()
    {
        using var flow = SparsePyrLKOpticalFlow.Create();

        flow.WinSize = new Size(15, 15);
        Assert.Equal(new Size(15, 15), flow.WinSize);

        flow.MaxLevel = 2;
        Assert.Equal(2, flow.MaxLevel);

        var criteria = new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 20, 0.03);
        flow.TermCriteria = criteria;
        Assert.Equal(criteria, flow.TermCriteria);

        flow.Flags = (int)OpticalFlowFlags.UseInitialFlow;
        Assert.Equal((int)OpticalFlowFlags.UseInitialFlow, flow.Flags);

        flow.MinEigThreshold = 1e-3;
        Assert.Equal(1e-3, flow.MinEigThreshold);
    }

    [Fact]
    public void Calc()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        using (var flow = SparsePyrLKOpticalFlow.Create())
        using (var prevPts = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 27, 27 }))
        using (var nextPts = new Mat())
        using (var status = new Mat())
        using (var err = new Mat())
        {
            flow.Calc(prev, next, prevPts, nextPts, status, err);

            Assert.False(nextPts.Empty());
        }
    }
}
