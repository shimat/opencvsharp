using System;
using Xunit;
using OpenCvSharp;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;

namespace OpenCvSharp.Tests.Cuda
{
    public class CudaBufferPoolTests : CudaTestBase
    {
        [Fact]
        public void BufferPool_GetBufferTest()
        {
            VerifyCudaSupport();

            // 1. Arrange: Create a stream and a pool for that stream
            using var stream = new OpenCvSharp.Cuda.Stream();
            using var pool = new BufferPool(stream);

            // 2. Act: Request a buffer from the pool
            // 640x480, 3-channel 8-bit
            using var gpuMat = pool.GetBuffer(480, 640, MatType.CV_8UC3);

            // 3. Assert
            Assert.NotNull(gpuMat);
            Assert.False(gpuMat.Empty());
            Assert.Equal(480, gpuMat.Rows);
            Assert.Equal(640, gpuMat.Cols);
            Assert.Equal(MatType.CV_8UC3, gpuMat.Type());

            // 4. Verify usage
            gpuMat.SetTo(new Scalar(255, 0, 0),null, stream);
            stream.WaitForCompletion();

            using var cpuMat = new Mat();
            gpuMat.Download(cpuMat);
            Assert.Equal(255, cpuMat.At<Vec3b>(0, 0).Item0);
        }

        [Fact]
        public void BufferPool_GetAllocator_Test()
        {
            VerifyCudaSupport();

            using var stream = new OpenCvSharp.Cuda.Stream();
            using var pool = new BufferPool(stream);

            IntPtr allocator = pool.GetAllocator();
            Assert.NotEqual(IntPtr.Zero, allocator);
        }
    }
}
