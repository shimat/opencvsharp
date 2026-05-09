#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_createOpticalFlowDual_TVL1(
    double tau, double lambda, double theta, int nscales, int warps,
    double epsilon, int iterations, double scaleStep, double gamma, int useInitialFlow,
    cv::Ptr<cv::cuda::OpticalFlowDual_TVL1> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::OpticalFlowDual_TVL1::create(
        tau, lambda, theta, nscales, warps, epsilon, iterations, scaleStep, gamma, useInitialFlow != 0);
    *returnValue = new cv::Ptr<cv::cuda::OpticalFlowDual_TVL1>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_get(
    cv::Ptr<cv::cuda::OpticalFlowDual_TVL1> *ptr, cv::cuda::OpticalFlowDual_TVL1 **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_delete(cv::Ptr<cv::cuda::OpticalFlowDual_TVL1> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getEpsilon(cv::cuda::OpticalFlowDual_TVL1 *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getEpsilon();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setEpsilon(cv::cuda::OpticalFlowDual_TVL1 *obj, double val)
{
    BEGIN_WRAP
    obj->setEpsilon(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getGamma(cv::cuda::OpticalFlowDual_TVL1 *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getGamma();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setGamma(cv::cuda::OpticalFlowDual_TVL1 *obj, double val)
{
    BEGIN_WRAP
    obj->setGamma(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getLambda(cv::cuda::OpticalFlowDual_TVL1 *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getLambda();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setLambda(cv::cuda::OpticalFlowDual_TVL1 *obj, double val)
{
    BEGIN_WRAP
    obj->setLambda(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getNumIterations(cv::cuda::OpticalFlowDual_TVL1 *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumIterations();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setNumIterations(cv::cuda::OpticalFlowDual_TVL1 *obj, int val)
{
    BEGIN_WRAP
    obj->setNumIterations(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getNumScales(cv::cuda::OpticalFlowDual_TVL1 *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumScales();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setNumScales(cv::cuda::OpticalFlowDual_TVL1 *obj, int val)
{
    BEGIN_WRAP
    obj->setNumScales(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getNumWarps(cv::cuda::OpticalFlowDual_TVL1 *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumWarps();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setNumWarps(cv::cuda::OpticalFlowDual_TVL1 *obj, int val)
{
    BEGIN_WRAP
    obj->setNumWarps(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getScaleStep(cv::cuda::OpticalFlowDual_TVL1 *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getScaleStep();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setScaleStep(cv::cuda::OpticalFlowDual_TVL1 *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleStep(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getTau(cv::cuda::OpticalFlowDual_TVL1 *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getTau();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setTau(cv::cuda::OpticalFlowDual_TVL1 *obj, double val)
{
    BEGIN_WRAP
    obj->setTau(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getTheta(cv::cuda::OpticalFlowDual_TVL1 *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getTheta();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setTheta(cv::cuda::OpticalFlowDual_TVL1 *obj, double val)
{
    BEGIN_WRAP
    obj->setTheta(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_getUseInitialFlow(cv::cuda::OpticalFlowDual_TVL1 *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getUseInitialFlow() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_OpticalFlowDual_TVL1_setUseInitialFlow(cv::cuda::OpticalFlowDual_TVL1 *obj, int val)
{
    BEGIN_WRAP
    obj->setUseInitialFlow(val != 0);
    END_WRAP
}
