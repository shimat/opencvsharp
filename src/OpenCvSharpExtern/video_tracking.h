#ifndef _CPP_VIDEO_TRACKING_H_
#define _CPP_VIDEO_TRACKING_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) video_CamShift(
    cv::_InputArray *probImage, MyCvRect *window, MyCvTermCriteria criteria, MyCvBox2D *returnValue)
{
    BEGIN_WRAP
    cv::Rect window0 = cpp(*window);
    const auto ret = cv::CamShift(*probImage, window0, cpp(criteria));
    *window = c(window0);
    *returnValue = c(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) video_meanShift(
    cv::_InputArray *probImage, MyCvRect *window, MyCvTermCriteria criteria, int *returnValue)
{
    BEGIN_WRAP
    cv::Rect window0 = cpp(*window);
    const auto ret = cv::meanShift(*probImage, window0, cpp(criteria));
    *window = c(window0);
    *returnValue = ret;
    END_WRAP
}

CVAPI(ExceptionStatus) video_buildOpticalFlowPyramid1(
    cv::_InputArray* img, cv::_OutputArray* pyramid,
    MyCvSize winSize, int maxLevel, int withDerivatives,
    int pyrBorder, int derivBorder, int tryReuseInputImage,
    int* returnValue)
{
    BEGIN_WRAP
    * returnValue = cv::buildOpticalFlowPyramid(
        *img, *pyramid, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) video_buildOpticalFlowPyramid2(
    cv::_InputArray* img, std::vector<cv::Mat>* pyramidVec,
    MyCvSize winSize, int maxLevel, int withDerivatives,
    int pyrBorder, int derivBorder, int tryReuseInputImage,
    int* returnValue)
{
    BEGIN_WRAP
    * returnValue = cv::buildOpticalFlowPyramid(
        *img, *pyramidVec, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) video_calcOpticalFlowPyrLK_InputArray(
    cv::_InputArray* prevImg, cv::_InputArray* nextImg,
    cv::_InputArray* prevPts, cv::_InputOutputArray* nextPts,
    cv::_OutputArray* status, cv::_OutputArray* err,
    MyCvSize winSize, int maxLevel, MyCvTermCriteria criteria,
    int flags, double minEigThreshold)
{
    BEGIN_WRAP
    cv::calcOpticalFlowPyrLK(*prevImg, *nextImg, *prevPts, *nextPts, *status, *err,
        cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
    END_WRAP
}

CVAPI(ExceptionStatus) video_calcOpticalFlowPyrLK_vector(
    cv::_InputArray* prevImg, cv::_InputArray* nextImg,
    cv::Point2f* prevPts, int prevPtsSize,
    std::vector<cv::Point2f>* nextPts,
    std::vector<uchar>* status,
    std::vector<float>* err,
    MyCvSize winSize, int maxLevel, MyCvTermCriteria criteria,
    int flags, double minEigThreshold)
{
    BEGIN_WRAP
    const std::vector<cv::Point2f> prevPtsVec(prevPts, prevPts + prevPtsSize);
    cv::calcOpticalFlowPyrLK(*prevImg, *nextImg, prevPtsVec, *nextPts,
    *status, *err, cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
    END_WRAP
}

CVAPI(ExceptionStatus) video_calcOpticalFlowFarneback(
    cv::_InputArray* prev, cv::_InputArray* next,
    cv::_InputOutputArray* flow, double pyrScale, int levels, int winSize,
    int iterations, int polyN, double polySigma, int flags)
{
    BEGIN_WRAP
    cv::calcOpticalFlowFarneback(*prev, *next, *flow, pyrScale, levels, winSize,
        iterations, polyN, polySigma, flags);
    END_WRAP
}

/* deprecated
CVAPI(ExceptionStatus) video_estimateRigidTransform(cv::_InputArray *src, cv::_InputArray *dst, int fullAffine, cv::Mat *returnValue)
{
    *returnValue = cv::estimateRigidTransform(*src, *dst, fullAffine != 0);
}
*/

CVAPI(ExceptionStatus) video_computeECC(cv::_InputArray *templateImage, cv::_InputArray *inputImage, cv::_InputArray *inputMask, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::computeECC(*templateImage, *inputImage, entity(inputMask));
    END_WRAP
}

CVAPI(ExceptionStatus) video_findTransformECC1(
    cv::_InputArray *templateImage, cv::_InputArray *inputImage,
    cv::_InputOutputArray *warpMatrix, int motionType,
    MyCvTermCriteria criteria,
    cv::_InputArray *inputMask, int gaussFiltSize, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findTransformECC(
        *templateImage, *inputImage, *warpMatrix, motionType, 
        cpp(criteria),entity(inputMask), gaussFiltSize);
    END_WRAP
}

CVAPI(ExceptionStatus) video_findTransformECC2(
    cv::_InputArray *templateImage, cv::_InputArray *inputImage,
    cv::_InputOutputArray *warpMatrix, int motionType,
    MyCvTermCriteria criteria, cv::_InputArray *inputMask, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findTransformECC(
        *templateImage, *inputImage, *warpMatrix, motionType,
        cpp(criteria), entity(inputMask));
    END_WRAP
}

#pragma region KalmanFilter

CVAPI(ExceptionStatus) video_KalmanFilter_new1(cv::KalmanFilter **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::KalmanFilter;
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams, int type, cv::KalmanFilter **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::KalmanFilter(dynamParams, measureParams, controlParams, type);
    END_WRAP
}

CVAPI(ExceptionStatus) video_KalmanFilter_init(cv::KalmanFilter *obj, int dynamParams, int measureParams, int controlParams, int type)
{
    BEGIN_WRAP
    obj->init(dynamParams, measureParams, controlParams, type);
    END_WRAP
}

CVAPI(ExceptionStatus) video_KalmanFilter_delete(cv::KalmanFilter *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) video_KalmanFilter_predict(cv::KalmanFilter *obj, cv::Mat *control, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto result = obj->predict(entity(control));
    *returnValue = new cv::Mat(result);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_correct(cv::KalmanFilter *obj, cv::Mat *measurement, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto result = obj->correct(*measurement);
    *returnValue = new cv::Mat(result);
    END_WRAP
}

CVAPI(ExceptionStatus) video_KalmanFilter_statePre(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->statePre);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_statePost(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->statePost);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_transitionMatrix(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->transitionMatrix);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_controlMatrix(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->controlMatrix);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_measurementMatrix(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->measurementMatrix);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_processNoiseCov(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->processNoiseCov);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_measurementNoiseCov(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->measurementNoiseCov);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_errorCovPre(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->errorCovPre);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_gain(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->gain);
    END_WRAP
}
CVAPI(ExceptionStatus) video_KalmanFilter_errorCovPost(cv::KalmanFilter *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = &(obj->errorCovPost);
    END_WRAP
}

#pragma endregion


// TODO
#pragma region DenseOpticalFlow

/*CVAPI(ExceptionStatus) video_DenseOpticalFlow_calc(
    cv::DenseOpticalFlow *obj,
    cv::_InputArray *i0, cv::_InputArray *i1, cv::_InputOutputArray *flow)
{
    BEGIN_WRAP
    obj->calc(*i0, *i1, *flow);
    END_WRAP
}

CVAPI(ExceptionStatus) video_DenseOpticalFlow_collectGarbage(cv::DenseOpticalFlow *obj)
{
    BEGIN_WRAP
    obj->collectGarbage();
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_DenseOpticalFlow_get(cv::Ptr<cv::DenseOpticalFlow> *ptr, cv::DenseOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_DenseOpticalFlow_delete(cv::Ptr<cv::DenseOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}
*/

#pragma endregion

#endif