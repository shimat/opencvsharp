using System;
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.XPhoto
{
    /// <summary>
    /// A simple white balance algorithm that works by independently stretching each of the input image channels to the specified range. For increased robustness it ignores the top and bottom p% of pixel values.
    /// </summary>
    public class SimpleWB : WhiteBalancer
    {
        private Ptr? ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal SimpleWB(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates an instance of SimpleWB
        /// </summary>
        /// <returns></returns>
        public static SimpleWB Create()
        {
            var ptr = NativeMethods.xphoto_createSimpleWB();
            return new SimpleWB(ptr);
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
        /// Input image range maximum value.
        /// </summary>
        public float InputMax
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.xphoto_SimpleWB_InputMax_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xphoto_SimpleWB_InputMax_set(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Input image range minimum value.
        /// </summary>
        public float InputMin
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.xphoto_SimpleWB_InputMin_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xphoto_SimpleWB_InputMin_set(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Output image range maximum value.
        /// </summary>
        public float OutputMax
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.xphoto_SimpleWB_OutputMax_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xphoto_SimpleWB_OutputMax_set(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Output image range minimum value.
        /// </summary>
        public float OutputMin
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.xphoto_SimpleWB_OutputMin_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xphoto_SimpleWB_OutputMin_set(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Percent of top/bottom values to ignore.
        /// </summary>
        public float P
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.xphoto_SimpleWB_P_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xphoto_SimpleWB_P_set(ptr, value);
                GC.KeepAlive(this);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applies white balancing to the input image.
        /// </summary>
        /// <param name="src">Input image</param>
        /// <param name="dst">White balancing result</param>
        public override void BalanceWhite(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.xphoto_SimpleWB_balanceWhite(ptr, src.CvPtr, dst.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr)
                : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.xphoto_Ptr_SimpleWB_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xphoto_Ptr_SimpleWB_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}