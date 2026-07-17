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

CVAPI(ExceptionStatus) video_findTransformECCWithMask(
    const interop::InputArrayProxy* templateImage,
    const interop::InputArrayProxy* inputImage,
    const interop::InputArrayProxy* templateMask,
    const interop::InputArrayProxy* inputMask,
    const interop::InputOutputArrayProxy* warpMatrix,
    int motionType,
    interop::TermCriteria criteria,
    int gaussFiltSize,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::findTransformECCWithMask(
            InProxy(*templateImage), InProxy(*inputImage), InProxy(*templateMask), InProxy(*inputMask),
            IoProxy(*warpMatrix), motionType, cpp(criteria), gaussFiltSize);
    });
}

// Mirrors OpenCvSharp.Internal.CvECCParameters (the scalar/POD fields of cv::ECCParameters;
// itersPerLevel is a std::vector<int> passed as its own argument).
CV_EXTERN_C struct video_ECCParameters
{
    int motionType;
    interop::TermCriteria criteria;
    int gaussFiltSize;
    int nlevels;
    int interpolation;
};

CVAPI(ExceptionStatus) video_findTransformECCMultiScale(
    const interop::InputArrayProxy* reference,
    const interop::InputArrayProxy* sample,
    const interop::InputOutputArrayProxy* warpMatrix,
    const video_ECCParameters* eccParameters,
    const std::vector<int>* itersPerLevel,
    const interop::InputArrayProxy* referenceMask,
    const interop::InputArrayProxy* sampleMask,
    double* returnValue)
{
    return cvTry([&] {
        cv::ECCParameters eccParams;
        eccParams.motionType = eccParameters->motionType;
        eccParams.criteria = cpp(eccParameters->criteria);
        eccParams.itersPerLevel = *itersPerLevel;
        eccParams.gaussFiltSize = eccParameters->gaussFiltSize;
        eccParams.nlevels = eccParameters->nlevels;
        eccParams.interpolation = eccParameters->interpolation;
        *returnValue = cv::findTransformECCMultiScale(
            InProxy(*reference), InProxy(*sample), IoProxy(*warpMatrix), eccParams,
            InProxy(*referenceMask), InProxy(*sampleMask));
    });
}

CVAPI(ExceptionStatus) video_readOpticalFlow(const char* path, cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto result = cv::readOpticalFlow(path);
        *returnValue = new cv::Mat(result);
    });
}

