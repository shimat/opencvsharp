// Additional types

#ifndef _MY_TYPES_H_
#define _MY_TYPES_H_

typedef unsigned char uchar;
typedef unsigned short uint16;
typedef unsigned short ushort;
typedef unsigned int uint32;

namespace cv
{
    typedef cv::Vec<uchar, 6> Vec6b;
    typedef cv::Vec<short, 6> Vec6s;
    typedef cv::Vec<ushort, 6> Vec6w;
}

extern "C" 
{
    #pragma region OpenCV1.0-compatible Types

    struct MyCvPoint
    {
        int x;
        int y;
    };

    struct MyCvPoint2D32f
    {
        float x;
        float y;
    };

    struct MyCvSize
    {
        int width;
        int height;
    };

    struct MyCvSize2D32f
    {
        float width;
        float height;
    };

    struct MyCvRect
    {
        int x;
        int y;
        int width;
        int height;
    };

    struct MyCvRect2D
    {
        double x;
        double y;
        double width;
        double height;
    };

    struct MyCvScalar
    {
        double val[4];
    };

    struct MyCvSlice
    {
        int  start_index, end_index;
    };

    struct MyCvMoments
    {
        double  m00, m10, m01, m20, m11, m02, m30, m21, m12, m03; /* spatial moments */
        double  mu20, mu11, mu02, mu30, mu21, mu12, mu03; /* central moments */
        double  inv_sqrt_m00; /* m00 != 0 ? 1/sqrt(m00) : 0 */
    };

    struct MyCvTermCriteria
    {
        int    type;
        int    max_iter;
        double epsilon;
    };

    struct MyCvBox2D
    {
        MyCvPoint2D32f center; 
        MyCvSize2D32f  size;
        float angle;
    };

    #pragma endregion

    struct CvPoint3D
    {
        int x;
        int y;
        int z;
    };

    struct aruco_DetectorParameters 
    {
        int adaptiveThreshWinSizeMin;
        int adaptiveThreshWinSizeMax;
        int adaptiveThreshWinSizeStep;
        double adaptiveThreshConstant;
        double minMarkerPerimeterRate;
        double maxMarkerPerimeterRate;
        double polygonalApproxAccuracyRate;
        double minCornerDistanceRate;
        int minDistanceToBorder;
        double minMarkerDistanceRate;
        int doCornerRefinement; // bool
        int cornerRefinementWinSize;
        int cornerRefinementMaxIterations;
        double cornerRefinementMinAccuracy;
        int markerBorderBits;
        int perspectiveRemovePixelPerCell;
        double perspectiveRemoveIgnoredMarginPerCell;
        double maxErroneousBitsInBorderRate;
        double minOtsuStdDev;
        double errorCorrectionRate;
    };

    typedef struct CvVec2b { uchar val[2]; } CvVec2b;
    typedef struct CvVec3b { uchar val[3]; } CvVec3b;
    typedef struct CvVec4b { uchar val[4]; } CvVec4b;
    typedef struct CvVec6b { uchar val[6]; } CvVec6b;
    typedef struct CvVec2s { short val[2]; } CvVec2s;
    typedef struct CvVec3s { short val[3]; } CvVec3s;
    typedef struct CvVec4s { short val[4]; } CvVec4s;
    typedef struct CvVec6s { short val[6]; } CvVec6s;
    typedef struct CvVec2w { ushort val[2]; } CvVec2w;
    typedef struct CvVec3w { ushort val[3]; } CvVec3w;
    typedef struct CvVec4w { ushort val[4]; } CvVec4w;
    typedef struct CvVec6w { ushort val[6]; } CvVec6w;
    typedef struct CvVec2i { int val[2]; } CvVec2i;
    typedef struct CvVec3i { int val[3]; } CvVec3i;
    typedef struct CvVec4i { int val[4]; } CvVec4i;
    typedef struct CvVec6i { int val[6]; } CvVec6i;
    typedef struct CvVec2f { float val[2]; } CvVec2f;
    typedef struct CvVec3f { float val[3]; } CvVec3f;
    typedef struct CvVec4f { float val[4]; } CvVec4f;
    typedef struct CvVec6f { float val[6]; } CvVec6f;
    typedef struct CvVec2d { double val[2]; } CvVec2d;
    typedef struct CvVec3d { double val[3]; } CvVec3d;
    typedef struct CvVec4d { double val[4]; } CvVec4d;
    typedef struct CvVec6d { double val[6]; } CvVec6d;
}


