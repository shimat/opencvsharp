using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 重み付きの有向または無向グラフ
    /// </summary>
#else
    /// <summary>
    /// Oriented or unoriented weigted graph
    /// </summary>
#endif
    public class CvGraph : CvSet
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
        protected CvGraph()
        {
            ptr = IntPtr.Zero;
        }
#if LANG_JP
        /// <summary>
        /// 空のグラフを生成する
        /// </summary>
        /// <param name="graphFlags">生成したグラフのタイプ．無向グラフの場合，CV_SEQ_KIND_GRAPH，有向グラフの場合，CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED． </param>
        /// <param name="vtxSize">グラフのヘッダサイズ （sizeof(CvGraph)以上）</param>
        /// <param name="edgeSize">グラフの頂点サイズ</param>
        /// <param name="storage">グラフの辺サイズ</param>
#else
        /// <summary>
        /// Creates empty graph
        /// </summary>
        /// <param name="graphFlags">Type of the created graph. Usually, it is either CV_SEQ_KIND_GRAPH for generic unoriented graphs and CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED for generic oriented graphs. </param>
        /// <param name="vtxSize">Graph vertex size; the custom vertex structure must start with CvGraphVtx  (use CV_GRAPH_VERTEX_FIELDS()) </param>
        /// <param name="edgeSize">Graph edge size; the custom edge structure must start with CvGraphEdge  (use CV_GRAPH_EDGE_FIELDS()) </param>
        /// <param name="storage">The graph container. </param>
        /// <remarks>The function cvCreateGraph creates an empty graph and returns it.</remarks>
#endif
        public CvGraph(SeqType graphFlags, int vtxSize, int edgeSize, CvMemStorage storage)
            : this(graphFlags, vtxSize, edgeSize, storage, CvGraph.SizeOf)
        {
        }
#if LANG_JP
        /// <summary>
        /// 空のグラフを生成する
        /// </summary>
        /// <param name="graphFlags">生成したグラフのタイプ．無向グラフの場合，CV_SEQ_KIND_GRAPH，有向グラフの場合，CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED． </param>
        /// <param name="headerSize">グラフのヘッダサイズ （sizeof(CvGraph)以上）</param>
        /// <param name="vtxSize">グラフの頂点サイズ</param>
        /// <param name="edgeSize">グラフの辺サイズ</param>
        /// <param name="storage">グラフコンテナ</param>
#else
        /// <summary>
        /// Creates empty graph
        /// </summary>
        /// <param name="graphFlags">Type of the created graph. Usually, it is either CV_SEQ_KIND_GRAPH for generic unoriented graphs and CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED for generic oriented graphs. </param>
        /// <param name="headerSize">Graph header size; may not be less than sizeof(CvGraph).</param>
        /// <param name="vtxSize">Graph vertex size; the custom vertex structure must start with CvGraphVtx  (use CV_GRAPH_VERTEX_FIELDS()) </param>
        /// <param name="edgeSize">Graph edge size; the custom edge structure must start with CvGraphEdge  (use CV_GRAPH_EDGE_FIELDS()) </param>
        /// <param name="storage">The graph container. </param>
        /// <remarks>The function cvCreateGraph creates an empty graph and returns it.</remarks>
#endif
        public CvGraph(SeqType graphFlags, int vtxSize, int edgeSize, CvMemStorage storage, int headerSize)
        {
            if (storage == null)
                throw new ArgumentNullException();
            
            IntPtr p = NativeMethods.cvCreateGraph(graphFlags, headerSize, vtxSize, edgeSize, storage.CvPtr);
            Initialize(p);
            holdingStorage = storage;
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvGraph*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvGraph*</param>
#endif
        public CvGraph(IntPtr ptr)
        {
            Initialize(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvGraph) 
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvGraph));


#if LANG_JP
        /// <summary>
        /// 辺のセット
        /// </summary>
#else
        /// <summary>
        /// Set of edges
        /// </summary>
#endif
        public CvSet Edges
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvGraph*)ptr)->edges);

                    if (p != IntPtr.Zero)
                        return new CvSet(p);
                    return null;
                }
            }
        }
        #endregion

        #region Methods
        #region ClearGraph
#if LANG_JP
        /// <summary>
        /// グラフから全ての頂点と辺を削除する
        /// </summary>
#else
        /// <summary>
        /// Returns index of graph vertex
        /// </summary>
        /// <remarks>The function cvClearGraph removes all vertices and edges from the graph. The function has O(1) time complexity.</remarks>
#endif
        public void ClearGraph()
        {
            Cv.ClearGraph(this);
        }
        #endregion
        #region CloneGraph
