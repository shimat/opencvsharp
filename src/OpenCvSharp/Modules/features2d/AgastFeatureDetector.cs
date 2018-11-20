using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// AGAST 実装
    /// </summary>
#else
    /// <summary>
    /// Detects corners using the AGAST algorithm
    /// </summary>
#endif
    public class AgastFeatureDetector : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

#pragma warning disable 1591
        public const int
            THRESHOLD = 10000,
            NONMAX_SUPPRESSION = 10001;
#pragma warning restore 1591

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected AgastFeatureDetector(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// The AgastFeatureDetector constructor
        /// </summary>
        /// <param name="threshold">threshold on difference between intensity of the central pixel 
        /// and pixels of a circle around this pixel.</param>
        /// <param name="nonmaxSuppression">if true, non-maximum suppression is applied to detected corners (keypoints).</param>
        /// <param name="type"></param>
        public static AgastFeatureDetector Create(
            int threshold = 10,
            bool nonmaxSuppression = true,
            DetectorType type = DetectorType.OAST_9_16)
        {
            IntPtr ptr = NativeMethods.features2d_AgastFeatureDetector_create(
                threshold, nonmaxSuppression ? 1 : 0, (int) type);
            return new AgastFeatureDetector(ptr);
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
        /// threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.
        /// </summary>
        public int Threshold
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_AgastFeatureDetector_getThreshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AgastFeatureDetector_setThreshold(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// if true, non-maximum suppression is applied to detected corners (keypoints).
        /// </summary>
        public int NonmaxSuppression
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_AgastFeatureDetector_getNonmaxSuppression(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AgastFeatureDetector_setNonmaxSuppression(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// type one of the four neighborhoods as defined in the paper
        /// </summary>
        public DetectorType Type
        {
            get
            {
                ThrowIfDisposed();
                var res = (DetectorType)NativeMethods.features2d_AgastFeatureDetector_getType(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AgastFeatureDetector_setType(ptr, (int)value);
                GC.KeepAlive(this);
            }
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.features2d_Ptr_AgastFeatureDetector_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_AgastFeatureDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }

#pragma warning disable 1591

        /// <summary>
        /// AGAST type one of the four neighborhoods as defined in the paper
        /// </summary>
        public enum DetectorType : int
        {
            AGAST_5_8 = 0,
            AGAST_7_12d = 1,
            AGAST_7_12s = 2,
            OAST_9_16 = 3,
        }
    }
}
