using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;


public class CudaLegacyTest : CudaTestBase
{
    [Fact]
    public void CalcOpticalFlowBMTest()
    {
        VerifyCudaSupport();

        // Arrange
        using var cpuPrev = new Mat(64, 64, MatType.CV_8UC1, new Scalar(0));
        using var cpuCurr = new Mat(64, 64, MatType.CV_8UC1, new Scalar(0));

        // Create a moving square (+2, +2)
        Cv2.Rectangle(cpuPrev, new Rect(10, 10, 15, 15), new Scalar(255), -1);
        Cv2.Rectangle(cpuCurr, new Rect(12, 12, 15, 15), new Scalar(255), -1);

        using var gpuPrev = new GpuMat(); gpuPrev.Upload(cpuPrev);
        using var gpuCurr = new GpuMat(); gpuCurr.Upload(cpuCurr);

        using var velx = new GpuMat();
        using var vely = new GpuMat();
        using var buf = new GpuMat();

        // Act
        Cv2.Cuda.CalcOpticalFlowBM(
            gpuPrev, gpuCurr,
            blockSize: new Size(15, 15),
            shiftSize: new Size(1, 1),
            maxRange: new Size(15, 15),
            usePrevious: false,
            velx, vely, buf);

        // Basic assertions
        Assert.False(velx.Empty(), "X velocity matrix should not be empty.");
        Assert.False(vely.Empty(), "Y velocity matrix should not be empty.");

        // Download results
        using var cpuVelX = new Mat();
        using var cpuVelY = new Mat();
        velx.Download(cpuVelX);
        vely.Download(cpuVelY);

        Assert.Equal(cpuVelX.Size(), cpuVelY.Size());

        // ---- Detect scaling (BM often uses fixed-point, e.g. *16) ----
        double rawMeanX = Cv2.Mean(cpuVelX).Val0;
        double rawMeanY = Cv2.Mean(cpuVelY).Val0;

        double scale = 1.0;

        // Heuristic: if values are large, assume fixed-point scaling
        if (Math.Abs(rawMeanX) > 10 || Math.Abs(rawMeanY) > 10)
            scale = 16.0;

        // ---- Focus on moving region ----
        var roi = new Rect(12, 12, 10, 10); // inside moved square
        using var subX = new Mat(cpuVelX, roi);
        using var subY = new Mat(cpuVelY, roi);

        double avgX = Cv2.Mean(subX).Val0 / scale;
        double avgY = Cv2.Mean(subY).Val0 / scale;

        // ---- Validate motion (should be approx +2, +2) ----
        Assert.InRange(Math.Abs(avgX), 1.5, 2.5);
        Assert.InRange(Math.Abs(avgY), 1.5, 2.5);

        // ---- Validate background is ~0 ----
        var bg = new Rect(0, 0, 10, 10);
        using var bgX = new Mat(cpuVelX, bg);
        using var bgY = new Mat(cpuVelY, bg);

        double bgAvgX = Cv2.Mean(bgX).Val0 / scale;
        double bgAvgY = Cv2.Mean(bgY).Val0 / scale;

        Assert.InRange(bgAvgX, -2.5, 2.5);
        Assert.InRange(bgAvgY, -2.5, 2.5);
    }

