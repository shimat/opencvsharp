using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Base class for dense optical flow algorithms.
    /// </summary>
    public abstract class DenseOpticalFlow : Algorithm
    {
        /// <summary>
        /// Protected constructor used by derived classes.
        /// </summary>
        protected DenseOpticalFlow(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
            : base(smartPtr, rawPtr, release)
        {
        }

        /// <summary>
        /// Calculates a dense optical flow.
        /// </summary>
        /// <param name="i0">First input image.</param>
        /// <param name="i1">Second input image.</param>
        /// <param name="flow">Computed flow image that has the same size as I0 and type CV_32FC2.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void Calc(
            OpenCvSharp.Cuda.InputArray i0,
            OpenCvSharp.Cuda.InputArray i1,
            OpenCvSharp.Cuda.OutputArray flow,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (i0 == null) throw new ArgumentNullException(nameof(i0));
            if (i1 == null) throw new ArgumentNullException(nameof(i1));
            if (flow == null) throw new ArgumentNullException(nameof(flow));

            i0.ThrowIfDisposed();
            i1.ThrowIfDisposed();
            flow.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_DenseOpticalFlow_calc(
                    RawPtr, i0.CvPtr, i1.CvPtr, flow.CvPtr, stream?.CvPtr??IntPtr.Zero));

            flow.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(i0);
            GC.KeepAlive(i1);
        }
    }
}
