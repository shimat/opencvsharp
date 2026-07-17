using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Stereographic warper factory class.
/// </summary>
public class StereographicWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public StereographicWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_StereographicWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_StereographicWarper_new(out var ptr));
        return ptr;
    }
}