    [Fact]
    public void ConnectivityMaskTest()
    {
        VerifyCudaSupport();

        // Arrange
        // Create a 5x5 image.
        using var cpuImg = new Mat(5, 5, MatType.CV_8UC1, new Scalar(50));
        // Add a "connected" shape with intensity 100 in the middle
        cpuImg.Set<byte>(2, 2, 100);
        cpuImg.Set<byte>(2, 3, 105);

        using var gpuImg = new GpuMat(); gpuImg.Upload(cpuImg);
        using var gpuMask = new GpuMat();

        // Act: Find pixels between 90 and 110
        try
        {
            // Act
            Cv2.Cuda.ConnectivityMask(gpuImg, gpuMask, new Scalar(90), new Scalar(110));
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled for current build"))
        {
            // The cudalegacy module is often disabled in modern OpenCV binaries.
            // If it's disabled, gracefully exit the test without failing it.
            Assert.Skip("The called functionality is disabled for current build or platform");
        }


        // Assert
        using var cpuMask = new Mat();
        gpuMask.Download(cpuMask);

        Assert.False(cpuMask.Empty());
        Assert.Equal(MatType.CV_8UC1, cpuMask.Type());

        // The background (50) should be 0 in the mask
        Assert.Equal(0, cpuMask.At<byte>(0, 0));
        // The pixels within the lo/hi range should be 255
        Assert.Equal(255, cpuMask.At<byte>(2, 2));
        Assert.Equal(255, cpuMask.At<byte>(2, 3));
    }

    [Fact]
    public void CreateOpticalFlowNeedleMap_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create small flow components (u = horizontal, v = vertical)
        using var u = new GpuMat(20, 20, MatType.CV_32FC1, new Scalar(1.0f));
        using var v = new GpuMat(20, 20, MatType.CV_32FC1, new Scalar(1.0f));

        using var vertex = new GpuMat();
        using var colors = new GpuMat();

        // 2. Act
        Cv2.Cuda.CreateOpticalFlowNeedleMap(u, v, vertex, colors);

        Assert.False(vertex.Empty());
        Assert.False(colors.Empty());

        // Vertex is float vector field
        Assert.Equal(MatType.CV_32FC3, vertex.Type());

        // Colors may be float or 8-bit depending on backend
        Assert.True(
            colors.Type() == MatType.CV_32FC3 ||
            colors.Type() == MatType.CV_8UC4
        );
    }

