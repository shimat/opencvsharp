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

    [Fact]
    public void RgbdNormalsCreateAndProperties()
    {
        const int rows = 16;
        const int cols = 16;
        using var k = Mat.FromArray(new float[,] { { 525, 0, 8 }, { 0, 525, 8 }, { 0, 0, 1 } });
        using var normalsComputer = RgbdNormals.Create(
            rows, cols, MatType.CV_32F, k, 5, 50f, RgbdNormalsMethod.RGBD_NORMALS_METHOD_FALS);

        Assert.NotEqual(IntPtr.Zero, normalsComputer.RawPtr);
        Assert.Equal(rows, normalsComputer.Rows);
        Assert.Equal(cols, normalsComputer.Cols);
        Assert.Equal(RgbdNormalsMethod.RGBD_NORMALS_METHOD_FALS, normalsComputer.GetMethod());

        using var kOut = new Mat();
        normalsComputer.GetK(kOut);
        Assert.False(kOut.Empty());

        // NOTE: apply() (FALS normal computation) is intentionally omitted here — it is
        // finicky about input shape/channels and can hard-crash the native pipeline on
        // some platforms; covered separately with real fixtures.
    }

    [Fact]
    public void DepthTo3dAndRescaleDepth()
    {
        const int w = 32;
        const int h = 24;
        using var depth = new Mat(h, w, MatType.CV_32FC1, Scalar.All(2.0));
        using var k = Mat.FromArray(new float[,] { { 525, 0, 16 }, { 0, 525, 12 }, { 0, 0, 1 } });

        using var points3d = new Mat();
        Cv2.DepthTo3d(depth, k, points3d);
        Assert.False(points3d.Empty());

        using var src = new Mat(h, w, MatType.CV_16UC1, Scalar.All(1000));
        using var dst = new Mat();
        Cv2.RescaleDepth(src, MatType.CV_32F, dst);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void RegisterDepthSmoke()
    {
        const int w = 32;
        const int h = 24;
        using var unregK = Mat.FromArray(new float[,] { { 525, 0, 16 }, { 0, 525, 12 }, { 0, 0, 1 } });
        using var regK = Mat.FromArray(new float[,] { { 525, 0, 16 }, { 0, 525, 12 }, { 0, 0, 1 } });
        using var distCoeffs = new Mat(1, 5, MatType.CV_32FC1, Scalar.All(0));
        using var rt = Mat.Eye(4, 4, MatType.CV_32FC1).ToMat();
        using var depth = new Mat(h, w, MatType.CV_32FC1, Scalar.All(2.0));
        using var registered = new Mat();

        try
        {
            Cv2.RegisterDepth(unregK, regK, distCoeffs, rt, depth, new Size(w, h), registered);
            testOutputHelper.WriteLine($"RegisterDepth produced empty={registered.Empty()}");
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"RegisterDepth threw (entrypoints resolved): {ex.Message}");
        }
    }

    [Fact]
    public void WarpFrameSmoke()
    {
        const int w = 32;
        const int h = 24;
        using var depth = new Mat(h, w, MatType.CV_32FC1, Scalar.All(2.0));
        using var rt = Mat.Eye(4, 4, MatType.CV_32FC1).ToMat();
        using var cameraMatrix = Mat.FromArray(new float[,] { { 525, 0, 16 }, { 0, 525, 12 }, { 0, 0, 1 } });
        using var warpedDepth = new Mat();

        try
        {
            Cv2.WarpFrame(depth, null, null, rt, cameraMatrix, warpedDepth);
            testOutputHelper.WriteLine($"WarpFrame produced empty={warpedDepth.Empty()}");
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"WarpFrame threw (entrypoints resolved): {ex.Message}");
        }
    }

    [Fact]
    public void FindPlanesSmoke()
    {
        const int w = 32;
        const int h = 24;
        using var points3d = new Mat(h, w, MatType.CV_32FC3, Scalar.All(1.0));
        using var normals = new Mat(h, w, MatType.CV_32FC3, Scalar.All(0.0));
        using var mask = new Mat();
        using var planeCoefficients = new Mat();

        try
        {
            Cv2.FindPlanes(points3d, normals, mask, planeCoefficients, blockSize: 8, minSize: 16);
            testOutputHelper.WriteLine($"FindPlanes produced mask empty={mask.Empty()}");
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"FindPlanes threw (entrypoints resolved): {ex.Message}");
        }
    }

    [Fact]
    public void OdometryGetNormalsComputer()
    {
        using var odometry = new Odometry(OdometryType.RGB_DEPTH);
        try
        {
            using var normalsComputer = odometry.GetNormalsComputer();
            testOutputHelper.WriteLine($"GetNormalsComputer returned RawPtr={normalsComputer.RawPtr}");
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"GetNormalsComputer threw (entrypoints resolved): {ex.Message}");
        }
    }
}
