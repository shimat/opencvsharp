using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
public class DualTVL1OpticalFlow : DenseOpticalFlowExt
{
    /// <summary>
    /// 
    /// </summary>
    private Ptr? detectorPtr;

    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private DualTVL1OpticalFlow()
    {
        detectorPtr = null;
        ptr = IntPtr.Zero;
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

        var ptrObj = new Ptr(ptr);
        var obj = new DualTVL1OpticalFlow
        {
            detectorPtr = ptrObj,
            ptr = ptrObj.Get()
        };
        return obj;
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        detectorPtr?.Dispose();
        detectorPtr = null;
        base.DisposeManaged();
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

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_DualTVL1OpticalFlow_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_DualTVL1OpticalFlow_delete(ptr));
            Dispose();
        }
    }
}
