using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Specifies the binarization method to use in cv::ximgproc::niBlackThreshold
    /// </summary>
    public enum LocalBinarizationMethods 
    {
        /// <summary>
        /// Classic Niblack binarization. See @cite Niblack1985 .
        /// </summary>
        Niblack = 0, 

        /// <summary>
        /// Sauvola's technique. See @cite Sauvola1997 .
        /// </summary>
        Sauvola = 1,

        /// <summary>
        /// Wolf's technique. See @cite Wolf2004 .
        /// </summary>
        Wolf = 2,

        /// <summary>
        /// NICK technique. See @cite Khurshid2009 .
        /// </summary>
        Nick = 3
    }
}