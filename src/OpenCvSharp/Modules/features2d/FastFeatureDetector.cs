using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Detects corners using FAST algorithm by E. Rosten
/// </summary>
public class FastFeatureDetector : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    protected FastFeatureDetector(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Constructs FastFeatureDetector
    /// </summary>
    /// <param name="threshold">threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.</param>
    /// <param name="nonmaxSuppression">if true, non-maximum suppression is applied to detected corners (keypoints).</param>
    public static FastFeatureDetector Create(int threshold = 10, bool nonmaxSuppression = true)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_FastFeatureDetector_create(threshold, nonmaxSuppression ? 1 : 0, out var ptr));
        return new FastFeatureDetector(ptr);
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
    /// 
    /// </summary>
    public int Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_getThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_setThreshold(ptr, value));
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
                NativeMethods.features2d_FastFeatureDetector_getNonmaxSuppression(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_setNonmaxSuppression(ptr, value ? 1 : 0));
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
                NativeMethods.features2d_FastFeatureDetector_getType(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_FastFeatureDetector_setType(ptr, value));
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
                NativeMethods.features2d_Ptr_FastFeatureDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_FastFeatureDetector_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
