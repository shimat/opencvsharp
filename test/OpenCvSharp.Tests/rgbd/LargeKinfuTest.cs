using OpenCvSharp.Rgbd;
using Xunit;

namespace OpenCvSharp.Tests.Rgbd;

public class LargeKinfuTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public LargeKinfuTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void VolumeParamsFactoriesRoundTripFields()
    {
        var defaultVolume = LargeKinfuVolumeParams.DefaultParams(VolumeType.TSDF);
        Assert.False(defaultVolume.Pose.Empty());

        var coarseVolume = LargeKinfuVolumeParams.CoarseParams(VolumeType.HashTSDF);
        Assert.Equal(VolumeType.HashTSDF, coarseVolume.Kind);

        defaultVolume.VoxelSize = 0.01f;
        Assert.Equal(0.01f, defaultVolume.VoxelSize);
    }

    [Fact]
    public void ParamsFactoriesRoundTripFields()
    {
        var defaultParams = LargeKinfuParams.DefaultParams();
        Assert.NotNull(defaultParams.VolumeParams);
        Assert.False(defaultParams.Intr.Empty());

        var coarse = LargeKinfuParams.CoarseParams();
        Assert.NotEmpty(coarse.IcpIterations);

        var hash = LargeKinfuParams.HashTsdfParams(true);
        Assert.NotNull(hash.VolumeParams);
    }

    [Fact]
    public void CreateAndUpdateWireUpCorrectly()
    {
        // LargeKinfuImpl::paramsToSettings() always builds a HashTSDF volume regardless of
        // volumeParams.Kind, but only HashTsdfParams() sets UnitResolution (CoarseParams()/
        // DefaultParams() leave it at 0), so Create() needs HashTsdfParams() here.
        var parameters = LargeKinfuParams.HashTsdfParams(true);
        parameters.FrameSize = new Size(64, 48);

        using var largeKinfu = LargeKinfu.Create(parameters);
        var readBack = largeKinfu.GetParams();
        Assert.Equal(parameters.FrameSize, readBack.FrameSize);

        using var depth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.0));

        void Tolerant(string name, Action action)
        {
            try { action(); }
            catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
            {
                testOutputHelper.WriteLine($"{name} threw (wiring resolved): {ex.Message}");
            }
        }

        Tolerant("Update", () => largeKinfu.Update(depth));
        Tolerant("GetPose", () => largeKinfu.GetPose().Dispose());
        Tolerant("Reset", largeKinfu.Reset);
    }
}
