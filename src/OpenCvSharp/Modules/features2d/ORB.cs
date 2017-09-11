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
    // ReSharper disable once InconsistentNaming
    public class ORB : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected ORB(IntPtr p)
        {
            ptrObj = new Ptr(p);
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

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getMaxFeatures(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getScaleFactor(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getNLevels(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getEdgeThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getFirstLevel(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getWTA_K(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getScoreType(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getPatchSize(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_ORB_getFastThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setFastThreshold(ptr, value);
            }
        }

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.features2d_Ptr_ORB_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_ORB_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
