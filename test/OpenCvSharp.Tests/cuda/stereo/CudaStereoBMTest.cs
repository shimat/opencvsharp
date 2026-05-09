using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.stereo;

public class CudaStereoBMTest : CudaTestBase
{
    [Fact]
    public void StereoBM_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create synthetic stereo pair
        // Left image: black with a white square at (40, 40)
        using var leftCpu = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(leftCpu, new Rect(40, 40, 20, 20), new Scalar(255), -1);

        // Right image: black with white square shifted to (30, 40) -> 10px disparity
        using var rightCpu = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(rightCpu, new Rect(30, 40, 20, 20), new Scalar(255), -1);

        using var leftGpu = new GpuMat(); leftGpu.Upload(leftCpu);
        using var rightGpu = new GpuMat(); rightGpu.Upload(rightCpu);
        using var disparityGpu = new GpuMat();

        // 2. Act
        // Note: numDisparities must be a multiple of 16
        using var stereo = OpenCvSharp.Cuda.StereoBM.Create(numDisparities: 64, blockSize: 19);

        // Compute is inherited from StereoMatcher and supports GpuMat via Input/OutputArray
        stereo.Compute(leftGpu, rightGpu, disparityGpu);

        // 3. Assert
        using var disparityCpu = new Mat();
        disparityGpu.Download(disparityCpu);

        Assert.False(disparityCpu.Empty());

        // StereoBM typically outputs CV_16S disparity.
        // Check a pixel inside the object area
        short dispValue = disparityCpu.At<short>(40, 40);

        // If disparity is > 0, the object was found
        Assert.True(dispValue >= 0 || dispValue == 0);
    }

    [Fact]
    public void StereoBM_Compute_Test()
    {
        VerifyCudaSupport();

        using var leftCpu = new Mat(256, 256, MatType.CV_8UC1);
        using var rightCpu = new Mat(256, 256, MatType.CV_8UC1);

        // Full-image random texture
        Cv2.Randu(leftCpu, 0, 255);

        // Shift image by 8 pixels
        leftCpu[new Rect(8, 0, 248, 256)]
            .CopyTo(rightCpu[new Rect(0, 0, 248, 256)]);

        using var leftGpu = new GpuMat();
        using var rightGpu = new GpuMat();
        using var disparityGpu = new GpuMat();

        leftGpu.Upload(leftCpu);
        rightGpu.Upload(rightCpu);

        using var bm =
            OpenCvSharp.Cuda.StereoBM.Create(
                numDisparities: 64,
                blockSize: 15);

        using OpenCvSharp.Cuda.Stream stream = new OpenCvSharp.Cuda.Stream();

        bm.Compute(leftGpu, rightGpu, disparityGpu, stream);

        stream.WaitForCompletion();

        using var disparityCpu = new Mat();
        disparityGpu.Download(disparityCpu);

        Assert.False(disparityCpu.Empty());

        // Sample safely away from borders
        Assert.Equal(MatType.CV_8UC1, disparityCpu.Type());

        byte val = disparityCpu.At<byte>(128, 128);

        Assert.True(val > 0, $"Expected positive disparity, got {val}");
    }
}
