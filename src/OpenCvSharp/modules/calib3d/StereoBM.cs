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
                return NativeMethods.calib3d_StereoBM_getPreFilterType(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getPreFilterSize(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getPreFilterCap(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getTextureThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getUniquenessRatio(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getSmallerBlockSize(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getROI1(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.calib3d_StereoBM_getROI2(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.calib3d_StereoBM_setROI2(ptr, value);
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
                return NativeMethods.calib3d_Ptr_StereoBM_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.calib3d_Ptr_StereoBM_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
