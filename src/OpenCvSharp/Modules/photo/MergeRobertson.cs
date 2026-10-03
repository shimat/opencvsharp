using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>Merges an exposure sequence into an HDR image using Robertson's method.</summary>
public sealed class MergeRobertson : MergeExposures
{
    private MergeRobertson(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(NativeMethods.photo_Ptr_MergeRobertson_delete(p)))
    {
    }

    /// <summary>Creates a Robertson exposure merger.</summary>
    public static MergeRobertson Create()
    {
        NativeMethods.HandleException(NativeMethods.photo_createMergeRobertson(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_MergeRobertson_get(smartPtr, out var rawPtr));
        return new MergeRobertson(smartPtr, rawPtr);
    }

    /// <summary>Merges images using exposure times and an estimated camera response.</summary>
    public void Process(IEnumerable<Mat> src, OutputArray dst, InputArray times)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        var images = src.ToArray();
        using var input = new VectorOfMat(images);
        NativeMethods.HandleException(NativeMethods.photo_MergeRobertson_process(Handle, input.CvPtr, dst.Proxy, times.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(times.Source);
    }
}
