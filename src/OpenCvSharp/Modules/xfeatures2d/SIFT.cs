﻿using System;
using System.Collections.Generic;

namespace OpenCvSharp.XFeatures2D
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// SIFT 実装.
    /// </summary>
#else
    /// <summary>
    /// SIFT implementation.
    /// </summary>
#endif
    public class SIFT : Feature2D
    {
        private Ptr? detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::SIFT*
        /// </summary>
        protected SIFT(IntPtr p)
        {
            detectorPtr = new Ptr(p);
            ptr = detectorPtr.Get();
        }

        /// <summary>
        /// The SIFT constructor.
        /// </summary>
        /// <param name="nFeatures">The number of best features to retain. 
        /// The features are ranked by their scores (measured in SIFT algorithm as the local contrast)</param>
        /// <param name="nOctaveLayers">The number of layers in each octave. 3 is the value used in D. Lowe paper. 
        /// The number of octaves is computed automatically from the image resolution.</param>
        /// <param name="contrastThreshold">The contrast threshold used to filter out weak features in semi-uniform 
        /// (low-contrast) regions. The larger the threshold, the less features are produced by the detector.</param>
        /// <param name="edgeThreshold">The threshold used to filter out edge-like features. Note that the its meaning is 
        /// different from the contrastThreshold, i.e. the larger the edgeThreshold, the less features are filtered out (more features are retained).</param>
        /// <param name="sigma">The sigma of the Gaussian applied to the input image at the octave #0. 
        /// If your image is captured with a weak camera with soft lenses, you might want to reduce the number.</param>
        public static SIFT Create(int nFeatures = 0, int nOctaveLayers = 3,
            double contrastThreshold = 0.04, double edgeThreshold = 10,
            double sigma = 1.6)
        {
            IntPtr ptr = NativeMethods.xfeatures2d_SIFT_create(
                nFeatures, nOctaveLayers, 
                contrastThreshold, edgeThreshold, sigma);
            return new SIFT(ptr);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            detectorPtr?.Dispose();
            detectorPtr = null;
            base.DisposeManaged();
        }

        #endregion

        #region Properties

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.xfeatures2d_Ptr_SIFT_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xfeatures2d_Ptr_SIFT_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
