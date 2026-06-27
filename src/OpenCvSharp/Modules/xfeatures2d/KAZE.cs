using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

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
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_KAZE_delete(p)))
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
            NativeMethods.xfeatures2d_KAZE_create(
                extended ? 1 : 0, upright ? 1 : 0, threshold,
                nOctaves, nOctaveLayers, (int) diffusivity, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
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
                NativeMethods.xfeatures2d_KAZE_getDiffusivity(Handle, out var ret));
            return (KAZEDiffusivityType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_KAZE_setDiffusivity(Handle, (int)value));
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
                NativeMethods.xfeatures2d_KAZE_getExtended(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_KAZE_setExtended(Handle, value ? 1 : 0));
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
                NativeMethods.xfeatures2d_KAZE_getNOctaveLayers(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_KAZE_setNOctaveLayers(Handle, value));
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
                NativeMethods.xfeatures2d_KAZE_getNOctaves(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_KAZE_setNOctaves(Handle, value));
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
                NativeMethods.xfeatures2d_KAZE_getThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_KAZE_setThreshold(Handle, value));
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
                NativeMethods.xfeatures2d_KAZE_getUpright(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_KAZE_setUpright(Handle, value ? 1 : 0));
        }
    }
}
