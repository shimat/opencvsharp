using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Pixels are weighted using contrast, saturation and well-exposedness measures, than images are combined using laplacian pyramids.
///
/// The resulting image weight is constructed as weighted average of contrast, saturation and well-exposedness measures.
///
/// The resulting image doesn't require tonemapping and can be converted to 8-bit image by multiplying by 255,
/// but it's recommended to apply gamma correction and/or linear tonemapping.
///
/// For more information see @cite MK07 .
/// </summary>
public sealed class MergeMertens : MergeExposures
{
    /// <summary>
    /// Creates instance by MergeMertens*
    /// </summary>
    private MergeMertens(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.photo_Ptr_MergeMertens_delete(p)))
    { }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static MergeMertens Create()
    {
        NativeMethods.HandleException(NativeMethods.photo_createMergeMertens(out var ptr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_MergeMertens_get(ptr, out var rawPtr));
        return new MergeMertens(ptr, rawPtr);
    }

    /// <summary>
    /// Short version of process, that doesn't take extra arguments.
    /// </summary>
    /// <param name="src">vector of input images</param>
    /// <param name="dst">result image</param>
    public void Process(IEnumerable<Mat> src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        dst.ThrowIfNotReady();

        var srcArray = src.Select(s => s.CvPtr).ToArray();

        NativeMethods.photo_MergeMertens_process(RawPtr, srcArray, srcArray.Length, dst.CvPtr);

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(srcArray);
        dst.Fix();
    }
}
