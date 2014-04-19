using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
        PyrAReady = CppConst.OPTFLOW_PYR_A_READY,

        /// <summary>
        /// 
        /// </summary>
        PyrBReady = CppConst.OPTFLOW_PYR_B_READY,

        /// <summary>
        /// 
        /// </summary>
        UseInitialFlow = CppConst.OPTFLOW_USE_INITIAL_FLOW,

        /// <summary>
        /// 
        /// </summary>
        LkGetMinEigenvals = CppConst.OPTFLOW_LK_GET_MIN_EIGENVALS,

        /// <summary>
        /// 
        /// </summary>
        FarnebackGaussian = CppConst.OPTFLOW_FARNEBACK_GAUSSIAN,
    }
}
