using Xunit;

namespace OpenCvSharp.Tests.PtCloud;

// ReSharper disable once UnusedMember.Global
public class PtCloudTest : TestBase
{
    private static readonly int[] IterCounts777 = { 7, 7, 7 };
    private static readonly int[] VolumeResolution128 = { 128, 128, 128 };
    private static readonly float[] MinGradientMagnitudes = { 10f, 10f, 10f, 10f };

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

        using var iterCounts = Mat.FromArray(IterCounts777);
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
            Cv2.WarpFrame(depth, default, default, rt, cameraMatrix, warpedDepth);
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
    public void VolumeSettingsArrayProperties()
    {
        using var settings = new VolumeSettings(VolumeType.TSDF);

        using var pose = Mat.Eye(4, 4, MatType.CV_32FC1).ToMat();
        settings.SetVolumePose(pose);
        using var poseOut = new Mat();
        settings.GetVolumePose(poseOut);
        Assert.False(poseOut.Empty());

        using var resolution = Mat.FromArray(VolumeResolution128);
        settings.SetVolumeResolution(resolution);
        using var resOut = new Mat();
        settings.GetVolumeResolution(resOut);
        Assert.False(resOut.Empty());

        using var strides = new Mat();
        settings.GetVolumeStrides(strides);
        Assert.False(strides.Empty());

        using var k = Mat.FromArray(new float[,] { { 525, 0, 320 }, { 0, 525, 240 }, { 0, 0, 1 } });
        settings.SetCameraRaycastIntrinsics(k);
        using var kOut = new Mat();
        settings.GetCameraRaycastIntrinsics(kOut);
        Assert.False(kOut.Empty());
    }

    [Fact]
    public void OdometrySettingsArrayProperties()
    {
        using var settings = new OdometrySettings();

        using var cameraMatrix = Mat.FromArray(new float[,] { { 525, 0, 320 }, { 0, 525, 240 }, { 0, 0, 1 } });
        settings.SetCameraMatrix(cameraMatrix);
        using var camOut = new Mat();
        settings.GetCameraMatrix(camOut);
        Assert.False(camOut.Empty());

        using var minGrad = Mat.FromArray(MinGradientMagnitudes);
        settings.SetMinGradientMagnitudes(minGrad);
        using var minGradOut = new Mat();
        settings.GetMinGradientMagnitudes(minGradOut);
        Assert.False(minGradOut.Empty());
    }

