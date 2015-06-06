using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Gpu
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="status"></param>
    /// <param name="userData"></param>
    public delegate void StreamCallback(Stream stream, int status, object userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void StreamCallbackInternal(IntPtr stream, int status, IntPtr userData);

#if LANG_JP
    /// <summary>
    /// Encapculates Cuda Stream. Provides interface for async coping.
    /// </summary>
#else
    /// <summary>
    /// Encapculates Cuda Stream. Provides interface for async coping.
    /// </summary>
#endif
    public sealed class Stream : DisposableGpuObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        private StreamCallbackInternal callbackInternal;
        private GCHandle callbackHandle;
        private GCHandle userDataHandle;

        #region Init and Disposal

#if LANG_JP
    /// <summary>
    /// OpenCVネイティブの cv::gpu::Stream* ポインタから初期化
    /// </summary>
    /// <param name="ptr"></param>
#else
        /// <summary>
        /// Creates from native cv::gpu::Stream* pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public Stream(IntPtr ptr)
        {
            ThrowIfNotAvailable();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates empty Stream
        /// </summary>
        public Stream()
        {
            ThrowIfNotAvailable();
            ptr = NativeMethods.cuda_Stream_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public Stream(Stream m)
        {
            ThrowIfNotAvailable();
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = NativeMethods.cuda_Stream_new2(m.CvPtr);
        }

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
                        NativeMethods.cuda_Stream_delete(ptr);
                        if (callbackHandle.IsAllocated)
                            callbackHandle.Free();
                        if (userDataHandle.IsAllocated)
                            userDataHandle.Free();
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

        /// <summary>
        /// Empty stream
        /// </summary>
        /// <returns></returns>
        public static Stream Null
        {
            get
            {
                if (nullObject == null)
                {
                    IntPtr ret = NativeMethods.cuda_Stream_Null();
                    nullObject = new Stream(ret) {IsEnabledDispose = false};
                }
                return nullObject;
            }
        }

        private static Stream nullObject = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static explicit operator bool(Stream self)
        {
            self.ThrowIfDisposed();
            return NativeMethods.cuda_Stream_bool(self.ptr) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueryIfComplete()
        {
            ThrowIfDisposed();
            return NativeMethods.cuda_Stream_queryIfComplete(ptr) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void WaitForCompletion()
        {
            ThrowIfDisposed();
            NativeMethods.cuda_Stream_waitForCompletion(ptr);
        }

        /// <summary>
        /// Downloads asynchronously.
        /// Warning! cv::Mat must point to page locked memory (i.e. to CudaMem data or to its subMat)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public void EnqueueDownload(GpuMat src, Mat dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.cuda_Stream_enqueueDownload_Mat(ptr, src.CvPtr, dst.CvPtr);
        }

        /// <summary>
        /// Uploads asynchronously.
        /// Warning! cv::Mat must point to page locked memory (i.e. to CudaMem data or to its ROI)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public void EnqueueUpload(Mat src, GpuMat dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.cuda_Stream_enqueueUpload_Mat(ptr, src.CvPtr, dst.CvPtr);
        }

        /// <summary>
        /// Copy asynchronously
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public void EnqueueCopy(GpuMat src, GpuMat dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.cuda_Stream_enqueueCopy(ptr, src.CvPtr, dst.CvPtr);
        }

        /// <summary>
        /// Memory set asynchronously
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        public void EnqueueMemSet(GpuMat src, Scalar val)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();

            NativeMethods.cuda_Stream_enqueueMemSet(ptr, src.CvPtr, val);
        }

        /// <summary>
        /// Memory set asynchronously
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <param name="mask"></param>
        public void EnqueueMemSet(GpuMat src, Scalar val, GpuMat mask)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();

            NativeMethods.cuda_Stream_enqueueMemSet_WithMask(ptr, src.CvPtr, val, Cv2.ToPtr(mask));
        }

        /// <summary>
        /// converts matrix type, ex from float to uchar depending on type
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="dtype"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void EnqueueConvert(GpuMat src, GpuMat dst, int dtype, double a = 1, double b = 0)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.cuda_Stream_enqueueConvert(ptr, src.CvPtr, dst.CvPtr, dtype, a, b);
        }

        /// <summary>
        /// Adds a callback to be called on the host after all currently enqueued items 
        /// in the stream have completed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="userData">Not supported</param>
        public void EnqueueHostCallback(StreamCallback callback, object userData = null)
        {
            ThrowIfDisposed();
            if (callback == null)
                throw new ArgumentNullException("callback");

            if (callbackHandle.IsAllocated)
                callbackHandle.Free();
            if (userDataHandle.IsAllocated)
                userDataHandle.Free();

            IntPtr userDataPtr = IntPtr.Zero;
            if (userData != null)
            {
                userDataHandle = GCHandle.Alloc(userData);
                userDataPtr = GCHandle.ToIntPtr(userDataHandle);
            }

            callbackInternal = new StreamCallbackInternal(
                delegate(IntPtr rawStream, int status, IntPtr rawUserData)
                {
                    var streamObj = new Stream(rawStream) {IsEnabledDispose = false};
                    var userDataObj = GCHandle.FromIntPtr(rawUserData).Target;
                    callback(streamObj, status, userDataObj);
                });
            callbackHandle = GCHandle.Alloc(callbackInternal);
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate(callbackInternal);

            NativeMethods.cuda_Stream_enqueueHostCallback(
                ptr, callbackPtr, userDataPtr);
        }
    }
}
