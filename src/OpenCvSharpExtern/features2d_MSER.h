#ifndef _CPP_FEATURES2D_MSER_H_
#define _CPP_FEATURES2D_MSER_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::MSER>*) features2d_MSER_create(int delta, int minArea, int maxArea,
    double maxVariation, double minDiversity, int maxEvolution,
    double areaThreshold, double minMargin, int edgeBlurSize)
{
    cv::Ptr<cv::MSER> ptr = cv::MSER::create(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution,
        areaThreshold, minMargin, edgeBlurSize);
    return new cv::Ptr<cv::MSER>(ptr);
}
CVAPI(void) features2d_Ptr_MSER_delete(cv::Ptr<cv::MSER> *ptr)
{
    delete ptr;
}

CVAPI(void) features2d_MSER_detectRegions(
    cv::MSER *obj, cv::_InputArray *image,
    std::vector<std::vector<cv::Point> > *msers,
    std::vector<cv::Rect> *bboxes)
{
    obj->detectRegions(*image, *msers, *bboxes);
}

CVAPI(cv::MSER*) features2d_Ptr_MSER_get(cv::Ptr<cv::MSER> *ptr)
{
    return ptr->get();
}

CVAPI(void) features2d_MSER_setDelta(cv::MSER *obj, int delta)
{
    obj->setDelta(delta);
}
CVAPI(int) features2d_MSER_getDelta(cv::MSER *obj)
{
    return obj->getDelta();
}

CVAPI(void) features2d_MSER_setMinArea(cv::MSER *obj, int minArea)
{
    obj->setMinArea(minArea);
}
CVAPI(int) features2d_MSER_getMinArea(cv::MSER *obj)
{
    return obj->getMinArea();
}

CVAPI(void) features2d_MSER_setMaxArea(cv::MSER *obj, int maxArea)
{
    obj->setMaxArea(maxArea);
}
CVAPI(int) features2d_MSER_getMaxArea(cv::MSER *obj)
{
    return obj->getMaxArea();
}

CVAPI(void) features2d_MSER_setPass2Only(cv::MSER *obj, int f)
{
    obj->setPass2Only(f != 0);
}
CVAPI(int) features2d_MSER_getPass2Only(cv::MSER *obj)
{
    return obj->getPass2Only() ? 1 : 0;
}

#endif