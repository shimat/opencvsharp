#pragma once

#ifndef NO_BARCODE

#include "include_opencv.h"

CVAPI(ExceptionStatus) barcode_BarcodeDetector_create(
    const char *super_resolution_model_path, cv::barcode::BarcodeDetector **returnValue)
{
    return cvTry([&] {
    // OpenCV 5: BarcodeDetector takes a single ONNX super-resolution model path (Caffe dropped).
    if (super_resolution_model_path == nullptr || super_resolution_model_path[0] == '\0')
        *returnValue = new cv::barcode::BarcodeDetector();
    else
        *returnValue = new cv::barcode::BarcodeDetector(std::string(super_resolution_model_path));
    });
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_delete(cv::barcode::BarcodeDetector *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_setDownsamplingThreshold(cv::barcode::BarcodeDetector *obj, double thresh)
{
    return cvTry([&] {
    obj->setDownsamplingThreshold(thresh);
    });
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_setDetectorScales(cv::barcode::BarcodeDetector *obj, std::vector<float> *sizes)
{
    return cvTry([&] {
    obj->setDetectorScales(*sizes);
    });
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_setGradientThreshold(cv::barcode::BarcodeDetector *obj, double thresh)
{
    return cvTry([&] {
    obj->setGradientThreshold(thresh);
    });
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_decodeWithType(cv::barcode::BarcodeDetector *obj, cv::_InputArray *inputImage,
    std::vector<cv::Point2f> *points, std::vector<std::string> *detectorInfos, std::vector<std::string> *detectorTypes)
{
    return cvTry([&] {
    obj->decodeWithType(*inputImage, *points, *detectorInfos, *detectorTypes);
    });
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_detectAndDecodeWithType(cv::barcode::BarcodeDetector *obj, cv::_InputArray *inputImage,
    std::vector<cv::Point2f> *points, std::vector<std::string> *detectorInfos, std::vector<std::string> *detectorTypes)
{
    return cvTry([&] {
    obj->detectAndDecodeWithType(*inputImage, *detectorInfos, *detectorTypes, *points);
    });
}

#endif //NO_BARCODE
