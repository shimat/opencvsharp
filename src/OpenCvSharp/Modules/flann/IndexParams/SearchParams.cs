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
        : base(Create(checks, eps, sorted), static h => NativeMethods.flann_Ptr_SearchParams_delete(h))
    {
    }

    private static IntPtr Create(int checks, float eps, bool sorted)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SearchParams_new(checks, eps, sorted ? 1 : 0, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(SearchParams)}");
        return p;
    }
}
