using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// AGAST 実装
    /// </summary>
#else
    /// <summary>
    /// Detects corners using the AGAST algorithm
    /// </summary>
#endif
    public class AgastFeatureDetector : Feature2D
    {
        private bool disposed;
        private Ptr<AgastFeatureDetector> ptrObj;

#pragma warning disable 1591
        public const int
            AGAST_5_8 = 0,
            AGAST_7_12d = 1,
            AGAST_7_12s = 2,
            OAST_9_16 = 3,
            THRESHOLD = 10000,
            NONMAX_SUPPRESSION = 10001;
#pragma warning restore 1591
        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected AgastFeatureDetector(IntPtr p)
        {
            ptrObj = new Ptr<AgastFeatureDetector>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// The AgastFeatureDetector constructor
        /// </summary>
        /// <param name="threshold">threshold on difference between intensity of the central pixel 
        /// and pixels of a circle around this pixel.</param>
        /// <param name="nonmaxSuppression">if true, non-maximum suppression is applied to detected corners (keypoints).</param>
        /// <param name="type"></param>
        public static AgastFeatureDetector Create( int threshold=10,
                                                     bool nonmaxSuppression=true,
                                                     AGASTType type = AGASTType.OAST_9_16)
        {
            IntPtr ptr = NativeMethods.features2d_AgastFeatureDetector_create(
                threshold, nonmaxSuppression ? 1 : 0, (int)type);
            return new AgastFeatureDetector(ptr);
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

        #region Properties

        /// <summary>
        /// threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.
        /// </summary>
        public int Threshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_AgastFeatureDetector_getThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AgastFeatureDetector_setThreshold(ptr, value);
            }
        }

        /// <summary>
        /// if true, non-maximum suppression is applied to detected corners (keypoints).
        /// </summary>
        public int NonmaxSuppression
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_AgastFeatureDetector_getNonmaxSuppression(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AgastFeatureDetector_setNonmaxSuppression(ptr, value);
            }
        }

        /// <summary>
        /// type one of the four neighborhoods as defined in the paper
        /// </summary>
        public AGASTType Type
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return (AGASTType)NativeMethods.features2d_AgastFeatureDetector_getType(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AgastFeatureDetector_setType(ptr, (int)value);
            }
        }
        
        #endregion

        #region Methods

        #endregion
    }
}
