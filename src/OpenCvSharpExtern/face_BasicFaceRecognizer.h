#ifndef _CPP_FACE_BASICFACERECOGNIZER_H_
#define _CPP_FACE_BASICFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;

CVAPI(int) face_BasicFaceRecognizer_getNumComponents(BasicFaceRecognizer *obj)
{
    return obj->getNumComponents();
}
CVAPI(void) face_BasicFaceRecognizer_setNumComponents(BasicFaceRecognizer *obj, int val)
{
    obj->getNumComponents();
}

CVAPI(double) face_BasicFaceRecognizer_getThreshold(BasicFaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_BasicFaceRecognizer_setThreshold(BasicFaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}
CVAPI(void) face_BasicFaceRecognizer_getProjections(BasicFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    std::vector<cv::Mat> result = obj->getProjections();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->push_back(result[i]);
    }
}
CVAPI(void) face_BasicFaceRecognizer_getLabels(BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getLabels();
    result.copyTo(*dst);
}
CVAPI(void) face_BasicFaceRecognizer_getEigenValues(BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getEigenValues();
    result.copyTo(*dst);
}
CVAPI(void) face_BasicFaceRecognizer_getEigenVectors(BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getEigenVectors();
    result.copyTo(*dst);
}
CVAPI(void) face_BasicFaceRecognizer_getMean(BasicFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getMean();
    result.copyTo(*dst);
}


CVAPI(BasicFaceRecognizer*) face_Ptr_BasicFaceRecognizer_get(cv::Ptr<BasicFaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_BasicFaceRecognizer_delete(cv::Ptr<BasicFaceRecognizer> *obj)
{
    delete obj;
}

#endif