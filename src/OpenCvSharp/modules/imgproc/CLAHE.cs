using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Contrast Limited Adaptive Histogram Equalization
    /// </summary>
    public sealed class CLAHE : Algorithm
    {
        private bool disposed;

        /// <summary>
        /// cv::Ptr&lt;CLAHE&gt;
        /// </summary>
        private Ptr<CLAHE> ptrObj;

        /// <summary>
        /// 
        /// </summary>
        private CLAHE(IntPtr p)
        {
            ptrObj = new Ptr<CLAHE>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates a predefined CLAHE object
        /// </summary>
        /// <param name="clipLimit"></param>
        /// <param name="tileGridSize"></param>
        /// <returns></returns>
        public static CLAHE Create(double clipLimit = 40.0, Size? tileGridSize = null)
        {
            IntPtr ptr = NativeMethods.imgproc_createCLAHE(
                clipLimit, tileGridSize.GetValueOrDefault(new Size(8, 8)));
            return new CLAHE(ptr);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public void Apply(InputArray src, OutputArray dst)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.imgproc_CLAHE_apply(ptr, src.CvPtr, dst.CvPtr);

            dst.Fix();
            GC.KeepAlive(src);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clipLimit"></param>
        public void SetClipLimit(double clipLimit)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            NativeMethods.imgproc_CLAHE_setClipLimit(ptr, clipLimit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetClipLimit()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            return NativeMethods.imgproc_CLAHE_getClipLimit(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public double ClipLimit
        {
            get { return GetClipLimit(); }
            set { SetClipLimit(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tileGridSize"></param>
        public void SetTilesGridSize(Size tileGridSize)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            NativeMethods.imgproc_CLAHE_setTilesGridSize(ptr, tileGridSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size GetTilesGridSize()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            return NativeMethods.imgproc_CLAHE_getTilesGridSize(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public Size TilesGridSize
        {
            get { return GetTilesGridSize(); }
            set { SetTilesGridSize(value); }
        }


        /// <summary>
        /// 
        /// </summary>
        public void CollectGarbage()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            NativeMethods.imgproc_CLAHE_collectGarbage(ptr);
        }
    }
}
