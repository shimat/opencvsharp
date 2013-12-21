/*
* (C) 2008-2013 Schima
* This code is licenced under the LGPL.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
    public enum HistogramNormType : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [HOGDescriptor::L2Hys]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [HOGDescriptor::L2Hys]
        /// </summary>
#endif
        L2Hys = HOGDescriptor.L2Hys,
    }
}


