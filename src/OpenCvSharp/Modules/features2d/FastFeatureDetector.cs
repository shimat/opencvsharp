using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// Detects corners using FAST algorithm by E. Rosten
    /// </summary>
#else
    /// <summary>
    /// Detects corners using FAST algorithm by E. Rosten
    /// </summary>
#endif
    public class FastFeatureDetector : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected FastFeatureDetector(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSuppression"></param>
        public static FastFeatureDetector Create(int threshold = 10, bool nonmaxSuppression = true)
        {
            IntPtr ptr = NativeMethods.features2d_FastFeatureDetector_create(threshold, nonmaxSuppression ? 1 : 0);
            return new FastFeatureDetector(ptr);
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
        /// 
        /// </summary>
        public int Threshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_FastFeatureDetector_getThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_FastFeatureDetector_setThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool NonmaxSuppression
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_FastFeatureDetector_getNonmaxSuppression(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_FastFeatureDetector_setNonmaxSuppression(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_FastFeatureDetector_getType(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_FastFeatureDetector_setType(ptr, value);
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
                return NativeMethods.features2d_Ptr_FastFeatureDetector_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_FastFeatureDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
