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
        private Ptr ptrObj;

        #region Init and Disposal

        /// <summary>
        /// constructor
        /// </summary>
        protected StereoBM(IntPtr ptr)
            : base(ptr)
        {
            ptrObj = new Ptr(ptr);
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
        public int PreFilterType
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getPreFilterType(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setPreFilterType(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PreFilterSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getPreFilterSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setPreFilterSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PreFilterCap
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getPreFilterCap(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setPreFilterCap(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TextureThreshold
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getTextureThreshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setTextureThreshold(ptr, value);
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
                var res = NativeMethods.calib3d_StereoBM_getUniquenessRatio(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setUniquenessRatio(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SmallerBlockSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getSmallerBlockSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setSmallerBlockSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Rect ROI1
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getROI1(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setROI1(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Rect ROI2
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.calib3d_StereoBM_getROI2(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setROI2(ptr, value);
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
                var res = NativeMethods.calib3d_Ptr_StereoBM_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.calib3d_Ptr_StereoBM_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
