using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp.XPhoto;

/// <summary>
/// A simple white balance algorithm that works by independently stretching each of the input image channels to the specified range. For increased robustness it ignores the top and bottom p% of pixel values.
/// </summary>
public class SimpleWB : WhiteBalancer
{
    /// <summary>
    /// Constructor
    /// </summary>
    internal SimpleWB(IntPtr p)
    {
        NativeMethods.HandleException(NativeMethods.xphoto_Ptr_SimpleWB_get(p, out var rawPtr));
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.xphoto_Ptr_SimpleWB_delete(p))));
    }

    /// <summary>
    /// Creates an instance of SimpleWB
    /// </summary>
    /// <returns></returns>
    public static SimpleWB Create()
    {
        NativeMethods.HandleException(
            NativeMethods.xphoto_createSimpleWB(out var ptr));
        return new SimpleWB(ptr);
    }

    /// <summary>
    /// Input image range maximum value.
    /// </summary>
    public float InputMax
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_InputMax_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_InputMax_set(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Input image range minimum value.
    /// </summary>
    public float InputMin
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_InputMin_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_InputMin_set(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Output image range maximum value.
    /// </summary>
    public float OutputMax
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_OutputMax_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_OutputMax_set(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Output image range minimum value.
    /// </summary>
    public float OutputMin
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_OutputMin_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_OutputMin_set(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Percent of top/bottom values to ignore.
    /// </summary>
    public float P
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_P_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_SimpleWB_P_set(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Applies white balancing to the input image.
    /// </summary>
    /// <param name="src">Input image</param>
    /// <param name="dst">White balancing result</param>
    public override void BalanceWhite(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
            
        NativeMethods.HandleException(
            NativeMethods.xphoto_SimpleWB_balanceWhite(ptr, src.CvPtr, dst.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        dst.Fix();
    }

    }
