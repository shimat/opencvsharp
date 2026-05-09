using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public abstract class CudaTestBase : TestBase
{
    private static int _cudaSupport = -1;

    protected void VerifyCudaSupport()
    {
       if (_cudaSupport == -1)
        {
            string buildInfo = Cv2.GetBuildInformation();
            Console.WriteLine(buildInfo);

            // 2. Define the marker we are looking for. 
            // In OpenCV's output, it looks like: "NVIDIA CUDA:                   YES (ver 11.x)"
            string searchString = "NVIDIA CUDA:";

            // 3. Find the line containing the CUDA status
            string[] lines = buildInfo.Split(["\n", "\r"], StringSplitOptions.RemoveEmptyEntries);
            string? cudaLine = Array.Find(lines, l => l.Contains(searchString));

            bool valid = true;

            if (string.IsNullOrEmpty(cudaLine))
                valid = false;

            if (valid && !cudaLine.ToUpper().Contains("YES"))
                valid = false;

            _cudaSupport = 2; // default
            if (!valid)
            {
                _cudaSupport = 0; // set no cuda build
            }
            if (Cv2.Cuda.GetCudaEnabledDeviceCount() == 0)
            {
                _cudaSupport = 1; // set no cuda device found
            }
        }
       
        if (_cudaSupport == 0)
            Assert.Skip("OpenCV binary was not compiled with CUDA support.");
        if (_cudaSupport == 1)
            Assert.Skip("No CUDA device available.");
        if (_cudaSupport == 2)
            return;
    }
    public static void AssertAround(double actual, double expected, double percentage)
    {
        var tolerance = Math.Abs(expected) * percentage;
        var diff = Math.Abs(actual - expected);

        Assert.True(diff <= tolerance,
            $"Expected {actual} to be within {percentage:P} of {expected} (tolerance {tolerance}, diff {diff})");
    }


    public const int Rows = 4;
    public const int Cols = 4;
    public const float Tolerance = 1e-4f;

    public static GpuMat MakeFloat(int rows, int cols, float value)
    {
        using var cpu = new Mat(rows, cols, MatType.CV_32FC1, new Scalar(value));
        var gpu = new GpuMat();
        gpu.Upload(cpu);
        return gpu;
    }

    /// <summary>Creates a single-channel byte GpuMat filled with <paramref name="value"/>.</summary>
    public static GpuMat MakeByte(int rows, int cols, byte value)
    {
        using var cpu = new Mat(rows, cols, MatType.CV_8UC1, new Scalar(value));
        var gpu = new GpuMat();
        gpu.Upload(cpu);
        return gpu;
    }

    /// <summary>Downloads a GpuMat and returns the value of pixel (0,0) as float.</summary>
    public static float PixelF(GpuMat gpu)
    {
        using var cpu = new Mat();
        gpu.Download(cpu);
        return cpu.At<float>(0, 0);
    }

    /// <summary>Downloads a GpuMat and returns the value of pixel (0,0) as byte.</summary>
    public static byte PixelB(GpuMat gpu)
    {
        using var cpu = new Mat();
        gpu.Download(cpu);
        return cpu.At<byte>(0, 0);
    }


}