#if LANG_JP
        /// <summary>
        /// グラフをコピーする
        /// </summary>
        /// <param name="storage">コピーのためのコンテナ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clone graph
        /// </summary>
        /// <param name="storage">Container for the copy. </param>
        /// <returns>The function cvCloneGraph creates full copy of the graph. If the graph vertices or edges have pointers to some external data, it still be shared between the copies. The vertex and edge indices in the new graph may be different from the original, because the function defragments the vertex and edge sets.</returns>
#endif
        public CvGraph CloneGraph(CvMemStorage storage)
        {
            return Cv.CloneGraph(this, storage);
        }
        #endregion
        #region FindGraphEdge
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（インデックス指定）
        /// </summary>
        /// <param name="startIdx">辺の始点を示す頂点のインデックス． </param>
        /// <param name="endIdx">辺の終点を示す頂点のインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public CvGraphEdge FindGraphEdge(int startIdx, int endIdx)
        {
            return Cv.FindGraphEdge(this, startIdx, endIdx);
        }
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（インデックス指定）
        /// </summary>
        /// <param name="startIdx">辺の始点を示す頂点のインデックス． </param>
        /// <param name="endIdx">辺の終点を示す頂点のインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public CvGraphEdge GraphFindEdge(int startIdx, int endIdx)
        {
            return Cv.GraphFindEdge(this, startIdx, endIdx);
        }
        #endregion
        #region FindGraphEdgeByPtr
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（ポインタ指定）
        /// </summary>
        /// <param name="startVtx">辺の始点を示す頂点へのポインタ． </param>
        /// <param name="endVtx">辺の終点を示す頂点へのポインタ．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns>指定した二つの頂点を接続する辺</returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public CvGraphEdge FindGraphEdgeByPtr(CvGraphVtx startVtx, CvGraphVtx endVtx)
        {
            return Cv.FindGraphEdgeByPtr(this, startVtx, endVtx);
        }
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（ポインタ指定）
        /// </summary>
        /// <param name="startVtx">辺の始点を示す頂点へのポインタ． </param>
        /// <param name="endVtx">辺の終点を示す頂点へのポインタ．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns>指定した二つの頂点を接続する辺</returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public CvGraphEdge GraphFindEdgeByPtr(CvGraphVtx startVtx, CvGraphVtx endVtx)
        {
            return Cv.GraphFindEdgeByPtr(this, startVtx, endVtx);
        }
        #endregion
        #region GraphAddEdge
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（インデックス指定）
        /// </summary>
        /// <param name="startIdx">辺の始点を示すインデックス</param>
        /// <param name="endIdx">辺の終点を示すインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public int GraphAddEdge(int startIdx, int endIdx)
        {
            return Cv.GraphAddEdge(this, startIdx, endIdx);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（インデックス指定）
        /// </summary>
        /// <param name="startIdx">辺の始点を示すインデックス</param>
        /// <param name="endIdx">辺の終点を示すインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <param name="edge">オプションの入力パラメータ．辺の初期化のためのデータ． </param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public int GraphAddEdge(int startIdx, int endIdx, CvGraphEdge edge)
        {
            return Cv.GraphAddEdge(this, startIdx, endIdx, edge);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（インデックス指定）
        /// </summary>
        /// <param name="startIdx">辺の始点を示すインデックス</param>
        /// <param name="endIdx">辺の終点を示すインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <param name="edge">オプションの入力パラメータ．辺の初期化のためのデータ． </param>
        /// <param name="insertedEdge">入力された辺のアドレスを保存するための，オプションの出力パラメータ． </param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <param name="insertedEdge">Optional output parameter to contain the address of the inserted edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public int GraphAddEdge(int startIdx, int endIdx, CvGraphEdge edge, IntPtr insertedEdge)
        {
            return Cv.GraphAddEdge(this, startIdx, endIdx, edge, insertedEdge);
        }
        #endregion
        #region GraphAddEdgeByPtr
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（ポインタ指定）
        /// </summary>
        /// <param name="startVtx">辺の始点を示す頂点</param>
        /// <param name="endVtx">辺の終点を示す頂点</param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public int GraphAddEdgeByPtr(CvGraphEdge startVtx, CvGraphEdge endVtx)
        {
            return Cv.GraphAddEdgeByPtr(this, startVtx, endVtx);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（ポインタ指定）
        /// </summary>
        /// <param name="startVtx">辺の始点を示す頂点</param>
        /// <param name="endVtx">辺の終点を示す頂点</param>
        /// <param name="edge">オプションの入力パラメータ，辺の初期化データ．</param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public int GraphAddEdgeByPtr(CvGraphEdge startVtx, CvGraphEdge endVtx, CvGraphEdge edge)
        {
            return Cv.GraphAddEdgeByPtr(this, startVtx, endVtx, edge);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（ポインタ指定）
        /// </summary>
        /// <param name="startVtx">辺の始点を示す頂点</param>
        /// <param name="endVtx">辺の終点を示す頂点</param>
        /// <param name="edge">オプションの入力パラメータ，辺の初期化データ．</param>
        /// <param name="insertedEdge">辺の集合の中で入力された辺のアドレスを保存するための，オプションの出力パラメータ．</param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <param name="insertedEdge">Optional output parameter to contain the address of the inserted edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public int GraphAddEdgeByPtr(CvGraphEdge startVtx, CvGraphEdge endVtx, CvGraphEdge edge, IntPtr insertedEdge)
        {
            return Cv.GraphAddEdgeByPtr(this, startVtx, endVtx, edge, insertedEdge);
        }
        #endregion
        #region GraphAddVtx
#if LANG_JP
        /// <summary>
        /// グラフに頂点を追加する
        /// </summary>
        /// <returns>頂点のインデックス</returns>
#else
        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <returns>The function cvGraphAddVtx adds a vertex to the graph and returns the vertex index.</returns>
#endif
        public int GraphAddVtx()
        {
            return Cv.GraphAddVtx(this);
        }
#if LANG_JP
        /// <summary>
        /// グラフに頂点を追加する
        /// </summary>
        /// <param name="vtx">追加される頂点の初期化に使用される，オプションの入力引数（sizeof(CvGraphVtx)の領域を超えたユーザー定義フィールドのみコピーされる）． </param>
        /// <returns>頂点のインデックス</returns>
#else
        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="vtx">Optional input argument used to initialize the added vertex (only user-defined fields beyond sizeof(CvGraphVtx) are copied). </param>
        /// <returns>The function cvGraphAddVtx adds a vertex to the graph and returns the vertex index.</returns>
#endif
        public int GraphAddVtx(CvGraphVtx vtx)
        {
            return Cv.GraphAddVtx(this, vtx);
        }
#if LANG_JP
        /// <summary>
        /// グラフに頂点を追加する
        /// </summary>
        /// <param name="vtx">追加される頂点の初期化に使用される，オプションの入力引数（sizeof(CvGraphVtx)の領域を超えたユーザー定義フィールドのみコピーされる）． </param>
        /// <param name="insertedVtx">新しい頂点のアドレスがここに書かれる．</param>
        /// <returns>頂点のインデックス</returns>
#else
        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="vtx">Optional input argument used to initialize the added vertex (only user-defined fields beyond sizeof(CvGraphVtx) are copied). </param>
        /// <param name="insertedVtx">The address of the new vertex is written there. </param>
        /// <returns>The function cvGraphAddVtx adds a vertex to the graph and returns the vertex index.</returns>
#endif
        public int GraphAddVtx(CvGraphVtx vtx, out CvGraphVtx insertedVtx)
        {
            return Cv.GraphAddVtx(this, vtx, out insertedVtx);
        }
        #endregion
        #region GraphEdgeIdx
#if LANG_JP
        /// <summary>
        /// グラフの辺のインデックスを返す
        /// </summary>
        /// <param name="edge">辺への参照</param>
        /// <returns>グラフの辺のインデックス</returns>
#else
        /// <summary>
        /// Returns index of graph edge
        /// </summary>
        /// <param name="edge">Graph edge. </param>
        /// <returns>The function cvGraphEdgeIdx returns index of the graph edge.</returns>
#endif
        public int GraphEdgeIdx(CvGraphEdge edge)
        {
            return Cv.GraphEdgeIdx(this, edge);
        }
        #endregion
        #region GraphGetEdgeCount
#if LANG_JP
        /// <summary>
        /// Returns count of edges
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns count of edges
        /// </summary>
        /// <returns></returns>
#endif
        public int GraphGetEdgeCount()
        {
            return Cv.GraphGetEdgeCount(this);
        }
        #endregion
        #region GraphGetVtxCount
#if LANG_JP
        /// <summary>
        /// Returns count of vertex
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns count of vertex
        /// </summary>
        /// <returns></returns>
#endif
        public int GraphGetVtxCount()
        {
            return Cv.GraphGetVtxCount(this);
        }
        #endregion
        #region GraphRemoveEdge
#if LANG_JP
        /// <summary>
        /// グラフから辺を削除する（インデックス指定）
        /// </summary>
        /// <param name="startIdx">辺の始点を示す頂点のインデックス． </param>
        /// <param name="endIdx">辺の終点を示す頂点のインデックス．無向グラフの場合，順序はどちらでもよい． </param>
#else
        /// <summary>
        /// Removes edge from graph
        /// </summary>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <remarks>The function cvGraphRemoveEdge removes the edge connecting two specified vertices. If the vertices are not connected [in that order], the function does nothing. </remarks>
#endif
        public void GraphRemoveEdge(int startIdx, int endIdx)
        {
            Cv.GraphRemoveEdge(this, startIdx, endIdx);
        }
        #endregion
        #region GraphRemoveEdgeByPtr
#if LANG_JP
        /// <summary>
        /// グラフから辺を削除する（ポインタ指定）
        /// </summary>
        /// <param name="startVtx">辺の始点を示す頂点へのポインタ．</param>
        /// <param name="endVtx">辺の終点を示す頂点へのポインタ．無向グラフの場合，順序はどちらでもよい． </param>
#else
        /// <summary>
        /// Removes edge from graph
        /// </summary>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <remarks>The function cvGraphRemoveEdgeByPtr removes the edge connecting two specified vertices. If the vertices are not connected [in that order], the function does nothing.</remarks>
#endif
        public void GraphRemoveEdgeByPtr(CvGraphVtx startVtx, CvGraphVtx endVtx)
        {
            Cv.GraphRemoveEdgeByPtr(this, startVtx, endVtx);
        }
        #endregion
        #region GraphRemoveVtx
#if LANG_JP
        /// <summary>
        /// グラフから頂点を削除する（インデックス指定）
        /// </summary>
        /// <param name="index">削除される頂点のインデックス</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="index">Index of the removed vertex. </param>
        /// <returns>The function cvGraphRemoveAddVtx removes a vertex from the graph together with all the edges incident to it. The function reports an error, if the input vertex does not belong to the graph. The return value is number of edges deleted, or -1 if the vertex does not belong to the graph.</returns>
#endif
        public int GraphRemoveVtx(int index)
        {
            return Cv.GraphRemoveVtx(this, index);
        }
        #endregion
        #region GraphRemoveVtxByPtr
#if LANG_JP
        /// <summary>
        /// グラフから頂点を削除する（ポインタ指定）
        /// </summary>
        /// <param name="vtx">削除される頂点へのポインタ</param>
        /// <returns>削除された辺の数，あるいは頂点がグラフに存在しない場合は-1</returns>
#else
        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="vtx">Vertex to remove </param>
        /// <returns>The function cvGraphRemoveVtxByPtr removes a vertex from the graph together with all the edges incident to it. The function reports an error, if the vertex does not belong to the graph. The return value is number of edges deleted, or -1 if the vertex does not belong to the graph.</returns>
#endif
        public int GraphRemoveVtxByPtr(CvGraphVtx vtx)
        {
            return Cv.GraphRemoveVtxByPtr(this, vtx);
        }
        #endregion
        #region GraphVtxDegree
#if LANG_JP
        /// <summary>
        /// 頂点に接続している辺の数を数える（インデックス指定）
        /// </summary>
        /// <param name="vtxIdx">頂点のインデックス</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Counts edges indicent to the vertex
        /// </summary>
        /// <param name="vtxIdx">Index of the graph vertex.  </param>
        /// <returns>The function cvGraphVtxDegree returns the number of edges incident to the specified vertex, both incoming and outcoming. </returns>
#endif
        public int GraphVtxDegree(int vtxIdx)
        {
            return Cv.GraphVtxDegree(this, vtxIdx);
        }
        #endregion
        #region GraphVtxDegreeByPtr
#if LANG_JP
        /// <summary>
        /// 頂点に接続している辺の数を数える（ポインタ指定）
        /// </summary>
        /// <param name="vtx">頂点へのポインタ</param>
        /// <returns>指定した頂点に接続した（入る/出る両方向の）辺の数</returns>
#else
        /// <summary>
        /// Counts edges indicent to the vertex
        /// </summary>
        /// <param name="vtx">Index of the graph vertex.  </param>
        /// <returns>The function cvGraphVtxDegree returns the number of edges incident to the specified vertex, both incoming and outcoming.</returns>
#endif
        public int GraphVtxDegreeByPtr(CvGraphVtx vtx)
        {
            return Cv.GraphVtxDegreeByPtr(this, vtx);
        }
        #endregion
        #region GraphVtxIdx
#if LANG_JP
        /// <summary>
        /// グラフ頂点のインデックスを返す
        /// </summary>
        /// <param name="vtx">グラフ頂点への参照</param>
        /// <returns>グラフ頂点のインデックスを返す</returns>
#else
        /// <summary>
        /// Returns index of graph vertex
        /// </summary>
        /// <param name="vtx">Graph vertex. </param>
        /// <returns>The function cvGraphVtxIdx returns index of the graph vertex.</returns>
#endif
        public int GraphVtxIdx(CvGraphVtx vtx)
        {
            return Cv.GraphVtxIdx(this, vtx);
        }
        #endregion
        #endregion
    }
}