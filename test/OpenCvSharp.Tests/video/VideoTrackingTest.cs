using Xunit;

namespace OpenCvSharp.Tests.Video;

// ArrayProxy migration coverage (issue #1976): one test per migrated Cv2 method.
public class VideoTrackingTest : TestBase
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
    public void CamShift()
    {
        using var prob = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(prob, new Rect(40, 40, 20, 20), Scalar.All(255), -1);
        var window = new Rect(30, 30, 40, 40);
        var rr = Cv2.CamShift(prob, ref window, new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 10, 1));

        Assert.True(rr.Size.Width > 0 && rr.Size.Height > 0);
    }

    [Fact]
    public void MeanShift()
    {
        using var prob = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(prob, new Rect(40, 40, 20, 20), Scalar.All(255), -1);
        var window = new Rect(20, 20, 40, 40);
        var iters = Cv2.MeanShift(prob, ref window, new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 10, 1));

        Assert.True(iters >= 0);
    }

    [Fact]
    public void BuildOpticalFlowPyramid()
    {
        using var img = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(img, new Rect(20, 20, 16, 16), Scalar.All(255), -1);
        var maxLevel = Cv2.BuildOpticalFlowPyramid(img, out var pyramid, new Size(11, 11), 2);

        Assert.True(maxLevel >= 0);
        Assert.NotEmpty(pyramid);
        foreach (var p in pyramid)
            p.Dispose();
    }

    [Fact]
    public void CalcOpticalFlowPyrLK()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        {
            using var prevPts = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 27, 27 });
            using var nextPts = new Mat();
            using var status = new Mat();
            using var err = new Mat();
            Cv2.CalcOpticalFlowPyrLK(prev, next, prevPts, nextPts, status, err, new Size(15, 15), 2);

            Assert.False(nextPts.Empty());
        }
    }

    [Fact]
    public void CalcOpticalFlowFarneback()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        {
            using var flow = new Mat();
            Cv2.CalcOpticalFlowFarneback(prev, next, flow, 0.5, 3, 15, 3, 5, 1.2, OpticalFlowFlags.None);

            Assert.Equal(prev.Size(), flow.Size());
            Assert.Equal(2, flow.Channels());
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ComputeECC()
    {
        using var a = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(a, new Rect(20, 20, 20, 20), Scalar.All(255), -1);
        var cc = Cv2.ComputeECC(a, a);

        Assert.True(cc > 0.99); // identical inputs -> near-perfect correlation
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void FindTransformECC()
    {
        using var a = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(a, new Rect(16, 16, 28, 28), Scalar.All(255), -1);
        using var warp = Mat.FromPixelData(2, 3, MatType.CV_32FC1, new float[] { 1, 0, 0, 0, 1, 0 });
        var cc = Cv2.FindTransformECC(a, a, warp, MotionTypes.Translation,
            new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 50, 1e-4), default, 5);

        Assert.True(cc > 0.9); // identical inputs -> near-perfect alignment
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void FindTransformECCWithMask()
    {
        using var a = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(a, new Rect(16, 16, 28, 28), Scalar.All(255), -1);
        using var mask = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(255));
        using var warp = Mat.FromPixelData(2, 3, MatType.CV_32FC1, new float[] { 1, 0, 0, 0, 1, 0 });

        var cc = Cv2.FindTransformECCWithMask(a, a, mask, mask, warp, MotionTypes.Translation,
            new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 50, 1e-4), 5);

        Assert.True(cc > 0.9); // identical inputs -> near-perfect alignment
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void FindTransformECCMultiScale()
    {
        using var a = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(a, new Rect(16, 16, 28, 28), Scalar.All(255), -1);
        using var warp = Mat.FromPixelData(2, 3, MatType.CV_32FC1, new float[] { 1, 0, 0, 0, 1, 0 });

        var eccParams = new ECCParameters
        {
            MotionType = MotionTypes.Translation,
            Criteria = new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 50, 1e-4),
            ItersPerLevel = [10, 10, 10],
            GaussFiltSize = 5,
            NLevels = 3,
            Interpolation = InterpolationFlags.Linear,
        };

        var cc = Cv2.FindTransformECCMultiScale(a, a, warp, eccParams);

        Assert.True(cc > 0.9); // identical inputs -> near-perfect alignment
    }

    [Fact]
    public void ReadWriteOpticalFlow()
    {
        var path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.flo");
        try
        {
            using (var flow = new Mat(8, 8, MatType.CV_32FC2, Scalar.All(1.5)))
            {
                var written = Cv2.WriteOpticalFlow(path, flow);
                Assert.True(written);
            }

            using var loaded = Cv2.ReadOpticalFlow(path);
            Assert.Equal(new Size(8, 8), loaded.Size());
            Assert.Equal(2, loaded.Channels());
            Assert.Equal(MatType.CV_32FC2, loaded.Type());
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
