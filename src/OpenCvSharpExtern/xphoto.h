#pragma once

// OpenCV 5: kept available in every profile (including slim); see include_opencv.h.

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region inpainting.hpp

CVAPI(ExceptionStatus) xphoto_inpaint(
    cv::Mat *src,
    cv::Mat *mask,
    cv::Mat *dst,
    int algorithm)
{
    return cvTry([&] {
    cv::xphoto::inpaint(*src, *mask, *dst, static_cast<const cv::xphoto::InpaintTypes>(algorithm));
    });
}

#pragma endregion

#pragma region white_balance.hpp

CVAPI(ExceptionStatus) xphoto_applyChannelGains(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float gainB,
    float gainG,
    float gainR)
{
    return cvTry([&] {
    cv::xphoto::applyChannelGains(InProxy(*src), OutProxy(*dst), gainB, gainG, gainR);
    });
}

CVAPI(ExceptionStatus) xphoto_createGrayworldWB(cv::Ptr<cv::xphoto::GrayworldWB> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xphoto::createGrayworldWB();
    *returnValue = new cv::Ptr<cv::xphoto::GrayworldWB>(ptr);
    });
}

CVAPI(ExceptionStatus) xphoto_Ptr_GrayworldWB_delete(cv::Ptr<cv::xphoto::GrayworldWB> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}
CVAPI(ExceptionStatus) xphoto_Ptr_GrayworldWB_get(cv::Ptr<cv::xphoto::GrayworldWB>* ptr, cv::xphoto::GrayworldWB **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) xphoto_GrayworldWB_balanceWhite(
    cv::xphoto::GrayworldWB* ptr,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    ptr->balanceWhite(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) xphoto_GrayworldWB_SaturationThreshold_get(cv::xphoto::GrayworldWB* ptr, float* returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getSaturationThreshold();
    });
}
CVAPI(ExceptionStatus) xphoto_GrayworldWB_SaturationThreshold_set(cv::xphoto::GrayworldWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setSaturationThreshold(val);
    });
}

CVAPI(ExceptionStatus) xphoto_createLearningBasedWB(const char* path_to_model, cv::Ptr<cv::xphoto::LearningBasedWB> **returnValue)
{
    return cvTry([&] {
    const std::string str_path_to_model(path_to_model);
    const auto ptr = cv::xphoto::createLearningBasedWB(str_path_to_model);
    *returnValue = new cv::Ptr<cv::xphoto::LearningBasedWB>(ptr);
    });
}

CVAPI(ExceptionStatus) xphoto_Ptr_LearningBasedWB_delete(cv::Ptr<cv::xphoto::LearningBasedWB> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}
CVAPI(ExceptionStatus) xphoto_Ptr_LearningBasedWB_get(cv::Ptr<cv::xphoto::LearningBasedWB>* ptr, cv::xphoto::LearningBasedWB **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_balanceWhite(
    cv::xphoto::LearningBasedWB* ptr,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    ptr->balanceWhite(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_extractSimpleFeatures(
    cv::xphoto::LearningBasedWB* ptr,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    ptr->extractSimpleFeatures(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_RangeMaxVal_get(cv::xphoto::LearningBasedWB* ptr, int *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getRangeMaxVal();
    });
}
CVAPI(ExceptionStatus) xphoto_LearningBasedWB_RangeMaxVal_set(cv::xphoto::LearningBasedWB* ptr, int val)
{
    return cvTry([&] {
    ptr->setRangeMaxVal(val);
    });
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_SaturationThreshold_get(cv::xphoto::LearningBasedWB* ptr, float *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getSaturationThreshold();
    });
}
CVAPI(ExceptionStatus) xphoto_LearningBasedWB_SaturationThreshold_set(cv::xphoto::LearningBasedWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setSaturationThreshold(val);
    });
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_HistBinNum_get(cv::xphoto::LearningBasedWB* ptr, int *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getHistBinNum();
    });
}
CVAPI(ExceptionStatus) xphoto_LearningBasedWB_HistBinNum_set(cv::xphoto::LearningBasedWB* ptr, int val)
{
    return cvTry([&] {
    ptr->setHistBinNum(val);
    });
}

CVAPI(ExceptionStatus) xphoto_createSimpleWB(cv::Ptr<cv::xphoto::SimpleWB> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xphoto::createSimpleWB();
    *returnValue = new cv::Ptr<cv::xphoto::SimpleWB>(ptr);
    });
}

