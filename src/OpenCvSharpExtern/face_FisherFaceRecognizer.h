#ifndef _CPP_FACE_FISHERFACERECOGNIZER_H_
#define _CPP_FACE_FISHERFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;


CVAPI(cv::Ptr<FisherFaceRecognizer>*) face_FisherFaceRecognizer_create(
	const int numComponents, const double threshold)
{
	const auto r = FisherFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(FisherFaceRecognizer*) face_Ptr_FisherFaceRecognizer_get(cv::Ptr<FisherFaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_FisherFaceRecognizer_delete(cv::Ptr<FisherFaceRecognizer> *obj)
{
	delete obj;
}

#endif