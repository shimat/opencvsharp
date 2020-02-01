﻿namespace OpenCvSharp
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
    public enum MatDiagType
    {
        /// <summary>
        /// a diagonal from the upper half
        /// [&lt; 0]
        /// </summary>
        Upper = -1,

        /// <summary>
        /// Main diagonal
        /// [= 0]
        /// </summary>
        Main = 0,

        /// <summary>
        /// a diagonal from the lower half
        /// [&gt; 0]
        /// </summary>
        Lower = +1,
    }
}


