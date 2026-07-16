#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// SparseMatchInterpolator (base class methods, called via raw pointer obtained from each subclass's _get)

CVAPI(ExceptionStatus) ximgproc_SparseMatchInterpolator_interpolate(
    cv::ximgproc::SparseMatchInterpolator* obj,
    const interop::InputArrayProxy* fromImage,
    const interop::InputArrayProxy* fromPoints,
    const interop::InputArrayProxy* toImage,
    const interop::InputArrayProxy* toPoints,
    const interop::OutputArrayProxy* denseFlow)
{
    return cvTry([&] {
        obj->interpolate(InProxy(*fromImage), InProxy(*fromPoints), InProxy(*toImage), InProxy(*toPoints), OutProxy(*denseFlow));
    });
}

// EdgeAwareInterpolator

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeAwareInterpolator_delete(cv::Ptr<cv::ximgproc::EdgeAwareInterpolator>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeAwareInterpolator_get(cv::Ptr<cv::ximgproc::EdgeAwareInterpolator>* ptr, cv::ximgproc::EdgeAwareInterpolator** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_createEdgeAwareInterpolator(cv::Ptr<cv::ximgproc::EdgeAwareInterpolator>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createEdgeAwareInterpolator();
        *returnValue = new cv::Ptr<cv::ximgproc::EdgeAwareInterpolator>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setCostMap(cv::ximgproc::EdgeAwareInterpolator* obj, cv::Mat* costMap)
{
    return cvTry([&] {
        obj->setCostMap(*costMap);
    });
}

CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setK(cv::ximgproc::EdgeAwareInterpolator* obj, int k)          { return cvTry([&] { obj->setK(k); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_getK(cv::ximgproc::EdgeAwareInterpolator* obj, int* returnValue)   { return cvTry([&] { *returnValue = obj->getK(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setSigma(cv::ximgproc::EdgeAwareInterpolator* obj, float sigma)   { return cvTry([&] { obj->setSigma(sigma); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_getSigma(cv::ximgproc::EdgeAwareInterpolator* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getSigma(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setLambda(cv::ximgproc::EdgeAwareInterpolator* obj, float lambda) { return cvTry([&] { obj->setLambda(lambda); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_getLambda(cv::ximgproc::EdgeAwareInterpolator* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getLambda(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setUsePostProcessing(cv::ximgproc::EdgeAwareInterpolator* obj, int usePostProc) { return cvTry([&] { obj->setUsePostProcessing(usePostProc != 0); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_getUsePostProcessing(cv::ximgproc::EdgeAwareInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getUsePostProcessing() ? 1 : 0; }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setFGSLambda(cv::ximgproc::EdgeAwareInterpolator* obj, float lambda) { return cvTry([&] { obj->setFGSLambda(lambda); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_getFGSLambda(cv::ximgproc::EdgeAwareInterpolator* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getFGSLambda(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_setFGSSigma(cv::ximgproc::EdgeAwareInterpolator* obj, float sigma) { return cvTry([&] { obj->setFGSSigma(sigma); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeAwareInterpolator_getFGSSigma(cv::ximgproc::EdgeAwareInterpolator* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getFGSSigma(); }); }

// RICInterpolator

CVAPI(ExceptionStatus) ximgproc_Ptr_RICInterpolator_delete(cv::Ptr<cv::ximgproc::RICInterpolator>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RICInterpolator_get(cv::Ptr<cv::ximgproc::RICInterpolator>* ptr, cv::ximgproc::RICInterpolator** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_createRICInterpolator(cv::Ptr<cv::ximgproc::RICInterpolator>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createRICInterpolator();
        *returnValue = new cv::Ptr<cv::ximgproc::RICInterpolator>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setK(cv::ximgproc::RICInterpolator* obj, int k)                       { return cvTry([&] { obj->setK(k); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getK(cv::ximgproc::RICInterpolator* obj, int* returnValue)            { return cvTry([&] { *returnValue = obj->getK(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setCostMap(cv::ximgproc::RICInterpolator* obj, cv::Mat* costMap)      { return cvTry([&] { obj->setCostMap(*costMap); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setSuperpixelSize(cv::ximgproc::RICInterpolator* obj, int spSize)     { return cvTry([&] { obj->setSuperpixelSize(spSize); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getSuperpixelSize(cv::ximgproc::RICInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getSuperpixelSize(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setSuperpixelNNCnt(cv::ximgproc::RICInterpolator* obj, int spNN)      { return cvTry([&] { obj->setSuperpixelNNCnt(spNN); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getSuperpixelNNCnt(cv::ximgproc::RICInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getSuperpixelNNCnt(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setSuperpixelRuler(cv::ximgproc::RICInterpolator* obj, float ruler)   { return cvTry([&] { obj->setSuperpixelRuler(ruler); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getSuperpixelRuler(cv::ximgproc::RICInterpolator* obj, float* returnValue) { return cvTry([&] { *returnValue = obj->getSuperpixelRuler(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setSuperpixelMode(cv::ximgproc::RICInterpolator* obj, int mode)       { return cvTry([&] { obj->setSuperpixelMode(mode); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getSuperpixelMode(cv::ximgproc::RICInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getSuperpixelMode(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setAlpha(cv::ximgproc::RICInterpolator* obj, float alpha)             { return cvTry([&] { obj->setAlpha(alpha); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getAlpha(cv::ximgproc::RICInterpolator* obj, float* returnValue)      { return cvTry([&] { *returnValue = obj->getAlpha(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setModelIter(cv::ximgproc::RICInterpolator* obj, int modelIter)       { return cvTry([&] { obj->setModelIter(modelIter); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getModelIter(cv::ximgproc::RICInterpolator* obj, int* returnValue)    { return cvTry([&] { *returnValue = obj->getModelIter(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setRefineModels(cv::ximgproc::RICInterpolator* obj, int refineModels) { return cvTry([&] { obj->setRefineModels(refineModels != 0); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getRefineModels(cv::ximgproc::RICInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getRefineModels() ? 1 : 0; }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setMaxFlow(cv::ximgproc::RICInterpolator* obj, float maxFlow)         { return cvTry([&] { obj->setMaxFlow(maxFlow); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getMaxFlow(cv::ximgproc::RICInterpolator* obj, float* returnValue)    { return cvTry([&] { *returnValue = obj->getMaxFlow(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setUseVariationalRefinement(cv::ximgproc::RICInterpolator* obj, int use) { return cvTry([&] { obj->setUseVariationalRefinement(use != 0); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getUseVariationalRefinement(cv::ximgproc::RICInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getUseVariationalRefinement() ? 1 : 0; }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setUseGlobalSmootherFilter(cv::ximgproc::RICInterpolator* obj, int useFgs) { return cvTry([&] { obj->setUseGlobalSmootherFilter(useFgs != 0); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getUseGlobalSmootherFilter(cv::ximgproc::RICInterpolator* obj, int* returnValue) { return cvTry([&] { *returnValue = obj->getUseGlobalSmootherFilter() ? 1 : 0; }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setFGSLambda(cv::ximgproc::RICInterpolator* obj, float lambda)        { return cvTry([&] { obj->setFGSLambda(lambda); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getFGSLambda(cv::ximgproc::RICInterpolator* obj, float* returnValue)  { return cvTry([&] { *returnValue = obj->getFGSLambda(); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_setFGSSigma(cv::ximgproc::RICInterpolator* obj, float sigma)          { return cvTry([&] { obj->setFGSSigma(sigma); }); }
CVAPI(ExceptionStatus) ximgproc_RICInterpolator_getFGSSigma(cv::ximgproc::RICInterpolator* obj, float* returnValue)   { return cvTry([&] { *returnValue = obj->getFGSSigma(); }); }
