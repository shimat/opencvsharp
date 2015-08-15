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
        SphericalOrtho = CppConst.PROJ_SPHERICAL_ORTHO,

        /// <summary>
        /// 
        /// </summary>
        SphericalEqRect = CppConst.PROJ_SPHERICAL_EQRECT,
    }
}
