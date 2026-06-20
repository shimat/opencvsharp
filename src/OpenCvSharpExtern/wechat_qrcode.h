#pragma once

#ifndef NO_CONTRIB

#include "include_opencv.h"

CVAPI(ExceptionStatus) wechat_qrcode_create1(const char *detector_prototxt_path,
    const char *detector_caffe_model_path ,
    const char *super_resolution_prototxt_path ,
    const char *super_resolution_caffe_model_path, cv::wechat_qrcode::WeChatQRCode **returnValue)
{
    BEGIN_WRAP
    // OpenCV 5 dropped Caffe model support; WeChatQRCode now takes a single ONNX path for
    // the detector and a single ONNX path for the super-resolution model. The legacy caffe
    // model arguments are ignored.
    (void)detector_caffe_model_path;
    (void)super_resolution_caffe_model_path;
    *returnValue = new cv::wechat_qrcode::WeChatQRCode(
        detector_prototxt_path == nullptr ? std::string() : std::string(detector_prototxt_path),
        super_resolution_prototxt_path == nullptr ? std::string() : std::string(super_resolution_prototxt_path));
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