    [Fact]
    public void RgbdNormalsApplyAndSetK()
    {
        const int rows = 16;
        const int cols = 16;
        using var k = Mat.FromArray(new float[,] { { 525, 0, 8 }, { 0, 525, 8 }, { 0, 0, 1 } });
        using var normalsComputer = RgbdNormals.Create(
            rows, cols, MatType.CV_32F, k, 5, 50f, RgbdNormalsMethod.RGBD_NORMALS_METHOD_FALS);

        normalsComputer.SetK(k);

        using var points = new Mat(rows, cols, MatType.CV_32FC3, Scalar.All(1.0));
        using var normals = new Mat();
        try
        {
            normalsComputer.Apply(points, normals);
            testOutputHelper.WriteLine($"RgbdNormals.Apply produced empty={normals.Empty()}");
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"RgbdNormals.Apply threw (wiring resolved): {ex.Message}");
        }
    }

    [Fact]
    public void OdometryFrameGetters()
    {
        using var depth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.0));
        using var image = new Mat(48, 64, MatType.CV_8UC3, Scalar.All(100));
        using var mask = new Mat(48, 64, MatType.CV_8UC1, Scalar.All(255));
        using var normals = new Mat(48, 64, MatType.CV_32FC4, Scalar.All(0));
        using var frame = new OdometryFrame(depth, image, mask, normals);

        using var imageOut = new Mat();
        using var grayOut = new Mat();
        using var depthOut = new Mat();
        using var processedDepthOut = new Mat();
        using var maskOut = new Mat();
        using var normalsOut = new Mat();

        frame.GetImage(imageOut);
        frame.GetGrayImage(grayOut);
        frame.GetDepth(depthOut);
        frame.GetProcessedDepth(processedDepthOut);
        frame.GetMask(maskOut);
        frame.GetNormals(normalsOut);

        using var pyrOut = new Mat();
        try
        {
            frame.GetPyramidAt(pyrOut, OdometryFramePyramidType.PYR_IMAGE, 0);
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"GetPyramidAt threw (wiring resolved): {ex.Message}");
        }
    }

    [Fact]
    public void OdometryComputeMethods()
    {
        using var srcDepth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.0));
        using var dstDepth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.1));
        using var srcRgb = new Mat(48, 64, MatType.CV_8UC3, Scalar.All(100));
        using var dstRgb = new Mat(48, 64, MatType.CV_8UC3, Scalar.All(110));
        using var odometry = new Odometry(OdometryType.DEPTH);
        using var rt = new Mat();

        try
        {
            odometry.Compute(srcDepth, dstDepth, rt);
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"Compute(depth) threw (wiring resolved): {ex.Message}");
        }

        try
        {
            odometry.Compute(srcDepth, srcRgb, dstDepth, dstRgb, rt);
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"Compute(rgbd) threw (wiring resolved): {ex.Message}");
        }

        using var srcFrame = new OdometryFrame(srcDepth);
        using var dstFrame = new OdometryFrame(dstDepth);
        try
        {
            odometry.Compute(srcFrame, dstFrame, rt);
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"Compute(frame) threw (wiring resolved): {ex.Message}");
        }
    }

    [Fact]
    public void VolumeIntegrateRaycastFetch()
    {
        using var settings = new VolumeSettings(VolumeType.TSDF);
        using var volume = new Volume(VolumeType.TSDF, settings);

        using var depth = new Mat(48, 64, MatType.CV_32FC1, Scalar.All(2.0));
        using var image = new Mat(48, 64, MatType.CV_8UC3, Scalar.All(100));
        using var pose = Mat.Eye(4, 4, MatType.CV_32FC1).ToMat();
        using var k = Mat.FromArray(new float[,] { { 525, 0, 32 }, { 0, 525, 24 }, { 0, 0, 1 } });
        using var cameraPose = Mat.Eye(4, 4, MatType.CV_32FC1).ToMat();

        void Tolerant(string name, Action action)
        {
            try { action(); }
            catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
            {
                testOutputHelper.WriteLine($"{name} threw (wiring resolved): {ex.Message}");
            }
        }

        Tolerant("Integrate", () => volume.Integrate(depth, pose));
        Tolerant("IntegrateColor", () => volume.IntegrateColor(depth, image, pose));
        Tolerant("IntegrateFrame", () =>
        {
            using var frame = new OdometryFrame(depth);
            volume.IntegrateFrame(frame, pose);
        });

        Tolerant("Raycast", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            volume.Raycast(cameraPose, points, normals);
        });
        Tolerant("RaycastColor", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            using var colors = new Mat();
            volume.RaycastColor(cameraPose, points, normals, colors);
        });
        Tolerant("RaycastEx", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            volume.RaycastEx(cameraPose, 48, 64, k, points, normals);
        });
        Tolerant("RaycastExColor", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            using var colors = new Mat();
            volume.RaycastExColor(cameraPose, 48, 64, k, points, normals, colors);
        });

        Tolerant("FetchNormals", () =>
        {
            using var points = new Mat(4, 1, MatType.CV_32FC3, Scalar.All(0));
            using var normals = new Mat();
            volume.FetchNormals(points, normals);
        });
        Tolerant("FetchPointsNormals", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            volume.FetchPointsNormals(points, normals);
        });
        Tolerant("FetchPointsNormalsColors", () =>
        {
            using var points = new Mat();
            using var normals = new Mat();
            using var colors = new Mat();
            volume.FetchPointsNormalsColors(points, normals, colors);
        });
        Tolerant("GetBoundingBox", () =>
        {
            using var bb = new Mat();
            volume.GetBoundingBox(bb, VolumeBoundingBoxPrecision.VOLUME_UNIT);
        });
    }

    [Fact]
    public void DepthTo3dSparseSmoke()
    {
        const int n = 8;
        using var depth = new Mat(24, 32, MatType.CV_32FC1, Scalar.All(2.0));
        using var k = Mat.FromArray(new float[,] { { 525, 0, 16 }, { 0, 525, 12 }, { 0, 0, 1 } });
        using var inPoints = new Mat(n, 1, MatType.CV_32FC2, Scalar.All(5));
        using var points3d = new Mat();

        try
        {
            Cv2.DepthTo3dSparse(depth, k, inPoints, points3d);
            testOutputHelper.WriteLine($"DepthTo3dSparse produced empty={points3d.Empty()}");
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            testOutputHelper.WriteLine($"DepthTo3dSparse threw (wiring resolved): {ex.Message}");
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
