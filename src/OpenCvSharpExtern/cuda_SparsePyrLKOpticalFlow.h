#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_createSparsePyrLKOpticalFlow(
    cv::Size winSize, int maxLevel, int iters, int useInitialFlow,
    cv::Ptr<cv::cuda::SparsePyrLKOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::SparsePyrLKOpticalFlow::create(winSize, maxLevel, iters, useInitialFlow != 0);
    *returnValue = new cv::Ptr<cv::cuda::SparsePyrLKOpticalFlow>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_get(
    cv::Ptr<cv::cuda::SparsePyrLKOpticalFlow> *ptr, cv::cuda::SparsePyrLKOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_delete(cv::Ptr<cv::cuda::SparsePyrLKOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_getMaxLevel(cv::cuda::SparsePyrLKOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxLevel();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_setMaxLevel(cv::cuda::SparsePyrLKOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxLevel(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_getNumIters(cv::cuda::SparsePyrLKOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumIters();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_setNumIters(cv::cuda::SparsePyrLKOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setNumIters(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_getUseInitialFlow(cv::cuda::SparsePyrLKOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getUseInitialFlow() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_setUseInitialFlow(cv::cuda::SparsePyrLKOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setUseInitialFlow(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_getWinSize(cv::cuda::SparsePyrLKOpticalFlow *obj, cv::Size *val)
{
    BEGIN_WRAP
    *val = obj->getWinSize();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SparsePyrLKOpticalFlow_setWinSize(cv::cuda::SparsePyrLKOpticalFlow *obj, cv::Size val)
{
    BEGIN_WRAP
    obj->setWinSize(val);
    END_WRAP
}

