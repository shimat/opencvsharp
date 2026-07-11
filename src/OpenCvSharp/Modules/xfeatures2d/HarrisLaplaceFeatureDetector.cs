using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing the Harris-Laplace feature detector.
/// </summary>
public class HarrisLaplaceFeatureDetector : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private HarrisLaplaceFeatureDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_HarrisLaplaceFeatureDetector_delete(p)))
    { }

    /// <summary>
    /// Creates a new implementation instance.
    /// </summary>
    /// <param name="numOctaves">The number of octaves in the scale-space pyramid.</param>
    /// <param name="cornThresh">The threshold for the Harris cornerness measure.</param>
    /// <param name="dogThresh">The threshold for the Difference-of-Gaussians scale selection.</param>
    /// <param name="maxCorners">The maximum number of corners to consider.</param>
    /// <param name="numLayers">The number of intermediate scales per octave.</param>
    public static HarrisLaplaceFeatureDetector Create(
        int numOctaves = 6, float cornThresh = 0.01f, float dogThresh = 0.01f,
        int maxCorners = 5000, int numLayers = 4)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_create(
                numOctaves, cornThresh, dogThresh, maxCorners, numLayers, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_HarrisLaplaceFeatureDetector_get(ptr, out var rawPtr));
        return new HarrisLaplaceFeatureDetector(ptr, rawPtr);
    }

    /// <summary>
    /// The number of octaves in the scale-space pyramid.
    /// </summary>
    public int NumOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_getNumOctaves(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_setNumOctaves(Handle, value));
        }
    }

    /// <summary>
    /// The threshold for the Harris cornerness measure.
    /// </summary>
    public float CornThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_getCornThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_setCornThresh(Handle, value));
        }
    }

    /// <summary>
    /// The threshold for the Difference-of-Gaussians scale selection.
    /// </summary>
    public float DOGThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_getDOGThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_setDOGThresh(Handle, value));
        }
    }

    /// <summary>
    /// The maximum number of corners to consider.
    /// </summary>
    public int MaxCorners
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_getMaxCorners(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_setMaxCorners(Handle, value));
        }
    }

    /// <summary>
    /// The number of intermediate scales per octave.
    /// </summary>
    public int NumLayers
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_getNumLayers(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_HarrisLaplaceFeatureDetector_setNumLayers(Handle, value));
        }
    }
}
