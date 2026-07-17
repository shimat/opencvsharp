using Xunit;

namespace OpenCvSharp.Tests.Video;

// ReSharper disable once InconsistentNaming
public class DISOpticalFlowTest : TestBase
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
        using var flow = DISOpticalFlow.Create();
    }

    [Theory]
    [InlineData(DISOpticalFlowPresetTypes.UltraFast)]
    [InlineData(DISOpticalFlowPresetTypes.Fast)]
    [InlineData(DISOpticalFlowPresetTypes.Medium)]
    public void CreateWithPreset(DISOpticalFlowPresetTypes preset)
    {
        using var flow = DISOpticalFlow.Create(preset);
    }

    [Fact]
    public void CheckProperties()
    {
        using var flow = DISOpticalFlow.Create();

        flow.FinestScale = 1;
        Assert.Equal(1, flow.FinestScale);

        flow.CoarsestScale = 2;
        Assert.Equal(2, flow.CoarsestScale);

        flow.PatchSize = 6;
        Assert.Equal(6, flow.PatchSize);

        flow.PatchStride = 3;
        Assert.Equal(3, flow.PatchStride);

        flow.GradientDescentIterations = 12;
        Assert.Equal(12, flow.GradientDescentIterations);

        flow.VariationalRefinementIterations = 5;
        Assert.Equal(5, flow.VariationalRefinementIterations);

        flow.VariationalRefinementAlpha = 20f;
        Assert.Equal(20f, flow.VariationalRefinementAlpha);

        flow.VariationalRefinementDelta = 5f;
        Assert.Equal(5f, flow.VariationalRefinementDelta);

        flow.VariationalRefinementGamma = 10f;
        Assert.Equal(10f, flow.VariationalRefinementGamma);

        flow.VariationalRefinementEpsilon = 0.01f;
        Assert.Equal(0.01f, flow.VariationalRefinementEpsilon);

        flow.UseMeanNormalization = false;
        Assert.False(flow.UseMeanNormalization);
        flow.UseMeanNormalization = true;
        Assert.True(flow.UseMeanNormalization);

        flow.UseSpatialPropagation = false;
        Assert.False(flow.UseSpatialPropagation);
        flow.UseSpatialPropagation = true;
        Assert.True(flow.UseSpatialPropagation);
    }

    [Fact]
    public void Calc()
    {
        var (prev, next) = MakeShiftedPair();
        using (prev)
        using (next)
        using (var flow = DISOpticalFlow.Create(DISOpticalFlowPresetTypes.UltraFast))
        using (var flowMat = new Mat())
        {
            flow.Calc(prev, next, flowMat);

            Assert.Equal(prev.Size(), flowMat.Size());
            Assert.Equal(2, flowMat.Channels());
        }
    }
}
