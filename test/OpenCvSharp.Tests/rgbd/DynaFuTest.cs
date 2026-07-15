using OpenCvSharp.Rgbd;
using Xunit;

namespace OpenCvSharp.Tests.Rgbd;

public class DynaFuTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public DynaFuTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CreateUpdateAndExtrasWireUpCorrectly()
    {
        var parameters = KinFuParams.CoarseParams();
        parameters.FrameSize = new Size(64, 48);

        using var dynaFu = DynaFu.Create(parameters);
        var readBack = dynaFu.GetParams();
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

        Tolerant("Update", () => dynaFu.Update(depth));
        Tolerant("GetNodesPos", () => dynaFu.GetNodesPos());
        Tolerant("MarchCubes", () =>
        {
            using var vertices = new Mat();
            using var edges = new Mat();
            dynaFu.MarchCubes(vertices, edges);
        });
        Tolerant("RenderSurface", () =>
        {
            using var depthImage = new Mat();
            using var vertImage = new Mat();
            using var normImage = new Mat();
            dynaFu.RenderSurface(depthImage, vertImage, normImage);
        });
        Tolerant("GetPose", () => dynaFu.GetPose().Dispose());
        Tolerant("Reset", dynaFu.Reset);
    }
}
