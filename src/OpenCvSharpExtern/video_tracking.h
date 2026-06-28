#pragma once

#ifndef NO_VIDEO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) video_CamShift(
    cv::_InputArray *probImage, interop::Rect *window, interop::TermCriteria criteria, interop::RotatedRect *returnValue)
{
    return cvTry([&] {
    cv::Rect window0 = cpp(*window);
    const auto ret = cv::CamShift(*probImage, window0, cpp(criteria));
    *window = c(window0);
    *returnValue = c(ret);
    });
}

CVAPI(ExceptionStatus) video_meanShift(
    cv::_InputArray *probImage, interop::Rect *window, interop::TermCriteria criteria, int *returnValue)
{
    return cvTry([&] {
    cv::Rect window0 = cpp(*window);
    const auto ret = cv::meanShift(*probImage, window0, cpp(criteria));
    *window = c(window0);
    *returnValue = ret;
    });
}

CVAPI(ExceptionStatus) video_buildOpticalFlowPyramid1(
    cv::_InputArray* img, cv::_OutputArray* pyramid,
    interop::Size winSize, int maxLevel, int withDerivatives,
    int pyrBorder, int derivBorder, int tryReuseInputImage,
    int* returnValue)
{
    return cvTry([&] {
    * returnValue = cv::buildOpticalFlowPyramid(
        *img, *pyramid, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
    });
}
CVAPI(ExceptionStatus) video_buildOpticalFlowPyramid2(
    cv::_InputArray* img, std::vector<cv::Mat>* pyramidVec,
    interop::Size winSize, int maxLevel, int withDerivatives,
    int pyrBorder, int derivBorder, int tryReuseInputImage,
    int* returnValue)
{
    return cvTry([&] {
    * returnValue = cv::buildOpticalFlowPyramid(
        *img, *pyramidVec, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
    });
}

CVAPI(ExceptionStatus) video_calcOpticalFlowPyrLK_InputArray(
    cv::_InputArray* prevImg, cv::_InputArray* nextImg,
    cv::_InputArray* prevPts, cv::_InputOutputArray* nextPts,
    cv::_OutputArray* status, cv::_OutputArray* err,
    interop::Size winSize, int maxLevel, interop::TermCriteria criteria,
    int flags, double minEigThreshold)
{
    return cvTry([&] {
    cv::calcOpticalFlowPyrLK(*prevImg, *nextImg, *prevPts, *nextPts, *status, *err,
        cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
    });
}

CVAPI(ExceptionStatus) video_calcOpticalFlowPyrLK_vector(
    cv::_InputArray* prevImg, cv::_InputArray* nextImg,
    cv::Point2f* prevPts, int prevPtsSize,
    std::vector<cv::Point2f>* nextPts,
    std::vector<uchar>* status,
    std::vector<float>* err,
    interop::Size winSize, int maxLevel, interop::TermCriteria criteria,
    int flags, double minEigThreshold)
{
    return cvTry([&] {
    const std::vector<cv::Point2f> prevPtsVec(prevPts, prevPts + prevPtsSize);
    cv::calcOpticalFlowPyrLK(*prevImg, *nextImg, prevPtsVec, *nextPts,
    *status, *err, cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
    });
}

CVAPI(ExceptionStatus) video_calcOpticalFlowFarneback(
    cv::_InputArray* prev, cv::_InputArray* next,
    cv::_InputOutputArray* flow, double pyrScale, int levels, int winSize,
    int iterations, int polyN, double polySigma, int flags)
{
    return cvTry([&] {
    cv::calcOpticalFlowFarneback(*prev, *next, *flow, pyrScale, levels, winSize,
        iterations, polyN, polySigma, flags);
    });
}

/* deprecated
CVAPI(ExceptionStatus) video_estimateRigidTransform(cv::_InputArray *src, cv::_InputArray *dst, int fullAffine, cv::Mat *returnValue)
{
    *returnValue = cv::estimateRigidTransform(*src, *dst, fullAffine != 0);
}
*/

CVAPI(ExceptionStatus) video_computeECC(cv::_InputArray *templateImage, cv::_InputArray *inputImage, cv::_InputArray *inputMask, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::computeECC(*templateImage, *inputImage, entity(inputMask));
    });
}

CVAPI(ExceptionStatus) video_findTransformECC1(
    cv::_InputArray *templateImage, cv::_InputArray *inputImage,
    cv::_InputOutputArray *warpMatrix, int motionType,
    interop::TermCriteria criteria,
    cv::_InputArray *inputMask, int gaussFiltSize, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::findTransformECC(
        *templateImage, *inputImage, *warpMatrix, motionType, 
        cpp(criteria),entity(inputMask), gaussFiltSize);
    });
}

