using System;
using System.Collections.Generic;
using System.Text;

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
        private bool disposed = false;

        #region Properties
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
        {
            ptr = NativeMethods.flann_SearchParams_new(checks, eps, sorted ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create SearchParams");
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
                        if (ptr != IntPtr.Zero)
                        {
                            NativeMethods.flann_SearchParams_delete(ptr);
                        }
                        ptr = IntPtr.Zero;
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
