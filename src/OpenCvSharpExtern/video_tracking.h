#ifndef _CPP_VIDEO_TRACKING_H_
#define _CPP_VIDEO_TRACKING_H_

#include "include_opencv.h"

CVAPI(MyCvBox2D) video_CamShift(
    cv::_InputArray *probImage, CvRect *window, CvTermCriteria criteria)
{
    cv::Rect window0 = *window;
    cv::RotatedRect ret = cv::CamShift(*probImage, window0, criteria);
    *window = window0;
    return c(ret);
}

CVAPI(int) video_meanShift(
    cv::_InputArray *probImage, CvRect *window, CvTermCriteria criteria)
{
    cv::Rect window0 = *window;
    int ret = cv::meanShift(*probImage, window0, criteria);
    *window = window0;
    return ret;
}

#pragma region KalmanFilter

CVAPI(cv::KalmanFilter*) video_KalmanFilter_new1()
{
    return new cv::KalmanFilter();
}
CVAPI(cv::KalmanFilter*) video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams, int type)
{
    return new cv::KalmanFilter(dynamParams, measureParams, controlParams, type);
}
CVAPI(void) video_KalmanFilter_init(cv::KalmanFilter *obj, int dynamParams, int measureParams, int controlParams, int type)
{
    obj->init(dynamParams, measureParams, controlParams, type);
}
CVAPI(void) video_KalmanFilter_delete(cv::KalmanFilter *obj)
{
    delete obj;
}

CVAPI(cv::Mat*) video_KalmanFilter_predict(cv::KalmanFilter *obj, cv::Mat *control)
{
    cv::Mat result = obj->predict(entity(control));
    return new cv::Mat(result);
}
CVAPI(cv::Mat*) video_KalmanFilter_correct(cv::KalmanFilter *obj, cv::Mat *measurement)
{
    cv::Mat result = obj->correct(*measurement);
    return new cv::Mat(result);
}

CVAPI(cv::Mat*) video_KalmanFilter_statePre(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->statePre);
}
CVAPI(cv::Mat*) video_KalmanFilter_statePost(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->statePost);
}
CVAPI(cv::Mat*) video_KalmanFilter_transitionMatrix(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->transitionMatrix);
}
CVAPI(cv::Mat*) video_KalmanFilter_controlMatrix(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->controlMatrix);
}
CVAPI(cv::Mat*) video_KalmanFilter_measurementMatrix(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->measurementMatrix);
}
CVAPI(cv::Mat*) video_KalmanFilter_processNoiseCov(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->processNoiseCov);
}
CVAPI(cv::Mat*) video_KalmanFilter_measurementNoiseCov(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->measurementNoiseCov);
}
CVAPI(cv::Mat*) video_KalmanFilter_errorCovPre(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->errorCovPre);
}
CVAPI(cv::Mat*) video_KalmanFilter_gain(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->gain);
}
CVAPI(cv::Mat*) video_KalmanFilter_errorCovPost(cv::KalmanFilter *obj)
{
    return new cv::Mat(obj->errorCovPost);
}
#pragma endregion

CVAPI(int) video_buildOpticalFlowPyramid1(
    cv::_InputArray *img, cv::_OutputArray *pyramid,
    MyCvSize winSize, int maxLevel, int withDerivatives,
    int pyrBorder, int derivBorder, int tryReuseInputImage)
{
    return cv::buildOpticalFlowPyramid(
        *img, *pyramid, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
}
CVAPI(int) video_buildOpticalFlowPyramid2(
    cv::_InputArray *img, std::vector<cv::Mat> *pyramidVec,
    MyCvSize winSize, int maxLevel, int withDerivatives,
    int pyrBorder, int derivBorder, int tryReuseInputImage)
{
    return cv::buildOpticalFlowPyramid(
        *img, *pyramidVec, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
}

CVAPI(void) video_calcOpticalFlowPyrLK_InputArray(
    cv::_InputArray *prevImg, cv::_InputArray *nextImg,
    cv::_InputArray *prevPts, cv::_InputOutputArray *nextPts,
    cv::_OutputArray *status, cv::_OutputArray *err,
    MyCvSize winSize, int maxLevel, MyCvTermCriteria criteria,
    int flags, double minEigThreshold)
{
    cv::calcOpticalFlowPyrLK(*prevImg, *nextImg, *prevPts, *nextPts, *status, *err,
        cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
}

CVAPI(void) video_calcOpticalFlowPyrLK_vector(
    cv::_InputArray *prevImg, cv::_InputArray *nextImg,
    cv::Point2f *prevPts, int prevPtsSize,
    std::vector<cv::Point2f> *nextPts,
    std::vector<uchar> *status,
    std::vector<float> *err,
    CvSize winSize, int maxLevel, CvTermCriteria criteria,
    int flags, double minEigThreshold)
{
    std::vector<cv::Point2f> prevPtsVec(prevPts, prevPts + prevPtsSize);
    cv::calcOpticalFlowPyrLK(*prevImg, *nextImg, prevPtsVec, *nextPts,
        *status, *err, winSize, maxLevel, criteria, flags, minEigThreshold);
}

CVAPI(void) video_calcOpticalFlowFarneback(
    cv::_InputArray *prev, cv::_InputArray *next,
    cv::_InputOutputArray *flow, double pyrScale, int levels, int winSize,
    int iterations, int polyN, double polySigma, int flags)
{
    cv::calcOpticalFlowFarneback(*prev, *next, *flow, pyrScale, levels, winSize,
        iterations, polyN, polySigma, flags);
}

CVAPI(cv::Mat*) video_estimateRigidTransform(
    cv::_InputArray *src, cv::_InputArray *dst, int fullAffine)
{
    cv::Mat ret = cv::estimateRigidTransform(*src, *dst, fullAffine != 0);
    return new cv::Mat(ret);
}

#pragma region DenseOpticalFlow

CVAPI(void) video_DenseOpticalFlow_calc(
    cv::DenseOpticalFlow *obj,
    cv::_InputArray *i0, cv::_InputArray *i1, cv::_InputOutputArray *flow)
{
    obj->calc(*i0, *i1, *flow);
}
CVAPI(void) video_DenseOpticalFlow_collectGarbage(cv::DenseOpticalFlow *obj)
{
    obj->collectGarbage();
}

CVAPI(cv::Ptr<cv::DualTVL1OpticalFlow>*) video_createOptFlow_DualTVL1()
{
    return clone(cv::createOptFlow_DualTVL1());
}

CVAPI(cv::DenseOpticalFlow*) video_Ptr_DenseOpticalFlow_get(cv::Ptr<cv::DenseOpticalFlow> *ptr)
{
    return ptr->get();
}
CVAPI(void) video_Ptr_DenseOpticalFlow_delete(cv::Ptr<cv::DenseOpticalFlow> *ptr)
{
    delete ptr;
}

#pragma endregion

#endif