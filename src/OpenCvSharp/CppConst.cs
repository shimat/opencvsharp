using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Constantt values
    /// </summary>
    internal static class CppConst
    {
        /// <summary>
        /// cv::Param types
        /// </summary>
        public const int Param_INT = 0,
            Param_BOOLEAN = 1,
            Param_REAL = 2,
            Param_STRING = 3,
            Param_MAT = 4,
            Param_MAT_VECTOR = 5,
            Param_ALGORITHM = 6,
            Param_FLOAT = 7,
            Param_UNSIGNED_INT = 8,
            Param_UINT64 = 9,
            Param_SHORT = 10,
            Param_UCHAR = 11;
 
        /// <summary>
        /// cv::initWideAngleProjMap flags
        /// </summary>
        public const int
            PROJ_SPHERICAL_ORTHO = 0,
            PROJ_SPHERICAL_EQRECT = 1;

        /// <summary>
        /// DrawMatchesFlags
        /// </summary>
        public const int
            DrawMatchesFlags_DEFAULT = 0,
            DrawMatchesFlags_DRAW_OVER_OUTIMG = 1,
            DrawMatchesFlags_NOT_DRAW_SINGLE_POINTS = 2,
            DrawMatchesFlags_DRAW_RICH_KEYPOINTS = 4;

        /// <summary>
        /// cv::ORB
        /// </summary>
        public const int
            ORB_HARRIS_SCORE = 0,
            ORB_FAST_SCORE = 1;

        /// <summary>
        /// CascadeClassifier
        /// </summary>
        public const int CASCADE_DO_CANNY_PRUNING = 1,
            CASCADE_SCALE_IMAGE = 2,
            CASCADE_FIND_BIGGEST_OBJECT = 4,
            CASCADE_DO_ROUGH_SEARCH = 8;
    }
}
