/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// cvSubdiv2DRotateEdgeにおける辺の関係の指定（入力された辺と同じquad-edgeのどの辺を返すかを指定）
	/// </summary>
#else
    /// <summary>
    /// Specifies, which of edges of the same quad-edge as the input one to return
    /// </summary>
#endif
    public enum RotateEdgeFlag : int
    {
#if LANG_JP
		/// <summary>
		/// 入力の辺（eが入力された場合, 上図の e 自身） 
        /// [= 0]
		/// </summary>
#else
        /// <summary>
        /// the input edge (e on the picture above if e is the input edge) 
        /// [= 0]
        /// </summary>
#endif
        Input = 0,
#if LANG_JP
		/// <summary>
		/// 回転された辺（eRot）
        /// [= 1]
		/// </summary>
#else
        /// <summary>
        /// the rotated edge (eRot) 
        /// [= 1]
        /// </summary>
#endif
        Rotate = 1,
#if LANG_JP
		/// <summary>
		/// 反転された辺（eの反転（緑で表示））
        /// [= 2]
		/// </summary>
#else
        /// <summary>
        /// the reversed edge (reversed e (in green)) 
        /// [= 2]
        /// </summary>
#endif
        Reverse = 2,
#if LANG_JP
		/// <summary>
		/// 反転と回転された辺（eRotの反転（緑で表示））
        /// [= 3] 
		/// </summary>
#else
        /// <summary>
        /// the reversed rotated edge (reversed eRot (in green)) 
        /// [= 3]
        /// </summary>
#endif
        ReverseRotate = 3,
    }
}
