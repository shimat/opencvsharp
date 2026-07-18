using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Implementation of the camera parameters refinement algorithm which minimizes the sum of the
/// reprojection error squares. It can estimate focal length, aspect ratio and principal point.
/// </summary>
public class BundleAdjusterReproj : BundleAdjusterBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public BundleAdjusterReproj() : base(Create())
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterReproj_new(out var ptr));
        return ptr;
    }
}
