#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_DPM)
#include "include_opencv.h"
#include <opencv2/dpm.hpp>

using DpmObjectDetection = cv::dpm::DPMDetector::ObjectDetection;

CVAPI(ExceptionStatus) dpm_DPMDetector_create(
    const std::vector<std::string>* modelPaths, const std::vector<std::string>* classNames,
    cv::Ptr<cv::dpm::DPMDetector>** returnValue)
{
    return cvTry([&] {
        auto detector = cv::dpm::DPMDetector::create(*modelPaths, *classNames);
        *returnValue = new cv::Ptr<cv::dpm::DPMDetector>(std::move(detector));
    });
}

CVAPI(ExceptionStatus) dpm_Ptr_DPMDetector_get(
    cv::Ptr<cv::dpm::DPMDetector>* ptr, cv::dpm::DPMDetector** returnValue)
{
    return cvTry([&] { *returnValue = ptr->get(); });
}

CVAPI(ExceptionStatus) dpm_Ptr_DPMDetector_delete(cv::Ptr<cv::dpm::DPMDetector>* ptr)
{
    return cvTry([&] { delete ptr; });
}

CVAPI(ExceptionStatus) dpm_DPMDetector_isEmpty(cv::dpm::DPMDetector* obj, int* returnValue)
{
    return cvTry([&] { *returnValue = obj->isEmpty() ? 1 : 0; });
}

CVAPI(ExceptionStatus) dpm_DPMDetector_getClassCount(cv::dpm::DPMDetector* obj, int* returnValue)
{
    return cvTry([&] { *returnValue = static_cast<int>(obj->getClassCount()); });
}

CVAPI(ExceptionStatus) dpm_DPMDetector_getClassNames(
    cv::dpm::DPMDetector* obj, std::vector<std::string>* returnValue)
{
    return cvTry([&] { *returnValue = obj->getClassNames(); });
}

CVAPI(ExceptionStatus) dpm_DPMDetector_detect(
    cv::dpm::DPMDetector* obj, const cv::Mat* image,
    std::vector<DpmObjectDetection>** returnValue)
{
    return cvTry([&] {
        // Upstream converts grayscale input to BGR in place. Work on a copy so Detect
        // preserves the caller's image for both grayscale and color input.
        cv::Mat workingImage = image->clone();
        std::vector<DpmObjectDetection> detections;
        obj->detect(workingImage, detections);
        *returnValue = new std::vector<DpmObjectDetection>(std::move(detections));
    });
}

CVAPI(ExceptionStatus) dpm_detections_count(
    const std::vector<DpmObjectDetection>* detections, int* returnValue)
{
    return cvTry([&] { *returnValue = static_cast<int>(detections->size()); });
}

CVAPI(ExceptionStatus) dpm_detections_get(
    const std::vector<DpmObjectDetection>* detections, int index,
    interop::Rect* rect, float* score, int* classId)
{
    return cvTry([&] {
        const auto& detection = detections->at(static_cast<size_t>(index));
        *rect = c(detection.rect);
        *score = detection.score;
        *classId = detection.classID;
    });
}

CVAPI(ExceptionStatus) dpm_detections_delete(std::vector<DpmObjectDetection>* detections)
{
    return cvTry([&] { delete detections; });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_DPM
