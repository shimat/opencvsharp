// Additional types

#pragma once

#include "my_functions.h"

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
    struct MyCvPoint2D64f
    {
        double x;
        double y;
    };

    struct MyCvPoint3D32i
    {
        int x;
        int y;
        int z;
    };
    struct MyCvPoint3D32f
    {
        float x;
        float y;
        float z;
    };
    struct MyCvPoint3D64f
    {
        double x;
        double y;
        double z;
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
    struct MyCvSize2D64f
    {
        double width;
        double height;
    };

    struct MyCvRect
    {
        int x;
        int y;
        int width;
        int height;
    };
    struct MyCvRect2D32f
    {
        float x;
        float y;
        float width;
        float height;
    };
    struct MyCvRect2D64f
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

    struct MyKeyPoint
    {
        MyCvPoint2D32f pt;
        float size;
        float angle;
        float response;
        int octave;
        int class_id;
    };

    struct MyDMatch
    {
        int queryIdx;
        int trainIdx;
        int imgIdx;
        float distance;
    };

#pragma endregion

    struct CvPoint3D
    {
        int x;
        int y;
        int z;
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


    /** @brief Structure containing image keypoints and descriptors. */
    struct CV_EXPORTS_W_SIMPLE detail_ImageFeatures
    {
        int img_idx;
        MyCvSize img_size;
        std::vector<cv::KeyPoint>* keypoints;
        cv::Mat* descriptors;
    };

    /*
    struct line_descriptor_KeyLine
    {
        float angle;
        int class_id;
        int octave;
        MyCvPoint2D32f pt;
        float response;
        float size;
        float startPointX;
        float startPointY;
        float endPointX;
        float endPointY;
        float sPointInOctaveX;
        float sPointInOctaveY;
        float ePointInOctaveX;
        float ePointInOctaveY;
        float lineLength;
        int numOfPixels;
    };*/
}

static MyCvPoint c(const cv::Point p)
{
    const MyCvPoint ret = { p.x, p.y };
    return ret;
}
static cv::Point cpp(const MyCvPoint p)
{
    return cv::Point(p.x, p.y);
}

static MyCvPoint2D32f c(const cv::Point2f &p)
{
    return { p.x, p.y };
}
static cv::Point2f cpp(const MyCvPoint2D32f &p)
{
    return cv::Point2f(p.x, p.y);
}

static MyCvPoint2D64f c(const cv::Point2d &p)
{
    return { p.x, p.y };
}
static cv::Point2d cpp(const MyCvPoint2D64f &p)
{
    return cv::Point2d(p.x, p.y);
}

static MyCvPoint3D32i c(const cv::Point3i &p)
{
    return { p.x, p.y, p.z };
}
static cv::Point3i cpp(const MyCvPoint3D32i &p)
{
    return cv::Point3i(p.x, p.y, p.z);
}

static MyCvPoint3D64f c(const cv::Point3d &p)
{
    return { p.x, p.y, p.z };
}
static cv::Point3d cpp(const MyCvPoint3D64f &p)
{
    return cv::Point3d(p.x, p.y, p.z);
}

static MyCvSize c(const cv::Size &s)
{
    return { s.width, s.height };
}
static cv::Size cpp(const MyCvSize &s)
{
    return cv::Size(s.width, s.height);
}

static MyCvSize2D32f c(const cv::Size2f &s)
{
    return { s.width, s.height };
}
static cv::Size2f cpp(const MyCvSize2D32f &s)
{
    return cv::Size2f(s.width, s.height);
}

static MyCvSize2D64f c(const cv::Size2d &s)
{
    return { s.width, s.height };
}
static cv::Size2d cpp(const MyCvSize2D64f &s)
{
    return cv::Size2d(s.width, s.height);
}

static MyCvRect c(const cv::Rect &r)
{
    return { r.x, r.y, r.width, r.height };
}
static cv::Rect cpp(const MyCvRect &r)
{
    return cv::Rect(r.x, r.y, r.width, r.height);
}

static MyCvRect2D64f c(const cv::Rect2d &r)
{
    return { r.x, r.y, r.width, r.height };
}
static cv::Rect2d cpp(const MyCvRect2D64f &r)
{
    return cv::Rect2d(r.x, r.y, r.width, r.height);
}

static MyCvScalar c(const cv::Scalar &s)
{
    MyCvScalar ret{};
    ret.val[0] = s[0];
    ret.val[1] = s[1];
    ret.val[2] = s[2];
    ret.val[3] = s[3];
    return ret;
}
static cv::Scalar cpp(const MyCvScalar &s)
{
    return {s.val[0], s.val[1], s.val[2], s.val[3]};
}

static CvVec4i c(const cv::Vec4i &v)
{
    CvVec4i vv{};
    vv.val[0] = v.val[0];
    vv.val[1] = v.val[1];
    vv.val[2] = v.val[2];
    vv.val[3] = v.val[3];
    return vv;
}
static cv::Vec4i cpp(const CvVec4i &v)
{
    return cv::Vec4i(v.val[0], v.val[1], v.val[2], v.val[3]);
}

static MyCvSlice c(const cv::Range &s)
{
    const MyCvSlice ret{ s.start, s.end };
    return ret;
}
static cv::Range cpp(const MyCvSlice &s)
{
    return {s.start_index, s.end_index};
}

static MyCvMoments c(const cv::Moments &m)
{
    MyCvMoments ret;
    ret.m00 = m.m00; ret.m10 = m.m10; ret.m01 = m.m01;
    ret.m20 = m.m20; ret.m11 = m.m11; ret.m02 = m.m02;
    ret.m30 = m.m30; ret.m21 = m.m21; ret.m12 = m.m12; ret.m03 = m.m03;
    ret.mu20 = m.mu20; ret.mu11 = m.mu11; ret.mu02 = m.mu02;
    ret.mu30 = m.mu30; ret.mu21 = m.mu21; ret.mu12 = m.mu12; ret.mu03 = m.mu03;
    const double am00 = std::abs(m.m00);
    ret.inv_sqrt_m00 = am00 > DBL_EPSILON ? 1. / std::sqrt(am00) : 0;

    return ret;
}
static cv::Moments cpp(const MyCvMoments &m)
{
    return cv::Moments(m.m00, m.m10, m.m01, m.m20, m.m11, m.m02, m.m30, m.m21, m.m12, m.m03);
}

static MyCvTermCriteria c(const cv::TermCriteria &tc)
{
    return { tc.type, tc.maxCount, tc.epsilon };
}
static cv::TermCriteria cpp(const MyCvTermCriteria &tc)
{
    return cv::TermCriteria(tc.type, tc.max_iter, tc.epsilon);
}

static MyCvBox2D c(const cv::RotatedRect &r)
{
    return { c(r.center), c(r.size), r.angle };
}
static cv::RotatedRect cpp(const MyCvBox2D &b)
{
    return { cpp(b.center), cpp(b.size), b.angle };
}

static cv::KeyPoint cpp(const MyKeyPoint &k)
{
    return cv::KeyPoint(cpp(k.pt), k.size, k.angle, k.response, k.octave, k.class_id);
}
static MyKeyPoint c(const cv::KeyPoint &k)
{
    return { c(k.pt), k.size, k.angle, k.response, k.octave, k.class_id };
}

static cv::DMatch cpp(const MyDMatch &d)
{
    return cv::DMatch(d.queryIdx, d.trainIdx, d.imgIdx, d.distance);
}
static MyDMatch c(const cv::DMatch &d)
{
    return {d.queryIdx, d.trainIdx, d.imgIdx, d.distance };
}