static MyCvPoint c(cv::Point p)
{
    MyCvPoint ret = { p.x, p.y };
    return ret;
}
static cv::Point cpp(MyCvPoint p)
{
    return cv::Point(p.x, p.y);
}

static MyCvPoint2D32f c(cv::Point2f p)
{
    MyCvPoint2D32f ret = { p.x, p.y };
    return ret;
}
static cv::Point2f cpp(MyCvPoint2D32f p)
{
    return cv::Point2f(p.x, p.y);
}

static MyCvSize c(cv::Size s)
{
    MyCvSize ret = { s.width, s.height };
    return ret;
}
static cv::Size cpp(MyCvSize s)
{
    return cv::Size(s.width, s.height);
}

static MyCvSize2D32f c(cv::Size2f s)
{
    MyCvSize2D32f ret = { s.width, s.height };
    return ret;
}
static cv::Size2f cpp(MyCvSize2D32f s)
{
    return cv::Size2f(s.width, s.height);
}

static MyCvRect c(cv::Rect r)
{
    MyCvRect ret = { r.x, r.y, r.width, r.height };
    return ret;
}
static cv::Rect cpp(MyCvRect r)
{
    return cv::Rect(r.x, r.y, r.width, r.height);
}

static MyCvRect2D c(cv::Rect2d r)
{
    MyCvRect2D ret = { r.x, r.y, r.width, r.height };
    return ret;
}
static cv::Rect2d cpp(MyCvRect2D r)
{
    return cv::Rect2d(r.x, r.y, r.width, r.height);
}

static MyCvScalar c(cv::Scalar s)
{
    MyCvScalar ret;
    ret.val[0] = s[0];
    ret.val[1] = s[1];
    ret.val[2] = s[2];
    ret.val[3] = s[3];
    return ret;
}
static cv::Scalar cpp(MyCvScalar s)
{
    return cv::Scalar(s.val[0], s.val[1], s.val[2], s.val[3]);
}

static CvVec4i c(cv::Vec4i v)
{
    CvVec4i vv;
    vv.val[0] = v.val[0];
    vv.val[1] = v.val[1];
    vv.val[2] = v.val[2];
    vv.val[3] = v.val[3];
    return vv;
}
static cv::Vec4i cpp(CvVec4i v)
{
    return cv::Vec4i(v.val[0], v.val[1], v.val[2], v.val[3]);
}

static MyCvSlice c(cv::Range s)
{
    MyCvSlice ret;
    ret.start_index = s.start;
    ret.end_index = s.end;
    return ret;
}
static cv::Range cpp(MyCvSlice s)
{
    return cv::Range(s.start_index, s.end_index);
}

static MyCvMoments c(cv::Moments m)
{
    MyCvMoments ret;
    ret.m00 = m.m00; ret.m10 = m.m10; ret.m01 = m.m01;
    ret.m20 = m.m20; ret.m11 = m.m11; ret.m02 = m.m02;
    ret.m30 = m.m30; ret.m21 = m.m21; ret.m12 = m.m12; ret.m03 = m.m03;
    ret.mu20 = m.mu20; ret.mu11 = m.mu11; ret.mu02 = m.mu02;
    ret.mu30 = m.mu30; ret.mu21 = m.mu21; ret.mu12 = m.mu12; ret.mu03 = m.mu03;
    double am00 = std::abs(m.m00);
    ret.inv_sqrt_m00 = am00 > DBL_EPSILON ? 1. / std::sqrt(am00) : 0;

    return ret;
}
static cv::Moments cpp(MyCvMoments m)
{
    return cv::Moments(m.m00, m.m10, m.m01, m.m20, m.m11, m.m02, m.m30, m.m21, m.m12, m.m03);
}

static MyCvTermCriteria c(cv::TermCriteria tc)
{
    MyCvTermCriteria ret;
    ret.type = tc.type;
    ret.max_iter = tc.maxCount;
    ret.epsilon = tc.epsilon;
    return ret;
}
static cv::TermCriteria cpp(MyCvTermCriteria tc)
{
    return cv::TermCriteria(tc.type, tc.max_iter, tc.epsilon);
}

