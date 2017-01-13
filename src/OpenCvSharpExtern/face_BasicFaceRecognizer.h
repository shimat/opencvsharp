#ifndef _CPP_FACE_BASICFACERECOGNIZER_H_
#define _CPP_FACE_BASICFACERECOGNIZER_H_

#include "include_opencv.h"
using namespace cv::face;

CVAPI(cv::Ptr<BasicFaceRecognizer>*) face_createEigenFaceRecognizer(int numComponents, double threshold)
{
    return clone(createEigenFaceRecognizer(numComponents, threshold));
}
CVAPI(cv::Ptr<BasicFaceRecognizer>*) face_createFisherFaceRecognizer(int numComponents, double threshold)
{
    return clone(createFisherFaceRecognizer(numComponents, threshold));
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