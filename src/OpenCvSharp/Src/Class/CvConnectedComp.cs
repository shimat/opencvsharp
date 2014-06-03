using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 連結成分
    /// </summary>
#else
    /// <summary>
    /// Connected component
    /// </summary>
#endif
    public class CvConnectedComp : DisposableCvObject
    {
        #region Init and disposal
#if LANG_JP
        /// <summary>
        /// メモリ領域を確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Empty constructor
        /// </summary>
#endif
        public CvConnectedComp()
        {
            this.ptr = AllocMemory(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr">struct CvConnectedComp*</param>
#endif
        public CvConnectedComp(IntPtr ptr)
        {
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタからオブジェクトを生成する
        /// </summary>
#else
        /// <summary>
        /// Creates a CvConnectedComp from a pointer
        /// </summary>
#endif
        public static CvConnectedComp FromPtr(IntPtr ptr)
        {
            return new CvConnectedComp(ptr);
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
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            // 親の解放処理
            base.Dispose(disposing);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvConnectedComp)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvConnectedComp));

#if LANG_JP
        /// <summary>
        /// セグメント化された連結成分の面積
        /// </summary>
#else
        /// <summary>
        /// area of the connected component
        /// </summary>
#endif
        public double Area
        {
            get
            {
                unsafe
                {
                    return ((WCvConnectedComp*)ptr)->area;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// セグメント化された連結成分のグレースケール値
        /// </summary>
#else
        /// <summary>
        /// average color of the connected component
        /// </summary>
#endif
        public CvScalar Value
        {
            get
            {
                unsafe
                {
                    return ((WCvConnectedComp*)ptr)->value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// セグメント化された連結成分のROI
        /// </summary>
#else
        /// <summary>
        /// ROI of the component
        /// </summary>
#endif
        public CvRect Rect
        {
            get
            {
                unsafe
                {
                    return ((WCvConnectedComp*)ptr)->rect;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// optional component boundary (the contour might have child contours corresponding to the holes)
        /// </summary>
#endif
        [Obsolete]
        public CvSeq<CvPoint> Contour
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvConnectedComp*)ptr)->contour);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvSeq<CvPoint>(p);
                }
            }
        }        
        #endregion
    }
}
