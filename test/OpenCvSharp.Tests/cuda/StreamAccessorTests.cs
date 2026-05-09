using System;
using Xunit;
using OpenCvSharp;
using OpenCvSharp.Cuda;

namespace OpenCvSharp.Tests.Cuda
{
    public class CudaStreamAccessorTests : CudaTestBase
    {
        [Fact]
        public void StreamAccessor_RoundTrip_Test()
        {
            VerifyCudaSupport();

            // 1. Create a managed OpenCV Stream
            using var original = new OpenCvSharp.Cuda.Stream();

            // 2. Act: Extract the hardware handle using the Accessor
            IntPtr rawHandle = StreamAccessor.GetStream(original);
            Assert.NotEqual(IntPtr.Zero, rawHandle);

            // 3. Act: Wrap that handle into a second Stream object
            using var wrapped = StreamAccessor.WrapStream(rawHandle);

            // 4. Assert
            Assert.NotNull(wrapped);
            Assert.NotEqual(IntPtr.Zero, wrapped.CvPtr);

            // Both objects should return the same hardware handle
            Assert.Equal(rawHandle, StreamAccessor.GetStream(wrapped));
        }
    }
}
