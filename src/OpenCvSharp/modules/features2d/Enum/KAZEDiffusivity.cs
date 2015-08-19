using System;


namespace OpenCvSharp
{
    /// <summary>
    /// cv::KAZE diffusivity type
    /// </summary>
    public enum KAZEDiffusivity : int
    {
        /// <summary>
        /// 
        /// </summary>
        DiffPmG1 = CppConst.KAZE_DIFF_PM_G1,

        /// <summary>
        /// 
        /// </summary>
        DiffPmG2 = CppConst.KAZE_DIFF_PM_G2,

        /// <summary>
        /// 
        /// </summary>
        DiffWeickert = CppConst.KAZE_DIFF_WEICKERT,

        /// <summary>
        /// 
        /// </summary>
        DiffCharbonnier = CppConst.KAZE_DIFF_CHARBONNIER,
    }
}
