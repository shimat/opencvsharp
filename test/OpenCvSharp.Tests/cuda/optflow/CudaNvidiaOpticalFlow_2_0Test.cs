using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.optflow;

public class CudaNvidiaOpticalFlow_2_0Test : CudaTestBase
{
    [Fact]
    public void NvidiaOpticalFlow20_Test()
    {
        VerifyCudaSupport();

        try
        {
            Size imgSize = new Size(1280, 720);
            // Test ROI creation
            Rect[] rois = { new Rect(0, 0, 640, 720), new Rect(640, 0, 640, 720) };

            using var nvFlow = OpenCvSharp.Cuda.NvidiaOpticalFlow_2_0.Create(imgSize, rois);

            int gridSize = nvFlow.GridSize;
            Assert.True(gridSize > 0);

            // Prepare mock hardware output
            using var gpuFlowCoarse = new GpuMat(imgSize.Height / gridSize, imgSize.Width / gridSize, MatType.CV_16SC2, new Scalar(5, 5));
            using var gpuFlowFloat = new GpuMat();

            // Test ConvertToFloat
            nvFlow.ConvertToFloat(gpuFlowCoarse, gpuFlowFloat);

            Assert.False(gpuFlowFloat.Empty());
            Assert.Equal(MatType.CV_32FC2, gpuFlowFloat.Type());
        }
        catch (OpenCVException ex) when (ex.Message.Contains("not supported") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip(ex.Message);
        }
    }
}
