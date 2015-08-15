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
        private bool disposed;
        private Ptr<FREAK> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected FREAK(IntPtr p)
        {
            ptrObj = new Ptr<FREAK>(p);
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

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources

                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
