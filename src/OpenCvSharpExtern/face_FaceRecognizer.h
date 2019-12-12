#ifndef _CPP_FACE_FACERECOGNIZER_H_
#define _CPP_FACE_FACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region FaceRecognizer

CVAPI(void) face_FaceRecognizer_train(
    cv::face::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    std::vector<cv::Mat> srcVec(srcLength);
    for (int i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->train(srcVec, labelsVec);
}
CVAPI(void) face_FaceRecognizer_update(
    cv::face::FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    std::vector<cv::Mat> srcVec(srcLength);
    for (int i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->update(srcVec, labelsVec);
}
CVAPI(int) face_FaceRecognizer_predict1(cv::face::FaceRecognizer *obj, cv::_InputArray *src)
{
    return obj->predict(*src);
}
CVAPI(void) face_FaceRecognizer_predict2(
    cv::face::FaceRecognizer *obj, cv::_InputArray *src, int *label, double *confidence)
{
    obj->predict(*src, *label, *confidence);
}
CVAPI(void) face_FaceRecognizer_write1(cv::face::FaceRecognizer *obj, const char *filename)
{
    obj->write(filename);
}
CVAPI(void) face_FaceRecognizer_read1(cv::face::FaceRecognizer *obj, const char *filename)
{
    obj->read(filename);
}
CVAPI(void) face_FaceRecognizer_write2(cv::face::FaceRecognizer *obj, cv::FileStorage *fs)
{
    obj->write(*fs);
}
CVAPI(void) face_FaceRecognizer_read2(cv::face::FaceRecognizer *obj, cv::FileNode *fn)
{
    obj->read(*fn);
}

CVAPI(void) face_FaceRecognizer_setLabelInfo(cv::face::FaceRecognizer *obj, int label, const char *strInfo)
{
    obj->setLabelInfo(label, strInfo);
}
CVAPI(void) face_FaceRecognizer_getLabelInfo(cv::face::FaceRecognizer *obj, int label, std::vector<uchar> *dst)
{
    cv::String result = obj->getLabelInfo(label);
    dst->resize(result.size() + 1);
    std::memcpy(&((*dst)[0]), result.c_str(), result.size() + 1);
}

CVAPI(void) face_FaceRecognizer_getLabelsByString(cv::face::FaceRecognizer *obj, const char* str, std::vector<int> *dst)
{
    std::vector<int> result = obj->getLabelsByString(str);
    std::copy(result.begin(), result.end(), std::back_inserter(*dst));
}

CVAPI(double) face_FaceRecognizer_getThreshold(cv::face::FaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_FaceRecognizer_setThreshold(cv::face::FaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}


CVAPI(cv::face::FaceRecognizer*) face_Ptr_FaceRecognizer_get(cv::Ptr<cv::face::FaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_FaceRecognizer_delete(cv::Ptr<cv::face::FaceRecognizer> *obj)
{
    delete obj;
}

#pragma endregion

#pragma region BasicFaceRecognizer

CVAPI(int) face_BasicFaceRecognizer_getNumComponents(cv::face::BasicFaceRecognizer *obj)
{
    return obj->getNumComponents();
}
CVAPI(void) face_BasicFaceRecognizer_setNumComponents(cv::face::BasicFaceRecognizer *obj, int val)
{
    obj->setNumComponents(val);
}

CVAPI(double) face_BasicFaceRecognizer_getThreshold(cv::face::BasicFaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_BasicFaceRecognizer_setThreshold(cv::face::BasicFaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}
CVAPI(void) face_BasicFaceRecognizer_getProjections(cv::face::BasicFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    std::vector<cv::Mat> result = obj->getProjections();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->push_back(result[i]);
    }
}
CVAPI(void) face_BasicFaceRecognizer_getLabels(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getLabels();
    result.copyTo(*dst);
}
CVAPI(void) face_BasicFaceRecognizer_getEigenValues(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getEigenValues();
    result.copyTo(*dst);
}
CVAPI(void) face_BasicFaceRecognizer_getEigenVectors(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getEigenVectors();
    result.copyTo(*dst);
}
CVAPI(void) face_BasicFaceRecognizer_getMean(cv::face::BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getMean();
    result.copyTo(*dst);
}


CVAPI(cv::face::BasicFaceRecognizer*) face_Ptr_BasicFaceRecognizer_get(cv::Ptr<cv::face::BasicFaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_BasicFaceRecognizer_delete(cv::Ptr<cv::face::BasicFaceRecognizer> *obj)
{
    delete obj;
}

#pragma endregion

#pragma region EigenFaceRecognizer

CVAPI(cv::Ptr<cv::face::EigenFaceRecognizer>*) face_EigenFaceRecognizer_create(
	const int numComponents, const double threshold)
{
	const auto r = cv::face::EigenFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(cv::face::EigenFaceRecognizer*) face_Ptr_EigenFaceRecognizer_get(cv::Ptr<cv::face::EigenFaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_EigenFaceRecognizer_delete(cv::Ptr<cv::face::EigenFaceRecognizer> *obj)
{
	delete obj;
}

#pragma endregion 

#pragma region FisherFaceRecognizer

CVAPI(cv::Ptr<cv::face::FisherFaceRecognizer>*) face_FisherFaceRecognizer_create(
	const int numComponents, const double threshold)
{
	const auto r = cv::face::FisherFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(cv::face::FisherFaceRecognizer*) face_Ptr_FisherFaceRecognizer_get(cv::Ptr<cv::face::FisherFaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_FisherFaceRecognizer_delete(cv::Ptr<cv::face::FisherFaceRecognizer> *obj)
{
	delete obj;
}

#pragma endregion 

#pragma region LBPHFaceRecognizer

CVAPI(cv::Ptr<cv::face::LBPHFaceRecognizer>*) face_LBPHFaceRecognizer_create(
	const int radius, const int neighbors, const int gridX, const int gridY, const double threshold)
{
	const auto r = cv::face::LBPHFaceRecognizer::create(radius, neighbors, gridX, gridY, threshold);
	return clone(r);
}

CVAPI(int) face_LBPHFaceRecognizer_getGridX(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getGridX();
}
CVAPI(void) face_LBPHFaceRecognizer_setGridX(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setGridX(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getGridY(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getGridY();
}
CVAPI(void) face_LBPHFaceRecognizer_setGridY(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setGridY(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getRadius(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getRadius();
}
CVAPI(void) face_LBPHFaceRecognizer_setRadius(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setRadius(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getNeighbors(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getNeighbors();
}
CVAPI(void) face_LBPHFaceRecognizer_setNeighbors(cv::face::LBPHFaceRecognizer *obj, int val)
{
    obj->setNeighbors(val);
}
CVAPI(double) face_LBPHFaceRecognizer_getThreshold(cv::face::LBPHFaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_LBPHFaceRecognizer_setThreshold(cv::face::LBPHFaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}
CVAPI(void) face_LBPHFaceRecognizer_getHistograms(cv::face::LBPHFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    std::vector<cv::Mat> result = obj->getHistograms();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->at(i) = result[i];
    }
}
CVAPI(void) face_LBPHFaceRecognizer_getLabels(cv::face::LBPHFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getLabels();
    result.copyTo(*dst);
}


CVAPI(cv::face::LBPHFaceRecognizer*) face_Ptr_LBPHFaceRecognizer_get(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_LBPHFaceRecognizer_delete(cv::Ptr<cv::face::LBPHFaceRecognizer> *obj)
{
    delete obj;
}

#pragma endregion 

#endif
