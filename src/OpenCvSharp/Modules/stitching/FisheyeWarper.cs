using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Fisheye warper factory class.
/// </summary>
public class FisheyeWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public FisheyeWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_FisheyeWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_FisheyeWarper_new(out var ptr));
        return ptr;
    }
}
