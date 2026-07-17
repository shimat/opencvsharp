using OpenCvSharp.OptFlow;
using Xunit;

namespace OpenCvSharp.Tests.OptFlow;

// ReSharper disable once InconsistentNaming
public class RLOFOpticalFlowParameterTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var p = new RLOFOpticalFlowParameter();
    }

    [Fact]
    public void CheckDefaults()
    {
        using var p = new RLOFOpticalFlowParameter();

        Assert.Equal(SolverType.Bilinear, p.SolverType);
        Assert.Equal(SupportRegionType.Cross, p.SupportRegionType);
        Assert.Equal(9, p.SmallWinSize);
        Assert.Equal(21, p.LargeWinSize);
        Assert.Equal(25, p.CrossSegmentationThreshold);
        Assert.Equal(4, p.MaxLevel);
        Assert.False(p.UseInitialFlow);
        Assert.True(p.UseIlluminationModel);
        Assert.True(p.UseGlobalMotionPrior);
        Assert.Equal(30, p.MaxIteration);
        Assert.Equal(0.0001f, p.MinEigenValue);
        Assert.Equal(10f, p.GlobalMotionRansacThreshold);
    }

    [Fact]
    public void CheckPropertyRoundTrip()
    {
        using var p = new RLOFOpticalFlowParameter
        {
            SolverType = SolverType.Standart,
            SupportRegionType = SupportRegionType.Fixed,
            NormSigma0 = 3.2f,
            NormSigma1 = 7.0f,
            SmallWinSize = 7,
            LargeWinSize = 15,
            CrossSegmentationThreshold = 20,
            MaxLevel = 3,
            UseInitialFlow = true,
            UseIlluminationModel = false,
            UseGlobalMotionPrior = false,
            MaxIteration = 20,
            MinEigenValue = 0.001f,
            GlobalMotionRansacThreshold = 15f,
        };

        Assert.Equal(SolverType.Standart, p.SolverType);
        Assert.Equal(SupportRegionType.Fixed, p.SupportRegionType);
        Assert.Equal(3.2f, p.NormSigma0);
        Assert.Equal(7.0f, p.NormSigma1);
        Assert.Equal(7, p.SmallWinSize);
        Assert.Equal(15, p.LargeWinSize);
        Assert.Equal(20, p.CrossSegmentationThreshold);
        Assert.Equal(3, p.MaxLevel);
        Assert.True(p.UseInitialFlow);
        Assert.False(p.UseIlluminationModel);
        Assert.False(p.UseGlobalMotionPrior);
        Assert.Equal(20, p.MaxIteration);
        Assert.Equal(0.001f, p.MinEigenValue);
        Assert.Equal(15f, p.GlobalMotionRansacThreshold);
    }

    [Fact]
    public void SetUseMEstimator()
    {
        using var p = new RLOFOpticalFlowParameter();
        p.SetUseMEstimator(true);
        Assert.Equal(3.2f, p.NormSigma0);
        Assert.Equal(7.0f, p.NormSigma1);

        p.SetUseMEstimator(false);
        Assert.Equal(float.MaxValue, p.NormSigma0);
        Assert.Equal(float.MaxValue, p.NormSigma1);
    }
}
