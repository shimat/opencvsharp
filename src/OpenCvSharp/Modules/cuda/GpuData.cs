#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Lightweight wrapper for raw GPU memory allocation.
    /// </summary>
    public sealed class GpuData : DisposableGpuObject
    {
        /// <summary>
        /// Allocates a raw buffer of the specified size on the GPU.
        /// </summary>
        /// <param name="size">Size in bytes.</param>
        public GpuData(ulong size)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuData_new(size, out var ptr));

            InitSafeHandle(ptr);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
                static h => NativeMethods.cuda_GpuData_delete(h)));
        }


        /// <summary>
        /// Returns the raw device memory pointer.
        /// </summary>
        public IntPtr Data
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuData_data(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Returns the size of the buffer in bytes.
        /// </summary>
        public ulong Size
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_GpuData_size(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }
    }
}
#endif
