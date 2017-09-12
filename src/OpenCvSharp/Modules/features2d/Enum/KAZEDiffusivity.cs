using System;

namespace OpenCvSharp
{
    /// <summary>
    /// cv::KAZE diffusivity type
    /// </summary>
// ReSharper disable once InconsistentNaming
    public enum KAZEDiffusivity : int
    {
        /// <summary>
        /// 
        /// </summary>
        DiffPmG1 = 0,

        /// <summary>
        /// 
        /// </summary>
        DiffPmG2 = 1,

        /// <summary>
        /// 
        /// </summary>
        DiffWeickert = 2,

        /// <summary>
        /// 
        /// </summary>
        DiffCharbonnier = 3,
    }
}
