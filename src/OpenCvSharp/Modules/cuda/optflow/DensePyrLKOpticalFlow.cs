using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class DensePyrLKOpticalFlow : DenseOpticalFlow
{
    protected DensePyrLKOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_delete(p)))
    {
    }

    public static DensePyrLKOpticalFlow Create(
        Size? winSize = null, int maxLevel = 3, int iters = 30, bool useInitialFlow = false)
    {
        Size win = winSize ?? new Size(13, 13);

        NativeMethods.HandleException(
            NativeMethods.cuda_createDensePyrLKOpticalFlow(
                win, maxLevel, iters, useInitialFlow ? 1 : 0, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_DensePyrLKOpticalFlow_get(smartPtr, out var rawPtr));

        return new DensePyrLKOpticalFlow(smartPtr, rawPtr);
    }

    public int MaxLevel
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_getMaxLevel(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_setMaxLevel(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public int NumIters
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_getNumIters(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_setNumIters(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public bool UseInitialFlow
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_getUseInitialFlow(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val != 0; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_setUseInitialFlow(RawPtr, value ? 1 : 0));
            GC.KeepAlive(this); 
        }
    }

    public Size WinSize
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_getWinSize(RawPtr, out Size val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_DensePyrLKOpticalFlow_setWinSize(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }
}
