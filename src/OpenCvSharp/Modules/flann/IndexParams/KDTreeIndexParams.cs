﻿using System;
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// ランダム kd-tree の集合でインデックスが表現され，これは並列に探索されます．
    /// </summary>
#else
    /// <summary>
    /// When passing an object of this type the index constructed will consist of a set
    /// of randomized kd-trees which will be searched in parallel.
    /// </summary>
#endif
    public class KDTreeIndexParams : IndexParams
    {
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trees">並列な kd-tree の個数．[1..16] の範囲が適切な値です</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trees">The number of parallel kd-trees to use. Good values are in the range [1..16]</param>
#endif
        public KDTreeIndexParams(int trees = 4)
            : base(null)
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_KDTreeIndexParams_new(trees, out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(KDTreeIndexParams)}");

            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        protected KDTreeIndexParams(OpenCvSharp.Ptr ptrObj)
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
                    NativeMethods.flann_Ptr_KDTreeIndexParams_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.flann_Ptr_KDTreeIndexParams_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
