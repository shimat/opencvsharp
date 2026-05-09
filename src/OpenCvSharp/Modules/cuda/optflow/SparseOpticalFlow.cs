#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Base class for sparse optical flow algorithms.
    /// </summary>
    public abstract class SparseOpticalFlow : Algorithm
    {
        protected SparseOpticalFlow(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
            : base(smartPtr, rawPtr, release)
        {
        }

        /// <summary>
        /// Calculates a sparse optical flow.
        /// </summary>
        /// <param name="prevImg">First input image.</param>
        /// <param name="nextImg">Second input image.</param>
        /// <param name="prevPts">Vector of 2D points for which the flow needs to be found.</param>
        /// <param name="nextPts">Output vector of 2D points containing the calculated new positions.</param>
        /// <param name="status">Output status vector (char). 1 if flow found, 0 otherwise.</param>
        /// <param name="err">Output vector of errors.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void Calc(
            OpenCvSharp.Cuda.InputArray prevImg,
            OpenCvSharp.Cuda.InputArray nextImg,
            OpenCvSharp.Cuda.InputArray prevPts,
            OpenCvSharp.Cuda.OutputArray nextPts,
            OpenCvSharp.Cuda.OutputArray status,
            OpenCvSharp.Cuda.OutputArray? err = null,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (prevImg == null) throw new ArgumentNullException(nameof(prevImg));
            if (nextImg == null) throw new ArgumentNullException(nameof(nextImg));
            if (prevPts == null) throw new ArgumentNullException(nameof(prevPts));
            if (nextPts == null) throw new ArgumentNullException(nameof(nextPts));
            if (status == null) throw new ArgumentNullException(nameof(status));

            prevImg.ThrowIfDisposed();
            nextImg.ThrowIfDisposed();
            prevPts.ThrowIfDisposed();
            nextPts.ThrowIfNotReady();
            status.ThrowIfNotReady();
            err?.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_SparseOpticalFlow_calc(
                    RawPtr, prevImg.CvPtr, nextImg.CvPtr, prevPts.CvPtr, nextPts.CvPtr,
                    status.CvPtr, err?.CvPtr ?? IntPtr.Zero,stream?.CvPtr??IntPtr.Zero));

            nextPts.Fix();
            status.Fix();
            err?.Fix();

            GC.KeepAlive(this);
            GC.KeepAlive(prevImg);
            GC.KeepAlive(nextImg);
            GC.KeepAlive(prevPts);
        }
    }
}
#endif
