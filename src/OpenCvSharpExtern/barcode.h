#pragma once
#include "include_opencv.h"
CVAPI(ExceptionStatus) barcode_detector_create(const char *super_resolution_prototxt_path,
    const char *super_resolution_caffe_model_path, cv::Ptr<cv::barcode::BarcodeDetector> **returnValue)
{
    BEGIN_WRAP
        cv::Ptr<cv::barcode::BarcodeDetector> detector;
    detector = cv::makePtr<cv::barcode::BarcodeDetector>(super_resolution_prototxt_path, super_resolution_caffe_model_path);
    *returnValue = clone(detector);
    END_WRAP
}
CVAPI(ExceptionStatus) barcode_detector_Ptr_delete(cv::Ptr<cv::barcode::BarcodeDetector>* obj)
{
    BEGIN_WRAP
        delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_detector_Ptr_BarcodeDetector_get(cv::Ptr<cv::barcode::BarcodeDetector>* obj, cv::barcode::BarcodeDetector **returnValue)
{
    BEGIN_WRAP
        * returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) barcode_detector_BarcodeDetector_detectAndDecodeWithType(cv::barcode::BarcodeDetector* obj, cv::_InputArray* inputImage, std::vector<cv::Point2f>* points, std::vector<std::string>* detectorInfos, std::vector<std::string>* detectorTypes)
{
    BEGIN_WRAP
        obj->detectAndDecodeWithType(*inputImage, *detectorInfos, *detectorTypes, *points);
    END_WRAP
}
