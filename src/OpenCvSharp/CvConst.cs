using System;

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
        // cvApproxPoly
        public const int CV_POLY_APPROX_DP = 0;

        // cvCalcCoverMatrixEx, cvCalcEigenObjects, ...
        public const int CV_EIGOBJ_NO_CALLBACK = 0;
        public const int CV_EIGOBJ_INPUT_CALLBACK = 1;
        public const int CV_EIGOBJ_OUTPUT_CALLBACK = 2;
        public const int CV_EIGOBJ_BOTH_CALLBACK = 3;

        // cvCanny
        public const int CV_SCHARR = -1;

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

        // CvHistogram
        public const int CV_HIST_ARRAY = 0;
        public const int CV_HIST_SPARSE = 1;
        public const int CV_COMP_CHISQR = 1;
        public const int CV_COMP_CORREL = 0;
        public const int CV_COMP_INTERSECT = 2;
        public const int CV_COMP_BHATTACHARYYA = 3;

        // cvMatchContourTrees
        public const int CV_CONTOUR_TREES_MATCH_I1 = 1;

        // cvStereoRectify
        public const int CV_CALIB_ZERO_DISPARITY = 1024;
    }
}
