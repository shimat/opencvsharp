#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_createFarnebackOpticalFlow(
    int numLevels, float pyrScale, int fastPyramids, int winSize,
    int numIters, int polyN, float polySigma, int flags,
    cv::Ptr<cv::cuda::FarnebackOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::FarnebackOpticalFlow::create(
        numLevels, pyrScale, fastPyramids != 0, winSize, numIters, polyN, polySigma, flags);
    *returnValue = new cv::Ptr<cv::cuda::FarnebackOpticalFlow>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_get(
    cv::Ptr<cv::cuda::FarnebackOpticalFlow> *ptr, cv::cuda::FarnebackOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_delete(cv::Ptr<cv::cuda::FarnebackOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getFastPyramids(cv::cuda::FarnebackOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getFastPyramids() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setFastPyramids(cv::cuda::FarnebackOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setFastPyramids(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getFlags(cv::cuda::FarnebackOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getFlags();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setFlags(cv::cuda::FarnebackOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setFlags(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getNumIters(cv::cuda::FarnebackOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumIters();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setNumIters(cv::cuda::FarnebackOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setNumIters(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getNumLevels(cv::cuda::FarnebackOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumLevels();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setNumLevels(cv::cuda::FarnebackOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setNumLevels(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getPolyN(cv::cuda::FarnebackOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getPolyN();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setPolyN(cv::cuda::FarnebackOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setPolyN(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getPolySigma(cv::cuda::FarnebackOpticalFlow *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getPolySigma();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setPolySigma(cv::cuda::FarnebackOpticalFlow *obj, float val)
{
    BEGIN_WRAP
    obj->setPolySigma(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getPyrScale(cv::cuda::FarnebackOpticalFlow *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getPyrScale();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setPyrScale(cv::cuda::FarnebackOpticalFlow *obj, float val)
{
    BEGIN_WRAP
    obj->setPyrScale(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_getWinSize(cv::cuda::FarnebackOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getWinSize();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_FarnebackOpticalFlow_setWinSize(cv::cuda::FarnebackOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setWinSize(val);
    END_WRAP
}
