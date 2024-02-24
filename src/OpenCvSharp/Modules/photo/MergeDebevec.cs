using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The resulting HDR image is calculated as weighted average of the exposures considering exposure
/// values and camera response.
///
/// For more information see @cite DM97 .
/// </summary>
public sealed class MergeDebevec : MergeExposures
{
    private Ptr? ptrObj;

    /// <summary>
    /// Creates instance by MergeDebevec*
    /// </summary>
    private MergeDebevec(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static MergeDebevec Create()
    {
        var ptr = NativeMethods.photo_createMergeDebevec();
        return new MergeDebevec(ptr);
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
            var res = NativeMethods.photo_Ptr_MergeDebevec_get(ptr);
            GC.KeepAlive(this);
            return res;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.photo_Ptr_MergeDebevec_delete(ptr);
            base.DisposeUnmanaged();
        }
    }
}
