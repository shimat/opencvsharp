using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// 
/// </summary>
public class SearchParams : IndexParams
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="checks"></param>
    /// <param name="eps"></param>
    /// <param name="sorted"></param>
    public SearchParams(int checks = 32, float eps = 0.0f, bool sorted = true)
        : this(Create(checks, eps, sorted))
    {
    }

    private SearchParams((IntPtr smartPtr, IntPtr rawPtr) ptrs)
        : base(ptrs.smartPtr, ptrs.rawPtr,
            static h => NativeMethods.HandleException(NativeMethods.flann_Ptr_SearchParams_delete(h)))
    {
    }

    private static (IntPtr smartPtr, IntPtr rawPtr) Create(int checks, float eps, bool sorted)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SearchParams_new(checks, eps, sorted ? 1 : 0, out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(SearchParams)}");
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SearchParams_get(smartPtr, out var rawPtr));
        return (smartPtr, rawPtr);
    }
}
