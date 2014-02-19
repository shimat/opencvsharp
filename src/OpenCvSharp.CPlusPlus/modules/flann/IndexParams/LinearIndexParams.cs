using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Flann
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
        #region Field
        /// <summary>
        /// sizeof(cv::flann::LinearIndexParams)
        /// </summary>
        public static readonly new int SizeOf = FlannInvoke.flann_LinearIndexParams_sizeof();

        private bool disposed = false;
        #endregion

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
            ptr = FlannInvoke.flann_LinearIndexParams_construct();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create LinearIndexParams");
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        FlannInvoke.flann_LinearIndexParams_destruct(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
    }
}
