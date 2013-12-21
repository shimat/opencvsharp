/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.MachineLearning
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
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct CvPair32s32f
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
		public int I;
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
		/// <summary>
		/// 
		/// </summary>
#endif
		public float Val;



#if LANG_JP
		/// <summary>
		/// 初期化
		/// </summary>
#else
		/// <summary>
		/// Constructor
		/// </summary>
#endif
		public CvPair32s32f(int i, float val)
		{
			this.I = i;
			this.Val = val;
		}
	};
}
