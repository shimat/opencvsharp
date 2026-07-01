#pragma once

#ifndef NO_VIDEO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) video_CamShift(
    const interop::InputArrayProxy* probImage,
    interop::Rect *window,
    interop::TermCriteria criteria,
    interop::RotatedRect *returnValue)
{
    return cvTry([&] {
    cv::Rect window0 = cpp(*window);
    const auto ret = cv::CamShift(InProxy(*probImage), window0, cpp(criteria));
    *window = c(window0);
    *returnValue = c(ret);
    });
}

CVAPI(ExceptionStatus) video_meanShift(
    const interop::InputArrayProxy* probImage,
    interop::Rect *window,
    interop::TermCriteria criteria,
    int *returnValue)
{
    return cvTry([&] {
    cv::Rect window0 = cpp(*window);
    const auto ret = cv::meanShift(InProxy(*probImage), window0, cpp(criteria));
    *window = c(window0);
    *returnValue = ret;
    });
}

CVAPI(ExceptionStatus) video_buildOpticalFlowPyramid1(
    const interop::InputArrayProxy* img,
    const interop::OutputArrayProxy* pyramid,
    interop::Size winSize,
    int maxLevel,
    int withDerivatives,
    int pyrBorder,
    int derivBorder,
    int tryReuseInputImage,
    int* returnValue)
{
    return cvTry([&] {
    * returnValue = cv::buildOpticalFlowPyramid(
        InProxy(*img), OutProxy(*pyramid), cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
    });
}
CVAPI(ExceptionStatus) video_buildOpticalFlowPyramid2(
    const interop::InputArrayProxy* img,
    std::vector<cv::Mat>* pyramidVec,
    interop::Size winSize,
    int maxLevel,
    int withDerivatives,
    int pyrBorder,
    int derivBorder,
    int tryReuseInputImage,
    int* returnValue)
{
    return cvTry([&] {
    * returnValue = cv::buildOpticalFlowPyramid(
        InProxy(*img), *pyramidVec, cpp(winSize), maxLevel, withDerivatives != 0,
        pyrBorder, derivBorder, tryReuseInputImage != 0);
    });
}

CVAPI(ExceptionStatus) video_calcOpticalFlowPyrLK_InputArray(
    const interop::InputArrayProxy* prevImg,
    const interop::InputArrayProxy* nextImg,
    const interop::InputArrayProxy* prevPts,
    const interop::InputOutputArrayProxy* nextPts,
    const interop::OutputArrayProxy* status,
    const interop::OutputArrayProxy* err,
    interop::Size winSize,
    int maxLevel,
    interop::TermCriteria criteria,
    int flags,
    double minEigThreshold)
{
    return cvTry([&] {
    cv::calcOpticalFlowPyrLK(InProxy(*prevImg), InProxy(*nextImg), InProxy(*prevPts), IoProxy(*nextPts), OutProxy(*status), OutProxy(*err),
        cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
    });
}

CVAPI(ExceptionStatus) video_calcOpticalFlowPyrLK_vector(
    const interop::InputArrayProxy* prevImg,
    const interop::InputArrayProxy* nextImg,
    cv::Point2f* prevPts,
    int prevPtsSize,
    std::vector<cv::Point2f>* nextPts,
    std::vector<uchar>* status,
    std::vector<float>* err,
    interop::Size winSize,
    int maxLevel,
    interop::TermCriteria criteria,
    int flags,
    double minEigThreshold)
{
    return cvTry([&] {
    const std::vector<cv::Point2f> prevPtsVec(prevPts, prevPts + prevPtsSize);
    cv::calcOpticalFlowPyrLK(InProxy(*prevImg), InProxy(*nextImg), prevPtsVec, *nextPts,
    *status, *err, cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
    });
}

CVAPI(ExceptionStatus) video_calcOpticalFlowFarneback(
    const interop::InputArrayProxy* prev,
    const interop::InputArrayProxy* next,
    const interop::InputOutputArrayProxy* flow,
    double pyrScale,
    int levels,
    int winSize,
    int iterations,
    int polyN,
    double polySigma,
    int flags)
{
    return cvTry([&] {
    cv::calcOpticalFlowFarneback(InProxy(*prev), InProxy(*next), IoProxy(*flow), pyrScale, levels, winSize,
        iterations, polyN, polySigma, flags);
    });
}

/* deprecated
CVAPI(ExceptionStatus) video_estimateRigidTransform(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    int fullAffine,
    cv::Mat *returnValue)
{
    *returnValue = cv::estimateRigidTransform(InProxy(*src), InProxy(*dst), fullAffine != 0);
}
*/

CVAPI(ExceptionStatus) video_computeECC(
    const interop::InputArrayProxy* templateImage,
    const interop::InputArrayProxy* inputImage,
    const interop::InputArrayProxy* inputMask,
    double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::computeECC(InProxy(*templateImage), InProxy(*inputImage), InProxy(*inputMask));
    });
}

CVAPI(ExceptionStatus) video_findTransformECC1(
    const interop::InputArrayProxy* templateImage,
    const interop::InputArrayProxy* inputImage,
    const interop::InputOutputArrayProxy* warpMatrix,
    int motionType,
    interop::TermCriteria criteria,
    const interop::InputArrayProxy* inputMask,
    int gaussFiltSize,
    double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::findTransformECC(
        InProxy(*templateImage), InProxy(*inputImage), IoProxy(*warpMatrix), motionType, 
        cpp(criteria),InProxy(*inputMask), gaussFiltSize);
    });
}

