#if ENABLED_CUDA
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;


public class FarnebackOpticalFlow : DenseOpticalFlow
{
    protected FarnebackOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
           : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_delete(p)))
    {
    }

    public static FarnebackOpticalFlow Create(
        int numLevels = 5, double pyrScale = 0.5, bool fastPyramids = false,
        int winSize = 13, int numIters = 10, int polyN = 5,
        double polySigma = 1.1, int flags = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createFarnebackOpticalFlow(
                numLevels, pyrScale, fastPyramids ? 1 : 0, winSize,
                numIters, polyN, polySigma, flags, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_FarnebackOpticalFlow_get(smartPtr, out var rawPtr));

        return new FarnebackOpticalFlow(smartPtr, rawPtr);
    }

    public bool FastPyramids
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getFastPyramids(RawPtr, out int val));
            GC.KeepAlive(this);
            return val != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setFastPyramids(RawPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    public int Flags
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getFlags(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set {
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setFlags(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public int NumIters
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getNumIters(RawPtr, out int val)); 
            GC.KeepAlive(this);
            return val;
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setNumIters(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public int NumLevels
    {
        get { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getNumLevels(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setNumLevels(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public int PolyN
    {
        get { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getPolyN(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setPolyN(RawPtr, value));
            GC.KeepAlive(this); 
        }
    }

    public float PolySigma
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getPolySigma(RawPtr, out float val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        {
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setPolySigma(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public float PyrScale
    {
        get 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getPyrScale(RawPtr, out float val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setPyrScale(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public int WinSize
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_getWinSize(RawPtr, out int val));
            GC.KeepAlive(this);
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_FarnebackOpticalFlow_setWinSize(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }
}
#endif
