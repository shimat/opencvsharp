using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

#if LANG_JP
    /// <summary>
    /// セミグローバルブロックマッチングアルゴリズムを用てステレオ対応点探索を行うためのクラス
    /// </summary>
#else
    /// <summary>
    /// Semi-Global Stereo Matching
    /// </summary>
#endif
    public class StereoBM : StereoMatcher
    {
        private bool disposed;
        private Ptr<StereoBM> ptrObj;

        #region Init and Disposal

        /// <summary>
        /// constructor
        /// </summary>
        protected StereoBM(IntPtr ptr)
            : base(ptr)
        {
            ptrObj = new Ptr<StereoBM>(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDisparities"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        public static StereoBM Create(int numDisparities = 0, int blockSize = 21)
        {
            IntPtr ptrObj = NativeMethods.calib3d_StereoBM_create(numDisparities, blockSize);
            return new StereoBM(ptrObj);
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
        public int PreFilterType
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getPreFilterType(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setPreFilterType(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PreFilterSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getPreFilterSize(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setPreFilterSize(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PreFilterCap
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getPreFilterCap(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setPreFilterCap(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TextureThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getTextureThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setTextureThreshold(ptr, value);
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
                return NativeMethods.calib3d_StereoBM_getUniquenessRatio(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setUniquenessRatio(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SmallerBlockSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getSmallerBlockSize(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setSmallerBlockSize(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Rect ROI1
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getROI1(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setROI1(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Rect ROI2
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.calib3d_StereoBM_getROI2(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.calib3d_StereoBM_setROI2(ptr, value);
            }
        }

        #endregion

    }
}
