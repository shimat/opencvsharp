using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Transverse Mercator warper factory class.
/// </summary>
public class TransverseMercatorWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public TransverseMercatorWarper() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_TransverseMercatorWarper_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_TransverseMercatorWarper_new(out var ptr));
        return ptr;
    }
}