CVAPI(ExceptionStatus) video_writeOpticalFlow(const char* path, const interop::InputArrayProxy* flow, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::writeOpticalFlow(path, InProxy(*flow)) ? 1 : 0;
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

CVAPI(ExceptionStatus) video_Tracker_getTrackingScore(cv::Tracker* tracker, float* returnValue)
{
    return cvTry([&] {
        *returnValue = tracker->getTrackingScore();
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

#pragma region DenseOpticalFlow

CVAPI(ExceptionStatus) video_DenseOpticalFlow_calc(
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

#pragma endregion

#pragma region SparseOpticalFlow

CVAPI(ExceptionStatus) video_SparseOpticalFlow_calc(
    cv::SparseOpticalFlow *obj,
    const interop::InputArrayProxy* prevImg,
    const interop::InputArrayProxy* nextImg,
    const interop::InputArrayProxy* prevPts,
    const interop::InputOutputArrayProxy* nextPts,
    const interop::OutputArrayProxy* status,
    const interop::OutputArrayProxy* err)
{
    return cvTry([&] {
        obj->calc(InProxy(*prevImg), InProxy(*nextImg), InProxy(*prevPts), IoProxy(*nextPts), OutProxy(*status), OutProxy(*err));
    });
}

CVAPI(ExceptionStatus) video_Ptr_SparseOpticalFlow_get(cv::Ptr<cv::SparseOpticalFlow> *ptr, cv::SparseOpticalFlow **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) video_Ptr_SparseOpticalFlow_delete(cv::Ptr<cv::SparseOpticalFlow> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

#pragma endregion

#pragma region FarnebackOpticalFlow

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_create(
    int numLevels, double pyrScale, int fastPyramids, int winSize, int numIters,
    int polyN, double polySigma, int flags,
    cv::Ptr<cv::FarnebackOpticalFlow>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::FarnebackOpticalFlow::create(
            numLevels, pyrScale, fastPyramids != 0, winSize, numIters, polyN, polySigma, flags);
        *returnValue = clone(p);
    });
}
CVAPI(ExceptionStatus) video_Ptr_FarnebackOpticalFlow_get(cv::Ptr<cv::FarnebackOpticalFlow>* ptr, cv::FarnebackOpticalFlow** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_FarnebackOpticalFlow_delete(cv::Ptr<cv::FarnebackOpticalFlow>* ptr)
{ return cvTry([&] { delete ptr; }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getNumLevels(cv::FarnebackOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getNumLevels(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setNumLevels(cv::FarnebackOpticalFlow* obj, int value) { return cvTry([&] { obj->setNumLevels(value); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getPyrScale(cv::FarnebackOpticalFlow* obj, double* returnValue) { return cvTry([&] { *returnValue = obj->getPyrScale(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setPyrScale(cv::FarnebackOpticalFlow* obj, double value) { return cvTry([&] { obj->setPyrScale(value); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getFastPyramids(cv::FarnebackOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getFastPyramids() ? 1 : 0; }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setFastPyramids(cv::FarnebackOpticalFlow* obj, int value) { return cvTry([&] { obj->setFastPyramids(value != 0); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getWinSize(cv::FarnebackOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getWinSize(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setWinSize(cv::FarnebackOpticalFlow* obj, int value) { return cvTry([&] { obj->setWinSize(value); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getNumIters(cv::FarnebackOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getNumIters(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setNumIters(cv::FarnebackOpticalFlow* obj, int value) { return cvTry([&] { obj->setNumIters(value); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getPolyN(cv::FarnebackOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getPolyN(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setPolyN(cv::FarnebackOpticalFlow* obj, int value) { return cvTry([&] { obj->setPolyN(value); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getPolySigma(cv::FarnebackOpticalFlow* obj, double* returnValue) { return cvTry([&] { *returnValue = obj->getPolySigma(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setPolySigma(cv::FarnebackOpticalFlow* obj, double value) { return cvTry([&] { obj->setPolySigma(value); }); }

CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_getFlags(cv::FarnebackOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getFlags(); }); }
CVAPI(ExceptionStatus) video_FarnebackOpticalFlow_setFlags(cv::FarnebackOpticalFlow* obj, int value) { return cvTry([&] { obj->setFlags(value); }); }

#pragma endregion

#pragma region VariationalRefinement

CVAPI(ExceptionStatus) video_VariationalRefinement_create(cv::Ptr<cv::VariationalRefinement>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::VariationalRefinement::create();
        *returnValue = clone(p);
    });
}
CVAPI(ExceptionStatus) video_Ptr_VariationalRefinement_get(cv::Ptr<cv::VariationalRefinement>* ptr, cv::VariationalRefinement** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_VariationalRefinement_delete(cv::Ptr<cv::VariationalRefinement>* ptr)
{ return cvTry([&] { delete ptr; }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_calcUV(
    cv::VariationalRefinement* obj,
    const interop::InputArrayProxy* i0,
    const interop::InputArrayProxy* i1,
    const interop::InputOutputArrayProxy* flowU,
    const interop::InputOutputArrayProxy* flowV)
{
    return cvTry([&] {
        obj->calcUV(InProxy(*i0), InProxy(*i1), IoProxy(*flowU), IoProxy(*flowV));
    });
}

CVAPI(ExceptionStatus) video_VariationalRefinement_getFixedPointIterations(cv::VariationalRefinement* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getFixedPointIterations(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setFixedPointIterations(cv::VariationalRefinement* obj, int value) { return cvTry([&] { obj->setFixedPointIterations(value); }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_getSorIterations(cv::VariationalRefinement* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getSorIterations(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setSorIterations(cv::VariationalRefinement* obj, int value) { return cvTry([&] { obj->setSorIterations(value); }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_getOmega(cv::VariationalRefinement* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getOmega(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setOmega(cv::VariationalRefinement* obj, float value) { return cvTry([&] { obj->setOmega(value); }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_getAlpha(cv::VariationalRefinement* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getAlpha(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setAlpha(cv::VariationalRefinement* obj, float value) { return cvTry([&] { obj->setAlpha(value); }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_getDelta(cv::VariationalRefinement* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getDelta(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setDelta(cv::VariationalRefinement* obj, float value) { return cvTry([&] { obj->setDelta(value); }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_getGamma(cv::VariationalRefinement* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getGamma(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setGamma(cv::VariationalRefinement* obj, float value) { return cvTry([&] { obj->setGamma(value); }); }

CVAPI(ExceptionStatus) video_VariationalRefinement_getEpsilon(cv::VariationalRefinement* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getEpsilon(); }); }
CVAPI(ExceptionStatus) video_VariationalRefinement_setEpsilon(cv::VariationalRefinement* obj, float value) { return cvTry([&] { obj->setEpsilon(value); }); }

#pragma endregion

#pragma region DISOpticalFlow

CVAPI(ExceptionStatus) video_DISOpticalFlow_create(int preset, cv::Ptr<cv::DISOpticalFlow>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::DISOpticalFlow::create(preset);
        *returnValue = clone(p);
    });
}
CVAPI(ExceptionStatus) video_Ptr_DISOpticalFlow_get(cv::Ptr<cv::DISOpticalFlow>* ptr, cv::DISOpticalFlow** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_DISOpticalFlow_delete(cv::Ptr<cv::DISOpticalFlow>* ptr)
{ return cvTry([&] { delete ptr; }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getFinestScale(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getFinestScale(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setFinestScale(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setFinestScale(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getCoarsestScale(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getCoarsestScale(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setCoarsestScale(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setCoarsestScale(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getPatchSize(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getPatchSize(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setPatchSize(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setPatchSize(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getPatchStride(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getPatchStride(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setPatchStride(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setPatchStride(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getGradientDescentIterations(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getGradientDescentIterations(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setGradientDescentIterations(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setGradientDescentIterations(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getVariationalRefinementIterations(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getVariationalRefinementIterations(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setVariationalRefinementIterations(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setVariationalRefinementIterations(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getVariationalRefinementAlpha(cv::DISOpticalFlow* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getVariationalRefinementAlpha(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setVariationalRefinementAlpha(cv::DISOpticalFlow* obj, float value) { return cvTry([&] { obj->setVariationalRefinementAlpha(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getVariationalRefinementDelta(cv::DISOpticalFlow* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getVariationalRefinementDelta(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setVariationalRefinementDelta(cv::DISOpticalFlow* obj, float value) { return cvTry([&] { obj->setVariationalRefinementDelta(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getVariationalRefinementGamma(cv::DISOpticalFlow* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getVariationalRefinementGamma(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setVariationalRefinementGamma(cv::DISOpticalFlow* obj, float value) { return cvTry([&] { obj->setVariationalRefinementGamma(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getVariationalRefinementEpsilon(cv::DISOpticalFlow* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getVariationalRefinementEpsilon(); }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setVariationalRefinementEpsilon(cv::DISOpticalFlow* obj, float value) { return cvTry([&] { obj->setVariationalRefinementEpsilon(value); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getUseMeanNormalization(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getUseMeanNormalization() ? 1 : 0; }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setUseMeanNormalization(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setUseMeanNormalization(value != 0); }); }

CVAPI(ExceptionStatus) video_DISOpticalFlow_getUseSpatialPropagation(cv::DISOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getUseSpatialPropagation() ? 1 : 0; }); }
CVAPI(ExceptionStatus) video_DISOpticalFlow_setUseSpatialPropagation(cv::DISOpticalFlow* obj, int value) { return cvTry([&] { obj->setUseSpatialPropagation(value != 0); }); }

#pragma endregion

#pragma region SparsePyrLKOpticalFlow

CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_create(
    interop::Size winSize, int maxLevel, interop::TermCriteria criteria, int flags, double minEigThreshold,
    cv::Ptr<cv::SparsePyrLKOpticalFlow>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::SparsePyrLKOpticalFlow::create(cpp(winSize), maxLevel, cpp(criteria), flags, minEigThreshold);
        *returnValue = clone(p);
    });
}
CVAPI(ExceptionStatus) video_Ptr_SparsePyrLKOpticalFlow_get(cv::Ptr<cv::SparsePyrLKOpticalFlow>* ptr, cv::SparsePyrLKOpticalFlow** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_SparsePyrLKOpticalFlow_delete(cv::Ptr<cv::SparsePyrLKOpticalFlow>* ptr)
{ return cvTry([&] { delete ptr; }); }

CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_getWinSize(cv::SparsePyrLKOpticalFlow* obj, interop::Size* returnValue) { return cvTry([&] { *returnValue = c(obj->getWinSize()); }); }
CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_setWinSize(cv::SparsePyrLKOpticalFlow* obj, interop::Size value) { return cvTry([&] { obj->setWinSize(cpp(value)); }); }

CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_getMaxLevel(cv::SparsePyrLKOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getMaxLevel(); }); }
CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_setMaxLevel(cv::SparsePyrLKOpticalFlow* obj, int value) { return cvTry([&] { obj->setMaxLevel(value); }); }

CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_getTermCriteria(cv::SparsePyrLKOpticalFlow* obj, interop::TermCriteria* returnValue) { return cvTry([&] { *returnValue = c(obj->getTermCriteria()); }); }
CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_setTermCriteria(cv::SparsePyrLKOpticalFlow* obj, interop::TermCriteria value) { return cvTry([&] { auto v = cpp(value); obj->setTermCriteria(v); }); }

CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_getFlags(cv::SparsePyrLKOpticalFlow* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getFlags(); }); }
CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_setFlags(cv::SparsePyrLKOpticalFlow* obj, int value) { return cvTry([&] { obj->setFlags(value); }); }

CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_getMinEigThreshold(cv::SparsePyrLKOpticalFlow* obj, double* returnValue) { return cvTry([&] { *returnValue = obj->getMinEigThreshold(); }); }
CVAPI(ExceptionStatus) video_SparsePyrLKOpticalFlow_setMinEigThreshold(cv::SparsePyrLKOpticalFlow* obj, double value) { return cvTry([&] { obj->setMinEigThreshold(value); }); }

#pragma endregion

#pragma region TrackerDaSiamRPN

CV_EXTERN_C struct video_TrackerDaSiamRPN_Params
{
    char* model;
    char* kernel_cls1;
    char* kernel_r1;
    int backend;
    int target;
};

CVAPI(ExceptionStatus) video_TrackerDaSiamRPN_create(video_TrackerDaSiamRPN_Params* p, cv::Ptr<cv::TrackerDaSiamRPN>** returnValue)
{
    return cvTry([&] {
        cv::TrackerDaSiamRPN::Params params;
        params.model = std::string(p->model);
        params.kernel_cls1 = std::string(p->kernel_cls1);
        params.kernel_r1 = std::string(p->kernel_r1);
        params.backend = p->backend;
        params.target = p->target;
        const auto obj = cv::TrackerDaSiamRPN::create(params);
        *returnValue = clone(obj);
    });
}
CVAPI(ExceptionStatus) video_Ptr_TrackerDaSiamRPN_get(cv::Ptr<cv::TrackerDaSiamRPN>* ptr, cv::TrackerDaSiamRPN** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_TrackerDaSiamRPN_delete(cv::Ptr<cv::TrackerDaSiamRPN>* ptr)
{ return cvTry([&] { delete ptr; }); }

#pragma endregion

#pragma region TrackerNano

CV_EXTERN_C struct video_TrackerNano_Params
{
    char* backbone;
    char* neckhead;
    int backend;
    int target;
};

CVAPI(ExceptionStatus) video_TrackerNano_create(video_TrackerNano_Params* p, cv::Ptr<cv::TrackerNano>** returnValue)
{
    return cvTry([&] {
        cv::TrackerNano::Params params;
        params.backbone = std::string(p->backbone);
        params.neckhead = std::string(p->neckhead);
        params.backend = p->backend;
        params.target = p->target;
        const auto obj = cv::TrackerNano::create(params);
        *returnValue = clone(obj);
    });
}
CVAPI(ExceptionStatus) video_Ptr_TrackerNano_get(cv::Ptr<cv::TrackerNano>* ptr, cv::TrackerNano** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_TrackerNano_delete(cv::Ptr<cv::TrackerNano>* ptr)
{ return cvTry([&] { delete ptr; }); }

#pragma endregion

#pragma region TrackerVit

CV_EXTERN_C struct video_TrackerVit_Params
{
    char* net;
    int backend;
    int target;
    interop::Scalar meanvalue;
    interop::Scalar stdvalue;
    float tracking_score_threshold;
};

CVAPI(ExceptionStatus) video_TrackerVit_create(video_TrackerVit_Params* p, cv::Ptr<cv::TrackerVit>** returnValue)
{
    return cvTry([&] {
        cv::TrackerVit::Params params;
        params.net = std::string(p->net);
        params.backend = p->backend;
        params.target = p->target;
        params.meanvalue = cpp(p->meanvalue);
        params.stdvalue = cpp(p->stdvalue);
        params.tracking_score_threshold = p->tracking_score_threshold;
        const auto obj = cv::TrackerVit::create(params);
        *returnValue = clone(obj);
    });
}
CVAPI(ExceptionStatus) video_Ptr_TrackerVit_get(cv::Ptr<cv::TrackerVit>* ptr, cv::TrackerVit** returnValue)
{ return cvTry([&] { *returnValue = ptr->get(); }); }
CVAPI(ExceptionStatus) video_Ptr_TrackerVit_delete(cv::Ptr<cv::TrackerVit>* ptr)
{ return cvTry([&] { delete ptr; }); }

#pragma endregion

#endif // NO_VIDEO
