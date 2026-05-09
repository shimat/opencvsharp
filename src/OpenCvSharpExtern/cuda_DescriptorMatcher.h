#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudafeatures2d.hpp>


CVAPI(ExceptionStatus) cuda_DescriptorMatcher_create(
    int normType, cv::Ptr<cv::cuda::DescriptorMatcher> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::DescriptorMatcher::createBFMatcher(normType);
    *returnValue = new cv::Ptr<cv::cuda::DescriptorMatcher>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_get(cv::Ptr<cv::cuda::DescriptorMatcher> *ptr, cv::cuda::DescriptorMatcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_delete(cv::Ptr<cv::cuda::DescriptorMatcher> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_isMaskSupported(cv::cuda::DescriptorMatcher *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->isMaskSupported() ? 1 : 0;
    END_WRAP
}



CVAPI(ExceptionStatus) cuda_DescriptorMatcher_clear(cv::cuda::DescriptorMatcher *obj)
{
    BEGIN_WRAP
    obj->clear();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_train(cv::cuda::DescriptorMatcher *obj)
{
    BEGIN_WRAP
    obj->train();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_add(cv::cuda::DescriptorMatcher *obj, cv::cuda::GpuMat **descriptors, int descriptorLength)
{
    BEGIN_WRAP
    std::vector<cv::cuda::GpuMat> descriptorsVec(descriptorLength);
    for (int i = 0; i < descriptorLength; i++)
        descriptorsVec[i] = *descriptors[i];
    obj->add(descriptorsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_getTrainDescriptors(cv::cuda::DescriptorMatcher *obj, std::vector<cv::cuda::GpuMat> *dst)
{
    BEGIN_WRAP
    *dst = obj->getTrainDescriptors();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_match1(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors,
    cv::_InputArray *trainDescriptors, std::vector<cv::DMatch> *matches, cv::_InputArray *mask)
{
    BEGIN_WRAP
    obj->match(*queryDescriptors, *trainDescriptors, *matches, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_knnMatch1(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors,
    cv::_InputArray *trainDescriptors, std::vector<std::vector<cv::DMatch>> *matches, int k,
    cv::_InputArray *mask, int compactResult)
{
    BEGIN_WRAP
    obj->knnMatch(*queryDescriptors, *trainDescriptors, *matches, k, entity(mask), compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_radiusMatch1(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors,
    cv::_InputArray *trainDescriptors, std::vector<std::vector<cv::DMatch>> *matches, float maxDistance,
    cv::_InputArray *mask, int compactResult)
{
    BEGIN_WRAP
    obj->radiusMatch(*queryDescriptors, *trainDescriptors, *matches, maxDistance, entity(mask), compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_match2(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors, std::vector<cv::DMatch> *matches,
    cv::cuda::GpuMat **masks, int masksSize)
{
    BEGIN_WRAP
    std::vector<cv::cuda::GpuMat> masksVal;
    if (masksSize != 0)
    {
        masksVal = std::vector<cv::cuda::GpuMat>(masksSize);
        for (int i = 0; i < masksSize; i++)
        {
            masksVal[i] = *(masks[i]);
        }
    }
    obj->match(*queryDescriptors, *matches, masksVal);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_knnMatch2(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors, std::vector<std::vector<cv::DMatch>> *matches,
    int k, cv::cuda::GpuMat **masks, int masksSize, int compactResult)
{
    BEGIN_WRAP
    std::vector<cv::cuda::GpuMat> masksVal;
    if (masksSize != 0)
    {
        masksVal = std::vector<cv::cuda::GpuMat>(masksSize);
        for (int i = 0; i < masksSize; i++)
        {
            masksVal[i] = *(masks[i]);
        }
    }
    obj->knnMatch(*queryDescriptors, *matches, k, masksVal, compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_radiusMatch2(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors, std::vector<std::vector<cv::DMatch>> *matches,
    float maxDistance, cv::cuda::GpuMat **masks, int masksSize, int compactResult)
{
    BEGIN_WRAP
    std::vector<cv::cuda::GpuMat> masksVal;
    if (masksSize != 0)
    {
        masksVal = std::vector<cv::cuda::GpuMat>(masksSize);
        for (int i = 0; i < masksSize; i++)
        {
            masksVal[i] = *(masks[i]);
        }
    }
    obj->radiusMatch(*queryDescriptors, *matches, maxDistance, masksVal, compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_matchAsync1(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors,
    cv::_InputArray *trainDescriptors, cv::_OutputArray *matches, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->matchAsync(*queryDescriptors, *trainDescriptors, *matches, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_matchAsync2(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors, cv::_OutputArray *matches,
    cv::cuda::GpuMat **masks, int maskCount, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    std::vector<cv::cuda::GpuMat> masksVec;
    if (masks != nullptr)
        for (int i = 0; i < maskCount; i++)
            masksVec.push_back(*masks[i]);
    obj->matchAsync(*queryDescriptors, *matches, masksVec, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_knnMatchAsync1(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors,
    cv::_InputArray *trainDescriptors, cv::_OutputArray *matches, int k,
    cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->knnMatchAsync(*queryDescriptors, *trainDescriptors, *matches, k, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_knnMatchAsync2(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors, cv::_OutputArray *matches,
    int k, cv::cuda::GpuMat **masks, int maskCount, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    std::vector<cv::cuda::GpuMat> masksVec;
    for (int i = 0; i < maskCount; i++)
        masksVec.push_back(*masks[i]);
    obj->knnMatchAsync(*queryDescriptors, *matches, k, masksVec, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_radiusMatchAsync1(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors,
    cv::_InputArray *trainDescriptors, cv::_OutputArray *matches, float maxDistance,
    cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->radiusMatchAsync(*queryDescriptors, *trainDescriptors, *matches, maxDistance, entity(mask), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_radiusMatchAsync2(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *queryDescriptors, cv::_OutputArray *matches,
    float maxDistance, cv::cuda::GpuMat **masks, int maskCount, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    std::vector<cv::cuda::GpuMat> masksVec;
    if (masks != nullptr)
        for (int i = 0; i < maskCount; i++)
            masksVec.push_back(*masks[i]);
    obj->radiusMatchAsync(*queryDescriptors, *matches, maxDistance, masksVec, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_matchConvert(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *gpu_matches, std::vector<cv::DMatch> *matches)
{
    BEGIN_WRAP
    obj->matchConvert(*gpu_matches, *matches);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_knnMatchConvert(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *gpu_matches, std::vector<std::vector<cv::DMatch>> *matches, int compactResult)
{
    BEGIN_WRAP
    obj->knnMatchConvert(*gpu_matches, *matches, compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DescriptorMatcher_radiusMatchConvert(
    cv::cuda::DescriptorMatcher *obj, cv::_InputArray *gpu_matches, std::vector<std::vector<cv::DMatch>> *matches, int compactResult)
{
    BEGIN_WRAP
    obj->radiusMatchConvert(*gpu_matches, *matches, compactResult != 0);
    END_WRAP
}
