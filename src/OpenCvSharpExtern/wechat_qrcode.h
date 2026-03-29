#pragma once

#ifndef NO_CONTRIB

#include "include_opencv.h"
CVAPI(ExceptionStatus) wechat_qrcode_create1(const char *detector_prototxt_path,
    const char *detector_caffe_model_path ,
    const char *super_resolution_prototxt_path ,
    const char *super_resolution_caffe_model_path, cv::wechat_qrcode::WeChatQRCode **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::wechat_qrcode::WeChatQRCode(
        detector_prototxt_path, detector_caffe_model_path,
        super_resolution_prototxt_path, super_resolution_caffe_model_path);
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

#endif // NO_CONTRIB
