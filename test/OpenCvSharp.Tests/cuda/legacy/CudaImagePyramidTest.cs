using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.legacy;

public class CudaImagePyramidTest : CudaTestBase
{
    [Fact]
    public void ImagePyramid_GetLayerTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 source image
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // 2. Act: Create pyramid
        using var pyramid = OpenCvSharp.Cuda.ImagePyramid.Create(gpuSrc, nLayers: 3);

        using var gpuLayer0 = new GpuMat();
        using var gpuLayer1 = new GpuMat();

        // Fetch the 100x100 layer
        pyramid.GetLayer(gpuLayer0, new Size(100, 100));
        // Fetch the 50x50 layer
        pyramid.GetLayer(gpuLayer1, new Size(50, 50));

        // 3. Assert
        Assert.Equal(100, gpuLayer0.Rows);
        Assert.Equal(50, gpuLayer1.Rows);
        Assert.False(gpuLayer1.Empty());
    }

   
}
