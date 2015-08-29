using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    /// <summary>
    /// cv::calcOpticalFlowPyrLK flags
    /// </summary>
    [Flags]
    public enum OpticalFlowFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        PyrAReady = 1,

        /// <summary>
        /// 
        /// </summary>
        PyrBReady = 2,

        /// <summary>
        /// 
        /// </summary>
        UseInitialFlow = 4,

        /// <summary>
        /// 
        /// </summary>
        LkGetMinEigenvals = 8,

        /// <summary>
        /// 
        /// </summary>
        FarnebackGaussian = 256,
    }
}
