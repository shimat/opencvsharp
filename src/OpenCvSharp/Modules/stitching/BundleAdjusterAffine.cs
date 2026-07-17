using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Bundle adjuster that expects an affine transformation represented in homogeneous coordinates in R
/// for each camera parameter. Estimates all transformation parameters; the refinement mask is ignored.
/// </summary>
public class BundleAdjusterAffine : BundleAdjusterBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public BundleAdjusterAffine() : base(Create())
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterAffine_new(out var ptr));
        return ptr;
    }
}
