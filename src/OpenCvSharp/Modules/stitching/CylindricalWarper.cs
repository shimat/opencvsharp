using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Cylindrical warper factory class.
/// </summary>
public class CylindricalWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CylindricalWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_CylindricalWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_CylindricalWarper_new(out var ptr));
        return ptr;
    }
}
