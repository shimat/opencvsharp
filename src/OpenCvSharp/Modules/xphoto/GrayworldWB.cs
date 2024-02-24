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
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    internal GrayworldWB(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates an instance of GrayworldWB
    /// </summary>
    /// <returns></returns>
    public static GrayworldWB Create()
    {
        NativeMethods.HandleException(
            NativeMethods.xphoto_createGrayworldWB(out var ptr));
        return new GrayworldWB(ptr);
    }

    /// <inheritdoc />
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// Maximum saturation for a pixel to be included in the gray-world assumption.
    /// </summary>
    public float SaturationThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_GrayworldWB_SaturationThreshold_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_GrayworldWB_SaturationThreshold_set(ptr, value));
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
            NativeMethods.xphoto_GrayworldWB_balanceWhite(ptr, src.CvPtr, dst.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        dst.Fix();
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr)
            : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.xphoto_Ptr_GrayworldWB_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.xphoto_Ptr_GrayworldWB_delete(ptr));
            base.DisposeUnmanaged();
        }

    }
}
