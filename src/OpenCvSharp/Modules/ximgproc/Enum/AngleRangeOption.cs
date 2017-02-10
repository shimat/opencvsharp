using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Specifies the part of Hough space to calculate
    /// </summary>
    /// <remarks>
    /// The enum specifies the part of Hough space to calculate. 
    /// Each member specifies primarily direction of lines(horizontal or vertical) 
    /// and the direction of angle changes. 
    /// Direction of angle changes is from multiples of 90 to odd multiples of 45. 
    /// The image considered to be written top-down and left-to-right. 
    /// Angles are started from vertical line and go clockwise. 
    /// Separate quarters and halves are written in orientation they should be in full Hough space.
    /// </remarks>
    public enum AngleRangeOption : int
    {
        /// <summary>
        /// Vertical primarily direction and clockwise angle changes
        /// </summary>
        ARO_0_45 = 0,

        /// <summary>
        /// Horizontal primarily direction and counterclockwise angle changes
        /// </summary>
        ARO_45_90 = 1,

        /// <summary>
        /// Horizontal primarily direction and clockwise angle changes
        /// </summary>
        ARO_90_135 = 2,

        /// <summary>
        /// Vertical primarily direction and counterclockwise angle changes
        /// </summary>
        ARO_315_0 = 3,

        /// <summary>
        /// Vertical primarily direction
        /// </summary>
        ARO_315_45 = 4,

        /// <summary>
        /// Horizontal primarily direction
        /// </summary>
        ARO_45_135 = 5,

        /// <summary>
        /// Full set of directions
        /// </summary>
        ARO_315_135 = 6,

        /// <summary>
        /// 90 +/- atan(0.5), interval approximately from 64.5 to 116.5 degrees.
        /// It is used for calculating Fast Hough Transform for images skewed by atan(0.5).
        /// </summary>
        ARO_CTR_HOR = 7,

        /// <summary>
        /// +/- atan(0.5), interval approximately from 333.5(-26.5) to 26.5 degrees
        /// It is used for calculating Fast Hough Transform for images skewed by atan(0.5).
        /// </summary>
        ARO_CTR_VER = 8  
    }
}