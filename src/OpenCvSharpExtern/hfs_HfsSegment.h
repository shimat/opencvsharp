#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) hfs_Ptr_HfsSegment_delete(cv::Ptr<cv::hfs::HfsSegment>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) hfs_Ptr_HfsSegment_get(cv::Ptr<cv::hfs::HfsSegment>* ptr, cv::hfs::HfsSegment** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_create(
    int height, int width,
    float segEgbThresholdI, int minRegionSizeI,
    float segEgbThresholdII, int minRegionSizeII,
    float spatialWeight, int slicSpixelSize, int numSlicIter,
    cv::Ptr<cv::hfs::HfsSegment>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::hfs::HfsSegment::create(
            height, width,
            segEgbThresholdI, minRegionSizeI,
            segEgbThresholdII, minRegionSizeII,
            spatialWeight, slicSpixelSize, numSlicIter);
        *returnValue = new cv::Ptr<cv::hfs::HfsSegment>(ptr);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getSegEgbThresholdI(cv::hfs::HfsSegment* obj, float* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSegEgbThresholdI();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setSegEgbThresholdI(cv::hfs::HfsSegment* obj, float value)
{
    return cvTry([&] {
        obj->setSegEgbThresholdI(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getMinRegionSizeI(cv::hfs::HfsSegment* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMinRegionSizeI();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setMinRegionSizeI(cv::hfs::HfsSegment* obj, int value)
{
    return cvTry([&] {
        obj->setMinRegionSizeI(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getSegEgbThresholdII(cv::hfs::HfsSegment* obj, float* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSegEgbThresholdII();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setSegEgbThresholdII(cv::hfs::HfsSegment* obj, float value)
{
    return cvTry([&] {
        obj->setSegEgbThresholdII(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getMinRegionSizeII(cv::hfs::HfsSegment* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMinRegionSizeII();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setMinRegionSizeII(cv::hfs::HfsSegment* obj, int value)
{
    return cvTry([&] {
        obj->setMinRegionSizeII(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getSpatialWeight(cv::hfs::HfsSegment* obj, float* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSpatialWeight();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setSpatialWeight(cv::hfs::HfsSegment* obj, float value)
{
    return cvTry([&] {
        obj->setSpatialWeight(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getSlicSpixelSize(cv::hfs::HfsSegment* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSlicSpixelSize();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setSlicSpixelSize(cv::hfs::HfsSegment* obj, int value)
{
    return cvTry([&] {
        obj->setSlicSpixelSize(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_getNumSlicIter(cv::hfs::HfsSegment* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumSlicIter();
    });
}
CVAPI(ExceptionStatus) hfs_HfsSegment_setNumSlicIter(cv::hfs::HfsSegment* obj, int value)
{
    return cvTry([&] {
        obj->setNumSlicIter(value);
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_performSegmentGpu(
    cv::hfs::HfsSegment* obj, const interop::InputArrayProxy* src, int ifDraw, cv::Mat** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->performSegmentGpu(InProxy(*src), ifDraw != 0));
    });
}

CVAPI(ExceptionStatus) hfs_HfsSegment_performSegmentCpu(
    cv::hfs::HfsSegment* obj, const interop::InputArrayProxy* src, int ifDraw, cv::Mat** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->performSegmentCpu(InProxy(*src), ifDraw != 0));
    });
}

#endif // NO_CONTRIB
