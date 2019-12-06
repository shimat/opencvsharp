#ifndef _CPP_FACE_EIGENFACERECOGNIZER_H_
#define _CPP_FACE_EIGENFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::face::EigenFaceRecognizer>*) face_EigenFaceRecognizer_create(
	const int numComponents, const double threshold)
{
	const auto r = cv::face::EigenFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(cv::face::EigenFaceRecognizer*) face_Ptr_EigenFaceRecognizer_get(cv::Ptr<cv::face::EigenFaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_EigenFaceRecognizer_delete(cv::Ptr<cv::face::EigenFaceRecognizer> *obj)
{
	delete obj;
}

#endif