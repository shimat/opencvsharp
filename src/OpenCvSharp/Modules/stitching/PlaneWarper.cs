using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Plane warper factory class.
/// </summary>
public class PlaneWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PlaneWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_PlaneWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_PlaneWarper_new(out var ptr));
        return ptr;
    }
}
