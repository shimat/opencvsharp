using OpenCvSharp.VideoStab;
using Xunit;

namespace OpenCvSharp.Tests.VideoStab;

public class CvVideoStabTest : TestBase
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void StabilizeReturnsOneFramePerInput(bool color)
    {
        var frameType = color ? MatType.CV_8UC3 : MatType.CV_8UC1;
        using var baseFrame = CreateFrame(frameType);
        using var shifted = new Mat();
        using var transform = Mat.FromPixelData(2, 3, MatType.CV_64FC1,
            new double[] { 1, 0, 2, 0, 1, -1 });
        Cv2.WarpAffine(baseFrame, shifted, transform, baseFrame.Size());

        var stabilized = CvVideoStab.Stabilize(
            [baseFrame, shifted, baseFrame, shifted, baseFrame],
            radius: 2, trimRatio: 0.1f, motionModel: VideoStabMotionModel.Translation);
        try
        {
            Assert.Equal(5, stabilized.Length);
            Assert.All(stabilized, frame =>
            {
                Assert.False(frame.Empty());
                Assert.Equal(frameType, frame.Type());
                Assert.Equal(80, frame.Rows);
                Assert.Equal(80, frame.Cols);
            });
        }
        finally
        {
            foreach (var frame in stabilized)
                frame.Dispose();
        }
    }

    [Fact]
    public void RejectsMismatchedFrames()
    {
        using var first = CreateFrame(MatType.CV_8UC1);
        using var second = new Mat(80, 80, MatType.CV_8UC1);

        Assert.Throws<ArgumentException>(() => CvVideoStab.Stabilize([first, second]));
        Assert.Throws<ArgumentOutOfRangeException>(() => CvVideoStab.Stabilize([first, first], radius: 0));
    }

    private static Mat CreateFrame(MatType type)
    {
        var frame = new Mat(100, 100, type, Scalar.Black);
        for (var y = 12; y < 88; y += 12)
        {
            for (var x = 12; x < 88; x += 12)
                Cv2.Circle(frame, new Point(x, y), 2, Scalar.White, -1);
        }
        return frame;
    }
}
