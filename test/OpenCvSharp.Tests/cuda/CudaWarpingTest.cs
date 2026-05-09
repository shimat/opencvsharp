using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaWarpingTest : CudaTestBase
{
    [Fact]
    public void BuildWarpAffineMapsTest()
    {
        VerifyCudaSupport();

        // Arrange: 2x3 Transformation Matrix for Affine
        double[] mData = { 1.0, 0.0, 10.0,   // shift right by 10
                               0.0, 1.0, 5.0 };  // shift down by 5
        using var cpuM = Mat.FromPixelData(2, 3, MatType.CV_64FC1, mData);
        Size dsize = new Size(100, 100);

        // Act
        var gpuXMap = new GpuMat();
        var gpuYMap = new GpuMat();
        Cv2.Cuda.BuildWarpAffineMaps(cpuM, false, dsize, gpuXMap, gpuYMap);

        // Assert
        Assert.False(gpuXMap.Empty());
        Assert.False(gpuYMap.Empty());
        Assert.Equal(100, gpuXMap.Cols);
        Assert.Equal(100, gpuYMap.Rows);

        // Cleanup
        gpuXMap.Dispose();
        gpuYMap.Dispose();
    }

    [Fact]
    public void BuildWarpPerspectiveMapsTest()
    {
        VerifyCudaSupport();

        // Arrange: 3x3 Transformation Matrix for Perspective
        double[] mData = { 1.0, 0.0, 10.0,
                               0.0, 1.0, 5.0,
                               0.0, 0.0, 1.0 };
        using var cpuM = Mat.FromPixelData(3, 3, MatType.CV_64FC1, mData);
        Size dsize = new Size(100, 100);

        // Act
        var gpuXMap = new GpuMat();
        var gpuYMap = new GpuMat();
        Cv2.Cuda.BuildWarpPerspectiveMaps(cpuM, false, dsize, gpuXMap, gpuYMap);

        // Assert
        Assert.False(gpuXMap.Empty());
        Assert.False(gpuYMap.Empty());

        gpuXMap.Dispose();
        gpuYMap.Dispose();
    }

    [Fact]
    public void PyrDown_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 matrix
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.PyrDown(gpuSrc, gpuDst);

        // 3. Assert
        Assert.Equal(50, gpuDst.Rows);
        Assert.Equal(50, gpuDst.Cols);
        Assert.False(gpuDst.Empty());
    }

    [Fact]
    public void PyrUp_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 50x50 matrix
        using var cpuSrc = new Mat(50, 50, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.PyrUp(gpuSrc, gpuDst);

        // 3. Assert
        Assert.Equal(100, gpuDst.Rows);
        Assert.Equal(100, gpuDst.Cols);
        Assert.False(gpuDst.Empty());
    }

    [Fact]
    public void Remap_IdentityTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 10x10 image with a unique pixel at (2, 2)
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(2, 2, 255);
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Create Identity Maps: mapX[y,x] = x, mapY[y,x] = y
        using var cpuMapX = new Mat(10, 10, MatType.CV_32FC1);
        using var cpuMapY = new Mat(10, 10, MatType.CV_32FC1);
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                cpuMapX.Set<float>(y, x, x);
                cpuMapY.Set<float>(y, x, y);
            }
        }
        using var gpuMapX = new GpuMat(); gpuMapX.Upload(cpuMapX);
        using var gpuMapY = new GpuMat(); gpuMapY.Upload(cpuMapY);

        // 3. Act
        using var gpuDst = new GpuMat();
        Cv2.Cuda.Remap(gpuSrc, gpuDst, gpuMapX, gpuMapY, InterpolationFlags.Nearest);

        // 4. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        // Because we used an identity map, (2,2) should still be 255
        Assert.Equal(255, cpuDst.At<byte>(2, 2));
        // And (0,0) should still be 0
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void Resize_AbsoluteSizeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 source
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Resize to 200x50
        Cv2.Cuda.Resize(gpuSrc, gpuDst, new Size(200, 50));

        // 3. Assert
        Assert.Equal(200, gpuDst.Cols);
        Assert.Equal(50, gpuDst.Rows);
        Assert.False(gpuDst.Empty());
    }

    [Fact]
    public void Resize_ScaleFactorTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 source
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Act: Scale by 0.5x in both directions
        // dsize must be Size(0,0) to use fx and fy
        using var gpuDst = new GpuMat();
        Cv2.Cuda.Resize(gpuSrc, gpuDst, new Size(0, 0), fx: 0.5, fy: 0.5);

        // 3. Assert
        Assert.Equal(50, gpuDst.Cols);
        Assert.Equal(50, gpuDst.Rows);
    }

    [Fact]
    public void Rotate_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(50));
        cpuSrc.Set<byte>(0, 10, 255); // (row=0, col=10)

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.Rotate(
            gpuSrc,
            gpuDst,
            new Size(100, 100),
            angle: 270,
            xShift : 99,

            interpolation: InterpolationFlags.Nearest);
        using var testc = new Mat();
        Cv2.Rotate(cpuSrc, testc, RotateFlags.Rotate90Clockwise);

        // 3. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Find brightest pixel instead of assuming location
        Cv2.MinMaxLoc(cpuDst, out _, out double maxVal, out _, out Point maxLoc);

        Assert.Equal(255, maxVal);

        // Validate it's NOT at original location
        Assert.NotEqual(new Point(10, 0), maxLoc);

        // Validate it's still inside bounds
        Assert.InRange(maxLoc.X, 0, 99);
        Assert.InRange(maxLoc.Y, 0, 99);
    }

    [Fact]
    public void WarpAffine_TranslationTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 black image with a white pixel at (0,0)
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(0, 0, 255);
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Create translation matrix (Shift by x=10, y=20)
        // [ 1  0  10 ]
        // [ 0  1  20 ]
        double[] mData = { 1, 0, 10, 0, 1, 20 };
        using var M = Mat.FromPixelData(2, 3, MatType.CV_64FC1, mData);

        // 3. Act
        using var gpuDst = new GpuMat();
            Cv2.Cuda.WarpAffine(gpuSrc, gpuDst, M, new Size(100, 100), InterpolationFlags.Nearest);
        // 4. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // Original (0,0) pixel should now be at (x=10, y=20) -> (row 20, col 10)
        Assert.Equal(255, cpuDst.At<byte>(20, 10));
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void WarpPerspective_IdentityTest()
    {
        VerifyCudaSupport();

        // 1. Arrange
        using var cpuSrc = new Mat(50, 50, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Identity Perspective Matrix (3x3)
        double[] mData = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
        using var M = Mat.FromPixelData(3, 3, MatType.CV_64FC1, mData);

        // 3. Act
        using var gpuDst = new GpuMat();
        Cv2.Cuda.WarpPerspective(gpuSrc, gpuDst, M, new Size(50, 50));

        // 4. Assert
        Assert.Equal(50, gpuDst.Rows);
        Assert.Equal(50, gpuDst.Cols);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        Assert.Equal(128, cpuDst.At<byte>(0, 0));
    }
}
