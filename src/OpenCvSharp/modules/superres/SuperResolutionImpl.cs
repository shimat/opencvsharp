﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// class for defined Super Resolution algorithm.
    /// </summary>
    internal sealed class SuperResolutionImpl : SuperResolution
    {
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        private Ptr detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private SuperResolutionImpl()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static SuperResolutionImpl FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FrameSource pointer");

            var ptrObj = new Ptr(ptr);
            var obj = new SuperResolutionImpl
            {
                detectorPtr = ptrObj,
                ptr = ptrObj.Get()
            };
            return obj;
        }

        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static SuperResolutionImpl FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FrameSource pointer");
            var obj = new SuperResolutionImpl
            {
                detectorPtr = null,
                ptr = ptr
            };
            return obj;
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
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        detectorPtr?.Dispose();
                        detectorPtr = null;
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

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        public override void SetInput(FrameSource fs)
        {
            ThrowIfDisposed();
            if (fs == null)
                throw new ArgumentNullException(nameof(fs));
            NativeMethods.superres_SuperResolution_setInput(ptr, fs.CvPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame"></param>
        public override void NextFrame(OutputArray frame)
        {
            ThrowIfDisposed();
            if (frame == null)
                throw new ArgumentNullException(nameof(frame));
            frame.ThrowIfNotReady();
            NativeMethods.superres_SuperResolution_nextFrame(ptr, frame.CvPtr);
            frame.Fix();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Reset()
        {
            ThrowIfDisposed();
            NativeMethods.superres_SuperResolution_reset(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CollectGarbage()
        {
            ThrowIfDisposed();
            NativeMethods.superres_SuperResolution_collectGarbage(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        protected override void InitImpl(FrameSource fs)
        {
            // ネイティブ実装なので特別に空で。
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="output"></param>
        protected override void ProcessImpl(FrameSource fs, OutputArray output)
        {
            // ネイティブ実装なので特別に空で。
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.superres_Ptr_SuperResolution_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.superres_Ptr_SuperResolution_delete(ptr);
            }
        }
    }
}
