using Xunit;
using OpenCvSharp.Cuda;

namespace OpenCvSharp.Tests.Cuda;

public class CudaArthimTest : CudaTestBase
{

    [Fact]
    public void Abs()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, -7f);
        using var dst = new GpuMat();

        Cv2.Cuda.Abs(src, dst);
        Assert.Equal(7f, PixelF(dst), 3);

        using var src2 = MakeFloat(Rows, Cols, 5f);
        using var dst2 = new GpuMat();

        Cv2.Cuda.Abs(src2, dst2);

        Assert.Equal(5f, PixelF(dst2), 3);
    }

    [Fact]
    public void Absdiff()
    {
        VerifyCudaSupport();

        // part 1
        using var src1 = MakeFloat(Rows, Cols, 10f);
        using var src2 = MakeFloat(Rows, Cols, 3f);
        using var dst1 = new GpuMat();

        Cv2.Cuda.Absdiff(src1, src2, dst1);

        Assert.Equal(7f, PixelF(dst1), 3);

        // part 2
        using var src3 = MakeFloat(Rows, Cols, 3f);
        using var src4 = MakeFloat(Rows, Cols, 10f);
        using var dst2 = new GpuMat();

        Cv2.Cuda.Absdiff(src3, src4, dst2);

        Assert.Equal(7f, PixelF(dst2), 3);
    }
   
    [Fact]
    public void AbsdiffWithScalar()
    {
        // 1. Check if a CUDA device is available. If not, skip the test.
        VerifyCudaSupport();

        int rows = 10;
        int cols = 10;

        // Set up test values
        byte matrixValue = 50;
        double scalarValue = 120;
        byte expectedValue = 70; // |50 - 120| = 70

        // 2. Initialize host (CPU) matrices
        using var cpuSrc = new Mat(rows, cols, MatType.CV_8UC1, new Scalar(matrixValue));
        using var cpuDst = new Mat();

        // 3. Initialize device (GPU) matrices and upload data
        using var gpuSrc = new GpuMat();
        using var gpuDst = new GpuMat();

        gpuSrc.Upload(cpuSrc);

        // 4. Call wrapped method
        // (Assuming your static method is in a class named `CudaInterop` or similar)
        Scalar scalarToSubtract = new Scalar(scalarValue);

        Cv2.Cuda.Absdiff(gpuSrc, scalarToSubtract, gpuDst);

        // 5. Download the result from GPU back to CPU to verify
        gpuDst.Download(cpuDst);

        // 6. Assertions (Verify the output)
        Assert.False(cpuDst.Empty(), "Destination matrix should not be empty.");
        Assert.Equal(rows, cpuDst.Rows);
        Assert.Equal(cols, cpuDst.Cols);
        Assert.Equal(MatType.CV_8UC1, cpuDst.Type());

        // 7. Verify the math of every pixel
        var indexer = cpuDst.GetGenericIndexer<byte>();
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Assert.Equal(expectedValue,indexer[y, x]);
            }
        }
    }

    [Fact]
    public void AbsSum_1()
    {
        VerifyCudaSupport();

        // Create a 2x2 matrix filled with -5 (Using 32-bit signed int, as 64F is not allowed)
        using var cpuSrc1 = new Mat(2, 2, MatType.CV_32SC1, new Scalar(-5));
        using var gpuSrc1 = new GpuMat();
        gpuSrc1.Upload(cpuSrc1);

        // Calculate AbsSum
        // |-5| * 4 pixels = 20
        Scalar result1 = Cv2.Cuda.AbsSum(gpuSrc1);

        // Val0 contains the sum for the first channel
        Assert.Equal(20, result1.Val0);
    }

    [Fact]
    public void AbsSum_2()
    {
        VerifyCudaSupport();

        using var cpuSrc2 = new Mat(2, 2, MatType.CV_32SC1, new Scalar(-5));
        using var gpuSrc2 = new GpuMat();
        gpuSrc2.Upload(cpuSrc2);

        // Create a mask. Only the top row (2 pixels) will be active (255).
        // The bottom row will be ignored (0).
        using var cpuMask2 = new Mat(2, 2, MatType.CV_8UC1, new Scalar(0));
        cpuMask2.Set<byte>(0, 0, 255);
        cpuMask2.Set<byte>(0, 1, 255);

        using var gpuMask2 = new GpuMat();
        gpuMask2.Upload(cpuMask2);

        // Calculate AbsSum with mask
        // |-5| * 2 active pixels = 10
        Scalar result2 = Cv2.Cuda.AbsSum(gpuSrc2, gpuMask2);

        Assert.Equal(10, result2.Val0);
    }

    [Fact]
    public void Add()
    {
        VerifyCudaSupport();

        // same test as Core
        using var src1 = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var src2 = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });

        // port everything to cuda
        using GpuMat gpuSrc1 = new GpuMat(src1);
        using GpuMat gpuSrc2 = new GpuMat(src2);
        using GpuMat gpuDst = new GpuMat();
        // the actual function
        Cv2.Cuda.Add(gpuSrc1, gpuSrc2, gpuDst);
        // downlaod results
        using Mat dst = new Mat();
        gpuDst.Download(dst);

        // same test as Core
        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(2, dst.Rows);
        Assert.Equal(2, dst.Cols);

        Assert.Equal(2, dst.At<byte>(0, 0));
        Assert.Equal(4, dst.At<byte>(0, 1));
        Assert.Equal(6, dst.At<byte>(1, 0));
        Assert.Equal(8, dst.At<byte>(1, 1));
    }

    [Fact]
    public void AddWeighted()
    {
        VerifyCudaSupport();

        // dst = 2*3 + 3*4 + 1 = 19
        using var src1 = MakeFloat(Rows, Cols, 3f);
        using var src2 = MakeFloat(Rows, Cols, 4f);
        using var dst = new GpuMat();

        Cv2.Cuda.AddWeighted(src1, 2.0, src2, 3.0, 1.0, dst);

        Assert.Equal(19f, PixelF(dst), 2);
    }

    [Fact]
    public void AddScalar()
    {
        using var srcCpu = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var srcGpu = new GpuMat(srcCpu);
        using GpuMat gpuDst = new GpuMat();
        Cv2.Cuda.Add(new Scalar(10), srcGpu, gpuDst);

        using var dst = new Mat();
        gpuDst.Download(dst);

        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(2, dst.Rows);
        Assert.Equal(2, dst.Cols);

        Assert.Equal(11, dst.At<byte>(0, 0));
        Assert.Equal(12, dst.At<byte>(0, 1));
        Assert.Equal(13, dst.At<byte>(1, 0));
        Assert.Equal(14, dst.At<byte>(1, 1));

        Cv2.Cuda.Add(srcGpu, new Scalar(10), gpuDst);
        gpuDst.Download(dst);
        Assert.Equal(11, dst.At<byte>(0, 0));
        Assert.Equal(12, dst.At<byte>(0, 1));
        Assert.Equal(13, dst.At<byte>(1, 0));
        Assert.Equal(14, dst.At<byte>(1, 1));

        using var inputArray = OpenCvSharp.Cuda.InputArray.Create(10.0);
        Cv2.Cuda.Add(srcGpu, inputArray, gpuDst);
        gpuDst.Download(dst);
        Assert.Equal(11, dst.At<byte>(0, 0));
        Assert.Equal(12, dst.At<byte>(0, 1));
        Assert.Equal(13, dst.At<byte>(1, 0));
        Assert.Equal(14, dst.At<byte>(1, 1));
    }

    [Fact]
    public void BitwiseAnd()
    {
        VerifyCudaSupport();

        // 0b1111_0000 & 0b1010_1010 = 0b1010_0000 = 160
        using var src1 = MakeByte(Rows, Cols, 0b1111_0000);
        using var src2 = MakeByte(Rows, Cols, 0b1010_1010);
        using var dst = new GpuMat();

        Cv2.Cuda.BitwiseAnd(src1, src2, dst);

        Assert.Equal((byte)0b1010_0000, PixelB(dst));
    }

    [Fact]
    public void BitwiseAndWithScalar()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a matrix filled with 12
        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(12));
        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // 2. Act: Bitwise AND with a scalar value of 10
        using var gpuDst = new GpuMat();
        Cv2.Cuda.BitwiseAnd(gpuSrc, new Scalar(10), gpuDst);
        
        // 3. Download to verify
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // 4. Assert
        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_8UC1, cpuDst.Type());

        // Validate that 12 & 10 = 8
        Assert.Equal(8, cpuDst.At<byte>(0, 0));
        Assert.Equal(8, cpuDst.At<byte>(2, 2)); // Check another pixel to ensure matrix-wide execution
    }

    [Fact]
    public void BitwiseNot()
    {
        VerifyCudaSupport();

        // ~0b0000_1111 = 0b1111_0000 = 240
        using var src = MakeByte(Rows, Cols, 0b0000_1111);
        using var dst = new GpuMat();

        Cv2.Cuda.BitwiseNot(src, dst);

        Assert.Equal((byte)0b1111_0000, PixelB(dst));
    }

    [Fact]
    public void BitwiseNot_WithEmptyMask()
    {
        VerifyCudaSupport();

        using var src = MakeByte(Rows, Cols, 0b0000_1111);
        using var mask = MakeByte(Rows, Cols, 0);
        using var dst = MakeByte(Rows, Cols, 0b1010_1010); // Known background

        Cv2.Cuda.BitwiseNot(src, dst, mask: mask);

        Assert.Equal((byte)0b1010_1010, PixelB(dst));
    }

    [Fact]
    public void BitwiseOr()
    {
        VerifyCudaSupport();

        // 0b1100_0000 | 0b0000_1100 = 0b1100_1100 = 204
        using var src1 = MakeByte(Rows, Cols, 0b1100_0000);
        using var src2 = MakeByte(Rows, Cols, 0b0000_1100);
        using var dst = new GpuMat();

        Cv2.Cuda.BitwiseOr(src1, src2, dst);

        Assert.Equal((byte)0b1100_1100, PixelB(dst));
    }

    [Fact]
    public void BitwiseOrWithScalar()
    {
        VerifyCudaSupport();

        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(10));
        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();
        Cv2.Cuda.BitwiseOr(gpuSrc, new Scalar(12), gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        // 10 | 12 = 14
        Assert.Equal(14, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void BitwiseXor_1()
    {
        VerifyCudaSupport();

        // 0b1111_0000 ^ 0b1010_1010 = 0b0101_1010 = 90
        using var src1 = MakeByte(Rows, Cols, 0b1111_0000);
        using var src2 = MakeByte(Rows, Cols, 0b1010_1010);
        using var dst = new GpuMat();

        Cv2.Cuda.BitwiseXor(src1, src2, dst);

        Assert.Equal((byte)0b0101_1010, PixelB(dst));
    }
    [Fact]
    public void BitwiseXor_2()
    {
        VerifyCudaSupport();

        using var srcDst = MakeByte(Rows, Cols, 0b1100_1100);

        // XORing a matrix with itself should result in 0
        Cv2.Cuda.BitwiseXor(srcDst, srcDst, srcDst);

        Assert.Equal((byte)0, PixelB(srcDst));
    }


    [Fact]
    public void BitwiseXorWithScalar()
    {
        VerifyCudaSupport();

        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(10));
        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();
        Cv2.Cuda.BitwiseXor(gpuSrc, new Scalar(12), gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        // 10 ^ 12 = 6
        Assert.Equal(6, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void CalcSumTest()
    {
        VerifyCudaSupport();

        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1, new Scalar(10));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        Cv2.Cuda.CalcSum(gpuSrc, gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // 10 * 4 pixels = 40
        Assert.Equal(40.0, cpuDst.At<double>(0, 0));
    }

    [Fact]
    public void CalcAbsSumTest()
    {
        VerifyCudaSupport();

        // Use 32SC1 for negative numbers
        using var cpuSrc = new Mat(2, 2, MatType.CV_32SC1, new Scalar(-5));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        Cv2.Cuda.CalcAbsSum(gpuSrc, gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // |-5| * 4 pixels = 20
        Assert.Equal(20.0, cpuDst.At<double>(0, 0));
    }

    [Fact]
    public void CalcSqrSumTest()
    {
        VerifyCudaSupport();

        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1, new Scalar(4));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        Cv2.Cuda.CalcSqrSum(gpuSrc, gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // (4^2) * 4 pixels = 16 * 4 = 64
        Assert.Equal(64.0, cpuDst.At<double>(0, 0));
    }

    [Fact]
    public void CalcNormTest()
    {
        VerifyCudaSupport();


        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1, new Scalar(3));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // L1 Norm = sum of absolute values
        Cv2.Cuda.CalcNorm(gpuSrc, gpuDst, NormTypes.L1);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // |3| * 4 pixels = 12
        Assert.Equal(12.0, cpuDst.At<double>(0, 0));
    }

    [Fact]
    public void CalcHistTest()
    {
        VerifyCudaSupport();


        // Create a 10x10 image
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        // Fill half of it with intensity 50
        cpuSrc[0, 5, 0, 10] = new Mat(5, 10, MatType.CV_8UC1, new Scalar(50));
        // Fill half of it with intensity 100
        cpuSrc[5, 10, 0, 10] = new Mat(5, 10, MatType.CV_8UC1, new Scalar(100));

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuHist = new GpuMat();

        // Act
        Cv2.Cuda.CalcHist(gpuSrc, gpuHist);

        // Assert
        using var cpuHist = new Mat();
        gpuHist.Download(cpuHist);

        Assert.False(cpuHist.Empty());
        // calcHist outputs a 1x256 array of integers (CV_32SC1)
        Assert.Equal(MatType.CV_32SC1, cpuHist.Type());
        Assert.Equal(256, cpuHist.Cols);

        // 50 pixels with intensity 50
        Assert.Equal(50, cpuHist.At<int>(0, 50));
        // 50 pixels with intensity 100
        Assert.Equal(50, cpuHist.At<int>(0, 100));
        // 0 pixels with intensity 99
        Assert.Equal(0, cpuHist.At<int>(0, 99));
    }

    [Fact]
    public void CartToPolar_1()
    {
        VerifyCudaSupport();

        // x=1, y=0 → magnitude=1, angle=0°
        using var x = MakeFloat(Rows, Cols, 1f);
        using var y = MakeFloat(Rows, Cols, 0f);
        using var mag = new GpuMat();
        using var ang = new GpuMat();

        Cv2.Cuda.CartToPolar(x, y, mag, ang, angleInDegrees: true);

        Assert.Equal(1f, PixelF(mag), 3);
        Assert.Equal(0f, PixelF(ang), 3);
    }

    [Fact]
    public void CartToPolar_2()
    {
        VerifyCudaSupport();

        using var x = MakeFloat(Rows, Cols, 1f);
        using var y = MakeFloat(Rows, Cols, 1f);
        using var mag = new GpuMat();
        using var ang = new GpuMat();

        Cv2.Cuda.CartToPolar(x, y, mag, ang);

        Assert.Equal(Math.Sqrt(2f), PixelF(mag), 2);
    }

    [Fact]
    public void Compare_1()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 5f);
        using var src2 = MakeFloat(Rows, Cols, 5f);
        using var dst = new GpuMat();

        Cv2.Cuda.Compare(src1, src2, dst, CmpTypes.EQ);

        // OpenCV returns 255 for true comparisons
        using var cpu = new Mat();
        dst.Download(cpu);
        Assert.Equal(255, cpu.At<byte>(0, 0));
    }

    [Fact]
    public void Compare_2()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 5f);
        using var src2 = MakeFloat(Rows, Cols, 6f);
        using var dst = new GpuMat();

        Cv2.Cuda.Compare(src1, src2, dst, CmpTypes.EQ);

        using var cpu = new Mat();
        dst.Download(cpu);
        Assert.Equal(0, cpu.At<byte>(0, 0));
    }

    [Fact]
    public void Compare_3()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 10f);
        using var src2 = MakeFloat(Rows, Cols, 5f);
        using var dst = new GpuMat();

        // 10 > 5 is True (255)
        Cv2.Cuda.Compare(src1, src2, dst, CmpTypes.GT);

        Assert.Equal((byte)255, PixelB(dst));
    }

    [Fact]
    public void Compare_4()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 10f);
        using var src2 = MakeFloat(Rows, Cols, 5f);
        using var dst = new GpuMat();

        // 10 < 5 is False (0)
        Cv2.Cuda.Compare(src1, src2, dst, CmpTypes.LT);

        Assert.Equal((byte)0, PixelB(dst));
    }

    [Fact]
    public void Compare_5()
    {
        VerifyCudaSupport();

        // Arrange: matrix with [50, 150]
        using var cpuSrc = Mat.FromPixelData(1, 2, MatType.CV_8UC1, new byte[] { 50, 150 });
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Act: Find where src > 100
        using var gpuDst = new GpuMat(); 
        Cv2.Cuda.Compare(gpuSrc, new Scalar(100), gpuDst, CmpTypes.GT);
        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // index 0: 50 > 100 (False -> 0)
        // index 1: 150 > 100 (True -> 255)
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
        Assert.Equal(255, cpuDst.At<byte>(0, 1));
    }

    [Fact]
    public void CopyMakeBorder()
    {
        VerifyCudaSupport();

        // Arrange: 2x2 image filled with 100
        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1, new Scalar(100));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Act: Add a 1-pixel constant border of value 255 around it
        using var gpuDst = new GpuMat();
        Cv2.Cuda.CopyMakeBorder(
            gpuSrc, gpuDst,
            top: 1, bottom: 1, left: 1, right: 1,
            borderType: BorderTypes.Constant,
            value: new Scalar(255));

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Original was 2x2. Added 1 top/bottom (2) and 1 left/right (2) -> Now 4x4
        Assert.Equal(4, cpuDst.Rows);
        Assert.Equal(4, cpuDst.Cols);

        // Check original pixel is still there in the new center
        Assert.Equal(100, cpuDst.At<byte>(1, 1));

        // Check that the border pixel is exactly what we specified (255)
        Assert.Equal(255, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void CountNonZero_1()
    {
        VerifyCudaSupport();

        // Arrange: Create a 3x3 matrix initialized to ZEROS
        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(0));

        // Set exactly 4 pixels to non-zero values
        cpuSrc.Set<byte>(0, 0, 255);
        cpuSrc.Set<byte>(1, 1, 100);
        cpuSrc.Set<byte>(2, 2, 50);
        cpuSrc.Set<byte>(0, 2, 1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Act (Synchronous method)
        int count = Cv2.Cuda.CountNonZero(gpuSrc);

        // Assert
        Assert.Equal(4, count);
    }

    [Fact]
    public void CountNonZero_2()
    {
        VerifyCudaSupport();

        // Arrange
        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(0, 0, 255);
        cpuSrc.Set<byte>(1, 1, 100);
        cpuSrc.Set<byte>(2, 2, 50);
        cpuSrc.Set<byte>(0, 2, 1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Act (Asynchronous / GpuMat output method)
        using var gpuDst = new GpuMat();
            Cv2.Cuda.CountNonZero(gpuSrc,gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // OpenCV's CountNonZero kernel outputs a single 32-bit integer (CV_32SC1)
        Assert.Equal(MatType.CV_32SC1, cpuDst.Type());
        Assert.Equal(1, cpuDst.Rows);
        Assert.Equal(1, cpuDst.Cols);

        // Verify the count inside the matrix is correct
        Assert.Equal(4, cpuDst.At<int>(0, 0));
    }

    [Fact]
    public void Divide_TwoMatrices_ReturnsQuotient()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 10f);
        using var src2 = MakeFloat(Rows, Cols, 4f);
        using var dst = new GpuMat();

        Cv2.Cuda.Divide(src1, src2, dst);

        Assert.Equal(2.5f, PixelF(dst), 3);
    }

    [Fact]
    public void Divide_WithScale_ReturnsScaledQuotient()
    {
        VerifyCudaSupport();

        // (10 / 2) * 3 = 15
        using var src1 = MakeFloat(Rows, Cols, 10f);
        using var src2 = MakeFloat(Rows, Cols, 2f);
        using var dst = new GpuMat();

        Cv2.Cuda.Divide(src1, src2, dst, scale: 3.0);

        Assert.Equal(15f, PixelF(dst), 2);
    }

    [Fact]
    public void Exp_Zero_ReturnsOne()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 0f);
        using var dst = new GpuMat();

        Cv2.Cuda.Exp(src, dst);

        Assert.Equal(1f, PixelF(dst), 3);
    }

    [Fact]
    public void Exp_One_ReturnsE()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 1f);
        using var dst = new GpuMat();

        Cv2.Cuda.Exp(src, dst);

        Assert.Equal(Math.E, PixelF(dst), 2);
    }

    [Fact]
    public void Log_One_ReturnsZero()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 1f);
        using var dst = new GpuMat();

        Cv2.Cuda.Log(src, dst);

        Assert.Equal(0f, PixelF(dst), 3);
    }

    [Fact]
    public void Log_E_ReturnsOne()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, (float) Math.E);
        using var dst = new GpuMat();

        Cv2.Cuda.Log(src, dst);

        Assert.Equal(1f, PixelF(dst), 3);
    }

    [Fact]
    public void Lshift_ByteMatrix_ShiftsByGivenAmount()
    {
        VerifyCudaSupport();

        // 1 << 3 = 8
        using var src = MakeByte(Rows, Cols, 1);
        using var dst = new GpuMat();

        Cv2.Cuda.Lshift(src, new Scalar(3, 0, 0, 0), dst);

        Assert.Equal((byte)8, PixelB(dst));
    }

    [Fact]
    public void Rshift_ByteMatrix_ShiftsByGivenAmount()
    {
        VerifyCudaSupport();

        // 16 >> 2 = 4
        using var src = MakeByte(Rows, Cols, 16);
        using var dst = new GpuMat();

        Cv2.Cuda.Rshift(src, new Scalar(2, 0, 0, 0), dst);

        Assert.Equal((byte)4, PixelB(dst));
    }

    [Fact]
    public void Magnitude_SeparatePlanes_Returns345Hypotenuse()
    {
        VerifyCudaSupport();

        // 3-4-5 right triangle
        using var x = MakeFloat(Rows, Cols, 3f);
        using var y = MakeFloat(Rows, Cols, 4f);
        using var mag = new GpuMat();

        Cv2.Cuda.Magnitude(x, y, mag);

        Assert.Equal(5f, PixelF(mag), 2);
    }


    [Fact]
    public void MagnitudeSqr_SeparatePlanes_ReturnsSquaredMagnitude()
    {
        VerifyCudaSupport();

        // sqrt(3² + 4²) = 5, so sqr = 25
        using var x = MakeFloat(Rows, Cols, 3f);
        using var y = MakeFloat(Rows, Cols, 4f);
        using var mag = new GpuMat();

        Cv2.Cuda.MagnitudeSqr(x, y, mag);

        Assert.Equal(25f, PixelF(mag), 2);
    }

    [Fact]
    public void Max_TwoMatrices_ReturnsLarger()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 7f);
        using var src2 = MakeFloat(Rows, Cols, 3f);
        using var dst = new GpuMat();

        Cv2.Cuda.Max(src1, src2, dst);

        Assert.Equal(7f, PixelF(dst), 3);
    }

    [Fact]
    public void MaxWithScalar_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 1x2 matrix with values 50 and 150
        using var cpuSrc = Mat.FromPixelData(1, 2, MatType.CV_8UC1, new byte[] { 50, 150 });
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Take max with 100
        // Math: max(50, 100) = 100; max(150, 100) = 150
        Cv2.Cuda.Max(gpuSrc, new Scalar(100), gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // index 0: was 50, capped at 100
        Assert.Equal(100, cpuDst.At<byte>(0, 0));
        // index 1: was 150, stays 150
        Assert.Equal(150, cpuDst.At<byte>(0, 1));
    }

    [Fact]
    public void Min_TwoMatrices_ReturnsSmaller()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 7f);
        using var src2 = MakeFloat(Rows, Cols, 3f);
        using var dst = new GpuMat();

        Cv2.Cuda.Min(src1, src2, dst);

        Assert.Equal(3f, PixelF(dst), 3);
    }

    [Fact]
    public void Multiply_TwoMatrices_ReturnsProduct()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 6f);
        using var src2 = MakeFloat(Rows, Cols, 7f);
        using var dst = new GpuMat();

        Cv2.Cuda.Multiply(src1, src2, dst);

        Assert.Equal(42f, PixelF(dst), 3);
    }

    [Fact]
    public void Multiply_WithScale_ReturnsScaledProduct()
    {
        VerifyCudaSupport();

        // (2 * 3) * 0.5 = 3
        using var src1 = MakeFloat(Rows, Cols, 2f);
        using var src2 = MakeFloat(Rows, Cols, 3f);
        using var dst = new GpuMat();

        Cv2.Cuda.Multiply(src1, src2, dst, scale: 0.5);

        Assert.Equal(3f, PixelF(dst), 3);
    }

    [Fact]
    public void Phase_PositiveXZeroY_AngleIsZero()
    {
        VerifyCudaSupport();

        using var x = MakeFloat(Rows, Cols, 1f);
        using var y = MakeFloat(Rows, Cols, 0f);
        using var ang = new GpuMat();

        Cv2.Cuda.Phase(x, y, ang, angleInDegrees: true);

        Assert.Equal(0f, PixelF(ang), 2);
    }

    [Fact]
    public void Phase_EqualXY_AngleIs45Degrees()
    {
        VerifyCudaSupport();

        using var x = MakeFloat(Rows, Cols, 1f);
        using var y = MakeFloat(Rows, Cols, 1f);
        using var ang = new GpuMat();

        Cv2.Cuda.Phase(x, y, ang, angleInDegrees: true);

        Assert.Equal(45f, PixelF(ang), 1);
    }

    [Fact]
    public void PolarToCart_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Magnitude 5, Angle ~53.13 degrees
        using var gpuMag = new GpuMat(1, 1, MatType.CV_32FC1, new Scalar(5.0f));
        using var gpuAngle = new GpuMat(1, 1, MatType.CV_32FC1, new Scalar(53.1301024f));
        using var gpuX = new GpuMat();
        using var gpuY = new GpuMat();

        // 2. Act
        Cv2.Cuda.PolarToCart(gpuMag, gpuAngle, gpuX, gpuY, angleInDegrees: true);

        // 3. Download and Assert
        using var cpuX = new Mat();
        using var cpuY = new Mat();
        gpuX.Download(cpuX);
        gpuY.Download(cpuY);

        // Results should be approx 3 and 4
        Assert.InRange(cpuX.At<float>(0, 0), 2.99f, 3.01f);
        Assert.InRange(cpuY.At<float>(0, 0), 3.99f, 4.01f);
    }

    [Fact]
    public void PolarToCart_InterleavedTest()
    {
        VerifyCudaSupport();

        // Arrange: 2-channel [Magnitude, Angle]
        using var gpuMA = new GpuMat(1, 1, MatType.CV_32FC2, new Scalar(5.0f, 53.1301024f));
        using var gpuXY = new GpuMat();

        // Act
        Cv2.Cuda.PolarToCart(gpuMA, gpuXY, angleInDegrees: true);

        // Assert
        using var cpuXY = new Mat();
        gpuXY.Download(cpuXY);
        Vec2f res = cpuXY.At<Vec2f>(0, 0);

        Assert.InRange(res.Item0, 2.99f, 3.01f); // X
        Assert.InRange(res.Item1, 3.99f, 4.01f); // Y
    }

    [Fact]
    public void Pow_BaseAndExponent_ReturnsCorrectPower()
    {
        VerifyCudaSupport();

        // 3^4 = 81
        using var src = MakeFloat(Rows, Cols, 3f);
        using var dst = new GpuMat();

        Cv2.Cuda.Pow(src, 4.0, dst);

        Assert.Equal(81f, PixelF(dst), 1);
    }

    [Fact]
    public void Pow_ExponentZero_ReturnsOne()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 99f);
        using var dst = new GpuMat();

        Cv2.Cuda.Pow(src, 0.0, dst);

        Assert.Equal(1f, PixelF(dst), 3);
    }

    [Fact]
    public void ScaleAdd_ComputesAlphaSrc1PlusSrc2()
    {
        VerifyCudaSupport();

        // 2.5 * 4 + 3 = 13
        using var src1 = MakeFloat(Rows, Cols, 4f);
        using var src2 = MakeFloat(Rows, Cols, 3f);
        using var dst = new GpuMat();

        Cv2.Cuda.ScaleAdd(src1, 2.5, src2, dst);

        Assert.Equal(13f, PixelF(dst), 2);
    }

    [Fact]
    public void Sqr_PositiveValue_ReturnsSquare()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 9f);
        using var dst = new GpuMat();

        Cv2.Cuda.Sqr(src, dst);

        Assert.Equal(81f, PixelF(dst), 2);
    }

    [Fact]
    public void Sqrt_PerfectSquare_ReturnsRoot()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 144f);
        using var dst = new GpuMat();

        Cv2.Cuda.Sqrt(src, dst);

        Assert.Equal(12f, PixelF(dst), 3);
    }

    [Fact]
    public void Subtract_TwoMatrices_ReturnsDifference()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 10f);
        using var src2 = MakeFloat(Rows, Cols, 3f);
        using var dst = new GpuMat();

        Cv2.Cuda.Subtract(src1, src2, dst);

        Assert.Equal(7f, PixelF(dst), 3);
    }

    [Fact]
    public void Threshold_BinaryType_PixelsAboveThresholdBecome255()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 200f);
        using var dst = new GpuMat();

        Cv2.Cuda.Threshold(src, dst, thresh: 100.0, maxval: 255.0,
            ThresholdTypes.Binary);

        Assert.Equal(255f, PixelF(dst), 0);
    }

    [Fact]
    public void Threshold_BinaryType_PixelsBelowThresholdBecomeZero()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 50f);
        using var dst = new GpuMat();

        Cv2.Cuda.Threshold(src, dst, thresh: 100.0, maxval: 255.0,
            ThresholdTypes.Binary);

        Assert.Equal(0f, PixelF(dst), 0);
    }

    [Fact]
    public void Threshold_ReturnsThresholdValue()
    {
        VerifyCudaSupport();

        using var src = MakeFloat(Rows, Cols, 50f);
        using var dst = new GpuMat();

        double returned = Cv2.Cuda.Threshold(src, dst,
            thresh: 128.0, maxval: 255.0, ThresholdTypes.Binary);

        Assert.Equal(128.0, returned, 3);
    }

    [Fact]
    public void Add_NullSrc1_Throws() =>
        Assert.Throws<ArgumentNullException>(() =>
            Cv2.Cuda.Add(null!, new GpuMat(), new GpuMat()));

    [Fact]
    public void Add_NullSrc2_Throws()
    {
        using var src1 = new GpuMat();
        Assert.Throws<ArgumentNullException>(() =>
            Cv2.Cuda.Add(src1, null!, new GpuMat()));
    }

    [Fact]
    public void Add_NullDst_Throws()
    {
        using var src1 = new GpuMat();
        using var src2 = new GpuMat();
        Assert.Throws<ArgumentNullException>(() =>
            Cv2.Cuda.Add(src1, src2, null!));
    }

    [Fact]
    public void Threshold_NullSrc_Throws() =>
        Assert.Throws<ArgumentNullException>(() =>
            Cv2.Cuda.Threshold(null!, new GpuMat(), 0, 255, ThresholdTypes.Binary));

    [Fact]
    public void Threshold_NullDst_Throws()
    {
        using var src = new GpuMat();
        Assert.Throws<ArgumentNullException>(() =>
            Cv2.Cuda.Threshold(src, null!, 0, 255, ThresholdTypes.Binary));
    }

    [Fact]
    public void Subtract_WithStream_VerifiesResult()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 20f);
        using var src2 = MakeFloat(Rows, Cols, 5f);
        using var dst = new GpuMat();
        using var stream = new OpenCvSharp.Cuda.Stream();

        Cv2.Cuda.Subtract(src1, src2, dst, stream: stream);

        // Wait for the GPU to finish before checking the result
        stream.WaitForCompletion();

        Assert.Equal(15f, PixelF(dst), 3);
    }

    [Fact]
    public void CartToPolar_WithStream_VerifiesResult()
    {
        VerifyCudaSupport();

        using var x = MakeFloat(Rows, Cols, 3f);
        using var y = MakeFloat(Rows, Cols, 4f);
        using var mag = new GpuMat();
        using var ang = new GpuMat();
        using var stream = new OpenCvSharp.Cuda.Stream();

        Cv2.Cuda.CartToPolar(x, y, mag, ang, stream: stream);
        stream.WaitForCompletion();

        Assert.Equal(5f, PixelF(mag), 2);
    }

    [Fact]
    public void Add_WithEmptyMask_LeavesDestinationUntouched()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 4f);
        using var src2 = MakeFloat(Rows, Cols, 6f);
        using var mask = MakeByte(Rows, Cols, 0); // 0 = Do not process
        using var dst = MakeFloat(Rows, Cols, 99f); // Pre-fill with known value

        Cv2.Cuda.Add(src1, src2, dst, mask: mask);

        // Because the mask is 0 everywhere, dst should remain 99f, not 10f
        Assert.Equal(99f, PixelF(dst), 3);
    }

    [Fact]
    public void Add_WithFullMask_UpdatesDestination()
    {
        VerifyCudaSupport();

        using var src1 = MakeFloat(Rows, Cols, 4f);
        using var src2 = MakeFloat(Rows, Cols, 6f);
        using var mask = MakeByte(Rows, Cols, 255); // 255 = Process everywhere
        using var dst = MakeFloat(Rows, Cols, 99f);

        Cv2.Cuda.Add(src1, src2, dst, mask: mask);

        // Because the mask is 255 everywhere, dst should be updated to 10f
        Assert.Equal(10f, PixelF(dst), 3);
    }

    [Fact]
    public void Add_InPlace_UpdatesSourceCorrectly()
    {
        VerifyCudaSupport();

        // We use the same matrix for src1 and dst
        using var srcDst = MakeFloat(Rows, Cols, 5f);
        using var src2 = MakeFloat(Rows, Cols, 2f);

        Cv2.Cuda.Add(srcDst, src2, srcDst);

        Assert.Equal(7f, PixelF(srcDst), 3);
    }

    [Fact]
    public void Multiply_WithDtype_CastsOutputProperly()
    {
        VerifyCudaSupport();

        // Input is byte (CV_8UC1)
        using var src1 = MakeByte(Rows, Cols, 100);
        using var src2 = MakeByte(Rows, Cols, 2);
        using var dst = new GpuMat();

        // Multiply to 200, but output as Float (MatType.CV_32FC1 == 5)
        Cv2.Cuda.Multiply(src1, src2, dst, dtype: (int)MatType.CV_32FC1);

        Assert.Equal(MatType.CV_32FC1, dst.Type());
        Assert.Equal(200f, PixelF(dst), 2);
    }

    [Fact]
    public void Phase_Radians_ReturnsCorrectAngle()
    {
        VerifyCudaSupport();

        using var x = MakeFloat(Rows, Cols, 1f);
        using var y = MakeFloat(Rows, Cols, 1f);
        using var ang = new GpuMat();

        // angleInDegrees = false -> Should return Pi/4 (approx 0.785)
        Cv2.Cuda.Phase(x, y, ang, angleInDegrees: false);

        Assert.Equal((float)(Math.PI / 4.0), PixelF(ang), 3);
    }

    [Fact]
    public void Convolution()
    {
        VerifyCudaSupport();

        // Arrange: 
        // Image: 4x4 filled with 1.0f
        using var cpuSrc = new Mat(4, 4, MatType.CV_32FC1, new Scalar(1.0f));
        // Kernel: 2x2 filled with 1.0f
        using var cpuTempl = new Mat(2, 2, MatType.CV_32FC1, new Scalar(1.0f));

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuTempl = new GpuMat(); gpuTempl.Upload(cpuTempl);
        using var gpuDst = new GpuMat();

        // Create Convolution algorithm
        using var convolution = OpenCvSharp.Cuda.Convolution.Create();

        // Act
        // Convolving a 2x2 square of 1s over a region of 1s should result in 4.0 (1*1 + 1*1 + 1*1 + 1*1)
        convolution.Convolve(gpuSrc, gpuTempl, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC1, cpuDst.Type());

        // Check center pixel. Due to FFT padding, we check (1,1)
        float resultVal = cpuDst.At<float>(1, 1);

        // Convolution results can have slight float noise, so we use a range
        Assert.InRange(resultVal, 3.99f, 4.01f);
    }

    [Fact]
    public void DFT()
    {
        VerifyCudaSupport();

        // 1. Create real input
        using var cpuReal = new Mat(4, 4, MatType.CV_32FC1, new Scalar(1.0f));

        using var gpuSrc = new GpuMat(); 
        gpuSrc.Upload(cpuReal);
        using var gpuDst = new GpuMat();

        // 3. Create DFT (no flags)
        using var dft = OpenCvSharp.Cuda.DFT.Create(new Size(4, 4), 0);

        // 4. Act
        dft.Compute(gpuSrc, gpuDst);

        // 5. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC2, cpuDst.Type());

        // DC component (sum of all values = 16)
        Vec2f dc = cpuDst.At<Vec2f>(0, 0);
        Assert.InRange(dc.Item0, 15.9f, 16.1f);
        Assert.InRange(dc.Item1, -0.1f, 0.1f);

        // AC component should be ~0
        Vec2f ac = cpuDst.At<Vec2f>(1, 1);
        Assert.InRange(ac.Item0, -0.1f, 0.1f);
        Assert.InRange(ac.Item1, -0.1f, 0.1f);
    }

    [Fact]
    public void LookUpTable_TransformTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create an inversion LUT (255 - i)
        using var cpuLut = new Mat(1, 256, MatType.CV_8UC1);
        var lutIndexer = cpuLut.GetGenericIndexer<byte>();
        for (int i = 0; i < 256; i++)
        {
            cpuLut.Set<byte>(0, i, (byte)(255 - i));
        }

        // 2. Arrange: Create a 5x5 source image filled with value '50'
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(50));
        using var gpuSrc = new GpuMat(); 
        gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 3. Act
        using var lut = OpenCvSharp.Cuda.LookUpTable.Create(cpuLut);
        lut.Transform(gpuSrc, gpuDst);

        // 4. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The value 50 through an inversion LUT (255 - 50) should be 205.
        Assert.Equal(205, cpuDst.At<byte>(0, 0));
    }



    [Fact]
    public void Dft_GlobalFuncTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 4x4 matrix of 1.0f
        using var cpuSrc = new Mat(4, 4, MatType.CV_32FC1, new Scalar(1.0f));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Perform DFT with Complex Output
        Cv2.Cuda.Dft(gpuSrc, gpuDst, new Size(4, 4), DftFlags.None);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC2, cpuDst.Type());

        // The DC component (0,0) Real part should be the sum (1.0 * 16 pixels = 16.0)
        Vec2f dc = cpuDst.At<Vec2f>(0, 0);
        Assert.InRange(dc.Item0, 15.9f, 16.1f);
    }

    [Fact]
    public void FindMinMaxLoc_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));
        cpuSrc.Set<byte>(5, 5, 10);
        cpuSrc.Set<byte>(50, 50, 200);

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuMinMax = new GpuMat();
        using var gpuLoc = new GpuMat();

        // 2. Act
        Cv2.Cuda.FindMinMaxLoc(gpuSrc, gpuMinMax, gpuLoc);

        // 3. Download
        using var cpuMinMax = new Mat();
        gpuMinMax.Download(cpuMinMax);

        Assert.False(cpuMinMax.Empty());

        // 4. Extract min/max safely
        double minVal, maxVal;

        // 1. Check if the results are packed into a single multi-channel pixel (1x1 CV_32FC2, etc.)
        if (cpuMinMax.Channels() >= 2)
        {
            if (cpuMinMax.Type() == MatType.CV_32FC2)
            {
                var vec = cpuMinMax.At<Vec2f>(0, 0);
                minVal = vec.Item0; maxVal = vec.Item1;
            }
            else
            {
                var vec = cpuMinMax.At<Vec2d>(0, 0);
                minVal = vec.Item0; maxVal = vec.Item1;
            }
        }
        // 2. Otherwise, they are in separate pixels (1x2 or 2x1)
        else
        {
            // Use Get<T> or a flat indexer to avoid "Row vs Col" confusion
            if (cpuMinMax.Type() == MatType.CV_32SC1)
            {
                // Use a flat loop or check dimensions
                minVal = cpuMinMax.Get<int>(0); // Get element 0
                maxVal = cpuMinMax.Get<int>(1); // Get element 1
            }
            else if (cpuMinMax.Type() == MatType.CV_32FC1)
            {
                minVal = cpuMinMax.Get<float>(0);
                maxVal = cpuMinMax.Get<float>(1);
            }
            else
            {
                minVal = cpuMinMax.Get<double>(0);
                maxVal = cpuMinMax.Get<double>(1);
            }
        }

        Assert.Equal(10, minVal);
        Assert.Equal(200, maxVal);

    }

    [Fact]
    public void Flip_YAxisTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 10x10 black image with a white pixel at (0, 0)
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(0, 0, 255);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Flip around Y-axis (Vertical Flip)
        Cv2.Cuda.Flip(gpuSrc, gpuDst, FlipMode.Y);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The original pixel was at (Row 0, Col 0).
        // After flipping around the Y-axis, it should be at (Row 0, Col 9).
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
        Assert.Equal(255, cpuDst.At<byte>(0, 9));
    }

    [Fact]
    public void Flip_XAxisTest()
    {
        VerifyCudaSupport();

        // Arrange: White pixel at (0, 0)
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(0, 0, 255);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Act: Flip around X-axis (Horizontal Flip)
        using var gpuDst = new GpuMat(); ;
        Cv2.Cuda.Flip(gpuSrc, gpuDst, FlipMode.X);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // The original pixel was at (Row 0, Col 0).
        // After flipping around the X-axis, it should be at (Row 9, Col 0).
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
        Assert.Equal(255, cpuDst.At<byte>(9, 0));
    }

    [Fact]
    public void GammaCorrection_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: grayscale → convert to BGR
        using var gray = new Mat(10, 10, MatType.CV_8UC1, new Scalar(128));
        using var cpuSrc = new Mat();
        Cv2.CvtColor(gray, cpuSrc, ColorConversionCodes.GRAY2BGR);

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.GammaCorrection(gpuSrc, gpuDst, forward: true);

        // 3. Download
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_8UC3, cpuDst.Type());

        // 4. Validate one channel (all channels are equal)
        Vec3b pixel = cpuDst.At<Vec3b>(0, 0);
        byte value = pixel.Item0;

        Assert.NotEqual(128, value);
        Assert.InRange(value, 180, 195);
    }

    [Fact]
    public void Gemm_BasicMultiplicationTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 
        // A (2x1) * B (1x2) = Result (2x2)
        using var cpuA = Mat.FromPixelData(2, 1, MatType.CV_32FC1, new float[] { 2, 2 });
        using var cpuB = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 3, 3 });

        using var gpuA = new GpuMat(); gpuA.Upload(cpuA);
        using var gpuB = new GpuMat(); gpuB.Upload(cpuB);
        using var gpuDst = new GpuMat();

        // 2. Act: Result = 1.0 * A * B + 0.0 * null
        Cv2.Cuda.Gemm(gpuA, gpuB, 1.0, null, 0.0, gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(2, cpuDst.Rows);
        Assert.Equal(2, cpuDst.Cols);

        // All elements should be 6.0
        Assert.Equal(6.0f, cpuDst.At<float>(0, 0));
        Assert.Equal(6.0f, cpuDst.At<float>(1, 1));
    }

    [Fact]
    public void Gemm_WithAdditionTest()
    {
        VerifyCudaSupport();

        // Arrange: (1x1) mat: (2 * 3) + (10 * 0.5) = 11
        using var gpuA = new GpuMat(1, 1, MatType.CV_32FC1, new Scalar(2));
        using var gpuB = new GpuMat(1, 1, MatType.CV_32FC1, new Scalar(3));
        using var gpuC = new GpuMat(1, 1, MatType.CV_32FC1, new Scalar(10));
        using var gpuDst = new GpuMat();

        // Act: 1.0 * (A*B) + 0.5 * C
        Cv2.Cuda.Gemm(gpuA, gpuB, 1.0, gpuC, 0.5, gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.Equal(11.0f, cpuDst.At<float>(0, 0));
    }

    [Fact]
    public void Integral_Test()
    {
        VerifyCudaSupport();

        // Arrange: 2x2 matrix of 1s
        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1, new Scalar(1));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuSum = new GpuMat();

        // Act
        Cv2.Cuda.Integral(gpuSrc, gpuSum);

        // Assert
        using var cpuSum = new Mat();
        gpuSum.Download(cpuSum);

        // Integral size is (W+1)x(H+1) -> 3x3
        Assert.Equal(3, cpuSum.Rows);
        // Bottom-right pixel (2,2) should be the sum of all (1+1+1+1 = 4)
        // CUDA integral defaults to CV_32S
        Assert.Equal(4, cpuSum.At<int>(2, 2));
    }

    [Fact]
    public void MeanStdDev_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix with values 10, 20, 30, 40
        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1);
        cpuSrc.Set<byte>(0, 0, 10);
        cpuSrc.Set<byte>(0, 1, 20);
        cpuSrc.Set<byte>(1, 0, 30);
        cpuSrc.Set<byte>(1, 1, 40);

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // 2. Act
        Cv2.Cuda.MeanStdDev(gpuSrc, out Scalar mean, out Scalar stddev);

        // 3. Assert
        // Mean should be exactly 25
        Assert.Equal(25.0, mean.Val0);

        // StdDev should be ~11.18
        Assert.InRange(stddev.Val0, 11.17, 11.19);
    }

    [Fact]
    public void MeanStdDev_OutputArrayTest()
    {
        VerifyCudaSupport();

        // 1. Arrange
        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1);
        cpuSrc.Set<byte>(0, 0, 10);
        cpuSrc.Set<byte>(0, 1, 20);
        cpuSrc.Set<byte>(1, 0, 30);
        cpuSrc.Set<byte>(1, 1, 40);

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.MeanStdDev(gpuSrc, gpuDst);

        // 3. Download
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Expected layout: 1x2
        Assert.Equal(1, cpuDst.Rows);
        Assert.Equal(2, cpuDst.Cols);
        Assert.Equal(MatType.CV_64FC1, cpuDst.Type());

        double mean = cpuDst.At<double>(0, 0);
        double stddev = cpuDst.At<double>(0, 1);

        Assert.Equal(25.0, mean);
        Assert.InRange(stddev, 11.17, 11.19);
    }

    [Fact]
    public void Merge_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Two 1-channel images
        using var cpuSrc1 = new Mat(5, 5, MatType.CV_8UC1, new Scalar(10));
        using var cpuSrc2 = new Mat(5, 5, MatType.CV_8UC1, new Scalar(20));

        using var gpuSrc1 = new GpuMat(); gpuSrc1.Upload(cpuSrc1);
        using var gpuSrc2 = new GpuMat(); gpuSrc2.Upload(cpuSrc2);

        GpuMat[] sources = { gpuSrc1, gpuSrc2 };

        // 2. Act: Merge them
        using var gpuDst = new GpuMat();
        Cv2.Cuda.Merge(sources, gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Result should have 2 channels (CV_8UC2)
        Assert.Equal(2, cpuDst.Channels());
        Assert.Equal(MatType.CV_8UC2, cpuDst.Type());

        // Check the values at (0,0)
        // Vec2b represents a 2-byte vector
        Vec2b pixel = cpuDst.At<Vec2b>(0, 0);
        Assert.Equal(10, pixel.Item0); // Channel 1
        Assert.Equal(20, pixel.Item1); // Channel 2
    }
    [Fact]
    public void MinWithScalar_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 1x2 matrix with values 50 and 150
        using var cpuSrc = Mat.FromPixelData(1, 2, MatType.CV_8UC1, new byte[] { 50, 150 });
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Take min with 100
        // Math: min(50, 100) = 50; min(150, 100) = 100
        Cv2.Cuda.Min(gpuSrc, new Scalar(100), gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // index 0: was 50, remains 50 (it was already lower than 100)
        Assert.Equal(50, cpuDst.At<byte>(0, 0));
        // index 1: was 150, capped at 100
        Assert.Equal(100, cpuDst.At<byte>(0, 1));
    }

    [Fact]
    public void MinMaxLoc_DirectTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 image with specific min/max
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));
        cpuSrc.Set<byte>(10, 20, 5);   // Min at (20, 10)
        cpuSrc.Set<byte>(80, 70, 250); // Max at (70, 80)

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // 2. Act
        Cv2.Cuda.MinMaxLoc(gpuSrc, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc);

        // 3. Assert
        Assert.Equal(5.0, minVal);
        Assert.Equal(250.0, maxVal);

        // Note: OpenCV Point is (X, Y) which is (Col, Row)
        Assert.Equal(20, minLoc.X);
        Assert.Equal(10, minLoc.Y);
        Assert.Equal(70, maxLoc.X);
        Assert.Equal(80, maxLoc.Y);
    }

    [Fact]
    public void MinMax_WithMaskTest()
    {
        VerifyCudaSupport();

        // Arrange: 10x10 image filled with 100.
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(100));
        // Add a very small value (10) that we will MASK OUT
        cpuSrc.Set<byte>(0, 0, 10);

        // Create mask: only the bottom-right 5x5 area is active (255)
        using var cpuMask = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpuMask, new Rect(5, 5, 5, 5), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuMask = new GpuMat(); gpuMask.Upload(cpuMask);

        // Act
        Cv2.Cuda.MinMax(gpuSrc, out double minVal, out double maxVal, gpuMask);

        // Assert
        // Even though '10' exists in the image at (0,0), it is masked out.
        // The minimum value in the active 5x5 region is 100.
        Assert.Equal(100, minVal);
        Assert.Equal(100, maxVal);
    }

    [Fact]
    public void MulSpectrums_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 1x1 Complex Matrices (CV_32FC2)
        using var cpu1 = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 1f, 1f }); // 1 + 1i
        using var cpu2 = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 2f, 3f }); // 2 + 3i

        using var gpu1 = new GpuMat(); gpu1.Upload(cpu1);
        using var gpu2 = new GpuMat(); gpu2.Upload(cpu2);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.MulSpectrums(gpu1, gpu2, gpuDst, DftFlags.None);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Vec2f result = cpuDst.At<Vec2f>(0, 0);

        // (1*2 - 1*3) = -1
        Assert.Equal(-1f, result.Item0);
        // (1*3 + 1*2) = 5
        Assert.Equal(5f, result.Item1);
    }

    [Fact]
    public void MulAndScaleSpectrums_Test()
    {
        VerifyCudaSupport();

        // Arrange: (1 + 0i) * (1 + 0i) = 1. Scaled by 0.5 = 0.5
        using var gpu1 = new GpuMat(1, 1, MatType.CV_32FC2, new Scalar(1, 0));
        using var gpu2 = new GpuMat(1, 1, MatType.CV_32FC2, new Scalar(1, 0));

        // Act: scale = 0.5f
        using var gpuDst = new GpuMat();
        Cv2.Cuda.MulAndScaleSpectrums(gpu1, gpu2, gpuDst, DftFlags.None, 0.5f);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        Vec2f result = cpuDst.At<Vec2f>(0, 0);

        Assert.Equal(0.5f, result.Item0);
        Assert.Equal(0f, result.Item1);
    }

    [Fact]
    public void NonLocalMeans_Test()
    {
        VerifyCudaSupport();

        // Arrange: small noisy region instead of single pixel
        using var cpuSrc = new Mat(20, 20, MatType.CV_8UC1, new Scalar(100));
        cpuSrc[new Rect(9, 9, 3, 3)].SetTo(new Scalar(200));

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();

        // Stronger filtering
        Cv2.Cuda.NonLocalMeans(gpuSrc, gpuDst, h: 30.0f, searchWindow: 15, blockSize: 3);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        byte denoisedPixel = cpuDst.At<byte>(10, 10);

        // Now smoothing should occur
        Assert.True(denoisedPixel < 200, $"Value was not reduced. Got: {denoisedPixel}");
    }

    [Fact]
    public void Norm_SingleMatrixTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix filled with 3.0
        using var cpuSrc = new Mat(2, 2, MatType.CV_32FC1, new Scalar(3.0));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Act: Calculate L1 Norm (Sum of absolute values)
        // |3| + |3| + |3| + |3| = 12.0
        double l1Norm = Cv2.Cuda.Norm(gpuSrc, NormTypes.L1 );

        // 3. Act: Calculate L2 Norm (Euclidean)
        // sqrt(3^2 + 3^2 + 3^2 + 3^2) = sqrt(36) = 6.0
        double l2Norm = Cv2.Cuda.Norm(gpuSrc, NormTypes.L2);

        // 4. Assert
        Assert.Equal(12.0, l1Norm);
        Assert.Equal(6.0, l2Norm);
    }

    [Fact]
    public void Norm_DifferenceTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 8-bit matrices
        using var gpuA = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(10));
        using var gpuB = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(7));

        // 2. Act
        double diffNorm = Cv2.Cuda.Norm(gpuA, gpuB, NormTypes.L1);

        // 3. Assert
        // Each pixel diff = 3, total pixels = 25 → 75
        Assert.Equal(75.0, diffNorm);
    }

    [Fact]
    public void Normalize_MinMaxTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x1 matrix with values 10.0 and 20.0
        using var cpuSrc = new Mat(2, 1, MatType.CV_32FC1);
        cpuSrc.Set<float>(0, 0, 10.0f);
        cpuSrc.Set<float>(1, 0, 20.0f);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Normalize to range [0, 255]
        Cv2.Cuda.Normalize(gpuSrc, gpuDst, 0.0, 255.0, NormTypes.MinMax, -1);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        float valMin = cpuDst.At<float>(0, 0);
        float valMax = cpuDst.At<float>(1, 0);

        // 10.0 should have become the new alpha (0)
        Assert.InRange(valMin, -0.01f, 0.01f);
        // 20.0 should have become the new beta (255)
        Assert.InRange(valMax, 254.9f, 255.1f);
    }

    [Fact]
    public void RectStdDev_Test()
    {
        VerifyCudaSupport();

        try
        {
            int rows = 8, cols = 8;

            // FIX 1: use CV_8UC1 (or CV_32FC1)
            using var cpuSrc = new Mat(rows, cols, MatType.CV_8UC1, Scalar.All(4));

            // FIX 2: separate outputs
            using var cpuSum = new Mat();
            using var cpuSqSum = new Mat();

            // tilted not needed → pass null
            Cv2.Integral(cpuSrc, cpuSum, cpuSqSum);

            using var gpuSum = new GpuMat();
            using var gpuSqSum = new GpuMat();

            gpuSum.Upload(cpuSum);
            gpuSqSum.Upload(cpuSqSum);

            using var gpuDst = new GpuMat();

            var rect = new Rect(0, 0, cols, rows);

            Cv2.Cuda.RectStdDev(gpuSum, gpuSqSum, gpuDst, rect);

            using var cpuDst = new Mat();
            gpuDst.Download(cpuDst);

            Assert.False(cpuDst.Empty());

            double stdDev = cpuDst.At<double>(rows / 2, cols / 2);

            // uniform image → stddev ≈ 0
            Assert.InRange(stdDev, -0.01, 0.01);
        }
        catch (OpenCVException ex) when (
            ex.Message.Contains("disabled") ||
            ex.Message.Contains("not implemented"))
        {
            Assert.Skip("CUDA functionality not available");
        }
    }

    [Fact]
    public void Reduce_ToRowSumTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix
        // [1, 2]
        // [3, 4]
        using var cpuSrc = new Mat(2, 2, MatType.CV_32SC1);
        cpuSrc.Set<int>(0, 0, 1);
        cpuSrc.Set<int>(0, 1, 2);
        cpuSrc.Set<int>(1, 0, 3);
        cpuSrc.Set<int>(1, 1, 4);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuVec = new GpuMat();

        // 2. Act: Reduce to single row (dim=0) using Sum
        Cv2.Cuda.Reduce(gpuSrc, gpuVec, dim: 0, reduceOp: ReduceTypes.Sum, dtype: -1);

        // 3. Download and Assert
        using var cpuVec = new Mat();
        gpuVec.Download(cpuVec);

        Assert.False(cpuVec.Empty());
        // Result should be 1x2
        Assert.Equal(1, cpuVec.Rows);
        Assert.Equal(2, cpuVec.Cols);

        // [1+3, 2+4] = [4, 6]
        Assert.Equal(4, cpuVec.At<int>(0, 0));
        Assert.Equal(6, cpuVec.At<int>(0, 1));
    }

    [Fact]
    public void Reduce_ToColMaxTest()
    {
        VerifyCudaSupport();

        // 1. Arrange
        using var cpuSrc = new Mat(2, 2, MatType.CV_32SC1);
        cpuSrc.Set<int>(0, 0, 10);
        cpuSrc.Set<int>(0, 1, 50);
        cpuSrc.Set<int>(1, 0, 100);
        cpuSrc.Set<int>(1, 1, 5);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Act: Reduce to single column (dim=1) using Max
        // Row 0: Max(10, 50) = 50
        // Row 1: Max(100, 5) = 100
        using var gpuVec = new GpuMat();
        Cv2.Cuda.Reduce(gpuSrc, gpuVec, dim: 1, reduceOp: ReduceTypes.Max);

        // 3. Download and Assert
        using var cpuVec = new Mat();
        gpuVec.Download(cpuVec);

        Assert.Equal(2, cpuVec.Rows);
        Assert.Equal(1, cpuVec.Cols);
        Assert.Equal(50, cpuVec.At<int>(0, 0));
        Assert.Equal(100, cpuVec.At<int>(1, 0));
    }
    [Fact]
    public void Split_BGRTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 5x5 BGR image
        // B=10, G=20, R=30
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC3, new Scalar(10, 20, 30));
        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // 2. Act
        int cn = cpuSrc.Channels();
        GpuMat[] channels = new GpuMat[cn];
        Cv2.Cuda.Split(gpuSrc, channels);

        // 3. Assert
        Assert.Equal(3, channels.Length);

        using var b = new Mat();
        using var g = new Mat();
        using var r = new Mat();

        channels[0].Download(b);
        channels[1].Download(g);
        channels[2].Download(r);

        Assert.Equal(10, b.At<byte>(0, 0));
        Assert.Equal(20, g.At<byte>(0, 0));
        Assert.Equal(30, r.At<byte>(0, 0));

        // Cleanup
        foreach (var m in channels) m.Dispose();
    }

    [Fact]
    public void SqrIntegral_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix of 2s. 
        // The squares are all 4s.
        using var cpuSrc = new Mat(2, 2, MatType.CV_8UC1, new Scalar(2));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuSqSum = new GpuMat();

        // 2. Act
        Cv2.Cuda.SqrIntegral(gpuSrc, gpuSqSum);

        // 3. Assert
        using var cpuSqSum = new Mat();
        gpuSqSum.Download(cpuSqSum);

        // Integral size is (W+1)x(H+1) -> 3x3. Type is CV_64F.
        Assert.Equal(3, cpuSqSum.Rows);
        Assert.Equal(MatType.CV_64FC1, cpuSqSum.Type());

        // Bottom-right pixel (2,2) should be sum of squares: (2^2 * 4 pixels) = 16
        double totalSqrSum = cpuSqSum.At<double>(2, 2);
        Assert.Equal(16.0, totalSqrSum);
    }

    [Fact]
    public void SqrSum_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix of 3s.
        // Squares are 9s. Sum of squares should be (9 * 4) = 36.
        using var gpuSrc = new GpuMat(2, 2, MatType.CV_8UC1, new Scalar(3));

        // 2. Act
        Scalar result = Cv2.Cuda.SqrSum(gpuSrc);

        // 3. Assert
        Assert.Equal(36.0, result.Val0);
    }

    [Fact]
    public void Subtract_MatrixScalarTest()
    {
        VerifyCudaSupport();

        // 100 - 40 = 60
        using var gpuSrc = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(100));
        using var gpuDst = new GpuMat();

        Cv2.Cuda.Subtract(gpuSrc, new Scalar(40), gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.Equal(60, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void Sum_BasicTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix filled with 10
        using var gpuSrc = new GpuMat(2, 2, MatType.CV_8UC1, new Scalar(10));

        // 2. Act
        Scalar result = Cv2.Cuda.Sum(gpuSrc);

        // 3. Assert
        // Val0 is the sum of the first channel
        Assert.Equal(40.0, result.Val0);
    }

    [Fact]
    public void Sum_WithMaskTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 2x2 matrix filled with 10
        using var gpuSrc = new GpuMat(2, 2, MatType.CV_8UC1, new Scalar(10));

        // 2. Create Mask: only one pixel is active (255)
        using var cpuMask = new Mat(2, 2, MatType.CV_8UC1, new Scalar(0));
        cpuMask.Set<byte>(0, 0, 255);
        using var gpuMask = new GpuMat();
        gpuMask.Upload(cpuMask);

        // 3. Act
        Scalar result = Cv2.Cuda.Sum(gpuSrc, gpuMask);

        // 4. Assert
        // Only the one active pixel (10) should be summed
        Assert.Equal(10.0, result.Val0);
    }

    [Fact]
    public void Multiply_MatrixScalarTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 5x5 matrix filled with 10
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(10));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Multiply by 5 (result = 10 * 5 = 50)
        Cv2.Cuda.Multiply(gpuSrc, new Scalar(5), gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(50, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void Multiply_WithScaleTest()
    {
        VerifyCudaSupport();

        // Arrange: 10 * 10 with a scale of 0.1
        // Math: (10 * 10) * 0.1 = 10
        using var gpuSrc = new GpuMat(1, 1, MatType.CV_32FC1, new Scalar(10));

        // Act
        using var gpuDst = new GpuMat();
        Cv2.Cuda.Multiply(gpuSrc,  new Scalar(10), gpuDst, scale: 0.1);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.Equal(10.0f, cpuDst.At<float>(0, 0));
    }

}
