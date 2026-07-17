using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Stub seam estimator which does nothing.
/// </summary>
public class NoSeamFinder : SeamFinder
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NoSeamFinder() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_NoSeamFinder_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_NoSeamFinder_new(out var ptr));
        return ptr;
    }
}
