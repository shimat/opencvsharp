using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Contrast Limited Adaptive Histogram Equalization
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class CLAHE : Algorithm
    {
        /// <summary>
        /// cv::Ptr&lt;CLAHE&gt;
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        private CLAHE(IntPtr p)
        {
            ptrObj = new Ptr(p);
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

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public void Apply(InputArray src, OutputArray dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.imgproc_CLAHE_apply(ptr, src.CvPtr, dst.CvPtr);

            dst.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clipLimit"></param>
        public void SetClipLimit(double clipLimit)
        {
            ThrowIfDisposed();
            NativeMethods.imgproc_CLAHE_setClipLimit(ptr, clipLimit);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetClipLimit()
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_CLAHE_getClipLimit(ptr);
            GC.KeepAlive(this);
            return res;
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
            ThrowIfDisposed();
            NativeMethods.imgproc_CLAHE_setTilesGridSize(ptr, tileGridSize);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size GetTilesGridSize()
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_CLAHE_getTilesGridSize(ptr);
            GC.KeepAlive(this);
            return res;
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
            ThrowIfDisposed();
            NativeMethods.imgproc_CLAHE_collectGarbage(ptr);
            GC.KeepAlive(this);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.imgproc_Ptr_CLAHE_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.imgproc_Ptr_CLAHE_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
