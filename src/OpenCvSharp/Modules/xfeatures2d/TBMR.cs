using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing the Tree Based Morse Regions (TBMR) detector, extended with scaled
/// extraction ability. Extends AffineFeature2D (mirroring cv::xfeatures2d::TBMR : AffineFeature2D),
/// so DetectElliptic/DetectAndComputeElliptic are available in addition to the plain Feature2D API.
/// </summary>
public class TBMR : AffineFeature2D
{
    /// <summary>
    ///
    /// </summary>
    private TBMR(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_TBMR_delete(p)))
    { }

    /// <summary>
    /// Creates the TBMR detector.
    /// </summary>
    /// <param name="minArea">Prune areas smaller than minArea.</param>
    /// <param name="maxAreaRelative">Prune areas bigger than maxArea = maxAreaRelative * input_image_size.</param>
    /// <param name="scaleFactor">Scale factor for scaled extraction.</param>
    /// <param name="nScales">Number of applications of the scale factor (octaves).</param>
    public static TBMR Create(
        int minArea = 60, float maxAreaRelative = 0.01f, float scaleFactor = 1.25f, int nScales = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_TBMR_create(minArea, maxAreaRelative, scaleFactor, nScales, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_TBMR_get(ptr, out var rawPtr));
        return new TBMR(ptr, rawPtr);
    }

    /// <summary>
    /// Prune areas smaller than this value.
    /// </summary>
    public int MinArea
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_getMinArea(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_setMinArea(Handle, value));
        }
    }

    /// <summary>
    /// Prune areas bigger than maxArea = MaxAreaRelative * input_image_size.
    /// </summary>
    public float MaxAreaRelative
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_getMaxAreaRelative(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_setMaxAreaRelative(Handle, value));
        }
    }

    /// <summary>
    /// Scale factor for scaled extraction.
    /// </summary>
    public float ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_getScaleFactor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_setScaleFactor(Handle, value));
        }
    }

    /// <summary>
    /// Number of applications of the scale factor (octaves).
    /// </summary>
    public int NScales
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_getNScales(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_TBMR_setNScales(Handle, value));
        }
    }
}
