﻿
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 線分の種類
    /// </summary>
#else
    /// <summary>
    /// Type of the line
    /// </summary>
#endif
    public enum LineTypes
    {
        /// <summary>
        /// 8-connected line.
        /// </summary>
        Link8 = 8,

        /// <summary>
        /// 4-connected line.
        /// </summary>
        Link4 = 4,

        /// <summary>
        /// Anti-aliased line. 
        /// </summary>
        AntiAlias = 16
    }
}
