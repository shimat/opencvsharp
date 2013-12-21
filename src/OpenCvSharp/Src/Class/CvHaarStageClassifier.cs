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
    /// ブーストされた分類器の組（= 段階分類器（stage classifiers））： 
    /// 分類器の応答の合計がthresholdよりも大きい場合には
    /// 段階分類器は 1 を返し，そうでない場合は 0 を返す．
    /// </summary>
#else
    /// <summary>
    /// a boosted battery of classifiers(=stage classifier):
    /// the stage classifier returns 1
    /// if the sum of the classifiers' responces
    /// is greater than threshold and 0 otherwise
    /// </summary>
#endif
    public class CvHaarStageClassifier : CvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタで初期化
        /// </summary>
        /// <param name="ptr">struct CvHaarStageClassifier*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvHaarStageClassifier*</param>
#endif
        public CvHaarStageClassifier(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            this._ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvHaarStageClassifier) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvHaarStageClassifier));


#if LANG_JP
        /// <summary>
        /// 組に含まれる分類器の個数
        /// </summary>
#else
        /// <summary>
        /// Number of classifiers in the battery
        /// </summary>
#endif
        public int Count
		{
            get
            {
                unsafe
                {
                    return ((WCvHaarStageClassifier*)_ptr)->count;
                }
            }
		}

#if LANG_JP
        /// <summary>
        /// ブーストされた分類器で用いる閾値
        /// </summary>
#else
        /// <summary>
        /// Threshold for the boosted classifier 
        /// </summary>
#endif
		public float Threshold
		{
            get
            {
                unsafe
                {
                    return ((WCvHaarStageClassifier*)_ptr)->threshold;
                }
            }
		}

#if LANG_JP
        /// <summary>
        /// 分類器の配列
        /// </summary>
#else
        /// <summary>
        /// Array of classifiers
        /// </summary>
#endif
		public CvHaarClassifier[] Classifier
		{
            get
            {
                unsafe
                {
                    WCvHaarStageClassifier* p = (WCvHaarStageClassifier*)_ptr;
                    WCvHaarClassifier* classifier = (WCvHaarClassifier*)p->classifier;

                    int length = p->count;
                    CvHaarClassifier[] result = new CvHaarClassifier[length];
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = new CvHaarClassifier(new IntPtr(&classifier[i]));
                    }
                    return result;
                }
            }
		}

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
		public int Next 
		{
            get
            {
                unsafe
                {
                    return ((WCvHaarStageClassifier*)_ptr)->next;
                }
            }
		}

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
		public int Child 
		{
            get
            {
                unsafe
                {
                    return ((WCvHaarStageClassifier*)_ptr)->child;
                }
            }
		}

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
		public int Parent 
		{
            get
            {
                unsafe
                {
                    return ((WCvHaarStageClassifier*)_ptr)->parent;
                }
            }
		}
        #endregion
    }
}
