using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Detects corners using FAST algorithm by E. Rosten
/// </summary>
public class FastFeatureDetector : Feature2D
{
    /// <summary>
    /// Constructor
    /// </summary>
    private FastFeatureDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_FastFeatureDetector_delete(p)))
    {
    }

    /// <summary>
    /// Constructs FastFeatureDetector
    /// </summary>
    /// <param name="threshold">threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.</param>
    /// <param name="nonmaxSuppression">if true, non-maximum suppression is applied to detected corners (keypoints).</param>
    public static FastFeatureDetector Create(int threshold = 10, bool nonmaxSuppression = true)
    {
        NativeMethods.HandleException(
            NativeMethods.features_FastFeatureDetector_create(threshold, nonmaxSuppression ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new FastFeatureDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// 
    /// </summary>
    public int Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_FastFeatureDetector_getThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_FastFeatureDetector_setThreshold(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool NonmaxSuppression
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_FastFeatureDetector_getNonmaxSuppression(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_FastFeatureDetector_setNonmaxSuppression(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Type
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_FastFeatureDetector_getType(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_FastFeatureDetector_setType(Handle, value));
        }
    }
}
