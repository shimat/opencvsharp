using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// types of intersection between rectangles
    /// </summary>
    public enum RectanglesIntersectTypes
    {
        /// <summary>
        /// No intersection
        /// </summary>
        None = 0,  

        /// <summary>
        /// There is a partial intersection
        /// </summary>
        Partial = 1, 

        /// <summary>
        /// One of the rectangle is fully enclosed in the other
        /// </summary>
        Full = 2 
    }
}
