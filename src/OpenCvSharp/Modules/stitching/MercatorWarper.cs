using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Mercator warper factory class.
/// </summary>
public class MercatorWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MercatorWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_MercatorWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_MercatorWarper_new(out var ptr));
        return ptr;
    }
}
