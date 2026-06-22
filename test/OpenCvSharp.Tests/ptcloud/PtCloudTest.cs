using Xunit;

namespace OpenCvSharp.Tests.PtCloud;

// ReSharper disable once UnusedMember.Global
public class PtCloudTest : TestBase
{
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
    public void VolumeCreateAndQuery()
    {
        using var settings = new VolumeSettings(VolumeType.TSDF);
        using var volume = new Volume(VolumeType.TSDF, settings);

        // Query-only entrypoints on a freshly created (empty) volume.
        // NOTE: running TSDF integrate/raycast/fetch on synthetic data is intentionally
        // omitted — it requires a fully configured camera plus valid depth frames, and
        // feeding placeholder data makes OpenCV's native pipeline crash (hard segfault,
        // not a catchable exception) on some platforms (e.g. Windows arm64). Algorithmic
        // integration should be covered separately with real depth fixtures.
        Assert.True(volume.GetVisibleBlocks() >= 0);
        Assert.True(volume.GetTotalVolumeUnits() >= 0);
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
    public void OdometryCreateFromType()
    {
        using var odometry = new Odometry(OdometryType.DEPTH);
        Assert.NotEqual(IntPtr.Zero, odometry.CvPtr);
        // NOTE: Odometry.Compute on synthetic flat depth is intentionally omitted — it
        // needs a configured camera matrix and textured/varying depth frames; placeholder
        // input crashes the native pipeline (hard segfault) on some platforms.
    }

    [Fact]
    public void OdometryWithSettingsCreate()
    {
        using var settings = new OdometrySettings();
        using var odometry = new Odometry(OdometryType.DEPTH, settings, OdometryAlgoType.COMMON);
        Assert.NotEqual(IntPtr.Zero, odometry.CvPtr);
    }
}
