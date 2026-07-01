#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getBoundingBoxes(
    cv::ximgproc::EdgeBoxes *obj,
    const interop::InputArrayProxy* edge_map,
    const interop::InputArrayProxy* orientation_map,
    std::vector<cv::Rect> *boxes)
{
    return cvTry([&] {
    obj->getBoundingBoxes(InProxy(*edge_map), InProxy(*orientation_map), *boxes);
    });
}

CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getAlpha(cv::ximgproc::EdgeBoxes *obj, float *returnValue)          { return cvTry([&] { *returnValue = obj->getAlpha(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setAlpha(cv::ximgproc::EdgeBoxes *obj, float value)                 { return cvTry([&] { obj->setAlpha(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getBeta(cv::ximgproc::EdgeBoxes *obj, float *returnValue)           { return cvTry([&] { *returnValue = obj->getBeta(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setBeta(cv::ximgproc::EdgeBoxes *obj, float value)                  { return cvTry([&] { obj->setBeta(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getEta(cv::ximgproc::EdgeBoxes *obj, float *returnValue)            { return cvTry([&] { *returnValue = obj->getEta(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setEta(cv::ximgproc::EdgeBoxes *obj, float value)                   { return cvTry([&] { obj->setEta(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMinScore(cv::ximgproc::EdgeBoxes *obj, float *returnValue)       { return cvTry([&] { *returnValue = obj->getMinScore(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMinScore(cv::ximgproc::EdgeBoxes *obj, float value)              { return cvTry([&] { obj->setMinScore(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMaxBoxes(cv::ximgproc::EdgeBoxes *obj, int *returnValue)         { return cvTry([&] { *returnValue = obj->getMaxBoxes(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMaxBoxes(cv::ximgproc::EdgeBoxes *obj, int value)                { return cvTry([&] { obj->setMaxBoxes(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getEdgeMinMag(cv::ximgproc::EdgeBoxes *obj, float *returnValue)     { return cvTry([&] { *returnValue = obj->getEdgeMinMag(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setEdgeMinMag(cv::ximgproc::EdgeBoxes *obj, float value)            { return cvTry([&] { obj->setEdgeMinMag(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getEdgeMergeThr(cv::ximgproc::EdgeBoxes *obj, float *returnValue)   { return cvTry([&] { *returnValue = obj->getEdgeMergeThr(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setEdgeMergeThr(cv::ximgproc::EdgeBoxes *obj, float value)          { return cvTry([&] { obj->setEdgeMergeThr(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getClusterMinMag(cv::ximgproc::EdgeBoxes *obj, float *returnValue)  { return cvTry([&] { *returnValue = obj->getClusterMinMag(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setClusterMinMag(cv::ximgproc::EdgeBoxes *obj, float value)         { return cvTry([&] { obj->setClusterMinMag(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMaxAspectRatio(cv::ximgproc::EdgeBoxes *obj, float *returnValue) { return cvTry([&] { *returnValue = obj->getMaxAspectRatio(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMaxAspectRatio(cv::ximgproc::EdgeBoxes *obj, float value)        { return cvTry([&] { obj->setMaxAspectRatio(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMinBoxArea(cv::ximgproc::EdgeBoxes *obj, float *returnValue)     { return cvTry([&] { *returnValue = obj->getMinBoxArea(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMinBoxArea(cv::ximgproc::EdgeBoxes *obj, float value)            { return cvTry([&] { obj->setMinBoxArea(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getGamma(cv::ximgproc::EdgeBoxes *obj, float *returnValue)          { return cvTry([&] { *returnValue = obj->getGamma(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setGamma(cv::ximgproc::EdgeBoxes *obj, float value)                 { return cvTry([&] { obj->setGamma(value); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getKappa(cv::ximgproc::EdgeBoxes *obj, float *returnValue)          { return cvTry([&] { *returnValue = obj->getKappa(); }); }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setKappa(cv::ximgproc::EdgeBoxes *obj, float value)                 { return cvTry([&] { obj->setKappa(value); }); }


CVAPI(ExceptionStatus) ximgproc_createEdgeBoxes(
    float alpha,
    float beta,
    float eta,
    float minScore,
    int maxBoxes,
    float edgeMinMag,
    float edgeMergeThr,
    float clusterMinMag,
    float maxAspectRatio,
    float minBoxArea,
    float gamma,
    float kappa,
    cv::Ptr<cv::ximgproc::EdgeBoxes> **returnValue)
{
    return cvTry([&] {
    *returnValue = clone(cv::ximgproc::createEdgeBoxes(alpha, beta, eta, minScore, maxBoxes, edgeMinMag, edgeMergeThr,
        clusterMinMag, maxAspectRatio, minBoxArea, gamma, kappa));
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeBoxes_delete(cv::Ptr<cv::ximgproc::EdgeBoxes> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeBoxes_get(cv::Ptr<cv::ximgproc::EdgeBoxes> *ptr, cv::ximgproc::EdgeBoxes **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#endif // NO_CONTRIB
