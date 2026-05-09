using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaPhotoTest : CudaTestBase
{
    [Fact]
    public void FastNlMeansDenoising_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 50x50 gray image (Value 100) with a noise pixel (Value 200) at center
        using var cpuSrc = new Mat(50, 50, MatType.CV_8UC1, new Scalar(100));
        cpuSrc.Set<byte>(25, 25, 200);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act: Apply NL Means with a strong filter strength (h=50)
        Cv2.Cuda.FastNlMeansDenoising(gpuSrc, gpuDst, h: 50.0f);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_8UC1, cpuDst.Type());

        byte originalNoise = 200;
        byte denoisedPixel = cpuDst.At<byte>(25, 25);

        // The denoising process should have pulled the value 200 much closer to 100
        Assert.True(denoisedPixel < originalNoise, $"Expected noise to be reduced, but was {denoisedPixel}");
    }

    [Fact]
    public void FastNlMeansDenoising_GrayTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Grayscale image with a specific noise pixel
        using var cpuSrc = new Mat(50, 50, MatType.CV_8UC1, new Scalar(100));
        cpuSrc.Set<byte>(25, 25, 200); // Noise

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.FastNlMeansDenoising(gpuSrc, gpuDst, h: 50.0f);

        // 3. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        byte result = cpuDst.At<byte>(25, 25);
        Assert.True(result < 200, "Noise was not reduced in grayscale.");
    }

    [Fact]
    public void FastNlMeansDenoising_ColoredTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 3-channel BGR image
        using var cpuSrc = new Mat(50, 50, MatType.CV_8UC3, new Scalar(100, 100, 100));
        cpuSrc.Set<Vec3b>(25, 25, new Vec3b(200, 200, 200)); // Noise

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        Cv2.Cuda.FastNlMeansDenoisingColored(gpuSrc, gpuDst, hLuminance: 50.0f, photoRender: 50.0f);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        Vec3b result = cpuDst.At<Vec3b>(25, 25);
        Assert.True(result.Item0 < 200, "Noise was not reduced in colored image.");
    }
}
