#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Class computing the optical flow for two images using Brox et al Optical Flow algorithm.
    /// </summary>
    public class BroxOpticalFlow : DenseOpticalFlow
    {
        protected BroxOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_delete(p)))
        {
        }

        public static BroxOpticalFlow Create(
            double alpha = 0.197, double gamma = 50.0, double scaleFactor = 0.8,
            int innerIterations = 5, int outerIterations = 150, int solverIterations = 10)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createBroxOpticalFlow(
                    alpha, gamma, scaleFactor, innerIterations, outerIterations, solverIterations, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_BroxOpticalFlow_get(smartPtr, out var rawPtr));

            return new BroxOpticalFlow(smartPtr, rawPtr);
        }

        public double FlowSmoothness
        {
            get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_getFlowSmoothness(RawPtr, out double val)); GC.KeepAlive(this); return val; }
            set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_setFlowSmoothness(RawPtr, value)); GC.KeepAlive(this); }
        }

        public double GradientConstancyImportance
        {
            get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_getGradientConstancyImportance(RawPtr, out double val)); GC.KeepAlive(this); return val; }
            set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_setGradientConstancyImportance(RawPtr, value)); GC.KeepAlive(this); }
        }

        public int InnerIterations
        {
            get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_getInnerIterations(RawPtr, out int val)); GC.KeepAlive(this); return val; }
            set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_setInnerIterations(RawPtr, value)); GC.KeepAlive(this); }
        }

        public int OuterIterations
        {
            get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_getOuterIterations(RawPtr, out int val)); GC.KeepAlive(this); return val; }
            set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_setOuterIterations(RawPtr, value)); GC.KeepAlive(this); }
        }

        public double PyramidScaleFactor
        {
            get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_getPyramidScaleFactor(RawPtr, out double val)); GC.KeepAlive(this); return val; }
            set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_setPyramidScaleFactor(RawPtr, value)); GC.KeepAlive(this); }
        }

        public int SolverIterations
        {
            get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_getSolverIterations(RawPtr, out int val)); GC.KeepAlive(this); return val; }
            set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BroxOpticalFlow_setSolverIterations(RawPtr, value)); GC.KeepAlive(this); }
        }
    }
}
#endif
