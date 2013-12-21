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
    /// 平面細分割のQuad-edge構造体
    /// </summary>
#else
    /// <summary>
    /// Quad-edge of planar subdivision
    /// </summary>
#endif
    public class CvQuadEdge2D : CvObject
    {
        #region Initialization & Operators
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvQuadEdge2D*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvQuadEdge2D(IntPtr ptr)
        {
            this._ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタからオブジェクトを生成する
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an instance from native pointer
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static CvQuadEdge2D FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            return new CvQuadEdge2D(ptr);
        }
#if LANG_JP
        /// <summary>
        /// ポインタからの明示的なキャスト
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// explicit cast from IntPtr to CvQuadEdge2D 
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static explicit operator CvQuadEdge2D(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            return new CvQuadEdge2D(ptr);
        }
#if LANG_JP
        /// <summary>
        /// CvSeqReaderからCvQuadEdge2Dのインスタンスを読み込んで返す
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Reads a CvQuadEdge2D instance from CvSeqReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
#endif
        public static CvQuadEdge2D FromSeqReader(CvSeqReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            return new CvQuadEdge2D(reader.Ptr);
        }

#if LANG_JP
        /// <summary>
        /// CvSubdiv2DEdgeへの明示的キャスト
        /// </summary>
        /// <param name="self"></param>
#else
        /// <summary>
        /// explicit cast to CvSubdiv2DEdge
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static explicit operator CvSubdiv2DEdge(CvQuadEdge2D self)
        {
            return self.ToCvSubdiv2DEdge();
        }
#if LANG_JP
        /// <summary>
        /// CvSubdiv2DEdgeへ変換して返す
        /// </summary>
#else
        /// <summary>
        /// Converts to a CvSubdiv2DEdge instance
        /// </summary>
        /// <returns></returns>
#endif
        public CvSubdiv2DEdge ToCvSubdiv2DEdge()
        {
            return new CvSubdiv2DEdge((uint)this.CvPtr.ToInt32());
            //uint value = (uint)Marshal.ReadInt32(this.CvPtr);
            //return new CvSubdiv2DEdge(value);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvQuadEdge2D)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvQuadEdge2D));

        /// <summary>
        /// CvSubdiv2DEdge pt[4];
        /// </summary>
        public CvSubdiv2DPoint[] Pt
        {
            get
            {
                unsafe
                {
                    WCvQuadEdge2D* p = ((WCvQuadEdge2D*)_ptr);
                    return new CvSubdiv2DPoint[] {
                        new CvSubdiv2DPoint(p->pt0), 
                        new CvSubdiv2DPoint(p->pt1), 
                        new CvSubdiv2DPoint(p->pt2), 
                        new CvSubdiv2DPoint(p->pt3),
                    };
                }
            }
        }
        /// <summary>
        /// CvSubdiv2DEdge next[4];
        /// </summary>
        public CvSubdiv2DEdge[] Next
        {
            get 
            {
                unsafe
                {
                    WCvQuadEdge2D* p = ((WCvQuadEdge2D*)_ptr);
                    return new CvSubdiv2DEdge[] { p->next0, p->next1, p->next2, p->next3 };
                }
            }
        }
        #endregion
    }
}
