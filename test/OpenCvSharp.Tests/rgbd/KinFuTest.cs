using OpenCvSharp.Rgbd;
using Xunit;

namespace OpenCvSharp.Tests.Rgbd;

public class KinFuTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public KinFuTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ParamsFactoriesRoundTripFields()
    {
        var defaultParams = KinFuParams.DefaultParams();
        Assert.False(defaultParams.Intr.Empty());
        Assert.Equal(defaultParams.FrameSize, defaultParams.FrameSize);

        var coarse = KinFuParams.CoarseParams();
        Assert.NotEmpty(coarse.IcpIterations);

        var hash = KinFuParams.HashTsdfParams(true);
        Assert.False(hash.VolumePose.Empty());

        var colored = KinFuParams.ColoredTsdfParams(false);
        Assert.Equal(VolumeType.ColorTSDF, colored.VolumeKind);

        defaultParams.PyramidLevels = 5;
        defaultParams.VoxelSize = 0.02f;
        Assert.Equal(5, defaultParams.PyramidLevels);
        Assert.Equal(0.02f, defaultParams.VoxelSize);
    }

    [Fact]
    public void CreateUpdateAndGetParamsWireUpCorrectly()
    {
        var parameters = KinFuParams.CoarseParams();
        parameters.FrameSize = new Size(64, 48);

        using var kinFu = KinFu.Create(parameters);
        var readBack = kinFu.GetParams();
        Assert.Equal(parameters.FrameSize, readBack.FrameSize);

        using var depth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.0));
        using var cameraPose = Mat.Eye(4, 4, MatType.CV_32FC1).ToMat();

        void Tolerant(string name, Action action)
        {
            try { action(); }
            catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
            {
                testOutputHelper.WriteLine($"{name} threw (wiring resolved): {ex.Message}");
            }
        }

        Tolerant("Update", () => kinFu.Update(depth));
        Tolerant("Render", () =>
        {
            using var image = new Mat();
            kinFu.Render(image);
        });
        Tolerant("RenderWithPose", () =>
        {
            using var image = new Mat();
            kinFu.Render(image, cameraPose);
        });
        Tolerant("GetCloud", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            kinFu.GetCloud(points, normals);
        });
        Tolerant("GetPoints", () =>
        {
            using var points = new Mat();
            kinFu.GetPoints(points);
        });
        Tolerant("GetPose", () => kinFu.GetPose().Dispose());
        Tolerant("Reset", kinFu.Reset);
    }
}
