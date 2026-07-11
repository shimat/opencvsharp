#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

#pragma region QRCodeEncoder

extern "C"
{
    struct objdetect_QRCodeEncoder_Params
    {
        int version;
        int correction_level;
        int mode;
        int structure_number;
    };
}

static cv::QRCodeEncoder::Params cpp(const objdetect_QRCodeEncoder_Params& p)
{
    cv::QRCodeEncoder::Params pp;
    pp.version = p.version;
    pp.correction_level = static_cast<cv::QRCodeEncoder::CorrectionLevel>(p.correction_level);
    pp.mode = static_cast<cv::QRCodeEncoder::EncodeMode>(p.mode);
    pp.structure_number = p.structure_number;
    return pp;
}

CVAPI(ExceptionStatus) objdetect_QRCodeEncoder_create(
    const objdetect_QRCodeEncoder_Params* parameters,
    cv::Ptr<cv::QRCodeEncoder>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::QRCodeEncoder::create(cpp(*parameters));
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) objdetect_Ptr_QRCodeEncoder_delete(cv::Ptr<cv::QRCodeEncoder>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) objdetect_Ptr_QRCodeEncoder_get(cv::Ptr<cv::QRCodeEncoder>* ptr, cv::QRCodeEncoder** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeEncoder_encode(
    cv::QRCodeEncoder* obj,
    const char* encodedInfo,
    const interop::OutputArrayProxy* qrcode)
{
    return cvTry([&] {
        obj->encode(cv::String(encodedInfo), OutProxy(*qrcode));
    });
}

CVAPI(ExceptionStatus) objdetect_QRCodeEncoder_encodeStructuredAppend(
    cv::QRCodeEncoder* obj,
    const char* encodedInfo,
    std::vector<cv::Mat>* qrcodes)
{
    return cvTry([&] {
        obj->encodeStructuredAppend(cv::String(encodedInfo), *qrcodes);
    });
}

#pragma endregion

#endif

#endif // NO_OBJDETECT
