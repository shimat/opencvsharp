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
    /// cvCreateGraphScannerで用いるイベントマスク．どのイベントにユーザが着目したいのかを指定する.
    /// </summary>
#else
    /// <summary>
    /// Event mask indicating which events are interesting to the user
    /// </summary>
#endif
    [Flags]
    public enum GraphScannerMask
    {
#if LANG_JP
        /// <summary>
        /// はじめてアクセスした頂点で停止する
        /// [CV_GRAPH_VERTEX]
        /// </summary>
#else
        /// <summary>
        /// Stop at the graph vertices visited for the first time
        /// [CV_GRAPH_VERTEX]
        /// </summary>
#endif
        Vertex = CvConst.CV_GRAPH_VERTEX,
#if LANG_JP
        /// <summary>
        /// tree edgeで停止する （tree edge は最後にアクセスした頂点と次にアクセスされる頂点を接続する辺のこと）
        /// [CV_GRAPH_TREE_EDGE]
        /// </summary>
#else
        /// <summary>
        /// Stop at tree edges (tree edge is the edge connecting the last visited vertex and the vertex to be visited next)
        /// [CV_GRAPH_TREE_EDGE]
        /// </summary>
#endif
        TreeEdge = CvConst.CV_GRAPH_TREE_EDGE,
#if LANG_JP
        /// <summary>
        /// back edgeで停止する （back edge は最後にアクセスした頂点と探索木内でのその親のいずれかを接続する辺のこと）
        /// [CV_GRAPH_BACK_EDGE]
        /// </summary>
#else
        /// <summary>
        /// Stop at back edges (back edge is an edge connecting the last visited vertex with some of its ancestors in the search tree)
        /// [CV_GRAPH_BACK_EDGE]
        /// </summary>
#endif
        BackEdge = CvConst.CV_GRAPH_BACK_EDGE,
#if LANG_JP
        /// <summary>
        /// forward edgeで停止する （forward edge は最後にアクセスした頂点と探索木内でのその子のいずれかを接続する辺のこと． forward edge は有向グラフの走査においてのみ有効）
        /// [CV_GRAPH_FORWARD_EDGE]
        /// </summary>
#else
        /// <summary>
        /// Stop at forward edges (forward edge is an edge conecting the last visited vertex with some of its descendants in the search tree). The forward edges are only possible during oriented graph traversal)
        /// [CV_GRAPH_FORWARD_EDGE]
        /// </summary>
#endif
        ForwardEdge = CvConst.CV_GRAPH_FORWARD_EDGE,
#if LANG_JP
        /// <summary>
        /// cross edgeで停止する （cross edge は異なる探索木同士か同じ木の枝同士を接続する辺のこと． cross edges は有向グラフの走査においてのみ有効）
        /// [CV_GRAPH_CROSS_EDGE]
        /// </summary>
#else
        /// <summary>
        /// Stop at cross edges (cross edge is an edge connecting different search trees or branches of the same tree. The cross edges are only possible during oriented graphs traversal)
        /// [CV_GRAPH_CROSS_EDGE]
        /// </summary>
#endif
        CrossEdge = CvConst.CV_GRAPH_CROSS_EDGE,
#if LANG_JP
        /// <summary>
        /// 任意の辺で停止する（tree, back, forward そしてcross edges）
        /// [CV_GRAPH_ANY_EDGE]
        /// </summary>
#else
        /// <summary>
        /// Stop and any edge (tree, back, forward and cross edges) 
        /// [CV_GRAPH_ANY_EDGE]
        /// </summary>
#endif
        AnyEdge = CvConst.CV_GRAPH_ANY_EDGE,
#if LANG_JP
        /// <summary>
        /// すべての新しい探索木の先頭で停止する． 走査プロセスが，走査開始頂点（initial vertex）から到達可能なすべての頂点と辺にアクセスする場合 （アクセスされた頂点は辺とともに一つの木（tree）を構成する），
        /// グラフ中でまだアクセスされていない頂点を探索し， その頂点からの探索を再開する．新しい木の開始前（最初に cvNextGraphItem が呼ばれる，全く初めての場合も含む）に， 
        /// CV_GRAPH_NEW_TREE イベントを生成する．無向グラフにおいては，各探索木が，グラフの接続される一つの成分に対応する．
        /// [CV_GRAPH_NEW_TREE]
        /// </summary>
#else
        /// <summary>
        /// Stop in the beginning of every new search tree. When the traversal procedure visits all vertices and edges reachible from the initial vertex (the visited vertices together with tree edges make up a tree), it searches for some unvisited vertex in the graph and resumes the traversal process from that vertex. Before starting a new tree (including the very first tree when cvNextGraphItem is called for the first time) it generates CV_GRAPH_NEW_TREE event.
        /// For unoriented graphs each search tree corresponds to a connected component of the graph.
        /// [CV_GRAPH_NEW_TREE]
        /// </summary>
#endif
        NewTree = CvConst.CV_GRAPH_NEW_TREE,
#if LANG_JP
        /// <summary>
        /// 逆探索（バックトラッキング，既にアクセスされた頂点を逆に戻っていく）中に，すべてのアクセス済みの頂点で停止する．
        /// [CV_GRAPH_BACKTRACKING]
        /// </summary>
#else
        /// <summary>
        /// Stop at every already visited vertex during backtracking - returning to already visited vertexes of the traversal tree.
        /// [CV_GRAPH_BACKTRACKING]
        /// </summary>
#endif
        BackTracking = CvConst.CV_GRAPH_BACKTRACKING,
#if LANG_JP
        /// <summary>
        /// [CV_GRAPH_OVER]
        /// </summary>
#else
        /// <summary>
        /// All events are interesting
        /// [CV_GRAPH_OVER]
        /// </summary>
#endif
        Over = CvConst.CV_GRAPH_OVER,
#if LANG_JP
        /// <summary>
        /// [CV_GRAPH_ALL_ITEMS]
        /// </summary>
#else
        /// <summary>
        /// All events are interesting
        /// [CV_GRAPH_ALL_ITEMS]
        /// </summary>
#endif
        AllItems = CvConst.CV_GRAPH_ALL_ITEMS,
    }
}
