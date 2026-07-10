using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing the locally uniform comparison image descriptor, described in @cite LUCID.
/// 
/// An image descriptor that can be computed very fast, while being 
/// about as robust as, for example, SURF or BRIEF.
/// @note It requires a color image as input.
/// </summary>
// ReSharper disable once InconsistentNaming
public class LUCID : Feature2D
{
    /// <summary>
    /// 
    /// </summary>
    private LUCID(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_LUCID_delete(p)))
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="lucidKernel">kernel for descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth</param>
    /// <param name="blurKernel">kernel for blurring image prior to descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth</param>
    public static LUCID Create(int lucidKernel = 1, int blurKernel = 2)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_LUCID_create(
                lucidKernel, blurKernel, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_LUCID_get(ptr, out var rawPtr));
        return new LUCID(ptr, rawPtr);
    }

    /// <summary>
    /// Kernel for descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth.
    /// </summary>
    public int LucidKernel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_LUCID_getLucidKernel(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_LUCID_setLucidKernel(Handle, value));
        }
    }

    /// <summary>
    /// Kernel for blurring image prior to descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth.
    /// </summary>
    public int BlurKernel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_LUCID_getBlurKernel(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_LUCID_setBlurKernel(Handle, value));
        }
    }
}
