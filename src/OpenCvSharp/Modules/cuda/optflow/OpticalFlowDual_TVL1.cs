#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Total Variation L1 optical flow algorithm.
    /// </summary>
    public class OpticalFlowDual_TVL1 : OpenCvSharp.Cuda.DenseOpticalFlow
    {
        protected OpticalFlowDual_TVL1(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_delete(p)))
        {
        }

        public static OpticalFlowDual_TVL1 Create(
            double tau = 0.25, double lambda = 0.15, double theta = 0.3, int nscales = 5, int warps = 5,
            double epsilon = 0.01, int iterations = 300, double scaleStep = 0.8, double gamma = 0.0, bool useInitialFlow = false)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createOpticalFlowDual_TVL1(
                    tau, lambda, theta, nscales, warps, epsilon, iterations, scaleStep, gamma, useInitialFlow ? 1 : 0, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_OpticalFlowDual_TVL1_get(smartPtr, out var rawPtr));

            return new OpticalFlowDual_TVL1(smartPtr, rawPtr);
        }

        public double Epsilon
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getEpsilon(RawPtr, out double val)); 
                GC.KeepAlive(this);
                return val;
            }
            set 
            {
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setEpsilon(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public double Gamma
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getGamma(RawPtr, out double val)); GC.KeepAlive(this); 
                return val; 
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setGamma(RawPtr, value));
                GC.KeepAlive(this); 
            }
        }

        public double Lambda
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getLambda(RawPtr, out double val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setLambda(RawPtr, value));
                GC.KeepAlive(this); 
            }
        }

        public int NumIterations
        {
            get 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getNumIterations(RawPtr, out int val));
                GC.KeepAlive(this);
                return val; 
            }
            set 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setNumIterations(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public int NumScales
        {
            get
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getNumScales(RawPtr, out int val));
                GC.KeepAlive(this);
                return val; 
            }
            set 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setNumScales(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public int NumWarps
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getNumWarps(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val;
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setNumWarps(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public double ScaleStep
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getScaleStep(RawPtr, out double val)); 
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setScaleStep(RawPtr, value));
                GC.KeepAlive(this); 
            }
        }

        public double Tau
        {
            get 
            { ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getTau(RawPtr, out double val));
                GC.KeepAlive(this);
                return val; 
            }
            set
            { ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setTau(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public double Theta
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getTheta(RawPtr, out double val)); 
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setTheta(RawPtr, value));
                GC.KeepAlive(this); 
            }
        }

        public bool UseInitialFlow
        {
            get 
            {
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_getUseInitialFlow(RawPtr, out int val));
                GC.KeepAlive(this); 
                return val != 0; 
            }
            set 
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_OpticalFlowDual_TVL1_setUseInitialFlow(RawPtr, value ? 1 : 0)); 
                GC.KeepAlive(this);
            }
        }
    }
}
#endif
