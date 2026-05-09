using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.features2d;

public class CudaFastFeatureDetectorTest : CudaTestBase
{
    [Fact]
    public void FastFeatureDetector_PropertiesAndDetectTest()
    {
        VerifyCudaSupport();

        try
        {
            // Larger threshold stability + disable suppression
            using var fast = OpenCvSharp.Cuda.FastFeatureDetector.Create(
                threshold: 10,
                nonmaxSuppression: false);

            fast.MaxNumPoints = 1000;
            Assert.Equal(1000, fast.MaxNumPoints);

            fast.Threshold = 10;

            // Larger square with stronger corners
            using var cpuSrc = new Mat(200, 200, MatType.CV_8UC1, Scalar.Black);

            Cv2.Rectangle(
                cpuSrc,
                new Rect(50, 50, 100, 100),
                Scalar.White,
                thickness: -1);

            using var gpuSrc = new GpuMat();
            gpuSrc.Upload(cpuSrc);

            using var gpuKeypoints = new GpuMat();

            using OpenCvSharp.Cuda.Stream stream = new OpenCvSharp.Cuda.Stream();
            // Detect
            fast.DetectAsync(gpuSrc, gpuKeypoints,null, stream);

            // IMPORTANT: wait for async op
            stream.WaitForCompletion();

             // Convert
             KeyPoint[] kps = fast.Convert(gpuKeypoints);

            Assert.NotNull(kps);
            Assert.True(kps.Length > 0,
                $"FAST failed to detect corners. Count={kps.Length}");
        }
        catch (OpenCVException ex) when (
            ex.Message.Contains("disabled") ||
            ex.Message.Contains("Not Implemented"))
        {
            return;
        }
    }
}
