#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include "dnn.h" // dnn_readNetGated (UTF-8 / non-ANSI model path handling)

// ----------------------------------------------------------------------------
// TextRecognitionModel
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_new_String(
    const char *model,
    const char *config,
    cv::dnn::TextRecognitionModel **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::TextRecognitionModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::TextRecognitionModel(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_new_Net(cv::dnn::Net *network, cv::dnn::TextRecognitionModel **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::TextRecognitionModel(*network);
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_delete(cv::dnn::TextRecognitionModel *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_setDecodeType(cv::dnn::TextRecognitionModel *model, const char *decodeType)
{
    return cvTry([&] {
        model->setDecodeType(decodeType);
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_getDecodeType(cv::dnn::TextRecognitionModel *model, std::string *outString)
{
    return cvTry([&] {
        outString->assign(model->getDecodeType());
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_setDecodeOptsCTCPrefixBeamSearch(
    cv::dnn::TextRecognitionModel *model,
    const int beamSize,
    const int vocPruneSize)
{
    return cvTry([&] {
        model->setDecodeOptsCTCPrefixBeamSearch(beamSize, vocPruneSize);
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_setVocabulary(
    cv::dnn::TextRecognitionModel *model,
    const char **vocabulary,
    const int vocabularyLength)
{
    return cvTry([&] {
        std::vector<std::string> vocabularyVec(vocabularyLength);
        for (auto i = 0; i < vocabularyLength; i++)
        {
            vocabularyVec[i] = vocabulary[i];
        }
        model->setVocabulary(vocabularyVec);
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_getVocabulary(cv::dnn::TextRecognitionModel *model, std::vector<std::string> *outVec)
{
    return cvTry([&] {
        const auto result = model->getVocabulary();
        outVec->assign(result.begin(), result.end());
    });
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_recognize(
    cv::dnn::TextRecognitionModel *model,
    const interop::InputArrayProxy* frame,
    std::string *outString)
{
    return cvTry([&] {
        outString->assign(model->recognize(InProxy(*frame)));
    });
}

// ----------------------------------------------------------------------------
// TextDetectionModel (base; methods are shared by EAST and DB via upcast)
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextDetectionModel_detect(
    cv::dnn::TextDetectionModel *model,
    const interop::InputArrayProxy* frame,
    std::vector<std::vector<cv::Point>> *detections,
    std::vector<float> *confidences)
{
    return cvTry([&] {
        model->detect(InProxy(*frame), *detections, *confidences);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_detectTextRectangles(
    cv::dnn::TextDetectionModel *model,
    const interop::InputArrayProxy* frame,
    std::vector<cv::RotatedRect> *detections,
    std::vector<float> *confidences)
{
    return cvTry([&] {
        model->detectTextRectangles(InProxy(*frame), *detections, *confidences);
    });
}

// ----------------------------------------------------------------------------
// TextDetectionModel_EAST
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_new_String(
    const char *model,
    const char *config,
    cv::dnn::TextDetectionModel_EAST **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::TextDetectionModel_EAST(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::TextDetectionModel_EAST(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_new_Net(cv::dnn::Net *network, cv::dnn::TextDetectionModel_EAST **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::TextDetectionModel_EAST(*network);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_delete(cv::dnn::TextDetectionModel_EAST *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_setConfidenceThreshold(cv::dnn::TextDetectionModel_EAST *model, const float confThreshold)
{
    return cvTry([&] {
        model->setConfidenceThreshold(confThreshold);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_getConfidenceThreshold(cv::dnn::TextDetectionModel_EAST *model, float *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getConfidenceThreshold();
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_setNMSThreshold(cv::dnn::TextDetectionModel_EAST *model, const float nmsThreshold)
{
    return cvTry([&] {
        model->setNMSThreshold(nmsThreshold);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_getNMSThreshold(cv::dnn::TextDetectionModel_EAST *model, float *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getNMSThreshold();
    });
}

// ----------------------------------------------------------------------------
// TextDetectionModel_DB
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_new_String(
    const char *model,
    const char *config,
    cv::dnn::TextDetectionModel_DB **returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        *returnValue = new cv::dnn::TextDetectionModel_DB(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
        const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
        *returnValue = new cv::dnn::TextDetectionModel_DB(model, configStr);
#endif
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_new_Net(cv::dnn::Net *network, cv::dnn::TextDetectionModel_DB **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::TextDetectionModel_DB(*network);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_delete(cv::dnn::TextDetectionModel_DB *model)
{
    return cvTry([&] {
        delete model;
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setBinaryThreshold(cv::dnn::TextDetectionModel_DB *model, const float binaryThreshold)
{
    return cvTry([&] {
        model->setBinaryThreshold(binaryThreshold);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getBinaryThreshold(cv::dnn::TextDetectionModel_DB *model, float *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getBinaryThreshold();
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setPolygonThreshold(cv::dnn::TextDetectionModel_DB *model, const float polygonThreshold)
{
    return cvTry([&] {
        model->setPolygonThreshold(polygonThreshold);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getPolygonThreshold(cv::dnn::TextDetectionModel_DB *model, float *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getPolygonThreshold();
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setUnclipRatio(cv::dnn::TextDetectionModel_DB *model, const double unclipRatio)
{
    return cvTry([&] {
        model->setUnclipRatio(unclipRatio);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getUnclipRatio(cv::dnn::TextDetectionModel_DB *model, double *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getUnclipRatio();
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setMaxCandidates(cv::dnn::TextDetectionModel_DB *model, const int maxCandidates)
{
    return cvTry([&] {
        model->setMaxCandidates(maxCandidates);
    });
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getMaxCandidates(cv::dnn::TextDetectionModel_DB *model, int *returnValue)
{
    return cvTry([&] {
        *returnValue = model->getMaxCandidates();
    });
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