CVAPI(ExceptionStatus) video_findTransformECC2(
    cv::_InputArray *templateImage, cv::_InputArray *inputImage,
    cv::_InputOutputArray *warpMatrix, int motionType,
    interop::TermCriteria criteria, cv::_InputArray *inputMask, double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::findTransformECC(
        *templateImage, *inputImage, *warpMatrix, motionType,
        cpp(criteria), entity(inputMask));
    });
}

#pragma region KalmanFilter

CVAPI(ExceptionStatus) video_KalmanFilter_new1(cv::KalmanFilter **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::KalmanFilter;
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams, int type, cv::KalmanFilter **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::KalmanFilter(dynamParams, measureParams, controlParams, type);
    });
}

CVAPI(ExceptionStatus) video_KalmanFilter_init(cv::KalmanFilter *obj, int dynamParams, int measureParams, int controlParams, int type)
{
    return cvTry([&] {
    obj->init(dynamParams, measureParams, controlParams, type);
    });
}

CVAPI(ExceptionStatus) video_KalmanFilter_delete(cv::KalmanFilter *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) video_KalmanFilter_predict(cv::KalmanFilter *obj, cv::Mat *control, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto result = obj->predict(entity(control));
    *returnValue = new cv::Mat(result);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_correct(cv::KalmanFilter *obj, cv::Mat *measurement, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto result = obj->correct(*measurement);
    *returnValue = new cv::Mat(result);
    });
}

CVAPI(ExceptionStatus) video_KalmanFilter_statePre(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->statePre);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_statePost(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->statePost);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_transitionMatrix(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->transitionMatrix);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_controlMatrix(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->controlMatrix);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_measurementMatrix(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->measurementMatrix);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_processNoiseCov(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->processNoiseCov);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_measurementNoiseCov(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->measurementNoiseCov);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_errorCovPre(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->errorCovPre);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_gain(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->gain);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_errorCovPost(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = &(obj->errorCovPost);
    });
}

#pragma endregion

#pragma region Tracker

CVAPI(ExceptionStatus) video_Tracker_init(cv::Tracker* tracker, const cv::Mat* image, const interop::Rect boundingBox)
{
    return cvTry([&] {
    tracker->init(*image, cpp(boundingBox));
    });
}

CVAPI(ExceptionStatus) video_Tracker_update(cv::Tracker* tracker, const cv::Mat* image, interop::Rect* boundingBox, int* returnValue)
{
    return cvTry([&] {
    cv::Rect bb = cpp(*boundingBox);
    const bool ret = tracker->update(*image, bb);
    if (ret)
    {
        boundingBox->x = bb.x;
        boundingBox->y = bb.y;
        boundingBox->width = bb.width;
        boundingBox->height = bb.height;
    }

    *returnValue = ret ? 1 : 0;
    });
}

#pragma endregion

#pragma region TrackerMIL

CVAPI(ExceptionStatus) video_TrackerMIL_create1(cv::Ptr<cv::TrackerMIL>** returnValue)
{
    return cvTry([&] {
    const auto p = cv::TrackerMIL::create();
    *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) video_TrackerMIL_create2(cv::TrackerMIL::Params* parameters, cv::Ptr<cv::TrackerMIL>** returnValue)
{
    return cvTry([&] {
    const auto p = cv::TrackerMIL::create(*parameters);
    *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) video_Ptr_TrackerMIL_delete(cv::Ptr<cv::TrackerMIL>* ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) video_Ptr_TrackerMIL_get(cv::Ptr<cv::TrackerMIL>* ptr, cv::TrackerMIL** returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#pragma endregion

// TODO
#pragma region DenseOpticalFlow

/*CVAPI(ExceptionStatus) video_DenseOpticalFlow_calc(
    cv::DenseOpticalFlow *obj,
    cv::_InputArray *i0, cv::_InputArray *i1, cv::_InputOutputArray *flow)
{
    return cvTry([&] {
    obj->calc(*i0, *i1, *flow);
    });
}

CVAPI(ExceptionStatus) video_DenseOpticalFlow_collectGarbage(cv::DenseOpticalFlow *obj)
{
    return cvTry([&] {
    obj->collectGarbage();
    });
}

CVAPI(ExceptionStatus) video_Ptr_DenseOpticalFlow_get(cv::Ptr<cv::DenseOpticalFlow> *ptr, cv::DenseOpticalFlow **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) video_Ptr_DenseOpticalFlow_delete(cv::Ptr<cv::DenseOpticalFlow> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}
*/

#pragma endregion

#endif // NO_VIDEO
