#ifndef _CPP_IMGPROC_CLAHE_H_
#define _CPP_IMGPROC_CLAHE_H_

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_createCLAHE(double clipLimit, MyCvSize tileGridSize, cv::Ptr<cv::CLAHE> **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::createCLAHE(clipLimit, cpp(tileGridSize));
    *returnValue = clone(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Ptr_CLAHE_delete(cv::Ptr<cv::CLAHE> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Ptr_CLAHE_get(cv::Ptr<cv::CLAHE> *obj, cv::CLAHE **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_CLAHE_apply(cv::CLAHE *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->apply(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_CLAHE_setClipLimit(cv::CLAHE *obj, double clipLimit)
{
    BEGIN_WRAP
    obj->setClipLimit(clipLimit);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_CLAHE_getClipLimit(cv::CLAHE *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getClipLimit();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_CLAHE_setTilesGridSize(cv::CLAHE *obj, MyCvSize tileGridSize)
{
    BEGIN_WRAP
    obj->setTilesGridSize(cpp(tileGridSize));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_CLAHE_getTilesGridSize(cv::CLAHE *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getTilesGridSize());
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_CLAHE_collectGarbage(cv::CLAHE *obj)
{
    BEGIN_WRAP
    obj->collectGarbage();
    END_WRAP
}

#endif