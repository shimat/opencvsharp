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
    /// グラフ走査状態のための構造体
    /// </summary>
#else
    /// <summary>
    /// CvGraphScanner
    /// </summary>
#endif
    public class CvGraphScanner : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Constructors
        /// <summary>
        /// Initialize from pointer
        /// </summary>
        /// <param name="ptr"></param>
        public CvGraphScanner(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// グラフの深さ優先走査のためのクラスを生成する
        /// </summary>
        /// <param name="graph">グラフ</param>
#else
        /// <summary>
        /// Creates structure for depth-first graph traversal
        /// </summary>
        /// <param name="graph">Graph. </param>
#endif
        public CvGraphScanner(CvGraph graph)
            : this(graph, null)
        {
        }
#if LANG_JP
        /// <summary>
        /// グラフの深さ優先走査のためのクラスを生成する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">走査開始頂点．nullの場合，走査は先頭の頂点（頂点シーケンスのうち最小のインデックスを持つ頂点）から始まる．</param>
#else
        /// <summary>
        /// Creates structure for depth-first graph traversal
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Initial vertex to start from. If NULL, the traversal starts from the first vertex (a vertex with the minimal index in the sequence of vertices). </param>
#endif
        public CvGraphScanner(CvGraph graph, CvGraphVtx vtx)
            : this(graph, vtx, GraphScannerMask.AllItems)
        {
        }
#if LANG_JP
        /// <summary>
        /// グラフの深さ優先走査のためのクラスを生成する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">走査開始頂点．nullの場合，走査は先頭の頂点（頂点シーケンスのうち最小のインデックスを持つ頂点）から始まる．</param>
        /// <param name="mask">イベントマスク．どのイベントにユーザが着目したいのかを指定する.</param>
#else
        /// <summary>
        /// Creates structure for depth-first graph traversal
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Initial vertex to start from. If NULL, the traversal starts from the first vertex (a vertex with the minimal index in the sequence of vertices). </param>
        /// <param name="mask">Event mask indicating which events are interesting to the user (where cvNextGraphItem  function returns control to the user) It can be CV_GRAPH_ALL_ITEMS (all events are interesting) or combination of the following flags:
        /// <br/> * CV_GRAPH_VERTEX - stop at the graph vertices visited for the first time
        ///   <br/>* CV_GRAPH_TREE_EDGE - stop at tree edges (tree edge is the edge connecting the last visited vertex and the vertex to be visited next)
        /// <br/>* CV_GRAPH_BACK_EDGE - stop at back edges (back edge is an edge connecting the last visited vertex with some of its ancestors in the search tree)
        /// <br/>* CV_GRAPH_FORWARD_EDGE - stop at forward edges (forward edge is an edge conecting the last visited vertex with some of its descendants in the search tree). The forward edges are only possible during oriented graph traversal)
        ///   <br/>* CV_GRAPH_CROSS_EDGE - stop at cross edges (cross edge is an edge connecting different search trees or branches of the same tree. The cross edges are only possible during oriented graphs traversal)
        ///   <br/> * CV_GRAPH_ANY_EDGE - stop and any edge (tree, back, forward and cross edges)
        ///   <br/>* CV_GRAPH_NEW_TREE - stop in the beginning of every new search tree. When the traversal procedure visits all vertices and edges reachible from the initial vertex (the visited vertices together with tree edges make up a tree), it searches for some unvisited vertex in the graph and resumes the traversal process from that vertex. Before starting a new tree (including the very first tree when cvNextGraphItem is called for the first time) it generates CV_GRAPH_NEW_TREE event.
        ///    <br/> For unoriented graphs each search tree corresponds to a connected component of the graph.
        ///  <br/> * CV_GRAPH_BACKTRACKING - stop at every already visited vertex during backtracking - returning to already visited vertexes of the traversal tree.</param>
#endif
        public CvGraphScanner(CvGraph graph, CvGraphVtx vtx, GraphScannerMask mask)
            : this(CvInvoke.cvCreateGraphScanner(graph.CvPtr, (vtx == null) ? IntPtr.Zero : vtx.CvPtr, mask))
        {
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        CvInvoke.cvReleaseGraphScanner(ref ptr);
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvGraphScanner) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvGraphScanner));

#if LANG_JP
        /// <summary>
        /// 現在の頂点（あるいは辺の始点）
        /// </summary>
#else
        /// <summary>
        /// Current graph vertex (or current edge origin)
        /// </summary>
#endif
        public CvGraphVtx Vtx
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvGraphScanner*)ptr)->vtx);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvGraphVtx(p);
            }
        }
#if LANG_JP
        /// <summary>
        /// 現在の辺の接続先頂点
        /// </summary>
#else
        /// <summary>
        /// Current graph edge destination vertex
        /// </summary>
#endif
        public CvGraphVtx Dst
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvGraphScanner*)ptr)->dst);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvGraphVtx(p);
            }
        }
#if LANG_JP
        /// <summary>
        /// 現在の辺
        /// </summary>
#else
        /// <summary>
        /// Current edge
        /// </summary>
#endif
        public CvGraphEdge Edge
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvGraphScanner*)ptr)->edge);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvGraphEdge(p);
            }
        }
#if LANG_JP
        /// <summary>
        /// the graph
        /// </summary>
#else
        /// <summary>
        /// the graph
        /// </summary>
#endif
        public CvGraph Graph
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvGraphScanner*)ptr)->graph);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvGraph(p);
            }
        }
#if LANG_JP
        /// <summary>
        /// the graph vertex stack
        /// </summary>
#else
        /// <summary>
        /// the graph vertex stack
        /// </summary>
#endif
        public CvSeq Stack
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvGraphScanner*)ptr)->stack);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvSeq(p);
            }
        }
#if LANG_JP
        /// <summary>
        /// the lower bound of certainly visited vertices
        /// </summary>
#else
        /// <summary>
        /// the lower bound of certainly visited vertices
        /// </summary>
#endif
        public int Index
        {
            get
            {
                unsafe
                {
                    return ((WCvGraphScanner*)ptr)->index;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// event mask
        /// </summary>
#else
        /// <summary>
        /// event mask
        /// </summary>
#endif
        public int Mask
        {
            get
            {
                unsafe
                {
                    return ((WCvGraphScanner*)ptr)->mask;
                }
            }
        }
        #endregion

        #region Methods
        #region NextGraphItem
#if LANG_JP
        /// <summary>
        /// グラフ走査処理を1ステップ，あるいは数ステップ進める
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns index of graph vertex
        /// </summary>
        /// <returns>The function cvNextGraphItem traverses through the graph until an event interesting to the user (that is, an event, specified in the mask in cvCreateGraphScanner call) is met or the traversal is over. In the first case it returns one of the events, listed in the description of mask parameter above and with the next call it resumes the traversal. In the latter case it returns CV_GRAPH_OVER (-1). When the event is CV_GRAPH_VERTEX, or CV_GRAPH_BACKTRACKING or CV_GRAPH_NEW_TREE, the currently observed vertex is stored in scanner->vtx. And if the event is edge-related, the edge itself is stored at scanner->edge, the previously visited vertex - at scanner->vtx and the other ending vertex of the edge - at scanner->dst.</returns>
#endif
        public int NextGraphItem()
        {
            return Cv.NextGraphItem(this);
        }
        #endregion
        #endregion
    }
}
