#ifndef _CPP_FACE_LBPHFACERECOGNIZER_H_
#define _CPP_FACE_LBPHFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;



CVAPI(LBPHFaceRecognizer*) face_Ptr_LBPHFaceRecognizer_get(cv::Ptr<LBPHFaceRecognizer> *obj)
{
    return obj->get();
}
CVAPI(void) face_Ptr_LBPHFaceRecognizer_delete(cv::Ptr<LBPHFaceRecognizer> *obj)
{
    delete obj;
}


#endif