using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public class Subdiv2D : DisposableCvObject
    {
        #region Init and Disposal

#if LANG_JP
        /// <summary>
        /// デフォルトのパラメータで初期化.
        /// 実際は numberOfDisparities だけは指定する必要がある.
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public Subdiv2D()
        {
            ptr = NativeMethods.imgproc_Subdiv2D_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
        /// <summary>
        /// Subdiv2D コンストラクタ
        /// </summary>
        /// <param name="rect"></param>
#else
        /// <summary>
        /// Subdiv2D Constructor
        /// </summary>
        /// <param name="rect"></param>
#endif
        public Subdiv2D(Rect rect)
        {
            ptr = NativeMethods.imgproc_Subdiv2D_new2(rect);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose();
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.imgproc_Subdiv2D_delete(ptr);
            base.DisposeUnmanaged();
        }
        
        #endregion

        #region Constants
        /// <summary>
        /// 
        /// </summary>
        public const int
            PTLOC_ERROR = -2,
            PTLOC_OUTSIDE_RECT = -1,
            PTLOC_INSIDE = 0,
            PTLOC_VERTEX = 1,
            PTLOC_ON_EDGE = 2;
        /// <summary>
        /// 
        /// </summary>
        public const int
            NEXT_AROUND_ORG = 0x00,
            NEXT_AROUND_DST = 0x22,
            PREV_AROUND_ORG = 0x11,
            PREV_AROUND_DST = 0x33,
            NEXT_AROUND_LEFT = 0x13,
            NEXT_AROUND_RIGHT = 0x31,
            PREV_AROUND_LEFT = 0x20,
            PREV_AROUND_RIGHT = 0x02;
        #endregion

        #region Methods
        #region InitDelaunay
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        public void InitDelaunay(Rect rect)
        {
            ThrowIfDisposed();
            NativeMethods.imgproc_Subdiv2D_initDelaunay(ptr, rect);
            GC.KeepAlive(this);
        }
        #endregion
        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public int Insert(Point2f pt)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_insert1(ptr, pt);
            GC.KeepAlive(this);
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptvec"></param>
        public void Insert(Point2f[] ptvec)
        {
            ThrowIfDisposed();
            if (ptvec == null)
                throw new ArgumentNullException(nameof(ptvec));
            NativeMethods.imgproc_Subdiv2D_insert2(ptr, ptvec, ptvec.Length);
            GC.KeepAlive(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptvec"></param>
        public void Insert(IEnumerable<Point2f> ptvec)
        {
            if (ptvec == null)
                throw new ArgumentNullException(nameof(ptvec));
            Insert(new List<Point2f>(ptvec).ToArray());
        }
        #endregion
        #region Locate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="edge"></param>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int Locate(Point2f pt, out int edge, out int vertex)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_locate(ptr, pt, out edge, out vertex);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region FindNearest
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public int FindNearest(Point2f pt)
        {
            Point2f nearestPt;
            return FindNearest(pt, out nearestPt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="nearestPt"></param>
        /// <returns></returns>
        public int FindNearest(Point2f pt, out Point2f nearestPt)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_findNearest(ptr, pt, out nearestPt);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region GetEdgeList
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4f[] GetEdgeList()
        {
            ThrowIfDisposed();
            IntPtr p;
            NativeMethods.imgproc_Subdiv2D_getEdgeList(ptr, out p);
            GC.KeepAlive(this);
            using (VectorOfVec4f vec = new VectorOfVec4f(p))
            {
                return vec.ToArray();
            }
        }
        #endregion
        #region GetTriangleList
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6f[] GetTriangleList()
        {
            ThrowIfDisposed();
            IntPtr p;
            NativeMethods.imgproc_Subdiv2D_getTriangleList(ptr, out p);
            GC.KeepAlive(this);
            using (VectorOfVec6f vec = new VectorOfVec6f(p))
            {
                return vec.ToArray();
            }
        }
        #endregion
        #region GetVoronoiFacetList
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="facetList"></param>
        /// <param name="facetCenters"></param>
        public void GetVoronoiFacetList(IEnumerable<int> idx, out Point2f[][] facetList, out Point2f[] facetCenters)
        {
            ThrowIfDisposed();

            IntPtr facetListPtr, facetCentersPtr;
            if (idx == null)
            {
                NativeMethods.imgproc_Subdiv2D_getVoronoiFacetList(ptr, IntPtr.Zero, 0, out facetListPtr, out facetCentersPtr);
            }
            else
            {
                int[] idxArray = EnumerableEx.ToArray(idx);
                NativeMethods.imgproc_Subdiv2D_getVoronoiFacetList(ptr, idxArray, idxArray.Length, out facetListPtr, out facetCentersPtr);
            }
            GC.KeepAlive(this);

            using (VectorOfVectorPoint2f facetListVec = new VectorOfVectorPoint2f(facetListPtr))
            {
                facetList = facetListVec.ToArray();
            }
            using (VectorOfPoint2f facetCentersVec = new VectorOfPoint2f(facetCentersPtr))
            {
                facetCenters = facetCentersVec.ToArray();
            }
        }
        #endregion
        #region GetVertex
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public Point2f GetVertex(int vertex)
        {
            int firstEdge;
            return GetVertex(vertex, out firstEdge);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="firstEdge"></param>
        /// <returns></returns>
        public Point2f GetVertex(int vertex, out int firstEdge)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_getVertex(ptr, vertex, out firstEdge);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region GetEdge
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="nextEdgeType"></param>
        /// <returns></returns>
        public int GetEdge(int edge, int nextEdgeType)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_getEdge(ptr, edge, nextEdgeType);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region NextEdge
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public int NextEdge(int edge)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_nextEdge(ptr, edge);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region RotateEdge
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="rotate"></param>
        /// <returns></returns>
        public int RotateEdge(int edge, int rotate)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_rotateEdge(ptr, edge, rotate);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region SymEdge
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public int SymEdge(int edge)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_symEdge(ptr, edge);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region EdgeOrg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public int EdgeOrg(int edge)
        {
            Point2f orgpt;
            return EdgeOrg(edge, out orgpt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="orgpt"></param>
        /// <returns></returns>
        public int EdgeOrg(int edge, out Point2f orgpt)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_edgeOrg(ptr, edge, out orgpt);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region EdgeDst
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public int EdgeDst(int edge)
        {
            Point2f dstpt;
            return EdgeDst(edge, out dstpt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="dstpt"></param>
        /// <returns></returns>
        public int EdgeDst(int edge, out Point2f dstpt)
        {
            ThrowIfDisposed();
            var res = NativeMethods.imgproc_Subdiv2D_edgeDst(ptr, edge, out dstpt);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #endregion
    }
}
