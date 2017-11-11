#ifndef _CPP_FACE_H_
#define _CPP_FACE_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;

CVAPI(cv::Ptr<EigenFaceRecognizer>*) face_createEigenFaceRecognizer(int numComponents, double threshold)
{
	auto r = EigenFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(cv::Ptr<FisherFaceRecognizer>*) face_createFisherFaceRecognizer(int numComponents, double threshold)
{
	auto r = FisherFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(cv::Ptr<LBPHFaceRecognizer>*) face_createLBPHFaceRecognizer(
    int radius, int neighbors, int gridX, int gridY, double threshold)
{
	auto r = LBPHFaceRecognizer::create(radius, neighbors, gridX, gridY, threshold);
	return clone(r);
}

#endif