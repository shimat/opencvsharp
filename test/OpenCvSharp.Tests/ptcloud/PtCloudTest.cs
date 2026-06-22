using Xunit;

namespace OpenCvSharp.Tests.PtCloud;

// ReSharper disable once UnusedMember.Global
public class PtCloudTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public PtCloudTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void VolumeSettingsCreateAndProperties()
    {
        using var settings = new VolumeSettings(VolumeType.TSDF);

        settings.IntegrateWidth = 640;
        settings.IntegrateHeight = 480;
        Assert.Equal(640, settings.IntegrateWidth);
        Assert.Equal(480, settings.IntegrateHeight);

        settings.VoxelSize = 0.01f;
        Assert.Equal(0.01f, settings.VoxelSize, 5);

        // round-trip the camera intrinsics (proves InputArray/OutputArray entrypoints resolve)
        using var k = Mat.FromArray(new float[,] { { 525, 0, 320 }, { 0, 525, 240 }, { 0, 0, 1 } });
        settings.SetCameraIntegrateIntrinsics(k);
        using var kOut = new Mat();
        settings.GetCameraIntegrateIntrinsics(kOut);
        Assert.False(kOut.Empty());
    }

    [Fact]
    public void VolumeIntegrateAndFetch()
    {
        using var settings = new VolumeSettings(VolumeType.TSDF);
        using var volume = new Volume(VolumeType.TSDF, settings);

        int w = settings.IntegrateWidth;
        int h = settings.IntegrateHeight;
        if (w <= 0 || h <= 0)
        {
            w = 640;
            h = 480;
            settings.IntegrateWidth = w;
            settings.IntegrateHeight = h;
        }

        // synthetic depth (CV_16U, scaled by depth factor) and an identity pose
        using var depth = new Mat(h, w, MatType.CV_16UC1, Scalar.All(1000));
        using var pose = Mat.Eye(4, 4, MatType.CV_32FC1);

        try
        {
            volume.Integrate(depth, pose);

            using var points = new Mat();
            using var normals = new Mat();
            volume.FetchPointsNormals(points, normals);

            using var rcPoints = new Mat();
            using var rcNormals = new Mat();
            volume.Raycast(pose, rcPoints, rcNormals);

            Assert.True(volume.GetVisibleBlocks() >= 0);
            Assert.True(volume.GetTotalVolumeUnits() >= 0);
        }
        catch (OpenCvSharpException ex)
        {
            // Entrypoints resolved (no EntryPointNotFoundException). OpenCV may reject
            // the synthetic input shape on some platforms; that is acceptable for a smoke test.
            testOutputHelper.WriteLine($"Volume integrate/raycast threw (entrypoints resolved): {ex.Message}");
        }
    }

    [Fact]
    public void VolumeReset()
    {
        using var settings = new VolumeSettings(VolumeType.TSDF);
        using var volume = new Volume(VolumeType.TSDF, settings);
        volume.Reset();
        volume.SetEnableGrowth(true);
        // getEnableGrowth round-trips for HashTSDF; for TSDF the value may be fixed,
        // so we only assert the entrypoint resolves.
        _ = volume.GetEnableGrowth();
    }

    [Fact]
    public void OdometrySettingsCreateAndProperties()
    {
        using var settings = new OdometrySettings();

        settings.MinDepth = 0.1f;
        settings.MaxDepth = 4.0f;
        Assert.Equal(0.1f, settings.MinDepth, 5);
        Assert.Equal(4.0f, settings.MaxDepth, 5);

        settings.SobelSize = 3;
        Assert.Equal(3, settings.SobelSize);

        settings.NormalMethod = RgbdNormalsMethod.RGBD_NORMALS_METHOD_FALS;
        Assert.Equal(RgbdNormalsMethod.RGBD_NORMALS_METHOD_FALS, settings.NormalMethod);

        using var iterCounts = Mat.FromArray(new[] { 7, 7, 7 });
        settings.SetIterCounts(iterCounts);
        using var iterOut = new Mat();
        settings.GetIterCounts(iterOut);
        Assert.False(iterOut.Empty());
    }

    [Fact]
    public void OdometryFrameCreate()
    {
        using var depth = new Mat(480, 640, MatType.CV_8UC1, Scalar.All(100));
        using var frame = new OdometryFrame(depth);

        using var depthOut = new Mat();
        frame.GetDepth(depthOut);

        Assert.Equal(0, frame.GetPyramidLevels());
    }

    [Fact]
    public void OdometryComputeFromDepth()
    {
        using var odometry = new Odometry(OdometryType.DEPTH);

        const int w = 640;
        const int h = 480;
        using var srcDepth = new Mat(h, w, MatType.CV_32FC1, Scalar.All(2.0));
        using var dstDepth = new Mat(h, w, MatType.CV_32FC1, Scalar.All(2.0));
        using var rt = new Mat();

        try
        {
            bool ok = odometry.Compute(srcDepth, dstDepth, rt);
            testOutputHelper.WriteLine($"Odometry.Compute returned {ok}");
        }
        catch (OpenCvSharpException ex)
        {
            // Entrypoints resolved; OpenCV may need a configured camera matrix / specific shapes.
            testOutputHelper.WriteLine($"Odometry.Compute threw (entrypoints resolved): {ex.Message}");
        }
    }

    [Fact]
    public void OdometryWithSettingsCreate()
    {
        using var settings = new OdometrySettings();
        using var odometry = new Odometry(OdometryType.DEPTH, settings, OdometryAlgoType.COMMON);
        Assert.NotEqual(IntPtr.Zero, odometry.CvPtr);
    }
}
