#pragma once

#ifndef NO_CONTRIB

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

#pragma region FaceRecognizer

CVAPI(ExceptionStatus) face_FaceRecognizer_train(
    cv::face::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    return cvTry([&] {
    std::vector<cv::Mat> srcVec(srcLength);
    for (auto i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    const std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->train(srcVec, labelsVec);
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_update(
    cv::face::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    return cvTry([&] {
    std::vector<cv::Mat> srcVec(srcLength);
    for (auto i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    const std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->update(srcVec, labelsVec);
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_predict1(cv::face::FaceRecognizer *obj, cv::_InputArray *src, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->predict(*src);
    });
}
CVAPI(ExceptionStatus) face_FaceRecognizer_predict2(
    cv::face::FaceRecognizer *obj, cv::_InputArray *src, int *label, double *confidence)
{
    return cvTry([&] {
    obj->predict(*src, *label, *confidence);
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_write1(cv::face::FaceRecognizer *obj, const char *filename)
{
    return cvTry([&] {
    obj->write(filename);
    });
}
CVAPI(ExceptionStatus) face_FaceRecognizer_read1(cv::face::FaceRecognizer *obj, const char *filename)
{
    return cvTry([&] {
    obj->read(filename);
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_write2(cv::face::FaceRecognizer *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
    obj->write(*fs);
    });
}
CVAPI(ExceptionStatus) face_FaceRecognizer_read2(cv::face::FaceRecognizer *obj, cv::FileNode *fn)
{
    return cvTry([&] {
    obj->read(*fn);
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_setLabelInfo(cv::face::FaceRecognizer *obj, int label, const char *strInfo)
{
    return cvTry([&] {
    obj->setLabelInfo(label, strInfo);
    });
}
CVAPI(ExceptionStatus) face_FaceRecognizer_getLabelInfo(cv::face::FaceRecognizer *obj, int label, std::string *dst)
{
    return cvTry([&] {
    const auto result = obj->getLabelInfo(label);
    dst->assign(result);
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_getLabelsByString(cv::face::FaceRecognizer *obj, const char* str, std::vector<int> *dst)
{
    return cvTry([&] {
    const auto result = obj->getLabelsByString(str);
    std::copy(result.begin(), result.end(), std::back_inserter(*dst));
    });
}

CVAPI(ExceptionStatus) face_FaceRecognizer_getThreshold(cv::face::FaceRecognizer *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getThreshold();
    });
}
CVAPI(ExceptionStatus) face_FaceRecognizer_setThreshold(cv::face::FaceRecognizer *obj, double val)
{
    return cvTry([&] {
    obj->setThreshold(val);
    });
}

#pragma endregion

#pragma region BasicFaceRecognizer

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getNumComponents(cv::face::BasicFaceRecognizer *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNumComponents();
    });
}
CVAPI(ExceptionStatus) face_BasicFaceRecognizer_setNumComponents(cv::face::BasicFaceRecognizer *obj, int val)
{
    return cvTry([&] {
    obj->setNumComponents(val);
    });
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getThreshold(cv::face::BasicFaceRecognizer *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getThreshold();
    });
}
CVAPI(ExceptionStatus) face_BasicFaceRecognizer_setThreshold(cv::face::BasicFaceRecognizer *obj, double val)
{
    return cvTry([&] {
    obj->setThreshold(val);
    });
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getProjections(cv::face::BasicFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    return cvTry([&] {
    auto result = obj->getProjections();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->push_back(result[i]);
    }
    });
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getLabels(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    return cvTry([&] {
    const auto result = obj->getLabels();
    result.copyTo(*dst);
    });
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getEigenValues(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    return cvTry([&] {
    const auto result = obj->getEigenValues();
    result.copyTo(*dst);
    });
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getEigenVectors(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    return cvTry([&] {
    const auto result = obj->getEigenVectors();
    result.copyTo(*dst);
    });
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getMean(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    return cvTry([&] {
    const auto result = obj->getMean();
    result.copyTo(*dst);
    });
}

#pragma endregion

#pragma region EigenFaceRecognizer

CVAPI(ExceptionStatus) face_EigenFaceRecognizer_create(
    const int numComponents, const double threshold, cv::Ptr<cv::face::EigenFaceRecognizer> **returnValue)
{
    return cvTry([&] {
    const auto r = cv::face::EigenFaceRecognizer::create(numComponents, threshold);
    *returnValue = clone(r);
    });
}

CVAPI(ExceptionStatus) face_Ptr_EigenFaceRecognizer_get(cv::Ptr<cv::face::EigenFaceRecognizer> *obj, cv::face::EigenFaceRecognizer **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) face_Ptr_EigenFaceRecognizer_delete(cv::Ptr<cv::face::EigenFaceRecognizer> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

#pragma endregion 

#pragma region FisherFaceRecognizer

CVAPI(ExceptionStatus) face_FisherFaceRecognizer_create(
    const int numComponents, const double threshold, cv::Ptr<cv::face::FisherFaceRecognizer> **returnValue)
{
    return cvTry([&] {
    const auto r = cv::face::FisherFaceRecognizer::create(numComponents, threshold);
    *returnValue = clone(r);
    });
}

CVAPI(ExceptionStatus) face_Ptr_FisherFaceRecognizer_get(cv::Ptr<cv::face::FisherFaceRecognizer> *obj, cv::face::FisherFaceRecognizer **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) face_Ptr_FisherFaceRecognizer_delete(cv::Ptr<cv::face::FisherFaceRecognizer> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

#pragma endregion 

#pragma region LBPHFaceRecognizer

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_create(
    const int radius, const int neighbors, const int gridX, const int gridY, const double threshold,
    cv::Ptr<cv::face::LBPHFaceRecognizer> **returnValue)
{
    return cvTry([&] {
    const auto r = cv::face::LBPHFaceRecognizer::create(radius, neighbors, gridX, gridY, threshold);
    *returnValue = clone(r);
    });
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getGridX(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getGridX();
    });
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setGridX(cv::face::LBPHFaceRecognizer *obj, int val)
{
    return cvTry([&] {
    obj->setGridX(val);
    });
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getGridY(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getGridY();
    });
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setGridY(cv::face::LBPHFaceRecognizer *obj, int val)
{
    return cvTry([&] {
    obj->setGridY(val);
    });
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getRadius(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getRadius();
    });
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setRadius(cv::face::LBPHFaceRecognizer *obj, int val)
{
    return cvTry([&] {
    obj->setRadius(val);
    });
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getNeighbors(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNeighbors();
    });
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setNeighbors(cv::face::LBPHFaceRecognizer *obj, int val)
{
    return cvTry([&] {
    obj->setNeighbors(val);
    });
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getThreshold(cv::face::LBPHFaceRecognizer *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getThreshold();
    });
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setThreshold(cv::face::LBPHFaceRecognizer *obj, double val)
{
    return cvTry([&] {
    obj->setThreshold(val);
    });
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getHistograms(cv::face::LBPHFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    return cvTry([&] {
    auto result = obj->getHistograms();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->at(i) = result[i];
    }
    });
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getLabels(cv::face::LBPHFaceRecognizer *obj, cv::Mat *dst)
{
    return cvTry([&] {
    const auto result = obj->getLabels();
    result.copyTo(*dst);
    });
}


CVAPI(ExceptionStatus) face_Ptr_LBPHFaceRecognizer_get(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj, cv::face::LBPHFaceRecognizer **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) face_Ptr_LBPHFaceRecognizer_delete(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

#pragma endregion

#endif // !_WINRT_DLL
#endif // NO_CONTRIB