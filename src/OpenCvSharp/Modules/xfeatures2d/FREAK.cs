using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

// ReSharper disable once InconsistentNaming

namespace OpenCvSharp.XFeatures2D
{
#if LANG_JP
    /// <summary>
    /// FREAK 実装
    /// </summary>
#else
    /// <summary>
    /// FREAK implementation
    /// </summary>
#endif
    public class FREAK : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected FREAK(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orientationNormalized">enable orientation normalization</param>
        /// <param name="scaleNormalized">enable scale normalization</param>
        /// <param name="patternScale">scaling of the description pattern</param>
        /// <param name="nOctaves">number of octaves covered by the detected keypoints</param>
        /// <param name="selectedPairs">(optional) user defined selected pairs</param>
        public static FREAK Create(
            bool orientationNormalized = true,
            bool scaleNormalized = true,
            float patternScale = 22.0f,
            int nOctaves = 4,
            IEnumerable<int> selectedPairs = null)
        {
            int[] selectedPairsArray = EnumerableEx.ToArray(selectedPairs);
            int selectedPairslength = selectedPairs == null ? 0 : selectedPairsArray.Length;

            IntPtr ptr = NativeMethods.xfeatures2d_FREAK_create(orientationNormalized ? 1 : 0,
                scaleNormalized ? 1 : 0, patternScale, nOctaves,
                selectedPairsArray, selectedPairslength);
            return new FREAK(ptr);
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

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.xfeatures2d_Ptr_FREAK_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xfeatures2d_Ptr_FREAK_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
