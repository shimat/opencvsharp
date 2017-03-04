#ifndef _CPP_IMGPROC_CLAHE_H_
#define _CPP_IMGPROC_CLAHE_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::CLAHE>*) imgproc_createCLAHE(double clipLimit, MyCvSize tileGridSize)
{
    cv::Ptr<cv::CLAHE> ret = cv::createCLAHE(clipLimit, cpp(tileGridSize));
    return clone(ret);
}

CVAPI(void) imgproc_Ptr_CLAHE_delete(cv::Ptr<cv::CLAHE> *obj)
{
    delete obj;
}

CVAPI(cv::CLAHE*) imgproc_Ptr_CLAHE_get(cv::Ptr<cv::CLAHE> *obj)
{
    return obj->get();
}


CVAPI(void) imgproc_CLAHE_apply(cv::CLAHE *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    obj->apply(*src, *dst);
}

CVAPI(void) imgproc_CLAHE_setClipLimit(cv::CLAHE *obj, double clipLimit)
{
    obj->setClipLimit(clipLimit);
}

CVAPI(double) imgproc_CLAHE_getClipLimit(cv::CLAHE *obj)
{
    return obj->getClipLimit();
}

CVAPI(void) imgproc_CLAHE_setTilesGridSize(cv::CLAHE *obj, MyCvSize tileGridSize)
{
    obj->setTilesGridSize(cpp(tileGridSize));
}

CVAPI(MyCvSize) imgproc_CLAHE_getTilesGridSize(cv::CLAHE *obj)
{
    return c(obj->getTilesGridSize());
}

CVAPI(void) imgproc_CLAHE_collectGarbage(cv::CLAHE *obj)
{
    obj->collectGarbage();
}

#endif