#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// BufferPool is a utility class for managing a pool of GpuMat buffers.
    /// </summary>
    public class BufferPool : DisposableGpuObject
    {

        private static IntPtr Create(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            stream.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_BufferPool_new(stream.CvPtr, out var ptr));

            return ptr;
        }

        /// <summary>
        /// Gets the BufferPool for the given stream.
        /// </summary>
        /// <param name="stream"></param>
        public BufferPool(Stream stream)
         : base(Create(stream))
        {
        }

        protected override void DisposeUnmanaged()
        {
            if (ptr != IntPtr.Zero)
            {
                NativeMethods.HandleException(NativeMethods.cuda_BufferPool_delete(ptr));
            }
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Allocates a new GpuMat of given size and type from the pool.
        /// </summary>
        public GpuMat GetBuffer(int rows, int cols, MatType type)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.cuda_BufferPool_getBuffer(ptr, rows, cols, type.Value, out var gpuMatPtr));

            GC.KeepAlive(this);
            return new GpuMat(gpuMatPtr);
        }

        /// <summary>
        /// Allocates a new GpuMat of given size and type from the pool.
        /// </summary>
        public GpuMat GetBuffer(Size size, MatType type)
        {
            return GetBuffer(size.Height, size.Width, type);
        }

        /// <summary>
        /// Returns the allocator associated with the stream.
        /// </summary>
        /// <returns></returns>
        public IntPtr GetAllocator()
        {
            ThrowIfDisposed();
            // Note: Returning as IntPtr for now. 
            // If you need a full GpuMatAllocator class, it would wrap this pointer.
            NativeMethods.HandleException(
                NativeMethods.cuda_BufferPool_getAllocator(ptr, out var allocatorPtr));

            GC.KeepAlive(this);
            return allocatorPtr;
        }
    }
}
#endif
