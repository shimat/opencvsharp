#ifndef _CPP_OPTFLOW_MOTEMPL_H_
#define _CPP_OPTFLOW_MOTEMPL_H_

#include "include_opencv.h"
using namespace cv::motempl;

CVAPI(void) optflow_motempl_updateMotionHistory(
    cv::_InputArray *silhouette, cv::_InputOutputArray *mhi,
    double timestamp, double duration)
{
    updateMotionHistory(*silhouette, *mhi, timestamp, duration);
}

CVAPI(void) optflow_motempl_calcMotionGradient(
    cv::_InputArray *mhi, cv::_OutputArray *mask, cv::_OutputArray *orientation,
    double delta1, double delta2, int apertureSize)
{
    calcMotionGradient(*mhi, *mask, *orientation, delta1, delta2, apertureSize);
}

CVAPI(double) optflow_motempl_calcGlobalOrientation(
    cv::_InputArray *orientation, cv::_InputArray *mask,
    cv::_InputArray *mhi, double timestamp, double duration)
{
    return calcGlobalOrientation(*orientation, *mask, *mhi, timestamp, duration);
}

CVAPI(void) optflow_motempl_segmentMotion(
    cv::_InputArray *mhi, cv::_OutputArray *segmask,
    std::vector<cv::Rect> *boundingRects,
    double timestamp, double segThresh)
{
    segmentMotion(*mhi, *segmask, *boundingRects, timestamp, segThresh);
}

#endif
