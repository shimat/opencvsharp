using System;

namespace OpenCvSharp
{
    /// <summary>
    /// cv::initWideAngleProjMap flags
    /// </summary>
    public enum ProjectionType : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        SphericalOrtho = 0,

        /// <summary>
        /// 
        /// </summary>
        SphericalEqRect = 1,
    }
}
