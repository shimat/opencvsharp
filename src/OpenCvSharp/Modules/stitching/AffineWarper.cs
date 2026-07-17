using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Affine warper factory class.
/// </summary>
public class AffineWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public AffineWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_AffineWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_AffineWarper_new(out var ptr));
        return ptr;
    }
}
