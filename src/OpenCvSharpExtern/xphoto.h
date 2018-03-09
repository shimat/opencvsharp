#ifndef _CPP_XPHOTO_H_
#define _CPP_XPHOTO_H_

#include "include_opencv.h"

#pragma region Inpainting

CVAPI(void) xphoto_inpaint(cv::Mat *src, cv::Mat *mask, cv::Mat *dst, const cv::xphoto::InpaintTypes algorithm)
{
    cv::xphoto::inpaint(*src, *mask, *dst, algorithm);
}

#pragma endregion

#pragma region WhiteBalance

CVAPI(void) xphoto_applyChannelGains(cv::_InputArray *src, cv::_OutputArray *dst, float gainB, float gainG, float gainR)
{
    cv::xphoto::applyChannelGains(*src, *dst, gainB, gainG, gainR);
}

CVAPI(cv::Ptr<cv::xphoto::GrayworldWB>*) xphoto_createGrayworldWB()
{
    cv::Ptr<cv::xphoto::GrayworldWB> ptr = cv::xphoto::createGrayworldWB();
    return new cv::Ptr<cv::xphoto::GrayworldWB>(ptr);
}

CVAPI(void) xphoto_Ptr_GrayworldWB_delete(cv::Ptr<cv::xphoto::GrayworldWB> *obj)
{
    delete obj;
}
CVAPI(cv::xphoto::GrayworldWB*) xphoto_Ptr_GrayworldWB_get(cv::Ptr<cv::xphoto::GrayworldWB>* ptr)
{
    return ptr->get();
}

CVAPI(void) xphoto_GrayworldWB_balanceWhite(cv::xphoto::GrayworldWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    return ptr->balanceWhite(*src, *dst);
}

CVAPI(float) xphoto_GrayworldWB_SaturationThreshold_get(cv::xphoto::GrayworldWB* ptr)
{
    return ptr->getSaturationThreshold();
}
CVAPI(void) xphoto_GrayworldWB_SaturationThreshold_set(cv::xphoto::GrayworldWB* ptr, float val)
{
    ptr->setSaturationThreshold(val);
}

CVAPI(cv::Ptr<cv::xphoto::LearningBasedWB>*) xphoto_createLearningBasedWB(const char* path_to_model)
{
    std::string str_path_to_model(path_to_model);
    cv::Ptr<cv::xphoto::LearningBasedWB> ptr = cv::xphoto::createLearningBasedWB(str_path_to_model);
    return new cv::Ptr<cv::xphoto::LearningBasedWB>(ptr);
}

CVAPI(void) xphoto_Ptr_LearningBasedWB_delete(cv::Ptr<cv::xphoto::LearningBasedWB> *obj)
{
    delete obj;
}
CVAPI(cv::xphoto::LearningBasedWB*) xphoto_Ptr_LearningBasedWB_get(cv::Ptr<cv::xphoto::LearningBasedWB>* ptr)
{
    return ptr->get();
}

CVAPI(void) xphoto_LearningBasedWB_balanceWhite(cv::xphoto::LearningBasedWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    return ptr->balanceWhite(*src, *dst);
}

CVAPI(void) xphoto_LearningBasedWB_extractSimpleFeatures(cv::xphoto::LearningBasedWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    return ptr->extractSimpleFeatures(*src, *dst);
}

CVAPI(int) xphoto_LearningBasedWB_RangeMaxVal_get(cv::xphoto::LearningBasedWB* ptr)
{
    return ptr->getRangeMaxVal();
}
CVAPI(void) xphoto_LearningBasedWB_RangeMaxVal_set(cv::xphoto::LearningBasedWB* ptr, int val)
{
    ptr->setRangeMaxVal(val);
}

CVAPI(float) xphoto_LearningBasedWB_SaturationThreshold_get(cv::xphoto::LearningBasedWB* ptr)
{
    return ptr->getSaturationThreshold();
}
CVAPI(void) xphoto_LearningBasedWB_SaturationThreshold_set(cv::xphoto::LearningBasedWB* ptr, float val)
{
    ptr->setSaturationThreshold(val);
}

