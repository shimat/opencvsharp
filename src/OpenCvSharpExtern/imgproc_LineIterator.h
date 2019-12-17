#ifndef _CPP_IMGPROC_LINEITERATOR_H_
#define _CPP_IMGPROC_LINEITERATOR_H_

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_LineIterator_new(
    cv::Mat *img, MyCvPoint pt1, MyCvPoint pt2, int connectivity, int leftToRight, cv::LineIterator** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::LineIterator(*img, cpp(pt1), cpp(pt2), connectivity, leftToRight != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_LineIterator_delete(cv::LineIterator *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_LineIterator_getValuePosAndShiftToNext(cv::LineIterator* obj, uchar** returnValue, MyCvPoint *returnPos)
{
    BEGIN_WRAP
    *returnValue = **obj;
    *returnPos = c(obj->pos());
    (*obj)++;
    END_WRAP
}

/*CVAPI(ExceptionStatus) imgproc_LineIterator_operatorEntity(cv::LineIterator *obj, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = **obj;
    END_WRAP
}*/

/*CVAPI(ExceptionStatus) imgproc_LineIterator_operatorPP(cv::LineIterator *obj)
{
    BEGIN_WRAP
    (*obj)++;
    END_WRAP
}*/

/*CVAPI(ExceptionStatus) imgproc_LineIterator_pos(cv::LineIterator *obj, MyCvPoint *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->pos());
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_ptr_get(cv::LineIterator *obj, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->ptr;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_ptr_set(cv::LineIterator *obj, uchar *val)
{
    BEGIN_WRAP
    obj->ptr = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_ptr0_get(cv::LineIterator *obj, const uchar** returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->ptr0;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_LineIterator_step_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->step;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_step_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->step = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_elemSize_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->elemSize;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_elemSize_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->elemSize = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_err_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->err;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_err_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->err = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_count_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->count;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_count_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->count = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_minusDelta_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->minusDelta;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_minusDelta_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->minusDelta = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_plusDelta_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->plusDelta;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_plusDelta_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->plusDelta = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_minusStep_get(cv::LineIterator *obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->minusStep;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_minusStep_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->minusStep = val;
    END_WRAP
}*/

CVAPI(ExceptionStatus) imgproc_LineIterator_plusStep_get(cv::LineIterator *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->plusStep;
    END_WRAP
}
/*CVAPI(ExceptionStatus) imgproc_LineIterator_plusStep_set(cv::LineIterator *obj, int val)
{
    BEGIN_WRAP
    obj->plusStep = val;
    END_WRAP
}*/

#endif