using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Voronoi diagram-based seam estimator.
/// </summary>
public class VoronoiSeamFinder : SeamFinder
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VoronoiSeamFinder() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_VoronoiSeamFinder_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_VoronoiSeamFinder_new(out var ptr));
        return ptr;
    }
}
