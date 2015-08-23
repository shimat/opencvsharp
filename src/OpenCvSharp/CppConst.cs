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

        /// <summary>
        /// calcOpticalFlowPyrLK
        /// </summary>
        public const int
            OPTFLOW_PYR_A_READY = 1,
            OPTFLOW_PYR_B_READY = 2,
            OPTFLOW_USE_INITIAL_FLOW = 4,
            OPTFLOW_LK_GET_MIN_EIGENVALS = 8,
            OPTFLOW_FARNEBACK_GAUSSIAN = 256;

        /// <summary>
        /// cv::flann distance types
        /// </summary>
        public const int FLANN_DIST_EUCLIDEAN = 1,
                         FLANN_DIST_L2 = 1,
                         FLANN_DIST_MANHATTAN = 2,
                         FLANN_DIST_L1 = 2,
                         FLANN_DIST_MINKOWSKI = 3,
                         FLANN_DIST_MAX = 4,
                         FLANN_DIST_HIST_INTERSECT = 5,
                         FLANN_DIST_HELLINGER = 6,
                         FLANN_DIST_CHI_SQUARE = 7,
                         FLANN_DIST_CS = 7,
                         FLANN_DIST_KULLBACK_LEIBLER = 8,
                         FLANN_DIST_KL = 8,
                         FLANN_DIST_HAMMING = 9;
    }
}
