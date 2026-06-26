using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// 
/// </summary>
// ReSharper disable once IdentifierTypo
public class BroxOpticalFlow : DenseOpticalFlowExt
{
    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private BroxOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.superres_Ptr_BroxOpticalFlow_delete(p)))
    { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static BroxOpticalFlow FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid pointer");

        NativeMethods.HandleException(NativeMethods.superres_Ptr_BroxOpticalFlow_get(ptr, out var rawPtr));
        return new BroxOpticalFlow(ptr, rawPtr);
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
                NativeMethods.superres_BroxOpticalFlow_getAlpha(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setAlpha(Handle, value));
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
                NativeMethods.superres_BroxOpticalFlow_getGamma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setGamma(Handle, value));
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
                NativeMethods.superres_BroxOpticalFlow_getScaleFactor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setScaleFactor(Handle, value));
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
                NativeMethods.superres_BroxOpticalFlow_getInnerIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setInnerIterations(Handle, value));
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
                NativeMethods.superres_BroxOpticalFlow_getOuterIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setOuterIterations(Handle, value));
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
                NativeMethods.superres_BroxOpticalFlow_getSolverIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_BroxOpticalFlow_setSolverIterations(Handle, value));
        }
    }
        
    #endregion

    }
