#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaobjdetect.hpp>

CVAPI(ExceptionStatus) cuda_createCascadeClassifier(const char *filename, cv::Ptr<cv::cuda::CascadeClassifier> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::CascadeClassifier::create(cv::String(filename));
    *returnValue = new cv::Ptr<cv::cuda::CascadeClassifier>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_get(cv::Ptr<cv::cuda::CascadeClassifier> *ptr, cv::cuda::CascadeClassifier **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_delete(cv::Ptr<cv::cuda::CascadeClassifier> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_detectMultiScale( cv::cuda::CascadeClassifier *obj, cv::_InputArray *image,  cv::_OutputArray *objects, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detectMultiScale(*image, *objects, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_convert(cv::cuda::CascadeClassifier *obj, cv::_OutputArray *gpu_objects, cv::Rect **outRects, int *outCount)
{
    BEGIN_WRAP
    std::vector<cv::Rect> objects;
    obj->convert(*gpu_objects, objects);

    *outCount = static_cast<int>(objects.size());
    if (*outCount > 0)
    {
        *outRects = new cv::Rect[*outCount];
        std::copy(objects.begin(), objects.end(), *outRects);
    }
    else
    {
        *outRects = nullptr;
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FreeRectArray(cv::Rect *rects)
{
    BEGIN_WRAP
    delete[] rects;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_CascadeClassifier_getClassifierSize(cv::cuda::CascadeClassifier *obj, cv::Size *val)
{
    BEGIN_WRAP
    *val = obj->getClassifierSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_getFindLargestObject(cv::cuda::CascadeClassifier *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getFindLargestObject() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_setFindLargestObject(cv::cuda::CascadeClassifier *obj, int val)
{
    BEGIN_WRAP
    obj->setFindLargestObject(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_getMaxNumObjects(cv::cuda::CascadeClassifier *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxNumObjects();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_setMaxNumObjects(cv::cuda::CascadeClassifier *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxNumObjects(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_getMaxObjectSize(cv::cuda::CascadeClassifier *obj, cv::Size *val)
{
    BEGIN_WRAP
    *val = obj->getMaxObjectSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_setMaxObjectSize(cv::cuda::CascadeClassifier *obj, cv::Size val)
{
    BEGIN_WRAP
    obj->setMaxObjectSize(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_getMinNeighbors(cv::cuda::CascadeClassifier *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMinNeighbors();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_setMinNeighbors(cv::cuda::CascadeClassifier *obj, int val)
{
    BEGIN_WRAP
    obj->setMinNeighbors(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_getMinObjectSize(cv::cuda::CascadeClassifier *obj, cv::Size *val)
{
    BEGIN_WRAP
    *val = obj->getMinObjectSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_setMinObjectSize(cv::cuda::CascadeClassifier *obj, cv::Size val)
{
    BEGIN_WRAP
    obj->setMinObjectSize(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_getScaleFactor(cv::cuda::CascadeClassifier *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getScaleFactor();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CascadeClassifier_setScaleFactor(cv::cuda::CascadeClassifier *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleFactor(val);
    END_WRAP
}
