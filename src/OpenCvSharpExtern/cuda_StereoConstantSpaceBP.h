#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudastereo.hpp>

// ---------- cuda_createStereoConstantSpaceBP --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createStereoConstantSpaceBP(int ndisp, int iters, int levels, int nr_plane, int msg_type, cv::Ptr<cv::cuda::StereoConstantSpaceBP> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createStereoConstantSpaceBP(ndisp, iters, levels, nr_plane, msg_type);
    *returnValue = new cv::Ptr<cv::cuda::StereoConstantSpaceBP>(ptr);
    END_WRAP
}

// ---------- cuda_StereoConstantSpaceBP_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_get(
    cv::Ptr<cv::cuda::StereoConstantSpaceBP> *ptr, cv::cuda::StereoConstantSpaceBP **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_StereoConstantSpaceBP_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_delete(cv::Ptr<cv::cuda::StereoConstantSpaceBP> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_estimateRecommendedParams(
    int width, int height, int *ndisp, int *iters, int *levels, int *nr_plane)
{
    BEGIN_WRAP
    cv::cuda::StereoConstantSpaceBP::estimateRecommendedParams(width, height, *ndisp, *iters, *levels, *nr_plane);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_getNrPlane(cv::cuda::StereoConstantSpaceBP *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNrPlane();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_setNrPlane(cv::cuda::StereoConstantSpaceBP *obj, int val)
{
    BEGIN_WRAP
    obj->setNrPlane(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_getUseLocalInitDataCost(cv::cuda::StereoConstantSpaceBP *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getUseLocalInitDataCost() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_StereoConstantSpaceBP_setUseLocalInitDataCost(cv::cuda::StereoConstantSpaceBP *obj, int val)
{
    BEGIN_WRAP
    obj->setUseLocalInitDataCost(val != 0);
    END_WRAP
}
