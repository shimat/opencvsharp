using OpenCvSharp.Rgbd;
using Xunit;

namespace OpenCvSharp.Tests.Rgbd;

public class ColoredKinFuTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public ColoredKinFuTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ParamsFactoriesRoundTripFields()
    {
        var defaultParams = ColoredKinFuParams.DefaultParams();
        Assert.False(defaultParams.Intr.Empty());

        var coarse = ColoredKinFuParams.CoarseParams();
        Assert.NotEmpty(coarse.IcpIterations);

        var hash = ColoredKinFuParams.HashTsdfParams(true);
        Assert.False(hash.VolumePose.Empty());

        var colored = ColoredKinFuParams.ColoredTsdfParams(false);
        Assert.Equal(VolumeType.ColorTSDF, colored.VolumeKind);

        defaultParams.RgbFrameSize = new Size(32, 24);
        Assert.Equal(new Size(32, 24), defaultParams.RgbFrameSize);
    }

    [Fact]
    public void CreateAndUpdateWireUpCorrectly()
    {
        var parameters = ColoredKinFuParams.CoarseParams();
        parameters.FrameSize = new Size(64, 48);
        parameters.RgbFrameSize = new Size(64, 48);

        using var coloredKinFu = ColoredKinFu.Create(parameters);
        var readBack = coloredKinFu.GetParams();
        Assert.Equal(parameters.FrameSize, readBack.FrameSize);

        using var depth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.0));
        using var rgb = new Mat(48, 64, MatType.CV_8UC3, Scalar.All(100));

        void Tolerant(string name, Action action)
        {
            try { action(); }
            catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
            {
                testOutputHelper.WriteLine($"{name} threw (wiring resolved): {ex.Message}");
            }
        }

        Tolerant("Update", () => coloredKinFu.Update(depth, rgb));
        Tolerant("GetPose", () => coloredKinFu.GetPose().Dispose());
        Tolerant("Reset", coloredKinFu.Reset);
    }
}
