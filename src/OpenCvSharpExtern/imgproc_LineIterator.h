#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_LineIterator_new(
    cv::Mat *img, interop::Point pt1, interop::Point pt2, int connectivity, int leftToRight, cv::LineIterator** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::LineIterator(*img, cpp(pt1), cpp(pt2), connectivity, leftToRight != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_delete(cv::LineIterator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_getValuePosAndShiftToNext(cv::LineIterator* obj, uchar** returnValue, interop::Point *returnPos)
{
    return cvTry([&] {
        *returnValue = **obj;
        *returnPos = c(obj->pos());
        (*obj)++;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_ptr_get(cv::LineIterator *obj, uchar **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->ptr;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_ptr0_get(cv::LineIterator *obj, const uchar** returnValue)
{
    return cvTry([&] {
        *returnValue = obj->ptr0;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_step_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->step;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_elemSize_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->elemSize;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_err_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->err;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_count_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->count;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_minusDelta_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->minusDelta;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_plusDelta_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->plusDelta;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_minusStep_get(cv::LineIterator *obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->minusStep;
    });
}

CVAPI(ExceptionStatus) imgproc_LineIterator_plusStep_get(cv::LineIterator *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->plusStep;
    });
}