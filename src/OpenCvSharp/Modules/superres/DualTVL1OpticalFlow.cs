using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
public class DualTVL1OpticalFlow : DenseOpticalFlowExt
{
    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private DualTVL1OpticalFlow()
    {
    }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static DualTVL1OpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        var obj = new DualTVL1OpticalFlow();
        NativeMethods.HandleException(NativeMethods.superres_Ptr_DualTVL1OpticalFlow_get(ptr, out var rawPtr));
        obj.SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.superres_Ptr_DualTVL1OpticalFlow_delete(ptr))));
        return obj;
    }

    #endregion
        
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public double Tau
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getTau(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setTau(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double Lambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getLambda(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setLambda(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double Theta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getTheta(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setTheta(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int ScalesNumber
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getScalesNumber(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setScalesNumber(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int WarpingsNumber
    {
        get
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getWarpingsNumber(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setWarpingsNumber(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double Epsilon
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getEpsilon(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setEpsilon(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Iterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setIterations(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public bool UseInitialFlow
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_getUseInitialFlow(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setUseInitialFlow(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }
        
    #endregion

    }
