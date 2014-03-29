/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 輪郭データ
    /// </summary>
#else
    /// <summary>
    /// Contour data
    /// </summary>
#endif
    public class CvContour : CvSeq<CvPoint>
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 一定のメモリを確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvContour()
            : this(Marshal.AllocHGlobal(SizeOf))
        {
            AllocatedMemory = ptr;
            NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ネイティブのデータポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvContour(IntPtr ptr)
            : base(ptr)
        {
            this.ptr = ptr;
        }

        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvContour) 
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvContour));


        /// <summary>
        /// 
        /// </summary>
        public CvRect Rect
        {
            get
            {
                unsafe
                {
                    return ((WCvContour*)ptr)->rect;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Color
        {
            get
            {
                unsafe
                {
                    return ((WCvContour*)ptr)->color;
                }
            }
        }
        #endregion
    }
}
