using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// 線形のブルートフォース探索が行われます
    /// </summary>
#else
    /// <summary>
    /// the index will perform a linear, brute-force search.
    /// </summary>
#endif
    public class LinearIndexParams : IndexParams
    {
        /// <summary>
        /// 
        /// </summary>
        protected LinearIndexParams()
            : base()
        {
            PtrObj = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private LinearIndexParams(IntPtr p)
            : base()
        {
            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        public new static LinearIndexParams Create()
        {
            IntPtr p = NativeMethods.flann_Ptr_LinearIndexParams_new();
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(LinearIndexParams)}");

            return new LinearIndexParams(p);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            PtrObj?.Dispose();
            PtrObj = null;
            base.DisposeManaged();
        }

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.flann_Ptr_LinearIndexParams_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.flann_Ptr_LinearIndexParams_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
