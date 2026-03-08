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
        : base(null)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SearchParams_new(checks, eps, sorted ? 1 : 0, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(SearchParams)}");

        PtrObj = new Ptr(p);
        SetSafeHandle(new OpenCvPtrSafeHandle(PtrObj.Get(), ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// 
    /// </summary>
    protected SearchParams(OpenCvSharp.Ptr ptrObj)
        : base(ptrObj)
    {
    }

    internal sealed new class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr, static h => NativeMethods.HandleException(NativeMethods.flann_Ptr_SearchParams_delete(h)))
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_SearchParams_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }
}
