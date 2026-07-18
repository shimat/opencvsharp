using Xunit;

namespace OpenCvSharp.Tests.Video;

public class VariationalRefinementTest : TestBase
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
        using var refinement = VariationalRefinement.Create();
    }

    [Fact]
    public void CheckProperties()
    {
        using var refinement = VariationalRefinement.Create();

        refinement.FixedPointIterations = 3;
        Assert.Equal(3, refinement.FixedPointIterations);

        refinement.SorIterations = 4;
        Assert.Equal(4, refinement.SorIterations);

        refinement.Omega = 1.6f;
        Assert.Equal(1.6f, refinement.Omega);

        refinement.Alpha = 15f;
        Assert.Equal(15f, refinement.Alpha);

        refinement.Delta = 4f;
        Assert.Equal(4f, refinement.Delta);

        refinement.Gamma = 8f;
        Assert.Equal(8f, refinement.Gamma);

        refinement.Epsilon = 0.002f;
        Assert.Equal(0.002f, refinement.Epsilon);
    }

    [Fact]
    public void Calc()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        using (var refinement = VariationalRefinement.Create())
        using (var flow = new Mat(prev.Size(), MatType.CV_32FC2, Scalar.All(0)))
        {
            refinement.Calc(prev, next, flow);

            Assert.Equal(prev.Size(), flow.Size());
            Assert.Equal(2, flow.Channels());
        }
    }

    [Fact]
    public void CalcUV()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        using (var refinement = VariationalRefinement.Create())
        using (var flowU = new Mat(prev.Size(), MatType.CV_32FC1, Scalar.All(0)))
        using (var flowV = new Mat(prev.Size(), MatType.CV_32FC1, Scalar.All(0)))
        {
            refinement.CalcUV(prev, next, flowU, flowV);

            Assert.Equal(prev.Size(), flowU.Size());
            Assert.Equal(prev.Size(), flowV.Size());
        }
    }
}
