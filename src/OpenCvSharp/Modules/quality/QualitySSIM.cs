using System;

namespace OpenCvSharp.Quality
{
    /// <summary>
    /// Full reference structural similarity algorithm  https://en.wikipedia.org/wiki/Structural_similarity
    /// </summary>
    public class QualitySSIM : QualityBase
    {
        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected QualitySSIM(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Create an object which calculates quality
        /// </summary>
        /// <param name="ref">input image to use as the source for comparison</param>
        /// <returns></returns>
        public static QualitySSIM Create(InputArray @ref)
        {
            if (@ref == null)
                throw new ArgumentNullException(nameof(@ref));
            @ref.ThrowIfDisposed();

            var ptr = NativeMethods.quality_createQualitySSIM(@ref.CvPtr);
            GC.KeepAlive(@ref);
            return new QualitySSIM(ptr);
        }

        /// <summary>
        /// static method for computing quality
        /// </summary>
        /// <param name="ref"></param>
        /// <param name="cmp"></param>
        /// <param name="qualityMap">output quality map, or null</param>
        /// <returns>cv::Scalar with per-channel quality values.  Values range from 0 (worst) to 1 (best)</returns>
        public static Scalar Compute(InputArray @ref, InputArray cmp, OutputArray qualityMap)
        {
            if (@ref == null)
                throw new ArgumentNullException(nameof(@ref));
            if (cmp == null)
                throw new ArgumentNullException(nameof(cmp));
            @ref.ThrowIfDisposed();
            cmp.ThrowIfDisposed();
            qualityMap?.ThrowIfNotReady();

            var ret = NativeMethods.quality_QualitySSIM_staticCompute(@ref.CvPtr, cmp.CvPtr, qualityMap?.CvPtr ?? IntPtr.Zero);

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
                var res = NativeMethods.quality_Ptr_QualitySSIM_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.quality_Ptr_QualitySSIM_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
