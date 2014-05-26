/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Gpu
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public class StereoBM_GPU : DisposableCvObject
    {
        #region Fields
        /// <summary>
        /// sizeof(StereoBM_GPU)
        /// </summary>
        public static readonly int SizeOf;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        public const int BASIC_PRESET = 0;
        /// <summary>
        /// 
        /// </summary>
        public const int PREFILTER_XSOBEL = 1;
        /// <summary>
        /// 
        /// </summary>
        public const int DEFAULT_NDISP = 64;
        /// <summary>
        /// 
        /// </summary>
        public const int DEFAULT_WINSZ = 19;
        #endregion

        #region Init and Disposal
        /// <summary>
        /// static constructor
        /// </summary>
        static StereoBM_GPU()
        {
            try
            {
                SizeOf = (int)NativeMethods.StereoBM_GPU_sizeof();
            }
            catch (DllNotFoundException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (BadImageFormatException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region Constructor
#if LANG_JP
        /// <summary>
        /// デフォルトのパラメータで初期化.
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public StereoBM_GPU()
        {
            ptr = NativeMethods.StereoBM_GPU_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
        /// <summary>
        /// StereoBM_GPU コンストラクタ
        /// </summary>
        /// <param name="preset"></param>
        /// <param name="ndisparities"></param>
        /// <param name="winSize"></param>
#else
        /// <summary>
        /// StereoBM_GPU Constructor
        /// </summary>
        /// <param name="preset"></param>
        /// <param name="ndisparities"></param>
        /// <param name="winSize"></param>
#endif
        public StereoBM_GPU(int preset, int ndisparities = DEFAULT_NDISP, int winSize = DEFAULT_WINSZ)
        {
            ptr = NativeMethods.StereoBM_GPU_new2(preset, ndisparities, winSize);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        #endregion
        #region Dispose
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose(true);
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
                        NativeMethods.StereoBM_GPU_delete(ptr);
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

        #region Properties
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Preset
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    return *NativeMethods.StereoBM_GPU_preset(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    *NativeMethods.StereoBM_GPU_preset(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Ndisp
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    return *NativeMethods.StereoBM_GPU_ndisp(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    *NativeMethods.StereoBM_GPU_ndisp(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int WinSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    return *NativeMethods.StereoBM_GPU_winSize(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    *NativeMethods.StereoBM_GPU_winSize(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public float AvergeTexThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    return *NativeMethods.StereoBM_GPU_avergeTexThreshold(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoBM_GPU");
                unsafe
                {
                    *NativeMethods.StereoBM_GPU_avergeTexThreshold(ptr) = value;
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfGpuCallReasonable()
        {
            return NativeMethods.StereoBM_GPU_checkIfGpuCallReasonable() != 0;
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="disparity"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="disparity"></param>
#endif
        public void Run(GpuMat left, GpuMat right, GpuMat disparity)
        {
            if (disposed)
                throw new ObjectDisposedException("StereoBM_GPU");
            if(left == null)
                throw new ArgumentNullException("left");
            if(right == null)
                throw new ArgumentNullException("right");
            if (disparity == null)
                throw new ArgumentNullException("disparity");

            NativeMethods.StereoBM_GPU_run1(ptr, left.CvPtr, right.CvPtr, disparity.CvPtr);
        }
        #endregion
    }
}
