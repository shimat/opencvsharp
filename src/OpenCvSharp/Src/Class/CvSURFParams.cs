/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// SURFのパラメータ
    /// </summary>
#else
    /// <summary>
    /// Various SURF algorithm parameters
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class CvSURFParams : ICloneable
    {
        /// <summary>
        /// Field data
        /// </summary>
        protected WCvSURFParams _p;

        #region Properties
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        internal WCvSURFParams Struct
        {
            get { return _p; }
        }

#if LANG_JP
        /// <summary>
        /// false : 基本的なディスクリプタ（64要素）
        /// true: 拡張されたディスクリプタ（128要素）
        /// </summary>
#else
        /// <summary>
        /// false means basic descriptors (64 elements each),
        /// true means _extended descriptors (128 elements each)
        /// </summary>
#endif
        public bool Extended
        {
            get { return _p.extended != 0; }
            set { _p.extended = value ? 1 : 0; }
        }


#if LANG_JP
        /// <summary>
        /// keypoint.hessian の値がこの閾値よりも大きい特徴だけが検出される．
        /// 適切なデフォルト値は，おおよそ300〜500 である（画像の局所的なコントラストと鮮明さの平均に依存する）．
        /// ユーザは，hessian や，その他の特徴に基づいて，不要な特徴点を除去することができる．
        /// </summary>
#else
        /// <summary>
        /// Only features with keypoint.hessian larger than that are extracted.
        /// good default value is ~300-500 (can depend on the average
        /// local contrast and sharpness of the image).
        /// user can further filter out some features based on their hessian values
        /// and other characteristics
        /// </summary>
#endif
        public double HessianThreshold
        {
            get { return _p.hessianThreshold; }
            set { _p.hessianThreshold = value; }
        }


#if LANG_JP
        /// <summary>
        /// 特徴検出に用いられるオクターブ数.
        /// オクターブが一つ上がる度に，特徴のサイズが2倍になる（デフォルトは3）.
        /// </summary>
#else
        /// <summary>
        /// The number of octaves to be used for extraction.
        /// With each next octave the feature size is doubled (3 by default)
        /// </summary>
#endif
        public int NOctaves
        {
            get { return _p.nOctaves; }
            set { _p.nOctaves = value; }
        }


#if LANG_JP
        /// <summary>
        /// 各オクターブ内に存在するレイヤ数（デフォルトは4）.
        /// </summary>
#else
        /// <summary>
        /// The number of layers within each octave (4 by default)
        /// </summary>
#endif
        public int NOctaveLayers
        {
            get { return _p.nOctaveLayers; }
            set { _p.nOctaveLayers = value; }
        }
        #endregion

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
        public CvSURFParams(double hessianThreshold, bool extended)
        {
            _p = CvInvoke.cvSURFParams(hessianThreshold, extended);
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
        public CvSURFParams Clone()
        {
            return (CvSURFParams)MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }
}
