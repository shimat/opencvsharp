#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// DTFilter

CVAPI(ExceptionStatus) ximgproc_Ptr_DTFilter_delete(
    cv::Ptr<cv::ximgproc::DTFilter>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_DTFilter_get(
    cv::Ptr<cv::ximgproc::DTFilter>* ptr, cv::ximgproc::DTFilter** returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_DTFilter_filter(
    cv::ximgproc::DTFilter* obj,
    cv::_InputArray *src, cv::_OutputArray *dst, int dDepth)
{
    return cvTry([&] {
    obj->filter(*src, *dst, dDepth);
    });
}

CVAPI(ExceptionStatus) ximgproc_createDTFilter(
    cv::_InputArray *guide, double sigmaSpatial, double sigmaColor, int mode, int numIters,
    cv::Ptr<cv::ximgproc::DTFilter>** returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ximgproc::createDTFilter(*guide, sigmaSpatial, sigmaColor, mode, numIters);
    *returnValue = new cv::Ptr<cv::ximgproc::DTFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_dtFilter(
    cv::_InputArray *guide, cv::_InputArray *src, cv::_OutputArray *dst, double sigmaSpatial, double sigmaColor, int mode, int numIters)
{
    return cvTry([&] {
    cv::ximgproc::dtFilter(*guide, *src, *dst, sigmaSpatial, sigmaColor, mode, numIters);
    });
}

//////////////////////////////////////////////////////////////////////////
// GuidedFilter

CVAPI(ExceptionStatus) ximgproc_Ptr_GuidedFilter_delete(
    cv::Ptr<cv::ximgproc::GuidedFilter>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_GuidedFilter_get(
    cv::Ptr<cv::ximgproc::GuidedFilter>* ptr, cv::ximgproc::GuidedFilter** returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_GuidedFilter_filter(
    cv::ximgproc::GuidedFilter* obj,
    cv::_InputArray* src, cv::_OutputArray* dst, int dDepth)
{
    return cvTry([&] {
    obj->filter(*src, *dst, dDepth);
    });
}

CVAPI(ExceptionStatus) ximgproc_createGuidedFilter(
    cv::_InputArray* guide, int radius, double eps, 
    cv::Ptr<cv::ximgproc::GuidedFilter>** returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ximgproc::createGuidedFilter(*guide, radius, eps);
    *returnValue = new cv::Ptr<cv::ximgproc::GuidedFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_guidedFilter(
    cv::_InputArray *guide, cv::_InputArray *src, cv::_OutputArray *dst, int radius, double eps, int dDepth)
{
    return cvTry([&] {
    cv::ximgproc::guidedFilter(*guide, *src, *dst, radius, eps, dDepth);
    });
}

//////////////////////////////////////////////////////////////////////////
// AdaptiveManifoldFilter

CVAPI(ExceptionStatus) ximgproc_Ptr_AdaptiveManifoldFilter_delete(
    cv::Ptr<cv::ximgproc::AdaptiveManifoldFilter>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_AdaptiveManifoldFilter_get(
    cv::Ptr<cv::ximgproc::AdaptiveManifoldFilter>* ptr, cv::ximgproc::AdaptiveManifoldFilter** returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_filter(
    cv::ximgproc::AdaptiveManifoldFilter* obj,
    cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray *joint)
{
    return cvTry([&] {
    obj->filter(*src, *dst, entity(joint));
    });
}

CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_collectGarbage(
    cv::ximgproc::AdaptiveManifoldFilter* obj)
{
    return cvTry([&] {
    obj->collectGarbage();
    });
}

CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_getSigmaS(cv::ximgproc::AdaptiveManifoldFilter* obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSigmaS();
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_setSigmaS(cv::ximgproc::AdaptiveManifoldFilter* obj, double val)
{
    return cvTry([&] {
    obj->setSigmaS(val);
    });    
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_getSigmaR(cv::ximgproc::AdaptiveManifoldFilter* obj, double* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSigmaR();
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_setSigmaR(cv::ximgproc::AdaptiveManifoldFilter* obj, double val)
{
    return cvTry([&] {
    obj->setSigmaR(val);
    });    
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_getTreeHeight(cv::ximgproc::AdaptiveManifoldFilter* obj, int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getTreeHeight();
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_setTreeHeight(cv::ximgproc::AdaptiveManifoldFilter* obj, int val)
{
    return cvTry([&] {
    obj->setTreeHeight(val);
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_getPCAIterations(cv::ximgproc::AdaptiveManifoldFilter* obj, int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPCAIterations();
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_setPCAIterations(cv::ximgproc::AdaptiveManifoldFilter* obj, int val)
{
    return cvTry([&] {
    obj->setPCAIterations(val);
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_getAdjustOutliers(cv::ximgproc::AdaptiveManifoldFilter* obj, int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getAdjustOutliers();
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_setAdjustOutliers(cv::ximgproc::AdaptiveManifoldFilter* obj, int val)
{
    return cvTry([&] {
    obj->setAdjustOutliers(val);
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_getUseRNG(cv::ximgproc::AdaptiveManifoldFilter* obj, int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getUseRNG() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) ximgproc_AdaptiveManifoldFilter_setUseRNG(cv::ximgproc::AdaptiveManifoldFilter* obj, int val)
{
    return cvTry([&] {
    obj->setUseRNG(val != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_createAMFilter(
    double sigma_s, double sigma_r, int adjust_outliers,
    cv::Ptr<cv::ximgproc::AdaptiveManifoldFilter>** returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ximgproc::createAMFilter(sigma_s, sigma_r, adjust_outliers != 0);
    *returnValue = new cv::Ptr<cv::ximgproc::AdaptiveManifoldFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_amFilter(
    cv::_InputArray *joint, cv::_InputArray *src, cv::_OutputArray *dst, double sigma_s, double sigma_r, int adjust_outliers)
{
    return cvTry([&] {
    cv::ximgproc::amFilter(*joint, *src, *dst, sigma_s, sigma_r, adjust_outliers != 0);
    });
}


//////////////////////////////////////////////////////////////////////////

CVAPI(ExceptionStatus) ximgproc_jointBilateralFilter(cv::_InputArray *joint, cv::_InputArray *src, cv::_OutputArray *dst, int d, double sigmaColor, double sigmaSpace, int borderType)
{
    return cvTry([&] {
    cv::ximgproc::jointBilateralFilter(*joint, *src, *dst, d, sigmaColor, sigmaSpace, borderType);
    });
}

CVAPI(ExceptionStatus) ximgproc_bilateralTextureFilter(cv::_InputArray *src, cv::_OutputArray *dst, int fr, int numIter, double sigmaAlpha, double sigmaAvg)
{
    return cvTry([&] {
    cv::ximgproc::bilateralTextureFilter(*src, *dst, fr, numIter, sigmaAlpha, sigmaAvg);
    });
}

CVAPI(ExceptionStatus) ximgproc_rollingGuidanceFilter(cv::_InputArray *src, cv::_OutputArray *dst, int d, double sigmaColor, double sigmaSpace, int numOfIter, int borderType)
{
    return cvTry([&] {
    cv::ximgproc::rollingGuidanceFilter(*src, *dst, d, sigmaColor, sigmaSpace, numOfIter, borderType);
    });
}


//////////////////////////////////////////////////////////////////////////
// FastBilateralSolverFilter 

CVAPI(ExceptionStatus) ximgproc_Ptr_FastBilateralSolverFilter_delete(
    cv::Ptr<cv::ximgproc::FastBilateralSolverFilter>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_FastBilateralSolverFilter_get(
    cv::Ptr<cv::ximgproc::FastBilateralSolverFilter>* ptr, cv::ximgproc::FastBilateralSolverFilter** returnValue)
{
    return cvTry([&] {
    * returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_FastBilateralSolverFilter_filter(
    cv::ximgproc::FastBilateralSolverFilter* obj,
    cv::_InputArray* src, cv::_InputArray *confidence, cv::_OutputArray* dst)
{
    return cvTry([&] {
    obj->filter(*src, *confidence , *dst);
    });
}

CVAPI(ExceptionStatus) ximgproc_createFastBilateralSolverFilter(
    cv::_InputArray *guide, double sigma_spatial, double sigma_luma, double sigma_chroma, double lambda, int num_iter, double max_tol,
    cv::Ptr<cv::ximgproc::FastBilateralSolverFilter>** returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ximgproc::createFastBilateralSolverFilter(*guide, sigma_spatial, sigma_luma, sigma_chroma, lambda, num_iter, max_tol);
    *returnValue = new cv::Ptr<cv::ximgproc::FastBilateralSolverFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_fastBilateralSolverFilter(
    cv::_InputArray *guide, cv::_InputArray *src, cv::_InputArray *confidence, cv::_OutputArray *dst, 
    double sigma_spatial, double sigma_luma, double sigma_chroma, double lambda, int num_iter, double max_tol)
{
    return cvTry([&] {
    cv::ximgproc::fastBilateralSolverFilter(*guide, *src, *confidence, *dst,
        sigma_spatial, sigma_luma, sigma_chroma, lambda, num_iter, max_tol);
    });
}


//////////////////////////////////////////////////////////////////////////
// FastGlobalSmootherFilter 

CVAPI(ExceptionStatus) ximgproc_Ptr_FastGlobalSmootherFilter_delete(
    cv::Ptr<cv::ximgproc::FastGlobalSmootherFilter>* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_FastGlobalSmootherFilter_get(
    cv::Ptr<cv::ximgproc::FastGlobalSmootherFilter>* ptr, cv::ximgproc::FastGlobalSmootherFilter** returnValue)
{
    return cvTry([&] {
    * returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_FastGlobalSmootherFilter_filter(
    cv::ximgproc::FastGlobalSmootherFilter* obj,
    cv::_InputArray* src, cv::_OutputArray* dst)
{
    return cvTry([&] {
    obj->filter(*src, *dst);
    });
}

CVAPI(ExceptionStatus) ximgproc_createFastGlobalSmootherFilter(
    cv::_InputArray *guide, double lambda, double sigma_color, double lambda_attenuation, int num_iter,
    cv::Ptr<cv::ximgproc::FastGlobalSmootherFilter>** returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ximgproc::createFastGlobalSmootherFilter(*guide, lambda, sigma_color, lambda_attenuation, num_iter);
    *returnValue = new cv::Ptr<cv::ximgproc::FastGlobalSmootherFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_fastGlobalSmootherFilter(
    cv::_InputArray *guide, cv::_InputArray *src, cv::_OutputArray *dst, double lambda, double sigma_color, double lambda_attenuation, int num_iter)
{
    return cvTry([&] {
    cv::ximgproc::fastGlobalSmootherFilter(*guide, *src, *dst,
        lambda, sigma_color, lambda_attenuation, num_iter);
    });
}

CVAPI(ExceptionStatus) ximgproc_l0Smooth(cv::_InputArray *src, cv::_OutputArray *dst, double lambda, double kappa)
{
    return cvTry([&] {
    cv::ximgproc::l0Smooth(*src, *dst, lambda, kappa);
    });
}

#endif // NO_CONTRIB
