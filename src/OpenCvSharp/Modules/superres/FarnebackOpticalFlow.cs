using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
public class FarnebackOpticalFlow : DenseOpticalFlowExt
{
    /// <summary>
    /// 
    /// </summary>
    private Ptr? detectorPtr;

    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private FarnebackOpticalFlow()
    {
        detectorPtr = null;
        ptr = IntPtr.Zero;
    }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static FarnebackOpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        var ptrObj = new Ptr(ptr);
        var obj = new FarnebackOpticalFlow
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
    public double PyrScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_getPyrScale(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setPyrScale(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int LevelsNumber
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_getLevelsNumber(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setLevelsNumber(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int WindowSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_getWindowSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setWindowSize(ptr, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setIterations(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int PolyN
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_getPolyN(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setPolyN(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double PolySigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_getPolySigma(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setPolySigma(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Flags
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_getFlags(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setFlags(ptr, value));
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
                NativeMethods.superres_Ptr_FarnebackOpticalFlow_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_FarnebackOpticalFlow_delete(ptr));
            Dispose();
        }
    }
}
