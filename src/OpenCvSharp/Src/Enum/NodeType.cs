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
	/// ノードの種類
	/// </summary>
#else
    /// <summary>
    /// File node type
    /// </summary>
#endif
	[Flags]
	public enum NodeType : int
	{
		/// <summary>
		/// 
		/// </summary>
		None = CvConst.CV_NODE_NONE,
		/// <summary>
		/// 
		/// </summary>
        Integer = CvConst.CV_NODE_INTEGER,
		/// <summary>
		/// 
		/// </summary>
        Float = CvConst.CV_NODE_FLOAT,
		/// <summary>
		/// 
		/// </summary>
        String = CvConst.CV_NODE_STRING,
		/// <summary>
		/// not used
		/// </summary>
        [Obsolete]
        Red = CvConst.CV_NODE_REF,
		/// <summary>
		/// 
		/// </summary>
        Seq = CvConst.CV_NODE_SEQ,
		/// <summary>
		/// 
		/// </summary>
        Map = CvConst.CV_NODE_MAP,

		/// <summary>
		/// used only for writing structures to YAML format
		/// </summary>
        Flow = CvConst.CV_NODE_FLOW,
		/// <summary>
		/// 
		/// </summary>
        User = CvConst.CV_NODE_USER,
		/// <summary>
		/// 
		/// </summary>
        Empty = CvConst.CV_NODE_EMPTY,
		/// <summary>
		/// 
		/// </summary>
        Named = CvConst.CV_NODE_NAMED,
	};
}
