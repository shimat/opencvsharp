using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Class computing a fast block-matching optical flow.
    /// </summary>
    public static class FastOpticalFlowBM
    {
        /// <summary>
        /// Computes optical flow using block matching algorithm.
        /// </summary>
        /// <param name="i0">First input image.</param>
        /// <param name="i1">Second input image.</param>
        /// <param name="flowx">Output horizontal flow (CV_32FC1).</param>
        /// <param name="flowy">Output vertical flow (CV_32FC1).</param>
        /// <param name="searchWindow">Search window size.</param>
        /// <param name="blockWindow">Block window size.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Compute(GpuMat i0, GpuMat i1, GpuMat flowx, GpuMat flowy,
            int searchWindow = 21, int blockWindow = 7, Stream? stream = null)
        {
            if (i0 == null)
                throw new ArgumentNullException(nameof(i0));
            if (i1 == null) 
                throw new ArgumentNullException(nameof(i1));
            if (flowx == null)
                throw new ArgumentNullException(nameof(flowx));
            if (flowy == null) 
                throw new ArgumentNullException(nameof(flowy));

            i0.ThrowIfDisposed();
            i1.ThrowIfDisposed();
            flowx.ThrowIfDisposed();
            flowy.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_FastOpticalFlowBM_compute(
                    i0.CvPtr, i1.CvPtr, flowx.CvPtr, flowy.CvPtr,
                    searchWindow, blockWindow, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(i0);
            GC.KeepAlive(i1);
            GC.KeepAlive(flowx);
            GC.KeepAlive(flowy);
        }
    }
}
