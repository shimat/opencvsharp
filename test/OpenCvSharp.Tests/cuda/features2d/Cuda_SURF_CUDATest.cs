using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.features2d;

public class Cuda_SURF_CUDATest : CudaTestBase
{
    [Fact]
    public void SURF_CUDA_Test()
    {
        VerifyCudaSupport();

        try
        {
            using var cpuImg = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpuImg, new Rect(25, 25, 50, 50), new Scalar(255), -1);

            using var gpuImg = new GpuMat(); gpuImg.Upload(cpuImg);
            using var gpuKeypoints = new GpuMat();
            using var gpuDescriptors = new GpuMat();

            using var surf = SURF_CUDA.Create(hessianThreshold: 100);
            surf.DetectWithDescriptors(gpuImg, null, gpuKeypoints, gpuDescriptors);

            KeyPoint[] kps = surf.DownloadKeypoints(gpuKeypoints);
            float[] descriptors = surf.DownloadDescriptors(gpuDescriptors);

            Assert.True(kps.Length > 0);
            Assert.Equal(kps.Length * surf.DescriptorSize, descriptors.Length);
        }
        catch (OpenCVException ex) when (ex.Message.Contains("Set OPENCV_ENABLE_NONFREE CMake"))
        {
            Assert.Skip(ex.Message);
        }
    }
}
