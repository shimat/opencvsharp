using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.Optflow;

public class CudaDensePyrLKTests : CudaTestBase
{
    [Fact]
    public void DensePyrLKOpticalFlow_PropertiesAndCalcTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Create instance
            using var pyrLk = OpenCvSharp.Cuda.DensePyrLKOpticalFlow.Create();

            // 2. Test Properties
            pyrLk.MaxLevel = 5;
            Assert.Equal(5, pyrLk.MaxLevel);

            pyrLk.NumIters = 50;
            Assert.Equal(50, pyrLk.NumIters);

            pyrLk.UseInitialFlow = true;
            Assert.True(pyrLk.UseInitialFlow);

            pyrLk.WinSize = new Size(21, 21);
            Assert.Equal(new Size(21, 21), pyrLk.WinSize);

            // 3. Test Computation
            // Use 8-bit images
            using var cpuImg1 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpuImg1, new Rect(20, 20, 20, 20), new Scalar(255), -1);

            using var cpuImg2 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpuImg2, new Rect(25, 20, 20, 20), new Scalar(255), -1); // Moved right by 5 pixels

            using var gpuImg1 = new GpuMat(); gpuImg1.Upload(cpuImg1);
            using var gpuImg2 = new GpuMat(); gpuImg2.Upload(cpuImg2);

            // Flow matrix must be pre-allocated because UseInitialFlow is true!
            // If it's empty, and UseInitialFlow is true, OpenCV crashes.
            using var gpuFlow = new GpuMat(100, 100, MatType.CV_32FC2, new Scalar(0, 0));

            // Calc is inherited from DenseOpticalFlow
            pyrLk.Calc(gpuImg1, gpuImg2, gpuFlow);

            // 4. Assert
            using var cpuFlow = new Mat();
            gpuFlow.Download(cpuFlow);

            Assert.False(cpuFlow.Empty());
            Assert.Equal(MatType.CV_32FC2, cpuFlow.Type());

            // Read flow vector at the object's position
            Vec2f flow = cpuFlow.At<Vec2f>(30, 30);

            // Since object moved Right (+X direction), the X-flow should be positive
            Assert.True(flow.Item0 > 0, $"Expected positive X motion flow, got {flow.Item0}");
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            // Graceful exit for builds without cudaoptflow
            return;
        }
    }
}
