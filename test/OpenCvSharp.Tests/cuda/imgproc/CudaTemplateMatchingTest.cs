using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaTemplateMatchingTest : CudaTestBase
{
    [Fact]
    public void TemplateMatching_MatchTest()
    {
        VerifyCudaSupport();

        using var scene = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(scene, new Rect(50, 50, 10, 10), new Scalar(255), -1);

        using var templ = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(templ, new Rect(2, 2, 6, 6), new Scalar(255), -1);

        using var gpuScene = new GpuMat(); gpuScene.Upload(scene);
        using var gpuTempl = new GpuMat(); gpuTempl.Upload(templ);
        using var gpuResult = new GpuMat();

        // 2. Act
        using var matcher = OpenCvSharp.Cuda.TemplateMatching.Create(
            MatType.CV_8UC1,
            TemplateMatchModes.CCoeffNormed);
        matcher.Match(gpuScene, gpuTempl, gpuResult);

        // 3. Assert
        using var cpuResult = new Mat();
        gpuResult.Download(cpuResult);

        Cv2.MinMaxLoc(cpuResult, out _, out _, out _, out var maxLoc);

        // allow small tolerance (CUDA can shift peaks slightly)
        Assert.InRange(maxLoc.X, 48, 52);
        Assert.InRange(maxLoc.Y, 48, 52);
    }
}
