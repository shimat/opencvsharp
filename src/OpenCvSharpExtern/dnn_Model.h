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

CVAPI(ExceptionStatus) dnn_Model_new_String(const char *model, const char *config, cv::dnn::Model **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::Model(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::Model(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_new_Net(cv::dnn::Net *network, cv::dnn::Model **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::Model(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_delete(cv::dnn::Model *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setInputSize(cv::dnn::Model *model, const MyCvSize size)
{
    BEGIN_WRAP
    model->setInputSize(cpp(size));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setInputMean(cv::dnn::Model *model, const MyCvScalar mean)
{
    BEGIN_WRAP
    model->setInputMean(cpp(mean));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setInputScale(cv::dnn::Model *model, const MyCvScalar scale)
{
    BEGIN_WRAP
    model->setInputScale(cpp(scale));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setInputCrop(cv::dnn::Model *model, const int crop)
{
    BEGIN_WRAP
    model->setInputCrop(crop != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setInputSwapRB(cv::dnn::Model *model, const int swapRB)
{
    BEGIN_WRAP
    model->setInputSwapRB(swapRB != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setInputParams(
    cv::dnn::Model *model, const double scale, const MyCvSize size, const MyCvScalar mean, const int swapRB, const int crop)
{
    BEGIN_WRAP
    model->setInputParams(scale, cpp(size), cpp(mean), swapRB != 0, crop != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setOutputNames(cv::dnn::Model *model, const char **outNames, const int outNamesLength)
{
    BEGIN_WRAP
    std::vector<cv::String> outNamesVec(outNamesLength);
    for (auto i = 0; i < outNamesLength; i++)
    {
        outNamesVec[i] = outNames[i];
    }
    model->setOutputNames(outNamesVec);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_predict(cv::dnn::Model *model, cv::_InputArray *frame, std::vector<cv::Mat> *outs)
{
    BEGIN_WRAP
    model->predict(*frame, *outs);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setPreferableBackend(cv::dnn::Model *model, const int backendId)
{
    BEGIN_WRAP
    model->setPreferableBackend(static_cast<cv::dnn::Backend>(backendId));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_setPreferableTarget(cv::dnn::Model *model, const int targetId)
{
    BEGIN_WRAP
    model->setPreferableTarget(static_cast<cv::dnn::Target>(targetId));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Model_enableWinograd(cv::dnn::Model *model, const int useWinograd)
{
    BEGIN_WRAP
    model->enableWinograd(useWinograd != 0);
    END_WRAP
}

// ----------------------------------------------------------------------------
// ClassificationModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_ClassificationModel_new_String(
    const char *model, const char *config, cv::dnn::ClassificationModel **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::ClassificationModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::ClassificationModel(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_new_Net(cv::dnn::Net *network, cv::dnn::ClassificationModel **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::ClassificationModel(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_delete(cv::dnn::ClassificationModel *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_setEnableSoftmaxPostProcessing(
    cv::dnn::ClassificationModel *model, const int enable)
{
    BEGIN_WRAP
    model->setEnableSoftmaxPostProcessing(enable != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_getEnableSoftmaxPostProcessing(
    cv::dnn::ClassificationModel *model, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getEnableSoftmaxPostProcessing() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_ClassificationModel_classify(
    cv::dnn::ClassificationModel *model, cv::_InputArray *frame, int *classId, float *conf)
{
    BEGIN_WRAP
    model->classify(*frame, *classId, *conf);
    END_WRAP
}

// ----------------------------------------------------------------------------
// DetectionModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_DetectionModel_new_String(
    const char *model, const char *config, cv::dnn::DetectionModel **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::DetectionModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::DetectionModel(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_DetectionModel_new_Net(cv::dnn::Net *network, cv::dnn::DetectionModel **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::DetectionModel(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_DetectionModel_delete(cv::dnn::DetectionModel *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_DetectionModel_setNmsAcrossClasses(cv::dnn::DetectionModel *model, const int value)
{
    BEGIN_WRAP
    model->setNmsAcrossClasses(value != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_DetectionModel_getNmsAcrossClasses(cv::dnn::DetectionModel *model, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getNmsAcrossClasses() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_DetectionModel_detect(
    cv::dnn::DetectionModel *model, cv::_InputArray *frame,
    std::vector<int> *classIds, std::vector<float> *confidences, std::vector<cv::Rect> *boxes,
    const float confThreshold, const float nmsThreshold)
{
    BEGIN_WRAP
    model->detect(*frame, *classIds, *confidences, *boxes, confThreshold, nmsThreshold);
    END_WRAP
}

// ----------------------------------------------------------------------------
// SegmentationModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_SegmentationModel_new_String(
    const char *model, const char *config, cv::dnn::SegmentationModel **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::SegmentationModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::SegmentationModel(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_SegmentationModel_new_Net(cv::dnn::Net *network, cv::dnn::SegmentationModel **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::SegmentationModel(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_SegmentationModel_delete(cv::dnn::SegmentationModel *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_SegmentationModel_segment(
    cv::dnn::SegmentationModel *model, cv::_InputArray *frame, cv::_OutputArray *mask)
{
    BEGIN_WRAP
    model->segment(*frame, *mask);
    END_WRAP
}

// ----------------------------------------------------------------------------
// KeypointsModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_KeypointsModel_new_String(
    const char *model, const char *config, cv::dnn::KeypointsModel **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::KeypointsModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::KeypointsModel(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_KeypointsModel_new_Net(cv::dnn::Net *network, cv::dnn::KeypointsModel **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::KeypointsModel(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_KeypointsModel_delete(cv::dnn::KeypointsModel *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_KeypointsModel_estimate(
    cv::dnn::KeypointsModel *model, cv::_InputArray *frame, std::vector<cv::Point2f> *keypoints, const float thresh)
{
    BEGIN_WRAP
    const auto result = model->estimate(*frame, thresh);
    keypoints->assign(result.begin(), result.end());
    END_WRAP
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
