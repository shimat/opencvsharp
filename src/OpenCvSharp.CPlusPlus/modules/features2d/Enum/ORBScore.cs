using System;


namespace OpenCvSharp
{
    /// <summary>
    /// cv::ORB score flags
    /// </summary>
    public enum ORBScore : int
    {
        /// <summary>
        /// 
        /// </summary>
        Fast = CppConst.ORB_FAST_SCORE,

        /// <summary>
        /// 
        /// </summary>
        Harris = CppConst.ORB_HARRIS_SCORE,
    }
}
