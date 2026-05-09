using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenCvSharp.Cuda;

namespace OpenCvSharp.Tests.Cuda;

public class GpuMatTest : CudaTestBase
{
    [Fact]
    public void GpuMatUploadAndDownloadTest()
    {
        VerifyCudaSupport();

        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));

        using var gpuMat = new GpuMat();
        gpuMat.Upload(cpuSrc);

        Assert.False(gpuMat.Empty());
        Assert.Equal(cpuSrc.Rows, gpuMat.Rows);
        Assert.Equal(cpuSrc.Cols, gpuMat.Cols);

        using var cpuDst = new Mat();
        gpuMat.Download(cpuDst);

        ImageEquals(cpuSrc, cpuDst);
    }

    [Fact]
    public void EmptyConstructor()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat();
        Assert.True(gpuMat.Empty());
        Assert.Equal(0, gpuMat.Rows);
        Assert.Equal(0, gpuMat.Cols);
    }

    [Fact]
    public void SizeAndTypeConstructor()
    {
        VerifyCudaSupport();

        int rows = 10;
        int cols = 20;
        using var gpuMat = new GpuMat(rows, cols, MatType.CV_8UC3);

        Assert.False(gpuMat.Empty());
        Assert.Equal(rows, gpuMat.Rows);
        Assert.Equal(cols, gpuMat.Cols);
        Assert.Equal(MatType.CV_8UC3, gpuMat.Type());
        Assert.Equal(3, gpuMat.Channels());
        //Assert.True(gpuMat.IsContinuous());
    }

    [Fact]
    public void ScalarConstructor()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(42));
        using var hostMat = new Mat();

        // Download to host to safely verify values
        gpuMat.Download(hostMat);

        Assert.Equal(42, hostMat.At<byte>(0, 0));
        Assert.Equal(42, hostMat.At<byte>(4, 4));
    }

    [Fact]
    public void UploadDownload()
    {
        VerifyCudaSupport();

        using var hostMat = new Mat(15, 15, MatType.CV_32FC1, new Scalar(3.14f));
        using var gpuMat = new GpuMat();

        // Upload
        gpuMat.Upload(hostMat);
        Assert.False(gpuMat.Empty());
        Assert.Equal(15, gpuMat.Rows);
        Assert.Equal(15, gpuMat.Cols);
        Assert.Equal(MatType.CV_32FC1, gpuMat.Type());

        // Download
        using var hostMat2 = new Mat();
        gpuMat.Download(hostMat2);

        Assert.Equal(3.14f, hostMat2.At<float>(7, 7), 5);
    }

    [Fact]
    public void MatToGpuMatCast()
    {
        VerifyCudaSupport();

        using var hostMat = new Mat(10, 10, MatType.CV_8UC1, new Scalar(100));
        using var gpuMat = new GpuMat(hostMat);

        Assert.Equal(10, gpuMat.Rows);
        Assert.Equal(MatType.CV_8UC1, gpuMat.Type());

        using var hostMat2 = new Mat();
        gpuMat.Download(hostMat2);
        Assert.Equal(100, hostMat2.At<byte>(5, 5));
    }

    [Fact]
    public void Clone()
    {
        VerifyCudaSupport();

        using var gpuMat1 = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(50));
        using var gpuMat2 = gpuMat1.Clone();

        Assert.Equal(gpuMat1.Rows, gpuMat2.Rows);
        Assert.Equal(gpuMat1.Cols, gpuMat2.Cols);
        Assert.NotEqual(gpuMat1.Data, gpuMat2.Data); // Should be a deep copy

        using var hostMat = new Mat();
        gpuMat2.Download(hostMat);
        Assert.Equal(50, hostMat.At<byte>(0, 0));
    }

    [Fact]
    public void CopyTo()
    {
        VerifyCudaSupport();

        using var src = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(100));
        using var dst = new GpuMat();

        src.CopyTo(dst);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(src.Type(), dst.Type());

        using var hostDst = new Mat();
        dst.Download(hostDst);
        Assert.Equal(100, hostDst.At<byte>(2, 2));
    }

    [Fact]
    public void CopyTo_WithMask_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Source image (all 255), Mask (half 255, half 0)
        using var gpuSrc = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(255));
        using var gpuMask = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(0));
        gpuMask.RowRange(0, 5).SetTo(new Scalar(255)); // Top half active

        using var gpuDst = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(0));

        // 2. Act
        gpuSrc.CopyTo(gpuDst, gpuMask);

        // 3. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.Equal(255, cpuDst.At<byte>(0, 0)); // Inside mask
        Assert.Equal(0, cpuDst.At<byte>(7, 7));   // Outside mask
    }

    [Fact]
    public void CopyTo_Async_Test()
    {
        VerifyCudaSupport();

        using var gpuSrc = new GpuMat(100, 100, MatType.CV_8UC1, new Scalar(123));
        using var gpuDst = new GpuMat();
        using var stream = new OpenCvSharp.Cuda.Stream();

        // Act: Async copy
        gpuSrc.CopyTo(gpuDst, stream);
        stream.WaitForCompletion();

        // Assert
        Assert.False(gpuDst.Empty());
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        Assert.Equal(123, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void ConvertTo()
    {
        VerifyCudaSupport();

        using var src = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(10));
        using var dst = new GpuMat();

        // Convert byte to float, and scale by 2.5
        src.ConvertTo(dst, MatType.CV_32FC1, 2.5, 0);

        Assert.Equal(MatType.CV_32FC1, dst.Type());

        using var hostDst = new Mat();
        dst.Download(hostDst);
        Assert.Equal(25.0f, hostDst.At<float>(0, 0), 5);
    }

    [Fact]
    public void ConvertTo_Scaling_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create CV_8U matrix filled with 100
        using var gpuSrc = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(100));
        using var gpuDst = new GpuMat();

        // 2. Act: Convert to CV_32F and multiply by 0.5 (100 * 0.5 = 50.0)
        gpuSrc.ConvertTo(gpuDst, MatType.CV_32FC1, 0.5, 0.0);

        // 3. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.Equal(MatType.CV_32FC1, cpuDst.Type());
        Assert.Equal(50.0f, cpuDst.At<float>(0, 0));
    }

    [Fact]
    public void ConvertTo_Async_Test()
    {
        VerifyCudaSupport();

        using var gpuSrc = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(200));
        using var gpuDst = new GpuMat();
        using var stream = new OpenCvSharp.Cuda.Stream();

        // Act: Async conversion
        gpuSrc.ConvertTo(gpuDst, MatType.CV_8UC1, 1.0, 10.0, stream);
        stream.WaitForCompletion();

        // Assert: 200 + 10 = 210
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        Assert.Equal(210, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void SetTo()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat(5, 5, MatType.CV_8UC1, new Scalar(0));
        gpuMat.SetTo(new Scalar(255));

        using var hostMat = new Mat();
        gpuMat.Download(hostMat);
        Assert.Equal(255, hostMat.At<byte>(3, 3));
    }

    //[Fact]
    // https://github.com/opencv/opencv/issues/4728
    //public void Reshape()
    //{
    //    CheckCuda();

    //    // 10x10, 1 channel
    //    using var gpuMat = new GpuMat(10, 10, MatType.CV_8UC1);

    //    // Reshape to 2 channels, calculate rows automatically (0 means keep same if possible, or calculate based on channels)
    //    // 100 elements / 2 channels = 50 elements. If we say rows = 5, cols will be 10.
    //    using var reshaped = gpuMat.Reshape(2, 5);

    //    Assert.Equal(5, reshaped.Rows);
    //    Assert.Equal(10, reshaped.Cols);
    //    Assert.Equal(2, reshaped.Channels());
    //}

    [Fact]
    public void SubMatrixROI()
    {
        VerifyCudaSupport();

        using var hostMat = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        // Set a 2x2 block in the middle to 255
        hostMat.SubMat(new Rect(4, 4, 2, 2)).SetTo(new Scalar(255));

        using var gpuMat = new GpuMat();
        gpuMat.Upload(hostMat);

        // Extract ROI on GPU
        using var roiGpu = new GpuMat(gpuMat, new Rect(4, 4, 2, 2));

        Assert.Equal(2, roiGpu.Rows);
        Assert.Equal(2, roiGpu.Cols);

        using var roiHost = new Mat();
        roiGpu.Download(roiHost);

        Assert.Equal(255, roiHost.At<byte>(0, 0));
        Assert.Equal(255, roiHost.At<byte>(1, 1));
    }

    [Fact]
    public void RowAndColRange()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat(10, 10, MatType.CV_8UC1);

        using var rowRange = gpuMat.RowRange(2, 5);
        Assert.Equal(3, rowRange.Rows);
        Assert.Equal(10, rowRange.Cols);

        using var colRange = gpuMat.ColRange(new Range(3, 7));
        Assert.Equal(10, colRange.Rows);
        Assert.Equal(4, colRange.Cols);
    }

    [Fact]
    public void Swap()
    {
        VerifyCudaSupport();

        using var m1 = new GpuMat(5, 5, MatType.CV_8UC1);
        using var m2 = new GpuMat(10, 10, MatType.CV_32FC1);

        m1.Swap(m2);

        Assert.Equal(10, m1.Rows);
        Assert.Equal(MatType.CV_32FC1, m1.Type());

        Assert.Equal(5, m2.Rows);
        Assert.Equal(MatType.CV_8UC1, m2.Type());
    }

    [Fact]
    public void PropertiesTest()
    {
        VerifyCudaSupport();

        using var m = new GpuMat(10, 20, MatType.CV_32FC3);

        Assert.Equal(10, m.Rows);
        Assert.Equal(20, m.Cols);
        Assert.Equal(10, m.Height);
        Assert.Equal(20, m.Width);
        Assert.Equal(3, m.Channels());
        Assert.Equal(MatType.CV_32FC3, m.Type());

        Assert.True(m.Step() > 0);
        Assert.True(m.ElemSize() > 0);
        Assert.True(m.ElemSize1() > 0);

        Assert.NotEqual(IntPtr.Zero, m.Data);
        Assert.NotEqual(IntPtr.Zero, m.DataStart);
        Assert.NotEqual(IntPtr.Zero, m.DataEnd);
    }

    [Fact]
    public void LocateROI()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat(20, 20, MatType.CV_8UC1);
        using var roi = new GpuMat(gpuMat, new Rect(5, 5, 10, 10));

        roi.LocateROI(out Size wholeSize, out Point ofs);

        Assert.Equal(20, wholeSize.Width);
        Assert.Equal(20, wholeSize.Height);
        Assert.Equal(5, ofs.X);
        Assert.Equal(5, ofs.Y);
    }

    [Fact]
    public void AsyncStreamUploadAndDownload()
    {
        VerifyCudaSupport();

        // 1. Prepare data on CPU
        using var source = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(50));
        using var destination = new Mat();
        using var gpuMat = new GpuMat();

        // 2. Create the stream
        using var stream = new OpenCvSharp.Cuda.Stream();

        // 3. Upload asynchronously
        gpuMat.Upload(source, stream);

        // 4. Download asynchronously
        gpuMat.Download(destination, stream);

        // At this point, the CPU might be faster than the GPU. 
        // If we check 'destination' immediately, it might be empty or partial.

        // 5. Block CPU until GPU is finished
        stream.WaitForCompletion();

        // 6. Verify
        Assert.Equal(50, destination.At<byte>(0, 0));
        Assert.Equal(source.Size(), destination.Size());
    }

    [Fact]
    public void CopyTo_Async()
    {
        VerifyCudaSupport();

        using var source = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(100));
        using var gpuSource = new GpuMat();
        using var gpuDest = new GpuMat();
        using var result = new Mat();
        using var stream = new OpenCvSharp.Cuda.Stream();

        // Upload sync (to set up)
        gpuSource.Upload(source);

        // Copy async: Source -> Dest
        gpuSource.CopyTo(gpuDest, stream);

        // Download result async
        gpuDest.Download(result, stream);

        stream.WaitForCompletion();

        Assert.Equal(100, result.At<byte>(0, 0));
    }

    [Fact]
    public void StreamQuery()
    {
        VerifyCudaSupport();

        // Use a very large matrix to give the GPU "work" to do
        using var largeMat = new Mat(5000, 5000, MatType.CV_32FC1, Scalar.All(1.0));
        using var gpuMat = new GpuMat();
        using var stream = new OpenCvSharp.Cuda.Stream();

        // Start a large upload
        gpuMat.Upload(largeMat, stream);

        // Query returns true if all steps in the stream are finished.
        // Note: On very fast GPUs, this might already be true.
        bool isFinished = stream.QueryIfComplete();

        stream.WaitForCompletion();

        Assert.True(stream.QueryIfComplete(), "Stream should be finished after WaitForCompletion");
    }

    [Fact]
    public void AsyncStreamSetTo()
    {
        VerifyCudaSupport();

        // Create a black image
        using var gpuMat = new GpuMat(10, 10, MatType.CV_8UC1, Scalar.All(0));
        // Create a mask (only fill the first 5 rows)
        using var mask = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));
        mask.RowRange(0, 5).SetTo(Scalar.All(255));
        using var gpuMask = new GpuMat();
        gpuMask.Upload(mask);

        using var stream = new OpenCvSharp.Cuda.Stream();
        using var result = new Mat();

        // Fill with 255 where mask is non-zero
        gpuMat.SetTo(Scalar.All(255), gpuMask, stream);
        gpuMat.Download(result, stream);

        stream.WaitForCompletion();

        Assert.Equal(255, result.At<byte>(0, 0)); // Inside mask
        Assert.Equal(0, result.At<byte>(6, 0));   // Outside mask
    }

    [Fact]
    public void UpdateContinuityFlag_Test()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat(10, 10, MatType.CV_8UC1);

        // Act & Assert
        // This should execute smoothly without ExceptionStatus issues
        var exception = Record.Exception(() => gpuMat.UpdateContinuityFlag());
        Assert.Null(exception);
    }

    [Fact]
    public void Allocators_Test()
    {
        VerifyCudaSupport();

        // 1. Get the built-in standard allocator
        IntPtr stdAllocator = GpuMat.GetStdAllocator();
        Assert.NotEqual(IntPtr.Zero, stdAllocator);

        // 2. Get the current default allocator
        IntPtr defAllocator = GpuMat.DefaultAllocator();
        Assert.NotEqual(IntPtr.Zero, defAllocator);

        // 3. Set the default allocator to the standard one 
        // (This is safe because it's the default behavior anyway)
        var exception = Record.Exception(() => GpuMat.SetDefaultAllocator(stdAllocator));
        Assert.Null(exception);
    }
}

