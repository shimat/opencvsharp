#ifndef _CPP_FACE_H_
#define _CPP_FACE_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

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

CVAPI(cv::Ptr<LBPHFaceRecognizer>*) face_createLBPHFaceRecognizer(
    int radius, int neighbors, int gridX, int gridY, double threshold)
{
    return clone(createLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold));
}

#endif