#ifndef _CPP_CALIB3D_STEREOMATCHER_H_
#define _CPP_CALIB3D_STEREOMATCHER_H_

#include "include_opencv.h"


CVAPI(void) calib3d_StereoMatcher_compute(
    cv::Ptr<cv::StereoMatcher> *obj, cv::_InputArray *left, cv::_InputArray *right, cv::_OutputArray *disparity)
{
    (*obj)->compute(*left, *right, *disparity);
}

CVAPI(int) calib3d_StereoMatcher_getMinDisparity(cv::Ptr<cv::StereoMatcher> *obj)
{
    return (*obj)->getMinDisparity();
}
CVAPI(void) calib3d_StereoMatcher_setMinDisparity(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
    (*obj)->setMinDisparity(value);
}

CVAPI(int) calib3d_StereoMatcher_getNumDisparities(cv::Ptr<cv::StereoMatcher> *obj)
{
    return (*obj)->getNumDisparities();
}
CVAPI(void) calib3d_StereoMatcher_setNumDisparities(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
    (*obj)->setNumDisparities(value);
}

CVAPI(int) calib3d_StereoMatcher_getBlockSize(cv::Ptr<cv::StereoMatcher> *obj)
{
    return (*obj)->getBlockSize();
}
CVAPI(void) calib3d_StereoMatcher_setBlockSize(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
    (*obj)->setBlockSize(value);
}

CVAPI(int) calib3d_StereoMatcher_getSpeckleWindowSize(cv::Ptr<cv::StereoMatcher> *obj)
{
    return (*obj)->getSpeckleWindowSize();
}
CVAPI(void) calib3d_StereoMatcher_setSpeckleWindowSize(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
    (*obj)->setSpeckleWindowSize(value);
}

CVAPI(int) calib3d_StereoMatcher_getSpeckleRange(cv::Ptr<cv::StereoMatcher> *obj)
{
    return (*obj)->getSpeckleRange();
}
CVAPI(void) calib3d_StereoMatcher_setSpeckleRange(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
    (*obj)->setSpeckleRange(value);
}

CVAPI(int) calib3d_StereoMatcher_getDisp12MaxDiff(cv::Ptr<cv::StereoMatcher> *obj)
{
    return (*obj)->getDisp12MaxDiff();
}
CVAPI(void) calib3d_StereoMatcher_setDisp12MaxDiff(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
    (*obj)->setDisp12MaxDiff(value);
}

#endif