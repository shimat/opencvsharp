#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Class used for calculating a sparse optical flow.
    /// </summary>
    public sealed class SparsePyrLKOpticalFlow : OpenCvSharp.Cuda.SparseOpticalFlow
    {
        private SparsePyrLKOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_delete(p)))
        {
        }

        public static SparsePyrLKOpticalFlow Create(
            Size? winSize = null, int maxLevel = 3, int iters = 30, bool useInitialFlow = false)
        {
            Size win = winSize ?? new Size(21, 21);

            NativeMethods.HandleException(
                NativeMethods.cuda_createSparsePyrLKOpticalFlow(
                    win, maxLevel, iters, useInitialFlow ? 1 : 0, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_SparsePyrLKOpticalFlow_get(smartPtr, out var rawPtr));

            return new SparsePyrLKOpticalFlow(smartPtr, rawPtr);
        }

        public int MaxLevel
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_getMaxLevel(RawPtr, out int val));
                GC.KeepAlive(this);
                return val;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_setMaxLevel(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public int NumIters
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_getNumIters(RawPtr, out int val));
                GC.KeepAlive(this);
                return val;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_setNumIters(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public bool UseInitialFlow
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_getUseInitialFlow(RawPtr, out int val));
                GC.KeepAlive(this);
                return val != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_setUseInitialFlow(RawPtr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        public Size WinSize
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_getWinSize(RawPtr, out Size val));
                GC.KeepAlive(this);
                return val;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_SparsePyrLKOpticalFlow_setWinSize(RawPtr, value));
                GC.KeepAlive(this);
            }
        }
    }
}
#endif
