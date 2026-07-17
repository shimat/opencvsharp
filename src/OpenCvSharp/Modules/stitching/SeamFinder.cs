using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Detail;

/// <summary>
/// Kind of seam finder to build (see <see cref="SeamFinder.CreateDefault"/>).
/// </summary>
public enum SeamFinderType
{
#pragma warning disable 1591
    No,
    VoronoiSeam,
    DpSeam,
#pragma warning restore 1591
}

/// <summary>
/// Base class for a seam estimator.
/// </summary>
public class SeamFinder : CvPtrObject
{
    /// <summary>
    /// Constructor for the factory pattern (used by <see cref="CreateDefault"/>).
    /// </summary>
    private SeamFinder(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr,
            p => NativeMethods.HandleException(NativeMethods.stitching_Ptr_SeamFinder_delete(p)))
    {
    }

    /// <summary>
    /// Constructor for the direct-allocation pattern (used by concrete subclasses with a public constructor).
    /// </summary>
    protected SeamFinder(IntPtr rawPtr, Action<IntPtr> release)
        : base(rawPtr, release)
    {
    }

    /// <summary>
    /// Creates a seam finder of the given kind.
    /// </summary>
    /// <param name="type">Kind of seam finder to build</param>
    public static SeamFinder CreateDefault(SeamFinderType type)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_SeamFinder_createDefault((int)type, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.stitching_Ptr_SeamFinder_get(smartPtr, out var rawPtr));
        return new SeamFinder(smartPtr, rawPtr);
    }

    /// <summary>
    /// Estimates seams and updates the source masks in place.
    /// </summary>
    /// <param name="src">Source images</param>
    /// <param name="corners">Source image top-left corners</param>
    /// <param name="masks">Source image masks to update</param>
    public virtual void Find(IEnumerable<Mat> src, IReadOnlyList<Point> corners, IEnumerable<Mat> masks)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(corners);
        ArgumentNullException.ThrowIfNull(masks);

        var srcArray = src.CastOrToArray();
        var cornersArray = corners as Point[] ?? [.. corners];
        var masksArray = masks.CastOrToArray();
        var srcPtrs = srcArray.Select(m => m.CvPtr).ToArray();
        var masksPtrs = masksArray.Select(m => m.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.stitching_SeamFinder_find(
                Handle, srcPtrs, srcPtrs.Length, cornersArray, cornersArray.Length, masksPtrs, masksPtrs.Length));

        GC.KeepAlive(srcArray);
        GC.KeepAlive(masksArray);
    }
}
