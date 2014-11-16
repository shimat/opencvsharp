using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// ORB 実装
    /// </summary>
#else
    /// <summary>
    /// ORB implementation
    /// </summary>
#endif
    public class ORB : Feature2D
    {
        private bool disposed;
        private Ptr<ORB> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected ORB(IntPtr p)
        {
            ptrObj = new Ptr<ORB>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFeatures"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="nLevels"></param>
        /// <param name="edgeThreshold"></param>
        /// <param name="firstLevel"></param>
        /// <param name="wtaK"></param>
        /// <param name="scoreType"></param>
        /// <param name="patchSize"></param>
        public static ORB Create(
            int nFeatures = 500, float scaleFactor = 1.2f, int nLevels = 8, 
            int edgeThreshold = 31, int firstLevel = 0, int wtaK = 2, 
            ORBScore scoreType = ORBScore.Harris, int patchSize = 31)
        {
            IntPtr ptr = NativeMethods.features2d_ORB_create(
                nFeatures, scaleFactor, nLevels, edgeThreshold,
                firstLevel, wtaK, (int)scoreType, patchSize);
            return new ORB(ptr);
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

        #region Methods

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name); 
                return NativeMethods.features2d_ORB_info(ptr);
            }
        }

        #endregion
    }
}
