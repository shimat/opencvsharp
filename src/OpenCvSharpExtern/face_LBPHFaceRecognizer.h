#ifndef _CPP_FACE_LBPHFACERECOGNIZER_H_
#define _CPP_FACE_LBPHFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;


CVAPI(int) face_LBPHFaceRecognizer_getGridX(LBPHFaceRecognizer *obj)
{
    return obj->getGridX();
}
CVAPI(void) face_LBPHFaceRecognizer_setGridX(LBPHFaceRecognizer *obj, int val)
{
    obj->setGridX(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getGridY(LBPHFaceRecognizer *obj)
{
    return obj->getGridY();
}
CVAPI(void) face_LBPHFaceRecognizer_setGridY(LBPHFaceRecognizer *obj, int val)
{
    obj->setGridY(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getRadius(LBPHFaceRecognizer *obj)
{
    return obj->getRadius();
}
CVAPI(void) face_LBPHFaceRecognizer_setRadius(LBPHFaceRecognizer *obj, int val)
{
    obj->setRadius(val);
}
CVAPI(int) face_LBPHFaceRecognizer_getNeighbors(LBPHFaceRecognizer *obj)
{
    return obj->getNeighbors();
}
CVAPI(void) face_LBPHFaceRecognizer_setNeighbors(LBPHFaceRecognizer *obj, int val)
{
    obj->setNeighbors(val);
}
CVAPI(double) face_LBPHFaceRecognizer_getThreshold(LBPHFaceRecognizer *obj)
{
    return obj->getThreshold();
}
CVAPI(void) face_LBPHFaceRecognizer_setThreshold(LBPHFaceRecognizer *obj, double val)
{
    obj->setThreshold(val);
}
CVAPI(void) face_LBPHFaceRecognizer_getHistograms(LBPHFaceRecognizer *obj, std::vector<cv::Mat> *dst)
{
    std::vector<cv::Mat> result = obj->getHistograms();
    dst->clear();
    dst->reserve(result.size());
    for (size_t i = 0; i < result.size(); i++)
    {
        dst->at(i) = result[i];
    }
}
CVAPI(void) face_LBPHFaceRecognizer_getLabels(LBPHFaceRecognizer *obj, cv::Mat *dst)
{
    cv::Mat result = obj->getLabels();
    result.copyTo(*dst);
}


CVAPI(LBPHFaceRecognizer*) face_Ptr_LBPHFaceRecognizer_get(cv::Ptr<LBPHFaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_LBPHFaceRecognizer_delete(cv::Ptr<LBPHFaceRecognizer> *obj)
{
    delete obj;
}


#endif