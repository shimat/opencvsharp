using System;

namespace OpenCvSharp
{

#if LANG_JP
    /// <summary>
	/// diagonal type
	/// </summary>
#else
    /// <summary>
    /// diagonal type
    /// </summary>
#endif
    public enum MatDiagType : int
    {
#if LANG_JP
		/// <summary>
		/// a diagonal from the upper half
        /// [&lt; 0]
		/// </summary>
#else
        /// <summary>
        /// a diagonal from the upper half
        /// [&lt; 0]
        /// </summary>
#endif
        Upper = -1,
#if LANG_JP
		/// <summary>
		/// Main dialonal
        /// [= 0]
		/// </summary>
#else
        /// <summary>
        /// Main dialonal
        /// [= 0]
        /// </summary>
#endif
        Main = 0,
#if LANG_JP
		/// <summary>
		/// a diagonal from the lower half
        /// [&gt; 0]
		/// </summary>
#else
        /// <summary>
        /// a diagonal from the lower half
        /// [&gt; 0]
        /// </summary>
#endif
        Lower = +1,
    }
}


