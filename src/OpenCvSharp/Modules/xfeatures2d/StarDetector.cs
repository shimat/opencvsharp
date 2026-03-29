using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// The "Star" Detector
/// </summary>
public class StarDetector : Feature2D
{
    /// <summary>
    /// 
    /// </summary>
    private StarDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_StarDetector_delete(p)))
    { }

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
                lineThresholdBinarized, suppressNonmaxSize, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_StarDetector_get(ptr, out var rawPtr));
        return new StarDetector(ptr, rawPtr);
    }
}
