using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
public class FarnebackOpticalFlow : DenseOpticalFlowExt
{
    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private FarnebackOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.superres_Ptr_FarnebackOpticalFlow_delete(p)))
    { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static FarnebackOpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        NativeMethods.HandleException(NativeMethods.superres_Ptr_FarnebackOpticalFlow_get(ptr, out var rawPtr));
        return new FarnebackOpticalFlow(ptr, rawPtr);
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
                NativeMethods.superres_FarnebackOpticalFlow_getPyrScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setPyrScale(Handle, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getLevelsNumber(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setLevelsNumber(Handle, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getWindowSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setWindowSize(Handle, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setIterations(Handle, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getPolyN(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setPolyN(Handle, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getPolySigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setPolySigma(Handle, value));
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
                NativeMethods.superres_FarnebackOpticalFlow_getFlags(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_FarnebackOpticalFlow_setFlags(Handle, value));
        }
    }
        
    #endregion

    }
