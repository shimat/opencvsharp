using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// Detects corners using FAST algorithm by E. Rosten
    /// </summary>
#else
    /// <summary>
    /// Detects corners using FAST algorithm by E. Rosten
    /// </summary>
#endif
    public class FastFeatureDetector : Feature2D
    {
        private bool disposed;
        private Ptr<FastFeatureDetector> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected FastFeatureDetector(IntPtr ptr)
        {
            ptrObj = new Ptr<FastFeatureDetector>(ptr);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSuppression"></param>
        public static FastFeatureDetector Create(int threshold = 10, bool nonmaxSuppression = true)
        {
            IntPtr ptr = NativeMethods.features2d_FastFeatureDetector_create(threshold, nonmaxSuppression ? 1 : 0);
            return new FastFeatureDetector(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources
                    
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int Threshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_FastFeatureDetector_getThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_FastFeatureDetector_setThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool NonmaxSuppression
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_FastFeatureDetector_getNonmaxSuppression(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_FastFeatureDetector_setNonmaxSuppression(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_FastFeatureDetector_getType(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_FastFeatureDetector_setType(ptr, value);
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
