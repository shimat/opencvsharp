using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// The "Star" Detector
/// </summary>
public class StarDetector : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    internal StarDetector(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="maxSize"></param>
    /// <param name="responseThreshold"></param>
    /// <param name="lineThresholdProjected"></param>
    /// <param name="lineThresholdBinarized"></param>
    /// <param name="suppressNonmaxSize"></param>
    public static StarDetector Create(
        int maxSize = 45, 
        int responseThreshold = 30, 
        int lineThresholdProjected = 10, 
        int lineThresholdBinarized = 8,
        int suppressNonmaxSize = 5)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_StarDetector_create(
                maxSize, responseThreshold, lineThresholdProjected,
                lineThresholdBinarized, suppressNonmaxSize, out var ret));
        return new StarDetector(ret);
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

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_StarDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_StarDetector_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
