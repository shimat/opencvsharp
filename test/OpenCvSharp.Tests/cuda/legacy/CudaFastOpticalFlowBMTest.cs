using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.legacy;

public class CudaFastOpticalFlowBMTest : CudaTestBase
{
    [Fact]
    public void FastOpticalFlowBM_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create two frames with a moving square
        using var cpu1 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpu1, new Rect(20, 20, 20, 20), new Scalar(255), -1);

        using var cpu2 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpu2, new Rect(25, 20, 20, 20), new Scalar(255), -1); // Shifted +5 in X

        using var gpu1 = new GpuMat(); gpu1.Upload(cpu1);
        using var gpu2 = new GpuMat(); gpu2.Upload(cpu2);

        using var flowX = new GpuMat();
        using var flowY = new GpuMat();

        // 2. Act
        OpenCvSharp.Cuda.FastOpticalFlowBM.Compute(gpu1, gpu2, flowX, flowY, searchWindow: 21, blockWindow: 7);

        // 3. Assert
        using var resX = new Mat();
        using var resY = new Mat();
        flowX.Download(resX);
        flowY.Download(resY);

        Assert.False(resX.Empty());
        Assert.Equal(MatType.CV_32FC1, resX.Type());

        // Read the flow value at the center of the square
        float moveX = resX.At<float>(30, 30);

        // Expected movement was roughly 5 pixels
        Assert.True(moveX > 0, $"Expected positive X flow, got {moveX}");
    }
}
