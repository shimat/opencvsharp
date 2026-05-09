using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaCLAHETest : CudaTestBase
{
    [Fact]
    public void CudaCLAHE()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create CLAHE algorithm with initial values
        using var clahe = OpenCvSharp.Cuda.CLAHE.Create(clipLimit: 40.0, tileGridSize: new Size(8, 8));

        // 2. Assert Initial Properties
        Assert.Equal(40.0, clahe.ClipLimit);
        Assert.Equal(new Size(8, 8), clahe.TilesGridSize);

        // 3. Act: Modify Properties
        clahe.ClipLimit = 20.5;
        clahe.TilesGridSize = new Size(4, 4);

        // 4. Assert Modified Properties
        Assert.Equal(20.5, clahe.ClipLimit);
        Assert.Equal(new Size(4, 4), clahe.TilesGridSize);

        // 5. Act: Test CollectGarbage
        // Just ensuring it successfully calls the native method without crashing
        var exception = Record.Exception(() => clahe.CollectGarbage());
        Assert.Null(exception);

        // 6. Act: Test Apply (Ensure it still works after property changes)
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(100)); // Dark Gray

        // Create a horizontal gradient (0-99)
        for (int y = 0; y < 100; y++)
        {
            for (int x = 0; x < 100; x++)
            {
                cpuSrc.Set(y, x, (byte)x);
            }
        }

        // Draw a tiny square that is barely visibly lighter (150)
        Cv2.Rectangle(cpuSrc, new Rect(40, 40, 20, 20), new Scalar(150), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        clahe.Apply(gpuSrc, gpuDst);

        // 7. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Cv2.MinMaxLoc(cpuSrc, out double minBefore, out double maxBefore);
        Cv2.MinMaxLoc(cpuDst, out double minAfter, out double maxAfter);

        double rangeBefore = maxBefore - minBefore;
        double rangeAfter = maxAfter - minAfter;

        Assert.True(rangeAfter > rangeBefore,
            $"Expected expanded dynamic range, before={rangeBefore}, after={rangeAfter}");
    }
}
