using System;

namespace OpenCvSharp.XPhoto
{
    /// <summary>
    /// Gray-world white balance algorithm.
    /// </summary>
    public class GrayworldWB : WhiteBalancer
    {

        private Ptr ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal GrayworldWB(IntPtr p)
        {
            this.ptrObj = new Ptr(p);
            this.ptr = this.ptrObj.Get();
        }

        /// <summary>
        /// Creates an instance of GrayworldWB
        /// </summary>
        /// <returns></returns>
        public static GrayworldWB Create()
        {
            var ptr = NativeMethods.xphoto_createGrayworldWB();
            return new GrayworldWB(ptr);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Maximum saturation for a pixel to be included in the gray-world assumption.
        /// </summary>
        public float SaturationThreshold
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.xphoto_GrayworldWB_SaturationThreshold_get(this.ptr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.xphoto_GrayworldWB_SaturationThreshold_set(this.ptr, value);
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
            NativeMethods.xphoto_GrayworldWB_balanceWhite(this.ptr, src.CvPtr, dst.CvPtr);
            GC.KeepAlive(src);
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
                return NativeMethods.xphoto_Ptr_GrayworldWB_get(this.ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xphoto_Ptr_GrayworldWB_delete(this.ptr);
                base.DisposeUnmanaged();
            }

        }
    }
}