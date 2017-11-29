using System;

namespace OpenCvSharp.XFeatures2D
{
#if LANG_JP
    /// <summary>
    /// Star Detector
    /// </summary>
#else
    /// <summary>
    /// The "Star" Detector
    /// </summary>
#endif
    [Serializable]
    public class StarDetector : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal StarDetector(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
        /// <param name="suppressNonmaxSize"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
        /// <param name="suppressNonmaxSize"></param>
#endif
        public static StarDetector Create(
            int maxSize = 45, 
            int responseThreshold = 30, 
            int lineThresholdProjected = 10, 
            int lineThresholdBinarized = 8,
            int suppressNonmaxSize = 5)
        {
            IntPtr ptr = NativeMethods.xfeatures2d_StarDetector_create(
                maxSize, responseThreshold, lineThresholdProjected, 
                lineThresholdBinarized, suppressNonmaxSize);
            return new StarDetector(ptr);
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

        #region Methods

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res =  NativeMethods.xfeatures2d_Ptr_StarDetector_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xfeatures2d_Ptr_StarDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
