#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include "dnn.h" // dnn_readNetGated (UTF-8 / non-ANSI model path handling)

// ----------------------------------------------------------------------------
// Model (base class)
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_Model_new_String(
    const char *model,
    const char *config,
    cv::dnn::Model **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::Model(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::Model(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_Model_new_Net(cv::dnn::Net *network, cv::dnn::Model **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::Model(*network);
    });
}

CVAPI(ExceptionStatus) dnn_Model_delete(cv::dnn::Model *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_Model_setInputSize(cv::dnn::Model *model, const interop::Size size)
{
    return cvTry([&] {
        model->setInputSize(cpp(size));
    });
}

CVAPI(ExceptionStatus) dnn_Model_setInputMean(cv::dnn::Model *model, const interop::Scalar mean)
{
    return cvTry([&] {
        model->setInputMean(cpp(mean));
    });
}

CVAPI(ExceptionStatus) dnn_Model_setInputScale(cv::dnn::Model *model, const interop::Scalar scale)
{
    return cvTry([&] {
        model->setInputScale(cpp(scale));
    });
}

CVAPI(ExceptionStatus) dnn_Model_setInputCrop(cv::dnn::Model *model, const int crop)
{
    return cvTry([&] {
        model->setInputCrop(crop != 0);
    });
}

CVAPI(ExceptionStatus) dnn_Model_setInputSwapRB(cv::dnn::Model *model, const int swapRB)
{
    return cvTry([&] {
        model->setInputSwapRB(swapRB != 0);
    });
}

CVAPI(ExceptionStatus) dnn_Model_setInputParams(
    cv::dnn::Model *model,
    const double scale,
    const interop::Size size,
    const interop::Scalar mean,
    const int swapRB,
    const int crop)
{
    return cvTry([&] {
        model->setInputParams(scale, cpp(size), cpp(mean), swapRB != 0, crop != 0);
    });
}

CVAPI(ExceptionStatus) dnn_Model_setOutputNames(
    cv::dnn::Model *model,
    const char **outNames,
    const int outNamesLength)
{
    return cvTry([&] {
        std::vector<cv::String> outNamesVec(outNamesLength);
        for (auto i = 0; i < outNamesLength; i++)
        {
            outNamesVec[i] = outNames[i];
        }
        model->setOutputNames(outNamesVec);
    });
}

CVAPI(ExceptionStatus) dnn_Model_predict(
    cv::dnn::Model *model,
    const interop::InputArrayProxy* frame,
    std::vector<cv::Mat> *outs)
{
    return cvTry([&] {
        model->predict(InProxy(*frame), *outs);
    });
}

CVAPI(ExceptionStatus) dnn_Model_setPreferableBackend(cv::dnn::Model *model, const int backendId)
{
    return cvTry([&] {
        model->setPreferableBackend(static_cast<cv::dnn::Backend>(backendId));
    });
}

CVAPI(ExceptionStatus) dnn_Model_setPreferableTarget(cv::dnn::Model *model, const int targetId)
{
    return cvTry([&] {
        model->setPreferableTarget(static_cast<cv::dnn::Target>(targetId));
    });
}

CVAPI(ExceptionStatus) dnn_Model_enableWinograd(cv::dnn::Model *model, const int useWinograd)
{
    return cvTry([&] {
        model->enableWinograd(useWinograd != 0);
    });
}

// ----------------------------------------------------------------------------
// ClassificationModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_ClassificationModel_new_String(
    const char *model,
    const char *config,
    cv::dnn::ClassificationModel **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::ClassificationModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::ClassificationModel(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_new_Net(cv::dnn::Net *network, cv::dnn::ClassificationModel **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::ClassificationModel(*network);
    });
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_delete(cv::dnn::ClassificationModel *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_setEnableSoftmaxPostProcessing(cv::dnn::ClassificationModel *model, const int enable)
{
    return cvTry([&] {
        model->setEnableSoftmaxPostProcessing(enable != 0);
    });
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_getEnableSoftmaxPostProcessing(cv::dnn::ClassificationModel *model, int *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getEnableSoftmaxPostProcessing() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_classify(
    cv::dnn::ClassificationModel *model,
    const interop::InputArrayProxy* frame,
    int *classId,
    float *conf)
{
    return cvTry([&] {
        model->classify(InProxy(*frame), *classId, *conf);
    });
}

// ----------------------------------------------------------------------------
// DetectionModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_DetectionModel_new_String(
    const char *model,
    const char *config,
    cv::dnn::DetectionModel **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::DetectionModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::DetectionModel(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_DetectionModel_new_Net(cv::dnn::Net *network, cv::dnn::DetectionModel **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::DetectionModel(*network);
    });
}

CVAPI(ExceptionStatus) dnn_DetectionModel_delete(cv::dnn::DetectionModel *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_DetectionModel_setNmsAcrossClasses(cv::dnn::DetectionModel *model, const int value)
{
    return cvTry([&] {
        model->setNmsAcrossClasses(value != 0);
    });
}

CVAPI(ExceptionStatus) dnn_DetectionModel_getNmsAcrossClasses(cv::dnn::DetectionModel *model, int *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getNmsAcrossClasses() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) dnn_DetectionModel_detect(
    cv::dnn::DetectionModel *model,
    const interop::InputArrayProxy* frame,
    std::vector<int> *classIds,
    std::vector<float> *confidences,
    std::vector<cv::Rect> *boxes,
    const float confThreshold,
    const float nmsThreshold)
{
    return cvTry([&] {
        model->detect(InProxy(*frame), *classIds, *confidences, *boxes, confThreshold, nmsThreshold);
    });
}

// ----------------------------------------------------------------------------
// SegmentationModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_SegmentationModel_new_String(
    const char *model,
    const char *config,
    cv::dnn::SegmentationModel **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::SegmentationModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::SegmentationModel(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_SegmentationModel_new_Net(cv::dnn::Net *network, cv::dnn::SegmentationModel **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::SegmentationModel(*network);
    });
}

CVAPI(ExceptionStatus) dnn_SegmentationModel_delete(cv::dnn::SegmentationModel *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_SegmentationModel_segment(
    cv::dnn::SegmentationModel *model,
    const interop::InputArrayProxy* frame,
    const interop::OutputArrayProxy* mask)
{
    return cvTry([&] {
        model->segment(InProxy(*frame), OutProxy(*mask));
    });
}

// ----------------------------------------------------------------------------
// KeypointsModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_KeypointsModel_new_String(
    const char *model,
    const char *config,
    cv::dnn::KeypointsModel **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::KeypointsModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::KeypointsModel(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_KeypointsModel_new_Net(cv::dnn::Net *network, cv::dnn::KeypointsModel **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::KeypointsModel(*network);
    });
}

CVAPI(ExceptionStatus) dnn_KeypointsModel_delete(cv::dnn::KeypointsModel *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_KeypointsModel_estimate(
    cv::dnn::KeypointsModel *model,
    const interop::InputArrayProxy* frame,
    std::vector<cv::Point2f> *keypoints,
    const float thresh)
{
    return cvTry([&] {
        const auto result = model->estimate(InProxy(*frame), thresh);
        keypoints->assign(result.begin(), result.end());
    });
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
