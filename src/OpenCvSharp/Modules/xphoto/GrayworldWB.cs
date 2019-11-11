﻿using System;
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.XPhoto
{
    /// <summary>
    /// Gray-world white balance algorithm.
    /// </summary>
    public class GrayworldWB : WhiteBalancer
    {
        private Ptr? ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal GrayworldWB(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
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

        /// <inheritdoc />
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
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
                ThrowIfDisposed();
                var res = NativeMethods.xphoto_GrayworldWB_SaturationThreshold_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xphoto_GrayworldWB_SaturationThreshold_set(ptr, value);
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
            NativeMethods.xphoto_GrayworldWB_balanceWhite(ptr, src.CvPtr, dst.CvPtr);
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
                var res = NativeMethods.xphoto_Ptr_GrayworldWB_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xphoto_Ptr_GrayworldWB_delete(ptr);
                base.DisposeUnmanaged();
            }

        }
    }
}