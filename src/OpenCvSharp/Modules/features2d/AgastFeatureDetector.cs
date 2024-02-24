using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Detects corners using the AGAST algorithm
/// </summary>
public class AgastFeatureDetector : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    protected AgastFeatureDetector(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
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
                threshold, nonmaxSuppression ? 1 : 0, (int) type, out var ptr));
        return new AgastFeatureDetector(ptr);
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
    /// threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.
    /// </summary>
    public int Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_getThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_setThreshold(ptr, value));
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
                NativeMethods.features2d_AgastFeatureDetector_getNonmaxSuppression(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_setNonmaxSuppression(ptr, value));
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
                NativeMethods.features2d_AgastFeatureDetector_getType(ptr, out var ret));
            GC.KeepAlive(this);
            return (DetectorType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_AgastFeatureDetector_setType(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }
        
    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_AgastFeatureDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_AgastFeatureDetector_delete(ptr));
            base.DisposeUnmanaged();
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
