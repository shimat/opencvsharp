using System;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class FrameSourceImpl : FrameSource
    {
        private bool disposed;
        private Ptr<FrameSource> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private FrameSourceImpl()
        {
            ptrObj = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static FrameSource FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FrameSource pointer");
            var obj = new FrameSourceImpl();
            var ptrObj = new Ptr<FrameSource>(ptr);
            obj.ptrObj = ptrObj;
            obj.ptr = ptr;
            return obj;
        }

        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static FrameSource FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FrameSource pointer");
            var obj = new FrameSourceImpl
                {
                    ptrObj = null,
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
                        if (ptrObj != null)
                            ptrObj.Dispose();
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

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame"></param>
        public override void NextFrame(OutputArray frame)
        {
            ThrowIfDisposed();
            if (frame == null)
                throw new ArgumentNullException("frame");
            frame.ThrowIfNotReady();
            NativeMethods.superres_FrameSource_nextFrame(ptr, frame.CvPtr);
            frame.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Reset()
        {
            ThrowIfDisposed();
            NativeMethods.superres_FrameSource_reset(ptr);
        }
        #endregion
    }
}
