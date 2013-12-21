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
	/// cvGetDiagメソッドにて、どの対角列を取得するかのフラグ
	/// </summary>
#else
    /// <summary>
    /// Array diagonal
    /// </summary>
#endif
    public enum DiagType : int
    {
#if LANG_JP
		/// <summary>
		/// メインの対角列
		/// </summary>
#else
        /// <summary>
        /// corresponds to the main diagonal
        /// </summary>
#endif
        Main = 0,


#if LANG_JP
		/// <summary>
		/// メインの対角列の一つ上の斜め列
		/// </summary>
#else
        /// <summary>
        /// corresponds to the diagonal above the main etc.
        /// </summary>
#endif
        Above = 1,


#if LANG_JP
		/// <summary>
		/// メインの対角列の一つ下の斜め列
		/// </summary>
#else
        /// <summary>
        /// corresponds to the diagonal below the main etc. 
        /// </summary>
#endif
        Below = -1
    }
}
