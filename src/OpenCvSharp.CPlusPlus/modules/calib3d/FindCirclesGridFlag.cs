using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Method for solving a PnP problem:
    /// </summary>
    [Flags]
    public enum FindCirclesGridFlag : int
    {
        /// <summary>
        /// uses symmetric pattern of circles.
        /// </summary>
        SymmetricGrid = CppConst.CALIB_CB_SYMMETRIC_GRID,

        /// <summary>
        /// uses asymmetric pattern of circles.
        /// </summary>
        AsymmetricGrid = CppConst.CALIB_CB_ASYMMETRIC_GRID,

        /// <summary>
        /// uses a special algorithm for grid detection. It is more robust to perspective distortions but much more sensitive to background clutter.
        /// </summary>
        Clustering = CppConst.CALIB_CB_CLUSTERING,
    }
}
