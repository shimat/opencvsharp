using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.optflow;

public class CudaNvidiaOpticalFlow_1_0Test : CudaTestBase
{
    [Fact]
    public void NvidiaOpticalFlow10_Test()
    {
        VerifyCudaSupport();

        try
        {
            Size imgSize = new Size(640, 480);
            using var nvFlow = OpenCvSharp.Cuda.NvidiaOpticalFlow_1_0.Create(imgSize);

            // 1. Verify Grid Size
            int gridSize = nvFlow.GridSize;
            Assert.True(gridSize > 0);

            // 2. Prepare mock hardware output (typically CV_16SC2)
            // Hardware flow size is typically (width/gridSize) x (height/gridSize)
            using var gpuFlowCoarse = new GpuMat(imgSize.Height / gridSize, imgSize.Width / gridSize, MatType.CV_16SC2, new Scalar(10, 10));
            using var gpuFlowDense = new GpuMat();

            // 3. Test UpSampler
            nvFlow.UpSampler(gpuFlowCoarse, imgSize, gridSize, gpuFlowDense);

            // 4. Assert
            Assert.False(gpuFlowDense.Empty());
            Assert.Equal(imgSize.Height, gpuFlowDense.Rows);
            Assert.Equal(imgSize.Width, gpuFlowDense.Cols);
        }
        catch (OpenCVException ex) when (ex.Message.Contains("not supported") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip(ex.Message);
        }
    }
}
