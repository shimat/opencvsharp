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
    const char *model, const char *config, cv::dnn::TextRecognitionModel **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::TextRecognitionModel(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::TextRecognitionModel(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_new_Net(
    cv::dnn::Net *network, cv::dnn::TextRecognitionModel **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::TextRecognitionModel(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_delete(cv::dnn::TextRecognitionModel *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_setDecodeType(
    cv::dnn::TextRecognitionModel *model, const char *decodeType)
{
    BEGIN_WRAP
    model->setDecodeType(decodeType);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_getDecodeType(
    cv::dnn::TextRecognitionModel *model, std::string *outString)
{
    BEGIN_WRAP
    outString->assign(model->getDecodeType());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_setDecodeOptsCTCPrefixBeamSearch(
    cv::dnn::TextRecognitionModel *model, const int beamSize, const int vocPruneSize)
{
    BEGIN_WRAP
    model->setDecodeOptsCTCPrefixBeamSearch(beamSize, vocPruneSize);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_setVocabulary(
    cv::dnn::TextRecognitionModel *model, const char **vocabulary, const int vocabularyLength)
{
    BEGIN_WRAP
    std::vector<std::string> vocabularyVec(vocabularyLength);
    for (auto i = 0; i < vocabularyLength; i++)
    {
        vocabularyVec[i] = vocabulary[i];
    }
    model->setVocabulary(vocabularyVec);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_getVocabulary(
    cv::dnn::TextRecognitionModel *model, std::vector<std::string> *outVec)
{
    BEGIN_WRAP
    const auto result = model->getVocabulary();
    outVec->assign(result.begin(), result.end());
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextRecognitionModel_recognize(
    cv::dnn::TextRecognitionModel *model, cv::_InputArray *frame, std::string *outString)
{
    BEGIN_WRAP
    outString->assign(model->recognize(*frame));
    END_WRAP
}

// ----------------------------------------------------------------------------
// TextDetectionModel (base; methods are shared by EAST and DB via upcast)
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextDetectionModel_detect(
    cv::dnn::TextDetectionModel *model, cv::_InputArray *frame,
    std::vector<std::vector<cv::Point>> *detections, std::vector<float> *confidences)
{
    BEGIN_WRAP
    model->detect(*frame, *detections, *confidences);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_detectTextRectangles(
    cv::dnn::TextDetectionModel *model, cv::_InputArray *frame,
    std::vector<cv::RotatedRect> *detections, std::vector<float> *confidences)
{
    BEGIN_WRAP
    model->detectTextRectangles(*frame, *detections, *confidences);
    END_WRAP
}

// ----------------------------------------------------------------------------
// TextDetectionModel_EAST
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_new_String(
    const char *model, const char *config, cv::dnn::TextDetectionModel_EAST **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::TextDetectionModel_EAST(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::TextDetectionModel_EAST(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_new_Net(
    cv::dnn::Net *network, cv::dnn::TextDetectionModel_EAST **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::TextDetectionModel_EAST(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_delete(cv::dnn::TextDetectionModel_EAST *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_setConfidenceThreshold(
    cv::dnn::TextDetectionModel_EAST *model, const float confThreshold)
{
    BEGIN_WRAP
    model->setConfidenceThreshold(confThreshold);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_getConfidenceThreshold(
    cv::dnn::TextDetectionModel_EAST *model, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getConfidenceThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_setNMSThreshold(
    cv::dnn::TextDetectionModel_EAST *model, const float nmsThreshold)
{
    BEGIN_WRAP
    model->setNMSThreshold(nmsThreshold);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_EAST_getNMSThreshold(
    cv::dnn::TextDetectionModel_EAST *model, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getNMSThreshold();
    END_WRAP
}

// ----------------------------------------------------------------------------
// TextDetectionModel_DB
// ----------------------------------------------------------------------------

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_new_String(
    const char *model, const char *config, cv::dnn::TextDetectionModel_DB **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    *returnValue = new cv::dnn::TextDetectionModel_DB(dnn_readNetGated(model, config, "", cv::dnn::ENGINE_AUTO));
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    *returnValue = new cv::dnn::TextDetectionModel_DB(model, configStr);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_new_Net(
    cv::dnn::Net *network, cv::dnn::TextDetectionModel_DB **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::TextDetectionModel_DB(*network);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_delete(cv::dnn::TextDetectionModel_DB *model)
{
    BEGIN_WRAP
    delete model;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setBinaryThreshold(
    cv::dnn::TextDetectionModel_DB *model, const float binaryThreshold)
{
    BEGIN_WRAP
    model->setBinaryThreshold(binaryThreshold);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getBinaryThreshold(
    cv::dnn::TextDetectionModel_DB *model, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getBinaryThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setPolygonThreshold(
    cv::dnn::TextDetectionModel_DB *model, const float polygonThreshold)
{
    BEGIN_WRAP
    model->setPolygonThreshold(polygonThreshold);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getPolygonThreshold(
    cv::dnn::TextDetectionModel_DB *model, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getPolygonThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setUnclipRatio(
    cv::dnn::TextDetectionModel_DB *model, const double unclipRatio)
{
    BEGIN_WRAP
    model->setUnclipRatio(unclipRatio);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getUnclipRatio(
    cv::dnn::TextDetectionModel_DB *model, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getUnclipRatio();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_setMaxCandidates(
    cv::dnn::TextDetectionModel_DB *model, const int maxCandidates)
{
    BEGIN_WRAP
    model->setMaxCandidates(maxCandidates);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_TextDetectionModel_DB_getMaxCandidates(
    cv::dnn::TextDetectionModel_DB *model, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = model->getMaxCandidates();
    END_WRAP
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
