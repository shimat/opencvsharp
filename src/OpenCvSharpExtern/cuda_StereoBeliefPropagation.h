#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudastereo.hpp>

// ---------- cuda_createStereoBeliefPropagation --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createStereoBeliefPropagation(int ndisp, int iters, int levels, int msg_type, cv::Ptr<cv::cuda::StereoBeliefPropagation> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createStereoBeliefPropagation(ndisp, iters, levels, msg_type);
    *returnValue = new cv::Ptr<cv::cuda::StereoBeliefPropagation>(ptr);
    END_WRAP
}

// ---------- cuda_StereoBeliefPropagation_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_get(cv::Ptr<cv::cuda::StereoBeliefPropagation> *ptr, cv::cuda::StereoBeliefPropagation **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_StereoBeliefPropagation_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_delete(cv::Ptr<cv::cuda::StereoBeliefPropagation> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_compute_data(
    cv::cuda::StereoBeliefPropagation *obj, cv::_InputArray *data,
    cv::_OutputArray *disparity, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->compute(*data, *disparity, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_estimateRecommendedParams(
    int width, int height, int *ndisp, int *iters, int *levels)
{
    BEGIN_WRAP
    cv::cuda::StereoBeliefPropagation::estimateRecommendedParams(width, height, *ndisp, *iters, *levels);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getDataWeight(cv::cuda::StereoBeliefPropagation *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getDataWeight();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setDataWeight(cv::cuda::StereoBeliefPropagation *obj, float val)
{
    BEGIN_WRAP
    obj->setDataWeight(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getDiscSingleJump(cv::cuda::StereoBeliefPropagation *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getDiscSingleJump();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setDiscSingleJump(cv::cuda::StereoBeliefPropagation *obj, double val)
{
    BEGIN_WRAP
    obj->setDiscSingleJump(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getMaxDataTerm(cv::cuda::StereoBeliefPropagation *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getMaxDataTerm();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setMaxDataTerm(cv::cuda::StereoBeliefPropagation *obj, double val)
{
    BEGIN_WRAP
    obj->setMaxDataTerm(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getMaxDiscTerm(cv::cuda::StereoBeliefPropagation *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getMaxDiscTerm();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setMaxDiscTerm(cv::cuda::StereoBeliefPropagation *obj, double val)
{
    BEGIN_WRAP
    obj->setMaxDiscTerm(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getMsgType(cv::cuda::StereoBeliefPropagation *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMsgType();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setMsgType(cv::cuda::StereoBeliefPropagation *obj, int val)
{
    BEGIN_WRAP
    obj->setMsgType(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getNumIters(cv::cuda::StereoBeliefPropagation *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumIters();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setNumIters(cv::cuda::StereoBeliefPropagation *obj, int val)
{
    BEGIN_WRAP
    obj->setNumIters(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_getNumLevels(cv::cuda::StereoBeliefPropagation *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumLevels();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoBeliefPropagation_setNumLevels(cv::cuda::StereoBeliefPropagation *obj, int val)
{
    BEGIN_WRAP
    obj->setNumLevels(val);
    END_WRAP
}

