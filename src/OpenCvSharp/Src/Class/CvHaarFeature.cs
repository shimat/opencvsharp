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
    /// haar 特徴. 適切な重みを持つ 2 個，あるいは 3 個の矩形から構成される.
    /// </summary>
#else
    /// <summary>
    /// A haar feature which consists of 2-3 rectangles with appropriate weights.
    /// </summary>
#endif
    public class CvHaarFeature : CvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタで初期化
        /// </summary>
        /// <param name="ptr">struct CvHaarFeature*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvHaarFeature*</param>
#endif
        public CvHaarFeature(IntPtr ptr)
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
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvHaarFeature));


#if LANG_JP
        /// <summary>
        /// 0 は，垂直な特徴，1 は，45度回転した特徴を意味する
        /// </summary>
#else
        /// <summary>
        /// 0 means up-right feature, 1 means 45--rotated feature
        /// </summary>
#endif
        public int Tilted
		{
            get
            {
                unsafe
                {
                    return ((WCvHaarFeature*)_ptr)->tilted;
                }
            }
		}

#if LANG_JP
        /// <summary>
        /// haar特徴を構成する矩形
        /// </summary>
#else
        /// <summary>
        /// Elements of the haar feature
        /// </summary>
#endif
        public CvHaarFeature.Rect[] rect
		{
			get
            {                
                unsafe
                {
                    WCvHaarFeature* p = (WCvHaarFeature*)_ptr;
                    CvHaarFeature.Rect[] result = new CvHaarFeature.Rect[CvConst.CV_HAAR_FEATURE_MAX]
                    {
                        new CvHaarFeature.Rect(){ R = p->rect1_r, Weight = p->rect1_weight },
                        new CvHaarFeature.Rect(){ R = p->rect2_r, Weight = p->rect2_weight },
                        new CvHaarFeature.Rect(){ R = p->rect3_r, Weight = p->rect3_weight },
                    };
                    return result;
                }                
            }
		}

#if LANG_JP
        /// <summary>
        /// haar特徴を構成する矩形
        /// </summary>
#else
        /// <summary>
        /// An element of a haar feature
        /// </summary>
#endif
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
#pragma warning disable 1591
            public CvRect R;
            public float Weight;
#pragma warning restore 1591
        }
        #endregion
    }
}
