using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Constantt values
    /// </summary>
    internal static class CppConst
    {
        public const int
            FileStorage_READ = 0,  //! read mode
            FileStorage_WRITE = 1,  //! write mode
            FileStorage_APPEND = 2, //! append mode
            FileStorage_MEMORY = 4,
            FileStorage_FORMAT_MASK = (7 << 3),
            FileStorage_FORMAT_AUTO = 0,
            FileStorage_FORMAT_XML = (1 << 3),
            FileStorage_FORMAT_YAML = (2 << 3);
           
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
        /// matrix decomposition types
        /// </summary>
        public const int DECOMP_LU = 0,
            DECOMP_SVD = 1,
            DECOMP_EIG = 2,
            DECOMP_CHOLESKY = 3,
            DECOMP_QR = 4,
            DECOMP_NORMAL = 16;

        /// <summary>
        /// InputArray kind
        /// </summary>
        public const int InputArray_KIND_SHIFT = 16,
            InputArray_FIXED_TYPE = 0x8000 << InputArray_KIND_SHIFT,
            InputArray_FIXED_SIZE = 0x4000 << InputArray_KIND_SHIFT,
            InputArray_KIND_MASK = ~(InputArray_FIXED_TYPE | InputArray_FIXED_SIZE) - (1 << InputArray_KIND_SHIFT) + 1,
            InputArray_NONE = 0 << InputArray_KIND_SHIFT,
            InputArray_MAT = 1 << InputArray_KIND_SHIFT,
            InputArray_MATX = 2 << InputArray_KIND_SHIFT,
            InputArray_STD_VECTOR = 3 << InputArray_KIND_SHIFT,
            InputArray_STD_VECTOR_VECTOR = 4 << InputArray_KIND_SHIFT,
            InputArray_STD_VECTOR_MAT = 5 << InputArray_KIND_SHIFT,
            InputArray_EXPR = 6 << InputArray_KIND_SHIFT,
            InputArray_OPENGL_BUFFER = 7 << InputArray_KIND_SHIFT,
            InputArray_OPENGL_TEXTURE = 8 << InputArray_KIND_SHIFT,
            InputArray_GPU_MAT = 9 << InputArray_KIND_SHIFT,
            InputArray_OCL_MAT = 10 << InputArray_KIND_SHIFT;

        /// <summary>
        /// various border interpolation methods
        /// </summary>
        public const int BORDER_REPLICATE = 1,
            BORDER_CONSTANT = 0,
            BORDER_REFLECT = 2,
            BORDER_WRAP = 3,
            BORDER_REFLECT101 = 4,
            BORDER_TRANSPARENT = 5,
            BORDER_DEFAULT = BORDER_REFLECT101,
            BORDER_ISOLATED = 16;

        /// <summary>
        /// shape of the structuring element
        /// </summary>
        public const int MORPH_RECT = 0,
            MORPH_CROSS = 1,
            MORPH_ELLIPSE = 2;

        /// <summary>
        /// cv::dft flags
        /// </summary>
        public const int DFT_INVERSE = 1,
            DFT_SCALE = 2,
            DFT_ROWS = 4,
            DFT_COMPLEX_OUTPUT = 16,
            DFT_REAL_OUTPUT = 32;

        /// <summary>
        /// cv::dct flags
        /// </summary>
        public const int DCT_INVERSE = DFT_INVERSE,
            DCT_ROWS = DFT_ROWS;

        /// <summary>
        /// cv::initWideAngleProjMap flags
        /// </summary>
        public const int
            PROJ_SPHERICAL_ORTHO = 0,
            PROJ_SPHERICAL_EQRECT = 1;

        /// <summary>
        /// GrabCut algorithm flags
        /// </summary>
        public const int
            GC_INIT_WITH_RECT = 0,
            GC_INIT_WITH_MASK = 1,
            GC_EVAL = 2;

        /// <summary>
        /// Mask size for distance transform 
        /// </summary>
        public const int
            CV_DIST_MASK_3 = 3,
            CV_DIST_MASK_5 = 5,
            CV_DIST_MASK_PRECISE = 0;

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
        /// cv::solvePnP
        /// </summary>
        public const int SolvePnP_ITERATIVE = 0,
            SolvePnP_EPNP = 1,
            SolvePnP_P3P = 2;

        public const int CALIB_CB_SYMMETRIC_GRID = 1,
            CALIB_CB_ASYMMETRIC_GRID = 2,
            CALIB_CB_CLUSTERING = 4;

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
        /// applyColorMap
        /// </summary>
        public const int COLORMAP_AUTUMN = 0,
            COLORMAP_BONE = 1,
            COLORMAP_JET = 2,
            COLORMAP_WINTER = 3,
            COLORMAP_RAINBOW = 4,
            COLORMAP_OCEAN = 5,
            COLORMAP_SUMMER = 6,
            COLORMAP_SPRING = 7,
            COLORMAP_COOL = 8,
            COLORMAP_HSV = 9,
            COLORMAP_PINK = 10,
            COLORMAP_HOT = 11;

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
