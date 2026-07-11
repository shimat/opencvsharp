#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region DAISY

CVAPI(ExceptionStatus) xfeatures2d_DAISY_create(
    float radius, int qRadius, int qTheta, int qHist, int norm, const interop::InputArrayProxy *h,
    int interpolation, int useOrientation,
    cv::Ptr<cv::xfeatures2d::DAISY> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::DAISY::create(
            radius, qRadius, qTheta, qHist,
            static_cast<cv::xfeatures2d::DAISY::NormalizationType>(norm), InProxy(*h),
            interpolation != 0, useOrientation != 0);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_DAISY_delete(cv::Ptr<cv::xfeatures2d::DAISY> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_DAISY_get(cv::Ptr<cv::xfeatures2d::DAISY> *obj, cv::xfeatures2d::DAISY **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setRadius(cv::xfeatures2d::DAISY *obj, float val)
{
    return cvTry([&] { obj->setRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getRadius(cv::xfeatures2d::DAISY *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setQRadius(cv::xfeatures2d::DAISY *obj, int val)
{
    return cvTry([&] { obj->setQRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getQRadius(cv::xfeatures2d::DAISY *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getQRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setQTheta(cv::xfeatures2d::DAISY *obj, int val)
{
    return cvTry([&] { obj->setQTheta(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getQTheta(cv::xfeatures2d::DAISY *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getQTheta(); });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setQHist(cv::xfeatures2d::DAISY *obj, int val)
{
    return cvTry([&] { obj->setQHist(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getQHist(cv::xfeatures2d::DAISY *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getQHist(); });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setNorm(cv::xfeatures2d::DAISY *obj, int val)
{
    return cvTry([&] { obj->setNorm(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getNorm(cv::xfeatures2d::DAISY *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNorm(); });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setH(cv::xfeatures2d::DAISY *obj, const interop::InputArrayProxy *h)
{
    return cvTry([&] { obj->setH(InProxy(*h)); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getH(cv::xfeatures2d::DAISY *obj, cv::Mat *returnValue)
{
    return cvTry([&] { *returnValue = obj->getH(); });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setInterpolation(cv::xfeatures2d::DAISY *obj, int val)
{
    return cvTry([&] { obj->setInterpolation(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getInterpolation(cv::xfeatures2d::DAISY *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getInterpolation() ? 1 : 0; });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_setUseOrientation(cv::xfeatures2d::DAISY *obj, int val)
{
    return cvTry([&] { obj->setUseOrientation(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_DAISY_getUseOrientation(cv::xfeatures2d::DAISY *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getUseOrientation() ? 1 : 0; });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_compute_roi(
    cv::xfeatures2d::DAISY *obj, const interop::InputArrayProxy *image, interop::Rect roi, const interop::OutputArrayProxy *descriptors)
{
    return cvTry([&] {
        const InProxy imageProxy(*image);
        const cv::Rect roiRect = cpp(roi);
        // DAISY_Impl::compute_descriptors (opencv_contrib xfeatures2d/src/daisy.cpp) indexes its
        // output buffer using absolute image coordinates while sizing the buffer to only
        // roi.width*roi.height rows, so it overflows unless roi covers the entire image. Guard
        // here instead of silently corrupting memory.
        const cv::Size imageSize = static_cast<const cv::_InputArray&>(imageProxy).size();
        if (roiRect.x != 0 || roiRect.y != 0 || roiRect.width != imageSize.width || roiRect.height != imageSize.height)
        {
            CV_Error(cv::Error::StsBadArg,
                "DAISY.Compute(image, roi, descriptors): due to an upstream OpenCV bug, roi must cover "
                "the entire image (x=0, y=0, width=image.Cols, height=image.Rows)");
        }
        obj->compute(static_cast<const cv::_InputArray&>(imageProxy), roiRect, OutProxy(*descriptors));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_compute_dense(
    cv::xfeatures2d::DAISY *obj, const interop::InputArrayProxy *image, const interop::OutputArrayProxy *descriptors)
{
    return cvTry([&] {
        obj->compute(InProxy(*image), OutProxy(*descriptors));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_GetDescriptor1(
    cv::xfeatures2d::DAISY *obj, double y, double x, int orientation, float *descriptor)
{
    return cvTry([&] {
        obj->GetDescriptor(y, x, orientation, descriptor);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_GetDescriptor2(
    cv::xfeatures2d::DAISY *obj, double y, double x, int orientation, float *descriptor, double *h, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->GetDescriptor(y, x, orientation, descriptor, h) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_GetUnnormalizedDescriptor1(
    cv::xfeatures2d::DAISY *obj, double y, double x, int orientation, float *descriptor)
{
    return cvTry([&] {
        obj->GetUnnormalizedDescriptor(y, x, orientation, descriptor);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_DAISY_GetUnnormalizedDescriptor2(
    cv::xfeatures2d::DAISY *obj, double y, double x, int orientation, float *descriptor, double *h, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->GetUnnormalizedDescriptor(y, x, orientation, descriptor, h) ? 1 : 0;
    });
}

#pragma endregion

#endif // NO_CONTRIB
