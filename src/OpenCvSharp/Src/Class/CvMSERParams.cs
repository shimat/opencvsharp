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
    /// MSERのパラメータ
    /// </summary>
#else
    /// <summary>
    /// Various MSER algorithm parameters
    /// </summary>
#endif
    [Serializable]
    public class CvMSERParams : ICloneable
    {
        #region Fields

        /// <summary>
        /// Native structure field
        /// </summary>
        public WCvMSERParams Struct;

#if LANG_JP
        /// <summary>
        /// delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}
        /// </summary>
#else
        /// <summary>
        /// delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}
        /// </summary>
#endif
        public int Delta
        {
            get { return Struct.delta; }
            set { Struct.delta = value; }
        }

#if LANG_JP
        /// <summary>
        /// prune the area which bigger than max_area
        /// </summary>
#else
        /// <summary>
        /// prune the area which bigger than max_area
        /// </summary>
#endif
        public int MaxArea
        {
            get { return Struct.maxArea; }
            set { Struct.maxArea = value; }
        }

#if LANG_JP
        /// <summary>
        /// prune the area which smaller than min_area
        /// </summary>
#else
        /// <summary>
        /// prune the area which smaller than min_area
        /// </summary>
#endif
        public int MinArea
        {
            get { return Struct.minArea; }
            set { Struct.minArea = value; }
        }

#if LANG_JP
        /// <summary>
        /// prune the area have simliar size to its children
        /// </summary>
#else
        /// <summary>
        /// prune the area have simliar size to its children
        /// </summary>
#endif
        public float MaxVariation
        {
            get { return Struct.maxVariation; }
            set { Struct.maxVariation = value; }
        }

#if LANG_JP
        /// <summary>
        /// trace back to cut off mser with diversity &lt; min_diversity
        /// </summary>
#else
        /// <summary>
        /// trace back to cut off mser with diversity &lt; min_diversity
        /// </summary>
#endif
        public float MinDiversity
        {
            get { return Struct.minDiversity; }
            set { Struct.minDiversity = value; }
        }

#if LANG_JP
        /// <summary>
        /// for color image, the evolution steps
        /// </summary>
#else
        /// <summary>
        /// for color image, the evolution steps
        /// </summary>
#endif
        public int MaxEvolution
        {
            get { return Struct.maxEvolution; }
            set { Struct.maxEvolution = value; }
        }

#if LANG_JP
        /// <summary>
        /// the area threshold to cause re-initialize
        /// </summary>
#else
        /// <summary>
        /// the area threshold to cause re-initialize
        /// </summary>
#endif
        public double AreaThreshold
        {
            get { return Struct.areaThreshold; }
            set { Struct.areaThreshold = value; }
        }

#if LANG_JP
        /// <summary>
        /// ignore too small margin
        /// </summary>
#else
        /// <summary>
        /// ignore too small margin
        /// </summary>
#endif
        public double MinMargin
        {
            get { return Struct.minMargin; }
            set { Struct.minMargin = value; }
        }

#if LANG_JP
        /// <summary>
        /// the aperture size for edge blur
        /// </summary>
#else
        /// <summary>
        /// the aperture size for edge blur
        /// </summary>
#endif
        public int EdgeBlurSize
        {
            get { return Struct.edgeBlurSize; }
            set { Struct.edgeBlurSize = value; }
        }
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
#endif
        public CvMSERParams()
            : this(5, 60, 14400, 0.25f, 0.2f, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="minArea">prune the area which smaller than min_area</param>
        /// <param name="maxArea">prune the area which bigger than max_area</param>
        /// <param name="maxVariation">prune the area have simliar size to its children</param>
        /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="maxEvolution">for color image, the evolution steps</param>
        /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
        /// <param name="minMargin">ignore too small margin</param>
        /// <param name="edgeBlurSize">the aperture size for edge blur</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="minArea">prune the area which smaller than min_area</param>
        /// <param name="maxArea">prune the area which bigger than max_area</param>
        /// <param name="maxVariation">prune the area have simliar size to its children</param>
        /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="maxEvolution">for color image, the evolution steps</param>
        /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
        /// <param name="minMargin">ignore too small margin</param>
        /// <param name="edgeBlurSize">the aperture size for edge blur</param>
#endif
        public CvMSERParams(int delta, int minArea, int maxArea, float maxVariation, float minDiversity, 
            int maxEvolution, double areaThreshold, double minMargin, int edgeBlurSize)
        {
            Delta = delta;
            MinArea = minArea;
            MaxArea = maxArea;
            MaxVariation = maxVariation;
            MinDiversity = minDiversity;
            MaxEvolution = maxEvolution;
            AreaThreshold = areaThreshold;
            MinMargin = minMargin;
            EdgeBlurSize = edgeBlurSize;
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
        public CvMSERParams Clone()
        {
            return (CvMSERParams)MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
}
