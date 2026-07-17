using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Kind of timelapse to build (see <see cref="Timelapser"/>).
/// </summary>
public enum TimelapserType
{
    /// <summary>
    /// Each frame is composited as-is, without cropping to the common overlap region.
    /// </summary>
    AsIs = 0,

    /// <summary>
    /// Each frame is cropped to the common overlap region before compositing.
    /// </summary>
    Crop = 1,
}

/// <summary>
/// Base class for timelapse composition. Takes a sequence of images, applies the appropriate shift,
/// and stores the result.
/// </summary>
public class Timelapser : CvPtrObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="smartPtr">cv::Ptr&lt;cv::detail::Timelapser&gt;*</param>
    /// <param name="rawPtr">cv::detail::Timelapser*</param>
    private Timelapser(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr,
            p => NativeMethods.HandleException(NativeMethods.stitching_Ptr_Timelapser_delete(p)))
    {
    }

    /// <summary>
    /// Creates a timelapser of the given kind.
    /// </summary>
    /// <param name="type">Kind of timelapse to build</param>
    public static Timelapser CreateDefault(TimelapserType type)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_Timelapser_createDefault((int)type, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.stitching_Ptr_Timelapser_get(smartPtr, out var rawPtr));
        return new Timelapser(smartPtr, rawPtr);
    }

    /// <summary>
    /// Prepares the timelapser for a sequence of images with the given corners and sizes in the
    /// destination image plane.
    /// </summary>
    /// <param name="corners">Top-left corners of the source images in the destination plane</param>
    /// <param name="sizes">Sizes of the source images</param>
    public void Initialize(IReadOnlyList<Point> corners, IReadOnlyList<Size> sizes)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(corners);
        ArgumentNullException.ThrowIfNull(sizes);

        var cornersArray = corners as Point[] ?? [.. corners];
        var sizesArray = sizes as Size[] ?? [.. sizes];
        NativeMethods.HandleException(
            NativeMethods.stitching_Timelapser_initialize(
                Handle, cornersArray, cornersArray.Length, sizesArray, sizesArray.Length));
    }

    /// <summary>
    /// Composites the given image into the timelapse at the given position.
    /// </summary>
    /// <param name="img">Source image</param>
    /// <param name="mask">Mask indicating valid pixels of the source image</param>
    /// <param name="tl">Top-left corner of the source image in the destination plane</param>
    public void Process(InputArray img, InputArray mask, Point tl)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.stitching_Timelapser_process(Handle, img.Proxy, mask.Proxy, tl));
        GC.KeepAlive(img.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Gets the composited destination image.
    /// </summary>
    public Mat GetDst()
    {
        ThrowIfDisposed();
        var dst = new Mat();
        NativeMethods.HandleException(
            NativeMethods.stitching_Timelapser_getDst(Handle, dst.CvPtr));
        return dst;
    }
}
