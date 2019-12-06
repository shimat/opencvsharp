#ifndef _CPP_FACE_FISHERFACERECOGNIZER_H_
#define _CPP_FACE_FISHERFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::face::FisherFaceRecognizer>*) face_FisherFaceRecognizer_create(
	const int numComponents, const double threshold)
{
	const auto r = cv::face::FisherFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(cv::face::FisherFaceRecognizer*) face_Ptr_FisherFaceRecognizer_get(cv::Ptr<cv::face::FisherFaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_FisherFaceRecognizer_delete(cv::Ptr<cv::face::FisherFaceRecognizer> *obj)
{
	delete obj;
}

#endif