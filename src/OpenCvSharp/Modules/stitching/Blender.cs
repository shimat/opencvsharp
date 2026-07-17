using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Kind of blender to build (see <see cref="Blender.CreateDefault"/>).
/// </summary>
public enum BlenderType
{
#pragma warning disable 1591
    No,
    Feather,
    MultiBand,
#pragma warning restore 1591
}

/// <summary>
/// Base class for all blenders. Simple blender which puts one image over another.
/// </summary>
public class Blender : CvPtrObject
{
    /// <summary>
    /// Constructor for the factory pattern (used by <see cref="CreateDefault"/>).
    /// </summary>
    private Blender(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr,
            p => NativeMethods.HandleException(NativeMethods.stitching_Ptr_Blender_delete(p)))
    {
    }

    /// <summary>
    /// Constructor for the direct-allocation pattern (used by concrete subclasses with a public constructor).
    /// </summary>
    protected Blender(IntPtr rawPtr, Action<IntPtr> release)
        : base(rawPtr, release)
    {
    }

    /// <summary>
    /// Creates a blender of the given kind.
    /// </summary>
    /// <param name="type">Kind of blender to build</param>
    /// <param name="tryGpu">Should try to use GPU or not</param>
    public static Blender CreateDefault(BlenderType type, bool tryGpu = false)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_Blender_createDefault((int)type, tryGpu ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.stitching_Ptr_Blender_get(smartPtr, out var rawPtr));
        return new Blender(smartPtr, rawPtr);
    }

    /// <summary>
    /// Prepares the blender for blending.
    /// </summary>
    /// <param name="corners">Source images top-left corners</param>
    /// <param name="sizes">Source image sizes</param>
    public void Prepare(IReadOnlyList<Point> corners, IReadOnlyList<Size> sizes)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(corners);
        ArgumentNullException.ThrowIfNull(sizes);

        var cornersArray = corners as Point[] ?? [.. corners];
        var sizesArray = sizes as Size[] ?? [.. sizes];
        NativeMethods.HandleException(
            NativeMethods.stitching_Blender_prepare1(Handle, cornersArray, cornersArray.Length, sizesArray, sizesArray.Length));
    }

    /// <summary>
    /// Prepares the blender for blending.
    /// </summary>
    /// <param name="dstRoi">Final pano region of interest</param>
    public void Prepare(Rect dstRoi)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.stitching_Blender_prepare2(Handle, dstRoi));
    }

    /// <summary>
    /// Processes the image.
    /// </summary>
    /// <param name="img">Source image</param>
    /// <param name="mask">Source image mask</param>
    /// <param name="tl">Source image top-left corner</param>
    public void Feed(InputArray img, InputArray mask, Point tl)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.stitching_Blender_feed(Handle, img.Proxy, mask.Proxy, tl));
        GC.KeepAlive(img.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Blends and returns the final pano.
    /// </summary>
    /// <param name="dst">Final pano</param>
    /// <param name="dstMask">Final pano mask</param>
    public void Blend(InputOutputArray dst, InputOutputArray dstMask)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.stitching_Blender_blend(Handle, dst.Proxy, dstMask.Proxy));
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(dstMask.Source);
    }
}
