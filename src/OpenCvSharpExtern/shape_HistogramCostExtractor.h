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
    const interop::InputArrayProxy* descriptors1,
    const interop::InputArrayProxy* descriptors2,
    const interop::OutputArrayProxy* costMatrix)
{
    return cvTry([&] {
    obj->buildCostMatrix(InProxy(*descriptors1), InProxy(*descriptors2), OutProxy(*costMatrix));
    });
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_setNDummies(cv::HistogramCostExtractor *obj, int val)
{
    return cvTry([&] {
    obj->setNDummies(val);
    });
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_getNDummies(cv::HistogramCostExtractor *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNDummies();
    });
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_setDefaultCost(cv::HistogramCostExtractor *obj, float val)
{
    return cvTry([&] {
    obj->setDefaultCost(val);
    });
}

CVAPI(ExceptionStatus) shape_HistogramCostExtractor_getDefaultCost(cv::HistogramCostExtractor *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDefaultCost();
    });
}


// ============================================================
// Ptr<HistogramCostExtractor> lifetime management
// All factory functions return Ptr<HistogramCostExtractor>,
// so one shared set of delete/get functions covers all subclasses.
// ============================================================

CVAPI(ExceptionStatus) shape_Ptr_HistogramCostExtractor_delete(cv::Ptr<cv::HistogramCostExtractor> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) shape_Ptr_HistogramCostExtractor_get(cv::Ptr<cv::HistogramCostExtractor> *ptr, cv::HistogramCostExtractor **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}


// ============================================================
// NormHistogramCostExtractor
// ============================================================

#pragma region NormHistogramCostExtractor

CVAPI(ExceptionStatus) shape_createNormHistogramCostExtractor(
    int flag,
    int nDummies,
    float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createNormHistogramCostExtractor(flag, nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    });
}

CVAPI(ExceptionStatus) shape_NormHistogramCostExtractor_setNormFlag(cv::HistogramCostExtractor *obj, int flag)
{
    return cvTry([&] {
    static_cast<cv::NormHistogramCostExtractor*>(obj)->setNormFlag(flag);
    });
}

CVAPI(ExceptionStatus) shape_NormHistogramCostExtractor_getNormFlag(cv::HistogramCostExtractor *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = static_cast<cv::NormHistogramCostExtractor*>(obj)->getNormFlag();
    });
}

#pragma endregion


// ============================================================
// EMDHistogramCostExtractor
// ============================================================

#pragma region EMDHistogramCostExtractor

CVAPI(ExceptionStatus) shape_createEMDHistogramCostExtractor(
    int flag,
    int nDummies,
    float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createEMDHistogramCostExtractor(flag, nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    });
}

CVAPI(ExceptionStatus) shape_EMDHistogramCostExtractor_setNormFlag(cv::HistogramCostExtractor *obj, int flag)
{
    return cvTry([&] {
    static_cast<cv::EMDHistogramCostExtractor*>(obj)->setNormFlag(flag);
    });
}

CVAPI(ExceptionStatus) shape_EMDHistogramCostExtractor_getNormFlag(cv::HistogramCostExtractor *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = static_cast<cv::EMDHistogramCostExtractor*>(obj)->getNormFlag();
    });
}

#pragma endregion


// ============================================================
// ChiHistogramCostExtractor
// ============================================================

#pragma region ChiHistogramCostExtractor

CVAPI(ExceptionStatus) shape_createChiHistogramCostExtractor(
    int nDummies,
    float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createChiHistogramCostExtractor(nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    });
}

#pragma endregion


// ============================================================
// EMDL1HistogramCostExtractor
// ============================================================

#pragma region EMDL1HistogramCostExtractor

CVAPI(ExceptionStatus) shape_createEMDL1HistogramCostExtractor(
    int nDummies,
    float defaultCost,
    cv::Ptr<cv::HistogramCostExtractor> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createEMDL1HistogramCostExtractor(nDummies, defaultCost);
    *returnValue = new cv::Ptr<cv::HistogramCostExtractor>(ptr);
    });
}

#pragma endregion


// ============================================================
// EMDL1 free function
// ============================================================

CVAPI(ExceptionStatus) shape_EMDL1(
    const interop::InputArrayProxy* signature1,
    const interop::InputArrayProxy* signature2,
    float *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::EMDL1(InProxy(*signature1), InProxy(*signature2));
    });
}


#endif // NO_CONTRIB