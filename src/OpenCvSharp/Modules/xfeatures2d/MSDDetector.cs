using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing the MSD (Maximal Self-Dissimilarity) keypoint detector.
/// </summary>
public class MSDDetector : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private MSDDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_MSDDetector_delete(p)))
    { }

    /// <summary>
    /// Creates the MSD detector.
    /// </summary>
    /// <param name="patchRadius">Patch radius.</param>
    /// <param name="searchAreaRadius">Search area radius.</param>
    /// <param name="nmsRadius">Non maxima suppression radius.</param>
    /// <param name="nmsScaleRadius">Non maxima suppression radius in scale space.</param>
    /// <param name="thSaliency">Saliency threshold.</param>
    /// <param name="kNN">Number of nearest neighbors.</param>
    /// <param name="scaleFactor">Scale factor for building up the scale pyramid.</param>
    /// <param name="nScales">Number of scales for the scale pyramid (-1 = auto).</param>
    /// <param name="computeOrientation">Flag to compute the keypoints orientation.</param>
    public static MSDDetector Create(
        int patchRadius = 3, int searchAreaRadius = 5, int nmsRadius = 5, int nmsScaleRadius = 0,
        float thSaliency = 250.0f, int kNN = 4, float scaleFactor = 1.25f, int nScales = -1,
        bool computeOrientation = false)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_MSDDetector_create(
                patchRadius, searchAreaRadius, nmsRadius, nmsScaleRadius, thSaliency,
                kNN, scaleFactor, nScales, computeOrientation ? 1 : 0, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_MSDDetector_get(ptr, out var rawPtr));
        return new MSDDetector(ptr, rawPtr);
    }

    /// <summary>
    /// Patch radius.
    /// </summary>
    public int PatchRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getPatchRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setPatchRadius(Handle, value));
        }
    }

    /// <summary>
    /// Search area radius.
    /// </summary>
    public int SearchAreaRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getSearchAreaRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setSearchAreaRadius(Handle, value));
        }
    }

    /// <summary>
    /// Non maxima suppression radius.
    /// </summary>
    public int NmsRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getNmsRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setNmsRadius(Handle, value));
        }
    }

    /// <summary>
    /// Non maxima suppression radius in scale space.
    /// </summary>
    public int NmsScaleRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getNmsScaleRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setNmsScaleRadius(Handle, value));
        }
    }

    /// <summary>
    /// Saliency threshold.
    /// </summary>
    public float ThSaliency
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getThSaliency(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setThSaliency(Handle, value));
        }
    }

    /// <summary>
    /// Number of nearest neighbors.
    /// </summary>
    public int KNN
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getKNN(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setKNN(Handle, value));
        }
    }

    /// <summary>
    /// Scale factor for building up the scale pyramid.
    /// </summary>
    public float ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getScaleFactor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setScaleFactor(Handle, value));
        }
    }

    /// <summary>
    /// Number of scales for the scale pyramid (-1 = auto).
    /// </summary>
    public int NScales
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getNScales(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setNScales(Handle, value));
        }
    }

    /// <summary>
    /// Flag to compute the keypoints orientation.
    /// </summary>
    public bool ComputeOrientation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_getComputeOrientation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_MSDDetector_setComputeOrientation(Handle, value ? 1 : 0));
        }
    }
}
