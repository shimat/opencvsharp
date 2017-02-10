#ifndef _CPP_XIMGPROC_FASTHOUGHTRANSFORM_H_
#define _CPP_XIMGPROC_FASTHOUGHTRANSFORM_H_

#include "include_opencv.h"

CVAPI(void) ximgproc_FastHoughTransform(cv::_InputArray *src, cv::_OutputArray *dst,
    int dstMatDepth, int angleRange, int op, int makeSkew)
{
    cv::ximgproc::FastHoughTransform(*src, *dst, dstMatDepth, angleRange, op, makeSkew);
}

CVAPI(CvVec4i) ximgproc_HoughPoint2Line(CvPoint houghPoint, cv::_InputArray *srcImgInfo,
    int angleRange, int makeSkew, int rules)
{
    return c(cv::ximgproc::HoughPoint2Line(houghPoint, *srcImgInfo, angleRange, makeSkew, rules));
}

#endif