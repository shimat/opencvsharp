#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/shape/hist_cost.hpp>
#include <opencv2/shape/emdL1.hpp>


// ============================================================
// HistogramCostExtractor base class methods
// ============================================================

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_buildCostMatrix(
    cv::HistogramCostExtractor *obj,
    cv::_InputArray *descriptors1,
    cv::_InputArray *descriptors2,
    cv::_OutputArray *costMatrix)
{
    BEGIN_WRAP
    obj->buildCostMatrix(*descriptors1, *descriptors2, *costMatrix);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_setNDummies(
    cv::HistogramCostExtractor *obj, int val)
{
    BEGIN_WRAP
    obj->setNDummies(val);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_getNDummies(
    cv::HistogramCostExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNDummies();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_setDefaultCost(
    cv::HistogramCostExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setDefaultCost(val);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_getDefaultCost(
    cv::HistogramCostExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDefaultCost();
    END_WRAP
}


// ============================================================
// Ptr<HistogramCostExtractor> lifetime management
// All factory functions return Ptr<HistogramCostExtractor>,
// so one shared set of delete/get functions covers all subclasses.
// ============================================================

CVAPI(ExceptionStatus) shape_Ptr_HistogramCostExtractor_delete(
    cv::Ptr<cv::HistogramCostExtractor> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) shape_Ptr_HistogramCostExtractor_get(
    cv::Ptr<cv::HistogramCostExtractor> *ptr,
    cv::HistogramCostExtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// ============================================================
// NormHistogramCostExtractor
// ============================================================

#pragma region NormHistogramCostExtractor

CVAPI(ExceptionStatus) shape_createNormHistogramCostExtractor(
    int flag, int nDummies, float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createNormHistogramCostExtractor(flag, nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_NormHistogramCostExtractor_setNormFlag(
    cv::HistogramCostExtractor *obj, int flag)
{
    BEGIN_WRAP
    static_cast<cv::NormHistogramCostExtractor*>(obj)->setNormFlag(flag);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_NormHistogramCostExtractor_getNormFlag(
    cv::HistogramCostExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<cv::NormHistogramCostExtractor*>(obj)->getNormFlag();
    END_WRAP
}

#pragma endregion


// ============================================================
// EMDHistogramCostExtractor
// ============================================================

#pragma region EMDHistogramCostExtractor

CVAPI(ExceptionStatus) shape_createEMDHistogramCostExtractor(
    int flag, int nDummies, float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createEMDHistogramCostExtractor(flag, nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_EMDHistogramCostExtractor_setNormFlag(
    cv::HistogramCostExtractor *obj, int flag)
{
    BEGIN_WRAP
    static_cast<cv::EMDHistogramCostExtractor*>(obj)->setNormFlag(flag);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_EMDHistogramCostExtractor_getNormFlag(
    cv::HistogramCostExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<cv::EMDHistogramCostExtractor*>(obj)->getNormFlag();
    END_WRAP
}

#pragma endregion


// ============================================================
// ChiHistogramCostExtractor
// ============================================================

#pragma region ChiHistogramCostExtractor

CVAPI(ExceptionStatus) shape_createChiHistogramCostExtractor(
    int nDummies, float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createChiHistogramCostExtractor(nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    END_WRAP
}

#pragma endregion


// ============================================================
// EMDL1HistogramCostExtractor
// ============================================================

#pragma region EMDL1HistogramCostExtractor

CVAPI(ExceptionStatus) shape_createEMDL1HistogramCostExtractor(
    int nDummies, float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createEMDL1HistogramCostExtractor(nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    END_WRAP
}

#pragma endregion


// ============================================================
// EMDL1 free function
// ============================================================

CVAPI(ExceptionStatus) shape_EMDL1(
    cv::_InputArray *signature1, cv::_InputArray *signature2, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::EMDL1(*signature1, *signature2);
    END_WRAP
}


#endif // NO_CONTRIB