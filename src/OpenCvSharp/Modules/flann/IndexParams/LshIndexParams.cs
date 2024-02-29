using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// When using a parameters object of this type the index created uses multi-probe LSH (by Multi-Probe LSH: Efficient Indexing for High-Dimensional Similarity Search by Qin Lv, William Josephson, Zhe Wang, Moses Charikar, Kai Li., Proceedings of the 33rd International Conference on Very Large Data Bases (VLDB). Vienna, Austria. September 2007)
/// </summary>
public class LshIndexParams : IndexParams
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tableNumber">The number of hash tables to use (between 10 and 30 usually).</param>
    /// <param name="keySize">The size of the hash key in bits (between 10 and 20 usually).</param>
    /// <param name="multiProbeLevel">The number of bits to shift to check for neighboring buckets (0 is regular LSH, 2 is recommended).</param>
    public LshIndexParams(int tableNumber, int keySize, int multiProbeLevel)
        : base(null)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_LshIndexParams_new(tableNumber, keySize, multiProbeLevel, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(LshIndexParams)}");

        PtrObj = new Ptr(p);
        ptr = PtrObj.Get();
    }

    /// <summary>
    /// 
    /// </summary>
    protected LshIndexParams(OpenCvSharp.Ptr ptrObj)
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
                NativeMethods.flann_Ptr_LshIndexParams_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_LshIndexParams_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
