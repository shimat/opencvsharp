using System;
using Xunit;
using OpenCvSharp;
using OpenCvSharp.Cuda;

namespace OpenCvSharp.Tests.Cuda.Optflow;

    public class CudaBroxOpticalFlowTests : CudaTestBase
    {
        [Fact]
        public void BroxOpticalFlow_PropertiesAndCalcTest()
        {
            VerifyCudaSupport();

            try
            {
                // 1. Create instance
                using var brox = OpenCvSharp.Cuda.BroxOpticalFlow.Create();

                // 2. Test Properties
                brox.FlowSmoothness = 0.5;
                Assert.Equal(0.5, brox.FlowSmoothness);

                brox.InnerIterations = 10;
                Assert.Equal(10, brox.InnerIterations);

                brox.SolverIterations = 20;
                Assert.Equal(20, brox.SolverIterations);

                // 3. Test Computation
                // Brox requires CV_32FC1 images [0.0 ... 1.0]
                using var cpuImg1 = new Mat(100, 100, MatType.CV_32FC1, new Scalar(0));
                Cv2.Rectangle(cpuImg1, new Rect(20, 20, 20, 20), new Scalar(1.0f), -1);

                using var cpuImg2 = new Mat(100, 100, MatType.CV_32FC1, new Scalar(0));
                Cv2.Rectangle(cpuImg2, new Rect(25, 20, 20, 20), new Scalar(1.0f), -1); // Moved right by 5 pixels

                using var gpuImg1 = new GpuMat(); gpuImg1.Upload(cpuImg1);
                using var gpuImg2 = new GpuMat(); gpuImg2.Upload(cpuImg2);
                using var gpuFlow = new GpuMat();

                // Calc is inherited from DenseOpticalFlow
                brox.Calc(gpuImg1, gpuImg2, gpuFlow);

                // 4. Assert
                using var cpuFlow = new Mat();
                gpuFlow.Download(cpuFlow);

                Assert.False(cpuFlow.Empty());
                // Dense optical flow produces a 2-channel matrix (X-flow, Y-flow)
                Assert.Equal(MatType.CV_32FC2, cpuFlow.Type());

                // Read flow vector at the object's position
                Vec2f flow = cpuFlow.At<Vec2f>(30, 30);

                // Since object moved Right (+X direction), the X-flow should be positive
                Assert.True(flow.Item0 > 0, "Expected positive X motion flow");
            }
            catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
            {
                // Graceful exit for builds without cudaoptflow
                return;
            }
        }
    }

