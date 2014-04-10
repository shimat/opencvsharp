using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public class BFMatcher : DescriptorMatcher
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="normType"></param>
        /// <param name="crossCheck"></param>
        public BFMatcher(NormType normType = NormType.L2, bool crossCheck = false)
        {
            ptr = NativeMethods.features2d_BFMatcher_new((int)normType, crossCheck ? 1 : 0);
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
        /// Releases the resources
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
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (ptr != IntPtr.Zero)
                        NativeMethods.features2d_BFMatcher_delete(ptr);
                    ptr = IntPtr.Zero;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Return true if the matcher supports mask in match methods.
        /// </summary>
        /// <returns></returns>
        public override bool IsMaskSupported()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_BFMatcher_isMaskSupported(ptr) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public override AlgorithmInfo Info
        {
            get
            {
                ThrowIfDisposed();
                IntPtr pInfo = NativeMethods.features2d_BFMatcher_info(ptr);
                return new AlgorithmInfo(pInfo);
            }
        }
        #endregion
    }
}
