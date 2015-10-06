using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// ORB 実装
    /// </summary>
#else
    /// <summary>
    /// Class implementing the ORB (*oriented BRIEF*) keypoint detector and descriptor extractor
    /// </summary>
    /// <remarks>
    /// described in @cite RRKB11 . The algorithm uses FAST in pyramids to detect stable keypoints, 
    /// selects the strongest features using FAST or Harris response, finds their orientation 
    /// using first-order moments and computes the descriptors using BRIEF (where the coordinates 
    /// of random point pairs (or k-tuples) are rotated according to the measured orientation).
    /// </remarks>
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
        /// 
        /// </summary>
        public int MaxFeatures
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getMaxFeatures(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setMaxFeatures(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ScaleFactor
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getScaleFactor(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setScaleFactor(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int NLevels
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getNLevels(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setNLevels(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int EdgeThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getEdgeThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setEdgeThreshold(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int FirstLevel
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getFirstLevel(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setFirstLevel(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
// ReSharper disable once InconsistentNaming
        public int WTA_K
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getWTA_K(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setWTA_K(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int ScoreType
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getScoreType(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setScoreType(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int PatchSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getPatchSize(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setPatchSize(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int FastThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_ORB_getFastThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_ORB_setFastThreshold(ptr, value);
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
