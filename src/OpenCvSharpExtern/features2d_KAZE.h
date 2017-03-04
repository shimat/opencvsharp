#ifndef _CPP_FEATURES2D_KAZE_H_
#define _CPP_FEATURES2D_KAZE_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::KAZE>*) features2d_KAZE_create(
    bool extended, bool upright, float threshold,
    int nOctaves, int nOctaveLayers, int diffusivity)
{
    cv::Ptr<cv::KAZE> ptr = cv::KAZE::create(
        extended, upright, threshold,
        nOctaves, nOctaveLayers, diffusivity);
    return new cv::Ptr<cv::KAZE>(ptr);
}
CVAPI(void) features2d_Ptr_KAZE_delete(cv::Ptr<cv::KAZE> *ptr)
{
    delete ptr;
}

CVAPI(cv::KAZE*) features2d_Ptr_KAZE_get(cv::Ptr<cv::KAZE> *ptr)
{
    return ptr->get();
}


CVAPI(void) features2d_KAZE_setDiffusivity(cv::KAZE *obj, int val)
{
    obj->setDiffusivity(val);
}
CVAPI(int) features2d_KAZE_getDiffusivity(cv::KAZE *obj)
{
    return obj->getDiffusivity();
}

CVAPI(void) features2d_KAZE_setExtended(cv::KAZE *obj, bool val)
{
    obj->setExtended(val);
}
CVAPI(bool) features2d_KAZE_getExtended(cv::KAZE *obj)
{
    return obj->getExtended();
}

CVAPI(void) features2d_KAZE_setNOctaveLayers(cv::KAZE *obj, int val)
{
    obj->setNOctaveLayers(val);
}
CVAPI(int) features2d_KAZE_getNOctaveLayers(cv::KAZE *obj)
{
    return obj->getNOctaveLayers();
}

CVAPI(void) features2d_KAZE_setNOctaves(cv::KAZE *obj, int val)
{
    obj->setNOctaves(val);
}
CVAPI(int) features2d_KAZE_getNOctaves(cv::KAZE *obj)
{
    return obj->getNOctaves();
}

CVAPI(void) features2d_KAZE_setThreshold(cv::KAZE *obj, double val)
{
    obj->setThreshold(val);
}
CVAPI(double) features2d_KAZE_getThreshold(cv::KAZE *obj)
{
    return obj->getThreshold();
}

CVAPI(void) features2d_KAZE_setUpright(cv::KAZE *obj, bool val)
{
    obj->setUpright(val);
}
CVAPI(bool) features2d_KAZE_getUpright(cv::KAZE *obj)
{
    return obj->getUpright();
}

#endif
