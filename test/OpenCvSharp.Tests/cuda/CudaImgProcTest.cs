using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaImgProcTest : CudaTestBase
{
    [Fact]
    public void AlphaCompTest()
    {
        VerifyCudaSupport();

        // AlphaComp REQUIRES 4-channel images (RGBA/BGRA) (CV_8UC4 or CV_16UC4 or CV_32FC4)
        // Foreground: value 100 on first channel, 255 alpha (fully opaque)
        using var cpuImg1 = new Mat(2, 2, MatType.CV_8UC4, new Scalar(100, 0, 0, 255));
        // Background: value 50 on first channel, 255 alpha
        using var cpuImg2 = new Mat(2, 2, MatType.CV_8UC4, new Scalar(50, 0, 0, 255));

        using var gpuImg1 = new GpuMat();
        using var gpuImg2 = new GpuMat();
        gpuImg1.Upload(cpuImg1);
        gpuImg2.Upload(cpuImg2);

        // Act: Place Foreground OVER Background
        using var gpuDst = new GpuMat();
        Cv2.Cuda.AlphaComp(gpuImg1, gpuImg2, gpuDst, AlphaCompTypes.Over);

        // Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_8UC4, cpuDst.Type());

        // Because the foreground was fully opaque (alpha=255), ALPHA_OVER 
        // should result in the exact foreground image.
        Vec4b pixel = cpuDst.At<Vec4b>(0, 0);
        Assert.Equal(100, pixel.Item0); // First channel
        Assert.Equal(255, pixel.Item3); // Alpha channel
    }

    [Fact]
    public void BilateralFilterTest()
    {
        VerifyCudaSupport();

        // Bilateral Filter usually operates on CV_8UC1 or CV_8UC3
        // Create a completely flat, gray image.
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // Act
        using var gpuDst = new GpuMat();
        Cv2.Cuda.BilateralFilter(
            gpuSrc, gpuDst,
            kernelSize: 5,
            sigmaColor: 50.0f,
            sigmaSpatial: 50.0f);

        // Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(cpuSrc.Rows, cpuDst.Rows);
        Assert.Equal(cpuSrc.Cols, cpuDst.Cols);
        Assert.Equal(MatType.CV_8UC1, cpuDst.Type());

        // Since the input image was a solid color, filtering it should do absolutely 
        // nothing to the color. It should remain 128.
        Assert.Equal(128, cpuDst.At<byte>(5, 5));
    }

    [Fact]
    public void BlendLinearTest()
    {
        VerifyCudaSupport();

        // Arrange: 
        using var cpuImg1 = new Mat(5, 5, MatType.CV_8UC1, new Scalar(100));
        using var cpuImg2 = new Mat(5, 5, MatType.CV_8UC1, new Scalar(50));

        using var cpuW1 = new Mat(5, 5, MatType.CV_32FC1, new Scalar(0.8f));
        using var cpuW2 = new Mat(5, 5, MatType.CV_32FC1, new Scalar(0.2f));

        using var gpuImg1 = new GpuMat(); gpuImg1.Upload(cpuImg1);
        using var gpuImg2 = new GpuMat(); gpuImg2.Upload(cpuImg2);
        using var gpuW1 = new GpuMat(); gpuW1.Upload(cpuW1);
        using var gpuW2 = new GpuMat(); gpuW2.Upload(cpuW2);
        using var gpuDst = new GpuMat();

        // Act
        Cv2.Cuda.BlendLinear(gpuImg1, gpuImg2, gpuW1, gpuW2, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // We expect ~90, but GPU Fused-Multiply-Add (FMA) might truncate it to 89.
        // We allow a tolerance of +/- 1.
        byte pixelValue = cpuDst.At<byte>(0, 0);
        Assert.InRange(pixelValue, 89, 91);
    }

    [Fact]
    public void CvtColor_BGR2GRAYTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 3-channel BGR image (10x10)
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC3, new Scalar(255, 0, 0)); // Pure Blue
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Convert BGR to Gray
        Cv2.Cuda.CvtColor(gpuSrc, gpuDst, ColorConversionCodes.BGR2GRAY);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Source was 3 channels, destination should be 1 channel
        Assert.Equal(3, cpuSrc.Channels());
        Assert.Equal(1, cpuDst.Channels());

        // Check that it's no longer zero
        Assert.NotEqual(0, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void Demosaicing_BayerRG2BGRTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 4x4 Bayer RG pattern
        // A very simple pattern where we set 'Red' and 'Blue' pixels
        using var cpuSrc = new Mat(4, 4, MatType.CV_8UC1, new Scalar(0));
        cpuSrc.Set<byte>(0, 0, 255); // Top-left is Red in BayerRG

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Convert Bayer RG to BGR (3 channels)
        Cv2.Cuda.Demosaicing(gpuSrc, gpuDst, ColorConversionCodes.BayerRG2BGR);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Result should have 3 channels (BGR)
        Assert.Equal(3, cpuDst.Channels());

        // In BayerRG2BGR, the pixel at (0,0) in the source affects the 'Red' channel 
        // of the output at (0,0). BGR Vec3b: Item0=B, Item1=G, Item2=R.
        Vec3b pixel = cpuDst.At<Vec3b>(0, 0);
        Assert.True(pixel.Item2 > 0, "Red channel should have been interpolated.");
    }

    [Fact]
    public void EqualizeHist_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 dark gray image (Value = 50)
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1);

        for (int y = 0; y < 100; y++)
        {
            for (int x = 0; x < 100; x++)
            {
                cpuSrc.Set<byte>(y, x, (byte)(x));
            }
        }


        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.EqualizeHist(gpuSrc, gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(cpuSrc.Size(), cpuDst.Size());
        Assert.Equal(MatType.CV_8UC1, cpuDst.Type());

        double minVal, maxVal;
        Cv2.MinMaxLoc(cpuDst, out minVal, out maxVal);

        Assert.True(maxVal - minVal > 0);
    }

    [Fact]
    public void EvenLevels_Test()
    {
        VerifyCudaSupport();

        // 1. Act: Create 5 levels from 0 to 100
        using var gpuLevels = new GpuMat();
        Cv2.Cuda.EvenLevels(gpuLevels,nLevels: 5, lowerLevel: 0, upperLevel: 100);
        // 2. Download and Assert
        using var cpuLevels = new Mat();
        gpuLevels.Download(cpuLevels);

        Assert.False(cpuLevels.Empty());

        // evenLevels outputs a 1D matrix of 32-bit integers (CV_32SC1)
        Assert.Equal(MatType.CV_32SC1, cpuLevels.Type());
        Assert.Equal(5, cpuLevels.Cols * cpuLevels.Rows);

        // Verify the linear distribution
        // (100 - 0) / (5 - 1) = 25 step size
        Assert.Equal(0, cpuLevels.At<int>(0, 0));
        Assert.Equal(25, cpuLevels.At<int>(0, 1));
        Assert.Equal(50, cpuLevels.At<int>(0, 2));
        Assert.Equal(75, cpuLevels.At<int>(0, 3));
        Assert.Equal(100, cpuLevels.At<int>(0, 4));
    }

    [Fact]
    public void HistEven_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 10x10 image (100 pixels total)
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        // Set 50 pixels to value '50'
        cpuSrc[0, 5, 0, 10].SetTo(new Scalar(50));
        // Set 50 pixels to value '150'
        cpuSrc[5, 10, 0, 10].SetTo(new Scalar(150));

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuHist = new GpuMat();

        // 2. Act: Calculate histogram with 2 bins across 0-200
        // Bin 1: 0 to 100 (should contain the '50's)
        // Bin 2: 100 to 200 (should contain the '150's)
        Cv2.Cuda.HistEven(gpuSrc, gpuHist, histSize: 2, lowerLevel: 0, upperLevel: 200);

        // 3. Download and Assert
        using var cpuHist = new Mat();
        gpuHist.Download(cpuHist);

        Assert.False(cpuHist.Empty());

        // Histogram should be 1x2 or 2x1 (CV_32SC1)
        Assert.Equal(MatType.CV_32SC1, cpuHist.Type());

        // Check the counts in the bins
        int bin1Count = cpuHist.At<int>(0, 0);
        int bin2Count = cpuHist.At<int>(0, 1);

        Assert.Equal(50, bin1Count);
        Assert.Equal(50, bin2Count);
    }

    [Fact]
    public void HistEven_MultiChannelTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 10x10 2-channel image (CV_8UC2)
        // Channel 0 (Blue): all 50
        // Channel 1 (Green): all 150
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC4, new Scalar(50, 150));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Must prepare 4 GpuMats even if we only have 2 channels
        GpuMat[] hists = { new GpuMat(), new GpuMat(), new GpuMat(), new GpuMat() };
        int[] sizes = { 1, 1, 1, 1 };
        int[] lowers = { 0, 0, 0, 0 };
        int[] uppers = { 255, 255, 255, 255 };

        // 2. Act
        Cv2.Cuda.HistEven(gpuSrc, hists, sizes, lowers, uppers);

        // 3. Download and Assert
        using var cpuHist0 = new Mat();
        using var cpuHist1 = new Mat();
        hists[0].Download(cpuHist0);
        hists[1].Download(cpuHist1);

        // 100 pixels in channel 0 had value 50 (which falls into our single bin)
        Assert.Equal(100, cpuHist0.At<int>(0, 0));
        // 100 pixels in channel 1 had value 150 (which falls into our single bin)
        Assert.Equal(100, cpuHist1.At<int>(0, 0));

        // Cleanup
        foreach (var h in hists) h.Dispose();
    }

    [Fact]
    public void HistRange_SingleChannelTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 10x10 image filled with 150
        using var cpuSrc = new Mat(10, 10, MatType.CV_8UC1, new Scalar(150));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Define custom levels: [0, 100, 255] -> creates 2 bins
        using var cpuLevels =Mat.FromPixelData(1, 3, MatType.CV_32SC1, new int[] { 0, 100, 255 });
        using var gpuLevels = new GpuMat(); gpuLevels.Upload(cpuLevels);
        using var gpuHist = new GpuMat();

        // 3. Act
        Cv2.Cuda.HistRange(gpuSrc, gpuHist, gpuLevels);

        // 4. Assert
        using var cpuHist = new Mat();
        gpuHist.Download(cpuHist);

        // Bin 0 (0-100) should be 0
        Assert.Equal(0, cpuHist.At<int>(0, 0));
        // Bin 1 (100-255) should be 100
        Assert.Equal(100, cpuHist.At<int>(0, 1));
    }

    [Fact]
    public void MeanShiftFiltering_Test()
    {
        VerifyCudaSupport();

        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC4, new Scalar(255, 0, 0));

        // Correct region assignment
        cpuSrc[new Rect(50, 0, 50, 100)].SetTo(new Scalar(250, 5, 5));

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        using var gpuDst = new GpuMat();

        // Stronger parameters
        Cv2.Cuda.MeanShiftFiltering(gpuSrc, gpuDst, sp: 50, sr: 20);

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        Vec4b left = cpuDst.At<Vec4b>(50, 10);
        Vec4b right = cpuDst.At<Vec4b>(50, 90);

        int diff = Math.Abs(left.Item0 - right.Item0);

        // Relaxed threshold
        Assert.True(diff < 10, $"Colors did not sufficiently merge. Difference was {diff}");
    }

    [Fact]
    public void MeanShiftProc_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: BGR → BGRA
        using var bgr = new Mat(50, 50, MatType.CV_8UC3, new Scalar(100, 100, 100));
        using var cpuSrc = new Mat();
        Cv2.CvtColor(bgr, cpuSrc, ColorConversionCodes.BGR2BGRA);

        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // 2. Act
        using var gpuColor = new GpuMat();
        using var gpuSpatial = new GpuMat();

        Cv2.Cuda.MeanShiftProc(gpuSrc, gpuColor, gpuSpatial, sp: 5, sr: 5);

        // 3. Assert
        Assert.False(gpuColor.Empty());
        Assert.False(gpuSpatial.Empty());

        // Color output keeps same type
        Assert.Equal(MatType.CV_8UC4, gpuColor.Type());
        Assert.Equal(50, gpuColor.Rows);

        // Spatial output: 2 channels (x, y)
        Assert.Equal(2, gpuSpatial.Channels());
    }

    [Fact]
    public void MeanShiftSegmentation_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 BGR image (Value 100, 100, 100)
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC4, new Scalar(100, 100, 100));

        // Draw a tiny 3x3 square (9 pixels total) with a different color
        Cv2.Rectangle(cpuSrc, new Rect(50, 50, 3, 3), new Scalar(200, 200, 200), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Set minsize to 20. 
        // Since our square is only 9 pixels, it should be merged into the background.
        Cv2.Cuda.MeanShiftSegmentation(gpuSrc, gpuDst, sp: 10, sr: 10, minsize: 20);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Check pixel where the square used to be
        Vec3b squareAreaPixel = cpuDst.At<Vec3b>(51, 51);
        Vec3b backgroundPixel = cpuDst.At<Vec3b>(10, 10);

        // Because minsize (20) > square size (9), they should have merged into the same color
        Assert.Equal(backgroundPixel.Item0, squareAreaPixel.Item0);
        Assert.Equal(backgroundPixel.Item1, squareAreaPixel.Item1);
        Assert.Equal(backgroundPixel.Item2, squareAreaPixel.Item2);
    }

    [Fact]
    public void SwapChannels_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 4-channel BGRA image
        // Blue=10, Green=20, Red=30, Alpha=255
        using var cpuSrc = new Mat(5, 5, MatType.CV_8UC4, new Scalar(10, 20, 30, 255));
        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuSrc);

        // New order: Index 2 becomes 0, 1 stays 1, 0 becomes 2, 3 stays 3
        // This effectively swaps Blue (0) and Red (2)
        int[] dstOrder = { 2, 1, 0, 3 };

        // 2. Act
        Cv2.Cuda.SwapChannels(gpuSrc, dstOrder);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuSrc.Download(cpuDst);

        Vec4b pixel = cpuDst.At<Vec4b>(0, 0);

        // New Blue (Item0) should be old Red (30)
        Assert.Equal(30, pixel.Item0);
        // Green (Item1) should stay 20
        Assert.Equal(20, pixel.Item1);
        // New Red (Item2) should be old Blue (10)
        Assert.Equal(10, pixel.Item2);
        // Alpha stays 255
        Assert.Equal(255, pixel.Item3);
    }

    [Fact]
    public void Transpose_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 2x3 matrix
        // [ 1, 2, 3 ]
        // [ 4, 5, 6 ]
        using var cpuSrc = new Mat(2, 3, MatType.CV_8UC1);
        cpuSrc.Set<byte>(0, 0, 1); cpuSrc.Set<byte>(0, 1, 2); cpuSrc.Set<byte>(0, 2, 3);
        cpuSrc.Set<byte>(1, 0, 4); cpuSrc.Set<byte>(1, 1, 5); cpuSrc.Set<byte>(1, 2, 6);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.Transpose(gpuSrc, gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        // Dimensions should be swapped
        Assert.Equal(3, cpuDst.Rows); // Old Cols
        Assert.Equal(2, cpuDst.Cols); // Old Rows

        // Content should be swapped: dst[col, row] = src[row, col]
        // New Matrix:
        // [ 1, 4 ]
        // [ 2, 5 ]
        // [ 3, 6 ]
        Assert.Equal(1, cpuDst.At<byte>(0, 0));
        Assert.Equal(4, cpuDst.At<byte>(0, 1));
        Assert.Equal(2, cpuDst.At<byte>(1, 0));
        Assert.Equal(6, cpuDst.At<byte>(2, 1));
    }

    [Fact]
    public void ConnectedComponents_AlgorithmTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create two separate blobs
        using var cpuSrc = new Mat(20, 20, MatType.CV_8UC1, new Scalar(0));
        // Blob 1
        Cv2.Rectangle(cpuSrc, new Rect(2, 2, 4, 4), new Scalar(255), -1);
        // Blob 2
        Cv2.Rectangle(cpuSrc, new Rect(10, 10, 4, 4), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Act: Test with SAUF algorithm explicitly
        using var gpuLabels = new GpuMat();
        Cv2.Cuda.ConnectedComponents(
            gpuSrc, gpuLabels,
            connectivity: 8,
            ltype: MatType.CV_32S,
            ccltype: OpenCvSharp.Cuda.ConnectedComponentsAlgorithmsTypes.Default);

        // 3. Assert
        using var cpuLabels = new Mat();
        gpuLabels.Download(cpuLabels);

        Assert.False(cpuLabels.Empty());

        // Background should be 0
        Assert.Equal(0, cpuLabels.At<int>(0, 0));

        // Blobs should have unique non-zero IDs
        int id1 = cpuLabels.At<int>(3, 3);
        int id2 = cpuLabels.At<int>(12, 12);

        Assert.True(id1 > 0);
        Assert.True(id2 > 0);
        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void Moments_AccuracyTest()
    {
        // Skip if no CUDA device is available
        VerifyCudaSupport();

        // 1. Arrange
        Size size = new Size(256, 256);
        bool isBinary = true;
        MatType momentsType = MatType.CV_64F; // Double precision
        MomentsOrder order = MomentsOrder.ThirdOrder;

        // Create a black image and draw a filled white circle
        // Circle at center (128, 128) with radius 60
        using var cpuImg = new Mat(size, MatType.CV_8UC1, new Scalar(0));
        Point centerPoint = new Point(size.Width / 2, size.Height / 2);
        int radius = 60;
        Cv2.Circle(cpuImg, centerPoint, radius, new Scalar(255), -1, LineTypes.AntiAlias);

        using var gpuImg = new GpuMat();
        gpuImg.Upload(cpuImg);

        // 2. Act: Calculate CUDA Moments
        // We follow the C++ test pattern: set binaryImage=true to treat non-zero pixels as 1
        Moments cudaM = Cv2.Cuda.Moments(gpuImg, isBinary, order, momentsType);

        // 3. Act: Calculate CPU Moments for reference
        // For binary comparison, we must ensure the CPU sees 0s and 1s
        using var binaryCpuImg = new Mat();
        Cv2.Threshold(cpuImg, binaryCpuImg, 1, 1, ThresholdTypes.Binary);
        Moments cpuM = Cv2.Moments(binaryCpuImg, binaryImage: true);

        // 4. Assert: Compare results
        // Tolerance: CV_64F should be very precise. We use 1e-6 as a safety margin.
        double epsilon = 1e-6;

        // Compare Spatial Moments (m00, m10, m01)
        Assert.InRange(cudaM.M00, cpuM.M00 - (cpuM.M00 * epsilon), cpuM.M00 + (cpuM.M00 * epsilon));
        Assert.InRange(cudaM.M10, cpuM.M10 - (cpuM.M10 * epsilon), cpuM.M10 + (cpuM.M10 * epsilon));
        Assert.InRange(cudaM.M01, cpuM.M01 - (cpuM.M01 * epsilon), cpuM.M01 + (cpuM.M01 * epsilon));

        // Compare Central Moments (mu20, mu11, mu02)
        if (order >= MomentsOrder.SecondOrder)
        {
            Assert.InRange(cudaM.Mu20, cpuM.Mu20 - (cpuM.Mu20 * epsilon), cpuM.Mu20 + (cpuM.Mu20 * epsilon));
            Assert.InRange(cudaM.Mu11, cpuM.Mu11 - (Math.Abs(cpuM.Mu11) * epsilon) - epsilon, cpuM.Mu11 + (Math.Abs(cpuM.Mu11) * epsilon) + epsilon);
            Assert.InRange(cudaM.Mu02, cpuM.Mu02 - (cpuM.Mu02 * epsilon), cpuM.Mu02 + (cpuM.Mu02 * epsilon));
        }

        // 5. Verify the Centroid (Derived from moments)
        // Centroid should be exactly at the center of the image (128, 128)
        double calculatedX = cudaM.M10 / cudaM.M00;
        double calculatedY = cudaM.M01 / cudaM.M00;

        Assert.InRange(calculatedX, 127.9, 128.1);
        Assert.InRange(calculatedY, 127.9, 128.1);
    }


    [Fact]
    public void NumMoments_OrderTest()
    {
        // Act
        int order1Count = Cv2.Cuda.NumMoments(MomentsOrder.FirstOrder);
        int order2Count = Cv2.Cuda.NumMoments(MomentsOrder.SecondOrder);
        int order3Count = Cv2.Cuda.NumMoments(MomentsOrder.ThirdOrder);

        // Assert
        // These are fixed mathematical constants in the OpenCV implementation
        Assert.Equal(3, order1Count);
        Assert.Equal(6, order2Count);
        Assert.Equal(10, order3Count);
    }

    [Fact]
    public void SpatialMoments_Async_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 black image with a 10x10 white square 
        // Square area is 100 pixels.
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpuSrc, new Rect(10, 10, 10, 10), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuRawMoments = new GpuMat();

        // 2. Act
        Cv2.Cuda.SpatialMoments(gpuSrc, gpuRawMoments, binaryImage: true, order: MomentsOrder.FirstOrder);

        // 3. Download raw results
        using var cpuRawMoments = new Mat();
        gpuRawMoments.Download(cpuRawMoments);

        // 4. Convert raw buffer to Moments struct to verify
        Moments m = Cv2.Cuda.ConvertSpatialMoments(cpuRawMoments, MomentsOrder.FirstOrder, MatType.CV_64F);

        // Area (m00) should be 100
        Assert.Equal(100.0, m.M00);

        // Centroid for a square from (10,10) to (20,20) is (15,15)
        double centerX = m.M10 / m.M00;
        double centerY = m.M01 / m.M00;

        Assert.InRange(centerX, 14.1, 15.1);
        Assert.InRange(centerY, 14.1, 15.1);
    }
}



