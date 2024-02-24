using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace OpenCvSharp;

/// <summary>
/// Contrast Limited Adaptive Histogram Equalization
/// </summary>
public sealed class CLAHE : Algorithm
{
    /// <summary>
    /// cv::Ptr&lt;CLAHE&gt;
    /// </summary>
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    private CLAHE(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates a predefined CLAHE object
    /// </summary>
    /// <param name="clipLimit"></param>
    /// <param name="tileGridSize"></param>
    /// <returns></returns>
    public static CLAHE Create(double clipLimit = 40.0, Size? tileGridSize = null)
    {
        var tileGridSizeValue = tileGridSize.GetValueOrDefault(new Size(8, 8));
        NativeMethods.HandleException(
            NativeMethods.imgproc_createCLAHE(
                clipLimit, tileGridSizeValue, out var ptr));
        return new CLAHE(ptr);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// Equalizes the histogram of a grayscale image using Contrast Limited Adaptive Histogram Equalization.
    /// </summary>
    /// <param name="src">Source image of type CV_8UC1 or CV_16UC1.</param>
    /// <param name="dst">Destination image.</param>
    public void Apply(InputArray src, OutputArray dst)
    {
        ThrowIfDisposed();
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.imgproc_CLAHE_apply(ptr, src.CvPtr, dst.CvPtr));

        dst.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// Gets or sets threshold for contrast limiting.
    /// </summary>
    public double ClipLimit
    {
        get
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_CLAHE_getClipLimit(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_CLAHE_setClipLimit(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets size of grid for histogram equalization. Input image will be divided into equally sized rectangular tiles.
    /// </summary>
    public Size TilesGridSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_CLAHE_getTilesGridSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_CLAHE_setTilesGridSize(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public void CollectGarbage()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_CLAHE_collectGarbage(ptr));
        GC.KeepAlive(this);
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_Ptr_CLAHE_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_Ptr_CLAHE_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
