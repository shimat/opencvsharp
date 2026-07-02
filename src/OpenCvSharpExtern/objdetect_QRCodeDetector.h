#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_new(cv::QRCodeDetector **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::QRCodeDetector();
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_delete(cv::QRCodeDetector *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_setEpsX(cv::QRCodeDetector *obj, double epsX)
{
    return cvTry([&] {
    obj->setEpsX(epsX);
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_setEpsY(cv::QRCodeDetector *obj, double epsY)
{
    return cvTry([&] {
    obj->setEpsY(epsY);
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_detect(
    cv::QRCodeDetector *obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f> *points,
    int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->detect(InProxy(*img), *points) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_decode(
    cv::QRCodeDetector *obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f> *points,
    const interop::OutputArrayProxy* straight_qrcode,
    std::string *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->decode(InProxy(*img), *points, OutProxy(*straight_qrcode));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_detectAndDecode(
    cv::QRCodeDetector *obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f> *points,
    const interop::OutputArrayProxy* straight_qrcode,
    std::string *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->detectAndDecode(InProxy(*img), *points, OutProxy(*straight_qrcode));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_detectMulti(
    cv::QRCodeDetector* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->detectMulti(InProxy(*img), *points) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_decodeMulti(
    cv::QRCodeDetector* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    std::vector<std::string>* decoded_info,
    std::vector<cv::Mat>* straight_qrcode,
    int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->decodeMulti(InProxy(*img), *points, *decoded_info, *straight_qrcode) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeDetector_decodeMulti_NoStraightQrCode(
    cv::QRCodeDetector* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f>* points,
    std::vector<std::string>* decoded_info,
    int* returnValue)
{
    return cvTry([&] {
    *returnValue = obj->decodeMulti(InProxy(*img), *points, *decoded_info) ? 1 : 0;
    });
}

#endif

#endif // NO_OBJDETECT
