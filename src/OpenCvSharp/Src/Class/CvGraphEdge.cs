using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// グラフの辺
    /// </summary>
#else
    /// <summary>
    /// Edge of graph
    /// </summary>
#endif
    public class CvGraphEdge : CvObject
    {
        #region Init and Disposal
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
        public CvGraphEdge(IntPtr ptr)
        {
            this._ptr = ptr;
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
        internal unsafe CvGraphEdge(void* ptr)
            : this(new IntPtr(ptr))
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvGraphEdge) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvGraphEdge));


#if LANG_JP
        /// <summary>
        /// 辺フラグ
        /// </summary>
#else
        /// <summary>
        /// Edge flags
        /// </summary>
#endif
        public GraphEdgeVtxFlag Flags
        {
            get
            {
                unsafe
                {
                    return (GraphEdgeVtxFlag)((WCvGraphEdge*)_ptr)->flags;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 辺の重み
        /// </summary>
#else
        /// <summary>
        /// Edge weight
        /// </summary>
#endif
        public float Weight
        {
            get
            {
                unsafe
                {
                    return ((WCvGraphEdge*)_ptr)->weight;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 辺リストにおける次の辺．始点（0），終点（1）
        /// </summary>
#else
        /// <summary>
        /// The next edges in the incidence lists for staring (0) and ending (1) vertices
        /// </summary>
#endif
        public CvGraphEdge[] Next
        {
            get
            {
                unsafe
                {
                    WCvGraphEdge* p = (WCvGraphEdge*)_ptr;
                    return new CvGraphEdge[2] { new CvGraphEdge(p->next1), new CvGraphEdge(p->next2) };
                }
            }
        }
#if LANG_JP
        /// <summary>
        ///  始点（0），終点（1）
        /// </summary>
#else
        /// <summary>
        /// The starting (0) and ending (1) vertices
        /// </summary>
#endif
        public CvGraphVtx[] Vtx
        {
            get
            {
                unsafe
                {
                    WCvGraphEdge* p = (WCvGraphEdge*)_ptr;
                    return new CvGraphVtx[2] { new CvGraphVtx(p->vtx1), new CvGraphVtx(p->vtx2) };
                }
            }
        }
        #endregion

        #region Methods
        #region IsGraphEdgeVisited
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public bool IsGraphEdgeVisited()
        {
            return Cv.IS_GRAPH_EDGE_VISITED(CvPtr);
        }
        #endregion
        #endregion
    }
}