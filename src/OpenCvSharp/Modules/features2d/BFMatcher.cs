using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Brute-force descriptor matcher.
/// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
/// </summary>
public class BFMatcher : DescriptorMatcher
{
    private static IntPtr CreateRawPtr(NormTypes normType, bool crossCheck)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_BFMatcher_new((int)normType, crossCheck ? 1 : 0, out var p));
        return p;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="normType"></param>
    /// <param name="crossCheck"></param>
    public BFMatcher(NormTypes normType = NormTypes.L2, bool crossCheck = false)
        : base(CreateRawPtr(normType, crossCheck),
            p => NativeMethods.HandleException(NativeMethods.features2d_BFMatcher_delete(p)))
    { }

    private BFMatcher(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features2d_Ptr_BFMatcher_delete(p)))
    { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal new static BFMatcher FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid cv::Ptr<BFMatcher> pointer");
        NativeMethods.HandleException(NativeMethods.features2d_Ptr_BFMatcher_get(ptr, out var rawPtr));
        return new BFMatcher(ptr, rawPtr);
    }

    /// <summary>
    /// Return true if the matcher supports mask in match methods.
    /// </summary>
    /// <returns></returns>
    public override bool IsMaskSupported()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.features2d_BFMatcher_isMaskSupported(CvPtr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }
}
