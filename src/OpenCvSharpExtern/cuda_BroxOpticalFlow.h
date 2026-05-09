#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_createBroxOpticalFlow(
    double alpha, double gamma, double scale_factor, int inner_iterations, int outer_iterations, int solver_iterations,
    cv::Ptr<cv::cuda::BroxOpticalFlow> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::BroxOpticalFlow::create(alpha, gamma, scale_factor, inner_iterations, outer_iterations, solver_iterations);
    *returnValue = new cv::Ptr<cv::cuda::BroxOpticalFlow>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_get(
    cv::Ptr<cv::cuda::BroxOpticalFlow> *ptr, cv::cuda::BroxOpticalFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_delete(cv::Ptr<cv::cuda::BroxOpticalFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// --- PROPERTIES ---
CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_getFlowSmoothness(cv::cuda::BroxOpticalFlow *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getFlowSmoothness();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_setFlowSmoothness(cv::cuda::BroxOpticalFlow *obj, double val)
{
    BEGIN_WRAP
    obj->setFlowSmoothness(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_getGradientConstancyImportance(cv::cuda::BroxOpticalFlow *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getGradientConstancyImportance();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_setGradientConstancyImportance(cv::cuda::BroxOpticalFlow *obj, double val)
{
    BEGIN_WRAP
    obj->setGradientConstancyImportance(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_getInnerIterations(cv::cuda::BroxOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getInnerIterations();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_setInnerIterations(cv::cuda::BroxOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setInnerIterations(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_getOuterIterations(cv::cuda::BroxOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getOuterIterations();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_setOuterIterations(cv::cuda::BroxOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setOuterIterations(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_getPyramidScaleFactor(cv::cuda::BroxOpticalFlow *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getPyramidScaleFactor();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_setPyramidScaleFactor(cv::cuda::BroxOpticalFlow *obj, double val)
{
    BEGIN_WRAP
    obj->setPyramidScaleFactor(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_getSolverIterations(cv::cuda::BroxOpticalFlow *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getSolverIterations();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BroxOpticalFlow_setSolverIterations(cv::cuda::BroxOpticalFlow *obj, int val)
{
    BEGIN_WRAP
    obj->setSolverIterations(val);
    END_WRAP
}
