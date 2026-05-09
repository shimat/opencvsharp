#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Class providing access to the low-level CUDA stream handle.
    /// </summary>
    public static class StreamAccessor
    {
        /// <summary>
        /// Gets the raw CUDA stream handle from an OpenCV Stream object.
        /// </summary>
        /// <param name="stream">The OpenCV CUDA stream.</param>
        /// <returns>The raw cudaStream_t handle.</returns>
        public static IntPtr GetStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            stream.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_StreamAccessor_getStream(stream.CvPtr, out IntPtr handle));

            GC.KeepAlive(stream);
            return handle;
        }

        /// <summary>
        /// Wraps an existing raw CUDA stream handle into an OpenCV Stream object.
        /// </summary>
        /// <param name="cudaStreamHandle">The raw cudaStream_t handle.</param>
        /// <returns>A new Stream object wrapping the handle.</returns>
        public static Stream WrapStream(IntPtr cudaStreamHandle)
        {
            if (cudaStreamHandle == IntPtr.Zero)
                throw new ArgumentNullException(nameof(cudaStreamHandle));

            NativeMethods.HandleException(
                NativeMethods.cuda_StreamAccessor_wrapStream(cudaStreamHandle, out IntPtr ptr));

            // Uses the public Stream(IntPtr ptr) constructor
            return new Stream(ptr);
        }
    }
}
#endif
