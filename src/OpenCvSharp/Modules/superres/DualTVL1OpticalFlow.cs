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
    private DualTVL1OpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.superres_Ptr_DualTVL1OpticalFlow_delete(p)))
    { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static DualTVL1OpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        NativeMethods.HandleException(NativeMethods.superres_Ptr_DualTVL1OpticalFlow_get(ptr, out var rawPtr));
        return new DualTVL1OpticalFlow(ptr, rawPtr);
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
                NativeMethods.superres_DualTVL1OpticalFlow_getTau(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setTau(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setLambda(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getTheta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setTheta(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getScalesNumber(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setScalesNumber(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getWarpingsNumber(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setWarpingsNumber(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getEpsilon(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setEpsilon(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setIterations(Handle, value));
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
                NativeMethods.superres_DualTVL1OpticalFlow_getUseInitialFlow(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_DualTVL1OpticalFlow_setUseInitialFlow(Handle, value ? 1 : 0));
        }
    }
        
    #endregion

    }
