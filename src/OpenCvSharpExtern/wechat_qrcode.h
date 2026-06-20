#pragma once

#ifndef NO_CONTRIB

#include "include_opencv.h"

CVAPI(ExceptionStatus) wechat_qrcode_create1(
    const char *detector_model_path,
    const char *super_resolution_model_path, cv::wechat_qrcode::WeChatQRCode **returnValue)
{
    BEGIN_WRAP
    // OpenCV 5: WeChatQRCode takes one ONNX detector model path and one ONNX super-resolution
    // model path (Caffe prototxt/caffemodel pairs dropped).
    *returnValue = new cv::wechat_qrcode::WeChatQRCode(
        detector_model_path == nullptr ? std::string() : std::string(detector_model_path),
        super_resolution_model_path == nullptr ? std::string() : std::string(super_resolution_model_path));
    END_WRAP
}

CVAPI(ExceptionStatus) wechat_qrcode_delete(cv::wechat_qrcode::WeChatQRCode* obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) wechat_qrcode_WeChatQRCode_detectAndDecode(cv::wechat_qrcode::WeChatQRCode* obj, cv::_InputArray* inputImage, std::vector<cv::Mat>* points, std::vector<std::string>* texts)
{
    BEGIN_WRAP
    *texts = obj->detectAndDecode(*inputImage, *points);
    END_WRAP
}

CVAPI(ExceptionStatus) wechat_qrcode_WeChatQRCode_detectAndDecode_points(cv::wechat_qrcode::WeChatQRCode* obj, cv::_InputArray* inputImage, std::vector<std::vector<cv::Point2f> >* points, std::vector<std::string>* texts)
{
    BEGIN_WRAP
    std::vector<cv::Mat> matPoints;
    *texts = obj->detectAndDecode(*inputImage, matPoints);
    points->clear();
    for (const auto& mat : matPoints)
    {
        std::vector<cv::Point2f> pts;
        for (int i = 0; i < mat.rows; i++)
            pts.emplace_back(mat.at<float>(i, 0), mat.at<float>(i, 1));
        points->push_back(std::move(pts));
    }
    END_WRAP
}

#endif // NO_CONTRIB
