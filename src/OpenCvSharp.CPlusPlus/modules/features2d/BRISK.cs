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
    /// BRISK 実装
    /// </summary>
#else
    /// <summary>
    /// BRISK implementation
    /// </summary>
#endif
    public class BRISK : FeatureDetector
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thresh"></param>
        /// <param name="octaves"></param>
        /// <param name="patternScale"></param>
        public BRISK(int thresh = 30, int octaves = 3, float patternScale = 1.0f)
        {
            ptr = NativeMethods.features2d_BRISK_new(thresh, octaves, patternScale);
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
                        NativeMethods.features2d_BRISK_delete(ptr);
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
            return NativeMethods.features2d_BRISK_descriptorSize(ptr);
        }

        /// <summary>
        /// returns the descriptor type
        /// </summary>
        /// <returns></returns>
        public int DescriptorType()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_BRISK_descriptorType(ptr);
        }

        /// <summary>
        /// Compute the BRISK features on an image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public KeyPoint[] Run(InputArray image, InputArray mask = null)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (VectorOfKeyPoint keyPointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_BRISK_run1(ptr, image.CvPtr, Cv2.ToPtr(mask), keyPointsVec.CvPtr);
                return keyPointsVec.ToArray();
            }
        }

        /// <summary>
        /// Compute the BRISK features and descriptors on an image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="keyPoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
        public void Run(InputArray image, InputArray mask, out KeyPoint[] keyPoints,
            OutputArray descriptors, bool useProvidedKeypoints = false)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException("image");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");
            image.ThrowIfDisposed();
            descriptors.ThrowIfNotReady();

            using (VectorOfKeyPoint keyPointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_BRISK_run2(ptr, image.CvPtr, Cv2.ToPtr(mask), keyPointsVec.CvPtr,
                    descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
                keyPoints = keyPointsVec.ToArray();
            }
            descriptors.Fix();
        }
        /// <summary>
        /// Compute the BRISK features and descriptors on an image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="keyPoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
        public void Run(InputArray image, InputArray mask, out KeyPoint[] keyPoints,
            out float[] descriptors, bool useProvidedKeypoints = false)
        {
            MatOfFloat descriptorsMat = new MatOfFloat();
            Run(image, mask, out keyPoints, descriptorsMat, useProvidedKeypoints);
            descriptors = descriptorsMat.ToArray();
        }


        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get
            {
                return NativeMethods.features2d_BRISK_info(ptr);
            }
        }
        #endregion
    }
}
