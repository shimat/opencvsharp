/*
 * (C) 2008-2014 shimat
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
    /// オリジナルの細分割と双対細分割の点を表すクラス
    /// </summary>
#else
    /// <summary>
    /// Point of original or dual subdivision
    /// </summary>
#endif
    public class CvSubdiv2DPoint : DisposableCvObject
    {
        #region Constructors & Destructor
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvSubdiv2DPoint(IntPtr ptr)
        {
            this.ptr = ptr;
            base.NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        internal unsafe CvSubdiv2DPoint(void* ptr)
            : this(new IntPtr(ptr))
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタからオブジェクトを生成して返す
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvSubdiv2DPoint instance from native pointer
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DPoint FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            return new CvSubdiv2DPoint(ptr);
        }
#if LANG_JP
        /// <summary>
        /// ポインタからの明示的なキャスト
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Explicit cast from IntPtr to CvSubdiv2DPoint
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static explicit operator CvSubdiv2DPoint(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            return new CvSubdiv2DPoint(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSubdiv2DPoint) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSubdiv2DPoint));


#if LANG_JP
        /// <summary>
        /// 様々なフラグ
        /// </summary>
#else
        /// <summary>
        /// Miscellaneous flags
        /// </summary>
#endif
        public int Flags
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2DPoint*)ptr)->flags;
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
        public uint First
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2DPoint*)ptr)->first;
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
        public CvPoint2D32f Pt
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2DPoint*)ptr)->pt;
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
        public int ID
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2DPoint*)ptr)->id;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvSubdiv2DPoint*)ptr)->id = value;
                }
            }
        }
        #endregion
    }
}
