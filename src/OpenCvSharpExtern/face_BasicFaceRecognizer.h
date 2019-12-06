#ifndef _CPP_FACE_BASICFACERECOGNIZER_H_
#define _CPP_FACE_BASICFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

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

#endif