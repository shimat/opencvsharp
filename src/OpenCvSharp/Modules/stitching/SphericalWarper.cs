using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Spherical warper factory class.
/// </summary>
public class SphericalWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SphericalWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_SphericalWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_SphericalWarper_new(out var ptr));
        return ptr;
    }
}
