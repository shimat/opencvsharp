using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Base class for CUDA Look-up Table.
    /// </summary>
    public class LookUpTable : Algorithm
    {
        protected LookUpTable(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_LookUpTable_delete(p)))
        {
        }

        /// <summary>
        /// Creates implementation for cuda::LookUpTable.
        /// </summary>
        /// <param name="lut">Look-up table. CV_8UC1 or CV_8UC3 types are supported.</param>
        /// <returns></returns>
        public static LookUpTable Create(OpenCvSharp.InputArray lut)
        {
            if (lut == null) throw new ArgumentNullException(nameof(lut));
            lut.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_createLookUpTable(lut.CvPtr, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_LookUpTable_get(smartPtr, out var rawPtr));

            return new LookUpTable(smartPtr, rawPtr);
        }

        /// <summary>
        /// Transforms the source image using the look-up table.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void Transform(
            OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (dst is null) throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_LookUpTable_transform(RawPtr, src.CvPtr, dst.CvPtr, stream?.CvPtr?? IntPtr.Zero));

            dst.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(src);
        }
    }
}
