#ifndef _CPP_FACE_FACERECOGNIZER_H_
#define _CPP_FACE_FACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


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

#endif
