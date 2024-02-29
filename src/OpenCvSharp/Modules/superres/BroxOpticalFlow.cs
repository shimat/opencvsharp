using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
// ReSharper disable once IdentifierTypo
public class BroxOpticalFlow : DenseOpticalFlowExt
{
    /// <summary>
    /// 
    /// </summary>
    private Ptr? detectorPtr;

    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once IdentifierTypo
    private BroxOpticalFlow()
    {
        detectorPtr = null;
        ptr = IntPtr.Zero;
    }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static BroxOpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        var ptrObj = new Ptr(ptr);
        var obj = new BroxOpticalFlow
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
    public double Alpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_getAlpha(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setAlpha(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double Gamma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_getGamma(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setGamma(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_getScaleFactor(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setScaleFactor(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int InnerIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_getInnerIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setInnerIterations(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int OuterIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_getOuterIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setOuterIterations(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int SolverIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_getSolverIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setSolverIterations(ptr, value));
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
                NativeMethods.superres_Ptr_BroxOpticalFlow_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_BroxOpticalFlow_delete(ptr));
            Dispose();
        }
    }
}
