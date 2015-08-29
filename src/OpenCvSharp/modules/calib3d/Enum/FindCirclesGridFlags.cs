using System;
using System.Collections.Generic;
namespace OpenCvSharp
{
    /// <summary>
    /// Method for solving a PnP problem:
    /// </summary>
    [Flags]
    public enum FindCirclesGridFlags : int
    {
        /// <summary>
        /// uses symmetric pattern of circles.
        /// </summary>
        SymmetricGrid = 1,

        /// <summary>
        /// uses asymmetric pattern of circles.
        /// </summary>
        AsymmetricGrid = 2,

        /// <summary>
        /// uses a special algorithm for grid detection. It is more robust to perspective distortions but much more sensitive to background clutter.
        /// </summary>
        Clustering = 4,
    }
}
