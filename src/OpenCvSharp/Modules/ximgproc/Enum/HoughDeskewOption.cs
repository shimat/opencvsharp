using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Specifies to do or not to do skewing of Hough transform image 
    /// </summary>
    /// <remarks>
    /// The enum specifies to do or not to do skewing of Hough transform image 
    /// so it would be no cycling in Hough transform image through borders of image.
    /// </remarks>
    public enum HoughDeskewOption : int
    {
        /// <summary>
        /// Use raw cyclic image
        /// </summary>
        RAW = 0,

        /// <summary>
        /// Prepare deskewed image
        /// </summary>
        DESKEW = 1  
    }
}