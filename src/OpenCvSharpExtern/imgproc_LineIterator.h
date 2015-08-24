#ifndef _CPP_IMGPROC_LINEITERATOR_H_
#define _CPP_IMGPROC_LINEITERATOR_H_

#include "include_opencv.h"


CVAPI(cv::LineIterator*) imgproc_LineIterator_new(
    cv::Mat *img, MyCvPoint pt1, MyCvPoint pt2, int connectivity, int leftToRight)
{
    return new cv::LineIterator(*img, cpp(pt1), cpp(pt2), connectivity, leftToRight != 0);
}

CVAPI(void) imgproc_LineIterator_delete(cv::LineIterator *obj)
{
    delete obj;
}

CVAPI(uchar*) imgproc_LineIterator_operatorEntity(cv::LineIterator *obj)
{
    return **obj;
}

CVAPI(void) imgproc_LineIterator_operatorPP(cv::LineIterator *obj)
{
    (*obj)++;
}

CVAPI(MyCvPoint) imgproc_LineIterator_pos(cv::LineIterator *obj)
{
    return c(obj->pos());
}

CVAPI(uchar*) imgproc_LineIterator_ptr_get(cv::LineIterator *obj)
{
    return obj->ptr;
}
CVAPI(void) imgproc_LineIterator_ptr_set(cv::LineIterator *obj, uchar *val)
{
    obj->ptr = val;
}

CVAPI(const uchar*) imgproc_LineIterator_ptr0_get(cv::LineIterator *obj)
{
    return obj->ptr0;
}

CVAPI(int) imgproc_LineIterator_step_get(cv::LineIterator *obj)
{
    return obj->step;
}
CVAPI(void) imgproc_LineIterator_step_set(cv::LineIterator *obj, int val)
{
    obj->step = val;
}

CVAPI(int) imgproc_LineIterator_elemSize_get(cv::LineIterator *obj)
{
    return obj->elemSize;
}
CVAPI(void) imgproc_LineIterator_elemSize_set(cv::LineIterator *obj, int val)
{
    obj->elemSize = val;
}

CVAPI(int) imgproc_LineIterator_err_get(cv::LineIterator *obj)
{
    return obj->err;
}
CVAPI(void) imgproc_LineIterator_err_set(cv::LineIterator *obj, int val)
{
    obj->err = val;
}

CVAPI(int) imgproc_LineIterator_count_get(cv::LineIterator *obj)
{
    return obj->count;
}
CVAPI(void) imgproc_LineIterator_count_set(cv::LineIterator *obj, int val)
{
    obj->count = val;
}

CVAPI(int) imgproc_LineIterator_minusDelta_get(cv::LineIterator *obj)
{
    return obj->minusDelta;
}
CVAPI(void) imgproc_LineIterator_minusDelta_set(cv::LineIterator *obj, int val)
{
    obj->minusDelta = val;
}

CVAPI(int) imgproc_LineIterator_plusDelta_get(cv::LineIterator *obj)
{
    return obj->plusDelta;
}
CVAPI(void) imgproc_LineIterator_plusDelta_set(cv::LineIterator *obj, int val)
{
    obj->plusDelta = val;
}

CVAPI(int) imgproc_LineIterator_minusStep_get(cv::LineIterator *obj)
{
    return obj->minusStep;
}
CVAPI(void) imgproc_LineIterator_minusStep_set(cv::LineIterator *obj, int val)
{
    obj->minusStep = val;
}

CVAPI(int) imgproc_LineIterator_plusStep_get(cv::LineIterator *obj)
{
    return obj->plusStep;
}
CVAPI(void) imgproc_LineIterator_plusStep_set(cv::LineIterator *obj, int val)
{
    obj->plusStep = val;
}

#endif