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
	/// CvSeqのさまざまな特性. EltypeXXX | KindXXXというようにして指定する.
	/// 上位16ビットで個々の動的特性と，シーケンスに関するその他の雑多な情報を持つ．
	/// 下位CV_SEQ_ELTYPE_BITS ビットは，要素タイプのIDを示す．
	/// </summary>    
#else
    /// <summary>
    /// The field flagscontain the particular dynamic type signature
    /// (CV_SEQ_MAGIC_VAL for dense sequences and CV_SET_MAGIC_VAL for sparse sequences) in the highest 16 bits and miscellaneous information about the sequence.
    /// The lowest CV_SEQ_ELTYPE_BITS bits contain the ID of the element type. 
    /// </summary>
#endif
	[Flags]
	public enum SeqType : int
	{
#if LANG_JP
		/// <summary>
		/// 特定のシーケンスタイプを引数にとるような関数に一切渡されない場合はこの値を指定してもかまわない
		/// </summary>
#else
        /// <summary>
        /// If the sequence is not passed to any function working with a specific type of sequences, you may use this value
        /// </summary>
#endif
        Zero = 0,


		#region Eltype
		/// <summary>
		/// (x,y) [CV_SEQ_ELTYPE_POINT]
		/// </summary>
		EltypePoint = CvConst.CV_SEQ_ELTYPE_POINT,
#if LANG_JP
		/// <summary>
		/// フリーマンコード: 0..7 [CV_SEQ_ELTYPE_CODE]
		/// </summary>
#else
        /// <summary>
        /// freeman code: 0..7 [CV_SEQ_ELTYPE_CODE]
        /// </summary>
#endif
        EltypeCode = CvConst.CV_SEQ_ELTYPE_CODE,
#if LANG_JP
		/// <summary>
		/// 一般的なシーケンス要素タイプ [CV_SEQ_ELTYPE_GENERIC]
		/// </summary>
#else
        /// <summary>
        /// unspecified type of sequence elements [CV_SEQ_ELTYPE_GENERIC]
        /// </summary>
#endif
        EltypeGeneric = CvConst.CV_SEQ_ELTYPE_GENERIC,
		/// <summary>
		/// =6 [CV_SEQ_ELTYPE_PTR]
		/// </summary>
        EltypePtr = CvConst.CV_SEQ_ELTYPE_PTR,
#if LANG_JP
		/// <summary>
		/// &amp;elem: 他のシーケンス要素へのポインタ [CV_SEQ_ELTYPE_PPOINT]
		/// </summary>
#else
        /// <summary>
        /// &amp;elem: pointer to element of other sequence [CV_SEQ_ELTYPE_PPOINT]
        /// </summary>
#endif
        EltypePPoint = CvConst.CV_SEQ_ELTYPE_PPOINT,
#if LANG_JP
		/// <summary>
		/// #elem: 他のシーケンス要素のインデックス [CV_SEQ_ELTYPE_INDEX]
		/// </summary>
#else
        /// <summary>
        /// #elem: index of element of some other sequence [CV_SEQ_ELTYPE_INDEX]
        /// </summary>
#endif
        EltypeIndex = CvConst.CV_SEQ_ELTYPE_INDEX,
		/// <summary>
		/// &amp;next_o, &amp;next_d, &amp;vtx_o, &amp;vtx_d [CV_SEQ_ELTYPE_GRAPH_EDGE]
		/// </summary>
        EltypeGraphEdge = CvConst.CV_SEQ_ELTYPE_GRAPH_EDGE,
#if LANG_JP
		/// <summary>
		/// 先頭の辺, &amp;(x,y) [CV_SEQ_ELTYPE_GRAPH_VERTEX]
		/// </summary>
#else
        /// <summary>
        /// first_edge, &amp;(x,y) [CV_SEQ_ELTYPE_GRAPH_VERTEX]
        /// </summary>
#endif
        EltypeGraphVertex = CvConst.CV_SEQ_ELTYPE_GRAPH_VERTEX,
#if LANG_JP
		/// <summary>
		/// 二分木の頂点（ノード） [CV_SEQ_ELTYPE_TRIAN_ATR]
		/// </summary>
#else
        /// <summary>
        /// vertex of the binary tree  [CV_SEQ_ELTYPE_TRIAN_ATR]
        /// </summary>
#endif
        EltypeTrianAtr = CvConst.CV_SEQ_ELTYPE_TRIAN_ATR,
#if LANG_JP
		/// <summary>
		/// 接続成分 [CV_SEQ_ELTYPE_CONNECTED_COMP]
		/// </summary>
#else
        /// <summary>
        /// connected component [CV_SEQ_ELTYPE_CONNECTED_COMP]
        /// </summary>
#endif
        EltypeConnectedComp = CvConst.CV_SEQ_ELTYPE_CONNECTED_COMP,
		/// <summary>
		/// (x,y,z) [CV_SEQ_ELTYPE_POINT3D]
		/// </summary>
        EltypePoint3D = CvConst.CV_SEQ_ELTYPE_POINT3D,

        #region MatrixTypeから
#if LANG_JP
        /// <summary>
		/// 符号なし8ビット整数1チャンネル [CV_8UC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 8-bit unsigned integers [CV_8UC1]
        /// </summary>
#endif
        EltypeU8C1 = CvConst.CV_8UC1,
#if LANG_JP
		/// <summary>
		/// 符号なし8ビット整数2チャンネル [CV_8UC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 8-bit unsigned integers [CV_8UC2]
        /// </summary>
#endif
        EltypeU8C2 = CvConst.CV_8UC2,
#if LANG_JP
		/// <summary>
		/// 符号なし8ビット整数3チャンネル [CV_8UC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 8-bit unsigned integers [CV_8UC3]
        /// </summary>
#endif
        EltypeU8C3 = CvConst.CV_8UC3,
#if LANG_JP
		/// <summary>
		/// 符号なし8ビット整数4チャンネル [CV_8UC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 8-bit unsigned integers [CV_8UC4]
        /// </summary>
#endif
        EltypeU8C4 = CvConst.CV_8UC4,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数1チャンネル [CV_8SC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 8-bit signed integers [CV_8SC1]
        /// </summary>
#endif
        EltypeS8C1 = CvConst.CV_8SC1,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数2チャンネル [CV_8SC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 8-bit signed integers [CV_8SC2]
        /// </summary>
#endif
        EltypeS8C2 = CvConst.CV_8SC2,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数3チャンネル [CV_8SC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 8-bit signed integers [CV_8SC3]
        /// </summary>
#endif
        EltypeS8C3 = CvConst.CV_8SC3,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数4チャンネル [CV_8SC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 8-bit signed integers [CV_8SC4]
        /// </summary>
#endif
        EltypeS8C4 = CvConst.CV_8SC4,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数1チャンネル [CV_16UC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 16-bit unsigned integers [CV_16UC1]
        /// </summary>
#endif
        EltypeU16C1 = CvConst.CV_16UC1,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数2チャンネル [CV_16UC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 16-bit unsigned integers [CV_16UC2]
        /// </summary>
#endif
        EltypeU16C2 = CvConst.CV_16UC2,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数3チャンネル [CV_16UC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 16-bit unsigned integers [CV_16UC3]
        /// </summary>
#endif
        EltypeU16C3 = CvConst.CV_16UC3,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数4チャンネル [CV_16UC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 16-bit unsigned integers [CV_16UC4]
        /// </summary>
#endif
        EltypeU16C4 = CvConst.CV_16UC4,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数1チャンネル [CV_16SC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 16-bit signed integers [CV_16SC1]
        /// </summary>
#endif
        EltypeS16C1 = CvConst.CV_16SC1,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数2チャンネル [CV_16SC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 16-bit signed integers [CV_16SC2]
        /// </summary>
#endif
        EltypeS16C2 = CvConst.CV_16SC2,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数3チャンネル [CV_16SC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 16-bit signed integers [CV_16SC3]
        /// </summary>
#endif
        EltypeS16C3 = CvConst.CV_16SC3,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数4チャンネル [CV_16SC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 16-bit signed integers [CV_16SC4]
        /// </summary>
#endif
        EltypeS16C4 = CvConst.CV_16SC4,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数1チャンネル [CV_32SC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 32-bit signed integers [CV_32SC1]
        /// </summary>
#endif
        EltypeS32C1 = CvConst.CV_32SC1,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数2チャンネル [CV_32SC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 32-bit signed integers [CV_32SC2]
        /// </summary>
#endif
        EltypeS32C2 = CvConst.CV_32SC2,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数3チャンネル [CV_32SC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 32-bit signed integers [CV_32SC3]
        /// </summary>
#endif
        EltypeS32C3 = CvConst.CV_32SC3,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数4チャンネル [CV_32SC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 32-bit signed integers [CV_32SC4]
        /// </summary>
#endif
        EltypeS32C4 = CvConst.CV_32SC4,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数1チャンネル [CV_32FC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 32-bit floating-point numbers [CV_32FC1]
        /// </summary>
#endif
        EltypeF32C1 = CvConst.CV_32FC1,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数2チャンネル [CV_32FC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 32-bit floating-point numbers [CV_32FC2]
        /// </summary>
#endif
        EltypeF32C2 = CvConst.CV_32FC2,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数3チャンネル [CV_32FC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 32-bit floating-point numbers [CV_32FC3]
        /// </summary>
#endif
        EltypeF32C3 = CvConst.CV_32FC3,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数4チャンネル [CV_32FC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 32-bit floating-point numbers [CV_32FC4]
        /// </summary>
#endif
        EltypeF32C4 = CvConst.CV_32FC4,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数1チャンネル [CV_64FC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 64-bit floating-point numbers [CV_64FC1]
        /// </summary>
#endif
        EltypeF64C1 = CvConst.CV_64FC1,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数2チャンネル [CV_64FC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 64-bit floating-point numbers [CV_64FC2]
        /// </summary>
#endif
        EltypeF64C2 = CvConst.CV_64FC2,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数3チャンネル [CV_64FC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 64-bit floating-point numbers [CV_64FC3]
        /// </summary>
#endif
        EltypeF64C3 = CvConst.CV_64FC3,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数4チャンネル [CV_64FC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 64-bit floating-point numbers [CV_64FC4]
        /// </summary>
#endif
        EltypeF64C4 = CvConst.CV_64FC4,
		#endregion
		#endregion

		#region Kind
		/// <summary>
		/// [CV_SEQ_KIND_GENERIC]
		/// </summary>
        KindGeneric = CvConst.CV_SEQ_KIND_GENERIC,
		/// <summary>
		/// [CV_SEQ_KIND_GENERIC]
		/// </summary>
        KindCurve = CvConst.CV_SEQ_KIND_CURVE,
		/// <summary>
		/// [CV_SEQ_KIND_BIN_TREE]
		/// </summary>
        KindBinaryTree = CvConst.CV_SEQ_KIND_BIN_TREE,
		/// <summary>
		/// [CV_SEQ_KIND_GRAPH]
		/// </summary>
        KindGraph = CvConst.CV_SEQ_KIND_GRAPH,
		/// <summary>
		/// [CV_SEQ_KIND_SUBDIV2D]
		/// </summary>
        KindSubdiv2D = CvConst.CV_SEQ_KIND_SUBDIV2D,
		#endregion

		#region Flag
		/// <summary>
		/// flags for curves [CV_SEQ_FLAG_CLOSED]
		/// </summary>
        FlagClosed = CvConst.CV_SEQ_FLAG_CLOSED,
		/// <summary>
		/// flags for curves [CV_SEQ_FLAG_SIMPLE]
		/// </summary>
        FlagSimple = CvConst.CV_SEQ_FLAG_SIMPLE,
		/// <summary>
		/// flags for curves [CV_SEQ_FLAG_CONVEX]
		/// </summary>
        FlagConvex = CvConst.CV_SEQ_FLAG_CONVEX,
		/// <summary>
		/// flags for curves [CV_SEQ_FLAG_HOLE]
		/// </summary>
        FlagHole = CvConst.CV_SEQ_FLAG_HOLE,

		/// <summary>
		/// flags for graphs [CV_GRAPH_FLAG_ORIENTED]
		/// </summary>
        Oriented = CvConst.CV_GRAPH_FLAG_ORIENTED,
		#endregion

		#region Graph
		/// <summary>
		/// flags for graphs [CV_GRAPH_FLAG_ORIENTED]
		/// </summary>
        Graph = CvConst.CV_GRAPH,
		/// <summary>
		/// flags for graphs [CV_GRAPH_FLAG_ORIENTED]
		/// </summary>
        OrientedGraph = CvConst.CV_ORIENTED_GRAPH,
		#endregion

		#region point sets
		/// <summary>
		/// point sets [CV_SEQ_POINT_SET]
		/// </summary>
        PointSet = CvConst.CV_SEQ_POINT_SET,
		/// <summary>
		/// point sets [CV_SEQ_POINT3D_SET]
		/// </summary>
        Point3DSet = CvConst.CV_SEQ_POINT3D_SET,
		/// <summary>
		/// point sets [CV_SEQ_POLYLINE]
		/// </summary>
        PolyLine = CvConst.CV_SEQ_POLYLINE,
		/// <summary>
		/// point sets [CV_SEQ_POLYGON]
		/// </summary>
        Polygon = CvConst.CV_SEQ_POLYGON,
		/// <summary>
		/// point sets [CV_SEQ_CONTOUR]
		/// </summary>
        Contour = CvConst.CV_SEQ_CONTOUR,
		/// <summary>
		/// point sets [CV_SEQ_SIMPLE_POLYGON]
		/// </summary>
        SimplePolygon = CvConst.CV_SEQ_SIMPLE_POLYGON,
		#endregion

		/// <summary>
		/// chain-coded curves [CV_SEQ_CHAIN]
		/// </summary>
        Chain = CvConst.CV_SEQ_CHAIN,
		/// <summary>
		/// chain-coded curves [CV_SEQ_CHAIN_CONTOUR]
		/// </summary>
        ChainContour = CvConst.CV_SEQ_CHAIN_CONTOUR,

		/// <summary>
		/// binary tree for the contour [CV_SEQ_POLYGON_TREE]
		/// </summary>
        PolygonTree = CvConst.CV_SEQ_POLYGON_TREE,

		/// <summary>
		/// sequence of the connected components [CV_SEQ_CONNECTED_COMP]
		/// </summary>
        ConnextedComp = CvConst.CV_SEQ_CONNECTED_COMP,

		/// <summary>
		///sequence of the integer numbers [CV_SEQ_INDEX]
		/// </summary>
        Index = CvConst.CV_SEQ_INDEX,
	};
}
