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
    /// 単一決定木による分類器（最も単純な場合は stump）.
    /// これは個々の画像位置における特徴に対する応答（つまりウィンドウ内の部分矩形におけるピクセル合計値）
　　/// を返し，その応答に依存する値を出力する
    /// </summary>
#else
    /// <summary>
    /// a single tree classifier (stump in the simplest case) that returns the response for the feature
    /// at the particular image location (i.e. pixel sum over subrectangles of the window) and gives out
    /// a value depending on the responce
    /// </summary>
#endif
    public class CvHaarClassifier : CvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタで初期化
        /// </summary>
        /// <param name="ptr">struct CvHaarClassifier*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvHaarClassifier*</param>
#endif
        public CvHaarClassifier(IntPtr ptr)
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
        /// sizeof(CvHaarClassifier) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvHaarClassifier));


#if LANG_JP
        /// <summary>
        /// 決定木のノード数
        /// </summary>
#else
        /// <summary>
        /// Number of nodes in the decision tree
        /// </summary>
#endif
        public int Count
        {
            get
            {
                unsafe
                {
                    return ((WCvHaarClassifier*)_ptr)->count;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// haar特徴の配列
        /// </summary>
#else
        /// <summary>
        /// Array of haar features
        /// </summary>
#endif
        public CvHaarFeature[] HaarFeature
        {
            get
            {
                unsafe
                {
                    WCvHaarClassifier* p = (WCvHaarClassifier*)_ptr;
                    WCvHaarFeature* haar_feature = (WCvHaarFeature*)p->haar_feature;

                    int length = p->count;
                    CvHaarFeature[] result = new CvHaarFeature[length];
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = new CvHaarFeature(new IntPtr(&haar_feature[i]));
                    }
                    return result;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 枝の閾値．特徴応答 &lt;= threshold となる場合は左側の枝が選択され，そうでない場合は右の枝が選択される．
        /// </summary>
#else
        /// <summary>
        /// branch threshold. if feature responce is &lt;= threshold, left branch is chosen, otherwise right branch is chosed.
        /// </summary>
#endif
        public PointerAccessor1D_Single Threshold
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvHaarClassifier*)_ptr)->threshold;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 左側の子のインデックス（左側の子が葉だった場合には負のインデックス）
        /// </summary>
#else
        /// <summary>
        /// index of the left child (or negated index if the left child is a leaf)
        /// </summary>
#endif
        public PointerAccessor1D_Int32 Left
        {
            get
            {
                unsafe
                {
                    int* p = ((WCvHaarClassifier*)_ptr)->left;
                    return new PointerAccessor1D_Int32(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 右側の子のインデックス（右側の子が葉だった場合には負のインデックス）
        /// </summary>
#else
        /// <summary>
        /// index of the right child (or negated index if the right child is a leaf)
        /// </summary>
#endif
        public PointerAccessor1D_Int32 Right
        {
            get
            {
                unsafe
                {
                    int* p = ((WCvHaarClassifier*)_ptr)->right;
                    return new PointerAccessor1D_Int32(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 葉に対応する出力値
        /// </summary>
#else
        /// <summary>
        /// output value correponding to the leaf.
        /// </summary>
#endif
        public PointerAccessor1D_Single Alpha
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvHaarClassifier*)_ptr)->alpha;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }
        #endregion
    }
}
