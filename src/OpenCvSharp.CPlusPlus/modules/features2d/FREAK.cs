/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
    public class FREAK : FeatureDetector
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orientationNormalized">enable orientation normalization</param>
        /// <param name="scaleNormalized">enable scale normalization</param>
        /// <param name="patternScale">scaling of the description pattern</param>
        /// <param name="nOctaves">number of octaves covered by the detected keypoints</param>
        /// <param name="selectedPairs">(optional) user defined selected pairs</param>
        public FREAK(
            bool orientationNormalized = true,
            bool scaleNormalized = true,
            float patternScale = 22.0f,
            int nOctaves = 4,
            IEnumerable<int> selectedPairs = null)
        {
            int[] selectedPairsArray = EnumerableEx.ToArray(selectedPairs);
            int selectedPairslength = selectedPairs == null ? 0 : selectedPairsArray.Length;

            ptr = NativeMethods.features2d_FREAK_new(orientationNormalized ? 1 : 0,
                scaleNormalized ? 1 : 0, patternScale, nOctaves, 
                selectedPairsArray, selectedPairslength);
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
                    }
                    // releases unmanaged resources
                    if (ptr != IntPtr.Zero)
                        NativeMethods.features2d_FREAK_delete(ptr);
                    ptr = IntPtr.Zero;
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
        /// <summary>
        /// returns the descriptor size in bytes
        /// </summary>
        /// <returns></returns>
        public int DescriptorSize()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_FREAK_descriptorSize(ptr);
        }

        /// <summary>
        /// returns the descriptor type
        /// </summary>
        /// <returns></returns>
        public int DescriptorType()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_FREAK_descriptorType(ptr);
        }

        /// <summary>
        /// select the 512 "best description pairs"
        /// </summary>
        /// <param name="images">grayscale images set</param>
        /// <param name="keypoints">set of detected keypoints</param>
        /// <param name="corrThresh">correlation threshold</param>
        /// <param name="verbose">print construction information</param>
        /// <returns>list of best pair indexes</returns>
        public int[] SelectPairs(IEnumerable<Mat> images, out KeyPoint[][] keypoints,
            double corrThresh = 0.7, bool verbose = true)
        {
            if (images == null)
                throw new ArgumentNullException("images");

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            using (VectorOfInt32 outVec = new VectorOfInt32())
            using (VectorOfVectorKeyPoint keypointsVec = new VectorOfVectorKeyPoint())
            {
                NativeMethods.features2d_FREAK_selectPairs(ptr, imagesPtrs, imagesPtrs.Length,
                    keypointsVec.CvPtr, corrThresh, verbose ? 1 : 0, outVec.CvPtr);
                keypoints = keypointsVec.ToArray();
                return outVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AlgorithmInfo Info
        {
            get
            {
                ThrowIfDisposed();
                IntPtr pInfo = NativeMethods.features2d_FREAK_info(ptr);
                return new AlgorithmInfo(pInfo);
            }
        }
        #endregion
    }
}
