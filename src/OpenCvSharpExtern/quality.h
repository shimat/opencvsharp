#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region QualityBase

CVAPI(ExceptionStatus) quality_QualityBase_compute(cv::quality::QualityBase *obj, cv::_InputArray *img, interop::Scalar *returnValue)
{
    return cvTry([&] {
    const auto ret = obj->compute(*img);
    *returnValue = c(ret);
    });
}

CVAPI(ExceptionStatus) quality_QualityBase_getQualityMap(cv::quality::QualityBase *obj, cv::_OutputArray *dst)
{
    return cvTry([&] {
    obj->getQualityMap(*dst);
    });
}

CVAPI(ExceptionStatus) quality_QualityBase_clear(cv::quality::QualityBase *obj)
{
    return cvTry([&] {
    obj->clear();
    });
}

CVAPI(ExceptionStatus) quality_QualityBase_empty(cv::quality::QualityBase *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->empty() ? 1 : 0;
    });
}

#pragma endregion

#pragma region QualityPSNR

CVAPI(ExceptionStatus) quality_createQualityPSNR(
    cv::_InputArray *ref, double maxPixelValue, cv::Ptr<cv::quality::QualityPSNR> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::quality::QualityPSNR::create(*ref, maxPixelValue);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityPSNR_delete(cv::Ptr<cv::quality::QualityPSNR> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityPSNR_get(
    cv::Ptr<cv::quality::QualityPSNR>* ptr, cv::quality::QualityPSNR **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) quality_QualityPSNR_staticCompute(
    cv::_InputArray *ref, cv::_InputArray *cmp, cv::_OutputArray *qualityMap, double maxPixelValue, interop::Scalar *returnValue)
{
    return cvTry([&] {
    cv::Scalar ret;
    if (qualityMap == nullptr)
        ret = cv::quality::QualityPSNR::compute(*ref, *cmp, cv::noArray(), maxPixelValue);
    else
        ret = cv::quality::QualityPSNR::compute(*ref, *cmp, *qualityMap, maxPixelValue);
    *returnValue = c(ret);
    });
}

CVAPI(ExceptionStatus) quality_QualityPSNR_getMaxPixelValue(cv::quality::QualityPSNR *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxPixelValue();
    });
}

CVAPI(ExceptionStatus) quality_QualityPSNR_setMaxPixelValue(cv::quality::QualityPSNR *obj, double val)
{
    return cvTry([&] {
    obj->setMaxPixelValue(val);
    });
}

#pragma endregion

#pragma region QualitySSIM

CVAPI(ExceptionStatus) quality_createQualitySSIM(cv::_InputArray* ref, cv::Ptr<cv::quality::QualitySSIM> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::quality::QualitySSIM::create(*ref);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualitySSIM_delete(cv::Ptr<cv::quality::QualitySSIM>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualitySSIM_get(
    cv::Ptr<cv::quality::QualitySSIM>* ptr, cv::quality::QualitySSIM **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) quality_QualitySSIM_staticCompute(
    cv::_InputArray* ref, cv::_InputArray* cmp, cv::_OutputArray* qualityMap, interop::Scalar *returnValue)
{
    return cvTry([&] {
    cv::Scalar ret;
    if (qualityMap == nullptr)
        ret = cv::quality::QualitySSIM::compute(*ref, *cmp, cv::noArray());
    else
        ret = cv::quality::QualitySSIM::compute(*ref, *cmp, *qualityMap);
    *returnValue = c(ret);
    });
}

#pragma endregion

#pragma region QualityGMSD

CVAPI(ExceptionStatus) quality_createQualityGMSD(cv::_InputArray* ref, cv::Ptr<cv::quality::QualityGMSD> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::quality::QualityGMSD::create(*ref);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityGMSD_delete(cv::Ptr<cv::quality::QualityGMSD>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityGMSD_get(
    cv::Ptr<cv::quality::QualityGMSD>* ptr, cv::quality::QualityGMSD **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) quality_QualityGMSD_staticCompute(
    cv::_InputArray* ref, cv::_InputArray* cmp, cv::_OutputArray* qualityMap, interop::Scalar *returnValue)
{
    return cvTry([&] {
    cv::Scalar ret;
    if (qualityMap == nullptr)
        ret = cv::quality::QualityGMSD::compute(*ref, *cmp, cv::noArray());
    else
        ret = cv::quality::QualityGMSD::compute(*ref, *cmp, *qualityMap);
    *returnValue = c(ret);
    });
}

#pragma endregion

#pragma region QualityMSE

CVAPI(ExceptionStatus) quality_createQualityMSE(cv::_InputArray* ref, cv::Ptr<cv::quality::QualityMSE> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::quality::QualityMSE::create(*ref);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityMSE_delete(cv::Ptr<cv::quality::QualityMSE>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityMSE_get(
    cv::Ptr<cv::quality::QualityMSE>* ptr, cv::quality::QualityMSE **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) quality_QualityMSE_staticCompute(
    cv::_InputArray* ref, cv::_InputArray* cmp, cv::_OutputArray* qualityMap, interop::Scalar *returnValue)
{
    return cvTry([&] {
    cv::Scalar ret;
    if (qualityMap == nullptr)
        ret = cv::quality::QualityMSE::compute(*ref, *cmp, cv::noArray());
    else
        ret = cv::quality::QualityMSE::compute(*ref, *cmp, *qualityMap);
    *returnValue = c(ret);
    });
}

#pragma endregion

#pragma region QualityBRISQUE

CVAPI(ExceptionStatus) quality_createQualityBRISQUE1(
    const char *modelFilePath, const char *rangeFilePath, cv::Ptr<cv::quality::QualityBRISQUE> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::quality::QualityBRISQUE::create(modelFilePath, rangeFilePath);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) quality_createQualityBRISQUE2(
    cv::ml::SVM *model, cv::Mat *range, cv::Ptr<cv::quality::QualityBRISQUE> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::quality::QualityBRISQUE::create(model, *range);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityBRISQUE_delete(cv::Ptr<cv::quality::QualityBRISQUE>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) quality_Ptr_QualityBRISQUE_get(
    cv::Ptr<cv::quality::QualityBRISQUE>* ptr, cv::quality::QualityBRISQUE **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) quality_QualityBRISQUE_staticCompute(
    cv::_InputArray* ref, const char* modelFilePath, const char* rangeFilePath, interop::Scalar *returnValue)
{
    return cvTry([&] {
    const auto ret = cv::quality::QualityBRISQUE::compute(*ref, modelFilePath, rangeFilePath);
    *returnValue = c(ret);
    });
}

CVAPI(ExceptionStatus) quality_QualityBRISQUE_computeFeatures(
    cv::_InputArray* img, cv::_OutputArray *features)
{
    return cvTry([&] {
    cv::quality::QualityBRISQUE::computeFeatures(*img, *features);
    });
}

#pragma endregion

#endif // _WINRT_DLL
#endif // NO_CONTRIB
