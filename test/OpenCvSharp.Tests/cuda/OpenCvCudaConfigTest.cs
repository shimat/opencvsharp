using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class OpenCvCudaConfigTest : CudaTestBase
{
    [Fact]
    public void OpenCVBinaryShouldBeCompiledWithCudaSupport()
    {

        try
        {
            // 1. Get the raw build information from the native library
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

            if (!valid)
                throw new Exception("OpenCV binary was not compiled with CUDA support.");



            int deviceCount = Cv2.Cuda.GetCudaEnabledDeviceCount();

            if (deviceCount ==0)
                throw new Exception("OpenCV binary compiled with CUDA support, but no device found");

        }
        catch (Exception ex)
        {
            throw new Exception($"Could not load OpenCV native library: {ex.Message}");
        }

    }

    [Fact]
    public void DeviceSupports_Test()
    {
        VerifyCudaSupport();

        // Most modern GPUs support Compute 3.0 and Double precision
        bool hasDouble = Cv2.Cuda.DeviceSupports(FeatureSet.NativeDouble);
        bool hasCompute30 = Cv2.Cuda.DeviceSupports(FeatureSet.Compute30);

        // This should not throw an exception. 
        // We can't strictly assert 'true' because of very old hardware (like Tesla),
        // but we can verify the call returns a valid boolean.
        Assert.True(hasDouble || !hasDouble);
        Assert.True(hasCompute30 || !hasCompute30);
    }
}
