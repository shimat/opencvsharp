using System;

namespace OpenCvSharp.Quality
{
    /// <summary>
    /// Full reference peak signal to noise ratio (PSNR) algorithm  https://en.wikipedia.org/wiki/Peak_signal-to-noise_ratio
    /// </summary>
    public class QualityPSNR : QualityBase
    {
        private const double MaxPixelValueDefault = 255;

        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected QualityPSNR(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// get or set the maximum pixel value used for PSNR computation
        /// </summary>
        /// <returns></returns>
        public double MaxPixelValue
        {
            get
            {
                ThrowIfDisposed();
                var ret = NativeMethods.quality_QualityPSNR_getMaxPixelValue(ptr);
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.quality_QualityPSNR_setMaxPixelValue(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Create an object which calculates quality
        /// </summary>
        /// <param name="ref">input image to use as the source for comparison</param>
        /// <param name="maxPixelValue">maximum per-channel value for any individual pixel; eg 255 for uint8 image</param>
        /// <returns></returns>
        public static QualityPSNR Create(InputArray @ref, double maxPixelValue = MaxPixelValueDefault)
        {
            if (@ref == null)
                throw new ArgumentNullException(nameof(@ref));
            @ref.ThrowIfDisposed();

            var ptr = NativeMethods.quality_createQualityPSNR(@ref.CvPtr, maxPixelValue);
            GC.KeepAlive(@ref);
            return new QualityPSNR(ptr);
        }
        
        /// <summary>
        /// static method for computing quality
        /// </summary>
        /// <param name="ref"></param>
        /// <param name="cmp"></param>
        /// <param name="qualityMap">output quality map, or null</param>
        /// <param name="maxPixelValue">maximum per-channel value for any individual pixel; eg 255 for uint8 image</param>
        /// <returns>PSNR value, or double.PositiveInfinity if the MSE between the two images == 0</returns>
        public static Scalar Compute(InputArray @ref, InputArray cmp, OutputArray qualityMap, double maxPixelValue = MaxPixelValueDefault)
        {
            if (@ref == null)
                throw new ArgumentNullException(nameof(@ref));
            if (cmp == null)
                throw new ArgumentNullException(nameof(cmp));
            @ref.ThrowIfDisposed();
            cmp.ThrowIfDisposed();
            qualityMap?.ThrowIfNotReady();

            var ret = NativeMethods.quality_QualityPSNR_staticCompute(@ref.CvPtr, cmp.CvPtr, qualityMap?.CvPtr ?? IntPtr.Zero, maxPixelValue);

            GC.KeepAlive(@ref);
            GC.KeepAlive(cmp);
            qualityMap?.Fix();
            return ret;
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

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.quality_Ptr_QualityPSNR_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.quality_Ptr_QualityPSNR_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
