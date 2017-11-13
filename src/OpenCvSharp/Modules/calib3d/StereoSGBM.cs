using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// 
    /// </summary>
    public enum StereoSGBMMode
    {
         SGBM = 0,
         HH   = 1,
    }

#if LANG_JP
    /// <summary>
    /// セミグローバルブロックマッチングアルゴリズムを用てステレオ対応点探索を行うためのクラス
    /// </summary>
#else
    /// <summary>
    /// Semi-Global Stereo Matching
    /// </summary>
#endif
    public class StereoSGBM : StereoMatcher
    {
        private Ptr ptrObj;

        #region Init and Disposal

        /// <summary>
        /// constructor
        /// </summary>
        protected StereoSGBM(IntPtr ptr) : base(ptr)
        {
            ptrObj = new Ptr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minDisparity"></param>
        /// <param name="numDisparities"></param>
        /// <param name="blockSize"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="disp12MaxDiff"></param>
        /// <param name="preFilterCap"></param>
        /// <param name="uniquenessRatio"></param>
        /// <param name="speckleWindowSize"></param>
        /// <param name="speckleRange"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static StereoSGBM Create(
            int minDisparity, int numDisparities, int blockSize,
            int p1 = 0, int p2 = 0, int disp12MaxDiff = 0,
            int preFilterCap = 0, int uniquenessRatio = 0,
            int speckleWindowSize = 0, int speckleRange = 0,
            StereoSGBMMode mode = StereoSGBMMode.SGBM)
        {
            IntPtr ptrObj = NativeMethods.calib3d_StereoSGBM_create(
                minDisparity, numDisparities, blockSize,
                p1, p2, disp12MaxDiff, preFilterCap, uniquenessRatio,
                speckleWindowSize, speckleRange, (int) mode);
            return new StereoSGBM(ptrObj);
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
        public int PreFilterCap
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoSGBM_getPreFilterCap(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoSGBM_setPreFilterCap(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UniquenessRatio
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoSGBM_getUniquenessRatio(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoSGBM_setUniquenessRatio(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int P1
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoSGBM_getP1(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoSGBM_setP1(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int P2
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoSGBM_getP2(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoSGBM_setP2(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public StereoSGBMMode Mode
        {
            get
            {
                ThrowIfDisposed();
                var res = (StereoSGBMMode)NativeMethods.calib3d_StereoSGBM_getMode(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoSGBM_setMode(ptr, (int)value);
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
                var res = NativeMethods.calib3d_Ptr_StereoSGBM_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.calib3d_Ptr_StereoSGBM_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
