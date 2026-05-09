#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudafeatures2d.hpp>

CVAPI(ExceptionStatus) cuda_ORB_create(
    int nfeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel,
    int WTA_K, int scoreType, int patchSize, int fastThreshold, int blurForDescriptor,
    cv::Ptr<cv::cuda::ORB> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::ORB::create(
        nfeatures, scaleFactor, nlevels, edgeThreshold, firstLevel,
        WTA_K, scoreType, patchSize, fastThreshold, blurForDescriptor != 0);
    *returnValue = new cv::Ptr<cv::cuda::ORB>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_get(cv::Ptr<cv::cuda::ORB> *ptr, cv::cuda::ORB **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_delete(cv::Ptr<cv::cuda::ORB> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getBlurForDescriptor(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getBlurForDescriptor() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setBlurForDescriptor(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setBlurForDescriptor(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getEdgeThreshold(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getEdgeThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setEdgeThreshold(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setEdgeThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getFastThreshold(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getFastThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setFastThreshold(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setFastThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getFirstLevel(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getFirstLevel();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setFirstLevel(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setFirstLevel(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getMaxFeatures(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxFeatures();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setMaxFeatures(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxFeatures(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getNLevels(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNLevels();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setNLevels(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setNLevels(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getPatchSize(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getPatchSize();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setPatchSize(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setPatchSize(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getScaleFactor(cv::cuda::ORB *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getScaleFactor();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setScaleFactor(cv::cuda::ORB *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleFactor(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getScoreType(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getScoreType();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setScoreType(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setScoreType(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_ORB_getWTA_K(cv::cuda::ORB *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getWTA_K();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_ORB_setWTA_K(cv::cuda::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setWTA_K(val);
    END_WRAP
}
