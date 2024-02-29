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
    private Ptr? ptrObj;

    /// <summary>
    /// Creates instance by MergeMertens*
    /// </summary>
    private MergeMertens(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static MergeMertens Create()
    {
        var ptr = NativeMethods.photo_createMergeMertens();
        return new MergeMertens(ptr);
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

        NativeMethods.photo_MergeMertens_process(ptr, srcArray, srcArray.Length, dst.CvPtr);

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(srcArray);
        dst.Fix();
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    private class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            var res = NativeMethods.photo_Ptr_MergeMertens_get(ptr);
            GC.KeepAlive(this);
            return res;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.photo_Ptr_MergeMertens_delete(ptr);
            base.DisposeUnmanaged();
        }
    }
}
