using OpenCvSharp.Internal;

// ReSharper disable once InconsistentNaming

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// FREAK implementation
/// </summary>
public class FREAK : Feature2D
{
    /// <summary>
    /// 
    /// </summary>
    private FREAK(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_FREAK_delete(p)))
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="orientationNormalized">enable orientation normalization</param>
    /// <param name="scaleNormalized">enable scale normalization</param>
    /// <param name="patternScale">scaling of the description pattern</param>
    /// <param name="nOctaves">number of octaves covered by the detected keypoints</param>
    /// <param name="selectedPairs">(optional) user defined selected pairs</param>
    public static FREAK Create(
        bool orientationNormalized = true,
        bool scaleNormalized = true,
        float patternScale = 22.0f,
        int nOctaves = 4,
        IEnumerable<int>? selectedPairs = null)
    {
        var selectedPairsArray = selectedPairs?.ToArray();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_FREAK_create(
                orientationNormalized ? 1 : 0,
                scaleNormalized ? 1 : 0, patternScale, nOctaves,
                selectedPairsArray, selectedPairsArray?.Length ?? 0, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_FREAK_get(ptr, out var rawPtr));
        return new FREAK(ptr, rawPtr);
    }

    /// <summary>
    /// Enable orientation normalization.
    /// </summary>
    public bool OrientationNormalized
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_getOrientationNormalized(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_setOrientationNormalized(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Enable scale normalization.
    /// </summary>
    public bool ScaleNormalized
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_getScaleNormalized(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_setScaleNormalized(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Scaling of the description pattern.
    /// </summary>
    public double PatternScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_getPatternScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_setPatternScale(Handle, value));
        }
    }

    /// <summary>
    /// Number of octaves covered by the detected keypoints.
    /// </summary>
    public int NOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_getNOctaves(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_FREAK_setNOctaves(Handle, value));
        }
    }
}
