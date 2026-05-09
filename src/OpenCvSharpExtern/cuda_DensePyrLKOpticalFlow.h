#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_createDensePyrLKOpticalFlow(
    cv::Size winSize, int maxLevel, int iters, int useInitialFlow,
    cv::Ptr<cv::cuda::DensePyrLKOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::DensePyrLKOpticalFlow::create(winSize, maxLevel, iters, useInitialFlow != 0);
    *returnValue = new cv::Ptr<cv::cuda::DensePyrLKOpticalFlow>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_get(
    cv::Ptr<cv::cuda::DensePyrLKOpticalFlow> *ptr, cv::cuda::DensePyrLKOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_delete(cv::Ptr<cv::cuda::DensePyrLKOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_getMaxLevel(cv::cuda::DensePyrLKOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxLevel();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_setMaxLevel(cv::cuda::DensePyrLKOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxLevel(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_getNumIters(cv::cuda::DensePyrLKOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumIters();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_setNumIters(cv::cuda::DensePyrLKOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setNumIters(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_getUseInitialFlow(cv::cuda::DensePyrLKOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getUseInitialFlow() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_setUseInitialFlow(cv::cuda::DensePyrLKOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setUseInitialFlow(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_getWinSize(cv::cuda::DensePyrLKOpticalFlow *obj, cv::Size *val)
{
    BEGIN_WRAP
    *val = obj->getWinSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DensePyrLKOpticalFlow_setWinSize(cv::cuda::DensePyrLKOpticalFlow *obj, cv::Size val)
{
    BEGIN_WRAP
    obj->setWinSize(val);
    END_WRAP
}
