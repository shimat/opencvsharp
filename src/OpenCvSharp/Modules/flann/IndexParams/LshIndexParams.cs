using System;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// Multi-Probe LSH を使用したインデックスが表現されます．
    /// </summary>
#else
    /// <summary>
    /// When using a parameters object of this type the index created uses multi-probe LSH (by Multi-Probe LSH: Efficient Indexing for High-Dimensional Similarity Search by Qin Lv, William Josephson, Zhe Wang, Moses Charikar, Kai Li., Proceedings of the 33rd International Conference on Very Large Data Bases (VLDB). Vienna, Austria. September 2007)
    /// </summary>
#endif
    public class LshIndexParams : IndexParams
    {
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableNumber">使用するハッシュテーブルの数 (通常、10 から 30)</param>
        /// <param name="keySize">ビットで表現されるハッシュキーのサイズ (通常、10 から 20)</param>
        /// <param name="multiProbeLevel">近接するバケツのチェックのためにシフトするビットの数 (0 は LSH の標準、推奨は 2)</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableNumber">The number of hash tables to use (between 10 and 30 usually).</param>
        /// <param name="keySize">The size of the hash key in bits (between 10 and 20 usually).</param>
        /// <param name="multiProbeLevel">The number of bits to shift to check for neighboring buckets (0 is regular LSH, 2 is recommended).</param>
#endif
        public LshIndexParams(int tableNumber, int keySize, int multiProbeLevel)
            : base(null)
        {
            IntPtr p = NativeMethods.flann_Ptr_LshIndexParams_new(tableNumber, keySize, multiProbeLevel);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(AutotunedIndexParams)}");

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
                var res = NativeMethods.flann_Ptr_LshIndexParams_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.flann_Ptr_LshIndexParams_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
