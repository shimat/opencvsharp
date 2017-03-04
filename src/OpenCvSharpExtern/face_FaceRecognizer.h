#ifndef _CPP_FACE_FACERECOGNIZER_H_
#define _CPP_FACE_FACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;


CVAPI(void) face_FaceRecognizer_train(
    FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    std::vector<cv::Mat> srcVec(srcLength);
    for (int i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->train(srcVec, labelsVec);
}
CVAPI(void) face_FaceRecognizer_update(
    FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
    std::vector<cv::Mat> srcVec(srcLength);
    for (int i = 0; i < srcLength; i++)
        srcVec[i] = *src[i];
    std::vector<int> labelsVec(labels, labels + labelsLength);
    obj->update(srcVec, labelsVec);
}
CVAPI(int) face_FaceRecognizer_predict1(FaceRecognizer *obj, cv::_InputArray *src)
{
    return obj->predict(*src);
}
CVAPI(void) face_FaceRecognizer_predict2(
    FaceRecognizer *obj, cv::_InputArray *src, int *label, double *confidence)
{
    obj->predict(*src, *label, *confidence);
}
CVAPI(void) face_FaceRecognizer_save1(FaceRecognizer *obj, const char *filename)
{
    obj->save(filename);
}
CVAPI(void) face_FaceRecognizer_load1(FaceRecognizer *obj, const char *filename)
{
    obj->load(filename);
}
CVAPI(void) face_FaceRecognizer_save2(FaceRecognizer *obj, cv::FileStorage *fs)
{
    obj->save(*fs);
}
CVAPI(void) face_FaceRecognizer_load2(FaceRecognizer *obj, cv::FileStorage *fs)
{
    obj->load(*fs);
}

CVAPI(void) face_FaceRecognizer_setLabelInfo(FaceRecognizer *obj, int label, const char *strInfo)
{
    obj->setLabelInfo(label, strInfo);
}
CVAPI(void) face_FaceRecognizer_getLabelInfo(FaceRecognizer *obj, int label, std::vector<uchar> *dst)
{
    cv::String result = obj->getLabelInfo(label);
    dst->resize(result.size() + 1);
    std::memcpy(&((*dst)[0]), result.c_str(), result.size() + 1);
}

CVAPI(void) face_FaceRecognizer_getLabelsByString(FaceRecognizer *obj, const char* str, std::vector<int> *dst)
{
    std::vector<int> result = obj->getLabelsByString(str);
    std::copy(result.begin(), result.end(), std::back_inserter(*dst));
}

CVAPI(double) face_FaceRecognizer_getThreshold(FaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_FaceRecognizer_setThreshold(FaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}


CVAPI(FaceRecognizer*) face_Ptr_FaceRecognizer_get(cv::Ptr<FaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_FaceRecognizer_delete(cv::Ptr<FaceRecognizer> *obj)
{
    delete obj;
}

#endif
