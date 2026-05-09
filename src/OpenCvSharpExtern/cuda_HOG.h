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

CVAPI(ExceptionStatus) cuda_createHOG(
    cv::Size win_size, cv::Size block_size, cv::Size block_stride, cv::Size cell_size, int nbins,
    cv::Ptr<cv::cuda::HOG> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::HOG::create(win_size, block_size, block_stride, cell_size, nbins);
    *returnValue = new cv::Ptr<cv::cuda::HOG>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_get(cv::Ptr<cv::cuda::HOG> *ptr, cv::cuda::HOG **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_delete(cv::Ptr<cv::cuda::HOG> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_compute(
    cv::cuda::HOG *obj, cv::_InputArray *img, cv::_OutputArray *descriptors, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->compute(*img, *descriptors, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_detect(cv::cuda::HOG *obj, cv::_InputArray *img, std::vector<cv::Point> *found_locations, std::vector<double> *confidences)
{
    BEGIN_WRAP
    if (confidences != nullptr)
    {
        obj->detect(*img, *found_locations, confidences);
    }
    else
    {
        obj->detect(*img, *found_locations);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_detectMultiScale( cv::cuda::HOG *obj, cv::_InputArray *img, std::vector<cv::Rect> *found_locations, std::vector<double> *confidences)
{
    BEGIN_WRAP
    if (confidences != nullptr)
    {
        obj->detectMultiScale(*img, *found_locations, confidences);
    }
    else
    {
        obj->detectMultiScale(*img, *found_locations);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getBlockHistogramSize(cv::cuda::HOG *obj, size_t *val)
{
    BEGIN_WRAP
    *val = obj->getBlockHistogramSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getDefaultPeopleDetector(cv::cuda::HOG *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Mat detector = obj->getDefaultPeopleDetector();
    *returnValue = new cv::Mat(detector);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getDescriptorFormat(cv::cuda::HOG *obj, int *val)
{
    BEGIN_WRAP
    *val = static_cast<int>(obj->getDescriptorFormat());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_setDescriptorFormat(cv::cuda::HOG *obj, int val)
{
    BEGIN_WRAP
    // We cast the incoming int to the specific HOG enum type
    obj->setDescriptorFormat(static_cast<cv::HOGDescriptor::DescriptorStorageFormat>(val));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getDescriptorSize(cv::cuda::HOG *obj, size_t *val)
{
    BEGIN_WRAP
    *val = obj->getDescriptorSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getGammaCorrection(cv::cuda::HOG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getGammaCorrection() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setGammaCorrection(cv::cuda::HOG *obj, int val)
{
    BEGIN_WRAP
    obj->setGammaCorrection(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getGroupThreshold(cv::cuda::HOG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getGroupThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setGroupThreshold(cv::cuda::HOG *obj, int val)
{
    BEGIN_WRAP
    obj->setGroupThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getHitThreshold(cv::cuda::HOG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getHitThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setHitThreshold(cv::cuda::HOG *obj, double val)
{
    BEGIN_WRAP
    obj->setHitThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getL2HysThreshold(cv::cuda::HOG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getL2HysThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setL2HysThreshold(cv::cuda::HOG *obj, double val)
{
    BEGIN_WRAP
    obj->setL2HysThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getNumLevels(cv::cuda::HOG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumLevels();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setNumLevels(cv::cuda::HOG *obj, int val)
{
    BEGIN_WRAP
    obj->setNumLevels(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getScaleFactor(cv::cuda::HOG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getScaleFactor();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setScaleFactor(cv::cuda::HOG *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleFactor(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getWinSigma(cv::cuda::HOG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getWinSigma();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setWinSigma(cv::cuda::HOG *obj, double val)
{
    BEGIN_WRAP
    obj->setWinSigma(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_getWinStride(cv::cuda::HOG *obj, cv::Size *val)
{
    BEGIN_WRAP
    *val = obj->getWinStride();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HOG_setWinStride(cv::cuda::HOG *obj, cv::Size val)
{
    BEGIN_WRAP
    obj->setWinStride(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HOG_setSVMDetector(cv::cuda::HOG *obj, cv::_InputArray *detector)
{
    BEGIN_WRAP
    obj->setSVMDetector(*detector);
    END_WRAP
}
