using System;

namespace OpenCvSharp.Quality
{
    /// <summary>
    /// Quality Base Class
    /// </summary>
    public abstract class QualityBase : Algorithm
    {
        /// <summary>
        /// Implements Algorithm::empty()
        /// </summary>
        /// <returns></returns>
        public override bool Empty
        {
            get
            {
                ThrowIfDisposed();
                var ret = NativeMethods.quality_QualityBase_empty(ptr) != 0;
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Returns output quality map that was generated during computation, if supported by the algorithm
        /// </summary>
        /// <param name="dst"></param>
        public virtual void GetQualityMap(OutputArray dst)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();
            NativeMethods.quality_QualityBase_getQualityMap(ptr, dst.CvPtr);
            dst.Fix();
        }

        /// <summary>
        /// Compute quality score per channel with the per-channel score in each element of the resulting cv::Scalar.
        /// See specific algorithm for interpreting result scores
        /// </summary>
        /// <param name="img">comparison image, or image to evaluate for no-reference quality algorithms</param>
        public virtual Scalar Compute(InputArray img)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            var ret = NativeMethods.quality_QualityBase_compute(ptr, img.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(img);
            return ret;
        }

        /// <summary>
        /// Implements Algorithm::clear() 
        /// </summary>
        public virtual void Clear()
        {
            ThrowIfDisposed();
            NativeMethods.quality_QualityBase_clear(ptr);
            GC.KeepAlive(this);
        }
    }
}
