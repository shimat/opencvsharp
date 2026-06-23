#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_readNetFromTensorflow(const char *model, const char *config, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    const auto net = cv::dnn::readNetFromTensorflow(model, configStr);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromTensorflow_InputArray(const char *model,size_t lenModel, const char *config, size_t lenConfig, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromTensorflow(model, lenModel, config, lenConfig);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNet(const char *model, const char *config, const char *framework, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto configStr = (config == nullptr) ? "" : cv::String(config);
    const auto frameworkStr = (framework == nullptr) ? "" : cv::String(framework);
    const auto net = cv::dnn::readNet(model, configStr, frameworkStr);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromModelOptimizer(const char *xml, const char *bin, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromModelOptimizer(xml, bin);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromONNX(const char *onnxFile, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromONNX(onnxFile);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromONNX_InputArray(const char* buffer, size_t sizeBuffer, cv::dnn::Net** returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromONNX(buffer, sizeBuffer);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}


CVAPI(ExceptionStatus) dnn_readTensorFromONNX(const char *path, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::dnn::readTensorFromONNX(path);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_blobFromImage(
    cv::Mat *image, const double scalefactor, const MyCvSize size, const MyCvScalar mean, const int swapRB, const int crop, 
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto blob = cv::dnn::blobFromImage(*image, scalefactor, cpp(size), cpp(mean), swapRB != 0, crop != 0);
    *returnValue = new cv::Mat(blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_blobFromImages(
    const cv::Mat **images, const int imagesLength, const double scalefactor, const MyCvSize size, const MyCvScalar mean, const int swapRB, const int crop, 
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesLength, imagesVec);

    const auto blob = cv::dnn::blobFromImages(imagesVec, scalefactor, cpp(size), cpp(mean), swapRB != 0, crop != 0);
    *returnValue = new cv::Mat(blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_writeTextGraph(const char *model, const char *output)
{
    BEGIN_WRAP
    cv::dnn::writeTextGraph(model, output);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxes_Rect(std::vector<cv::Rect> *bboxes, std::vector<float> *scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxes(*bboxes, *scores, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxes_Rect2d(std::vector<cv::Rect2d> *bboxes, std::vector<float> *scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxes(*bboxes, *scores, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxes_RotatedRect(std::vector<cv::RotatedRect> *bboxes, std::vector<float> *scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxes(*bboxes, *scores, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_resetMyriadDevice()
{
    BEGIN_WRAP
    cv::dnn::resetMyriadDevice();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_getAvailableTargets(const int be, std::vector<int> *targets)
{
    BEGIN_WRAP
    const auto v = cv::dnn::getAvailableTargets(static_cast<cv::dnn::Backend>(be));
    targets->clear();
    for (const auto t : v)
        targets->push_back(static_cast<int>(t));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_getAvailableBackends(std::vector<int> *backends, std::vector<int> *targets)
{
    BEGIN_WRAP
    const auto v = cv::dnn::getAvailableBackends();
    backends->clear();
    targets->clear();
    for (const auto &p : v)
    {
        backends->push_back(static_cast<int>(p.first));
        targets->push_back(static_cast<int>(p.second));
    }
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_enableModelDiagnostics(const int isDiagnosticsMode)
{
    BEGIN_WRAP
    cv::dnn::enableModelDiagnostics(isDiagnosticsMode != 0);
    END_WRAP
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
