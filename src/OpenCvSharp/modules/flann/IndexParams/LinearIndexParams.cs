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
        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public LinearIndexParams()
        {
            ptr = NativeMethods.flann_LinearIndexParams_new();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create LinearIndexParams");
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.flann_LinearIndexParams_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion
    }
}
