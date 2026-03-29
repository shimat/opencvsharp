using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Detects corners using the AGAST algorithm
/// </summary>
public class AgastFeatureDetector : Feature2D
{
    /// <summary>
    /// Constructor
    /// </summary>
    private AgastFeatureDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features2d_Ptr_AgastFeatureDetector_delete(p)))
    {
    }

    /// <summary>
    /// The AgastFeatureDetector constructor
    /// </summary>
    /// <param name="threshold">threshold on difference between intensity of the central pixel 
    /// and pixels of a circle around this pixel.</param>
    /// <param name="nonmaxSuppression">if true, non-maximum suppression is applied to detected corners (keypoints).</param>
    /// <param name="type"></param>
    public static AgastFeatureDetector Create(
        int threshold = 10,
        bool nonmaxSuppression = true,
        DetectorType type = DetectorType.OAST_9_16)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_AgastFeatureDetector_create(
                threshold, nonmaxSuppression ? 1 : 0, (int) type, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features2d_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new AgastFeatureDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.
    /// </summary>
    public int Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_getThreshold(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_setThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// if true, non-maximum suppression is applied to detected corners (keypoints).
    /// </summary>
    public int NonmaxSuppression
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_getNonmaxSuppression(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_setNonmaxSuppression(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// type one of the four neighborhoods as defined in the paper
    /// </summary>
    public DetectorType Type
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_getType(RawPtr, out var ret));
            GC.KeepAlive(this);
            return (DetectorType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_setType(RawPtr, (int)value));
            GC.KeepAlive(this);
        }
    }

    #pragma warning disable 1591

    /// <summary>
    /// AGAST type one of the four neighborhoods as defined in the paper
    /// </summary>
    public enum DetectorType
    {
        AGAST_5_8 = 0,
        AGAST_7_12d = 1,
        AGAST_7_12s = 2,
        OAST_9_16 = 3,
    }
}