CVAPI(int) xphoto_LearningBasedWB_HistBinNum_get(cv::xphoto::LearningBasedWB* ptr)
{
    return ptr->getHistBinNum();
}
CVAPI(void) xphoto_LearningBasedWB_HistBinNum_set(cv::xphoto::LearningBasedWB* ptr, int val)
{
    ptr->setHistBinNum(val);
}

CVAPI(cv::Ptr<cv::xphoto::SimpleWB>*) xphoto_createSimpleWB()
{
    cv::Ptr<cv::xphoto::SimpleWB> ptr = cv::xphoto::createSimpleWB();
    return new cv::Ptr<cv::xphoto::SimpleWB>(ptr);
}

CVAPI(void) xphoto_Ptr_SimpleWB_delete(cv::Ptr<cv::xphoto::SimpleWB> *obj)
{
    delete obj;
}
CVAPI(cv::xphoto::SimpleWB*) xphoto_Ptr_SimpleWB_get(cv::Ptr<cv::xphoto::SimpleWB>* ptr)
{
    return ptr->get();
}

CVAPI(void) xphoto_SimpleWB_balanceWhite(cv::xphoto::SimpleWB* ptr, cv::_InputArray *src, cv::_OutputArray *dst)
{
    return ptr->balanceWhite(*src, *dst);
}

CVAPI(float) xphoto_SimpleWB_InputMax_get(cv::xphoto::SimpleWB* ptr)
{
    return ptr->getInputMax();
}
CVAPI(void) xphoto_SimpleWB_InputMax_set(cv::xphoto::SimpleWB* ptr, float val)
{
    ptr->setInputMax(val);
}

CVAPI(float) xphoto_SimpleWB_InputMin_get(cv::xphoto::SimpleWB* ptr)
{
    return ptr->getInputMin();
}
CVAPI(void) xphoto_SimpleWB_InputMin_set(cv::xphoto::SimpleWB* ptr, float val)
{
    ptr->setInputMin(val);
}

CVAPI(float) xphoto_SimpleWB_OutputMax_get(cv::xphoto::SimpleWB* ptr)
{
    return ptr->getOutputMax();
}
CVAPI(void) xphoto_SimpleWB_OutputMax_set(cv::xphoto::SimpleWB* ptr, float val)
{
    ptr->setOutputMax(val);
}

CVAPI(float) xphoto_SimpleWB_OutputMin_get(cv::xphoto::SimpleWB* ptr)
{
    return ptr->getOutputMin();
}
CVAPI(void) xphoto_SimpleWB_OutputMin_set(cv::xphoto::SimpleWB* ptr, float val)
{
    ptr->setOutputMin(val);
}

CVAPI(float) xphoto_SimpleWB_P_get(cv::xphoto::SimpleWB* ptr)
{
    return ptr->getP();
}
CVAPI(void) xphoto_SimpleWB_P_set(cv::xphoto::SimpleWB* ptr, float val)
{
    ptr->setP(val);
}

#pragma endregion

#pragma region Denoising

CVAPI(void) xphoto_dctDenoising(const cv::Mat *src, cv::Mat *dst, const double sigma, const int psize)
{
    cv::xphoto::dctDenoising(*src, *dst, sigma, psize);
}

CVAPI(void) xphoto_bm3dDenoising1(
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
    cv::xphoto::bm3dDenoising(*src, *dstStep1, *dstStep2, h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, groupSize, slidingStep, beta, normType, step, transformType);
}

CVAPI(void) xphoto_bm3dDenoising2(
    cv::_InputArray *src,
    cv::_OutputArray *dst,
    float h,
    int templateWindowSize,
    int searchWindowSize,
    int blockMatchingStep1 ,
    int blockMatchingStep2 ,
    int groupSize,
    int slidingStep,
    float beta,
    int normType,
    int step,
    int transformType)
{
    cv::xphoto::bm3dDenoising(*src, *dst, h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, groupSize, slidingStep, beta, normType, step, transformType);
}

#pragma endregion

#endif