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
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features2d_Ptr_FastFeatureDetector_delete(p)))
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
            NativeMethods.features2d_FastFeatureDetector_create(threshold, nonmaxSuppression ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features2d_Ptr_Feature2D_get(smartPtr, out var rawPtr));
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
                NativeMethods.features2d_FastFeatureDetector_getThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_setThreshold(CvPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.features2d_FastFeatureDetector_getNonmaxSuppression(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_setNonmaxSuppression(CvPtr, value ? 1 : 0));
            GC.KeepAlive(this);
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
                NativeMethods.features2d_FastFeatureDetector_getType(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_setType(CvPtr, value));
            GC.KeepAlive(this);
        }
    }
}
