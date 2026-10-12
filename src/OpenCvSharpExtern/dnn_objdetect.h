#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_DNN_OBJDETECT)
#include "include_opencv.h"
#include <opencv2/core_detect.hpp>

CVAPI(ExceptionStatus) dnn_objdetect_inferBboxes(
    const cv::Mat* deltaBboxes, const cv::Mat* classScores, const cv::Mat* confidenceScores,
    double threshold, std::vector<cv::dnn_objdetect::object>** returnValue)
{
    return cvTry([&] {
        cv::dnn_objdetect::InferBbox infer(*deltaBboxes, *classScores, *confidenceScores);
        infer.filter(threshold);
        *returnValue = new std::vector<cv::dnn_objdetect::object>(std::move(infer.detections));
    });
}

CVAPI(ExceptionStatus) dnn_objdetect_detections_count(
    const std::vector<cv::dnn_objdetect::object>* detections, int* returnValue)
{
    return cvTry([&] { *returnValue = static_cast<int>(detections->size()); });
}

CVAPI(ExceptionStatus) dnn_objdetect_detections_get(
    const std::vector<cv::dnn_objdetect::object>* detections, int index,
    int* xmin, int* ymin, int* xmax, int* ymax, int* classIndex,
    const char** label, double* probability)
{
    return cvTry([&] {
        const auto& detection = detections->at(static_cast<size_t>(index));
        *xmin = detection.xmin;
        *ymin = detection.ymin;
        *xmax = detection.xmax;
        *ymax = detection.ymax;
        *classIndex = static_cast<int>(detection.class_idx);
        *label = detection.label_name.c_str();
        *probability = detection.class_prob;
    });
}

CVAPI(ExceptionStatus) dnn_objdetect_detections_delete(
    std::vector<cv::dnn_objdetect::object>* detections)
{
    return cvTry([&] { delete detections; });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_DNN_OBJDETECT
