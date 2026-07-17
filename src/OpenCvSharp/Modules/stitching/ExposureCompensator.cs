using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Detail;

/// <summary>
/// Kind of exposure compensator to build (see <see cref="ExposureCompensator.CreateDefault"/>).
/// </summary>
public enum ExposureCompensatorType
{
#pragma warning disable 1591
    No,
    Gain,
    GainBlocks,
    Channels,
    ChannelsBlocks,
#pragma warning restore 1591
}

/// <summary>
/// Base class for all exposure compensators.
/// </summary>
public class ExposureCompensator : CvPtrObject
{
    /// <summary>
    /// Constructor for the factory pattern (used by <see cref="CreateDefault"/>).
    /// </summary>
    private ExposureCompensator(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr,
            p => NativeMethods.HandleException(NativeMethods.stitching_Ptr_ExposureCompensator_delete(p)))
    {
    }

    /// <summary>
    /// Constructor for the direct-allocation pattern (used by concrete subclasses with a public constructor).
    /// </summary>
    /// <param name="rawPtr"></param>
    /// <param name="release"></param>
    protected ExposureCompensator(IntPtr rawPtr, Action<IntPtr> release)
        : base(rawPtr, release)
    {
    }

    /// <summary>
    /// Creates an exposure compensator of the given kind.
    /// </summary>
    /// <param name="type">Kind of exposure compensator to build</param>
    public static ExposureCompensator CreateDefault(ExposureCompensatorType type)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_ExposureCompensator_createDefault((int)type, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.stitching_Ptr_ExposureCompensator_get(smartPtr, out var rawPtr));
        return new ExposureCompensator(smartPtr, rawPtr);
    }

    /// <summary>
    /// Updates image masks and computes gains to prepare for exposure compensation.
    /// </summary>
    /// <param name="corners">Source image top-left corners</param>
    /// <param name="images">Source images</param>
    /// <param name="masks">Image masks to update</param>
    public void Feed(IReadOnlyList<Point> corners, IEnumerable<Mat> images, IEnumerable<Mat> masks)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(corners);
        ArgumentNullException.ThrowIfNull(images);
        ArgumentNullException.ThrowIfNull(masks);

        var cornersArray = corners as Point[] ?? [.. corners];
        var imagesArray = images.CastOrToArray();
        var masksArray = masks.CastOrToArray();
        var imagesPtrs = imagesArray.Select(m => m.CvPtr).ToArray();
        var masksPtrs = masksArray.Select(m => m.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.stitching_ExposureCompensator_feed(
                Handle, cornersArray, cornersArray.Length,
                imagesPtrs, imagesPtrs.Length,
                masksPtrs, masksPtrs.Length));

        GC.KeepAlive(imagesArray);
        GC.KeepAlive(masksArray);
    }

    /// <summary>
    /// Compensates exposure in the specified image.
    /// </summary>
    /// <param name="index">Image index</param>
    /// <param name="corner">Image top-left corner</param>
    /// <param name="image">Image to process</param>
    /// <param name="mask">Image mask</param>
    public virtual void Apply(int index, Point corner, InputOutputArray image, InputArray mask)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.stitching_ExposureCompensator_apply(Handle, index, corner, image.Proxy, mask.Proxy));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Gets the gains computed for each fed image.
    /// </summary>
    public Mat[] GetMatGains()
    {
        ThrowIfDisposed();
        using var gains = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.stitching_ExposureCompensator_getMatGains(Handle, gains.CvPtr));
        return gains.ToArray();
    }

    /// <summary>
    /// Sets the gains for each image, in lieu of computing them via <see cref="Feed"/>.
    /// </summary>
    public void SetMatGains(IEnumerable<Mat> gains)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(gains);

        var gainsArray = gains.CastOrToArray();
        var gainsPtrs = gainsArray.Select(m => m.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.stitching_ExposureCompensator_setMatGains(Handle, gainsPtrs, gainsPtrs.Length));
        GC.KeepAlive(gainsArray);
    }

    /// <summary>
    /// Whether gains are recomputed on each <see cref="Feed"/> call.
    /// </summary>
    public bool UpdateGain
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stitching_ExposureCompensator_getUpdateGain(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stitching_ExposureCompensator_setUpdateGain(Handle, value ? 1 : 0));
        }
    }
}