CVAPI(ExceptionStatus) xphoto_Ptr_SimpleWB_delete(cv::Ptr<cv::xphoto::SimpleWB> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}
CVAPI(ExceptionStatus) xphoto_Ptr_SimpleWB_get(cv::Ptr<cv::xphoto::SimpleWB>* ptr, cv::xphoto::SimpleWB **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_balanceWhite(
    cv::xphoto::SimpleWB* ptr,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    ptr->balanceWhite(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMax_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getInputMax();
    });
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMax_set(cv::xphoto::SimpleWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setInputMax(val);
    });
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMin_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getInputMin();
    });
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMin_set(cv::xphoto::SimpleWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setInputMin(val);
    });
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMax_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getOutputMax();
    });
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMax_set(cv::xphoto::SimpleWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setOutputMax(val);
    });
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMin_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getOutputMin();
    });
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMin_set(cv::xphoto::SimpleWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setOutputMin(val);
    });
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_P_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->getP();
    });
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_P_set(cv::xphoto::SimpleWB* ptr, float val)
{
    return cvTry([&] {
    ptr->setP(val);
    });
}

#pragma endregion

#pragma region bm3d_image_denoising.hpp

CVAPI(ExceptionStatus) xphoto_bm3dDenoising1(
    const interop::InputArrayProxy* src,
    const interop::InputOutputArrayProxy* dstStep1,
    const interop::OutputArrayProxy* dstStep2,
    float h,
    int templateWindowSize,
    int searchWindowSize,
    int blockMatchingStep1,
    int blockMatchingStep2,
    int groupSize,
    int slidingStep,
    float beta,
    int normType,
    int step,
    int transformType)
{
    return cvTry([&] {
    cv::xphoto::bm3dDenoising(
        InProxy(*src), IoProxy(*dstStep1), OutProxy(*dstStep2), h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, 
        groupSize, slidingStep, beta, normType, step, transformType);
    });
}

CVAPI(ExceptionStatus) xphoto_bm3dDenoising2(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float h,
    int templateWindowSize,
    int searchWindowSize,
    int blockMatchingStep1,
    int blockMatchingStep2,
    int groupSize,
    int slidingStep,
    float beta,
    int normType,
    int step,
    int transformType)
{
    return cvTry([&] {
    cv::xphoto::bm3dDenoising(
        InProxy(*src), OutProxy(*dst), h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, 
        groupSize, slidingStep, beta, normType, step, transformType);
    });
}

#pragma endregion

#pragma region dct_image_denoising.hpp

CVAPI(ExceptionStatus) xphoto_dctDenoising(
    cv::Mat *src,
    cv::Mat *dst,
    const double sigma,
    const int psize)
{
    return cvTry([&] {
    cv::xphoto::dctDenoising(*src, *dst, sigma, psize);
    });
}

#pragma endregion

#pragma region oilpainting.hpp

CVAPI(ExceptionStatus) xphoto_oilPainting(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int size,
    int dynRatio,
    int code)
{
    return cvTry([&] {
    if (code >= 0)
        cv::xphoto::oilPainting(InProxy(*src), OutProxy(*dst), size, dynRatio, code);
    else
        cv::xphoto::oilPainting(InProxy(*src), OutProxy(*dst), size, dynRatio);
    });
}

#pragma endregion

#pragma region tonemap.hpp

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getSaturation(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSaturation();
    });
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setSaturation(cv::xphoto::TonemapDurand *obj, float saturation)
{
    return cvTry([&] {
    obj->setSaturation(saturation);
    });
}

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getContrast(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getContrast();
    });
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setContrast(cv::xphoto::TonemapDurand *obj, float contrast)
{
    return cvTry([&] {
    obj->setContrast(contrast);
    });
}

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getSigmaSpace(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSigmaSpace();
    });
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setSigmaSpace(cv::xphoto::TonemapDurand *obj, float sigma_space)
{
    return cvTry([&] {
    obj->setSigmaSpace(sigma_space);
    });
}

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getSigmaColor(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSigmaColor();
    });
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setSigmaColor(cv::xphoto::TonemapDurand *obj, float sigma_color)
{
    return cvTry([&] {
    obj->setSigmaColor(sigma_color);
    });
}

CVAPI(ExceptionStatus) xphoto_createTonemapDurand(
    float gamma,
    float contrast,
    float saturation,
    float sigma_space,
    float sigma_color,
    cv::Ptr<cv::xphoto::TonemapDurand> **returnValue)
{
    return cvTry([&] {
    const auto p = cv::xphoto::createTonemapDurand(gamma, contrast, saturation, sigma_space, sigma_color);
    *returnValue = clone(p);
    });  
}

CVAPI(ExceptionStatus) xphoto_Ptr_TonemapDurand_delete(cv::Ptr<cv::xphoto::TonemapDurand> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) xphoto_Ptr_TonemapDurand_get(cv::Ptr<cv::xphoto::TonemapDurand> *ptr, cv::xphoto::TonemapDurand **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#pragma endregion

// (no NO_CONTRIB guard: kept in every profile for OpenCV 5)
