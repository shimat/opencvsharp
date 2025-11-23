#pragma once

#include "include_opencv.h"

CVAPI(ExceptionStatus) barcode_BarcodeDetector_create(const char *super_resolution_prototxt_path,
    const char *super_resolution_caffe_model_path, cv::Ptr<cv::barcode::BarcodeDetector> **returnValue)
{
    BEGIN_WRAP
        cv::Ptr<cv::barcode::BarcodeDetector> detector;
    detector = cv::makePtr<cv::barcode::BarcodeDetector>(super_resolution_prototxt_path, super_resolution_caffe_model_path);
    *returnValue = clone(detector);
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


CVAPI(ExceptionStatus) barcode_Ptr_BarcodeDetector_delete(cv::Ptr<cv::barcode::BarcodeDetector> *obj)
{
    BEGIN_WRAP
        delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_Ptr_BarcodeDetector_get(cv::Ptr<cv::barcode::BarcodeDetector> *obj, cv::barcode::BarcodeDetector **returnValue)
{
    BEGIN_WRAP
         *returnValue = obj->get();
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
