using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.Optflow;

public class CudaFarnebackOpticalFlowTest : CudaTestBase
{
    [Fact]
    public void Farneback_PropertiesAndCalcTest()
    {
        VerifyCudaSupport();

        try
        {
            using var farneback = OpenCvSharp. Cuda.FarnebackOpticalFlow.Create();

            // 1. Test Properties
            farneback.NumLevels = 3;
            Assert.Equal(3, farneback.NumLevels);

            farneback.PyrScale = 0.5f;
            Assert.Equal(0.5f, farneback.PyrScale);

            farneback.FastPyramids = true;
            Assert.True(farneback.FastPyramids);

            // 2. Test Computation
            using var cpu1 = new Mat(64, 64, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpu1, new Rect(10, 10, 10, 10), new Scalar(255), -1);

            using var cpu2 = new Mat(64, 64, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpu2, new Rect(12, 10, 10, 10), new Scalar(255), -1); // Shifted +2 in X

            using var gpu1 = new GpuMat(); gpu1.Upload(cpu1);
            using var gpu2 = new GpuMat(); gpu2.Upload(cpu2);
            using var flow = new GpuMat();

            farneback.Calc(gpu1, gpu2, flow);

            using var res = new Mat();
            flow.Download(res);

            Assert.False(res.Empty());
            // Check movement at a point inside the square
            Vec2f move = res.At<Vec2f>(15, 15);
            Assert.True(move.Item0 > 0, "Expected positive X movement.");
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            return;
        }
    }
}
