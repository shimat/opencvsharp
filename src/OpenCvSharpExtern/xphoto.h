#ifndef _CPP_XPHOTO_H_
#define _CPP_XPHOTO_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region inpainting.hpp

CVAPI(ExceptionStatus) xphoto_inpaint(cv::Mat *src, cv::Mat *mask, cv::Mat *dst, int algorithm)
{
    BEGIN_WRAP
    cv::xphoto::inpaint(*src, *mask, *dst, static_cast<const cv::xphoto::InpaintTypes>(algorithm));
    END_WRAP
}

#pragma endregion

#pragma region white_balance.hpp

CVAPI(ExceptionStatus) xphoto_applyChannelGains(cv::_InputArray *src, cv::_OutputArray *dst, float gainB, float gainG, float gainR)
{
    BEGIN_WRAP
    cv::xphoto::applyChannelGains(*src, *dst, gainB, gainG, gainR);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_createGrayworldWB(cv::Ptr<cv::xphoto::GrayworldWB> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xphoto::createGrayworldWB();
    *returnValue = new cv::Ptr<cv::xphoto::GrayworldWB>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_Ptr_GrayworldWB_delete(cv::Ptr<cv::xphoto::GrayworldWB> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_Ptr_GrayworldWB_get(cv::Ptr<cv::xphoto::GrayworldWB>* ptr, cv::xphoto::GrayworldWB **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_GrayworldWB_balanceWhite(cv::xphoto::GrayworldWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    ptr->balanceWhite(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_GrayworldWB_SaturationThreshold_get(cv::xphoto::GrayworldWB* ptr, float* returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getSaturationThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_GrayworldWB_SaturationThreshold_set(cv::xphoto::GrayworldWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setSaturationThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_createLearningBasedWB(const char* path_to_model, cv::Ptr<cv::xphoto::LearningBasedWB> **returnValue)
{
    BEGIN_WRAP
    const std::string str_path_to_model(path_to_model);
    const auto ptr = cv::xphoto::createLearningBasedWB(str_path_to_model);
    *returnValue = new cv::Ptr<cv::xphoto::LearningBasedWB>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_Ptr_LearningBasedWB_delete(cv::Ptr<cv::xphoto::LearningBasedWB> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_Ptr_LearningBasedWB_get(cv::Ptr<cv::xphoto::LearningBasedWB>* ptr, cv::xphoto::LearningBasedWB **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_balanceWhite(cv::xphoto::LearningBasedWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    ptr->balanceWhite(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_extractSimpleFeatures(cv::xphoto::LearningBasedWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    ptr->extractSimpleFeatures(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_RangeMaxVal_get(cv::xphoto::LearningBasedWB* ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getRangeMaxVal();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_LearningBasedWB_RangeMaxVal_set(cv::xphoto::LearningBasedWB* ptr, int val)
{
    BEGIN_WRAP
    ptr->setRangeMaxVal(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_SaturationThreshold_get(cv::xphoto::LearningBasedWB* ptr, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getSaturationThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_LearningBasedWB_SaturationThreshold_set(cv::xphoto::LearningBasedWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setSaturationThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_LearningBasedWB_HistBinNum_get(cv::xphoto::LearningBasedWB* ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getHistBinNum();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_LearningBasedWB_HistBinNum_set(cv::xphoto::LearningBasedWB* ptr, int val)
{
    BEGIN_WRAP
    ptr->setHistBinNum(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_createSimpleWB(cv::Ptr<cv::xphoto::SimpleWB> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xphoto::createSimpleWB();
    *returnValue = new cv::Ptr<cv::xphoto::SimpleWB>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_Ptr_SimpleWB_delete(cv::Ptr<cv::xphoto::SimpleWB> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_Ptr_SimpleWB_get(cv::Ptr<cv::xphoto::SimpleWB>* ptr, cv::xphoto::SimpleWB **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_balanceWhite(cv::xphoto::SimpleWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    ptr->balanceWhite(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMax_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getInputMax();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMax_set(cv::xphoto::SimpleWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setInputMax(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMin_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getInputMin();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_InputMin_set(cv::xphoto::SimpleWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setInputMin(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMax_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getOutputMax();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMax_set(cv::xphoto::SimpleWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setOutputMax(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMin_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getOutputMin();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_OutputMin_set(cv::xphoto::SimpleWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setOutputMin(val);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_SimpleWB_P_get(cv::xphoto::SimpleWB* ptr, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->getP();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_SimpleWB_P_set(cv::xphoto::SimpleWB* ptr, float val)
{
    BEGIN_WRAP
    ptr->setP(val);
    END_WRAP
}

#pragma endregion

#pragma region bm3d_image_denoising.hpp

CVAPI(ExceptionStatus) xphoto_bm3dDenoising1(
    cv::_InputArray *src,
    cv::_InputOutputArray *dstStep1,
    cv::_OutputArray *dstStep2,
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
    BEGIN_WRAP
    cv::xphoto::bm3dDenoising(
        *src, *dstStep1, *dstStep2, h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, 
        groupSize, slidingStep, beta, normType, step, transformType);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_bm3dDenoising2(
    cv::_InputArray *src,
    cv::_OutputArray *dst,
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
    BEGIN_WRAP
    cv::xphoto::bm3dDenoising(
        *src, *dst, h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, 
        groupSize, slidingStep, beta, normType, step, transformType);
    END_WRAP
}

#pragma endregion

#pragma region dct_image_denoising.hpp

CVAPI(ExceptionStatus) xphoto_dctDenoising(cv::Mat *src, cv::Mat *dst, const double sigma, const int psize)
{
    BEGIN_WRAP
    cv::xphoto::dctDenoising(*src, *dst, sigma, psize);
    END_WRAP
}

#pragma endregion

#pragma region oilpainting.hpp

CVAPI(ExceptionStatus) xphoto_oilPainting(cv::_InputArray *src, cv::_OutputArray *dst, int size, int dynRatio, int code)
{
    BEGIN_WRAP
    cv::xphoto::oilPainting(*src, *dst, size, dynRatio, code);
    END_WRAP
}

#pragma endregion

#pragma region tonemap.hpp

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getSaturation(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSaturation();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setSaturation(cv::xphoto::TonemapDurand *obj, float saturation)
{
    BEGIN_WRAP
    obj->setSaturation(saturation);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getContrast(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getContrast();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setContrast(cv::xphoto::TonemapDurand *obj, float contrast)
{
    BEGIN_WRAP
    obj->setContrast(contrast);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getSigmaSpace(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSigmaSpace();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setSigmaSpace(cv::xphoto::TonemapDurand *obj, float sigma_space)
{
    BEGIN_WRAP
    obj->setSigmaSpace(sigma_space);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_TonemapDurand_getSigmaColor(cv::xphoto::TonemapDurand *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSigmaColor();
    END_WRAP
}
CVAPI(ExceptionStatus) xphoto_TonemapDurand_setSigmaColor(cv::xphoto::TonemapDurand *obj, float sigma_color)
{
    BEGIN_WRAP
    obj->setSigmaColor(sigma_color);
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_createTonemapDurand(
    float gamma, float contrast, float saturation, float sigma_space, float sigma_color, cv::Ptr<cv::xphoto::TonemapDurand> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::xphoto::createTonemapDurand(gamma, contrast, saturation, sigma_space, sigma_color);
    *returnValue = clone(p);
    END_WRAP  
}

CVAPI(ExceptionStatus) xphoto_Ptr_TonemapDurand_delete(cv::Ptr<cv::xphoto::TonemapDurand> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) xphoto_Ptr_TonemapDurand_get(cv::Ptr<cv::xphoto::TonemapDurand> *ptr, cv::xphoto::TonemapDurand **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#endif