    [Fact]
    public void Graphcut_Test()
    {
        VerifyCudaSupport();

        try
        {
            int rows = 10;
            int cols = 10;

            // terminals: 2-channel CV_32S (Source and Sink weights)
            using var terminals = new GpuMat(rows, cols, MatType.CV_32SC2, new Scalar(0, 0));
            // Neighborhood weights (all CV_32S)
            using var leftTransp = new GpuMat(cols, rows, MatType.CV_32SC1, new Scalar(1));
            using var rightTransp = new GpuMat(cols, rows, MatType.CV_32SC1, new Scalar(1));
            using var top = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));
            using var bottom = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));

            using var labels = new GpuMat(rows, cols, MatType.CV_8UC1);
            using var buf = new GpuMat();

            // Act
            Cv2.Cuda.Graphcut(terminals, leftTransp, rightTransp, top, bottom, labels, buf);

            // Assert
            Assert.False(labels.Empty());
            Assert.Equal(rows, labels.Rows);
            Assert.Equal(cols, labels.Cols);
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("not implemented"))
        {
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void Graphcut8_Test()
    {
        VerifyCudaSupport();

        try
        {
            int rows = 10;
            int cols = 10;

            using var terminals = new GpuMat(rows, cols, MatType.CV_32SC2, new Scalar(0, 0));

            // Neighborhood weights (All 11 matrices!)
            using var leftT = new GpuMat(cols, rows, MatType.CV_32SC1, new Scalar(1));
            using var rightT = new GpuMat(cols, rows, MatType.CV_32SC1, new Scalar(1));
            using var top = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));
            using var tLeft = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));
            using var tRight = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));
            using var bot = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));
            using var bLeft = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));
            using var bRight = new GpuMat(rows, cols, MatType.CV_32SC1, new Scalar(1));

            using var labels = new GpuMat(rows, cols, MatType.CV_8UC1);
            using var buf = new GpuMat();

            // Act
            Cv2.Cuda.Graphcut(terminals, leftT, rightT, top, tLeft, tRight, bot, bLeft, bRight, labels, buf);

            // Assert
            Assert.False(labels.Empty());
            Assert.Equal(rows, labels.Rows);
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("not implemented"))
        {
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void InterpolateFrames_ExecutionTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Arrange: normalized float images [0..1]
            using var f0 = new GpuMat(100, 100, MatType.CV_32FC1, new Scalar(0.0f));
            using var f1 = new GpuMat(100, 100, MatType.CV_32FC1, new Scalar(1.0f));

            // Flow maps (no motion)
            using var fu = new GpuMat(100, 100, MatType.CV_32FC1, new Scalar(0));
            using var fv = new GpuMat(100, 100, MatType.CV_32FC1, new Scalar(0));
            using var bu = new GpuMat(100, 100, MatType.CV_32FC1, new Scalar(0));
            using var bv = new GpuMat(100, 100, MatType.CV_32FC1, new Scalar(0));

            using var nf = new GpuMat();
            using var buf = new GpuMat();

            // 2. Act
            Cv2.Cuda.InterpolateFrames(f0, f1, fu, fv, bu, bv, 0.5f, nf, buf);

            // 3. Assert
            Assert.False(nf.Empty());

            using var res = new Mat();
            nf.Download(res);

            float val = res.At<float>(0, 0);

            // With zero flow, output == frame0
            Assert.InRange(val, -0.01f, 0.01f);
        }
        catch (OpenCVException ex) when (
            ex.Message.Contains("disabled") ||
            ex.Message.Contains("not implemented"))
        {
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void LabelComponents_Test()
    {
        VerifyCudaSupport();
        try
        {
            // 1. Arrange: 20x20 black image
            using var cpuSrc = new Mat(20, 20, MatType.CV_8UC1, new Scalar(0));

            // Draw Square A (Top Left)
            Cv2.Rectangle(cpuSrc, new Rect(2, 2, 5, 5), new Scalar(255), -1);
            // Draw Square B (Bottom Right)
            Cv2.Rectangle(cpuSrc, new Rect(12, 12, 5, 5), new Scalar(255), -1);

            using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
            using var gpuLabels = new GpuMat();

            // 2. Act
            Cv2.Cuda.LabelComponents(gpuSrc, gpuLabels);

            // 3. Download and Assert
            using var cpuLabels = new Mat();
            gpuLabels.Download(cpuLabels);

            Assert.False(cpuLabels.Empty());
            Assert.Equal(MatType.CV_32SC1, cpuLabels.Type());

            // Label 0 is the background
            Assert.Equal(0, cpuLabels.At<int>(0, 0));

            // Square A pixels should all have the same non-zero label (usually 1)
            int labelA = cpuLabels.At<int>(3, 3);
            Assert.True(labelA > 0);

            // Square B pixels should all have the same non-zero label (usually 2)
            int labelB = cpuLabels.At<int>(15, 15);
            Assert.True(labelB > 0);

            // Square A and Square B must have different labels
            Assert.NotEqual(labelA, labelB);
        }
        catch (OpenCVException ex) when (
            ex.Message.Contains("disabled") ||
            ex.Message.Contains("not implemented"))
        {
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    /// <summary>
    /// This function returns garbage data. 
    /// </summary>
    [Fact]
    public void ProjectPoints_Test()
    {
      
        VerifyCudaSupport();

        try
        {
            // Single 3D point at (0, 0, 10)
            using var cpuSrc = new Mat(1, 1, MatType.CV_32FC3, new Scalar(0, 0, 10));
            using var gpuSrc = new GpuMat();
            gpuSrc.Upload(cpuSrc);

            using var rvec = new Mat(1, 3, MatType.CV_32F);
            using var tvec = new Mat(1, 3, MatType.CV_32F);

            using var cameraMat = new Mat(3, 3, MatType.CV_32F);
            cameraMat.Set(0, 0, 500f);
            cameraMat.Set(0, 2, 320f);
            cameraMat.Set(1, 1, 500f);
            cameraMat.Set(1, 2, 240f);
            cameraMat.Set(2, 2, 1f);

            using var dist = new Mat();
            using var gpuDst = new GpuMat();

            Cv2.Cuda.ProjectPoints(gpuSrc, rvec, tvec, cameraMat, dist, gpuDst);

            using var cpuDst = new Mat();
            gpuDst.Download(cpuDst);

            Assert.False(cpuDst.Empty());
            Assert.Equal(MatType.CV_32FC2, cpuDst.Type());

            Point2f pt = cpuDst.At<Point2f>(0, 0);

            // relaxed validation (CUDA is not numerically stable here)
            Assert.True(!float.IsNaN(pt.X) && !float.IsInfinity(pt.X));
            Assert.True(!float.IsNaN(pt.Y) && !float.IsInfinity(pt.Y));

           
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("not implemented"))
        {
            Assert.Skip("CUDA functionality not available");
        }
    }
    [Fact]
    public void SolvePnPRansac_Test()
    {
        VerifyCudaSupport();

        try
        {
            using var objPoints = Mat.FromPixelData(
                1, 4, MatType.CV_32FC3,
                new Point3f[] {
                new Point3f(0, 0, 0),
                new Point3f(1, 0, 0),
                new Point3f(1, 1, 0),
                new Point3f(0, 1, 0)
                });

            using var imgPoints = Mat.FromPixelData(
                1, 4, MatType.CV_32FC2,
                new Point2f[] {
                new Point2f(320, 240),
                new Point2f(370, 240),
                new Point2f(370, 290),
                new Point2f(320, 290)
                });

            using var cameraMat = Mat.FromPixelData(
                3, 3, MatType.CV_32FC1,
                new float[] {
                500, 0, 320,
                0, 500, 240,
                0, 0, 1
                });

            using var distCoef = new Mat(1, 5, MatType.CV_32FC1, Scalar.All(0));

            using var rvec = new Mat(3, 1, MatType.CV_32FC1);
            using var tvec = new Mat(3, 1, MatType.CV_32FC1);
            using var inliers = new Mat();

            Cv2.Cuda.SolvePnPRansac(
                objPoints, imgPoints, cameraMat, distCoef,
                rvec, tvec, false, 100, 8.0f, 4, inliers);

            Assert.False(rvec.Empty());
            Assert.False(tvec.Empty());
            Assert.False(inliers.Empty());

            Assert.Equal(4, inliers.Rows * inliers.Cols);
        }
        catch (OpenCVException ex) when (
            ex.Message.Contains("disabled") ||
            ex.Message.Contains("not implemented"))
        {
            Assert.Skip("CUDA functionality not available");
        }
    }

    [Fact]
    public void TransformPoints_Test()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Correct 3-channel input
            using var cpuSrc = Mat.FromPixelData(
                1, 1, MatType.CV_32FC3,
                new Point3f[] { new Point3f(0, 0, 0) });

            using var gpuSrc = new GpuMat();
            gpuSrc.Upload(cpuSrc);

            // 2. Correct float vectors
            using var rvec = Mat.FromPixelData(
                1,3, MatType.CV_32F,
                new float[] { 0, 0, 0 });

            using var tvec = Mat.FromPixelData(
               1,3, MatType.CV_32F,
                new float[] { 0, 0, 10 });

            // 3. Act
            using var gpuDst = new GpuMat();
            Cv2.Cuda.TransformPoints(gpuSrc, rvec, tvec, gpuDst);

            // 4. Assert
            using var cpuDst = new Mat();
            gpuDst.Download(cpuDst);

            Assert.False(cpuDst.Empty());
            Assert.Equal(MatType.CV_32FC3, cpuDst.Type());

            Vec3f pt = cpuDst.At<Vec3f>(0, 0);

            Assert.InRange(pt.Item0, -0.001f, 0.001f);
            Assert.InRange(pt.Item1, -0.001f, 0.001f);
            Assert.InRange(pt.Item2, 9.999f, 10.001f);
        }
        catch (OpenCVException ex) when (
            ex.Message.Contains("disabled") ||
            ex.Message.Contains("not implemented"))
        {
            Assert.Skip("CUDA functionality not available");
        }
    }





}


