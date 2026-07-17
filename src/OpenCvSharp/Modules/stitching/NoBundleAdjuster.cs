using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Stub bundle adjuster that does nothing.
/// </summary>
public class NoBundleAdjuster : BundleAdjusterBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NoBundleAdjuster() : base(Create())
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_NoBundleAdjuster_new(out var ptr));
        return ptr;
    }
}
