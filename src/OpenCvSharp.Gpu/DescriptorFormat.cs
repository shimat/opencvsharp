/*
* (C) 2008-2013 Schima
* This code is licenced under the LGPL.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Gpu
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
    public enum DescriptorFormat : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [HOGDescriptor::DESCR_FORMAT_ROW_BY_ROW]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [HOGDescriptor::DESCR_FORMAT_ROW_BY_ROW]
        /// </summary>
#endif
        RowByRow = 0,


#if LANG_JP
		/// <summary>
		/// 
        /// [HOGDescriptor::DESCR_FORMAT_COL_BY_COL]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [HOGDescriptor::DESCR_FORMAT_COL_BY_COL]
        /// </summary>
#endif
        ColByCol = 0,
    }
}


