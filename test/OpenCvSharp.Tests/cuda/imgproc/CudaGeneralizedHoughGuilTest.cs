using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaGeneralizedHoughGuilTest : CudaTestBase
{
    [Fact]
    public void Guil_CreateAndSetTemplateTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a simple template
        using var cpuTempl = new Mat(20, 20, MatType.CV_8UC1, new Scalar(0));
        Cv2.Circle(cpuTempl, new Point(10, 10), 5, new Scalar(255), -1);

        using var gpuTempl = new GpuMat();
        gpuTempl.Upload(cpuTempl);

        // 2. Act
        using var hough = OpenCvSharp.Cuda.GeneralizedHoughGuil.Create();

        // 3. Assert
        // Ensure no exception is thrown when setting the template
        var exception = Record.Exception(() => hough.SetTemplate(gpuTempl));
        Assert.Null(exception);

        Assert.NotEqual(IntPtr.Zero, hough.RawPtr);
    }
}
