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
            ORBScoreType scoreType = ORBScoreType.Harris, int patchSize = 31)
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
                var res = NativeMethods.features2d_ORB_getMaxFeatures(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setMaxFeatures(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getScaleFactor(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setScaleFactor(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getNLevels(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setNLevels(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getEdgeThreshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setEdgeThreshold(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getFirstLevel(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setFirstLevel(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getWTA_K(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setWTA_K(ptr, value);
                GC.KeepAlive(this);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ORBScoreType ScoreType
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_ORB_getScoreType(ptr);
                GC.KeepAlive(this);
                return (ORBScoreType)res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setScoreType(ptr, (int)value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getPatchSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setPatchSize(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.features2d_ORB_getFastThreshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_ORB_setFastThreshold(ptr, value);
                GC.KeepAlive(this);
            }
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.features2d_Ptr_ORB_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_ORB_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
