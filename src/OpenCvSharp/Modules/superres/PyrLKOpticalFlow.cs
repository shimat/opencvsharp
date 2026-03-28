using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
public class PyrLKOpticalFlow : DenseOpticalFlowExt
{
    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private PyrLKOpticalFlow()
    {
    }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static PyrLKOpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        var obj = new PyrLKOpticalFlow();
        obj.SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.superres_Ptr_PyrLKOpticalFlow_delete(ptr))));
        return obj;
    }

    #endregion
        
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int WindowSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_PyrLKOpticalFlow_getWindowSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_PyrLKOpticalFlow_setWindowSize(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int MaxLevel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_PyrLKOpticalFlow_getMaxLevel(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_PyrLKOpticalFlow_setMaxLevel(ptr, value));
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
                NativeMethods.superres_PyrLKOpticalFlow_getIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_PyrLKOpticalFlow_setIterations(ptr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    }
