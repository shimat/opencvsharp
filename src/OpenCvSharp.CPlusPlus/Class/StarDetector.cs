/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// Star Detector
    /// </summary>
#else
    /// <summary>
    /// Star Detector
    /// </summary>
#endif
    [Serializable]
    public class StarDetector : CvStarDetectorParams, ICloneable
    {
        #region Constructors
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Constructor
        /// </summary>
#endif
        public StarDetector()
            : base()
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
#endif
        public StarDetector(int maxSize)
            : base(maxSize)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
#endif
        public StarDetector(int maxSize, int responseThreshold)
            : base(maxSize, responseThreshold)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
#endif
        public StarDetector(int maxSize, int responseThreshold, int lineThresholdProjected)
            : base(maxSize, responseThreshold, lineThresholdProjected)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
#endif
        public StarDetector(int maxSize, int responseThreshold, int lineThresholdProjected, int lineThresholdBinarized)
            : base(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized)
        {
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
        public StarDetector(int maxSize, int responseThreshold, int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize)
            : base(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize)
        {
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// StarDetectorアルゴリズムによりキーポイントを取得する
        /// </summary>
        /// <param name="image">8ビット グレースケールの入力画像</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves keypoints using the StarDetector algorithm.
        /// </summary>
        /// <param name="image">The input 8-bit grayscale image</param>
        /// <returns></returns>
#endif
        public KeyPoint[] GetKeyPoints(Mat image)
        {
            if (image == null)
                throw new ArgumentNullException("img");

            using (CvMemStorage storage = new CvMemStorage(0))
            {
                IntPtr ptr = CvInvoke.cvGetStarKeypoints(image.ToCvMat().CvPtr, storage.CvPtr, _p);
                if (ptr == IntPtr.Zero)
                {
                    return new KeyPoint[0];
                }
                CvSeq<CvStarKeypoint> keypoints = new CvSeq<CvStarKeypoint>(ptr);
                KeyPoint[] result = new KeyPoint[keypoints.Total];
                for (int i = 0; i < keypoints.Total; i++)
                {
                    CvStarKeypoint kpt = keypoints[i].Value;
                    result[i] = new KeyPoint(kpt.Pt, (float)kpt.Size, -1.0f, kpt.Response, 0);
                }
                return result;
            }
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
        public new StarDetector Clone()
        {
            return (StarDetector)MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
}
