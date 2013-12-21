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
    /// 4辺の内の一つ．実体はUInt32であり、暗黙のキャストが定義されている.
    /// 下位2ビットはインデックス（0...3）で, 上位ビットは4辺へのポインタ．
    /// </summary>
#else
    /// <summary>
    /// one of edges within quad-edge, lower 2 bits is index (0..3)
    /// and upper bits are quad-edge pointer
    /// </summary>
    /// <remarks>
    /// typedef size_t CvSubdiv2DEdge;
    /// typedef unsigned int size_t;
    /// </remarks>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvSubdiv2DEdge
    {
#if LANG_JP
        /// <summary>
        /// 実体データ (size_t型)
        /// </summary>
#else
        /// <summary>
        /// Data (size_t)
        /// </summary>
#endif
        public IntPtr Value;


#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="value"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
#endif
        public CvSubdiv2DEdge(uint value)
        {
            this.Value = new IntPtr((int)value);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="value"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
#endif
        public CvSubdiv2DEdge(ulong value)
        {
            this.Value = new IntPtr((long)value);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="value"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
#endif
        public CvSubdiv2DEdge(IntPtr value)
        {
            this.Value = value;
        }

        #region Operators
#if LANG_JP
        /// <summary>
        /// CvSubdiv2DEdgeからuintへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implicit cast to uint
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator uint(CvSubdiv2DEdge self)
        {
            return (uint)self.Value.ToInt32();
        }
#if LANG_JP
        /// <summary>
        /// CvSubdiv2DEdgeからulongへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implicit cast to ulong
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator ulong(CvSubdiv2DEdge self)
        {
            return (ulong)self.Value.ToInt64();
        }
#if LANG_JP
        /// <summary>
        /// CvSubdiv2DEdgeからIntPtrへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implicit cast to IntPtr
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator IntPtr(CvSubdiv2DEdge self)
        {
            return self.Value;
        }
#if LANG_JP
        /// <summary>
        /// uintからCvSubdiv2DEdgeへの暗黙のキャスト
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implicit cast from uint to CvSubdiv2DEdge
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#endif
        public static implicit operator CvSubdiv2DEdge(uint v)
        {
            return new CvSubdiv2DEdge(v);
        }
#if LANG_JP
        /// <summary>
        /// ulongからCvSubdiv2DEdgeへの暗黙のキャスト
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implicit cast from IntPtr to CvSubdiv2DEdge
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#endif
        public static implicit operator CvSubdiv2DEdge(ulong v)
        {
            return new CvSubdiv2DEdge(v);
        }
#if LANG_JP
        /// <summary>
        /// IntPtrからCvSubdiv2DEdgeへの暗黙のキャスト
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implicit cast from IntPtr to CvSubdiv2DEdge
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#endif
        public static implicit operator CvSubdiv2DEdge(IntPtr v)
        {
            return new CvSubdiv2DEdge(v);
        }
        #endregion

        #region OpenCV Methods
        #region GetEdge
#if LANG_JP
        /// <summary>
        /// 入力された辺に関連する辺の一つを返す (cvSubdiv2DGetEdge).
        /// </summary>
        /// <param name="type">戻り値とする辺の条件</param>
        /// <returns>与えられた辺に関連する辺の一つ</returns>
#else
        /// <summary>
        /// Returns one of edges related to given (cvSubdiv2DGetEdge).
        /// </summary>
        /// <param name="type">Specifies, which of related edges to return</param>
        /// <returns>one the edges related to the input edge</returns>
#endif
        public CvSubdiv2DEdge GetEdge(CvNextEdgeType type)
        {
            return Cv.Subdiv2DGetEdge(this, type);
        }
        #endregion
        #region Dst
#if LANG_JP
        /// <summary>
        /// 辺の終点を返す (cvSubdiv2DEdgeDst)．
        /// 仮想点は関数 cvCalcSubdivVoronoi2D を用いて計算される.
        /// </summary>
        /// <returns>辺の終点. 辺が双対細分割のものであり，仮想点の座標がまだ計算されていない場合は，nullを返す．</returns>
#else
        /// <summary>
        /// Returns edge destination (cvSubdiv2DEdgeDst)．
        /// </summary>
        /// <returns>The edge destination. If the edge is from dual subdivision and the virtual point coordinates are not calculated yet, the returned pointer may be null.</returns>
#endif
        public CvSubdiv2DPoint Dst()
        {
            return Cv.Subdiv2DEdgeDst(this);
        }
        #endregion
        #region Org
#if LANG_JP
        /// <summary>
        /// 辺の始点を返す (cvSubdiv2DEdgeOrg)． 
        /// 仮想点は関数 cvCalcSubdivVoronoi2D を用いて計算される.
        /// </summary>
        /// <returns>辺の始点. 辺が双対細分割のものであり，仮想点の座標がまだ計算されていない場合は，nullを返す．</returns>
#else
        /// <summary>
        /// Returns edge origin (cvSubdiv2DEdgeOrg)．
        /// </summary>
        /// <returns>The edge origin. If the edge is from dual subdivision and the virtual point coordinates are not calculated yet, the returned pointer may be null.</returns>
#endif
        public CvSubdiv2DPoint Org()
        {
            return Cv.Subdiv2DEdgeOrg(this);
        }
        #endregion
        #region RotateEdge
#if LANG_JP
        /// <summary>
        /// 入力された辺を含むquad-edge中の辺の一つを返す (cvSubdiv2DRotateEdge)．
        /// </summary>
        /// <param name="rotate">関係の指定（入力された辺と同じquad-edgeのどの辺を返すかを指定）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns another edge of the same quad-edge (cvSubdiv2DRotateEdge).
        /// </summary>
        /// <returns>one the edges of the same quad-edge as the input edge. </returns>
#endif
        public CvSubdiv2DEdge RotateEdge(RotateEdgeFlag rotate)
        {
            return Cv.Subdiv2DRotateEdge(this, rotate);
        }
        #endregion
        #endregion

#if LANG_JP
        /// <summary>
        /// 文字列形式を返す 
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
        public override string ToString()
        {
            return string.Format("CvSubdiv2DEdge({0})", Value);
        }
    }
}
