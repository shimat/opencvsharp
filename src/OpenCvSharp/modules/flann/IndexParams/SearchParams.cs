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
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public SearchParams()
            : this(32, 0.0f, true)
        {
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
#endif
        public SearchParams(int checks)
            : this(checks, 0.0f, true)
        {
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
#endif
        public SearchParams(int checks, float eps)
            : this(checks, eps, true)
        {
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
        /// <param name="sorted"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks"></param>
        /// <param name="eps"></param>
        /// <param name="sorted"></param>
#endif
        public SearchParams(int checks, float eps, bool sorted)
            : base(false)
        {
            ptr = NativeMethods.flann_SearchParams_new(checks, eps, sorted ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create SearchParams");
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.flann_SearchParams_delete(ptr);
            base.DisposeUnmanaged();
        }
    }
}
