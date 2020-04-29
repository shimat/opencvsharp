#ifndef _CPP_OBJDETECT_QRCODE_DETECTOR_H_
#define _CPP_OBJDETECT_QRCODE_DETECTOR_H_

#include "include_opencv.h"


CVAPI(ExceptionStatus) objdetect_QRCodeDetector_new(cv::QRCodeDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::QRCodeDetector();
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_delete(cv::QRCodeDetector *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_setEpsX(cv::QRCodeDetector *obj, double epsX)
{
    BEGIN_WRAP
    obj->setEpsX(epsX);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_setEpsY(cv::QRCodeDetector *obj, double epsY)
{
    BEGIN_WRAP
    obj->setEpsY(epsY);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_detect(
    cv::QRCodeDetector *obj, cv::_InputArray *img, std::vector<cv::Point2f> *points, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->detect(*img, *points) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_decode(
    cv::QRCodeDetector *obj, cv::_InputArray *img, std::vector<cv::Point2f> *points, cv::_OutputArray *straight_qrcode, std::string *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->decode(*img, *points, entity(straight_qrcode));
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_detectAndDecode(
    cv::QRCodeDetector *obj, cv::_InputArray *img, std::vector<cv::Point2f> *points,
    cv::_OutputArray *straight_qrcode, std::string *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->detectAndDecode(*img, *points, entity(straight_qrcode));
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_detectMulti(
    cv::QRCodeDetector* obj, cv::_InputArray* img, std::vector<cv::Point2f>* points, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->detectMulti(*img, *points) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_decodeMulti(
    cv::QRCodeDetector* obj, cv::_InputArray* img, std::vector<cv::Point2f>* points, std::vector<std::string>* decoded_info, std::vector<cv::Mat>** straight_qrcode, int* returnValue)
{
    BEGIN_WRAP
    *straight_qrcode = new std::vector<cv::Mat>;
    *returnValue = obj->decodeMulti(*img, *points, *decoded_info, **straight_qrcode) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_decodeMulti_NoStraightQrCode(
    cv::QRCodeDetector* obj, cv::_InputArray* img, std::vector<cv::Point2f>* points, std::vector<std::string>* decoded_info, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->decodeMulti(*img, *points, *decoded_info) ? 1 : 0;
    END_WRAP
}

#endif