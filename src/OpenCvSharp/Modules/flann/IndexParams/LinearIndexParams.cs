using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// the index will perform a linear, brute-force search.
/// </summary>
public class LinearIndexParams : IndexParams
{
    /// <summary>
    /// Constructor
    /// </summary>
    public LinearIndexParams()
        : base(null)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_LinearIndexParams_new(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(LinearIndexParams)}");

        PtrObj = new Ptr(p);
        ptr = PtrObj.Get();
    }

    /// <summary>
    /// 
    /// </summary>
    protected LinearIndexParams(OpenCvSharp.Ptr ptrObj)
        : base(ptrObj)
    {
    }

    internal new class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_LinearIndexParams_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_LinearIndexParams_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
