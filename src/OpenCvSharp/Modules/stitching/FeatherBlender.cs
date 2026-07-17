using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Simple blender which mixes images at its borders.
/// </summary>
public class FeatherBlender : Blender
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sharpness"></param>
    public FeatherBlender(float sharpness = 0.02f) : base(Create(sharpness), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_FeatherBlender_delete(h)))
    {
    }

    private static IntPtr Create(float sharpness)
    {
        NativeMethods.HandleException(NativeMethods.stitching_FeatherBlender_new(sharpness, out var ptr));
        return ptr;
    }

    /// <summary>
    /// Sharpness of the blending border.
    /// </summary>
    public float Sharpness
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_FeatherBlender_getSharpness(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_FeatherBlender_setSharpness(Handle, value));
        }
    }

    /// <summary>
    /// Creates weight maps for a fixed set of source images by their masks and top-left corners.
    /// The final image can be obtained by simple weighting of the source images.
    /// </summary>
    /// <param name="masks">Source image masks</param>
    /// <param name="corners">Source image top-left corners</param>
    /// <param name="weightMaps">Weight maps, one per source image</param>
    /// <returns>The region of interest covered by the weight maps</returns>
    public Rect CreateWeightMaps(IEnumerable<Mat> masks, IReadOnlyList<Point> corners, IEnumerable<Mat> weightMaps)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(masks);
        ArgumentNullException.ThrowIfNull(corners);
        ArgumentNullException.ThrowIfNull(weightMaps);

        var masksArray = masks as Mat[] ?? [.. masks];
        var cornersArray = corners as Point[] ?? [.. corners];
        var weightMapsArray = weightMaps as Mat[] ?? [.. weightMaps];
        var masksPtrs = masksArray.Select(m => m.CvPtr).ToArray();
        var weightMapsPtrs = weightMapsArray.Select(m => m.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.stitching_FeatherBlender_createWeightMaps(
                Handle,
                masksPtrs, masksPtrs.Length,
                cornersArray, cornersArray.Length,
                weightMapsPtrs, weightMapsPtrs.Length,
                out var roi));

        GC.KeepAlive(masksArray);
        GC.KeepAlive(weightMapsArray);
        return roi;
    }
}
