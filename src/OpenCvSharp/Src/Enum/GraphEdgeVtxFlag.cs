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
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public enum GraphEdgeVtxFlag : int
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
        GraphItemVisited = CvConst.CV_GRAPH_ITEM_VISITED_FLAG,
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        GraphSearchTreeNode = CvConst.CV_GRAPH_SEARCH_TREE_NODE_FLAG,
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        GraphForwardEdgeFlag = CvConst.CV_GRAPH_FORWARD_EDGE_FLAG,
    }
}
