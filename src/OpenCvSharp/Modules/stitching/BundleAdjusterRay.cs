using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Implementation of the camera parameters refinement algorithm which minimizes the sum of the
/// distances between the rays passing through the camera center and a feature. It can estimate
/// focal length; it ignores the refinement mask.
/// </summary>
public class BundleAdjusterRay : BundleAdjusterBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public BundleAdjusterRay() : base(Create())
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterRay_new(out var ptr));
        return ptr;
    }
}
