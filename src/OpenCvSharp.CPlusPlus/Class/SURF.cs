/*
 * (C) 2008-2013 Schima
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
    /// 画像から SURF を抽出するためのクラス．
    /// </summary>
#else
    /// <summary>
    /// Class for extracting Speeded Up Robust Features from an image.
    /// </summary>
#endif
    [Serializable]
    public class SURF : CvSURFParams, ICloneable
    {
        #region Constructors
#if LANG_JP
        /// <summary>
        /// SURFのデフォルトパラメータを生成する
        /// </summary>
        /// <param name="hessianThreshold">keypoint.hessian の値がこの閾値よりも大きい特徴だけが検出される</param>
        /// <param name="extended">false：基本的なディスクリプタ（64要素）, true：拡張されたディスクリプタ（128要素）</param>
#else
        /// <summary>
        /// Creates SURF default parameters
        /// </summary>
        /// <param name="hessianThreshold">Only features with keypoint.hessian larger than that are extracted. </param>
        /// <param name="extended">false means basic descriptors (64 elements each), true means _extended descriptors (128 elements each) </param>
#endif
        public SURF(double hessianThreshold, bool extended)
            : base(hessianThreshold, extended)
        {
        }
        #endregion
        
        #region Methods
#if LANG_JP
        /// <summary>
        /// 高速なマルチスケール Hesian 検出器を用いて keypoint を検出します．
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// detects keypoints using fast multi-scale Hessian detector
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#endif
        public KeyPoint[] Extract(Mat img, Mat mask)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            CvMat imgMat = img.ToCvMat();
            CvMat maskMat = (mask == null) ? null : mask.ToCvMat();

            CvSURFPoint[] keypoints;
            float[][] descriptors;
            Cv.ExtractSURF(imgMat, maskMat, out keypoints, out descriptors, this);

            KeyPoint[] result = new KeyPoint[keypoints.Length];
            for (int i = 0; i < result.Length; i++)
            {
                CvSURFPoint kpt = keypoints[i];
                result[i] = new KeyPoint(kpt.Pt, (float) kpt.Size, kpt.Dir, kpt.Hessian, GetPointOctave(kpt, this));
            }
            return result;
        }

#if LANG_JP
        /// <summary>
        /// keypoint を検出し，その SURF ディスクリプタを計算します．[useProvidedKeypoints = true]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
#else
        /// <summary>
        /// detects keypoints and computes the SURF descriptors for them. [useProvidedKeypoints = true]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
#endif
        public void Extract(Mat img, Mat mask, KeyPoint[] keypoints, out float[][] descriptors)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            CvMat imgMat = img.ToCvMat();
            CvMat maskMat = (mask == null) ? null : mask.ToCvMat();

            CvSURFPoint[] kpt = new CvSURFPoint[keypoints.Length];
            for (int i = 0; i < keypoints.Length; i++)
            {
                KeyPoint k = keypoints[i];
                kpt[i] = new CvSURFPoint(k.Pt, 1, (int) Math.Round(k.Size), k.Angle, k.Response);
            }

            Cv.ExtractSURF(imgMat, maskMat, ref kpt, out descriptors, this, true);

            for (int i = 0; i < kpt.Length; i++)
            {
                CvSURFPoint p = kpt[i];
                keypoints[i] = new KeyPoint(p.Pt, p.Size, p.Dir, p.Hessian, GetPointOctave(p, this));
            }
        }


#if LANG_JP
        /// <summary>
        /// keypoint を検出し，その SURF ディスクリプタを計算します．[useProvidedKeypoints = false]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
#else
        /// <summary>
        /// detects keypoints and computes the SURF descriptors for them. [useProvidedKeypoints = false]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
#endif
        public void Extract(Mat img, Mat mask, out KeyPoint[] keypoints, out float[][] descriptors)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            CvMat imgMat = img.ToCvMat();
            CvMat maskMat = (mask == null) ? null : mask.ToCvMat();

            CvSURFPoint[] kpt;
            Cv.ExtractSURF(imgMat, maskMat, out kpt, out descriptors, this);

            keypoints = new KeyPoint[kpt.Length];
            for (int i = 0; i < keypoints.Length; i++)
            {
                CvSURFPoint p = kpt[i];
                keypoints[i] = new KeyPoint(p.Pt, (float) p.Size, p.Dir, p.Hessian, GetPointOctave(p, this));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kpt"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        static private int GetPointOctave(CvSURFPoint kpt, CvSURFParams param)
        {
            /* Wavelet size at first layer of first octave. */ 
            const int HAAR_SIZE0 = 9;
            /* Wavelet size increment between layers. This should be an even number, 
             such that the wavelet sizes in an octave are either all even or all odd.
             This ensures that when looking for the neighbours of a sample, the layers
             above and below are aligned correctly. */
            const int HAAR_SIZE_INC = 6;

            int bestOctave = 0;
            float minDiff = float.MaxValue;
            for (int octave = 1; octave < param.NOctaves; octave++)
            {
                for (int layer = 0; layer < param.NOctaveLayers; layer++)
                {
                    float diff = Math.Abs(kpt.Size - (float)((HAAR_SIZE0 + HAAR_SIZE_INC * layer) << octave));
                    if (minDiff > diff)
                    {
                        minDiff = diff;
                        bestOctave = octave;
                        if (Math.Abs(minDiff - 0) < 1e-9)
                            return bestOctave;
                    }
                }
            }
            return bestOctave;
        }
        #endregion

        #region ICloneable Members
#if LANG_JP
        /// <summary>
        /// 現在のインスタンスのコピーである新しいオブジェクトを作成します。    
        /// </summary>
        /// <returns>このインスタンスのコピーである新しいオブジェクト。</returns>
#else
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
#endif
        public new SURF Clone()
        {
            return (SURF)MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }
}
