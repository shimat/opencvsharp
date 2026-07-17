using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Bundle adjuster that expects an affine transformation with 4 degrees of freedom, represented in
/// homogeneous coordinates in R for each camera parameter. Estimates all transformation parameters;
/// the refinement mask is ignored.
/// </summary>
public class BundleAdjusterAffinePartial : BundleAdjusterBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public BundleAdjusterAffinePartial() : base(Create())
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterAffinePartial_new(out var ptr));
        return ptr;
    }
}
