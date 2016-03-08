using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    internal sealed class DenseOpticalFlowImpl : DenseOpticalFlow
    {
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        private Ptr<DenseOpticalFlow> detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private DenseOpticalFlowImpl()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static DenseOpticalFlowImpl FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DenseOpticalFlow pointer");

            var ptrObj = new Ptr<DenseOpticalFlow>(ptr);
            var obj = new DenseOpticalFlowImpl
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
        internal static DenseOpticalFlowImpl FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DenseOpticalFlow pointer");
            var obj = new DenseOpticalFlowImpl
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
                        if (detectorPtr != null)
                            detectorPtr.Dispose();
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
        /// <param name="frame0"></param>
        /// <param name="frame1"></param>
        /// <param name="flow"></param>
        public override void Calc(
            InputArray frame0, InputArray frame1, InputOutputArray flow)
        {
            if (disposed)
                throw new ObjectDisposedException("DenseOpticalFlowImpl");
            if (frame0 == null)
                throw new ArgumentNullException("frame0");
            if (frame1 == null)
                throw new ArgumentNullException("frame1");
            if (flow == null)
                throw new ArgumentNullException("flow");
            frame0.ThrowIfDisposed();
            frame1.ThrowIfDisposed();
            flow.ThrowIfNotReady();

            NativeMethods.video_DenseOpticalFlow_calc(
                ptr, frame0.CvPtr, frame1.CvPtr, flow.CvPtr);

            flow.Fix();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CollectGarbage()
        {
            if (disposed)
                throw new ObjectDisposedException("DenseOpticalFlowImpl");
            NativeMethods.video_DenseOpticalFlow_collectGarbage(ptr);
        }

        #endregion
    }
}
