using System;

namespace OpenCvSharp.ImgHash
{
    /// <inheritdoc />
    /// <summary>
    /// Marr-Hildreth Operator Based Hash, slowest but more discriminative.
    /// </summary>
    public class MarrHildrethHash : ImgHashBase
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        protected MarrHildrethHash(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Create BlockMeanHash object
        /// </summary>
        /// <param name="alpha">int scale factor for marr wavelet (default=2).</param>
        /// <param name="scale">int level of scale factor (default = 1)</param>
        /// <returns></returns>
        public static MarrHildrethHash Create(float alpha = 2.0f, float scale = 1.0f)
        {
            IntPtr p = NativeMethods.img_hash_MarrHildrethHash_create(alpha, scale);
            return new MarrHildrethHash(p);
        }
        
        /// <inheritdoc />
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
        /// <param name="alpha">int scale factor for marr wavelet (default=2).</param>
        /// <param name="scale">int level of scale factor (default = 1)</param>
        public void SetKernelParam(float alpha = 2.0f, float scale = 1.0f)
        {
            ThrowIfDisposed();
            NativeMethods.img_hash_MarrHildrethHash_setKernelParam(ptr, alpha, scale);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// int scale factor for marr wavelet (default=2).
        /// </summary>
        public float Alpha
        {
            get
            {
                ThrowIfDisposed();
                float ret = NativeMethods.img_hash_MarrHildrethHash_getAlpha(ptr);
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                float scale = NativeMethods.img_hash_MarrHildrethHash_getScale(ptr);
                NativeMethods.img_hash_MarrHildrethHash_setKernelParam(ptr, value, scale);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// int level of scale factor (default = 1)
        /// </summary>
        public float Scale
        {
            get
            {
                ThrowIfDisposed();
                float ret = NativeMethods.img_hash_MarrHildrethHash_getScale(ptr);
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                float alpha = NativeMethods.img_hash_MarrHildrethHash_getAlpha(ptr);
                NativeMethods.img_hash_MarrHildrethHash_setKernelParam(ptr, alpha, value);
                GC.KeepAlive(this);
            }
        }

        // ReSharper disable once RedundantOverriddenMember
        /// <inheritdoc />
        /// <summary>
        /// Computes average hash value of the input image
        /// </summary>
        /// <param name="inputArr">input image want to compute hash value, type should be CV_8UC4, CV_8UC3, CV_8UC1.</param>
        /// <param name="outputArr">Hash value of input, it will contain 16 hex decimal number, return type is CV_8U</param>
        /// <returns></returns>
        public override void Compute(InputArray inputArr, OutputArray outputArr)
        {
            base.Compute(inputArr, outputArr);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.img_hash_Ptr_MarrHildrethHash_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.img_hash_Ptr_MarrHildrethHash_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}