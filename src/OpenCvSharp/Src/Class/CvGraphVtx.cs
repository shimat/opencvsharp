using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// グラフの頂点
    /// </summary>
#else
    /// <summary>
    /// Vertex of graph
    /// </summary>
#endif
    public class CvGraphVtx : DisposableCvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// メモリを確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Allocates memory
        /// </summary>
#endif
        public CvGraphVtx()
        {
            ptr = AllocMemory(SizeOf);
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
        public CvGraphVtx(IntPtr ptr)
        {
            this.ptr = ptr;
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
        internal unsafe CvGraphVtx(void* ptr) :
            this(new IntPtr(ptr))
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvGraphVtx) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvGraphVtx));
 
#if LANG_JP
        /// <summary>
        /// 頂点フラグ
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
                    return (GraphEdgeVtxFlag)((WCvGraphVtx*)ptr)->flags;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 最初の辺
        /// </summary>
#else
        /// <summary>
        /// The first incident edge
        /// </summary>
#endif
        public CvGraphEdge First
        {
            get 
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvGraphVtx*)ptr)->first);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvGraphEdge(p);
            }
        }
        #endregion

        #region Methods
        #region IsGraphVertexVisited
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
        public bool IsGraphVertexVisited()
        {
            return Cv.IS_GRAPH_VERTEX_VISITED(CvPtr);
        }
        #endregion
        #endregion
    }
}