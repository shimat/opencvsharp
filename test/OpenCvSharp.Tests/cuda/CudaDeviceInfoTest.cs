using System;
using OpenCvSharp;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda
{
    public class CudaDeviceInfoTests : CudaTestBase
    {
        [Fact]
        public void DeviceInfo_Test()
        {
            // Skip if no CUDA
            VerifyCudaSupport();

            // 1. Act: Create DeviceInfo for device 0
            using var device = new DeviceInfo(0);

            // 2. Assert: Check if properties return valid values
            // Most modern GPUs have at least 1 or 2 async engines.
            int engines = device.AsyncEngineCount;
            Assert.True(engines >= 0);

            // canMapHostMemory is a hardware-specific boolean
            bool canMap = device.CanMapHostMemory;

            // Just verifying the call succeeds
            Assert.True(canMap || !canMap);
        }

        [Fact]
        public void DeviceInfo_DefaultConstructor_Test()
        {
            VerifyCudaSupport();

            // Should succeed for current active device
            using var device = new DeviceInfo();
            Assert.NotEqual(IntPtr.Zero, device.CvPtr);
        }

        [Fact]
        public void DeviceInfo_ExtendedProperties_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Clock rate should be a positive number (usually 1,000,000 kHz+)
            Assert.True(device.ClockRate > 0);

            // Device ID should match the index we used to create it
            Assert.Equal(0, device.DeviceID);

            // Verify concurrent kernels is accessible
            bool canDoMulti = device.ConcurrentKernels;
            Assert.True(canDoMulti || !canDoMulti);

            // Verify compute mode
            ComputeMode mode = device.ComputeMode;
            Assert.IsType<ComputeMode>(mode);
        }

        [Fact]
        public void DeviceInfo_HardwareInfo_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // isCompatible should virtually always be true if the driver initialized
            Assert.True(device.IsCompatible);

            // Free memory should be a positive value if the GPU is working
            Assert.True(device.FreeMemory > 0);

            // Check bool accessors
            bool ecc = device.ECCEnabled;
            bool integrated = device.Integrated;

            // Output for diagnostic purposes
            Console.WriteLine($"GPU 0: Free Mem: {device.FreeMemory / 1024 / 1024} MB");
            Console.WriteLine($"GPU 0: Integrated: {integrated}, ECC: {ecc}");
        }

        [Fact]
        public void DeviceInfo_ComputeCapability_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Major version for any modern CUDA-enabled card should be >= 3
            Assert.True(device.MajorVersion >= 3);

            // L2 Cache should be reported (usually several megabytes)
            Assert.True(device.L2CacheSize > 0);

            // Grid size dimensions are usually very large (e.g. 2147483647)
            Vec3i grid = device.MaxGridSize;
            Assert.True(grid.Item0 > 0);
            Assert.True(grid.Item1 > 0);
            Assert.True(grid.Item2 > 0);

            // Timeout usually enabled on Windows if it's the primary display card
            bool timeout = device.KernelExecTimeoutEnabled;
            // No specific assertion needed, just verifying it returns
        }

        [Fact]
        public void DeviceInfo_SurfaceLimits_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Verify 1D and Cubemap (Int)
            Assert.True(device.MaxSurface1D > 0);
            Assert.True(device.MaxSurfaceCubemap > 0);

            // Verify 2D limits (Vec2i)
            Vec2i s2d = device.MaxSurface2D;
            Assert.True(s2d.Item0 > 0 && s2d.Item1 > 0);

            // Verify 3D limits (Vec3i)
            Vec3i s3d = device.MaxSurface3D;
            Assert.True(s3d.Item0 > 0 && s3d.Item1 > 0 && s3d.Item2 > 0);

            // Output a few values for logging
            Console.WriteLine($"Surface 2D Max: {s2d.Item0}x{s2d.Item1}");
            Console.WriteLine($"Surface 3D Max: {s3d.Item0}x{s3d.Item1}x{s3d.Item2}");
        }

        [Fact]
        public void DeviceInfo_TextureLimits_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Verify 1D limits
            Assert.True(device.MaxTexture1D > 0);
            Assert.True(device.MaxTexture1DLinear > 0);

            // Verify 2D limits
            Vec2i t2d = device.MaxTexture2D;
            Assert.True(t2d.Item0 > 0 && t2d.Item1 > 0);

            // Verify 3D limits
            Vec3i t3d = device.MaxTexture3D;
            Assert.True(t3d.Item0 > 0 && t3d.Item1 > 0 && t3d.Item2 > 0);

            // Logging for information
            Console.WriteLine($"Max Texture 2D: {t2d.Item0}x{t2d.Item1}");
            Console.WriteLine($"Max Texture 3D: {t3d.Item0}x{t3d.Item1}x{t3d.Item2}");
        }

        [Fact]
        public void DeviceInfo_ThreadLimits_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Verify thread limits (Essential for kernel tuning)
            // On most modern NVIDIA hardware, MaxThreadsPerBlock is 1024.
            int maxThreads = device.MaxThreadsPerBlock;
            Assert.True(maxThreads > 0);

            // Verify thread dimension limits
            // Typically (1024, 1024, 64)
            Vec3i threadDims = device.MaxThreadsDim;
            Assert.True(threadDims.Item0 > 0 && threadDims.Item1 > 0 && threadDims.Item2 > 0);

            // Verify Cubemap texture limits
            Assert.True(device.MaxTextureCubemap > 0);

            // Diagnostic output
            Console.WriteLine($"Max Threads Per Block: {maxThreads}");
            Console.WriteLine($"Max Block Dimensions: {threadDims.Item0}x{threadDims.Item1}x{threadDims.Item2}");
        }

        [Fact]
        public void DeviceInfo_MemoryPerformance_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Memory Bus Width is typically 64, 128, 192, 256, 320, or 384 bits.
            Assert.True(device.MemoryBusWidth > 0);
            Assert.True(device.MemoryBusWidth % 32 == 0);

            // Memory Clock Rate should be a high frequency (e.g., 7000000 kHz for GDDR6)
            Assert.True(device.MemoryClockRate > 0);

            // Max threads per SM (Streaming Multiprocessor)
            // Typically 1536 or 2048 on modern architectures.
            Assert.True(device.MaxThreadsPerMultiProcessor > 0);

            // Max pitch for memory copies (usually 2GB or higher)
            Assert.True(device.MemPitch > 0);

            Console.WriteLine($"Memory Bus: {device.MemoryBusWidth} bit");
            Console.WriteLine($"Max Threads per SM: {device.MaxThreadsPerMultiProcessor}");
        }

        [Fact]
        public void DeviceInfo_Identification_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Name should contain "NVIDIA" or at least not be empty
            string name = device.Name;
            Assert.False(string.IsNullOrWhiteSpace(name));

            // Compute Capability Check
            // If Major is 8 and Minor is 6, Capability is 8.6
            int major = device.MajorVersion;
            int minor = device.MinorVersion;
            Assert.True(major > 0);

            // Multiprocessor count should be significant for any GPU
            Assert.True(device.MultiProcessorCount > 0);

            // PCI IDs are hardware-defined
            Assert.True(device.PciBusID >= 0);

            // Console output for your debugging logs
            Console.WriteLine($"Device 0: {name}");
            Console.WriteLine($"Compute Capability: {major}.{minor}");
            Console.WriteLine($"SM Count: {device.MultiProcessorCount}");
        }

        [Fact]
        public void DeviceInfo_ResourcesAndFeatures_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // 1. Test Memory Query
            device.QueryMemory(out long total, out long free);
            Assert.True(total > 0);
            Assert.True(free <= total);

            // 2. Test Resource Limits
            // Modern GPUs usually have 32768 or 65536 registers per block
            Assert.True(device.RegsPerBlock > 0);
            // Modern GPUs usually have 48KB or more shared memory per block
            Assert.True(device.SharedMemPerBlock > 0);

            // 3. Test Feature Support
            // Every CUDA card supports Compute 1.0 logic
            Assert.True(device.Supports(FeatureSet.Compute10));

            // Check for a specific modern feature (might be false on very old cards)
            bool hasDouble = device.Supports(FeatureSet.NativeDouble);
            Assert.True(hasDouble || !hasDouble); // Verify call succeeds
        }

        [Fact]
        public void DeviceInfo_Alignment_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Alignment values are hardware constants and should always be non-zero (usually powers of 2)
            Assert.True(device.TextureAlignment > 0);
            Assert.True(device.TexturePitchAlignment > 0);
            Assert.True(device.SurfaceAlignment > 0);

            // TCC Driver is typically false on consumer (GeForce) cards
            bool isTcc = device.TccDriver;

            // Log info for environment awareness
            Console.WriteLine($"Texture Alignment: {device.TextureAlignment} bytes");
            Console.WriteLine($"TCC Driver Enabled: {isTcc}");
        }

        [Fact]
        public void DeviceInfo_MemoryAndWarp_Test()
        {
            VerifyCudaSupport();

            using var device = new DeviceInfo(0);

            // Warp size is a mathematical constant in CUDA (currently always 32)
            Assert.Equal(32, device.WarpSize);

            // Global memory should be reported in bytes (e.g. 8GB card will report ~8.5 billion)
            Assert.True(device.TotalGlobalMem > 0);
            Assert.Equal(device.TotalGlobalMem, device.TotalMemory);

            // Constant memory is usually 65536 bytes (64KB)
            Assert.True(device.TotalConstMem >= 65536);

            // Unified addressing is supported on most cards since Fermi/Kepler
            bool ua = device.UnifiedAddressing;

            // Diagnostic output
            Console.WriteLine($"VRAM: {device.TotalGlobalMem / 1024 / 1024} MB");
            Console.WriteLine($"Unified Addressing: {ua}");
        }
    }
}
