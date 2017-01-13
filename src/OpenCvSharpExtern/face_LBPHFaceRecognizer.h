#ifndef _CPP_FACE_LBPHFACERECOGNIZER_H_
#define _CPP_FACE_LBPHFACERECOGNIZER_H_

#include "include_opencv.h"
using namespace cv::face;


CVAPI(cv::Ptr<LBPHFaceRecognizer>*) face_createLBPHFaceRecognizer(
    int radius, int neighbors, int gridX, int gridY, double threshold)
{
    return clone(createLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold));
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