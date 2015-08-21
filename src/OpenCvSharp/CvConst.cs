using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// OpenCVの定数
	/// </summary>
#else
    /// <summary>
    /// OpenCV Constants defined by macro
    /// </summary>
#endif
    static public class CvConst
    {
        public const int CV_AUTOSTEP = 2147483647;
        public const int CV_FILLED = -1;
        public const double CV_LOG2 = 0.69314718055994530941723212145818;
        public const double CV_PI = 3.1415926535897932384626433832795;
        public const int CV_MAX_DIM = 32;
        public const int CV_WHOLE_SEQ_END_INDEX = 1073741823;
        public const int CV_ORIENTED_GRAPH = 5632;
        public const int CV_GRAPH_FLAG_ORIENTED = 4096;
        public const int CV_GRAPH = 1536;
        public const uint IPL_DEPTH_SIGN = 0x80000000;
        public const uint MAGIC_MASK = 0xFFFF0000;
        public const int TYPE_MASK = 0x00000FFF;
        public const int DEPTH_MASK = 7;
        public const int CV_MAT_CONT_FLAG_SHIFT = 14;
        public const int CV_MAT_CONT_FLAG = (1 << CV_MAT_CONT_FLAG_SHIFT);
        public const uint CV_MAGIC_MASK = 0xFFFF0000;
        public const int CV_MAT_MAGIC_VAL = 0x42420000;

        // Matrix type
        public const int CV_CN_MAX = 64;
        public const int CV_CN_SHIFT = 3;
        public const int CV_DEPTH_MAX = (1 << CV_CN_SHIFT);
        public const int CV_MAT_DEPTH_MASK = (CV_DEPTH_MAX - 1);
        public const int CV_MAT_CN_MASK = ((CV_CN_MAX - 1) << CV_CN_SHIFT);
        public const int CV_MAT_TYPE_MASK = (CV_DEPTH_MAX * CV_CN_MAX - 1);

        // cvApproxPoly
        public const int CV_POLY_APPROX_DP = 0;
        // cvLine, cvCircle, ...
        public const int CV_AA = 16;
        // cvCalibrateCamera2        
        public const int CV_CALIB_USE_INTRINSIC_GUESS = 1;
        public const int CV_CALIB_FIX_ASPECT_RATIO = 2;
        public const int CV_CALIB_FIX_PRINCIPAL_POINT = 4;
        public const int CV_CALIB_ZERO_TANGENT_DIST = 8;
        public const int CV_CALIB_FIX_FOCAL_LENGTH = 16;
        public const int CV_CALIB_FIX_K1 = 32;
        public const int CV_CALIB_FIX_K2 = 64;
        public const int CV_CALIB_FIX_K3 = 128;
        public const int CV_CALIB_FIX_INTRINSIC = 256;
        public const int CV_CALIB_SAME_FOCAL_LENGTH = 512;
        public const int CV_CALIB_FIX_K4 = 2048;
        public const int CV_CALIB_FIX_K5 = 4096;
        public const int CV_CALIB_FIX_K6 = 8192;
        public const int CV_CALIB_RATIONAL_MODEL = 16384;

        // cvCalcCoverMatrix
        public const int CV_COVAR_SCRAMBLED = 0;
        public const int CV_COVAR_NORMAL = 1;
        public const int CV_COVAR_USE_AVG = 2;
        public const int CV_COVAR_SCALE = 4;
        public const int CV_COVAR_ROWS = 8;
        public const int CV_COVAR_COLS = 16;
        // cvCalcCoverMatrixEx, cvCalcEigenObjects, ...
        public const int CV_EIGOBJ_NO_CALLBACK = 0;
        public const int CV_EIGOBJ_INPUT_CALLBACK = 1;
        public const int CV_EIGOBJ_OUTPUT_CALLBACK = 2;
        public const int CV_EIGOBJ_BOTH_CALLBACK = 3;
        // cvCalcOpticalFlowXXX
        public const int CV_LKFLOW_PYR_A_READY = 1;
        public const int CV_LKFLOW_PYR_B_READY = 2;
        public const int CV_LKFLOW_INITIAL_GUESSES = 4;
        public const int OPTFLOW_USE_INITIAL_FLOW = 4;
        public const int CV_LKFLOW_GET_MIN_EIGENVALS = 8;
        // cvCalcPCA
        public const int CV_PCA_DATA_AS_ROW = 0;
        public const int CV_PCA_DATA_AS_COL = 1;
        public const int CV_PCA_USE_AVG = 2;
        // cvCanny
        public const int CV_SCHARR = -1;

        // cvCheckArr
        public const int CV_CHECK_RANGE = 1;
        public const int CV_CHECK_QUIET = 2;
        // cvConvertImage
        public const int CV_CVTIMG_FLIP = 1;
        public const int CV_CVTIMG_SWAP_RB = 2;

        // cvConvexHull2
        public const int CV_CLOCKWISE = 1;
        public const int CV_COUNTER_CLOCKWISE = 2;
        // cvCreateButton
        public const int CV_PUSH_BUTTON = 0;
        public const int CV_CHECKBOX = 1;
        public const int CV_RADIOBOX = 2;

        // cvCreateStereoBMState
        public const int CV_STEREO_BM_BASIC = 0;
        public const int CV_STEREO_BM_FISH_EYE = 1;
        public const int CV_STEREO_BM_NARROW = 2;
        // cvCreateStructuringElementEx
        public const int CV_SHAPE_CROSS = 1;
        public const int CV_SHAPE_CUSTOM = 100;
        public const int CV_SHAPE_ELLIPSE = 2;
        public const int CV_SHAPE_RECT = 0;

        // cvError
        public const int CV_StsOk = 0;	/* everithing is ok                */
        public const int CV_StsBackTrace = -1;	/* pseudo error for back trace     */
        public const int CV_StsError = -2;		/* unknown /unspecified error      */
        public const int CV_StsInternal = -3;	/* internal error (bad state)      */
        public const int CV_StsNoMem = -4;		/* insufficient memory             */
        public const int CV_StsBadArg = -5;		/* function arg_param is bad       */
        public const int CV_StsBadFunc = -6;		/* unsupported function            */
        public const int CV_StsNoConv = -7;		/* iter. didn't converge           */
        public const int CV_StsAutoTrace = -8;	/* tracing                         */

        public const int CV_HeaderIsNull = -9;	/* image header is NULL            */
        public const int CV_BadImageSize = -10;	/* image size is invalid           */
        public const int CV_BadOffset = -11;		/* offset is invalid               */
        public const int CV_BadDataPtr = -12;		/**/
        public const int CV_BadStep = -13;	/**/
        public const int CV_BadModelOrChSeq = -14; /**/
        public const int CV_BadNumChannels = -15;	/**/
        public const int CV_BadNumChannel1U = -16; /**/
        public const int CV_BadDepth = -17;		/**/
        public const int CV_BadAlphaChannel = -18; /**/
        public const int CV_BadOrder = -19;		/**/
        public const int CV_BadOrigin = -20;		/**/
        public const int CV_BadAlign = -21;		/**/
        public const int CV_BadCallBack = -22;		/**/
        public const int CV_BadTileSize = -23;		/**/
        public const int CV_BadCOI = -24;	/**/
        public const int CV_BadROISize = -25;		/**/

        public const int CV_MaskIsTiled = -26;		/**/

        public const int CV_StsNullPtr = -27;		/* null pointer */
        public const int CV_StsVecLengthErr = -28;	/* incorrect vector length */
        public const int CV_StsFilterStructContentErr = -29; /* incorr. filter structure content */
        public const int CV_StsKernelStructContentErr = -30; /* incorr. transform kernel content */
        public const int CV_StsFilterOffsetErr = -31;		/* incorrect filter ofset value */

        /*extra for CV */
        public const int CV_StsBadSize = -201;		/* the input/output structure size is incorrect  */
        public const int CV_StsDivByZero = -202;	/* division by zero */
        public const int CV_StsInplaceNotSupported = -203; /* inplace operation is not supported */
        public const int CV_StsObjectNotFound = -204;		/* request can't be completed */
        public const int CV_StsUnmatchedFormats = -205;	/* formats of input/output arrays differ */
        public const int CV_StsBadFlag = -206;		/* flag is wrong or not supported */
        public const int CV_StsBadPoint = -207;	/* bad CvPoint */
        public const int CV_StsBadMask = -208;		/* bad format of mask (neither 8uC1 nor 8sC1)*/
        public const int CV_StsUnmatchedSizes = -209;		/* sizes of input/output structures do not match */
        public const int CV_StsUnsupportedFormat = -210;	/* the data format/type is not supported by the function*/
        public const int CV_StsOutOfRange = -211;	/* some of parameters are out of range */
        public const int CV_StsParseError = -212;	/* invalid syntax/structure of the parsed file */
        public const int CV_StsNotImplemented = -213;		/* the requested function/feature is not implemented */
        public const int CV_StsBadMemBlock = -214;	/* an allocated block has been corrupted */

        // cvGet/SetErrMode
        public const int CV_ErrModeLeaf = 0;
        public const int CV_ErrModeParent = 1;
        public const int CV_ErrModeSilent = 2;

        // CV_FACE_ELEMENTS
        public const int CV_FACE_MOUTH = 0;
        public const int CV_FACE_LEFT_EYE = 1;
        public const int CV_FACE_RIGHT_EYE = 2;
        // CvFileNode
        public const int CV_NODE_NONE = 0;
        public const int CV_NODE_INT = 1;
        public const int CV_NODE_INTEGER = CV_NODE_INT;
        public const int CV_NODE_REAL = 2;
        public const int CV_NODE_FLOAT = CV_NODE_REAL;
        public const int CV_NODE_STR = 3;
        public const int CV_NODE_STRING = CV_NODE_STR;
        public const int CV_NODE_REF = 4;/* not used */
        public const int CV_NODE_SEQ = 5;
        public const int CV_NODE_MAP = 6;
        public const int CV_NODE_TYPE_MASK = 7;
        public const int CV_NODE_FLOW = 8; /* Used only for writing structures in YAML format. */
        public const int CV_NODE_USER = 16;
        public const int CV_NODE_EMPTY = 32;
        public const int CV_NODE_NAMED = 64;
        // cvFindChessboardCorners
        public const int CV_CALIB_CB_ADAPTIVE_THRESH = 1;
        public const int CV_CALIB_CB_NORMALIZE_IMAGE = 2;
        public const int CV_CALIB_CB_FILTER_QUADS = 4;
        // cvFindContours
        public const int CV_CHAIN_CODE = 0;
        public const int CV_CHAIN_APPROX_NONE = 1;
        public const int CV_CHAIN_APPROX_SIMPLE = 2;
        public const int CV_CHAIN_APPROX_TC89_L1 = 3;
        public const int CV_CHAIN_APPROX_TC89_KCOS = 4;
        public const int CV_LINK_RUNS = 5;
        public const int CV_RETR_EXTERNAL = 0,
            CV_RETR_LIST = 1,
            CV_RETR_CCOMP = 2,
            CV_RETR_TREE = 3,
            CV_RETR_FLOODFILL = 3;
        // cvFindDominantPoints
        public const int CV_DOMINANT_IPAN = 1;
        // cvFindFundamentalMat
        public const int CV_FM_7POINT = 1;
        public const int CV_FM_8POINT = 2;
        public const int CV_FM_LMEDS = 4;
        public const int CV_FM_LMEDS_ONLY = 4;
        public const int CV_FM_RANSAC = 8;
        public const int CV_FM_RANSAC_ONLY = 8;
        // cvFindHomography
        public const int CV_LMEDS = 4;
        public const int CV_RANSAC = 8;
        // cvFindStereoCorrespondence
        public const int CV_UNDEF_SC_PARAM = 12345;
        public const int CV_DISPARITY_BIRCHFIELD = 0;
        public const int CV_IDP_BIRCHFIELD_PARAM1 = 25;
        public const int CV_IDP_BIRCHFIELD_PARAM2 = 5;
        public const int CV_IDP_BIRCHFIELD_PARAM3 = 12;
        public const int CV_IDP_BIRCHFIELD_PARAM4 = 15;
        public const int CV_IDP_BIRCHFIELD_PARAM5 = 25;
        // cvFloodFill
        public const int CV_FLOODFILL_FIXED_RANGE = 65536;
        public const int CV_FLOODFILL_MASK_ONLY = 131072;
        // cvFontQt
        public const int CV_FONT_LIGHT = 25;//QFont::Light,
        public const int CV_FONT_NORMAL = 50;//QFont::Normal,
        public const int CV_FONT_DEMIBOLD = 63;//QFont::DemiBold,
        public const int CV_FONT_BOLD = 75;//QFont::Bold,
        public const int CV_FONT_BLACK = 87;//QFont::Black
        public const int CV_STYLE_NORMAL = 0;//QFont::StyleNormal,
        public const int CV_STYLE_ITALIC = 1;//QFont::StyleItalic,
        public const int CV_STYLE_OBLIQUE = 2;//QFont::StyleOblique
        // cvGEMM
        public const int CV_GEMM_A_T = 1;
        public const int CV_GEMM_B_T = 2;
        public const int CV_GEMM_C_T = 4;

        // CvHaarFeature
        public const int CV_HAAR_FEATURE_MAX = 3;
        // CvHistogram
        public const int CV_HIST_ARRAY = 0;
        public const int CV_HIST_SPARSE = 1;
        public const int CV_COMP_CHISQR = 1;
        public const int CV_COMP_CORREL = 0;
        public const int CV_COMP_INTERSECT = 2;
        public const int CV_COMP_BHATTACHARYYA = 3;
        // cvHoughCircles
        public const int CV_HOUGH_GRADIENT = 3;
        // cvHoughLines
        public const int CV_HOUGH_STANDARD = 0;
        public const int CV_HOUGH_PROBABILISTIC = 1;
        public const int CV_HOUGH_MULTI_SCALE = 2;

        // cvInpaint
        public const int CV_INPAINT_NS = 0;
        public const int CV_INPAINT_TELEA = 1;
        // cvInvert
        public const int CV_LU = 0;
        public const int CV_SVD = 1;
        public const int DECOMP_EIG = 2;
        public const int CV_SVD_SYM = 2;
        public const int CV_CHOLESKY = 3;
        public const int CV_QR = 4;
        public const int CV_NORMAL = 16;
        // cvKMeans2
        public const int KMEANS_RANDOM_CENTERS = 0;
        public const int KMEANS_USE_INITIAL_LABELS = 1;
        public const int KMEANS_PP_CENTERS = 2;     // Uses k-Means++ algorithm for initialization
        // cvMatchContourTrees
        public const int CV_CONTOUR_TREES_MATCH_I1 = 1;
        // cvMatchShapes
        public const int CV_CONTOURS_MATCH_I1 = 1;
        public const int CV_CONTOURS_MATCH_I2 = 2;
        public const int CV_CONTOURS_MATCH_I3 = 3;

        // cvMorphologyEx
        public const int CV_MOP_OPEN = 2;
        public const int CV_MOP_CLOSE = 3;
        public const int CV_MOP_GRADIENT = 4;
        public const int CV_MOP_TOPHAT = 5;
        public const int CV_MOP_BLACKHAT = 6;
        // cvMouseCallback
        public const int CV_EVENT_MOUSEMOVE = 0;
        public const int CV_EVENT_LBUTTONDOWN = 1;
        public const int CV_EVENT_RBUTTONDOWN = 2;
        public const int CV_EVENT_MBUTTONDOWN = 3;
        public const int CV_EVENT_LBUTTONUP = 4;
        public const int CV_EVENT_RBUTTONUP = 5;
        public const int CV_EVENT_MBUTTONUP = 6;
        public const int CV_EVENT_LBUTTONDBLCLK = 7;
        public const int CV_EVENT_RBUTTONDBLCLK = 8;
        public const int CV_EVENT_MBUTTONDBLCLK = 9;
        public const int CV_EVENT_FLAG_LBUTTON = 1;
        public const int CV_EVENT_FLAG_RBUTTON = 2;
        public const int CV_EVENT_FLAG_MBUTTON = 4;
        public const int CV_EVENT_FLAG_CTRLKEY = 8;
        public const int CV_EVENT_FLAG_SHIFTKEY = 16;
        public const int CV_EVENT_FLAG_ALTKEY = 32;

        // cvNamedWindow(only for Qt)
        public const int CV_GUI_EXPANDED = 0;
        public const int CV_GUI_NORMAL = 2;

        // cvNorm
        public const int CV_C = 1,
                         CV_L1 = 2,
                         CV_L2 = 4,
                         NORM_L2SQR = 5,
                         NORM_HAMMING = 6,
                         NORM_HAMMING2 = 7,
                         CV_NORM_MASK = 7,
                         CV_RELATIVE = 8,
                         CV_DIFF = 16,
                         CV_MINMAX = 32,
                         CV_DIFF_C = (CV_DIFF | CV_C),
                         CV_DIFF_L1 = (CV_DIFF | CV_L1),
                         CV_DIFF_L2 = (CV_DIFF | CV_L2),
                         CV_RELATIVE_C = (CV_RELATIVE | CV_C),
                         CV_RELATIVE_L1 = (CV_RELATIVE | CV_L1),
                         CV_RELATIVE_L2 = (CV_RELATIVE | CV_L2);
        // cvOpenFileStorage
        public const int CV_STORAGE_READ = 0;
        public const int CV_STORAGE_WRITE = 1;
        public const int CV_STORAGE_WRITE_TEXT = 1;
        public const int CV_STORAGE_WRITE_BINARY = 1;
        public const int CV_STORAGE_APPEND = 2;
        public const int CV_STORAGE_MEMORY = 4;
        public const int CV_STORAGE_FORMAT_MASK = (7 << 3);
        public const int CV_STORAGE_FORMAT_AUTO = 0;
        public const int CV_STORAGE_FORMAT_XML = 8;
        public const int CV_STORAGE_FORMAT_YAML = 16;
        // cvPyrDown, PyrUp, ...
        public const int CV_GAUSSIAN_5x5 = 7;
        // cvRandArr
        public const int CV_RAND_UNI = 0;
        public const int CV_RAND_NORMAL = 1;
        // cvReduce
        public const int CV_REDUCE_SUM = 0;
        public const int CV_REDUCE_AVG = 1;
        public const int CV_REDUCE_MAX = 2;
        public const int CV_REDUCE_MIN = 3;

        // cvSmooth
        public const int CV_BLUR_NO_SCALE = 0;
        public const int CV_BLUR = 1;
        public const int CV_GAUSSIAN = 2;
        public const int CV_MEDIAN = 3;
        public const int CV_BILATERAL = 4;
        // cvSnakeImage
        public const int CV_VALUE = 1;
        public const int CV_ARRAY = 2;
        // cvSort
        public const int CV_SORT_EVERY_ROW = 0;
        public const int CV_SORT_EVERY_COLUMN = 1;
        public const int CV_SORT_ASCENDING = 0;
        public const int CV_SORT_DESCENDING = 16;
        // cvStereoRectify
        public const int CV_CALIB_ZERO_DISPARITY = 1024;

        // cvSVD
        public const int CV_SVD_MODIFY_A = 1;
        public const int CV_SVD_U_T = 2;
        public const int CV_SVD_V_T = 4;
        // CvTermCriteria
        public const int CV_TERMCRIT_ITER = 1;
        public const int CV_TERMCRIT_NUMBER = 1;
        public const int CV_TERMCRIT_EPS = 2;
    }
}
