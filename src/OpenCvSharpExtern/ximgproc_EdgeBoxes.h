#ifndef _CPP_XIMGPROC_EDGEBOXES_H_
#define _CPP_XIMGPROC_EDGEBOXES_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getBoundingBoxes(
    cv::ximgproc::EdgeBoxes *obj, cv::_InputArray *edge_map, 
    cv::_InputArray *orientation_map, std::vector<cv::Rect> *boxes)
{
    BEGIN_WRAP
    obj->getBoundingBoxes(*edge_map, *orientation_map, *boxes);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getAlpha(cv::ximgproc::EdgeBoxes *obj, float *returnValue)          { BEGIN_WRAP *returnValue = obj->getAlpha(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setAlpha(cv::ximgproc::EdgeBoxes *obj, float value)                 { BEGIN_WRAP obj->setAlpha(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getBeta(cv::ximgproc::EdgeBoxes *obj, float *returnValue)           { BEGIN_WRAP *returnValue = obj->getBeta(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setBeta(cv::ximgproc::EdgeBoxes *obj, float value)                  { BEGIN_WRAP obj->setBeta(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getEta(cv::ximgproc::EdgeBoxes *obj, float *returnValue)            { BEGIN_WRAP *returnValue = obj->getEta(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setEta(cv::ximgproc::EdgeBoxes *obj, float value)                   { BEGIN_WRAP obj->setEta(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMinScore(cv::ximgproc::EdgeBoxes *obj, float *returnValue)       { BEGIN_WRAP *returnValue = obj->getMinScore(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMinScore(cv::ximgproc::EdgeBoxes *obj, float value)              { BEGIN_WRAP obj->setMinScore(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMaxBoxes(cv::ximgproc::EdgeBoxes *obj, int *returnValue)         { BEGIN_WRAP *returnValue = obj->getMaxBoxes(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMaxBoxes(cv::ximgproc::EdgeBoxes *obj, int value)                { BEGIN_WRAP obj->setMaxBoxes(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getEdgeMinMag(cv::ximgproc::EdgeBoxes *obj, float *returnValue)     { BEGIN_WRAP *returnValue = obj->getEdgeMinMag(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setEdgeMinMag(cv::ximgproc::EdgeBoxes *obj, float value)            { BEGIN_WRAP obj->setEdgeMinMag(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getEdgeMergeThr(cv::ximgproc::EdgeBoxes *obj, float *returnValue)   { BEGIN_WRAP *returnValue = obj->getEdgeMergeThr(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setEdgeMergeThr(cv::ximgproc::EdgeBoxes *obj, float value)          { BEGIN_WRAP obj->setEdgeMergeThr(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getClusterMinMag(cv::ximgproc::EdgeBoxes *obj, float *returnValue)  { BEGIN_WRAP *returnValue = obj->getClusterMinMag(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setClusterMinMag(cv::ximgproc::EdgeBoxes *obj, float value)         { BEGIN_WRAP obj->setClusterMinMag(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMaxAspectRatio(cv::ximgproc::EdgeBoxes *obj, float *returnValue) { BEGIN_WRAP *returnValue = obj->getMaxAspectRatio(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMaxAspectRatio(cv::ximgproc::EdgeBoxes *obj, float value)        { BEGIN_WRAP obj->setMaxAspectRatio(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getMinBoxArea(cv::ximgproc::EdgeBoxes *obj, float *returnValue)     { BEGIN_WRAP *returnValue = obj->getMinBoxArea(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setMinBoxArea(cv::ximgproc::EdgeBoxes *obj, float value)            { BEGIN_WRAP obj->setMinBoxArea(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getGamma(cv::ximgproc::EdgeBoxes *obj, float *returnValue)          { BEGIN_WRAP *returnValue = obj->getGamma(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setGamma(cv::ximgproc::EdgeBoxes *obj, float value)                 { BEGIN_WRAP obj->setGamma(value); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_getKappa(cv::ximgproc::EdgeBoxes *obj, float *returnValue)          { BEGIN_WRAP *returnValue = obj->getKappa(); END_WRAP }
CVAPI(ExceptionStatus) ximgproc_EdgeBoxes_setKappa(cv::ximgproc::EdgeBoxes *obj, float value)                 { BEGIN_WRAP obj->setKappa(value); END_WRAP }


CVAPI(ExceptionStatus) ximgproc_createEdgeBoxes(
    float alpha,  float beta, float eta, float minScore, int maxBoxes, float edgeMinMag, float edgeMergeThr,
    float clusterMinMag, float maxAspectRatio, float minBoxArea, float gamma, float kappa,
    cv::Ptr<cv::ximgproc::EdgeBoxes> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::createEdgeBoxes(alpha, beta, eta, minScore, maxBoxes, edgeMinMag, edgeMergeThr,
        clusterMinMag, maxAspectRatio, minBoxArea, gamma, kappa));
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeBoxes_delete(cv::Ptr<cv::ximgproc::EdgeBoxes> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeBoxes_get(cv::Ptr<cv::ximgproc::EdgeBoxes> *ptr, cv::ximgproc::EdgeBoxes **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#endif