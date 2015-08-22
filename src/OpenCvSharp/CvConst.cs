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

        // cvCanny
        public const int CV_SCHARR = -1;

        // cvCheckArr
        public const int CV_CHECK_RANGE = 1;
        public const int CV_CHECK_QUIET = 2;

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

        // CV_FACE_ELEMENTS
        public const int CV_FACE_MOUTH = 0;
        public const int CV_FACE_LEFT_EYE = 1;
        public const int CV_FACE_RIGHT_EYE = 2;

        // cvFindChessboardCorners
        public const int CV_CALIB_CB_ADAPTIVE_THRESH = 1;
        public const int CV_CALIB_CB_NORMALIZE_IMAGE = 2;
        public const int CV_CALIB_CB_FILTER_QUADS = 4;

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

        // cvInvert
        public const int CV_LU = 0;
        public const int CV_SVD = 1;
        public const int DECOMP_EIG = 2;
        public const int CV_SVD_SYM = 2;
        public const int CV_CHOLESKY = 3;
        public const int CV_QR = 4;
        public const int CV_NORMAL = 16;
        // cvMatchContourTrees
        public const int CV_CONTOUR_TREES_MATCH_I1 = 1;
        // cvMatchShapes
        public const int CV_CONTOURS_MATCH_I1 = 1;
        public const int CV_CONTOURS_MATCH_I2 = 2;
        public const int CV_CONTOURS_MATCH_I3 = 3;

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

        // cvPyrDown, PyrUp, ...
        public const int CV_GAUSSIAN_5x5 = 7;
        // cvRandArr
        public const int CV_RAND_UNI = 0;
        public const int CV_RAND_NORMAL = 1;

        // cvStereoRectify
        public const int CV_CALIB_ZERO_DISPARITY = 1024;

        // cvSVD
        public const int CV_SVD_MODIFY_A = 1;
        public const int CV_SVD_U_T = 2;
        public const int CV_SVD_V_T = 4;

    }
}
