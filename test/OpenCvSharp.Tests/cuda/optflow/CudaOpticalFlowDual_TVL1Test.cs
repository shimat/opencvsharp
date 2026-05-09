using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.Optflow;

public class CudaOpticalFlowDual_TVL1Test : CudaTestBase
{
    [Fact]
    public void DualTVL1_PropertiesAndCalcTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Instantiate
            using var tvl1 = OpenCvSharp.Cuda.OpticalFlowDual_TVL1.Create(iterations: 100);

            // 2. Test Properties
            tvl1.Tau = 0.2;
            Assert.Equal(0.2, tvl1.Tau);

            tvl1.NumScales = 3;
            Assert.Equal(3, tvl1.NumScales);

            tvl1.UseInitialFlow = true;
            Assert.True(tvl1.UseInitialFlow);

            // 3. Perform a Calculation
            using var cpu1 = new Mat(64, 64, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpu1, new Rect(10, 10, 10, 10), new Scalar(255), -1);

            using var cpu2 = new Mat(64, 64, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpu2, new Rect(15, 10, 10, 10), new Scalar(255), -1); // Moved right

            using var gpu1 = new GpuMat(); gpu1.Upload(cpu1);
            using var gpu2 = new GpuMat(); gpu2.Upload(cpu2);

            // Output matrix (2-channel float)
            using var flow = new GpuMat();

            // Must allocate flow if UseInitialFlow is true
            flow.Create(gpu1.Size(), MatType.CV_32FC2);
            flow.SetTo(new Scalar(0, 0));

            tvl1.Calc(gpu1, gpu2, flow);

            using var res = new Mat();
            flow.Download(res);

            Assert.False(res.Empty());
            Vec2f motion = res.At<Vec2f>(15, 15);
            Assert.True(motion.Item0 > 0, "Expected positive X motion.");
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            return;
        }
    }
}
