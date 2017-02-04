using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// thinning algorithm
    /// </summary>
    public enum ThinningTypes : int
    {
        /// <summary>
        /// Thinning technique of Zhang-Suen
        /// </summary>

        ZHANGSUEN = 0, 

        /// <summary>
        /// Thinning technique of Guo-Hall
        /// </summary>
        GUOHALL = 1 
    }
}