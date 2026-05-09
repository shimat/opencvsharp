using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaFiltersTest : CudaTestBase
{
    [Fact]
    public void CreateBoxFilterTest()
    {
        VerifyCudaSupport();

        // Arrange: 5x5 Matrix of zeros, with a single '90' in the very center.
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(2, 2, 90);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: 3x3 average filter
        using var filter = OpenCvSharp.Cuda.Filter.CreateBoxFilter(MatType.CV_8UC1, MatType.CV_8UC1, new Size(3, 3));
        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // A 3x3 box average of a single '90' pixel surrounded by zeros = 90 / 9 = 10.
        // The center 3x3 grid should now all be 10.
        Assert.Equal(10, cpuDst.At<byte>(2, 2)); // Center
        Assert.Equal(10, cpuDst.At<byte>(1, 1)); // Top Left of the 3x3 area

        // Pixels outside the 3x3 reach should still be 0
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void CreateBoxMaxFilter()
    {
        VerifyCudaSupport();

        // Arrange: 5x5 Matrix of zeros, with a single '100' in the center.
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(2, 2, 100);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: 3x3 Max filter
        using var filter = OpenCvSharp.Cuda.Filter.CreateBoxMaxFilter(MatType.CV_8UC1, new Size(3, 3));
        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // The max filter expands the brightest pixel. The center '100' should expand to a 3x3 square.
        Assert.Equal(100, cpuDst.At<byte>(2, 2)); // Center
        Assert.Equal(100, cpuDst.At<byte>(1, 1)); // Top Left of the 3x3 area

        // Pixels outside the 3x3 reach should still be 0
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void CreateBoxMinFilter()
    {
        VerifyCudaSupport();

        // Arrange: 5x5 Matrix of 255s, with a single '0' in the center.
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(255));
        cpuSrc.Set<byte>(2, 2, 0);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: 3x3 Min filter
        using var filter = OpenCvSharp.Cuda.Filter.CreateBoxMinFilter(MatType.CV_8UC1, new Size(3, 3));
        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        // The min filter expands the darkest pixel. The center '0' should expand to a 3x3 square.
        Assert.Equal(0, cpuDst.At<byte>(2, 2)); // Center
        Assert.Equal(0, cpuDst.At<byte>(1, 1)); // Top Left of the 3x3 area

        // Pixels outside the 3x3 reach should still be 255
        Assert.Equal(255, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void CreateColumnSumFilter()
    {
        VerifyCudaSupport();

        // Arrange: 3x3 Matrix filled with 1s
        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(1));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: Create a vertical filter of size 3. 
        // We output to CV_32SC1 (32-bit Int) to handle the sum results.
        using var filter = OpenCvSharp.Cuda.Filter.CreateColumnSumFilter(
            MatType.CV_8UC1,
            MatType.CV_32FC1,
            ksize: 3);

        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC1, cpuDst.Type());

        float resultValue = cpuDst.At<float>(1, 1);
        Assert.InRange(resultValue, 2.9f, 3.1f);
    }

    [Fact]
    public void CreateDerivFilter()
    {
        VerifyCudaSupport();

        // Arrange: Create a 10x10 gradient image
        // Row 0: [0, 10, 20, 30, 40, ...]
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1);
        for (int x = 0; x < 10; x++)
        {
            using var col = cpuSrc.Col(x);
            col.SetTo(new Scalar(x * 10));
        }

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: First derivative in X direction (dx=1, dy=0)
        // Aperture size 3, normalized.
        // Using CV_32F output to handle precision.
        using var filter = OpenCvSharp.Cuda.Filter.CreateDerivFilter(
            MatType.CV_8UC1,
            MatType.CV_32FC1,
            dx: 1, dy: 0, ksize: 3,
            normalize: true);

        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Because the gradient is 10 units per pixel, 
        // the first derivative (slope) should be 10.
        // We check a center pixel (to avoid border effects).
        float derivativeValue = cpuDst.At<float>(5, 5);

        // Allow small float tolerance
        Assert.InRange(derivativeValue, 9.9f, 10.1f);
    }

    [Fact]
    public void CreateGaussianFilter()
    {
        VerifyCudaSupport();

        // Arrange: 10x10 black image with one white pixel in the center (5,5)
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(5, 5, 255);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Create Gaussian Filter: 3x3 kernel, sigma = 1.0
        using var filter = OpenCvSharp.Cuda.Filter.CreateGaussianFilter(
            MatType.CV_8UC1,
            MatType.CV_8UC1,
            new Size(3, 3),
            sigma1: 1.0);

        // Act
        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The center pixel should now be less than 255 because energy spread to neighbors
        byte centerVal = cpuDst.At<byte>(5, 5);
        Assert.True(centerVal < 255);
        Assert.True(centerVal > 0);

        // A neighbor pixel (5, 4) should now be non-zero
        byte neighborVal = cpuDst.At<byte>(5, 4);
        Assert.True(neighborVal > 0);
    }


    [Fact]
    public void CreateLaplacianFilter_ApplyTest()
    {
        VerifyCudaSupport();

        // Arrange: 10x10 black image with a 4x4 white square in the middle
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpuSrc, new Rect(3, 3, 4, 4), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Convert to float
        using var gpuSrc32F = new GpuMat();
        gpuSrc.ConvertTo(gpuSrc32F, MatType.CV_32FC1);

        using var gpuDst = new GpuMat();

        using var filter = OpenCvSharp.Cuda.Filter.CreateLaplacianFilter(
            MatType.CV_32FC1,
            MatType.CV_32FC1,
            ksize: 1);

        filter.Apply(gpuSrc32F, gpuDst);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC1, cpuDst.Type());

        // Background
        Assert.Equal(0f, cpuDst.At<float>(0, 0));

        // Edge (correct location)
        float edgeResponse = cpuDst.At<float>(3, 2);
        Assert.NotEqual(0f, edgeResponse);
    }

    [Fact]
    public void CreateLinearFilter_ApplyTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 5x5 black image with one white pixel at (1, 1)
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(1, 1, 255);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Define a "Shift Right" kernel
        // [0, 0, 0]
        // [1, 0, 0]  <- The '1' is at (-1, 0) relative to center
        // [0, 0, 0]
        // This kernel will move the pixel at (1,1) to (2,1)
        float[] kData = { 0, 0, 0,
                              1, 0, 0,
                              0, 0, 0 };
        using Mat kernel = Mat.FromPixelData(3, 3, MatType.CV_32FC1, kData);

        // 3. Act
        using var filter = OpenCvSharp.Cuda.Filter.CreateLinearFilter(MatType.CV_8UC1, MatType.CV_8UC1, kernel);
        filter.Apply(gpuSrc, gpuDst);

        // 4. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The original pixel was at (1, 1). 
        // Our custom "Shift Right" kernel moved it to (2, 1).
        Assert.Equal(0, cpuDst.At<byte>(1, 1));
        Assert.Equal(255, cpuDst.At<byte>(1, 2)); // (Row 1, Col 2)
    }

    [Fact]
    public void CreateMedianFilter_ApplyTest()
    {
        VerifyCudaSupport();
        // 1. Arrange: 5x5 black image with one white "noise" pixel at (2, 2)
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(2, 2, 255);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Create 3x3 Median Filter
        using var filter = OpenCvSharp.Cuda.Filter.CreateMedianFilter(MatType.CV_8UC1, windowSize: 3);
        filter.Apply(gpuSrc, gpuDst);

        // 3. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The noise pixel at (2, 2) should have been removed by the median logic
        // because in its 3x3 neighborhood, 8 pixels are '0' and only 1 is '255'.
        // The median of {0,0,0,0,0,0,0,0,255} is 0.
        Assert.Equal(0, cpuDst.At<byte>(2, 2));

        // Verify the whole image is now black
        Scalar sum = Cv2.Sum(cpuDst);
        Assert.Equal(0, sum.Val0);
    }

    [Fact]
    public void CreateMorphologyFilter_DilateTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 5x5 black image with one white pixel at (2, 2)
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(2, 2, 255);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Create a 3x3 rectangular structuring element (kernel)
        using var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));

        // 3. Act: Create and apply Dilation filter
        using var filter = OpenCvSharp.Cuda.Filter.CreateMorphologyFilter(
            MorphTypes.Dilate,
            MatType.CV_8UC1,
            kernel);

        filter.Apply(gpuSrc, gpuDst);

        // 4. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The single pixel at (2,2) should have dilated into a 3x3 square.
        // Center is (2,2). Range is (1,1) to (3,3).
        Assert.Equal(255, cpuDst.At<byte>(2, 2)); // Center
        Assert.Equal(255, cpuDst.At<byte>(1, 1)); // Top-Left of the dilated area
        Assert.Equal(255, cpuDst.At<byte>(3, 3)); // Bottom-Right of the dilated area

        // Pixel at (0,0) should still be 0
        Assert.Equal(0, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void CreateRowSumFilter_ApplyTest()
    {
        VerifyCudaSupport();

        // Arrange: 3x3 Matrix filled with 1s
        using var cpuSrc = new Mat(3, 3, MatType.CV_8UC1, new Scalar(1));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: Create a horizontal filter of size 3. 
        // We output to CV_32SC1 (32-bit Int) to handle the sum results.
        using var filter = OpenCvSharp.Cuda.Filter.CreateRowSumFilter(
             MatType.CV_8UC1,
             MatType.CV_32FC1,  
             ksize: 3);

        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC1, cpuDst.Type());

        // The middle pixel (1, 1) result should be the sum of (1,0), (1,1), and (1,2).
        // 1 + 1 + 1 = 3
        float resultValue = cpuDst.At<float>(1, 1);
        Assert.Equal(3f, resultValue);
    }

    [Fact]
    public void CreateScharrFilter_ApplyTest()
    {
        VerifyCudaSupport();

        // Arrange: 10x10 image with a vertical edge
        // Left (0-4) = 0, Right (5-9) = 255
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpuSrc, new Rect(5, 0, 5, 10), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: Scharr X-derivative. 
        // Using CV_32F to capture the gradient magnitude.
        using var filter = OpenCvSharp.Cuda.Filter.CreateScharrFilter(
            MatType.CV_8UC1,
            MatType.CV_32FC1,
            dx: 1, dy: 0);

        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The gradient at the edge (column 5) should be very high.
        float edgeGradient = cpuDst.At<float>(5, 5);
        Assert.True(edgeGradient > 0);

        // The gradient in a flat area (column 0 or column 9) should be 0.
        float flatGradient = cpuDst.At<float>(5, 0);
        Assert.Equal(0, flatGradient);
    }

    [Fact]
    public void CreateSeparableLinearFilter_ApplyTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 5x5 black image with one white pixel at (2, 2)
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(2, 2, 90);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Define 1D kernels for a 3x3 average blur (90 / 9 = 10)
        float[] kData = { 0.3333f, 0.3333f, 0.3333f };
        using var rowKernel = Mat.FromPixelData(1, 3, MatType.CV_32FC1, kData);
        using var colKernel = Mat.FromPixelData(1, 3, MatType.CV_32FC1, kData);

        // 3. Act
        using var filter = OpenCvSharp.Cuda.Filter.CreateSeparableLinearFilter(
            MatType.CV_8UC1, MatType.CV_8UC1, rowKernel, colKernel);

        filter.Apply(gpuSrc, gpuDst);

        // 4. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The original '90' should be spread over a 3x3 area.
        // 90 * (1/3) * (1/3) = 10.
        byte resultVal = cpuDst.At<byte>(2, 2);
        Assert.InRange(resultVal, 9, 11);

        Assert.Equal(resultVal, cpuDst.At<byte>(1, 1));
    }

    [Fact]
    public void CreateSobelFilter_ApplyTest()
    {
        VerifyCudaSupport();

        // Arrange: 10x10 image with a vertical edge
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        // Fill right half with 255
        Cv2.Rectangle(cpuSrc, new Rect(5, 0, 5, 10), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // Act: Sobel X-derivative (detects vertical edges)
        using var filter = OpenCvSharp.Cuda.Filter.CreateSobelFilter(
            MatType.CV_8UC1,
            MatType.CV_32FC1,
            dx: 1, dy: 0, ksize: 3);

        filter.Apply(gpuSrc, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // The gradient at the edge (column 5) should be positive
        float edgeValue = cpuDst.At<float>(5, 5);
        Assert.True(edgeValue > 0);

        // The gradient in the flat area (column 0) should be 0
        float flatValue = cpuDst.At<float>(5, 0);
        Assert.Equal(0f, flatValue);
    }
}