static MyCvBox2D c(cv::RotatedRect r)
{
    MyCvBox2D ret;
    ret.center = c(r.center);
    ret.size = c(r.size);
    ret.angle = r.angle;
    return ret;
}
static cv::RotatedRect cpp(MyCvBox2D b)
{
    return cv::RotatedRect(cpp(b.center), cpp(b.size), b.angle);
}

static cv::aruco::DetectorParameters cpp(aruco_DetectorParameters p)
{
    cv::aruco::DetectorParameters pp;
    pp.adaptiveThreshWinSizeMin = p.adaptiveThreshWinSizeMin;
    pp.adaptiveThreshWinSizeMax = p.adaptiveThreshWinSizeMax;
    pp.adaptiveThreshWinSizeStep = p.adaptiveThreshWinSizeStep;
    pp.adaptiveThreshConstant = p.adaptiveThreshConstant;
    pp.minMarkerPerimeterRate = p.minMarkerPerimeterRate;
    pp.maxMarkerPerimeterRate = p.maxMarkerPerimeterRate;
    pp.polygonalApproxAccuracyRate = p.polygonalApproxAccuracyRate;
    pp.minCornerDistanceRate = p.minCornerDistanceRate;
    pp.minDistanceToBorder = p.minDistanceToBorder;
    pp.minMarkerDistanceRate = p.minMarkerDistanceRate;
    pp.doCornerRefinement = p.doCornerRefinement != 0;
    pp.cornerRefinementWinSize = p.cornerRefinementWinSize;
    pp.cornerRefinementMaxIterations = p.cornerRefinementMaxIterations;
    pp.cornerRefinementMinAccuracy = p.cornerRefinementMinAccuracy;
    pp.markerBorderBits = p.markerBorderBits;
    pp.perspectiveRemovePixelPerCell = p.perspectiveRemovePixelPerCell;
    pp.perspectiveRemoveIgnoredMarginPerCell = p.perspectiveRemoveIgnoredMarginPerCell;;
    pp.maxErroneousBitsInBorderRate = p.maxErroneousBitsInBorderRate;
    pp.minOtsuStdDev = p.minOtsuStdDev;
    pp.errorCorrectionRate = p.errorCorrectionRate;
    return pp;
}
static aruco_DetectorParameters c(const cv::aruco::DetectorParameters &p)
{
    aruco_DetectorParameters pp;
    pp.adaptiveThreshWinSizeMin = p.adaptiveThreshWinSizeMin;
    pp.adaptiveThreshWinSizeMax = p.adaptiveThreshWinSizeMax;
    pp.adaptiveThreshWinSizeStep = p.adaptiveThreshWinSizeStep;
    pp.adaptiveThreshConstant = p.adaptiveThreshConstant;
    pp.minMarkerPerimeterRate = p.minMarkerPerimeterRate;
    pp.maxMarkerPerimeterRate = p.maxMarkerPerimeterRate;
    pp.polygonalApproxAccuracyRate = p.polygonalApproxAccuracyRate;
    pp.minCornerDistanceRate = p.minCornerDistanceRate;
    pp.minDistanceToBorder = p.minDistanceToBorder;
    pp.minMarkerDistanceRate = p.minMarkerDistanceRate;
    pp.doCornerRefinement = p.doCornerRefinement ? 1 : 0;
    pp.cornerRefinementWinSize = p.cornerRefinementWinSize;
    pp.cornerRefinementMaxIterations = p.cornerRefinementMaxIterations;
    pp.cornerRefinementMinAccuracy = p.cornerRefinementMinAccuracy;
    pp.markerBorderBits = p.markerBorderBits;
    pp.perspectiveRemovePixelPerCell = p.perspectiveRemovePixelPerCell;
    pp.perspectiveRemoveIgnoredMarginPerCell = p.perspectiveRemoveIgnoredMarginPerCell;;
    pp.maxErroneousBitsInBorderRate = p.maxErroneousBitsInBorderRate;
    pp.minOtsuStdDev = p.minOtsuStdDev;
    pp.errorCorrectionRate = p.errorCorrectionRate;
    return pp;
}

#endif