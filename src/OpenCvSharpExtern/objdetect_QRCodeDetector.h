#ifndef _CPP_OBJDETECT_QRCODE_DETECTOR_H_
#define _CPP_OBJDETECT_QRCODE_DETECTOR_H_

#include "include_opencv.h"


CVAPI(cv::QRCodeDetector*) objdetect_QRCodeDetector_new()
{
    return new cv::QRCodeDetector();
}

CVAPI(void) objdetect_QRCodeDetector_delete(cv::QRCodeDetector *obj)
{
    delete obj;
}

CVAPI(void) objdetect_QRCodeDetector_setEpsX(cv::QRCodeDetector *obj, double epsX)
{
    obj->setEpsX(epsX);
}

CVAPI(void) objdetect_QRCodeDetector_setEpsY(cv::QRCodeDetector *obj, double epsY)
{
    obj->setEpsY(epsY);
}

CVAPI(int) objdetect_QRCodeDetector_detect(cv::QRCodeDetector *obj, cv::_InputArray *img, std::vector<cv::Point2f> *points)
{
    return obj->detect(*img, *points) ? 1 : 0;
}

CVAPI(void) objdetect_QRCodeDetector_decode(
    cv::QRCodeDetector *obj, cv::_InputArray *img, std::vector<cv::Point2f> *points, cv::_OutputArray *straight_qrcode, std::string *result)
{
    *result = obj->decode(*img, *points, entity(straight_qrcode));
}

CVAPI(void) objdetect_QRCodeDetector_detectAndDecode(
    cv::QRCodeDetector *obj, cv::_InputArray *img, cv::_OutputArray *points,
    cv::_OutputArray *straight_qrcode, std::string *result)
{
    *result = obj->detectAndDecode(*img, entity(points), entity(straight_qrcode));
}

#endif