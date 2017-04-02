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
        internal Ptr PtrObj { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public SearchParams()
            : this(32, 0.0f, true)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        public SearchParams(int checks)
            : this(checks, 0.0f, true)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
        public SearchParams(int checks, float eps)
            : this(checks, eps, true)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
        /// <param name="sorted"></param>
        public SearchParams(int checks, float eps, bool sorted)
        {
            IntPtr p = NativeMethods.flann_Ptr_SearchParams_new(checks, eps, sorted ? 1 : 0);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {GetType().Name}");

            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
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

        internal class Ptr : OpenCvSharp.Ptr
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
