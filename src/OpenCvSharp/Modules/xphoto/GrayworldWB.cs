using OpenCvSharp.Internal;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.XPhoto;

/// <summary>
/// Gray-world white balance algorithm.
/// </summary>
public class GrayworldWB : WhiteBalancer
{
    /// <summary>
    /// Constructor
    /// </summary>
    private GrayworldWB(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xphoto_Ptr_GrayworldWB_delete(p)))
    { }
    /// <summary>
    /// Creates an instance of GrayworldWB
    /// </summary>
    /// <returns></returns>
    public static GrayworldWB Create()
    {
        NativeMethods.HandleException(
            NativeMethods.xphoto_createGrayworldWB(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.xphoto_Ptr_GrayworldWB_get(smartPtr, out var rawPtr));
        return new GrayworldWB(smartPtr, rawPtr);
    }

    /// <summary>
    /// Maximum saturation
    /// </summary>
    public float SaturationThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_GrayworldWB_SaturationThreshold_get(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_GrayworldWB_SaturationThreshold_set(CvPtr, value));
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
            NativeMethods.xphoto_GrayworldWB_balanceWhite(CvPtr, src.CvPtr, dst.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        dst.Fix();
    }
}