CVAPI(ExceptionStatus) video_findTransformECC2(
    const interop::InputArrayProxy* templateImage,
    const interop::InputArrayProxy* inputImage,
    const interop::InputOutputArrayProxy* warpMatrix,
    int motionType,
    interop::TermCriteria criteria,
    const interop::InputArrayProxy* inputMask,
    double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::findTransformECC(
        InProxy(*templateImage), InProxy(*inputImage), IoProxy(*warpMatrix), motionType,
        cpp(criteria), InProxy(*inputMask));
    });
}

#pragma region KalmanFilter

CVAPI(ExceptionStatus) video_KalmanFilter_new1(cv::KalmanFilter **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::KalmanFilter;
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_new2(
    int dynamParams,
    int measureParams,
    int controlParams,
    int type,
    cv::KalmanFilter **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::KalmanFilter(dynamParams, measureParams, controlParams, type);
    });
}

CVAPI(ExceptionStatus) video_KalmanFilter_init(
    cv::KalmanFilter *obj,
    int dynamParams,
    int measureParams,
    int controlParams,
    int type)
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

CVAPI(ExceptionStatus) video_KalmanFilter_predict(
    cv::KalmanFilter *obj,
    cv::Mat *control,
    cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto result = obj->predict(entity(control));
    *returnValue = new cv::Mat(result);
    });
}
CVAPI(ExceptionStatus) video_KalmanFilter_correct(
    cv::KalmanFilter *obj,
    cv::Mat *measurement,
    cv::Mat **returnValue)
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

CVAPI(ExceptionStatus) video_Tracker_init(
    cv::Tracker* tracker,
    const cv::Mat* image,
    const interop::Rect boundingBox)
{
    return cvTry([&] {
    tracker->init(*image, cpp(boundingBox));
    });
}

CVAPI(ExceptionStatus) video_Tracker_update(
    cv::Tracker* tracker,
    const cv::Mat* image,
    interop::Rect* boundingBox,
    int* returnValue)
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
    const interop::InputArrayProxy* i0,
    const interop::InputArrayProxy* i1,
    const interop::InputOutputArrayProxy* flow)
{
    return cvTry([&] {
    obj->calc(InProxy(*i0), InProxy(*i1), IoProxy(*flow));
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
