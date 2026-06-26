#pragma once

#ifndef NO_BARCODE

#include "include_opencv.h"

CVAPI(ExceptionStatus) barcode_BarcodeDetector_create(
    const char *super_resolution_model_path, cv::barcode::BarcodeDetector **returnValue)
{
    BEGIN_WRAP
    // OpenCV 5: BarcodeDetector takes a single ONNX super-resolution model path (Caffe dropped).
    if (super_resolution_model_path == nullptr || super_resolution_model_path[0] == '\0')
        *returnValue = new cv::barcode::BarcodeDetector();
    else
        *returnValue = new cv::barcode::BarcodeDetector(std::string(super_resolution_model_path));
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_delete(cv::barcode::BarcodeDetector *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_setDownsamplingThreshold(cv::barcode::BarcodeDetector *obj, double thresh)
{
    BEGIN_WRAP
    obj->setDownsamplingThreshold(thresh);
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_setDetectorScales(cv::barcode::BarcodeDetector *obj, std::vector<float> *sizes)
{
    BEGIN_WRAP
    obj->setDetectorScales(*sizes);
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_setGradientThreshold(cv::barcode::BarcodeDetector *obj, double thresh)
{
    BEGIN_WRAP
    obj->setGradientThreshold(thresh);
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_decodeWithType(cv::barcode::BarcodeDetector *obj, cv::_InputArray *inputImage,
    std::vector<cv::Point2f> *points, std::vector<std::string> *detectorInfos, std::vector<std::string> *detectorTypes)
{
    BEGIN_WRAP
    obj->decodeWithType(*inputImage, *points, *detectorInfos, *detectorTypes);
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_BarcodeDetector_detectAndDecodeWithType(cv::barcode::BarcodeDetector *obj, cv::_InputArray *inputImage,
    std::vector<cv::Point2f> *points, std::vector<std::string> *detectorInfos, std::vector<std::string> *detectorTypes)
{
    BEGIN_WRAP
    obj->detectAndDecodeWithType(*inputImage, *detectorInfos, *detectorTypes, *points);
    END_WRAP
}

#endif //NO_BARCODE
