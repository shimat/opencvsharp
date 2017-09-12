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
            AGAST_5_8 = 0,
            AGAST_7_12d = 1,
            AGAST_7_12s = 2,
            OAST_9_16 = 3,
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
        public static AgastFeatureDetector Create( int threshold=10,
                                                     bool nonmaxSuppression=true,
                                                     AGASTType type = AGASTType.OAST_9_16)
        {
            IntPtr ptr = NativeMethods.features2d_AgastFeatureDetector_create(
                threshold, nonmaxSuppression ? 1 : 0, (int)type);
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
                return NativeMethods.features2d_AgastFeatureDetector_getThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AgastFeatureDetector_setThreshold(ptr, value);
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
                return NativeMethods.features2d_AgastFeatureDetector_getNonmaxSuppression(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AgastFeatureDetector_setNonmaxSuppression(ptr, value);
            }
        }

        /// <summary>
        /// type one of the four neighborhoods as defined in the paper
        /// </summary>
        public AGASTType Type
        {
            get
            {
                ThrowIfDisposed();
                return (AGASTType)NativeMethods.features2d_AgastFeatureDetector_getType(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AgastFeatureDetector_setType(ptr, (int)value);
            }
        }

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.features2d_Ptr_AgastFeatureDetector_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_AgastFeatureDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
