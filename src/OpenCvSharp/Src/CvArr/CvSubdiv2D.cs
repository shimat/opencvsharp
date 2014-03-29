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
    /// 平面細分割のためのクラス
    /// </summary>
#else
    /// <summary>
    /// Planar subdivision
    /// </summary>
#endif
    public class CvSubdiv2D : CvGraph
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected CvSubdiv2D()
        {
            ptr = IntPtr.Zero;
        }
#if LANG_JP
        /// <summary>
	    /// cvCreateSubdivDelaunay2Dで初期化
	    /// </summary>
        /// <param name="rect"></param>
	    /// <param name="storage"></param>
#else
        /// <summary>
        /// Initializes using cvCreateSubdivDelaunay2D
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="storage"></param>
#endif
        public CvSubdiv2D(CvRect rect, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }

            IntPtr subdiv = CvInvoke.cvCreateSubdiv2D(
                SeqType.KindSubdiv2D, SizeOf, CvSubdiv2DPoint.SizeOf, CvQuadEdge2D.SizeOf, storage.CvPtr
            );

            if (subdiv == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvSubdiv2D");
            }

            CvInvoke.cvInitSubdivDelaunay2D(subdiv, rect);

            Initialize(subdiv);
            holdingStorage = storage;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSubdiv2D*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSubdiv2D*</param>
#endif
        public CvSubdiv2D(IntPtr ptr)
            : base(ptr)
        {
            Initialize(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSubdiv2D)
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSubdiv2D));


#if LANG_JP
		/// <summary>
		/// 
		/// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int QuadEdges
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2D*)ptr)->quad_edges;
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
        public bool IsGeometryValid
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2D*)ptr)->is_geometry_valid != 0;
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
        public uint RecentEdge
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2D*)ptr)->recent_edge;
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
        public CvPoint2D32f TopLeft
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2D*)ptr)->topleft;
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
        public CvPoint2D32f BottomRight
        {
            get
            {
                unsafe
                {
                    return ((WCvSubdiv2D*)ptr)->bottomright;
                }
            }
        }
        #endregion

        #region Methods
        #region CalcVoronoi2D
#if LANG_JP
        /// <summary>
        /// 仮想点の座標を計算する．元の細分割面のある頂点に対応する仮想点全てを接続すると，その頂点を含むボロノイ領域の境界を構成する (CalcSubdivVoronoi2D) ． 
        /// </summary>
#else
        /// <summary>
        /// Calculates coordinates of Voronoi diagram cells (CalcSubdivVoronoi2D).
        /// </summary>
#endif
        public void CalcVoronoi2D()
        {
            Cv.CalcSubdivVoronoi2D(this);
        }
        #endregion
        #region ClearVoronoi2D
#if LANG_JP
        /// <summary>
        /// 全ての仮想点を削除する (cvClearSubdivVoronoi2D)． 
        /// この関数の前回の呼出し後に細分割が変更された場合，この関数は cvCalcSubdivVoronoi2D の内部で呼ばれる． 
        /// </summary>
#else
        /// <summary>
        /// Removes all virtual points (cvClearSubdivVoronoi2D).
        /// </summary>
#endif
        public void ClearVoronoi2D()
        {
            CvInvoke.cvClearSubdivVoronoi2D(ptr);
        }
        #endregion
        #region FindNearestPoint2D
#if LANG_JP
        /// <summary>
        /// 与えられた点に最も近い細分割の頂点を求める. 入力点を細分割内に配置するもう一つの関数である．
        /// この関数は入力された点に最も近い頂点を求める． 
        /// </summary>
        /// <param name="pt">入力点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds the closest subdivision vertex to given point
        /// </summary>
        /// <param name="pt">Input point. </param>
        /// <returns></returns>
#endif
        public CvSubdiv2DPoint FindNearestPoint2D(CvPoint2D32f pt)
        {
            return Cv.FindNearestPoint2D(this, pt);
        }
        #endregion
        #region Insert
#if LANG_JP
        /// <summary>
        /// ドロネー三角形に点を追加する (cvSubdivDelaunay2D).
        /// </summary>
        /// <param name="pt">追加する点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Inserts a single point to Delaunay triangulation (cvSubdivDelaunay2D).
        /// </summary>
        /// <param name="pt">Inserted point. </param>
        /// <returns></returns>
#endif
        public CvSubdiv2DPoint Insert(CvPoint2D32f pt)
        {
            return Cv.SubdivDelaunay2DInsert(this, pt);
        }
        #endregion
        #region InitSubdivDelaunay2D
#if LANG_JP
        /// <summary>
        /// CvSubdiv2Dの初期化
        /// </summary>
        /// <param name="rect"></param>
#else
        /// <summary>
        /// CvSubdiv2Dの初期化
        /// </summary>
        /// <param name="rect"></param>
#endif
        public void InitSubdivDelaunay2D(CvRect rect)
        {
            Cv.InitSubdivDelaunay2D(this, rect);
        }
        #endregion
        #region Locate
#if LANG_JP
        /// <summary>
        /// ドロネー三角形に点を追加する (cvSubdiv2DLocate).
        /// </summary>
        /// <param name="pt">配置する点</param>
        /// <param name="edge">出力される辺．配置した点は，その辺上または端に存在する.</param>
        /// <returns>配置する点</returns>
#else
        /// <summary>
        /// Inserts a single point to Delaunay triangulation (cvSubdiv2DLocate).
        /// </summary>
        /// <param name="pt">The point to locate. </param>
        /// <param name="edge">The output edge the point falls onto or right to. </param>
        /// <returns></returns>
#endif
        public CvSubdiv2DPointLocation Locate(CvPoint2D32f pt, out CvSubdiv2DEdge edge)
        {
            return Cv.Subdiv2DLocate(this, pt, out edge);
        }
#if LANG_JP
        /// <summary>
        /// ドロネー三角形に点を追加する (cvSubdiv2DLocate).
        /// </summary>
        /// <param name="pt">配置する点</param>
        /// <param name="edge">出力される辺．配置した点は，その辺上または端に存在する.</param>
        /// <param name="vertex">オプション出力．入力点と一致する細分割の頂点へのポインタのポインタ</param>
        /// <returns>配置する点</returns>
#else
        /// <summary>
        /// Inserts a single point to Delaunay triangulation (cvSubdiv2DLocate).
        /// </summary>
        /// <param name="pt">The point to locate. </param>
        /// <param name="edge">The output edge the point falls onto or right to. </param>
        /// <param name="vertex">Optional output vertex double pointer the input point coinsides with. </param>
        /// <returns></returns>
#endif
        public CvSubdiv2DPointLocation Locate(CvPoint2D32f pt, out CvSubdiv2DEdge edge, ref CvSubdiv2DPoint vertex)
        {
            return Cv.Subdiv2DLocate(this, pt, out edge, ref vertex);
        }
        #endregion
        #endregion
    }
}
