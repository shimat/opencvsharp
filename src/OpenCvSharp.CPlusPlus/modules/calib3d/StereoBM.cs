/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// Class for computing stereo correspondence using the block matching algorithm.
    /// </summary>
#else
    /// <summary>
    /// Class for computing stereo correspondence using the block matching algorithm.
    /// </summary>
#endif
    public class StereoBM : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        public const int PREFILTER_NORMALIZED_RESPONSE = 0,
                         PREFILTER_XSOBEL = 1,
                         BASIC_PRESET = 0,
                         FISH_EYE_PRESET = 1,
                         NARROW_PRESET = 2;

        #region Init and Disposal
        #region Constructor
#if LANG_JP
        /// <summary>
        /// デフォルトのパラメータで初期化.
        /// あとでInitを呼ぶ必要がある。
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public StereoBM()
        {
            ptr = NativeMethods.calib3d_StereoBM_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="preset"></param>
        /// <param name="nDisparities"></param>
        /// <param name="sadWindowSize"></param>
        public StereoBM(int preset, int nDisparities=0, int sadWindowSize=21)
        {
            ptr = NativeMethods.calib3d_StereoBM_new2(preset, nDisparities, sadWindowSize);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        #endregion
        #region Dispose
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
                        if(ptr != IntPtr.Zero)
                            NativeMethods.calib3d_StereoBM_delete(ptr);
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
        #endregion

        #region Methods

        /// <summary>
        /// separate initialization function
        /// </summary>
        /// <param name="preset"></param>
        /// <param name="nDisparities"></param>
        /// <param name="sadWindowSize"></param>
        public void Init(int preset, int nDisparities = 0, int sadWindowSize = 21)
        {
            NativeMethods.calib3d_StereoBM_init(ptr, preset, nDisparities, sadWindowSize);
        }
#if LANG_JP
        /// <summary>
        /// computes the disparity for the two rectified 8-bit single-channel images.
        /// the disparity will be 16-bit signed (fixed-point) or 32-bit floating-point image of the same size as left.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="disp"></param>
                /// <param name="dispType"></param>
#else
        /// <summary>
        /// computes the disparity for the two rectified 8-bit single-channel images.
        /// the disparity will be 16-bit signed (fixed-point) or 32-bit floating-point image of the same size as left.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="disp"></param>
        /// <param name="dispType"></param>
#endif
        public void Compute(InputArray left, InputArray right, OutputArray disp, int dispType = MatType.CV_16S)
        {
            if (disposed)
                throw new ObjectDisposedException("StereoSGBM");
            if(left == null)
                throw new ArgumentNullException("left");
            if(right == null)
                throw new ArgumentNullException("right");
            if(disp == null)
                throw new ArgumentNullException("disp");
            left.ThrowIfDisposed();
            right.ThrowIfDisposed();
            disp.ThrowIfNotReady();
            NativeMethods.calib3d_StereoBM_compute(ptr, left.CvPtr, right.CvPtr, disp.CvPtr, dispType);
            disp.Fix();
        }
        #endregion
    }
}
