#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// ExposureCompensator

CVAPI(ExceptionStatus) stitching_ExposureCompensator_createDefault(
    int type, cv::Ptr<cv::detail::ExposureCompensator> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::detail::ExposureCompensator::createDefault(type);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_ExposureCompensator_get(
    cv::Ptr<cv::detail::ExposureCompensator> *ptr, cv::detail::ExposureCompensator **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_ExposureCompensator_delete(cv::Ptr<cv::detail::ExposureCompensator> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) stitching_ExposureCompensator_feed(
    cv::detail::ExposureCompensator *obj,
    const interop::Point *corners, int cornersLength,
    cv::Mat **images, int imagesLength,
    cv::Mat **masks, int masksLength)
{
    return cvTry([&] {
        std::vector<cv::Point> cornersVec;
        cornersVec.reserve(cornersLength);
        for (int i = 0; i < cornersLength; i++)
            cornersVec.push_back(cpp(corners[i]));

        std::vector<cv::UMat> imagesVec;
        toUMatVec(images, imagesLength, imagesVec);
        std::vector<cv::UMat> masksVec;
        toUMatVec(masks, masksLength, masksVec);

        obj->feed(cornersVec, imagesVec, masksVec);
    });
}

CVAPI(ExceptionStatus) stitching_ExposureCompensator_apply(
    cv::detail::ExposureCompensator *obj,
    int index,
    interop::Point corner,
    const interop::InputOutputArrayProxy *image,
    const interop::InputArrayProxy *mask)
{
    return cvTry([&] {
        obj->apply(index, cpp(corner), IoProxy(*image), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) stitching_ExposureCompensator_getMatGains(
    cv::detail::ExposureCompensator *obj, std::vector<cv::Mat> *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> gains;
        obj->getMatGains(gains);
        std::copy(gains.begin(), gains.end(), std::back_inserter(*returnValue));
    });
}

CVAPI(ExceptionStatus) stitching_ExposureCompensator_setMatGains(
    cv::detail::ExposureCompensator *obj, cv::Mat **gains, int gainsLength)
{
    return cvTry([&] {
        std::vector<cv::Mat> gainsVec;
        toVec(gains, gainsLength, gainsVec);
        obj->setMatGains(gainsVec);
    });
}

CVAPI(ExceptionStatus) stitching_ExposureCompensator_getUpdateGain(
    cv::detail::ExposureCompensator *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getUpdateGain() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) stitching_ExposureCompensator_setUpdateGain(
    cv::detail::ExposureCompensator *obj, int b)
{
    return cvTry([&] {
        obj->setUpdateGain(b != 0);
    });
}


// NoExposureCompensator

CVAPI(ExceptionStatus) stitching_NoExposureCompensator_new(cv::detail::NoExposureCompensator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::NoExposureCompensator();
    });
}

CVAPI(ExceptionStatus) stitching_NoExposureCompensator_delete(cv::detail::NoExposureCompensator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// GainCompensator

CVAPI(ExceptionStatus) stitching_GainCompensator_new(int nr_feeds, cv::detail::GainCompensator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::GainCompensator(nr_feeds);
    });
}

CVAPI(ExceptionStatus) stitching_GainCompensator_delete(cv::detail::GainCompensator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_GainCompensator_getNrFeeds(cv::detail::GainCompensator *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNrFeeds();
    });
}
CVAPI(ExceptionStatus) stitching_GainCompensator_setNrFeeds(cv::detail::GainCompensator *obj, int nrFeeds)
{
    return cvTry([&] {
        obj->setNrFeeds(nrFeeds);
    });
}
CVAPI(ExceptionStatus) stitching_GainCompensator_getSimilarityThreshold(cv::detail::GainCompensator *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSimilarityThreshold();
    });
}
CVAPI(ExceptionStatus) stitching_GainCompensator_setSimilarityThreshold(cv::detail::GainCompensator *obj, double thresh)
{
    return cvTry([&] {
        obj->setSimilarityThreshold(thresh);
    });
}


// ChannelsCompensator

CVAPI(ExceptionStatus) stitching_ChannelsCompensator_new(int nr_feeds, cv::detail::ChannelsCompensator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::ChannelsCompensator(nr_feeds);
    });
}

CVAPI(ExceptionStatus) stitching_ChannelsCompensator_delete(cv::detail::ChannelsCompensator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_ChannelsCompensator_getNrFeeds(cv::detail::ChannelsCompensator *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNrFeeds();
    });
}
CVAPI(ExceptionStatus) stitching_ChannelsCompensator_setNrFeeds(cv::detail::ChannelsCompensator *obj, int nrFeeds)
{
    return cvTry([&] {
        obj->setNrFeeds(nrFeeds);
    });
}
CVAPI(ExceptionStatus) stitching_ChannelsCompensator_getSimilarityThreshold(cv::detail::ChannelsCompensator *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSimilarityThreshold();
    });
}
CVAPI(ExceptionStatus) stitching_ChannelsCompensator_setSimilarityThreshold(cv::detail::ChannelsCompensator *obj, double thresh)
{
    return cvTry([&] {
        obj->setSimilarityThreshold(thresh);
    });
}


// BlocksCompensator (shared implementation for BlocksGainCompensator / BlocksChannelsCompensator)

CVAPI(ExceptionStatus) stitching_BlocksCompensator_delete(cv::detail::BlocksCompensator *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_BlocksCompensator_getNrFeeds(cv::detail::BlocksCompensator *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNrFeeds();
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_setNrFeeds(cv::detail::BlocksCompensator *obj, int nrFeeds)
{
    return cvTry([&] {
        obj->setNrFeeds(nrFeeds);
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_getSimilarityThreshold(cv::detail::BlocksCompensator *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSimilarityThreshold();
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_setSimilarityThreshold(cv::detail::BlocksCompensator *obj, double thresh)
{
    return cvTry([&] {
        obj->setSimilarityThreshold(thresh);
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_getBlockSize(cv::detail::BlocksCompensator *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getBlockSize());
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_setBlockSize(cv::detail::BlocksCompensator *obj, int width, int height)
{
    return cvTry([&] {
        obj->setBlockSize(width, height);
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_getNrGainsFilteringIterations(cv::detail::BlocksCompensator *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNrGainsFilteringIterations();
    });
}
CVAPI(ExceptionStatus) stitching_BlocksCompensator_setNrGainsFilteringIterations(cv::detail::BlocksCompensator *obj, int nrIterations)
{
    return cvTry([&] {
        obj->setNrGainsFilteringIterations(nrIterations);
    });
}


// BlocksGainCompensator

CVAPI(ExceptionStatus) stitching_BlocksGainCompensator_new(
    int bl_width, int bl_height, int nr_feeds, cv::detail::BlocksGainCompensator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::BlocksGainCompensator(bl_width, bl_height, nr_feeds);
    });
}


// BlocksChannelsCompensator

CVAPI(ExceptionStatus) stitching_BlocksChannelsCompensator_new(
    int bl_width, int bl_height, int nr_feeds, cv::detail::BlocksChannelsCompensator **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::BlocksChannelsCompensator(bl_width, bl_height, nr_feeds);
    });
}

#endif // NO_STITCHING
