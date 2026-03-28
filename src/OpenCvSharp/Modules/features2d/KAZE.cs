using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing the KAZE keypoint detector and descriptor extractor
/// </summary>
// ReSharper disable once InconsistentNaming
public class KAZE : Feature2D
{
    /// <summary>
    /// Constructor
    /// </summary>
    private KAZE(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features2d_Ptr_KAZE_delete(p)))
    {
    }

    /// <summary>
    /// The KAZE constructor
    /// </summary>
    /// <param name="extended">Set to enable extraction of extended (128-byte) descriptor.</param>
    /// <param name="upright">Set to enable use of upright descriptors (non rotation-invariant).</param>
    /// <param name="threshold">Detector response threshold to accept point</param>
    /// <param name="nOctaves">Maximum octave evolution of the image</param>
    /// <param name="nOctaveLayers">Default number of sublevels per scale level</param>
    /// <param name="diffusivity">Diffusivity type. DIFF_PM_G1, DIFF_PM_G2, DIFF_WEICKERT or DIFF_CHARBONNIER</param>
    public static KAZE Create(
        bool extended = false, bool upright = false, float threshold = 0.001f,
        int nOctaves = 4, int nOctaveLayers = 4, KAZEDiffusivityType diffusivity = KAZEDiffusivityType.DiffPmG2)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_KAZE_create(
                extended ? 1 : 0, upright ? 1 : 0, threshold,
                nOctaves, nOctaveLayers, (int) diffusivity, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features2d_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new KAZE(smartPtr, rawPtr);
    }

    /// <summary>
    /// 
    /// </summary>
    public KAZEDiffusivityType Diffusivity
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getDiffusivity(CvPtr, out var ret));
            GC.KeepAlive(this);
            return (KAZEDiffusivityType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setDiffusivity(CvPtr, (int)value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool Extended
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getExtended(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setExtended(CvPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public int NOctaveLayers
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getNOctaveLayers(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setNOctaveLayers(CvPtr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public int NOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getNOctaves(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setNOctaves(CvPtr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public double Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public bool Upright
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getUpright(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setUpright(CvPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }
}
