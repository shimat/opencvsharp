#ifndef _CPP_FEATURES2D_ORB_H_
#define _CPP_FEATURES2D_ORB_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::ORB>*) features2d_ORB_create(
    int nFeatures, float scaleFactor, int nlevels, int edgeThreshold,
    int firstLevel, int wtaK, int scoreType, int patchSize)
{
    cv::Ptr<cv::ORB> ptr = cv::ORB::create(
        nFeatures, scaleFactor, nlevels, edgeThreshold, firstLevel, wtaK, scoreType, patchSize);
    return new cv::Ptr<cv::ORB>(ptr);
}
CVAPI(void) features2d_Ptr_ORB_delete(cv::Ptr<cv::ORB> *ptr)
{
    delete ptr;
}

CVAPI(cv::ORB*) features2d_Ptr_ORB_get(cv::Ptr<cv::ORB> *ptr)
{
    return ptr->get();
}


CVAPI(void) features2d_ORB_setMaxFeatures(cv::ORB *obj, int val)
{
    obj->setMaxFeatures(val);
}
CVAPI(int) features2d_ORB_getMaxFeatures(cv::ORB *obj)
{
    return obj->getMaxFeatures();
}

CVAPI(void) features2d_ORB_setScaleFactor(cv::ORB *obj, double val)
{
    obj->setScaleFactor(val);
}
CVAPI(double) features2d_ORB_getScaleFactor(cv::ORB *obj)
{
    return obj->getScaleFactor();
}

CVAPI(void) features2d_ORB_setNLevels(cv::ORB *obj, int val)
{
    obj->setNLevels(val);
}
CVAPI(int) features2d_ORB_getNLevels(cv::ORB *obj)
{
    return obj->getNLevels();
}

CVAPI(void) features2d_ORB_setEdgeThreshold(cv::ORB *obj, int val)
{
    obj->setEdgeThreshold(val);
}
CVAPI(int) features2d_ORB_getEdgeThreshold(cv::ORB *obj)
{
    return obj->getEdgeThreshold();
}

CVAPI(void) features2d_ORB_setFirstLevel(cv::ORB *obj, int val)
{
    obj->setFirstLevel(val);
}
CVAPI(int) features2d_ORB_getFirstLevel(cv::ORB *obj)
{
    return obj->getFirstLevel();
}

CVAPI(void) features2d_ORB_setWTA_K(cv::ORB *obj, int val)
{
    obj->setWTA_K(val);
}
CVAPI(int) features2d_ORB_getWTA_K(cv::ORB *obj)
{
    return obj->getWTA_K();
}

CVAPI(void) features2d_ORB_setScoreType(cv::ORB *obj, int val)
{
    obj->setScoreType(val);
}
CVAPI(int) features2d_ORB_getScoreType(cv::ORB *obj)
{
    return obj->getScoreType();
}

CVAPI(void) features2d_ORB_setPatchSize(cv::ORB *obj, int val)
{
    obj->setPatchSize(val);
}
CVAPI(int) features2d_ORB_getPatchSize(cv::ORB *obj)
{
    return obj->getPatchSize();
}

CVAPI(void) features2d_ORB_setFastThreshold(cv::ORB *obj, int val)
{
    obj->setFastThreshold(val);
}
CVAPI(int) features2d_ORB_getFastThreshold(cv::ORB *obj)
{
    return obj->getFastThreshold();
}

#endif