#ifndef _CPP_FACE_FACERECOGNIZER_H_
#define _CPP_FACE_FACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region FaceRecognizer

CVAPI(ExceptionStatus) face_FaceRecognizer_train(
    cv::face::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    BEGIN_WRAP
    std::vector<cv::Mat> srcVec(srcLength);
    for (auto i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    const std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->train(srcVec, labelsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_update(
    cv::face::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    BEGIN_WRAP
    std::vector<cv::Mat> srcVec(srcLength);
    for (auto i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    const std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->update(srcVec, labelsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_predict1(cv::face::FaceRecognizer *obj, cv::_InputArray *src, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->predict(*src);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FaceRecognizer_predict2(
    cv::face::FaceRecognizer *obj, cv::_InputArray *src, int *label, double *confidence)
{
    BEGIN_WRAP
    obj->predict(*src, *label, *confidence);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_write1(cv::face::FaceRecognizer *obj, const char *filename)
{
    BEGIN_WRAP
    obj->write(filename);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FaceRecognizer_read1(cv::face::FaceRecognizer *obj, const char *filename)
{
    BEGIN_WRAP
    obj->read(filename);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_write2(cv::face::FaceRecognizer *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->write(*fs);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FaceRecognizer_read2(cv::face::FaceRecognizer *obj, cv::FileNode *fn)
{
    BEGIN_WRAP
    obj->read(*fn);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_setLabelInfo(cv::face::FaceRecognizer *obj, int label, const char *strInfo)
{
    BEGIN_WRAP
    obj->setLabelInfo(label, strInfo);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FaceRecognizer_getLabelInfo(cv::face::FaceRecognizer *obj, int label, std::string *dst)
{
    BEGIN_WRAP
    const auto result = obj->getLabelInfo(label);
    dst->assign(result);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_getLabelsByString(cv::face::FaceRecognizer *obj, const char* str, std::vector<int> *dst)
{
    BEGIN_WRAP
    const auto result = obj->getLabelsByString(str);
    std::copy(result.begin(), result.end(), std::back_inserter(*dst));
    END_WRAP
}

CVAPI(ExceptionStatus) face_FaceRecognizer_getThreshold(cv::face::FaceRecognizer *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) face_FaceRecognizer_setThreshold(cv::face::FaceRecognizer *obj, double val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}

#pragma endregion

#pragma region BasicFaceRecognizer

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getNumComponents(cv::face::BasicFaceRecognizer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNumComponents();
    END_WRAP
}
CVAPI(ExceptionStatus) face_BasicFaceRecognizer_setNumComponents(cv::face::BasicFaceRecognizer *obj, int val)
{
    BEGIN_WRAP
    obj->setNumComponents(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getThreshold(cv::face::BasicFaceRecognizer *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) face_BasicFaceRecognizer_setThreshold(cv::face::BasicFaceRecognizer *obj, double val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getProjections(cv::face::BasicFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    BEGIN_WRAP
    auto result = obj->getProjections();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->push_back(result[i]);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getLabels(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    BEGIN_WRAP
    const auto result = obj->getLabels();
    result.copyTo(*dst);
    END_WRAP
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getEigenValues(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    BEGIN_WRAP
    const auto result = obj->getEigenValues();
    result.copyTo(*dst);
    END_WRAP
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getEigenVectors(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    BEGIN_WRAP
    const auto result = obj->getEigenVectors();
    result.copyTo(*dst);
    END_WRAP
}

CVAPI(ExceptionStatus) face_BasicFaceRecognizer_getMean(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    BEGIN_WRAP
    const auto result = obj->getMean();
    result.copyTo(*dst);
    END_WRAP
}

#pragma endregion

#pragma region EigenFaceRecognizer

CVAPI(ExceptionStatus) face_EigenFaceRecognizer_create(
    const int numComponents, const double threshold, cv::Ptr<cv::face::EigenFaceRecognizer> **returnValue)
{
    BEGIN_WRAP
    const auto r = cv::face::EigenFaceRecognizer::create(numComponents, threshold);
    *returnValue = clone(r);
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_EigenFaceRecognizer_get(cv::Ptr<cv::face::EigenFaceRecognizer> *obj, cv::face::EigenFaceRecognizer **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_EigenFaceRecognizer_delete(cv::Ptr<cv::face::EigenFaceRecognizer> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

#pragma endregion 

#pragma region FisherFaceRecognizer

CVAPI(ExceptionStatus) face_FisherFaceRecognizer_create(
    const int numComponents, const double threshold, cv::Ptr<cv::face::FisherFaceRecognizer> **returnValue)
{
    BEGIN_WRAP
    const auto r = cv::face::FisherFaceRecognizer::create(numComponents, threshold);
    *returnValue = clone(r);
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_FisherFaceRecognizer_get(cv::Ptr<cv::face::FisherFaceRecognizer> *obj, cv::face::FisherFaceRecognizer **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_FisherFaceRecognizer_delete(cv::Ptr<cv::face::FisherFaceRecognizer> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

#pragma endregion 

#pragma region LBPHFaceRecognizer

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_create(
    const int radius, const int neighbors, const int gridX, const int gridY, const double threshold,
    cv::Ptr<cv::face::LBPHFaceRecognizer> **returnValue)
{
    BEGIN_WRAP
    const auto r = cv::face::LBPHFaceRecognizer::create(radius, neighbors, gridX, gridY, threshold);
    *returnValue = clone(r);
    END_WRAP
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getGridX(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getGridX();
    END_WRAP
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setGridX(cv::face::LBPHFaceRecognizer *obj, int val)
{
    BEGIN_WRAP
    obj->setGridX(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getGridY(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getGridY();
    END_WRAP
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setGridY(cv::face::LBPHFaceRecognizer *obj, int val)
{
    BEGIN_WRAP
    obj->setGridY(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getRadius(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRadius();
    END_WRAP
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setRadius(cv::face::LBPHFaceRecognizer *obj, int val)
{
    BEGIN_WRAP
    obj->setRadius(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getNeighbors(cv::face::LBPHFaceRecognizer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNeighbors();
    END_WRAP
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setNeighbors(cv::face::LBPHFaceRecognizer *obj, int val)
{
    BEGIN_WRAP
    obj->setNeighbors(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getThreshold(cv::face::LBPHFaceRecognizer *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_setThreshold(cv::face::LBPHFaceRecognizer *obj, double val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getHistograms(cv::face::LBPHFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    BEGIN_WRAP
    auto result = obj->getHistograms();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->at(i) = result[i];
    }
    END_WRAP
}
CVAPI(ExceptionStatus) face_LBPHFaceRecognizer_getLabels(cv::face::LBPHFaceRecognizer *obj, cv::Mat *dst)
{
    BEGIN_WRAP
    const auto result = obj->getLabels();
    result.copyTo(*dst);
    END_WRAP
}


CVAPI(ExceptionStatus) face_Ptr_LBPHFaceRecognizer_get(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj, cv::face::LBPHFaceRecognizer **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}
CVAPI(ExceptionStatus) face_Ptr_LBPHFaceRecognizer_delete(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

#pragma endregion 

#endif
