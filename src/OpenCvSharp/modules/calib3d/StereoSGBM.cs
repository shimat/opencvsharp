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
        private bool disposed;
        private Ptr<StereoSGBM> ptrObj;

        #region Init and Disposal

        /// <summary>
        /// constructor
        /// </summary>
        protected StereoSGBM(IntPtr ptr) : base(ptr)
        {
            ptrObj = new Ptr<StereoSGBM>(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                        }
                        ptrObj = null;
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

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int PreFilterCap
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoSGBM_getPreFilterCap(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoSGBM_setPreFilterCap(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UniquenessRatio
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoSGBM_getUniquenessRatio(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoSGBM_setUniquenessRatio(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int P1
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoSGBM_getP1(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoSGBM_setP1(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int P2
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoSGBM_getP2(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoSGBM_setP2(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public StereoSGBMMode Mode
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return (StereoSGBMMode)NativeMethods.calib3d_StereoSGBM_getMode(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoSGBM_setMode(ptr, (int)value);
            }
        }

        #endregion

    }
}
