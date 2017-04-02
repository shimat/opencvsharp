using System;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public class SearchParams : IndexParams
    {
        /// <summary>
        /// 
        /// </summary>
        protected SearchParams()
        {
            PtrObj = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private SearchParams(IntPtr p)
            : base()
        {
            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
        /// <param name="sorted"></param>
        public static SearchParams Create(int checks = 32, float eps = 0.0f, bool sorted = true)
        {
            IntPtr p = NativeMethods.flann_Ptr_SearchParams_new(checks, eps, sorted ? 1 : 0);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(SearchParams)}");

            return new SearchParams(p);
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
                return NativeMethods.flann_Ptr_SearchParams_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.flann_Ptr_SearchParams_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
